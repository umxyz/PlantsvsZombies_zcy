using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication3;
using ZombiesVsPlants.API;
using ZombiesVsPlants.MyLand;
using ZombiesVsPlants.MyEnum;
using System.Threading;
using System.Drawing;

namespace ZombiesVsPlants.MyPlant
{
    class Plant : Role
    {
        //临时种植该植物的草地
        private Land land;
        private string type;
        private bool GrowSoil;
        private string plantName;

        public Plant(Street s, Floor f) : base(s, f)
        {

        }

        public Plant()
        {

        }

        //public void PlantDoomShroomBoom()
        //{
        //    Images = new Resources().PlantDoomShroom();
        //    Width = ((Image)Images[0]).Width;
        //    Height = ((Image)Images[0]).Height;
        //}

        //public void PlantPotatoMineBoom()
        //{
        //    Images = new Resources().PlantPotatoMine();
        //    Width = ((Image)Images[0]).Width;
        //    Height = ((Image)Images[0]).Height;
        //}
        //public void PlantCherryBombBoom()
        //{
        //    Images = new Resources().PlantCherryBomb();
        //    Width = ((Image)Images[0]).Width;
        //    Height = ((Image)Images[0]).Height;
        //}

        public virtual void Instance(Street street, Floor floor)
        {
            this.X = (int)street;
            this.Y = (int)floor;
            this.Street = street;
            this.Floor = floor;

            //默认所有植物方向向右，不同的在自己的构造函数重定义
            Dir = Direction.RIGHT;
        }

        public virtual void Dead()
        {
            Map.delete(Map.Plants, this);
        }

        public override void Run()
        {
            Thread t = new Thread(new ThreadStart(RunThread));
            t.Start();
        }

        public virtual void RunThread()
        {
            //线程初始化
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
                        case RoleStatus.NORMAL:
                            PlantAction(time);
                            break;
                        case RoleStatus.DEAD:
                            Dead();
                            Land.IsEmpty = true;
                            return;
                    }
                    time++;
                    //更新图片
                    Images_num = (Images_num + 1) % Images.Count;
                    Map.Update();
                }
                Thread.Sleep(MyAPI.PlantDanceSpeed);
            }
        }

        public virtual void PlantAction(int time)
        {

        }

        public override void loadImage()
        {
            Images = new Resources().PlantType(type);
            Width = ((Image)Images[0]).Width;
            Height = ((Image)Images[0]).Height;
            X = X - Width / 2 + MyAPI.PlantWidth / 2 - 5;
        }

        public void loadNewImage()
        {
            Images = new Resources().PlantType(type);
            Width = ((Image)Images[0]).Width;
            Height = ((Image)Images[0]).Height;
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            if (Images != null)
                g.DrawImage((Image)Images[Images_num], (int)X, (int)Y);
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public Land Land
        {
            get { return land; }
            set { land = value; }
        }
        public string PlantName
        {
            get { return plantName; }
            set { plantName = value; }
        }
    }
}
