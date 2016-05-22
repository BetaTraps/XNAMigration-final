using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XNAMigration
{
    class Bullet
    {
        Texture2D texture;
        Vector2 bulletPos;
        Vector2 OriginPos;
        float bulletVelocity = 1.0f;
        ContentManager Content;

        public Bullet(ContentManager content)
        {
            Content = content;
        }

        public Bullet() { }

        public Vector2 setOriginPos
        {
            set { OriginPos = value; }
        }

        public void UpdateBullet()
        {

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture,bulletPos,Color.White);    
        }

    }
}
