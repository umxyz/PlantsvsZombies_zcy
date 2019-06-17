using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication3;
using ZombiesVsPlants.MyEnum;

namespace ZombiesVsPlants.MyBullet
{
    class ShroomBullet : Bullet
    {
        public ShroomBullet(Street s, Floor f, Direction dir) : base(s, f, dir)
        {
            Speed = 10;
            Type = "ShroomBullet";
            RolesStatus = RoleStatus.MOVE;

            loadImage();
        }

        public override void Dead()
        {
            Images = new Resources().ShroomBulletHit();
            base.Dead();
        }
    }
}
