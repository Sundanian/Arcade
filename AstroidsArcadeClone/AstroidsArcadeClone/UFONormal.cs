using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroidsArcadeClone
{
    class UFONormal
    {
        private Enemy enemy;
        public Enemy GetEnemy
        {
            get { return enemy; }
        }

        public UFONormal()
        {
            enemy = new Enemy();
        }

        //Build Parts
    }
}
