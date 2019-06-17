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
    class TallNut : Plant
    {
        public TallNut(Street s, Floor f)
            : base(s, f)
        {
            Hp = 18;
            Dir = Direction.RIGHT;
            Type = "TallNut";
            RolesStatus = RoleStatus.NORMAL;

            //加载图片数组
            loadImage();
        }

        public TallNut()
        {
        }

        public override void Instance(Street street, Floor floor)
        {
            base.Instance(street, floor);
            Hp = 18;
            Dir = Direction.RIGHT;
            Type = "TallNut";
            RolesStatus = RoleStatus.NORMAL;

            //加载图片数组
            loadImage();
        }

        public override void RunThread()
        {
            int time = 0;
            int gameTime = Controller.GameTime;
            while (Controller.gameStatus != GameStatus.OVER && gameTime == Controller.GameTime)
            {
                if (Controller.gameStatus != GameStatus.STOP)
                {
                    if (Hp > 12)
                    {
                        Type = "WallNut";
                        loadNewImage();
                    }
                    else if (Hp > 6)
                    {
                        Type = "Wallnut_cracked1";
                        loadNewImage();
                    }
                    else if (Hp > 0)
                    {
                        Type = "Wallnut_cracked2";
                        loadNewImage();
                    }
                    else
                    {
                        Dead();
                        Land.IsEmpty = true;
                    }

                    time++;
                    //更新图片
                    Images_num = (Images_num + 1) % Images.Count;
                    Map.Update();
                }
                Thread.Sleep(MyAPI.PlantDanceSpeed);
            }
        }

        public override void Attack()
        {

        }
    }
}
