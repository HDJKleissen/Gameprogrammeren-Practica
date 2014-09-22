using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace Practicum1.gameobjects
{
    public class Paddle : GameObject
    {
        int lives;
        Texture2D livesSprite;
        Keys key1, key2;
        float newVelocity, baseVelocity;

        public Paddle(Texture2D sprite, Texture2D livesSprite, Vector2 position, float newVelocity, Keys key1, Keys key2, String name)
            : base(sprite, position, name)
        {
            this.position = position;
            this.sprite = sprite;
            this.livesSprite = livesSprite;
            this.key1 = key1;
            this.key2 = key2;
            this.newVelocity = newVelocity;
            baseVelocity = newVelocity;
            lives = 3;
            Practicum1.TimerManager.setTimer(timerName + "1", -1);
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
            else if (position.Y + sprite.Height*spriteScale > Practicum1.Screen.Y)
            {
                position.Y = Practicum1.Screen.Y - sprite.Height*spriteScale;
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

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Practicum1.TimerManager.TimerDone(timerName) && newVelocity != baseVelocity)
            {
                newVelocity = baseVelocity;
            }
            if(Practicum1.TimerManager.TimerDone(timerName + "1") && spriteScale != 1f)
            {
                spriteScale = 1f;
            }
            Debug.Print("timer ended, reset stuffs");
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (name.Equals("Player 1"))
                DrawLevens(position.X, spriteBatch);
            else if (name.Equals("Player 2"))
                DrawLevens(position.X - (livesSprite.Width * lives) + sprite.Width, spriteBatch);
            base.Draw(gameTime, spriteBatch);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            checkMaxRange();
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

        public void HandlePowerup(PowerUpType powerUp)
        {
            Debug.Print("handling powerup");
            Debug.Print("set the timer");
            switch(powerUp)
            {
                case PowerUpType.OPSmaller:
                    spriteScale = 0.75f;
                    Practicum1.TimerManager.setTimer(timerName + "1", 7.5f);
                    Debug.Print("applying smaller powerup for " + name);
                    break;
                case PowerUpType.OPSlower:
                    newVelocity = baseVelocity / 2;
                    Practicum1.TimerManager.setTimer(timerName, 7.5f);
                    Debug.Print("applying slower powerup for " + name);
                    break;
                case PowerUpType.TPBigger:
                    spriteScale = 1.5f;
                    Practicum1.TimerManager.setTimer(timerName + "1", 7.5f);
                    Debug.Print("applying bigger powerup for " + name);
                    break;
                case PowerUpType.TPFaster:
                    newVelocity = baseVelocity * 2;
                    Practicum1.TimerManager.setTimer(timerName, 7.5f);
                    Debug.Print("applying faster powerup for " + name);
                    break;
                default:
                    break;
            }
        }

        public override void Reset()
        {
            lives = 3;
            base.Reset();
        }
        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }
    }
}