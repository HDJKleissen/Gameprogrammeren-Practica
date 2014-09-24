using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Practicum1.gameobjects;
using Practicum1.states;

namespace Practicum1.gameobjects
{
    public class Ball : GameObject
    {
        Random random = new Random();
        double direction, speed, startSpeed;
        List<Paddle> paddleList = new List<Paddle>();
        Paddle lastBouncePaddle = null;

        public Ball(Texture2D sprite, Vector2 position, double speed, List<Paddle> paddleList, string name)
            : base(sprite, position, name)
        {
            direction = random.NextDouble() * 2 * Math.PI;
            this.speed = speed;
            startSpeed = speed;
            this.paddleList = paddleList;
        }

        public override void Update(GameTime gameTime)
        {
            velocity.X = (float)(speed * Math.Cos(direction));
            velocity.Y = (float)(speed * Math.Sin(direction));

            State currentState = Practicum1.GameStateManager.GetCurrentGameState();

            if (!Practicum1.GameStateManager.GetCurrentGameState("fourPlayerState"))
            {
                if ((position.Y < 0 && velocity.Y < 0) || (position.Y > Practicum1.Screen.Y - sprite.Height && velocity.Y > 0))
                {
                    Bounce(false);
                }
            }

            if (position.X < 0)
            {
                foreach (Paddle paddle in paddleList)
                {
                    if (paddle.Name.Equals("Player 1"))
                    {
                        if (paddle.Lives > 0)
                        {
                            paddle.Lives -= 1;
                            Reset(paddle);
                        }
                        else if (velocity.X < 0)
                        {
                            Bounce(true);
                            Debug.Print("bouncing from left side");
                        }
                    }
                }
            }
                
            if (position.X + sprite.Width > Practicum1.Screen.X)
            {
                foreach (Paddle paddle in paddleList)
                {
                    if (paddle.Name.Equals("Player 2"))
                    {
                        if (paddle.Lives > 0)
                        {
                            paddle.Lives -= 1;
                            Reset(paddle);
                        }
                        else if(velocity.X > 0)
                        {
                            Bounce(true);
                            Debug.Print("bouncing from right side");
                        }
                    }
                }
            }

            if (Practicum1.GameStateManager.GetCurrentGameState("fourPlayerState"))
            {
                if (position.Y < 0)
                {
                    foreach (Paddle paddle in paddleList)
                    {
                        if (paddle.Name.Equals("Player 3"))
                        {
                            if (paddle.Lives > 0)
                            {
                                paddle.Lives -= 1;
                                Reset(paddle);
                            }
                            else if (velocity.Y < 0)
                            {
                                Bounce(false);
                            }
                        }
                    }
                }
                if (position.Y > Practicum1.Screen.Y - sprite.Height)
                {
                    foreach (Paddle paddle in paddleList)
                    {
                        if (paddle.Name.Equals("Player 4"))
                        {
                            if (paddle.Lives > 0)
                            {
                                paddle.Lives -= 1;
                                Reset(paddle);
                            }
                            else if (velocity.Y > 0)
                            {
                                Bounce(false);
                            }
                        }
                    }
                }
            }
            foreach (Paddle paddle in paddleList)
            {
                if (CheckCollision(paddle))
                    Bounce(paddle);
            }

            
            foreach (PowerUp pwrUp in currentState.PowerUpList)
            {
                if(CheckCollision(pwrUp) && pwrUp.Visible)
                {
                    Debug.Print("collision between ball and " + pwrUp.Name);
                    if (lastBouncePaddle != null)
                    {
                        foreach (Paddle paddle in paddleList)
                        {
                            if ((pwrUp.ChosenType == PowerUpType.OPSmaller || pwrUp.ChosenType == PowerUpType.OPSlower) && !paddle.Name.Equals(lastBouncePaddle.Name))
                            {
                                paddle.HandlePowerup(pwrUp.ChosenType);
                                Debug.Print("poweruptype is " + pwrUp.ChosenType + " and is for " + paddle.Name);
                            }
                            else if ((pwrUp.ChosenType == PowerUpType.TPBigger || pwrUp.ChosenType == PowerUpType.TPFaster) && paddle.Name.Equals(lastBouncePaddle.Name))
                            {
                                paddle.HandlePowerup(pwrUp.ChosenType);
                                Debug.Print("poweruptype is " + pwrUp.ChosenType + " and is for " + paddle.Name);
                            }
                        }
                    }
                    pwrUp.Reset();
                }
            }
            if(Practicum1.GameStateManager.GetCurrentGameState("trollState"))
            {
                foreach(Paddle paddle in paddleList)
                {
                    paddle.Lives = 3;
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            /* debugging
            int i = 0;
            foreach(Paddle paddle in paddleList)
            {
                spriteBatch.DrawString(Practicum1.GameFont, "" + paddle.Name + "  " + paddle.BoundingBox + "  " + CheckCollision(paddle), new Vector2(50, 0+i*20), Color.Black);
                i++;
            }
            
            spriteBatch.DrawString(Practicum1.GameFont, "velocity: " + velocity, new Vector2(100, 60), Color.Black);
            spriteBatch.DrawString(Practicum1.GameFont, "position: " + BoundingBox, new Vector2(100, 80), Color.Black);
            spriteBatch.DrawString(Practicum1.GameFont, "direction: " + direction, new Vector2(100, 100), Color.Black);
            */
            base.Draw(gameTime, spriteBatch);
        }

        public bool CheckCollision(GameObject obj)
        {
            Rectangle otherBounds = obj.BoundingBox;
            return BoundingBox.Intersects(otherBounds);
        }

        public void Bounce(bool sides)
        {
            if (sides)
            {
                direction = Math.PI - direction;
            }
            else
            {
                direction = -direction;
            }
        }

        public void Bounce(Paddle paddle)
        {
            if(paddle.Name.Equals("Player 1"))
            {
                float relativeIntersectY = (paddle.Position.Y + ((paddle.Sprite.Height * paddle.SpriteScale) / 2) - position.Y);
                float normalizedIntersectY = (relativeIntersectY / ((paddle.Sprite.Height * paddle.SpriteScale) / 2));
                direction = normalizedIntersectY * (-1 * Math.PI / 3);
                
            }
            else if(paddle.Name.Equals("Player 2"))
            {
                float relativeIntersectY = (paddle.Position.Y + ((paddle.Sprite.Height * paddle.SpriteScale) / 2) - position.Y);
                float normalizedIntersectY = (relativeIntersectY / (paddle.Sprite.Height * paddle.SpriteScale) / 2); 
                direction = Math.PI - normalizedIntersectY * (-1 * Math.PI / 3);
            }
            else if(paddle.Name.Equals("Player 3"))
            {
                float relativeIntersectX = (paddle.Position.X + ((paddle.Sprite.Width * paddle.SpriteScale) / 2) - position.X);
                float normalizedIntersectX = (relativeIntersectX / (paddle.Sprite.Width * paddle.SpriteScale) / 2);
                direction = (0.5 * Math.PI) - normalizedIntersectX * (-2 * Math.PI / 3);
            }
            else if (paddle.Name.Equals("Player 4"))
            {
                float relativeIntersectX = (paddle.Position.X + ((paddle.Sprite.Width * paddle.SpriteScale) / 2) - position.X);
                float normalizedIntersectX = (relativeIntersectX / (paddle.Sprite.Width * paddle.SpriteScale) / 2);
                direction = (1.5 * Math.PI) + normalizedIntersectX * (-2 * Math.PI / 3);
            }
            lastBouncePaddle = paddle;
            speed *= 1.04;
        }


        public void Reset(Paddle paddle)
        {
            position = new Vector2(Practicum1.Screen.X / 2, Practicum1.Screen.Y / 2);
            
            if (paddle.Name.Equals("Player 1"))
                direction = 0.75 * Math.PI + random.NextDouble() * 0.5 * Math.PI;
            else if (paddle.Name.Equals("Player 2"))
                direction = 0.25 * Math.PI - random.NextDouble() * 0.5 * Math.PI;
            else if (paddle.Name.Equals("Player 3"))
                direction = 0.25 * Math.PI + random.NextDouble() * 0.5 * Math.PI;
            else if (paddle.Name.Equals("Player 4"))
                direction = 0.75 * Math.PI - random.NextDouble() * 0.5 * Math.PI;
            lastBouncePaddle = null;
            speed = startSpeed;
        }
    }
}