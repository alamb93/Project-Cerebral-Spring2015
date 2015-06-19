#region Using Statements
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System;
using System.Collections.Generic;
using Cerebral.Content;
using Cerebral.Scenes;
using Microsoft.Xna.Framework.Media;
#endregion

namespace Cerebral.Scenes
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Scene1
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern uint MessageBox(IntPtr hWnd, String text, String caption, uint type);
        Game1 game;
        public Background background;
        private Texture2D dont;
        private Texture2D beer;
        private Texture2D shoes;
        private Texture2D keys;
        private Texture2D moss;
        private SpriteFont font;
        private bool keysHere = true;
        private bool clicked = false;
        private bool beerEmpty = false;
        private int score = 0;
        private MouseState oldState;
        private KeyboardState previousState;
        private TextBox box;
        private Male male;
        Scene1 scened;
        State gameState;
        Vector2 beerPos;
        Vector2 keyPos;
        Vector2 shoePos;
        Vector2 mossPos;
        Vector2 pathPos;
        Scene2A A;
        Scene2B B;
        Scene traSC;
        protected Song song;
        bool upOff = false;
        int mossCount;

        public Scene1(Game1 game)
        {
            this.game = game;
            previousState = Keyboard.GetState();
            LoadContent();                 
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
            //background = game.Content.Load<Texture2D>("Assets/Art/forest"); // change these names to the names of your images
            background = new Background(game, "Assets/Art/forest", .33f, 90, 850);
            dont = game.Content.Load<Texture2D>("Assets/Art/dont");
            beer = game.Content.Load<Texture2D>("Assets/Art/beer");
            shoes = game.Content.Load<Texture2D>("Assets/Art/shoes");
            keys = game.Content.Load<Texture2D>("Assets/Art/keys");
            font = game.Content.Load<SpriteFont>("Assets/Font/SpriteFont1");
            moss = game.Content.Load<Texture2D>("Assets/Art/moss");
            scened = this;
            box = new TextBox(0,0, game);
            male = new Male(game, background);
            gameState = State.Interacting;
            shoePos = new Vector2(150, 300);
            keyPos = new Vector2(50, 400);
            beerPos = new Vector2(330, 350);
            mossPos = new Vector2(-480,0);
            pathPos = new Vector2(470,118);
            A = new Scene2A(game);
            B = new Scene2B(game);
            traSC = new Scene(game);
            // TODO: use this.Content to load your game content here
            mossCount = 0;
            song = game.Content.Load<Song>("Assets/Music/scaryyyy");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        public void UnloadContent()
        {
            game.Content.Unload();
            // TODO: Unload any non ContentManager content here
        }

        protected static void GetMBResult(IAsyncResult r)
        {
            //int? b = EndShowMessageBox(r);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update()
        {
            gameState = game.getState();
            // TODO: Add your update logic here
            MouseState mouseState = Mouse.GetState();
            MouseState newState = Mouse.GetState(); 
            int x = mouseState.X;
            int y = mouseState.Y;
            //Console.WriteLine("X: " + x + " and " + "Y: " + y);
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                if (x > 540 && y > 220 && x < 540 + dont.Height && y < 220 + dont.Width)
                {
                    if (score >= 1 && !keysHere && beerEmpty)
                    {
                        //MessageBox(new IntPtr(0), "Good Job Genius! You're dead. I said DON'T!  Listen next time...", "Bad End", 0);
                          box.setText("Good Job Genius! You're dead. I said DON'T!  Listen next time...");
                          box.showMessage(true);
                    }

                    if (score >= 1 && keysHere)
                    {
                        //MessageBox(new IntPtr(0), "Good Job Genius! You're dead. I said DON'T!  Listen next time...", "Bad End", 0);
                        //  box.setText("Good Job Genius! You're dead. I said DON'T!  Listen next time...");
                        //  box.showMessage(true);
                     
                    }
                   // MessageBox(new IntPtr(0), "Please Dont.", "Sign", 0);
                    box.setText("Please Dont.");
                    box.showMessage(true);
                    score++;
                }

                if (x > shoePos.X && y > shoePos.Y && x < shoePos.X + shoes.Width && y < shoePos.Y + shoes.Height)
                {
                    //MessageBox(new IntPtr(0), "Two perfectly placed shoes lay flat on the forest floor. The pair is mysteriously alone in the woods with no owner in sight. Replacing them with your torn pair seems like a good idea if only they weren’t too small. They remind you of the running shoes you used to wear in middle school.", "TWO PERFECTLY PLACED SHOES", 0);
                    box.setText("Two perfectly placed shoes lay flat on the forest floor. The pair is mysteriously alone in the woods with no owner in sight. Replacing them with your torn pair seems like a good idea if only they weren't too small. They remind you of the running shoes you used to wear in middle school.");
                    //box.setText("How curious. Someone managed to leave behind a pair of shoes. The shoes are quite small, no more than a size four or five, and they're fairly new. You like the color scheme--jet black with neon red flames licking up the sides. It reminds you of the shiny new shoes you saw in the store windows when you were younger and always begged your mom to buy. It also reminds you of the people in school who had those shoes. You turn away from the shoes, trying to avoid the memories.");
                    box.showMessage(true);
                }

                if (x > beerPos.X && y > beerPos.Y && x < beerPos.X + beer.Width && y < beerPos.Y + beer.Height)
                {
                    if (keysHere)
                    {
                        box.setText("The amber liquid in the bottle looks strong, exactly what you need to calm your nerves. One sip or two wouldn't hurt, right?");
                        box.showMessage(true);
                        clicked = true;
                    }
                   // MessageBox(new IntPtr(0), "The amber liquid in the bottle looks strong, exactly what you need to calm your nerves. One sip or two wouldn’t hurt, right?", "ALCOHOL", 0);
                    if (!keysHere)
                    {
                       // MessageBox(new IntPtr(0), "You used the bottle opener on the keychain to open the bottle. You drink away and you pass out.", "ALCOHOL", 0);
                        box.setText("You used the bottle opener on the keychain to open the bottle. You drink away and you pass out.");
                        box.showMessage(true);
                        beerEmpty = true;
                    }
                }

                if (x > keyPos.X && y > keyPos.Y && x < keyPos.X + keys.Width && y < keyPos.Y + keys.Height && keysHere)
                {
                    //MessageBox(new IntPtr(0), "The key chain rattles unnervingly as you pick it up. There’s a large number of keys, perhaps to someone’s attic or garage, attached to one ring of the chain. A handy miniature flashlight and bottle opener are attached to the other.", "KEYCHAIN", 0);
                    box.setText("The key chain rattles unnervingly as you pick it up. There's a large number of keys, perhaps to someone's attic or garage, attached to one ring of the chain. A handy miniature flashlight and bottle opener are attached to the other.");
                    box.showMessage(true);
                    keysHere = false;

                }

                if (x > mossPos.X && y > mossPos.Y && x < mossPos.X + moss.Width && y < mossPos.Y + moss.Height)
                {
                    if (mossCount == 0)
                    {
                        box.setText("There seems to be something carved on the tree, but it's hidden by a thick patch of moss. ");
                        box.showMessage(true);
                    }

                    if (mossCount == 1)
                    {
                       box.setText("You brush some of the moss away and can faintly make out some letters. There's still too much moss to read it completely though.");
                       box.showMessage(true);
                    }

                    if (mossCount == 2)
                    {
                        box.setText("Finally! You blow scraps of moss off your hand, satisfied with the work you've done uncovering the tree carving. It seems to be directions to a location in the woods. Wouldn't hurt to go check it out now that you're done here. ");
                        box.showMessage(true);
                    }

                    if (mossCount == 3)
                    {
                        game.transition(Cerebral.Screen.Scene2A,0);
                    }
                    mossCount++;
                }

                if (x > pathPos.X && y > pathPos.Y && x < pathPos.X + 60 && y < pathPos.Y + 100)
                {
                    //MessageBox(new IntPtr(0), "The key chain rattles unnervingly as you pick it up. There’s a large number of keys, perhaps to someone’s attic or garage, attached to one ring of the chain. A handy miniature flashlight and bottle opener are attached to the other.", "KEYCHAIN", 0);
                    game.transition(Cerebral.Screen.Scene2B,0);

                }

                box.getInput(x, y);
            }
            oldState = newState; // this reassigns the old state so that it is ready for next time
            male.Update();
            box.Update();
            background.Update();
            if(gameState == State.Walking) {
                beerPos.X += background.offSet();
                keyPos.X += background.offSet();
                shoePos.X += background.offSet();
                mossPos.X += background.offSet();
                pathPos.X += background.offSet();
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
          //  spriteBatch.Draw(dont, new Vector2(540, 220), Color.White);
            if (!beerEmpty)
            {
            spriteBatch.Draw(beer, beerPos, Color.White);
            }
            spriteBatch.Draw(shoes, shoePos , Color.White);
            spriteBatch.Draw(moss, mossPos, Color.Gray);
            if (keysHere)
            {
                spriteBatch.Draw(keys, keyPos, Color.White);
            }
            male.Draw(spriteBatch);
            box.Draw(spriteBatch);
            
           // spriteBatch.DrawString(font, "How many Didn't? " + score, new Vector2(130, 100), Color.Crimson);
            // TODO: Add your drawing code here
        }


    }
}
