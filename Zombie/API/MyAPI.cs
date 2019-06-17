using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using WindowsFormsApplication3;

namespace ZombiesVsPlants.API
{
    class MyAPI
    {
        public static int GamePanelX = 0;
        public static int GlassHeight = 100;//用于僵尸调整坐标的草地高度
        public static int ZombieHeight = 154;
        public static int CardHeight = 60;
        public static int CardWidth = 100;
        public static int PlantWidth = 80;//草地宽度，用于植物调整坐标
        public static int PlantHeight = 100;
        public static int BulletWidth = 52;
        public static int SunBoardX = 290;
        public static int SunBoardY = 15;
        public static int ShovelX = 370;
        public static int ShovelY = 0;
        //各线程刷新速率
        public static int SunFlowSpeed = 100;
        public static int SunOfSunFlower = 8000;
        public static int ZombieRunSpeed = 80;
        public static int PlantAttackSpeed = 5000;
        public static int BulletMoveSpeed = 30;
        public static int PlantDanceSpeed = 80;
        public static int ControllSpeed = 150;
        public static int PlantsBoxSpeed = 200;
        public static int ZombieAttackSpeed = 100;//(40倍此数值即为攻击间隔)
        public static int RepeaterSecondAttackTime = 250;
        public static int SunDispearSpeed = 50;

        public bool isHit(Role a, Role b)
        {
            if ((a.X + a.Width) > (b.X + b.Width / 2 + 20) && (a.X + a.Width) < (b.X + b.Width) && a.Floor == b.Floor)
            {
                return true;
            }
            return false;
        }

        public void TransparentImage(int x, int y, Image image, Graphics g)
        {
            Bitmap bitmap = new Bitmap(image, image.Width, image.Height);
            float[][] ptsArray ={
            new float[] {1, 0, 0, 0, 0},
            new float[] {0, 1, 0, 0, 0},
            new float[] {0, 0, 1, 0, 0},
            new float[] {0, 0, 0, 0.2f, 0}, //注意：此处为0.1f，图像为强透明
            new float[] {0, 0, 0, 0, 1}};
            ColorMatrix clrMatrix = new ColorMatrix(ptsArray);
            ImageAttributes imgAttributes = new ImageAttributes();
            //设置图像的颜色属性
            imgAttributes.SetColorMatrix(clrMatrix, ColorMatrixFlag.Default,
            ColorAdjustType.Bitmap);
            g.DrawImage(bitmap, new Rectangle(x, y, bitmap.Width, bitmap.Height),
            0, 0, bitmap.Width, bitmap.Height,
            GraphicsUnit.Pixel, imgAttributes);
        }

        public int NeedSun(string PlantType)
        {
            switch (PlantType)
            {
                case "SunFlower":
                    return 50;
                case "Repeater":
                    return 125;
                case "WallNut":
                    return 25;
                case "FlowerPot":
                    return 25;
                case "GatlingPea":
                    return 250;
                case "LilyPad":
                    return 25;
                case "SeaShroom":
                    return 50;
                case "SnowPea":
                    return 175;
                case "SplitPea":
                    return 225;
                case "TallNut":
                    return 75;
                case "TwinSunflower":
                    return 125;
                case "DoomShroom":
                    return 75;
                case "PotatoMine":
                    return 50;
                case "CherryBomb":
                    return 50;
                case "PuffShroom":
                    return 0;
                case "ScaredyShroom":
                    return 50;
                case "PumpkinHead":
                    return 25;
                default:
                    return 75;
            }
        }

        public int CoolDown(string PlantType)
        {
            switch (PlantType)
            {
                case "SunFlower":
                    return 5;
                case "Repeater":
                    return 5;
                case "FlowerPot":
                    return 2;
                case "GatlingPea":
                    return 10;
                case "LilyPad":
                    return 2;
                case "SnowPea":
                    return 8;
                case "SplitPea":
                    return 8;
                case "TallNut":
                    return 5;
                case "TwinSunflower":
                    return 7;
                case "CoffeeBean":
                    return 5;
                case "DoomShroom":
                    return 5;
                case "PotatoMine":
                    return 5;
                default:
                    return 3;
            }
        }

        public bool isEnter(Element e, int x, int y)
        {
            if (x > e.X && x < (e.X + e.Width) && y > e.Y && y < e.Y
                + e.Height)
            {
                return true;
            }
            return false;
        }

        public static BoxForPlant AdjustPonint(int x, int y)
        {
            Street s;
            Floor f;
            //
            //  判断街道数
            //
            if (x > (int)Street.FIRST && x < (int)Street.SECOND)
                s = Street.FIRST;
            else if (x > (int)Street.SECOND && x < (int)Street.THIRD)
                s = Street.SECOND;
            else if (x > (int)Street.THIRD && x < (int)Street.FOURTH)
                s = Street.THIRD;
            else if (x > (int)Street.FOURTH && x < (int)Street.FIFTH)
                s = Street.FOURTH;
            else if (x > (int)Street.FIFTH && x < (int)Street.SIXTH)
                s = Street.FIFTH;
            else if (x > (int)Street.SIXTH && x < (int)Street.SEVENTH)
                s = Street.SIXTH;
            else if (x > (int)Street.SEVENTH && x < (int)Street.EIGHTH)
                s = Street.SEVENTH;
            else if (x > (int)Street.EIGHTH && x < (int)Street.NINTH)
                s = Street.EIGHTH;
            else if (x > (int)Street.NINTH && x < (int)Street.TENTH)
                s = Street.NINTH;
            else
                s = Street.NULL;
            //
            //  判断Y所在楼层数
            //
            if (y > (int)Floor.FIRST && y < (int)Floor.SECOND)
                f = Floor.FIRST;
            else if (y > (int)Floor.SECOND && y < (int)Floor.THIRD)
                f = Floor.SECOND;
            else if (y > (int)Floor.THIRD && y < (int)Floor.FOURTH)
                f = Floor.THIRD;
            else if (y > (int)Floor.FOURTH && y < (int)Floor.FIFTH)
                f = Floor.FOURTH;
            else if (y > (int)Floor.FIFTH && y < (int)Floor.SIXTH)
                f = Floor.FIFTH;
            else if (y > (int)Floor.SIXTH && y < (int)Floor.SEVENTH)
                f = Floor.SIXTH;
            else
                f = Floor.NULL;


            return new BoxForPlant(s, f);

        }

        internal static string PlantIntroduction(string type)
        {
            if (type.Equals("SunFlower"))
            {
                return "向日葵是你收集额外阳光必不可少的植物。为什么不多种一些呢？";
            }
            else if (type.Equals("Repeater"))
            {
                return "这个和第一个不一样的地方就是脑袋后面的叶子比较多，他是发2个豆豆的。";
            }
            else if (type.Equals("Peashooter"))
            {
                return "豌豆射手可谓你的第一道防线，他们朝来犯的僵尸射击豌豆。";
            }
            else
                return "";
        }

        internal static string ChineseType(string type)
        {
            if (type.Equals("SunFlower"))
            {
                return "向日葵";
            }
            else if (type.Equals("Repeater"))
            {
                return "双枪豌豆";
            }
            else if (type.Equals("Peashooter"))
            {
                return "豌豆射手";
            }
            else
                return "";
        }
    }
}
