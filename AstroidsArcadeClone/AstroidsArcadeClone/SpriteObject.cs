using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroidsArcadeClone
{
    public abstract class SpriteObject
    {
        protected Texture2D texture;
        private Rectangle[] rectangles;
        protected Vector2 position;
        private Vector2 origin = Vector2.Zero;
        private float layer = 0;
        protected float scale;
        private Color color = Color.White;
        private SpriteEffects effect = SpriteEffects.None;
        private float rotation = 0;
        protected Vector2 velocity;
        protected float speed = 100;
        private int currentIndex;
        private float timeElapsed;
        private float fps = 10;
        private Dictionary<string, Animation> animations = new Dictionary<string,Animation>();
        private Vector2 offset;


        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public SpriteObject(Vector2 position)
        {
            this.position = position;
        }
        public virtual void LoadContent(ContentManager content)
        {
            
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position + offset, rectangles[currentIndex], color, rotation, origin, scale, effect, layer);
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
        protected void PlayAnimation(string name)
        {
            rectangles = animations[name].Rectangles;
            offset = animations[name].Offset;
            fps = animations[name].Fps;
        }
    }
}
