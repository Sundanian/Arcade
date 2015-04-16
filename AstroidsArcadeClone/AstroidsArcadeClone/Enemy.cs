using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroidsArcadeClone
{
    class Enemy : SpriteObject
    {
        private bool weapon;
        private int velocityX;
        private int velocityY;
        private Random r = new Random();

        public bool Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public Enemy(Vector2 position) : base(position)
        {

        }
        public override void Update(GameTime gametime)
        {
            velocity = Vector2.Zero;
            velocity += new Vector2(velocityX,velocityY);
            velocity *= speed;
            float deltatime = (float)gametime.ElapsedGameTime.TotalSeconds;
            position += (velocity * deltatime);

            base.Update(gametime);
        }
        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            velocityX = r.Next(-1, 2);
            velocityY = r.Next(-1, 2);
            CreateAnimation("Idle", 1, 0, 0, Texture.Width, Texture.Height, Vector2.Zero, 1, texture);
            PlayAnimation("Idle");

            base.LoadContent(content);
        }
    }
}
