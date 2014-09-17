using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Practicum1.states.TwoPlayerState;
namespace Practicum1.gameobjects
{
    class PowerUp : Object
    {
        private enum powerUpType { };
        private powerUpType chosenType;

        public PowerUp(powerUpType PowerUpType, Texture2D sprite, Vector2 position, string name)
            : base(sprite, position, name)
        {
            chosenType = PowerUpType;
        }
    }
}
