using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        private float wlength;
        Game1 game;
        private MouseState oldState;
        protected Song song;

        public StartScreen(Game1 game)
        {
            this.game = game;
            height = game.GraphicsDevice.Viewport.Bounds.Height;
            width = game.GraphicsDevice.Viewport.Bounds.Width;
            font = game.Content.Load<SpriteFont>("Assets/Font/SpriteFont1"); 
            length = font.MeasureString("{Cerebral}").Length();
            wlength = font.MeasureString("{Cerebral}").Y;
            song = game.Content.Load<Song>("Assets/Music/scaryyyy");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(font, "{Cerebral}", new Vector2(width / 2 - length/2, height/2 - wlength/2), Color.White);
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            MouseState newState = Mouse.GetState();
            int x = mouseState.X;
            int y = mouseState.Y;

            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                MediaPlayer.Stop();
                game.transition(Cerebral.Screen.Scene1,0);
            }
            oldState = newState; // this reassigns the old state so that it is ready for next time
        }
    }
}
