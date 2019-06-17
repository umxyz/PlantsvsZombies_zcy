using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZombiesVsPlants.API;
using System.Drawing;
using System.Threading;
using ZombiesVsPlants.MyEnum;

namespace ZombiesVsPlants.ExtendRole
{
    class Sun : Role
    {
        private int finalX, finalY;
        private int sunNum;
        private int MoveY;
        private int MoveSpeed = 5;
        private int timeWait;
        private int threadTime;
        private bool isClicked;

        public int SunNum
        {
            get { return sunNum; }
            set { sunNum = value; }
        }

        public Sun(int x, int y, int finalX, int finalY)
        {
            this.X = x;
            this.Y = y;
            this.finalX = finalX;
            this.finalY = finalY;
            this.sunNum = 25;
            this.RolesStatus = RoleStatus.MOVE;

            loadImage();
        }

        public override void loadImage()
        {
            Images = new Resources().Sun();
            this.Width = ((Image)Images[0]).Width;
            this.Height = ((Image)Images[0]).Height;
        }

        public override void Run()
        {
            Thread t = new Thread(new ThreadStart(RunThread));
            t.Start();
        }

        public void RunThread()
        {
            threadTime = MyAPI.SunFlowSpeed;
            int gameTime = Controller.GameTime;
            while (Controller.gameStatus != GameStatus.OVER
               && gameTime == Controller.GameTime)
            {
                if (Controller.gameStatus == GameStatus.START)
                {
                    switch (RolesStatus)
                    {
                        case RoleStatus.MOVE:
                            //移动
                            if (Y < finalY)
                                Y += MoveSpeed;
                            break;
                        case RoleStatus.DEAD:
                            moveToDispear();
                            if (X <= MyAPI.SunBoardX + 20 && X >= MyAPI.SunBoardX - 40 &&
                                Y <= MyAPI.SunBoardY + 20 && Y >= MyAPI.SunBoardY - 40)
                            {
                                Map.SunShine += 25;
                                Map.delete(Map.Suns, this);
                                return;
                            }
                            break;
                        case RoleStatus.DISPEAR:
                            Disapear();
                            break;
                    }
                    //更新图片
                    Images_num = (Images_num + 1) % Images.Count;                 
                }
                Thread.Sleep(threadTime);

                //Mm.update();
            }
        }

        public void Disapear()
        {
            Map.delete(Map.Suns, this);
        }

        public void Dead()
        {
            MoveSpeed = 16;
            threadTime = 20;
            RolesStatus = RoleStatus.DEAD;
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            if (Images != null)
            {
                g.DrawImage((Image)Images[Images_num], X, Y, Width, Height);
            }
        }

        //是否被点击
        public bool isClick(int x, int y)
        {
            if (isContact(x, y))
            {
                isClicked = true;
                Dead();
                return isClicked;
            }
            return false;
        }

        //计算指定坐标是否接触本对象
        public bool isContact(int x, int y)
        {
            if (x > X && x < (X + Width) && y > Y && y < Y
                + Height && RolesStatus != RoleStatus.DEAD)
            {
                return true;
            }
            return false;
        }

        public void moveToDispear()
        {
            if (X < MyAPI.SunBoardX)
            {
                Y -= MoveSpeed;
                X += MoveSpeed * (MyAPI.SunBoardX - X) / (Y - MyAPI.SunBoardY);
            }
            else if (X > MyAPI.SunBoardX)
            {
                Y -= MoveSpeed;
                X -= MoveSpeed * (X - MyAPI.SunBoardX) / (Y - MyAPI.SunBoardY);
            }
            else
                Y -= MoveSpeed;
            return;
        }
    }
}
