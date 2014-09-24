using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using Practicum1.gameobjects;

namespace Practicum1.states
{
    class HelpState : State
    {
        TextObject helpText;

        public HelpState()
        {
            string text = "Controls\n\n    Player 1 (left): W and S\n    Player 2 (right): Up and Down arrow keys\n    Player 3 (top): O and P\n    Player 4 (bottom): V and B";
            helpText = new TextObject(text, new Vector2(100, 100), Color.Black, null, "helpText");
            this.Add(helpText);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.IsKeyPressed(Keys.Escape))
                Practicum1.GameStateManager.SwitchTo("mainMenuState");
            base.HandleInput(inputHelper);
        }
    }
}
