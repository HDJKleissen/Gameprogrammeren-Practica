using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace Practicum1
{
    class Paddle : Object
    {
        int lives;
        Texture2D livesSprite;
        
        public Paddle(Texture2D sprite, Vector2 position)
            : base(sprite, position)
        {
            this.position = position;
            this.sprite = sprite;
            lives = 3;
        }
        public void checkMaxRange()
        {
            //for 4 players horizontal checking
            //if (position.X < 0 || position.X + sprite.Width > Practicum1.Screen.X)// > Practicum1.Screen.width )
            // {
            // velocity.X = 0;
            // }
            if (position.Y < 0)
            {
                position.Y = 0;
            }
            else if (position.Y + sprite.Height > Practicum1.Screen.Y)
            {
                position.Y = Practicum1.Screen.Y - sprite.Height;
            }
        }
        
        
        public void drawlevens(int posX)
        {
            // draw lives
            for (int i = 0; lives > i; i++)
            {
                spriteBatch.Draw(livesSprite, new Vector2(i * livesSprite.Width + posX, 0), Color.White);
            }
        }
 
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
 
 
        public void Move(Keys key1, Keys key2, float newVelocity)
        {
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(key1))
            {
                velocity.Y = -newVelocity;
            }
            else if (keyState.IsKeyDown(key2))
            {
                velocity.Y = newVelocity;
            }
            else
            {
                velocity.Y = 0;
            }
        }
        
        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }
    }
}
