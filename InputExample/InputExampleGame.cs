﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InputExample
{
    public class InputExampleGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Ball[] balls;

        InputManager inputManager;
        

        /// <summary>
        /// Constructs the game
        /// </summary>
        public InputExampleGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        /// <summary>
        /// Initializes the game
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            balls = new Ball[] {
                new Ball(this, Color.Red) { Position = new Vector2(250, 200) },
                new Ball(this, Color.Green) { Position = new Vector2(350, 200) },
                new Ball(this, Color.Blue) { Position = new Vector2(450, 200) }
            };
            inputManager = new InputManager();
            base.Initialize();
        }

        /// <summary>
        /// Loads game content
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            foreach (Ball b in balls) b.LoadContent();
        }

        /// <summary>
        /// Updates the game
        /// </summary>
        /// <param name="gameTime">The game time</param>
        protected override void Update(GameTime gameTime)
        {

            inputManager.Update(gameTime);

            if (inputManager.Exit) Exit();

            balls[1].Position += inputManager.Direction;

            if (inputManager.Warp)
            {
                balls[1].Warp();
            }

            // TODO: Add your update logic here
            

            

            

            

            

            

            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the game
        /// </summary>
        /// <param name="gameTime">The game time</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach (Ball b in balls) b.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
