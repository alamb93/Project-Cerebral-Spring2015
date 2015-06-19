using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System;
using System.Collections.Generic;
using Cerebral.Content;

namespace Cerebral.Scenes
{ 
    public class ThirdPerson
    {
        private Texture2D player;
        Game1 game;
        private MouseState oldState;

        public ThirdPerson(Game1 game){
            this.game = game;
           // cam = new Camera(game.GraphicsDevice.Viewport);
        }
        public void LoadContent(){
            player = game.Content.Load<Texture2D>("Assets/Art/dont");
        }
        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(player, new Vector2(540, 220), Color.White);
        }
        public void Update(){
            // TODO: Add your update logic here
            MouseState mouseState = Mouse.GetState();
            MouseState newState = Mouse.GetState();
            int x = mouseState.X;
            int y = mouseState.Y;
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                //Move player sprite
            }
            oldState = newState; // this reassigns the old state so that it is ready for next time
            //cam.Update();
        }
    }
}
