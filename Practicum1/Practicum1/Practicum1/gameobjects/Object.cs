using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace Practicum1
{
    public class Object : IGameLoopObject
    {
        public Texture2D sprite;
        public Vector2 position, velocity;
        public string name;

        public Object(Texture2D sprite, Vector2 position, string name)
        {
            this.sprite = sprite;
            this.position = position;
            this.name = name;
        }


        public virtual void Update(GameTime gameTime)
        {
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }

        public Rectangle BoundingBox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height); }
        }

        public string Name
        {
            get { return name; }
        }

        public virtual void Reset()
        {

        }

        public virtual void HandleInput()
        {
            
        }
    }
}