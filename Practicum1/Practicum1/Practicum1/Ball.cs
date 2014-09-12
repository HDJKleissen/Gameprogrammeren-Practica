using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace Practicum1
{
    class Ball : Object
    {
        Random random = new Random();
        double direction, speed;
        List<Paddle> paddleList = new List<Paddle>();
        
        public Ball(Texture2D sprite, Vector2 position, double speed, List<Paddle> paddleList)
            : base(sprite, position)
        {
            direction = Math.PI;//random.NextDouble()*2*Math.PI;
            this.speed = speed;
            this.paddleList = paddleList;
            
        }
        public override void Update(GameTime gameTime)
        {
            velocity.X = (float)(speed * Math.Cos(direction));
            velocity.Y = (float)(speed * Math.Sin(direction));
            
            if((position.Y < 0 && velocity.Y < 0)
                || (position.Y > Practicum1.Screen.Y-sprite.Height && velocity.Y > 0))
            {
                Bounce();
            }
            foreach(Paddle paddle in paddleList)
            {
                if (CheckCollision(paddle))
                    Bounce(paddle);
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // debugging
            int i = 0;
            foreach(Paddle paddle in paddleList)
            {
                spriteBatch.DrawString(Practicum1.GameFont, "" + paddle.name + "  " + paddle.BoundingBox + "  " + CheckCollision(paddle), new Vector2(50, 0+i*20), Color.Black);
                i++;
            }
            spriteBatch.DrawString(Practicum1.GameFont, "velocity: " + velocity, new Vector2(100, 60), Color.Black);
            spriteBatch.DrawString(Practicum1.GameFont, "position: " + BoundingBox, new Vector2(100, 80), Color.Black);
            spriteBatch.DrawString(Practicum1.GameFont, "direction: " + direction, new Vector2(100, 100), Color.Black);
            base.Draw(gameTime, spriteBatch);
        }

        public bool CheckCollision(Paddle paddle)
        {
            Rectangle paddleBounds = paddle.BoundingBox;
            Rectangle ballBounds = this.BoundingBox;
            return ballBounds.Intersects(paddleBounds);
        }
        
        public void Bounce()
        {            
            direction = 2 * Math.PI - direction;
        }

        public void Bounce(Paddle paddle)
        {
            if(paddle.name.Equals("Player 1"))
            {
                float relativeIntersectY = (paddle.position.Y + (paddle.sprite.Height / 2) - position.Y);
                float normalizedIntersectY = (relativeIntersectY / (paddle.sprite.Height / 2));
                direction = normalizedIntersectY * (-1 * Math.PI / 3);
            }
            else if(paddle.name.Equals("Player 2"))
            {
                float relativeIntersectY = (paddle.position.Y + (paddle.sprite.Height / 2) - position.Y);
                float normalizedIntersectY = (relativeIntersectY / (paddle.sprite.Height / 2));
                direction = Math.PI - normalizedIntersectY * (-1 * Math.PI / 3);
            }
            speed *= 1.01;
        }
    }
}