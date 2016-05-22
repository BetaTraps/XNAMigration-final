using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNAMigration
{
    class Tile
    {
        protected Texture2D texture;

        private Rectangle rect;
        public Rectangle Rect
        {
            get { return rect; }
            protected set { rect = value; }
        }
        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(texture, rect, Color.White);
        }
    }
    class CollisionTiles : Tile
    {
        public CollisionTiles(int i, Rectangle newRect)
        {
            texture = Content.Load<Texture2D>("Tile" + i);
            this.Rect = newRect;
        }
    }
}
