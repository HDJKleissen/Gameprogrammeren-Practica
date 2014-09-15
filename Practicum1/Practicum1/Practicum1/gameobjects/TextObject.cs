using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Practicum1.gameobjects
{
    class TextObject : Object
    {
        protected string text;
        protected bool visible;
        protected Color color;
        public SpriteFont spriteFont = Practicum1.GameFont;
        
        public TextObject(string text, Vector2 position, Color color, Texture2D sprite, string name) : base(sprite, position, name)
        {
            this.text = text;
            this.position = position;
            this.color = color;
            visible = true;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (visible)
                 spriteBatch.DrawString(spriteFont, text, position, color);
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Size
        {
            get
            {
                return spriteFont.MeasureString(text);
            }
        }
    }
}
