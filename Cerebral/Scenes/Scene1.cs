using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Cerebral.Scenes
{
    class Scene1
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

        public Scene1() : base()
        {

        }

        public void Update()
        {
            // TODO: Add your update logic here
            MouseState mouseState = Mouse.GetState();
            MouseState newState = Mouse.GetState();
            int x = mouseState.X;
            int y = mouseState.Y;
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                //Do Stuff
            }
            oldState = newState; // this reassigns the old state so that it is ready for next time
            Draw();
        }

        public void Draw()
        {
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.Gray);
            spriteBatch.Draw(dont, new Vector2(540, 220), Color.White);
            spriteBatch.DrawString(font, "Score", new Vector2(100, 100), Color.Azure);

            spriteBatch.End();
        }
    }
}
