using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZombiesVsPlants.MyLand;
using ZombiesVsPlants.API;
using System.Threading;
using WindowsFormsApplication3;
using ZombiesVsPlants.MyZombie;
using ZombiesVsPlants.MyCleaner;
using ZombiesVsPlants.ExtendRole;
using ZombiesVsPlants.MyPlant;

namespace ZombiesVsPlants.MyMission
{
    class Mission3 : Mission
    {

        public Mission3() : base()
        {
        }

        public override void initMission(Map map)
        {
            base.initMission(map);
            ZombiesVsPlants.PlansTime.SunFlower = ZombiesVsPlants.PlansTime.SunShroom = ZombiesVsPlants.PlansTime.TwinSunflower = 180;
            //初始化剩余界面信息
            LevelStart();
        }

        public override void loadBackImage()
        {
            //初始化背景图片
            Map.BackgroundImage = Resources.NormalBackground3();
        }

        public override void initMap()
        {
            //初始化时间
            Map.IsDayTime = true;
            //初始化铲子
            Map.Shovel = new Shovel();
            //
            Map.SunBoard = new SunBoard(Map);
            Map.SunShine = 200;
            //草地环境
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Land land = new Grass(LandX(i), LandY(j));
                    Map.Lands.Add(land);
                }
            }
        }

        public override void initCleaners()
        {
            Map.addCleaner(new LawnMower(Street.FIRST, Floor.FIRST));
            Map.addCleaner(new LawnMower(Street.FIRST, Floor.SECOND - 10));
            Map.addCleaner(new LawnMower(Street.FIRST, Floor.THIRD - 30));
            Map.addCleaner(new LawnMower(Street.FIRST, Floor.FOURTH - 50));
            Map.addCleaner(new LawnMower(Street.FIRST, Floor.FIFTH - 60));
            Map.addCleaner(new LawnMower(Street.FIRST, Floor.SIXTH - 100));
        }

        public override void initCards()
        {
            Map.initCard(new PlantCard("LilyPad"));
            Map.initCard(new PlantCard("SunFlower"));
            Map.initCard(new PlantCard("TwinSunflower"));
            Map.initCard(new PlantCard("Peashooter"));
            Map.initCard(new PlantCard("GatlingPea"));
            Map.initCard(new PlantCard("SplitPea"));
            Map.initCard(new PlantCard("Threepeater"));
            Map.initCard(new PlantCard("SeaShroom"));
        }

        //关卡的开头动画
        public override void beginMovie()
        {
            base.beginMovie();
        }

        public override void CreateZombies()
        {
            //选择卡牌完成后的游戏界面初始化      
            //提示开始
            int validNum = Controller.GameTime;
            ZombiesVsPlants.AttackTime.sleeptime = 12000;
            ZombiesVsPlants.AttackTime.Tcases = 30;
            while (Controller.gameStatus != GameStatus.OVER && validNum == Controller.GameTime)
            {
                if (Controller.gameStatus == GameStatus.START)
                {
                    int random1 = ro.Next(1, 6);
                    int random2 = ro.Next(1, 50);

                    ZombieProduction(random1, random2);

                    Thread.Sleep(ZombiesVsPlants.AttackTime.sleeptime);

                    if (ZombiesVsPlants.AttackTime.Tcases == 0)
                    {
                        Controller.gameStatus = GameStatus.OVER;
                        System.Windows.Forms.MessageBox.Show("恭喜你以及通过本关卡");
                        System.Windows.Forms.MessageBox.Show("请开始下一关");
                    }

                    if (ZombiesVsPlants.AttackTime.sleeptime > 500) ZombiesVsPlants.AttackTime.sleeptime -= 200; //else ZombiesVsPlants.AttackTime.sleeptime = 100;

                    if (ZombiesVsPlants.AttackTime.sleeptime < 3000)
                    {
                        ZombiesVsPlants.AttackTime.Tcases--;
                    }
                }
            }
        }
        public void ZombieProduction(int random1, int random2)
        {
            if (random1 >= 8)
                Map.addZombie(new PoleVaultingZombie(Street.TENTH, LandY(random2 % 5)));
            else if (random1 >= 6)
                Map.addZombie(new BucketheadZombie(Street.TENTH, LandY(random2 % 5)));
            else if (random1 >= 4)
                Map.addZombie(new ConeheadZombie(Street.TENTH, LandY(random2 % 5)));
            else if (random1 >= 2)
                Map.addZombie(new FlagZombie(Street.TENTH, LandY(random2 % 5)));
            else if (random1 >= 0)
                Map.addZombie(new NormalZombie(Street.TENTH, LandY(random2 % 5)));
        }
    }
}
