using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ZombiesVsPlants.API;

namespace ZombiesVsPlants
{
    class Shovel : Element
    {
        private bool isActivate;
        private Image image;
        private Image BackgroundImage;

        public Shovel()
        {
            X = MyAPI.ShovelX;
            Y = MyAPI.ShovelY;
            isActivate = false;

            loadImage();
        }

        public override void loadImage()
        {
            image = Image.FromFile(@"..\..\images\interface\Shovel.png");
            BackgroundImage = Image.FromFile(@"..\..\images\interface\ShovelBack.png");
            Width = image.Width;
            Height = image.Height;
        }

        public bool isClick(int x, int y)
        {
            //当点击铲子时
            if (x >= X && x < (X + image.Width) && y >= Y && y < Y
                + image.Height)
            {
                //如果处于未激活状态
                if (!isActivate)
                {
                    //修改为激活状态
                    isActivate = true;
                }
                else
                {
                    //否则
                    Resume();
                    return true;
                }
            }
            return false;
        }

        public void Move(int x,int y)
        {
            //激活状态允许移动
            if (isActivate)
            {
                X = x;
                Y = y;
            }
        }

        public void Resume()
        {
            isActivate = false;
            X = MyAPI.ShovelX;
            Y = MyAPI.ShovelY;
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            //绘制背景
            g.DrawImage(BackgroundImage, MyAPI.ShovelX, MyAPI.ShovelY,
                BackgroundImage.Width, BackgroundImage.Height);
            //绘制铲子
            g.DrawImage(image, X, Y, image.Width, image.Height);
        }
    }
}
