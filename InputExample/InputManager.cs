using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace InputExample
{
    public class InputManager
    {
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;
        MouseState currentMouseState;
        MouseState previousMouseState;
        GamePadState currentGamePadState;
        GamePadState previousGamePadState;

        /// <summary>
        /// The current direction
        /// </summary>
        public Vector2 Direction { get; private set; }

        /// <summary>
        /// If the warp functionality has been requested
        /// </summary>
        public bool Warp { get; private set; } = false;

        /// <summary>
        /// If the user has requested the game end
        /// </summary>
        public bool Exit { get; private set; } = false;

        public void Update(GameTime gameTime)
        {
            #region State Updating

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            previousGamePadState = currentGamePadState;
            currentGamePadState = GamePad.GetState(0);

            #endregion

            #region Direction Input
            //get position from Mouse
            //Direction = new Vector2(currentMouseState.X, currentMouseState.Y);

            //get direction from GamePad
            Direction = currentGamePadState.ThumbSticks.Left * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds * new Vector2(1,-1);

            //get direction from Keyboard
            if (currentKeyboardState.IsKeyDown(Keys.Left)
                || currentKeyboardState.IsKeyDown(Keys.A))
            {
                Direction += new Vector2(-100 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }

            if (currentKeyboardState.IsKeyDown(Keys.Right)
                || currentKeyboardState.IsKeyDown(Keys.D))
            {
                Direction += new Vector2(100 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }

            if (currentKeyboardState.IsKeyDown(Keys.Up)
                || currentKeyboardState.IsKeyDown(Keys.W))
            {
                Direction += new Vector2(0, -100 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (currentKeyboardState.IsKeyDown(Keys.Down)
                || currentKeyboardState.IsKeyDown(Keys.S))
            {
                Direction += new Vector2(0, 100 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            #endregion

            #region Warp Input

            Warp = false;

            if (currentKeyboardState.IsKeyDown(Keys.Space) && previousKeyboardState.IsKeyUp(Keys.Space))
            {
                Warp = true;
            }

            if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                Warp = true;
            }

            if (currentGamePadState.IsButtonDown(Buttons.A) && previousGamePadState.IsButtonUp(Buttons.A))
            {
                Warp = true;
            }

            #endregion

            #region Exit Input

            if (currentGamePadState.Buttons.Back == ButtonState.Pressed || currentKeyboardState.IsKeyDown(Keys.Escape))
            {
                Exit = true;
            }

            #endregion

        }
    }
}
