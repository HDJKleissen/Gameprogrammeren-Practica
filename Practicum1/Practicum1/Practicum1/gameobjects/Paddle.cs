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
        bool vertical;
        Vector2 beginPosition;

        public Paddle(Texture2D sprite, Texture2D livesSprite, Vector2 position, float newVelocity, Keys key1, Keys key2, bool vertical, String name)
            : base(sprite, position, name)
        {
            this.sprite = sprite;
            this.livesSprite = livesSprite;
            this.position = position;
            this.beginPosition = position;
            this.newVelocity = newVelocity;
            this.key1 = key1;
            this.key2 = key2;
            this.vertical = vertical;
            baseVelocity = newVelocity;
            lives = 3;
            Practicum1.TimerManager.setTimer(timerName + "1", -1);
        }
        public void checkMaxRange()
        {
            if (vertical)
            {
                if (position.Y < 0)
                {
                    position.Y = 0;
                }
                else if (position.Y + sprite.Height * spriteScale > Practicum1.Screen.Y)
                {
                    position.Y = Practicum1.Screen.Y - sprite.Height * spriteScale;
                }
            }
            else
            {
                if (position.X < 0)
                {
                    position.X = 0;
                }
                else if (position.X + sprite.Width * spriteScale > Practicum1.Screen.X)
                {
                    position.X = Practicum1.Screen.X - sprite.Width * spriteScale;
                }
            }

        }

        public void DrawLevens(float posX, float posY, SpriteBatch spriteBatch)
        {
            // draw lives
            for (int i = 0; lives > i; i++)
            {
                spriteBatch.Draw(livesSprite, new Vector2(i * livesSprite.Width + posX, posY), Color.White);
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
            if(lives <= 0)
            {
                visible = false;
                this.position = new Vector2(-200, -200);
            }
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (sprite != null && visible)
            {
                if (vertical)
                {
                    spriteBatch.Draw(sprite, position, null, Color.White, 0, Vector2.Zero, new Vector2(1, spriteScale), SpriteEffects.None, 0);
                }
                else
                {
                    spriteBatch.Draw(sprite, position, null, Color.White, 0, Vector2.Zero, new Vector2(spriteScale, 1), SpriteEffects.None, 0);
                }
            }
        
            if (name.Equals("Player 1"))
                DrawLevens(position.X, Practicum1.Screen.Y-livesSprite.Height, spriteBatch);
            else if (name.Equals("Player 2"))
                DrawLevens(position.X - (livesSprite.Width * lives) + sprite.Width, 0, spriteBatch);
            else if (name.Equals("Player 3"))
                DrawLevens(0, position.Y, spriteBatch);
            else if (name.Equals("Player 4"))
                DrawLevens(Practicum1.Screen.X - (livesSprite.Width * lives), position.Y, spriteBatch);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            checkMaxRange();
            if (vertical)
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
            else
            {
                if(inputHelper.IsKeyDown(key1))
                {
                    velocity.X = -newVelocity;
                }
                else if (inputHelper.IsKeyDown(key2))
                {
                    velocity.X = newVelocity;
                }
                else
                {
                    velocity.X = 0;
                }
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
            position = beginPosition;
            visible = true;
            base.Reset();
        }
        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }
    }
}