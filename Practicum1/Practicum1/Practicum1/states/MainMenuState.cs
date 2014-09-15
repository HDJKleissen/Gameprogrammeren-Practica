using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Practicum1;
using Practicum1.gameobjects;

namespace Practicum1.states
{
    class MainMenuState : State
    {
         
        public MainMenuState()
        {
            TextObject pressStartText = new TextObject("Press <SPACEBAR> to begin/na game with two players", new Vector2(Practicum1.Screen.X/2, Practicum1.Screen.Y/2), Color.Black, null, "Main Menu Text");
            this.Add(pressStartText);
        }
    }
}
