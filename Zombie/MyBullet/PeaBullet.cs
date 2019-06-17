using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication3;
using ZombiesVsPlants.MyEnum;

namespace ZombiesVsPlants.MyBullet
{
    class PeaBullet : Bullet
    {
        public PeaBullet(Street s, Floor f, Direction dir):base(s,f,dir)
        {
            Speed = 10;
            Type = "PeaBullet";
            RolesStatus = RoleStatus.MOVE;

            loadImage();
        }

        public override void Dead()
        {
            Images = new Resources().PeaBulletHit();
            base.Dead();
        }
    }
}
