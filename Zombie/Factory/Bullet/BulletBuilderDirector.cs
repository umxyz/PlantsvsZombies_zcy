using System;
using System.Collections.Generic;
using System.Text;

namespace ZombiesVsPlants
{
    class BulletBuilderDirector
    {
        public static IBullet Construct(BulletBuilder builder)
        {
            builder.AddBulletAtrr();
            builder.AddBulletAnimate();
            builder.AddInCharacterSystem();
            return builder.GetResult();
        }
    }
}
