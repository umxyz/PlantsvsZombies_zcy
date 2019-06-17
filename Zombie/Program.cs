using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombiesVsPlants
{
    public static class FilesPath
    {
        public static string DefaultZombie = "../../images/Zombies/Zombie/Zombie.gif";  //默认僵尸
        public static string DefaultZombieAttack = "../../images/Zombies/Zombie/ZombieAttack.gif";  //默认僵尸攻击
        public static string FlagZombie = "../../images/Zombies/FlagZombie/FlagZombie.gif";  //领头僵尸
        public static string FlagZombieAttack = "../../images/Zombies/FlagZombie/FlagZombieAttack.gif";  //领头僵尸攻击
        public static string PlantPeashooter = "../../images/Plants/Peashooter/Peashooter.gif";  //豌豆射手
        public static string PlantWallNut = "../../images/Plants/WallNut/WallNut.gif";       //坚果
        public static string PlantGarlic = ".../../images/Plants/Garlic/Garlic.gif";  //窝瓜
        public static string PlantPotatoMine = "../../images/Plants/PotatoMine/PotatoMine.gif";  //土地地雷
        public static string PlantPumpkinHead = "../../images/Plants/PumpkinHead/PumpkinHead.gif";    //南瓜灯
        public static string PlantTwinSunflower = "../../images/Plants/TwinSunflower/TwinSunflower.gif";    //双向日葵
        public static string PlantsBullet10 = "../../images/Plants/PB10.gif";   //植物发射燃烧子弹
        public static string PlantsBulletPeashooter = "../../images/Plants/PeaBullet.gif";   //豌豆射手子弹
        public static string PlantsBulletPeashooterHits = "../../images/Plants/PeaBulletHit.gif";   //豌豆射手攻击动画
        public static string PlantsBulletWallNut = "../../images/Plants/ShroomBullet.gif";  //非攻击类植物蓝色子弹
        public static string PlantsBulletWallNutHits = "../../images/Plants/Wallnut/Wallnut_cracked2.gif";  //动画
        public static string PlantsBulletGarlic = "../../images/Plants/ShroomBullet.gif";   //窝瓜
        public static string PlantsBulletGarlicHits = "../../images/Plants/Garlic/Garlic_body3.gif";
        public static string PlantsBulletPotatoMine = "../../images/Plants/ShroomBullet.gif";   //土地地雷
        public static string PlantsBulletPotatoMineHits = "../../images/Plants/PotatoMine/PotatoMine_mashed.gif";
        public static string PlantsBulletPumpkinHead = "../../images/Plants/ShroomBullet.gif";  //南瓜头
        public static string PlantsBulletPumpkinHeadHits = "../../images/Plants/PumpkinHead/PumpkinHead2.gif";
        public static string PlantsBulletTwinSunflower = "../../images/Plants/ShroomBullet.gif";    //双向日葵
        public static string PlantsBulletTwinSunflowerHits = "../../images/Plants/PeaBulletHit.gif";
        public static string PlantsFileStr; //需要调用的植物路径
        public static string PlantsBullet;  //需要调用的子弹路径
        public static string PlantsBulletHits;  //需要调用的射击动画路径
        public static string AudioShort = "../../images/short.wav";   //Choose Your Seeds.mp3
        public static string AudioLong = "../../images/long.wav";    //Crazy Dave (Intro Theme).mp3
        public static string Welcomebackground = "../../images/Logo.jpg";
    }

    public static class AttackTime
    {
        public static int Cactus, CherryBomb, DoomShroom, FumeShroom, FlowerPot, GatlingPea, GloomShroom, IceShroom, Jalapeno, LilyPad, Peashooter, PotatoMine, PuffShroom, Repeater, ScaredyShroom, SeaShroom, SnowPea, SplitPea, SunFlower, SunShroom, TallNut, Threepeater, TwinSunflower, WallNut;
        public static int Tcases, sleeptime;
    }

    public static class PlansTime
    {
        public static int SunFlower, SunShroom, TwinSunflower;
        public static bool flag = false;
    }

    public enum CharacterName
    {
        nZombie,
        nFlagZombie,
        nConeheadZombie,
        nBucketheadZombie,
        nRepeater
    }
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartMeun());
            //Application.Run(new StartForm());
        }
    }
}
