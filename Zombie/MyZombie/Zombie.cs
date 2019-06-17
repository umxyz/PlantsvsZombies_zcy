using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication3;
using ZombiesVsPlants.API;
using ZombiesVsPlants.MyEnum;
using System.Drawing;
using System.Threading;
using ZombiesVsPlants.MyPlant;
using ZombiesVsPlants.MyLand;

namespace ZombiesVsPlants.MyZombie
{
    class Zombie : Role
    {
        public int AttackTime;
        private int power;
        private string type;
        private int threadTime;

        public Zombie(Street street, Floor floor) : base(street, floor)
        {
            Y = Y - MyAPI.ZombieHeight + MyAPI.GlassHeight;
            RolesStatus = RoleStatus.MOVE;
        }

        public Zombie()
        {

        }

        public override void loadImage()
        {
            Images = new Resources().ZombieType(Type);
            Width = ((Image)Images[0]).Width;
            Height = ((Image)Images[0]).Height;
        }

        public void loadAttackImage()
        {
            Images = new Resources().ZombieBoom(type);
            Width = ((Image)Images[0]).Width;
            Height = ((Image)Images[0]).Height;
        }

        public void loaddeadImage()
        {
            Images = new Resources().ZombieBoom1();
            Width = ((Image)Images[0]).Width;
            Height = ((Image)Images[0]).Height;
        }

        public void ZombieBoomImage()
        {
            Images = new Resources().ZombieBoom1();
            Width = ((Image)Images[0]).Width;
            Height = ((Image)Images[0]).Height;
        }

        public void PlantIsDead()
        {
            RolesStatus = RoleStatus.MOVE;
            Enemy.RolesStatus = RoleStatus.DEAD;
        }

        public override void Run()
        {
            Thread t = new Thread(new ThreadStart(RunThread));
            t.Start();
        }

        public override void Attack()
        {
            if (Enemy == null || Enemy.Hp <= 0)
            {
                //System.Windows.Forms.MessageBox.Show("僵尸找不到攻击对象或植物已死亡");
                loadImage();
                RolesStatus = RoleStatus.MOVE;
                //Enemy.RolesStatus = RoleStatus.DEAD;
                return;
            }
            Enemy.Hp -= power;
            if (AttackTime > 2 || Enemy.Hp <= 0)
            {
                Enemy.Hp = 0;
                //PlantIsDead();
                RolesStatus = RoleStatus.MOVE;
                Enemy.RolesStatus = RoleStatus.DEAD;
                AttackTime = 0;
                //switch (AttackTime)
                //{
                //    case ZombiesVsPlants.PlantAttackedTime.Cactus :
                //        break;

                //}
            }
        }

        public virtual void Move()
        {
            switch (Dir)
            {
                case Direction.UP:
                    Y += Speed;
                    break;
                case Direction.DOWN:
                    Y -= Speed;
                    break;
                case Direction.LEFT:
                    X -= Speed;
                    break;
                case Direction.RIGHT:
                    X += Speed;
                    break;
            }
        }

        public virtual void RunThread()
        {
            //线程初始化
            Images_num = 0;
            threadTime = MyAPI.ZombieRunSpeed;
            int time = 0;
            int gameTime = Controller.GameTime;
            while (Controller.gameStatus != GameStatus.OVER && gameTime == Controller.GameTime)
            {
                //判断是否游戏暂停
                if (Controller.gameStatus != GameStatus.STOP)
                {
                    switch (RolesStatus)
                    {
                        case RoleStatus.NORMAL:
                            break;
                        case RoleStatus.MOVE:
                            if (time % 4 == 0)
                                Move();
                            break;
                        case RoleStatus.ATTACK:
                            if (time % 30 == 0)
                            {
                                Attack();
                                AttackTime++;
                            }
                            break;
                        case RoleStatus.DISPEAR:
                            //loaddeadImage();
                            Dispear();
                            return;
                        //case RoleStatus.IsBoom:
                        //    ZombieBoomImage();
                        //    RolesStatus = RoleStatus.DEAD;
                        //    break;
                        case RoleStatus.DEAD:
                            if (time % 4 == 0)
                                Move();
                            if (Images_num == Images.Count - 1)
                            {
                                //loaddeadImage();
                                Map.delete(Map.Zombies, this);
                                return;
                            }
                            break;
                    }
                    if (contactEnemy())
                    {
                        RolesStatus = RoleStatus.ATTACK;
                        loadAttackImage();
                    }
                    if (Enemy != null && Enemy.Hp <= 0 && Enemy.RolesStatus != RoleStatus.DEAD)
                    {
                        loadImage();
                        Enemy.Hp = 0;
                        RolesStatus = RoleStatus.MOVE;
                        Enemy.RolesStatus = RoleStatus.DEAD;
                    }
                    time++;
                    //更新图片 
                    Images_num = (Images_num + 1) % Images.Count;
                    // Form update
                    Map.Update();
                }
                Thread.Sleep(threadTime);
            }
        }

        private bool contactEnemy()
        {
            for (int i = 0; i < Map.Plants.Count; i++)
            {
                Plant p = (Plant)Map.Plants[i];
                if (new MyAPI().isHit(p, this) && RolesStatus != RoleStatus.DEAD)
                {
                    Enemy = p;
                    return true;
                }
            }
            return false;
        }

        public override void Dispear()
        {
            Map.delete(Map.Zombies, this);
        }

        public override void Dead()
        {
            Images_num = 0;
            Images = new Resources().ZombieDead(type);
            RolesStatus = RoleStatus.DEAD;
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            if (Images != null)
                g.DrawImage((Image)Images[Images_num], X, Y);
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }
    }
}
