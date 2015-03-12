#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Cerebral
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D background;
        private Texture2D dont;
        private SpriteFont font;
        private AnimatedSprite animatedSprite;
        private int score = 0;
        private int height;
        private int width;
        private float length;
        private MouseState oldState;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("Assets/Art/forest"); // change these names to the names of your images
            dont = Content.Load<Texture2D>("Assets/Art/dont");
            font = Content.Load<SpriteFont>("Assets/Font/SpriteFont1");
            Texture2D texture = Content.Load<Texture2D>("Assets/Art/SmileyWalk");
            animatedSprite = new AnimatedSprite(texture, 4, 4);
            height = GraphicsDevice.PresentationParameters.BackBufferHeight;
            width = GraphicsDevice.PresentationParameters.BackBufferWidth;
            length = font.MeasureString("Cerebral").Length();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            base.Update(gameTime);
            MouseState mouseState = Mouse.GetState();
            MouseState newState = Mouse.GetState();
            int x = mouseState.X;
            int y = mouseState.Y;
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
           // Move to the first scene  
            }
            oldState = newState; // this reassigns the old state so that it is ready for next time
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            //spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.Gray);
            //spriteBatch.Draw(dont, new Vector2(540, 220), Color.White);
            spriteBatch.DrawString(font, "Cerebral", new Vector2(height/2, width / 2 -length), Color.White);

            spriteBatch.End();

           // animatedSprite.Draw(spriteBatch, new Vector2(400, 200));

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

