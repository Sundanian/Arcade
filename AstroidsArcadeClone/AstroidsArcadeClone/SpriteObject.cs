using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroidsArcadeClone
{
    abstract class SpriteObject
    {
        protected Texture2D texture;
        private Rectangle[] rectangles;
        protected Vector2 position;
        private Vector2 origin;
        private float layer;
        private float scale;
        private Color color;
        private SpriteEffects effect;
        protected Vector2 velocity;
        protected float speed;
        private int frames;
        private int currentIndex;
        private float timeElapsed;
        private float fps;
        private Dictionary<string, Animation> animations;

        public SpriteObject(Vector2 position, int frames)
        {

        }
        public void LoadContent(ContentManager content)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
        public virtual void Update(GameTime gametime)
        {

        }
        private void CreateAnimation(string name, int frames, int yPos, int xStartFrame, int width, int height, Vector2 offset, float fps)
        {

        }
    }
}
