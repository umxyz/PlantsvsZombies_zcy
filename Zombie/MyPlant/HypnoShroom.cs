using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication3;
using ZombiesVsPlants.MyEnum;
using ZombiesVsPlants.MyBullet;
using ZombiesVsPlants.API;
using System.Threading;
using ZombiesVsPlants.MyZombie;

namespace ZombiesVsPlants.MyPlant
{
    class HypnoShroom : Plant
    {
        public HypnoShroom(Street s, Floor f)
            : base(s, f)
        {
            Hp = 2147483647;
            Dir = Direction.RIGHT;
            Type = "HypnoShroom";
            RolesStatus = RoleStatus.NORMAL;

            //加载图片数组
            loadImage();
        }

        public HypnoShroom()
        {
        }

        public override void Instance(Street street, Floor floor)
        {
            base.Instance(street, floor);
            Hp = 2147483647;
            Dir = Direction.RIGHT;
            Type = "HypnoShroom";
            RolesStatus = RoleStatus.NORMAL;

            //加载图片数组
            loadImage();
        }

        public override void Run()
        {
            Thread t = new Thread(new ThreadStart(RunThread));
            t.Start();
        }

        public override void Attack()
        {

        }
    }
}
