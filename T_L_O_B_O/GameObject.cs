using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace T_L_O_B_O
{
    enum DIRECTION
    {
        Left, Right, Jump, Climb,
    }

    class GameObject : Component
    {
        List<Component> components = new List<Component>();
        Transform transform;

        public GameObject(GameObject gameObject)
        {

        }

        public GameObject()
        {
            transform = new Transform(Vector2.One, this);

            components.Add(transform);
        }

        public Transform Transform { get => transform; set => transform = value; }

        public void AddComponent(Component component)
        {
            components.Add(component);
        }

        public Component GetComponent(string component)
        {
            Component _return = null;
            foreach (Component com in components)
            {
                if (com.GetType().Name == component)
                {
                    _return = com;
                    break;
                }
            }
            return _return;
        }

        public void LoadContent(ContentManager content)
        {
            foreach (Component com in components)
            {
                if (com is ILoadable)
                {
                    (com as ILoadable).LoadContent(content);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Component com in components)
            {
                if (com is IUpdateable)
                {
                    (com as IUpdateable).Update();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component com in components)
            {
                if (com is IDrawable)
                {
                    (com as IDrawable).Draw(spriteBatch);
                }
            }
        }

        public void OnAnimationDone(string animationName)
        {
            foreach (Component com in components)
            {
                if (com is IAnimateable)
                {
                    (com as IAnimateable).OnAnimationDone(animationName);
                }
            }
        }
    }
}
