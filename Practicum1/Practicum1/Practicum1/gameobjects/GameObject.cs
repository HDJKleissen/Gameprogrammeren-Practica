using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Practicum1.gameobjects
{
    public class GameObject
    {
        protected Texture2D sprite;
        protected Vector2 position, velocity, startPosition;
        protected string name, timerName;
        protected bool visible;
        protected float spriteScale;

        public GameObject(Texture2D sprite, Vector2 position, string name)
        {
            timerName = name.Replace(" ", string.Empty) + "timer";
            this.sprite = sprite;
            this.position = position;
            startPosition = position;
            this.name = name;
            this.visible = true;
            spriteScale = 1f;
            Practicum1.TimerManager.setTimer(timerName, -1f);
        }


        public virtual void Update(GameTime gameTime)
        {
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (sprite != null && visible)
            {
                spriteBatch.Draw(sprite, position, null, Color.White, 0, Vector2.Zero, new Vector2(1, spriteScale), SpriteEffects.None, 0);
            }
        }

        public Rectangle BoundingBox
        {
            get{ return new Rectangle((int)position.X, (int)position.Y, sprite.Width, (int)(sprite.Height * spriteScale)); }
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
            set { sprite = value; }
        }

        public float SpriteScale
        {
            get { return spriteScale; }
            set { spriteScale = value; }
        }

        public virtual void Reset()
        {
            position = startPosition;
        }

        public virtual void HandleInput(InputHelper inputHelper)
        {
            
        }
    }
}