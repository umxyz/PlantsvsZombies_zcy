using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ZombiesVsPlants.MyPanel
{
    class GamePanel : Panel
    {
        //子面板
        private MenuDialog md;
        //控制器，与控制器关联
        private Controller c;
        //菜单按钮
        private MyButton button;

        //private
        public GamePanel(Controller c)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = ZombiesVsPlants.FilesPath.AudioLong;
            player.Load();
            player.PlayLooping();
            this.c = c;
            initSubPanel();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.AllPaintingInWmPaint, true);
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Paint += new PaintEventHandler(GamePanel_Paint);
            this.MouseClick += new MouseEventHandler(GamePanel_MouseClick);
            this.MouseMove += new MouseEventHandler(GamePanel_MouseMove);
        }

        public void initSubPanel()
        {
            md = new MenuDialog(this);
            md.SetBounds(340, 40, 413, 520);

            button = new MyButton("菜单");
            button.SetBounds(900, 0, 113, 41);
            button.MouseClick += new MouseEventHandler(GamePanel_MouseClick);
            button.MouseMove += new MouseEventHandler(GamePanel_MouseMove);

            this.Controls.Add(md);
            this.Controls.Add(button);
        }

        public void MenuDialogClicked(Object o)
        {
            if (o is MyButton)
            {
                MyButton mb = (MyButton)o;
                bool isStart = false;
                //初始化地图
                switch (mb.MyText)
                {
                    case "重新开始":
                        c.Restart();
                        break;
                    case "新手关":
                        c.MissionStart(mb.MyText);
                        md.Visible = false;
                        break;
                    case "第一关":
                        c.MissionStart(mb.MyText);
                        md.Visible = false;
                        break;
                    case "第二关":
                        c.MissionStart(mb.MyText);
                        md.Visible = false;
                        break;
                    case "第三关":
                        c.MissionStart(mb.MyText);
                        md.Visible = false;
                        break;
                    case "第四关":
                        c.MissionStart(mb.MyText);
                        md.Visible = false;
                        break;
                    case "第五关":
                        c.MissionStart(mb.MyText);
                        md.Visible = false;
                        break;
                    case "第六关":
                        c.MissionStart(mb.MyText);
                        md.Visible = false;
                        break;
                    case "无尽模式":
                        //System.Windows.Forms.MessageBox.Show("模板已制作数据待完成");
                        c.MissionStart(mb.MyText);
                        md.Visible = false;
                        break;
                    case "菜单":
                        md.Visible = true;
                        break;
                    case "返回主界面":
                        System.Windows.Forms.MessageBox.Show("此阶段不能返回");
                        md.Visible = true;
                        break;
                }
                if (isStart)
                {
                    md.Visible = false;
                }
            }
            else if (o is Label)
            {
                md.Visible = false;
            }
        }

        public void MapClicked(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                c.isClick(e.X, e.Y);
                c.planting(e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Right)
            {
                c.PbDestroy();
            }
        }

        public void GamePanel_Paint(Object o, PaintEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            //视图改变
            c.Map.Draw(g);
        }

        public void GamePanel_MouseClick(Object o, MouseEventArgs e)
        {
            MenuDialogClicked(o);
            MapClicked(e);
        }
        public void GamePanel_MouseClick2(Object o, MouseEventArgs e)
        {
            //ZombiesVsPlants.BoolFlag.flag = false;
            System.Environment.Exit(0);
        }
        public void GamePanel_MouseMove(Object o, MouseEventArgs e)
        {
            if (Controller.gameStatus == GameStatus.START)
            {
                c.PlantBoxMove(e.X, e.Y);
                c.setShadow(e.X, e.Y);
                c.MoveShovel(e.X, e.Y);
                if (c.isEnter(e.X, e.Y))
                {
                    this.Cursor = Cursors.Hand;
                }
                else
                    this.Cursor = Cursors.Arrow;
                return;
            }
            if (o is MyButton)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Arrow;
            }
        }
    }
}
