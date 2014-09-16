using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Practicum1
{
    public class InputHelper
    {
        protected KeyboardState currentKeyboardState, previousKeyboardState;

        public void Update()
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState(); 
        }

        public bool IsKeyPressed(Keys k)
        {
            return currentKeyboardState.IsKeyDown(k) && previousKeyboardState.IsKeyUp(k);
        }

        public bool IsKeyDown(Keys k)
        {
            return currentKeyboardState.IsKeyDown(k);
        }
    }
}
