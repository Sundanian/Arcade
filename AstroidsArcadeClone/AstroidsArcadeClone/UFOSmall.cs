using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroidsArcadeClone
{
    class UFOSmall
    {
        private Enemy enemy;
        public Enemy GetEnemy
        {
            get { return enemy; }
        }

        public UFOSmall()
        {
            enemy = new Enemy();
        }

        //Build Parts
    }
}
