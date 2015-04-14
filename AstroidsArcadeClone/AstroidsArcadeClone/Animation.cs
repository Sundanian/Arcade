using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroidsArcadeClone
{
    class Animation
    {
        private Vector2 offset;
        private float fps;
        private Rectangle[] rectangles;

        public Vector2 Offset
        {
            get { return offset; }
        }
        public Rectangle[] Rectangles
        {
            get { return rectangles; }
        }
        public float Fps
        {
            get { return fps; }
        }

        public Animation(int frames, int yPos, int xStartFrame, int width, Vector2 offset, float fps)
        {

        }
    }
}
