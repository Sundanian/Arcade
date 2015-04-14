using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroidsArcadeClone
{
    class EnemyDirector
    {
        private readonly IEnemyBuilder enemyBuilder;

        public Enemy GetEnemy
        {
            get { return enemyBuilder.GetEnemy; }
        }

        public EnemyDirector(IEnemyBuilder enemyBuilder)
        {
            this.enemyBuilder = enemyBuilder;
        }

        public void BuildEnemy()
        {
            //enemyBuilder.BuildPart();
            //osv......
        }
    }
}
