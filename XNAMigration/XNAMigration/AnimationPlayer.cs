using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAMigration
{
    class AnimationPlayer
    {
        Animation animation;
        public Animation Animation
        {
            get { return animation; }
        }

        Rectangle rectangle;
        int frameIndex;
        public int FrameIndex
        {
            get { return frameIndex; }
            set { frameIndex = value; }
        }

        private float timer;

        public Vector2 Origin
        {
            get { return new Vector2(0, 0); }
        }

        

        public void PlayAnimation(Animation newAnimation)
        {
            if (animation == newAnimation)
                return;

            animation = newAnimation;
            frameIndex = 0;
            timer = 0;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 position, SpriteEffects flip)
        {
            if (Animation == null)
                throw new Exception("Some Thing went Wrong Bro. Sort this shit out.");

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            while (timer >= animation.FrameTime)
            {
                timer -= animation.FrameTime;

                if (animation.IsLooping)
                    frameIndex = (frameIndex + 1) % animation.FrameCount;
                else frameIndex = Math.Min(frameIndex + 1, animation.FrameCount - 1);
            }

            rectangle = new Rectangle(frameIndex * Animation.FrameWidth, 0, Animation.FrameWidth, Animation.FrameHight);

            

            spriteBatch.Draw(Animation.Texture, position, rectangle, Color.White, 0f, Origin, 1f, flip, 0f);
        }
        
    }
}
