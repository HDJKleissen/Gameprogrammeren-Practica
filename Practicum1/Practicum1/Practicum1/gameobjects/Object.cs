﻿using System;
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
        protected Texture2D sprite;
        protected Vector2 position, velocity;
        protected string name;
        protected bool visible;
        public Object(Texture2D sprite, Vector2 position, string name)
        {
            this.sprite = sprite;
            this.position = position;
            this.name = name;
            this.visible = true;
        }


        public virtual void Update(GameTime gameTime)
        {
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (sprite != null && visible)
            {
                spriteBatch.Draw(sprite, position, Color.White);
            }
        }

        public Rectangle BoundingBox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height); }
        }

        public string Name
        {
            get { return name; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        public Texture2D Sprite
        {
            get { return sprite; }
        }

        public virtual void Reset()
        {

        }

        public virtual void HandleInput(InputHelper inputHelper)
        {
            
        }
    }
}