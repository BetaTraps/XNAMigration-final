using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace XNAMigration
{
    public class Player
    {
        AnimationPlayer animationPlayer;

        Animation Walk;
        Animation Idle;
        Animation Jump;
        Animation Yell;
        Animation Celebrate;

        private bool Right = false;
        private bool Left = false;
        private bool Up = false;
        private bool Down = false;
        private bool hasJumped = false;
        private bool isShoot = false;
        private bool isAttacking = false;
        private bool isStanding = true;

        private String lastDirection = "Right";

        private Vector2 Pos = new Vector2(50, 60);
        private Vector2 velocity;
        private Rectangle rect;

        public Vector2 Position
        {
            get { return Pos; }
        }

        public Player() { animationPlayer = new AnimationPlayer(); hasJumped = true; }

        public void Load(ContentManager Content)
        {

            Walk = new Animation(Content.Load<Texture2D>("mikuWalk"), 77, 75f, true);
            Idle = new Animation(Content.Load<Texture2D>("mikuIdle"), 59, 100f, true);
            Jump = new Animation(Content.Load<Texture2D>("mikuJump"), 78, 150f, true);
            Yell = new Animation(Content.Load<Texture2D>("mikuYell"), 85, 100f, true);
            Celebrate = new Animation(Content.Load<Texture2D>("mikuCelebrate"), 84, 100f, true);
        }


        public void Update(GameTime gameTime)
        {


            Pos += velocity;
            
            Input();
            if (Right)
                velocity.X = 3f;
            else if (Left)
                velocity.X = -3f;
            else velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                Pos.Y -= 10f;
                velocity.Y = -7f;
                hasJumped = true; animationPlayer.PlayAnimation(Jump);
            }
            float i = 1;
            velocity.Y += 0.15f * i;


            

            if (hasJumped)
                animationPlayer.PlayAnimation(Jump);

            if (Right == false && Left == false && hasJumped == false)
                isStanding = true;
            else isStanding = false;

            if ((Right == true || Left == true) && hasJumped == false)
                animationPlayer.PlayAnimation(Walk);
            if (isStanding)
                animationPlayer.PlayAnimation(Idle);
            if (isShoot == true && isStanding == true)
                animationPlayer.PlayAnimation(Yell);

            //if (isShoot == true && hasJumped == true)
            //animationPlayer.PlayAnimation(ShootJump);
            //if (isShoot == true && (Right == true || Left == true))
            //animationPlayer.PlayAnimation(ShootWalk);
            //rect = new Rectangle((int)Pos.X, (int)Pos.Y,59,66);
             rect = new Rectangle((int)Pos.X, (int)Pos.Y, 59, 66);

        }

        private void Input()
        {
            KeyboardState keys = Keyboard.GetState();
            GamePadState pad = GamePad.GetState(PlayerIndex.One);

            if (keys.IsKeyDown(Keys.Right) || keys.IsKeyDown(Keys.D) || pad.ThumbSticks.Left.X > 0) { Right = true; lastDirection = "Right"; }
            else { Right = false; }
            if (keys.IsKeyDown(Keys.Left) || keys.IsKeyDown(Keys.A) || pad.ThumbSticks.Left.X < 0) { Left = true; lastDirection = "Left"; }
            else { Left = false; }
            if (keys.IsKeyDown(Keys.Up) || keys.IsKeyDown(Keys.W) || pad.ThumbSticks.Left.Y > 0) { Up = true; }
            else { Up = false; }
            if (keys.IsKeyDown(Keys.Down) || keys.IsKeyDown(Keys.S) || pad.ThumbSticks.Left.Y < 0) { Down = true; }
            else { Down = false; }
            if (keys.IsKeyDown(Keys.C)) { isShoot = true; }
            else { isShoot = false; }


        }

        private void shootBullet()
        {

        }

        private void meleeAttack()
        {

        }

        public void Collision(Rectangle newRect, int xOffset, int yOffset)
        {
            if (rect.TouchTopOf(newRect))
            {
                rect.Y = newRect.Y - rect.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }

            if (rect.TouchLeftOf(newRect))
            {
                Pos.X = newRect.X - newRect.Width - 2;
            }
            if (rect.TouchRightOf(newRect))
            {
               Pos.X = newRect.X + newRect.Width + 2;
            }
           

            //collision with the map
            if (Pos.X < 0) Pos.X = 0;
            if (Pos.X > xOffset - rect.Width) Pos.X = xOffset - rect.Width;
            if (Pos.Y < 0) velocity.Y = 1f;
            if (Pos.Y > yOffset - rect.Height) Pos.Y = yOffset - rect.Height;
        }

        public void Draw(GameTime gameTime, SpriteBatch sprite)
        {
            SpriteEffects flip = SpriteEffects.None;

            if (lastDirection == "Right")
                flip = SpriteEffects.None;
            else if (lastDirection == "Left")
                flip = SpriteEffects.FlipHorizontally;

            animationPlayer.Draw(gameTime, sprite, Pos, flip);
            
        }
    }
}
