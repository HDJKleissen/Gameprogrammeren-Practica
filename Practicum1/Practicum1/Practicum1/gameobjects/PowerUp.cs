using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Practicum1.gameobjects
{
    class PowerUp : Object
    {
        private PowerUpType chosenType;
        
        public PowerUp(PowerUpType chosenType, Texture2D sprite, Vector2 position, string name)
            : base(sprite, position, name)
        {
            this.chosenType = chosenType;
        }


    }
}
