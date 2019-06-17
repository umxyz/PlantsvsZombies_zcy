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
    class SplitPea : Plant
    {
        public SplitPea(Street s, Floor f)
            : base(s, f)
        {
            Hp = 2147483647;
            Dir = Direction.RIGHT;
            Type = "SplitPea";
            RolesStatus = RoleStatus.NORMAL;

            //加载图片数组
            loadImage();
        }

        public SplitPea()
        {
        }

        public override void Instance(Street street, Floor floor)
        {
            base.Instance(street, floor);
            Hp = 2147483647;
            Dir = Direction.RIGHT;
            Type = "SplitPea";
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
                    switch (RolesStatus)
                    {
                        case RoleStatus.NOTHING:
                            break;
                        case RoleStatus.ATTACK:
                            if (time % 30 == 0)
                            {
                                Attack1();
                                Attack2();
                            }
                            break;
                        case RoleStatus.DEAD:
                            Dead();
                            Land.IsEmpty = true;
                            return;
                    }
                    if (hasEnemy())
                    {
                        RolesStatus = RoleStatus.ATTACK;
                    }
                    else
                    {
                        RolesStatus = RoleStatus.NOTHING;
                    }
                    time++;
                    //更新图片
                    Images_num = (Images_num + 1) % Images.Count;
                    Map.Update();
                }
                Thread.Sleep(MyAPI.PlantDanceSpeed);
            }
        }

        private bool hasEnemy()
        {
            for (int j = 0; j < Map.Zombies.Count; j++)
            {

                Zombie z = (Zombie)Map.Zombies[j];
                //判断植物是否攻击
                if (z.Floor == this.Floor)
                {
                    return true;
                }
            }
            return false;
        }

        public void Attack1()
        {
            //更新图片
            Bullet bullet = new PeaBullet(this.Street, this.Floor, Direction.RIGHT);
            Map.addBullet(bullet);
        }
        public void Attack2()
        {
            //更新图片
            Bullet bullet = new PeaBullet(this.Street, this.Floor, Direction.LEFT);
            Map.addBullet(bullet);
        }
    }
}
