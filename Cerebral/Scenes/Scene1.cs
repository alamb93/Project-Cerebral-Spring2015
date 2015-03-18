#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System;
using System.Collections.Generic;
using Cerebral.Content;
#endregion

namespace Cerebral.Scenes
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Scene1
    {
        Game1 game;
        Camera cam;
        private Texture2D background;
        private Texture2D dont;
        private SpriteFont font;
        private int score = 0;
        private MouseState oldState;
        private KeyboardState previousState;


        public Scene1(Game1 game)
        {
            this.game = game;
            previousState = Keyboard.GetState();
            LoadContent();
            cam = new Camera(game.GraphicsDevice.Viewport);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public void Initialize()
        {
            // TODO: Add your initialization logic here
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            background = game.Content.Load<Texture2D>("Assets/Art/forest"); // change these names to the names of your images
            dont = game.Content.Load<Texture2D>("Assets/Art/dont");
            font = game.Content.Load<SpriteFont>("Assets/Font/SpriteFont1");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        public void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update()
        {
            // TODO: Add your update logic here
            MouseState mouseState = Mouse.GetState();
            MouseState newState = Mouse.GetState();
            int x = mouseState.X;
            int y = mouseState.Y;
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                if (x > 540 && y > 220 && x < 540 + dont.Height && y < 220 + dont.Width)
                {
                    score++;
                }

            }
            oldState = newState; // this reassigns the old state so that it is ready for next time
            cam.Update();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.Gray);
            spriteBatch.Draw(dont, new Vector2(540, 220), Color.White);
            spriteBatch.DrawString(font, "How many Didn't? " + score, new Vector2(130, 100), Color.Crimson);
            // TODO: Add your drawing code here
        }
    }
}
