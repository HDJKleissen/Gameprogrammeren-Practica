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
    public class Paddle : Object
    {
        int lives;
        Texture2D livesSprite;
        Keys key1, key2;
        float newVelocity;

        public Paddle(Texture2D sprite, Texture2D livesSprite, Vector2 position, float newVelocity, Keys key1, Keys key2, String name)
            : base(sprite, position, name)
        {
            this.position = position;
            this.sprite = sprite;
            this.livesSprite = livesSprite;
            this.key1 = key1;
            this.key2 = key2;
            this.newVelocity = newVelocity;
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
        public void DrawLevens(float posX, SpriteBatch spriteBatch)
        {
            // draw lives
            for (int i = 0; lives > i; i++)
            {
                spriteBatch.Draw(livesSprite, new Vector2(i * livesSprite.Width + posX, 0), Color.White);
            }
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (name.Equals("Player 1"))
                DrawLevens(position.X, spriteBatch);
            else if (name.Equals("Player 2"))
                DrawLevens(position.X - (livesSprite.Width * lives) + sprite.Width, spriteBatch);
            base.Draw(gameTime, spriteBatch);
        }
        public void Move(Keys key1, Keys key2, float newVelocity)
        {
            
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.IsKeyDown(key1))
            {
                velocity.Y = -newVelocity;
            }
            else if (inputHelper.IsKeyDown(key2))
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