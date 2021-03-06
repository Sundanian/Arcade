﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroidsArcadeClone
{
    class UFOSmall : IEnemyBuilder
    {
        private Enemy enemy;
        public Enemy GetEnemy
        {
            get { return enemy; }
        }

        public UFOSmall()
        {
            enemy = new Enemy(Vector2.Zero);
        }

        public void BuildTexture(ContentManager content)
        {
            this.enemy.Texture = content.Load<Texture2D>(@"Enemy");
        }
        public void BuildScale()
        {
            this.enemy.Scale = 0.5f;
        }
        public void BuildWeapon()
        {
            this.enemy.Weapon = true;
        }
        public void BuildPosition(Vector2 position)
        {
            this.enemy.Position = position;
        }
        public void BuildType()
        {
            this.enemy.Type = EnemyType.UFOSmall;
        }
    }
}
