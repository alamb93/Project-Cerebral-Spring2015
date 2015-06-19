#region Using Statements
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Cerebral.Scenes;
using Cerebral.Content;
using Microsoft.Xna.Framework.Media;
#endregion


namespace Cerebral
{
    public enum Screen
    {
        Scene1,
        Scene2A,
        Scene2B,
        Ending1,
        StartScreen,
    }

    public enum State
    {
        Walking,
        Reading,
        FirstPerson,
        Watching,
        Interacting
    }
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern uint MessageBox(IntPtr hWnd, String text, String caption, uint type);

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Scene1 sceneOne;
        Scene2A sceneTwoA;
        Scene2B sceneTwoB;
        Ending1 ending;
        StartScreen startScreen;
        Screen currentScreen;
        State currentState;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            Components.Add(new GameComponent(this));
            graphics.PreferredBackBufferHeight = 480;
            graphics.PreferredBackBufferWidth = 800;
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
            currentState = State.Interacting;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
            // TODO: Unload any non ContentManager content here*
        }

        /// <summary>
        /// Allows the game pto run logic such as updating the world,
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
                case Screen.Scene2A:
                    if (sceneTwoA != null)
                        sceneTwoA.Update();
                    break;
                case Screen.Scene2B:
                    if (sceneTwoB != null)
                        sceneTwoB.Update();
                    break;
                case Screen.Ending1:
                    if (ending != null)
                        ending.Update();
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
                case Screen.Scene2A:
                    if (sceneTwoA != null)
                        sceneTwoA.Draw(spriteBatch);
                    break;
                case Screen.Scene2B:
                    if (sceneTwoB != null)
                        sceneTwoB.Draw(spriteBatch);
                    break;
                case Screen.Ending1:
                    if (ending != null)
                        ending.Draw(spriteBatch);
                    break;
            }
            spriteBatch.End();
            //spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.Gray);
            //spriteBatch.Draw(dont, new Vector2(540, 220), Color.White);

           // animatedSprite.Draw(spriteBatch, new Vector2(400, 200));

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void transition(Screen newScene, int endingNum)
        {
            int num = endingNum;
            currentScreen = newScene;
            switch (currentScreen)
            {
                case Screen.Scene1:
                    sceneOne = new Scene1(this);
                    startScreen = null;  
                    break;
                case Screen.StartScreen:
                    startScreen = new StartScreen(this);
                    sceneOne = null;
                    sceneTwoA = null;
                    sceneTwoB = null;
                    ending = null;
                    break;
                case Screen.Scene2A:
                    sceneTwoA = new Scene2A(this);
                    sceneOne = null;
                    break;
                case Screen.Scene2B:
                    sceneTwoB = new Scene2B(this);
                    sceneOne = null;
                    break;
                case Screen.Ending1:
                    ending = new Ending1(this, num);
                    sceneOne = null;
                    sceneTwoA = null;
                    sceneTwoB = null;
                    startScreen = null;
                    break;
            }
        }

        public State getState()
        {
            return currentState;
        }

        public void setState(State newState)
        {
            currentState = newState;
        }
    }
}

