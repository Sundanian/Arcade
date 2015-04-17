using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroidsArcadeClone
{
    class Missile : SpriteObject
    {
        public Missile(Vector2 position) : base(position)
        {

        }
        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            speed = 110;
            Texture = content.Load<Texture2D>(@"Ship");
            CreateAnimation("Idle", 1, 0, 2, 128, 128, Vector2.Zero, 1, texture);
            PlayAnimation("Idle");
            
            base.LoadContent(content);
        }

    }
}
