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
    class Animation
    {
        float fps;
        Vector2 offset;
        Rectangle[] rectangles;

        public Animation(float fps, Vector2 offset, int frames, int yPos, int xStratFrame,int width, int height)
        {
            this.fps = fps;
            Offset = offset;
            Frames = frames;
            YPos = yPos;
            XStratFrame = xStratFrame;
            Width = width;
            Height = height;
        }

        
        public Vector2 Offset { get => offset; set => offset = value; }
        public int Frames { get; }
        public int YPos { get; }
        public int XStratFrame { get; }
        public int Width { get; }
        public int Height { get; }
        public float Fps { get => fps; }
        public Rectangle[] Rectangles { get => rectangles; }
    }
}
