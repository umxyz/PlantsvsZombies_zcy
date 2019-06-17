using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace ZombiesVsPlants
{
    class EnemyZombie : IEnemy
    {
        
        public EnemyZombie()
        {
            AtkRange = 10;
            attackimg = ZombiesVsPlants.FilesPath.FlagZombieAttack;
            chaseimg = ZombiesVsPlants.FilesPath.FlagZombie;
            Image bm = Image.FromFile(chaseimg);
            base.imgheight = bm.Height;
            base.imgwidth = bm.Width;
            bm.Dispose();
        }
        public override void PlayEffect()
        {
            throw new NotImplementedException();
        }
    }
}
