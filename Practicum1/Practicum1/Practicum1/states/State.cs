using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Practicum1.gameobjects;

namespace Practicum1.states
{
    public class State
    {
        protected List<GameObject> gameObjects;
        protected List<PowerUp> powerUpList = new List<PowerUp>();
        public State()
        {
            gameObjects = new List<GameObject>();
        }

        public void Add(GameObject obj)
        {
            gameObjects.Add(obj);
        }

        public void Remove(GameObject obj)
        {
            gameObjects.Remove(obj);
        }

        public GameObject Find(string name)
        {
            foreach (GameObject obj in gameObjects)
            {
                if (obj.Name == name)
                    return obj;
            }
            return null;
        }

        public List<GameObject> Objects
        {
            get { return gameObjects; }
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (GameObject obj in gameObjects)
            {
                obj.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            List<GameObject>.Enumerator e = gameObjects.GetEnumerator();
            while (e.MoveNext())
                e.Current.Draw(gameTime, spriteBatch);
        }

        public virtual void HandleInput(InputHelper inputHelper)
        {
            foreach (GameObject obj in gameObjects)
            {
                obj.HandleInput(inputHelper);
            }
        }

        public virtual void Reset()
        {
            foreach (GameObject obj in gameObjects)
            {
                obj.Reset();
            }
        }

        public List<PowerUp> PowerUpList
        {
            get { return powerUpList; }
        }
    }
}
