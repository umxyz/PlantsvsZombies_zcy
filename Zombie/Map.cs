using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using ZombiesVsPlants.MyPanel;
using ZombiesVsPlants.MyZombie;
using ZombiesVsPlants.MyBullet;
using ZombiesVsPlants.ExtendRole;
using ZombiesVsPlants.MyEnum;
using ZombiesVsPlants.MyMission;
using ZombiesVsPlants.MyCleaner;
using ZombiesVsPlants.API;
using WindowsFormsApplication3;
using ZombiesVsPlants.MyPlant;
using ZombiesVsPlants.MyLand;

namespace ZombiesVsPlants
{
    class Map : Element
    {
        //私有成员
        private SunBoard sunBoard;
        private Shovel shovel;
        //植物临时箱
        private PlantsBox pb;
        private CardsBar cb;
        //临时存储的卡牌ID
        private PlantCard pc;
        private int mouseX, mouseY;
        private bool isIntroduce;
        //角色数组
        private ArrayList zombies;
        private ArrayList plants;
        private ArrayList plantscards;
        private ArrayList bullets;
        private ArrayList suns;
        private ArrayList cleaners;
        private ArrayList plantcards;
        private ArrayList lands;
        //图片
        private Image backgroundImage;
        private Image noticeImage;
        //阳光
        private int sunshine;
        private int sunCost;
        private bool isDayTime;
        //关卡编号
        private Mission mission;
        //主界面
        private GamePanel p;


        public Map(GamePanel p)
        {
            this.p = p;
            initMap();
        }

        public void initMap()
        {
            //集合组
            plantscards = new ArrayList();
            zombies = new ArrayList();
            plants = new ArrayList();
            bullets = new ArrayList();
            suns = new ArrayList();
            lands = new ArrayList();
            cleaners = new ArrayList();
            //植物临时箱
            pb = new PlantsBox(this);
            cb = new CardsBar(this);

            sunshine = 150;
        }

        public void initMission(Mission mission)
        {
            if (this.mission != null)
                Controller.GameTime++;
            this.mission = mission;
            mission.initMission(this);
        }

        public void initMission()
        {
            if (this.mission == null)
            {
                System.Windows.Forms.MessageBox.Show("没有选择关卡");
                return;
            }
            Controller.GameTime++;
            this.mission.initMission(this);
        }

        public bool initPlantBox(string type)
        {
            pb.setType(type);
            pb.Run();
            return true;
        }

        public void addSun(Sun s)
        {
            suns.Add(s);
            s.Map = this;
            s.Run();
        }

        public void addBullet(Bullet b)
        {
            bullets.Add(b);
            b.Map = this;
            b.Run();
        }

        public void addZombie(Zombie z)
        {
            zombies.Add(z);
            z.Map = this;
            z.Run();
        }

        public void addCard(PlantCard pc)
        {
            plantscards.Add(pc);
            pc.Map = this;
        }

        public void initCard(PlantCard pc)
        {
            cb.initCard(pc);
        }

        public void addPlant(Plant p)
        {
            plants.Add(p);
            p.Map = this;
            p.Run();
        }

        public void addCleaner(Cleaner c)
        {
            cleaners.Add(c);
            c.Map = this;
            c.Run();
        }

        public void Clear()
        {
            Controller.gameStatus = GameStatus.OVER;
            sunshine = 1000;
            Clear(plants);
            Clear(zombies);
            Clear(suns);
            plantscards.Clear();
            Clear(cleaners);
            Clear(bullets);
            for(int i=0;i<lands.Count;i++)
            {
                ((Land)lands[i]).IsEmpty = true;
            }
        }

        public void Clear(ArrayList array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                ((Role)array[i]).RolesStatus = RoleStatus.DISPEAR;
            }
            array.Clear();
        }


        public void delete(ArrayList array,Role r)
        {
            array.Remove(r);
        }

        public void Update()
        {
            p.Invalidate();
        }

        public override void Draw(Graphics g)
        {
            if (backgroundImage != null)
                g.DrawImage(backgroundImage, -(int)(MyAPI.GamePanelX * 1.0), 0, 1400, 600);
            for (int i = 0; i < plants.Count; i++)
            {
                Plant p = (Plant)plants[i];
                p.Draw(g);
            }
            
            for (int i = 0; i < zombies.Count; i++)
            {
                Zombie zombie = (Zombie)zombies[i];
                zombie.Draw(g);
            }

            for (int i = 0; i < cleaners.Count; i++)
            {
                Cleaner c = (Cleaner)cleaners[i];
                c.Draw(g);
            }

            
            for (int i = 0; i < plantscards.Count; i++)
            {
                PlantCard pc = (PlantCard)plantscards[i];
                pc.Draw(g);
            }
            
            for (int i = 0; i < bullets.Count; i++)
            {
                //Bullet b = (Bullet)bullets[i];
                ((Bullet)bullets[i]).Draw(g);
            }

            for (int i = 0; i < suns.Count; i++)
            {
                Sun sun = (Sun)suns[i];
                sun.Draw(g);
            }
            
            if (pb.IsAcitive != false)
                pb.Draw(g);
            if (shovel != null)
                shovel.Draw(g);
            if (sunBoard != null)
                sunBoard.Draw(g);
            if (noticeImage != null)
            {
                g.DrawImage(noticeImage, 900 / 2 - noticeImage.Width / 2 + 120,
                    600 / 2 - noticeImage.Height / 2, noticeImage.Width, noticeImage.Height);
            }
            
            //绘制介绍区域
            //if (isIntroduce)
            //{
            //    showIntroduce(g);
            //}
        }

