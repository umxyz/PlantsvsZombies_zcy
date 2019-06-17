using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Drawing.Imaging;
using System.IO;

namespace ZombiesVsPlants
{
    class Resources
    {
        //
        //欢迎面板的图片资源
        //
        public static Image WelcomeBackImage()
        {
            //Image image = Image.FromFile("../../images/interface/menu.png");
            Image image = Image.FromFile(ZombiesVsPlants.FilesPath.Welcomebackground);
            return image;
        }
        public static Image Start_Over()
        {
            Image image = Image.FromFile("../../images/interface/start_over.png");
            return image;
        }
        public static Image Start_Leave()
        {
            Image image = Image.FromFile("../../images/interface/start_leave.png");
            return image;
        }

        //根据植物名称获取植物图片
        public ArrayList BoxImage(string name)
        {
            ArrayList images = new ArrayList();
            string file = ("../../images/Plants/" + name + "/" + name + ".gif");
            GifToJpg(file, images);
            return images;
        }
        //角色类型的图片
        public ArrayList BulletType(string type)
        {
            ArrayList images = new ArrayList();
            GifToJpg("../../images/Plants/" + type + ".gif", images);
            return images;
        }

        public Image CardType(string type)
        {
            Image image = Image.FromFile(Path.Combine(@"..\..\images\Card\Plants\",
                type + ".png"));
            return image;
        }

        public ArrayList PlantType(string type)
        {
            ArrayList images = new ArrayList();
            GifToJpg("../../images/Plants/" + type + "/" + type + ".gif", images);
            return images;
        }

        //public ArrayList PlantCherryBomb()
        //{
        //    ArrayList images = new ArrayList();
        //    GifToJpg(@"../../images/Plants/CherryBomb/" + "Boom.gif", images);
        //    return images;
        //}
        //public ArrayList PlantDoomShroom()
        //{
        //    ArrayList images = new ArrayList();
        //    GifToJpg(@"../../images/Plants/CherryBomb/" + "Boom.gif", images);
        //    return images;
        //}
        //public ArrayList PlantPotatoMine()
        //{
        //    ArrayList images = new ArrayList();
        //    GifToJpg(@"../../images/Plants/PotatoMine/" + "PotatoMine_mashed.gif", images);
        //    return images;
        //}
        public ArrayList ZombieType(string type)
        {
            ArrayList images = new ArrayList();
            GifToJpg("../../images/Zombies/" + type + "/" + type + ".gif", images);
            return images;
        }

        public ArrayList ZombieBoom(string type)
        {
            ArrayList images = new ArrayList();
            GifToJpg("../../images/Zombies/" + type + "/" + type + "Attack.gif", images);
            return images;
        }
        public ArrayList ZombieBoom1()
        {
            ArrayList images = new ArrayList();
            GifToJpg("../../images/Zombies/" + "BoomDie1.gif", images);
            return images;
        }

        public ArrayList ZombieDead(string type)
        {
            ArrayList images = new ArrayList();
            GifToJpg("../../images/Zombies/" + type + "/" + type + "LostHead.gif", images);
            GifToJpg("../../images/Zombies/" + type + "/" + type + "Die.gif", images);
            return images;
        }

        //阳光
        public ArrayList Sun()
        {
            ArrayList images = new ArrayList();
            GifToJpg(@"..\..\images\Sun.gif", images);
            return images;
        }

        public void GifToJpg(string file, ArrayList images)
        {
            //String filepath = "..\\..\\" + file;
            Image myImage = Image.FromFile(file);
            FrameDimension fd = new FrameDimension(myImage.FrameDimensionsList[0]);
            int framecount = myImage.GetFrameCount(fd);
            string path = file.Replace(Path.GetExtension(file), "");

            //资源是否已存在
            bool exists = Directory.Exists(path);
            //创建新文件夹
            if (!exists)
                Directory.CreateDirectory(path);
            //MessageBox.Show(file+": "+"framecount:" + framecount);

            //保存各帧
            for (int i = 0; i < framecount; i++)
            {
                myImage.SelectActiveFrame(fd, i);
                if (!exists)
                {
                    myImage.Save(Path.Combine(path, "frame_" + i + ".Png"), ImageFormat.Png);
                }

                Image image = Image.FromFile(Path.Combine(path, "frame_" + i + ".Png"));
                images.Add(image);
            }
        }

        internal ArrayList PeaBulletHit()
        {
            ArrayList images = new ArrayList();
            GifToJpg(@"..\..\images\Plants\PeaBulletHit.gif", images);
            return images;
        }

        internal ArrayList ShroomBulletHit()
        {
            ArrayList images = new ArrayList();
            GifToJpg(@"..\..\images\Plants\ShroomBulletHit.gif", images);
            return images;
        }

        public ArrayList PrepareGrowPlants()
        {
            ArrayList images = new ArrayList();
            GifToJpg(@"..\..\Images\PrepareGrowPlants.gif", images);
            return images;
        }

        public static Image NormalBackground0()
        {
            Image image = Image.FromFile(@"../../images/interface/background1unsodded_1.jpg");
            return image;
        }

        public static Image NormalBackground()
        {
            Image image = Image.FromFile(@"../../images/interface/background1.jpg");
            return image;
        }
        public static Image NormalBackground2()
        {
            Image image = Image.FromFile(@"..\..\images\interface\background2.jpg");
            return image;
        }

        public static Image NormalBackground3()
        {
            Image image = Image.FromFile(@"..\..\images\interface\background3.jpg");
            return image;
        }

        public static Image NormalBackground4()
        {
            Image image = Image.FromFile(@"..\..\images\interface\background4.jpg");
            return image;
        }

        public static Image NormalBackground5()
        {
            Image image = Image.FromFile(@"..\..\images\interface\background5.jpg");
            return image;
        }

        public static Image NormalBackground6()
        {
            Image image = Image.FromFile(@"..\..\images\interface\background6boss.jpg");
            return image;
        }
    }
}
