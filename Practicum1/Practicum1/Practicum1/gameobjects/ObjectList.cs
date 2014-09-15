using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Practicum1.gameobjects
{
    class ObjectList : Object
    {
        protected List<Object> gameObjects;

        public ObjectList(Texture2D sprite, Vector2 position, string name = "") : base(sprite, position, name)
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
            foreach(Object obj in gameObjects)
            {
                if(obj.)
            }
        }
    }
}
