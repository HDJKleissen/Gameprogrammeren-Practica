using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Practicum1.gameobjects;
namespace Practicum1.states
{
    class GameOverState : State
    {
        Paddle winPaddle;
        TextObject winText;

        public override void Update(GameTime gameTime)
        {
            winPaddle = Practicum1.WinPaddle;
            if(winText == null)
            {
                winText = new TextObject(winPaddle.Name + " has won! Press space to return to main menu\nor press R to have a rematch", new Vector2(Practicum1.Screen.X / 2 - 200, Practicum1.Screen.Y - 150), Color.Black, null, "winText");
                this.Add(winText);
            }
            else
            {
                winText.Text = winPaddle.Name + " has won! Press space to return to main menu\nor press R to have a rematch";
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.IsKeyPressed(Keys.Space))
            {
                Practicum1.WinPaddle = null;
                Practicum1.GameStateManager.SwitchTo("mainMenuState");
            }
            else if (inputHelper.IsKeyPressed(Keys.R))
            {
                Practicum1.WinPaddle = null;
                Practicum1.GameStateManager.SwitchTo("twoPlayerState");
            }
            base.HandleInput(inputHelper);
        }
    }
}
