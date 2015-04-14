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
        protected float speed = 100;
        private int frames;
        private int currentIndex;
        private float timeElapsed;
        private float fps = 10;
        private Dictionary<string, Animation> animations = new Dictionary<string,Animation>();

        public SpriteObject(Vector2 position)
        {
            this.position = position;
        }
        public virtual void LoadContent(ContentManager content)
        {
            int width = texture.Width / frames;

            rectangles = new Rectangle[frames];

            for (int i = 0; i < frames; i++)
            {
                rectangles[i] = new Rectangle(i * width, 0, width, texture.Height);
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, rectangles[currentIndex], color, 0, origin, scale, effect, layer);
        }
        public virtual void Update(GameTime gametime)
        {
            timeElapsed += (float)gametime.ElapsedGameTime.TotalSeconds;

            currentIndex = (int)(timeElapsed * fps);

            if (currentIndex > rectangles.Length - 1)
            {
                timeElapsed = 0;
                currentIndex = 0;
            }
        }
        protected void CreateAnimation(string name, int frames, int yPos, int xStartFrame, int width, int height, Vector2 offset, float fps)
        {
            animations.Add(name, new Animation(frames, yPos, xStartFrame, width, height, offset, fps));
        }
    }
}
