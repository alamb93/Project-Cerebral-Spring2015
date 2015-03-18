using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cerebral
{
    public class StartScreen
    {
        private SpriteFont font;
        private int height;
        private int width;
        private float length;
        Game1 game;
        private MouseState oldState;

        public StartScreen(Game1 game)
        {
            this.game = game;
            height = game.GraphicsDevice.PresentationParameters.BackBufferHeight;
            width = game.GraphicsDevice.PresentationParameters.BackBufferWidth;
            font = game.Content.Load<SpriteFont>("Assets/Font/SpriteFont1"); 
            length = font.MeasureString("Cerebral").Length();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(font, "Cerebral", new Vector2(height / 2, width / 2 - length), Color.White);
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            MouseState newState = Mouse.GetState();
            int x = mouseState.X;
            int y = mouseState.Y;

            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                game.start();
            }
            oldState = newState; // this reassigns the old state so that it is ready for next time
        }
    }
}
