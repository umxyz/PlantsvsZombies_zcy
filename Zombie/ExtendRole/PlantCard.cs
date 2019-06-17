using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZombiesVsPlants.API;
using System.Drawing;
using System.Threading;
using System.IO;

namespace ZombiesVsPlants.ExtendRole
{
    class PlantCard : Element
    {
        private int needSun;
        private string type;

        public int NeedSun
        {
            get { return needSun; }
            set { needSun = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private Image image;

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }
        private double waitTime, loadTime;

        public double LoadTime
        {
            get { return loadTime; }
            set { loadTime = value; }
        }

        public double WaitTime
        {
            get { return waitTime; }
            set { waitTime = value; }
        }
        private bool isChoose;

        public PlantCard(string type)
        {
            this.waitTime = 0;
            this.loadTime = new MyAPI().CoolDown(type);
            this.isChoose = false;
            this.type = type;
            this.needSun = new MyAPI().NeedSun(type);

            loadImage(@"..\..\images\Card\Plants\");
        }

        public void loadImage(string file)
        {
            string path = (file);
            this.image = Image.FromFile(Path.Combine(path, type + ".png"));
            Width = image.Width;
            Height = image.Height;
        }

        public void loading()
        {
            loadImage(@"..\..\images\Card\Plants\");
            // time
            waitTime = loadTime;
            //装载线程
            Thread t = new Thread(new ThreadStart(loadingThread));
            t.Start();
        }

        public void loadingThread()
        {
            int gameTime = Controller.GameTime;
            while (Controller.gameStatus != GameStatus.OVER
               && gameTime == Controller.GameTime && waitTime != 0)
            {
                //判断是否游戏暂停
                if (Controller.gameStatus == GameStatus.START)
                {
                    waitTime = waitTime - 0.5;                 

                    Map.Update();
                }
                Thread.Sleep(500);
            }

            //初始化
            isChoose = false;
        }

        public void Draw(Graphics g)
        {
            if (needSun > Map.SunShine || waitTime != 0)
                new MyAPI().TransparentImage(X, Y, image, g);
            else
                g.DrawImage(image, X, Y, 
                    MyAPI.CardWidth, MyAPI.CardHeight);
            if (waitTime != 0)
            {
                //画刷，字体
                Brush brush = new SolidBrush(Color.Black);
                Font font = new Font("Arial", 15);
                //取字体尺寸
                SizeF sizeF = g.MeasureString(waitTime.ToString("F1"), new Font("宋体", 9));
                //绘制字体
                g.DrawString(waitTime.ToString("F1"), font, brush,
                    new Rectangle(X + MyAPI.CardWidth / 2 - (int)sizeF.Width, Y + 
                        MyAPI.CardHeight / 2 - (int)sizeF.Height , MyAPI.CardWidth,
                        MyAPI.CardHeight));

            }
            //
            //  绘制所需阳光数据
            //
            //画刷，字体
            Brush brush1 = new SolidBrush(Color.Black);
            Font font1 = new Font("Arial", 10);
            //取字体尺寸
            SizeF sizeF1 = g.MeasureString(waitTime.ToString("F1"), new Font("宋体", 9));
            g.DrawString(needSun.ToString(), font1, brush1,
                    new Rectangle(X + MyAPI.CardWidth/2+10,Y+
                        MyAPI.CardHeight/4*3 , MyAPI.CardWidth,
                        MyAPI.CardHeight/2));
        }

        //是否被点击（如果被点击进行判断并执行）
        public bool isClick(int x,int y)
        {
            if (isContact(x,y) && needSun <= Map.SunShine)
            {
                //界面变化
                //loading();//绘制装填时间
                //p.waitToPlant(type);
                if (Map.Pb.IsAcitive == true)
                    return false;
                else
                    Map.initPlantBox(type);
                Map.SunCost = needSun;
                Map.Pc = this;
                return true;
            }
            return false;
        }

        //计算指定坐标是否接触本对象
        public bool isContact(int x,int y)
        {
            if (x > this.X && x < (this.X + MyAPI.CardWidth) && y > this.Y && y < this.Y
                + MyAPI.CardHeight)
            {
                return true;
            }
            return false;
        }
    }
}
