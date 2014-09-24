using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Practicum1.states;

namespace Practicum1
{
    public class GameStateManager
    {
        protected Dictionary<string, State> gameStates;
        protected State currentGameState;

        public GameStateManager()
        {
            gameStates = new Dictionary<string, State>();
            currentGameState = null;
        }

        public void AddGameState(string name, State state)
        {
            gameStates[name] = state;
        }

        public State GetGameState(string name)
        {
            return gameStates[name];
        }

        public void SwitchTo(string name)
        {
            if (gameStates.ContainsKey(name))
            {
                currentGameState = gameStates[name];
                Console.WriteLine("Switched gamestate to " + currentGameState);
            }     
        }

        public bool GetCurrentGameState(string name)
        {
            return gameStates[name] == currentGameState;
        }

        public State GetCurrentGameState()
        {
            return currentGameState;
        }

        public void Update(GameTime gameTime)
        {
            if (currentGameState != null)
                currentGameState.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (currentGameState != null)
                currentGameState.Draw(gameTime, spriteBatch);
        }

        public void HandleInput(InputHelper inputHelper)
        {
            if (currentGameState != null)
            {
                currentGameState.HandleInput(inputHelper);
            }
        }

        public void Reset()
        {
            if(currentGameState != null)
            {
                currentGameState.Reset();
            }
        }
    }
}
