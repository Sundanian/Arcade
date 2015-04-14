using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroidsArcadeClone
{
    class AstroidNormal
    {
        private Enemy enemy;
        public Enemy GetEnemy
        {
            get { return enemy; }
        }

        public AstroidNormal()
        {
            enemy = new Enemy();
        }

        //Build Parts
    }
}
