using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroidsArcadeClone
{
    class AstroidSmall : IEnemyBuilder
    {
        private Enemy enemy;
        public Enemy GetEnemy
        {
            get { return enemy; }
        }

        public AstroidSmall()
        {
            enemy = new Enemy(Vector2.Zero);
        }

        public void BuildTexture(ContentManager content)
        {
            this.enemy.Texture = content.Load<Texture2D>(@"");
        }
        public void BuildScale()
        {
            this.enemy.Scale = 1;
        }
        public void BuildWeapon()
        {
            this.enemy.Weapon = false;
        }
        public void BuildPosition(Vector2 position)
        {
            this.enemy.Position = position;
        }
    }
}
