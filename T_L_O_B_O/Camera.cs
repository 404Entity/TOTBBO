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
        private Matrix transform;
        public Matrix Transform { get { return transform; } private set { transform = value;} }

        public void Follow(GameObject target, Collider targetColisionbox)
        {
            var offset = Matrix.CreateTranslation(GameWorld.ScreenWidth / 2, GameWorld.ScreenHeight / 2, 0);
            var position = Matrix.CreateTranslation(
                -target.Transform.Position.X - (targetColisionbox.CollisionBox.Width / 2),
                -target.Transform.Position.Y - (targetColisionbox.CollisionBox.Height / 2),
                0);

            Transform = position * offset;

        }
    }
}
