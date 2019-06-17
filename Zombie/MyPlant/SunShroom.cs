using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication3;
using System.Threading;
using ZombiesVsPlants.MyEnum;
using ZombiesVsPlants.API;
using ZombiesVsPlants.ExtendRole;

namespace ZombiesVsPlants.MyPlant
{
    class SunShroom : Plant
    {
        public SunShroom(Street s, Floor f)
            : base(s, f)
        {
            Hp = 2147483647;
            Dir = Direction.RIGHT;
            Type = "SunFlower";
            RolesStatus = RoleStatus.NORMAL;

            //加载图片数组
            loadImage();
        }

        public SunShroom()
        {
        }

        public override void Instance(Street street, Floor floor)
        {
            base.Instance(street, floor);
            Hp = 2147483647;
            Dir = Direction.RIGHT;
            Type = "SunShroom";
            RolesStatus = RoleStatus.NORMAL;

            //加载图片数组
            loadImage();
        }

        public override void Run()
        {
            Thread t = new Thread(new ThreadStart(RunThread));
            t.Start();
        }

        public override void PlantAction(int time)
        {
            if ((time + 1) % ZombiesVsPlants.PlansTime.SunShroom == 0)
                collectSun();
            if (ZombiesVsPlants.PlansTime.SunShroom > 120)
                ZombiesVsPlants.PlansTime.SunShroom -= 10;
        }

        private void collectSun()
        {
            Sun sun = new Sun(this.X + 30, this.Y + 30, this.X + 30, this.Y + 30);
            Map.addSun(sun);
        }

        public override void Attack()
        {

        }
    }
}
