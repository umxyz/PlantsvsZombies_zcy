﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using WindowsFormsApplication3;
using ZombiesVsPlants.MyEnum;
using System.Threading;
using ZombiesVsPlants.MyZombie;
using ZombiesVsPlants.API;
using System.Windows.Forms;

namespace ZombiesVsPlants.MyCleaner
{
    class Cleaner : Role
    {
        private Image image;
        private string type;

        public Cleaner(Street s, Floor f)
            : base(s, f)
        {
            X = (int)s - 80;
            Y = (int)f + 20;
            Speed = 16;
            Dir = Direction.RIGHT;
            RolesStatus = RoleStatus.NORMAL;
        }

        public void Move()
        {
            //MessageBox.Show("清洁机移动");
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
            if (contactEnemy())
                Attack();
        }

        public bool contactEnemy()
        {
            for (int j = 0; j < Map.Zombies.Count; j++)
            {
                Zombie z = (Zombie)Map.Zombies[j];
                if (new MyAPI().isHit(this, z) && RolesStatus != RoleStatus.DEAD)
                {
                    Enemy = z;
                    return true;
                }
            }
            return false;
        }

        public void Attack()
        {
            if (Enemy == null)
            {
                System.Windows.Forms.MessageBox.Show("清洁机找不到攻击对象");
                return;
            }
            Enemy.RolesStatus = RoleStatus.DISPEAR;
        }

        public override void Run()
        {
            Thread t = new Thread(new ThreadStart(RunThread));
            t.Start();
        }

        public void RunThread()
        {
            int time = 60;
            int Speed = 20;
            int gameTime = Controller.GameTime;
            while (Controller.gameStatus != GameStatus.OVER
               && gameTime == Controller.GameTime)
            {
                if (Controller.gameStatus == GameStatus.START)
                {
                    switch (RolesStatus)
                    {
                        case RoleStatus.NORMAL:
                            break;
                        case RoleStatus.MOVE:
                            Move();
                            break;
                        case RoleStatus.DISPEAR:
                            Dispear();
                            return;
                    }
                    if (X > 1200)
                    {
                        RolesStatus = RoleStatus.DISPEAR;
                    }
                    if (contactEnemy())
                    {
                        RolesStatus = RoleStatus.MOVE;
                    }
                    Map.Update();
                }
                Thread.Sleep(time);
            }
        }

        public void Dispear()
        {
            Map.delete(Map.Cleaners,this);
        }

        public virtual void loadImage()
        {
            image = Image.FromFile("../../images/" + type + ".png");
            Width = image.Width;
            Height = image.Height;
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            if (image != null)
            {               
                g.DrawImage(image, X, Y, Width, Height);
            }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
