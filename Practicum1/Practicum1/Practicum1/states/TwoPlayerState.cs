﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Practicum1.gameobjects;

namespace Practicum1.states
{
    class TwoPlayerState : State
    {
        TextObject pressStartText;
        int i = 0;
        public TwoPlayerState()
        {
            pressStartText = new TextObject("Press <SPACEBAR> to begin\na game with two players", new Vector2(Practicum1.Screen.X/2-180, Practicum1.Screen.Y/2-50), Color.Black, null, "Main Menu Text");
            this.Add(pressStartText);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if(inputHelper.IsKeyPressed(Keys.Space))
            {
                Practicum1.GameStateManager.SwitchTo("mainMenuState");
            }
        }

        public override void Update(GameTime gameTime)
        {

            pressStartText.Position = new Vector2(Practicum1.Screen.X - i, Practicum1.Screen.Y - i);
            i++;
        }
    }
}
