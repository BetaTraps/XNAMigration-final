using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAMigration
{
    class Camera
    {
        public Matrix transform;
        Viewport view;
        Vector2 center;

        public Camera(Viewport newView)
        {
            view = newView;
        }

        public void Update(Vector2 position, int xOffset,int yOffset)
        {
            if (position.X < view.Width / 2)
                center.X = view.Width / 2;
            else if (position.X > xOffset - (view.Width / 2))
                center.X = xOffset - (view.Width / 2);
            else center.X = position.X;

            if (position.Y < view.Height / 2)
                center.Y = view.Height / 2;
            else if (position.Y > yOffset - (view.Height / 2))
                center.Y = yOffset - (view.Height / 2);
            else center.Y = position.Y;

            transform = Matrix.CreateTranslation(new Vector3(-center.X + (view.Width / 2),
                                                             -center.Y + (view.Height / 2), 0));
        }
    }
}