        //显示每个卡牌的说明
        private void showIntroduce(Graphics g)
        {
            int textY = mouseY + 30;
            int height = 50, textHeight = 20;
            Pen pen = new Pen(new SolidBrush(Color.Black));
            Brush brush = new SolidBrush(Color.WhiteSmoke);
            Brush textBrush = new SolidBrush(Color.Black);
            Font font = new Font("宋体", 9);

            string name = MyAPI.ChineseType(pc.Type);
            string coolTime = "冷却时间:" + pc.LoadTime + "秒";
            string introduce = MyAPI.PlantIntroduction(pc.Type);
            if (pc.WaitTime != 0)
            {
                height += textHeight;
            }
            if (pc.NeedSun > SunShine)
            {
                height += textHeight;
            }
            height += 20 + 20 * (introduce.Length / 8);

            g.FillRectangle(brush, mouseX, mouseY + 30, 120, height);
            g.DrawRectangle(pen, mouseX, mouseY + 30, 120, height);
            //绘制名称
            textY = showText(name,
                textY + 10, font, textBrush, g);
            textY = showText(coolTime,
                textY, font, textBrush, g);
            //绘制说明
            textY = showText(introduce,
                textY, font, textBrush, g);
            //显示当前卡牌情况
            if (pc.WaitTime != 0)
            {
                Brush loadbrush = new SolidBrush(Color.Red);
                textY = showText("装填弹药中..",
                    textY, font, loadbrush, g);
            }
            if (pc.NeedSun > SunShine)
            {
                Brush loadbrush = new SolidBrush(Color.Red);
                textY = showText("阳光不足",
                    textY, font, loadbrush, g);
            }
        }

        //显示文本
        private int showText(string s, int textY, Font font, Brush brush, Graphics g)
        {
            int time = s.Length / 8;
            int startNum = 0;
            SizeF sizeF = g.MeasureString(s + "", font);
            string text, nextText;
            if (s.Length <= 8)
            {
                g.DrawString(s + "", font, brush, new Rectangle(mouseX + 60 - (int)sizeF.Width / 2,
                    textY, (int)sizeF.Width + 1, (int)sizeF.Height));
                textY += 20;
            }
            else
            {
                nextText = s.Substring(startNum + 8, s.Length - 8);
                text = s.Substring(startNum, 8);
                SizeF sizeF2 = g.MeasureString(text + "", font);
                g.DrawString(text + "", font, brush, new Rectangle(mouseX + 60 - (int)sizeF2.Width / 2,
                    textY, (int)sizeF2.Width + 1, (int)sizeF2.Height));
                textY = showText(nextText, textY + 20, font, brush, g);
            }

            return textY;
        }

        public int SunShine
        {
            get { return sunshine; }
            set { sunshine = value; }
        }
        public ArrayList Plants
        {
            get { return plants; }
            set { plants = value; }
        }

        public ArrayList Zombies
        {
            get { return zombies; }
            set { zombies = value; }
        }

        internal Shovel Shovel
        {
            get { return shovel; }
            set { shovel = value; }
        }

        public ArrayList Cleaners
        {
            get { return cleaners; }
            set { cleaners = value; }
        }
        
        internal PlantCard Pc
        {
            get { return pc; }
            set { pc = value; }
        }

        public int SunCost
        {
            get { return sunCost; }
            set { sunCost = value; }
        }
        
        public ArrayList Plantscards
        {
            get { return plantscards; }
            set { plantscards = value; }
        }

        public ArrayList Suns
        {
            get { return suns; }
            set { suns = value; }
        }

        public ArrayList Bullets
        {
            get { return bullets; }
            set { bullets = value; }
        }

        public Image NoticeImage
        {
            get { return noticeImage; }
            set { noticeImage = value; }
        }

        public Image BackgroundImage
        {
            get { return backgroundImage; }
            set { backgroundImage = value; }
        }

        public bool IsDayTime
        {
            get { return isDayTime; }
            set { isDayTime = value; }
        }

        public ArrayList Lands
        {
            get { return lands; }
            set { lands = value; }
        }

        internal SunBoard SunBoard
        {
            get { return sunBoard; }
            set { sunBoard = value; }
        }

        internal PlantsBox Pb
        {
            get { return pb; }
            set { pb = value; }
        }

        public bool IsIntroduce
        {
            get { return isIntroduce; }
            set { isIntroduce = value; }
        }

        public int MouseX
        {
            get { return mouseX; }
            set { mouseX = value; }
        }

        public int MouseY
        {
            get { return mouseY; }
            set { mouseY = value; }
        }

        internal Mission Mission
        {
            get { return mission; }
            set { mission = value; }
        }
    }
}
