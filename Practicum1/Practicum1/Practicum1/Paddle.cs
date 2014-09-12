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
        public String name;
        public Paddle(Texture2D sprite, Vector2 position, String name)
            : base(sprite, position)
        {
            this.position = position;
            this.sprite = sprite;
            this.name = name;
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
        //key1 == up key2 == down
        //void Update(GameTime gameTime)
        // {
        // base.Update(gameTime);
        // }
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
    }
}