#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Cerebral.Scenes;
#endregion

namespace Cerebral
{
    enum Screen
    {
        Scene1,
        StartScreen
    }
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Scene1 sceneOne;
        StartScreen startScreen;
        Screen currentScreen;

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
            startScreen = new StartScreen(this);
            currentScreen = Screen.StartScreen;
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
           
            switch (currentScreen)
            {
                case Screen.Scene1:
                    if (sceneOne != null)
                        sceneOne.Update();
                    break;
                case Screen.StartScreen:
                    if (startScreen != null)
                        startScreen.Update();
                        break;
            }
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
         
            spriteBatch.Begin();
            switch (currentScreen)
            {
                case Screen.Scene1:
                    if (sceneOne != null)
                        sceneOne.Draw(spriteBatch);
                    break;
                case Screen.StartScreen:
                    if (startScreen != null)
                        startScreen.Draw(spriteBatch);
                    break;
            }
            //spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.Gray);
            //spriteBatch.Draw(dont, new Vector2(540, 220), Color.White);

            spriteBatch.End();

           // animatedSprite.Draw(spriteBatch, new Vector2(400, 200));

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void start()
        {
            sceneOne = new Scene1(this);
            currentScreen = Screen.Scene1;
            startScreen = null;
        }
    }
}

