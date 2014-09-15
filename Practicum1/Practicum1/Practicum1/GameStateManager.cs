using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Practicum1
{
    class GameStateManager : IGameLoopObject
    {
        protected Dictionary<string, IGameLoopObject> gameStates;
        protected IGameLoopObject currentGameState;

        public GameStateManager()
        {
            gameStates = new Dictionary<string, IGameLoopObject>();
            currentGameState = null;
        }

        public void AddGameState(string name, IGameLoopObject state)
        {
            gameStates[name] = state;
        }

        public IGameLoopObject getGameState(string name)
        {
            return gameStates[name];
        }

        public void SwitchTo(string name)
        {
            if (gameStates.ContainsKey(name))
                currentGameState = gameStates[name];
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

        public void HandleInput()
        {

        }   

        public void Reset()
        {
            
        }
    }
}
