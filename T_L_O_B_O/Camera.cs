using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace T_L_O_B_O
{
    class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(GameObject target, SpriteRenderer targetrender)
        {
             var offset = Matrix.CreateTranslation(GameWorld.ScreenWidth / 2, GameWorld.ScreenHeight / 2, 0);
            var position = Matrix.CreateTranslation(
                -target.Transform.Position.X - (targetrender.Rectangle.Width / 2),
                -target.Transform.Position.Y - (targetrender.Rectangle.Height / 2),
                0);

            Transform = position * offset;

        }
    }
}
