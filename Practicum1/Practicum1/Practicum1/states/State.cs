using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Practicum1.states
{
    public class State
    {
        protected List<Object> gameObjects;
        public State()
        {
            gameObjects = new List<Object>();
        }

        public void Add(Object obj)
        {
            gameObjects.Add(obj);
        }

        public void Remove(Object obj)
        {
            gameObjects.Remove(obj);
        }

        public Object Find(string name)
        {
            foreach (Object obj in gameObjects)
            {
                if (obj.Name == name)
                    return obj;
            }
            return null;
        }

        public List<Object> Objects
        {
            get { return gameObjects; }
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (Object obj in gameObjects)
            {
                obj.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            List<Object>.Enumerator e = gameObjects.GetEnumerator();
            while (e.MoveNext())
                e.Current.Draw(gameTime, spriteBatch);
        }

        public virtual void HandleInput(InputHelper inputHelper)
        {
            foreach (Object obj in gameObjects)
            {
                obj.HandleInput(inputHelper);
            }
        }

        public virtual void Reset()
        {
            foreach (Object obj in gameObjects)
            {
                obj.Reset();
            }
        }
    }
}
