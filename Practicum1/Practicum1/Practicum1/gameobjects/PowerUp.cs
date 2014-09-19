using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Practicum1.states;

namespace Practicum1.gameobjects
{
    public class PowerUp : GameObject
    {
        private ContentManager Content;
        private PowerUpType chosenType;
        public PowerUp(Texture2D sprite, Vector2 position, ContentManager Content, string name)
            : base(sprite, position, name)
        {
            this.Content = Content;
            Reset();
        }

        public void ChooseRandomPowerUp()
        {
            Array powerUpsArray = Enum.GetValues(typeof(PowerUpType));
            chosenType = (PowerUpType)powerUpsArray.GetValue(Practicum1.Random.Next(powerUpsArray.Length));
            sprite = TextureFromPowerUpType(chosenType, Content);
        }

        public Texture2D TextureFromPowerUpType(PowerUpType chosenType, ContentManager Content)
        {
            switch (chosenType)
            {
                case PowerUpType.OPSmaller:
                    return Content.Load<Texture2D>("pwrupOPSmaller");
                case PowerUpType.OPSlower:
                    return Content.Load<Texture2D>("pwrupOPSlower");
                case PowerUpType.TPBigger:
                    return Content.Load<Texture2D>("pwrupTPBigger");
                case PowerUpType.TPFaster:
                    return Content.Load<Texture2D>("pwrupTPFaster");
                default:
                    return Content.Load<Texture2D>("");
            }
        }

        public override void Reset()
        {
            int newPosX = Practicum1.Random.Next(50, Practicum1.Screen.X - 50);
            int newPosY = Practicum1.Random.Next(25, Practicum1.Screen.Y - 25);
            position = new Vector2(newPosX, newPosY);
            ChooseRandomPowerUp();
        }

        public PowerUpType ChosenType
        {
            get { return chosenType; }
        }
    }
}
