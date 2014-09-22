using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Practicum1.states;
using System.Diagnostics;

namespace Practicum1.gameobjects
{
    public class PowerUp : GameObject
    {
        private ContentManager Content;
        private PowerUpType chosenType;
        private Texture2D OPSmallerspr, OPSlowerspr, TPBiggerspr, TPFasterspr;
        
        public PowerUp(Texture2D sprite, Vector2 position, ContentManager Content, string name)
            : base(sprite, position, name)
        {
            this.Content = Content;
            OPSmallerspr = Content.Load<Texture2D>("pwrupOPSmaller");
            OPSlowerspr = Content.Load<Texture2D>("pwrupOPSlower");
            TPBiggerspr = Content.Load<Texture2D>("pwrupTPBigger");
            TPFasterspr = Content.Load<Texture2D>("pwrupTPFaster");
            Reset();
        }

        public void ChooseRandomPowerUp()
        {
            Array powerUpsArray = Enum.GetValues(typeof(PowerUpType));
            chosenType = (PowerUpType)powerUpsArray.GetValue(Practicum1.Random.Next(powerUpsArray.Length));
            sprite = TextureFromPowerUpType(chosenType, Content);
        }

        public Texture2D TextureFromPowerUpType(PowerUpType tempType, ContentManager Content)
        {
            Debug.Print(name + " has chosen " + tempType);
            switch (tempType)
            {
                case PowerUpType.OPSmaller:
                    return OPSmallerspr;
                case PowerUpType.OPSlower:
                    return OPSlowerspr;
                case PowerUpType.TPBigger:
                    return TPBiggerspr;
                case PowerUpType.TPFaster:
                    return TPFasterspr;
                default:
                    return Content.Load<Texture2D>("");
            }
        }

        public override void Update(GameTime gameTime)
        {
            if(Practicum1.TimerManager.TimerDone(timerName) && Practicum1.PowerUpsOn)
            {
                visible = true;
            }
            else
            {
                visible = false;
            }
            base.Update(gameTime);
        }

        public override void Reset()
        {
            Practicum1.TimerManager.setTimer(timerName, 10f);
            visible = false;
            ChooseRandomPowerUp();
            int newPosX = Practicum1.Random.Next(sprite.Width * 3, Practicum1.Screen.X - sprite.Width * 3);
            int newPosY = Practicum1.Random.Next(sprite.Height * 3, Practicum1.Screen.Y - sprite.Height * 3);
            position = new Vector2(newPosX, newPosY);
        }

        public PowerUpType ChosenType
        {
            get { return chosenType; }
        }
    }
}
