using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace Practicum1.gameobjects
{
    class PaddleAI : Paddle
    {
        Random random = new Random();
        private Ball ball;
        float difference;
        float newVelocity;

        public PaddleAI(Texture2D sprite, Texture2D livesSprite, Vector2 position, float newVelocity, bool vertical, String name)
            : base(sprite, livesSprite, position, newVelocity, Keys.None, Keys.None, vertical, name)
        {
            this.newVelocity = newVelocity;
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            //no input cause AI object
        }
        public override void Update(GameTime gametime)
        {
            difference = ball.Position.Y - position.Y;
            if (ball.Position.X > 550)
            {
                if (difference >= 50 || difference <= -50)
                {
                    if (difference > 0)
                    {
                        velocity.Y += 30 + random.Next(0, 20);
                    }
                    else
                    {
                        velocity.Y -= 30 + random.Next(0, 20);
                    }
                }
            }
            else
            {
                if (difference > 0)
                    velocity.Y = 50;
                else
                    velocity.Y = -50;
            }
            if(velocity.Y > newVelocity)
            {
                velocity.Y = newVelocity;
            }
            checkMaxRange();
            base.Update(gametime);
        }
        public Ball Ball
        {
            get { return ball; }
            set { ball = value; }
        }
    }
}