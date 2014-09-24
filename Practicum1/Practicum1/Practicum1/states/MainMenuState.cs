using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Practicum1;
using Practicum1.gameobjects;

namespace Practicum1.states
{
    class MainMenuState : State
    {
        TextObject pressStartText, pressPText, powerUpsToggleText, powerUpsToggleText2;
        string powerUpText;
        Color powerUpColor;
        public MainMenuState()
        {
            pressPText = new TextObject("Press <P> to\ntoggle powerups", new Vector2(Practicum1.Screen.X - 250, 25), Color.Black, null, "Press P Text");
            powerUpsToggleText = new TextObject("Powerups: ", new Vector2(Practicum1.Screen.X - 250, 90), Color.Black, null, "PowerUps Toggle Text");
            powerUpsToggleText2 = new TextObject("On", new Vector2(Practicum1.Screen.X - 100, 90), Color.Green, null, "PowerUps Toggle Text 2");
            pressStartText = new TextObject("Press <1> to begin\na game with two players\n\nPress <2> to begin\n a game with four players", new Vector2(Practicum1.Screen.X/2-180, Practicum1.Screen.Y/2-50), Color.Black, null, "Main Menu Text");

            this.Add(pressPText);
            this.Add(powerUpsToggleText);
            this.Add(powerUpsToggleText2);
            this.Add(pressStartText);
        }
        
        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.IsKeyPressed(Keys.D1))
            {
                Practicum1.GameStateManager.SwitchTo("twoPlayerState");
            }

            if(inputHelper.IsKeyPressed(Keys.D2))
            {
                Practicum1.GameStateManager.SwitchTo("fourPlayerState");
            }
            if (inputHelper.IsKeyPressed(Keys.P))
            {
                Practicum1.PowerUpsOn = !Practicum1.PowerUpsOn;
                if (Practicum1.PowerUpsOn)
                {
                    powerUpText = "On";
                    powerUpColor = Color.Green;
                }
                else
                {
                    powerUpText = "Off";
                    powerUpColor = Color.Red;
                }

                powerUpsToggleText2.Text = "" + powerUpText;
                powerUpsToggleText2.Color = powerUpColor;

            }
            if (inputHelper.IsKeyPressed(Keys.F1))
            {
                Practicum1.GameStateManager.SwitchTo("helpState");
            }
        }
    }
}
