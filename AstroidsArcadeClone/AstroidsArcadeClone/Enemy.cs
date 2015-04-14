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
        private string textureString;
        public Enemy(Vector2 position, Texture2D texture, Vector2 velocity, Rectangle[] rectangles) : base(position)
        {
            this.texture = texture;
            this.velocity = velocity;
            this.velocity *= speed;
        }
        public override void Update(GameTime gametime)
        {
            float deltatime = (float)gametime.ElapsedGameTime.TotalSeconds;
            position += (velocity * deltatime);

            base.Update(gametime);
        }
    }
}
