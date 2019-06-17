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
    class TwinSunflower : Plant
    {
        public TwinSunflower(Street s, Floor f)
            : base(s, f)
        {
            Hp = 3;
            Dir = Direction.RIGHT;
            Type = "TwinSunflower";
            RolesStatus = RoleStatus.NORMAL;

            //加载图片数组
            loadImage();
        }

        public TwinSunflower()
        {
        }

        public override void Instance(Street street, Floor floor)
        {
            base.Instance(street, floor);
            Hp = 3;
            Dir = Direction.RIGHT;
            Type = "TwinSunflower";
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
            if ((time + 1) % ZombiesVsPlants.PlansTime.TwinSunflower == 0)
            {
                collectSun1();
                collectSun2();
            }
            if (ZombiesVsPlants.PlansTime.TwinSunflower > 120)
                ZombiesVsPlants.PlansTime.TwinSunflower -= 10;
        }

        private void collectSun1()
        {
            Sun sun = new Sun(this.X + 30, this.Y + 30, this.X + 30, this.Y + 30);
            Map.addSun(sun);
        }
        private void collectSun2()
        {
            Sun sun = new Sun(this.X + 0, this.Y + 30, this.X + 0, this.Y + 30);
            Map.addSun(sun);
        }
        public override void Attack()
        {

        }
    }
}
