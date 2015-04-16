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

        public bool Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }
        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
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
            float deltatime = (float)gametime.ElapsedGameTime.TotalSeconds;
            position += (velocity * deltatime);
            velocity *= speed;

            base.Update(gametime);
        }
        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            CreateAnimation("Idle", 1, 1, 1, texture.Width, texture.Height, Vector2.Zero, 1);
            PlayAnimation("Idle");
            base.LoadContent(content);
        }
    }
}
