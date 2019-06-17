using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.IO;

namespace ZombiesVsPlants.MyPanel
{
    class WelcomePanel : Panel
    {
        //私有属性
        private Image backgroundImage;
        private Button button1, button2, button3;
        private Image ButtonDownImage;
        private Image ButtonUpImage;
        //主窗口
        private StartForm form;

        public WelcomePanel(StartForm form)
        {
            //SoundPlayer music = new SoundPlayer();
            //music = new SoundPlayer(ZombiesVsPlants.FilesPath.AudioShort);
            //music.Play();
            //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            //player.SoundLocation = ZombiesVsPlants.FilesPath.AudioShort;
            //player.Load();
            //player.PlayLooping();
            //this.music.Ctlcontrols.stop();
            this.form = form;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.AllPaintingInWmPaint, true);
            this.BorderStyle = BorderStyle.Fixed3D;
            //System.Windows.Forms.MessageBox.Show("请尽量玩新版本第单数关卡",
                //"其他植物高度Map区域等数据还未制作完成测试数据需要花费大量时间请谅解");
            init();
        }

        public void init()
        {
            //Image
            backgroundImage = Resources.WelcomeBackImage();
            ButtonDownImage = Resources.Start_Over();
            ButtonUpImage = Resources.Start_Leave();
            //按钮初始化
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button1.SetBounds(520, 415, 90, 32);
            button2.SetBounds(520, 450, 90, 32);
            button3.SetBounds(520, 485, 90, 32);
            //button1.BackgroundImage = ButtonUpImage;
            button1.Text = "新版本";
            button2.Text = "旧版本";
            button3.Text = "退出游戏";
            //增加控件
            this.Controls.Add(button1);
            this.Controls.Add(button2);
            this.Controls.Add(button3);
            //添加事件委托
            button1.MouseDown += new MouseEventHandler(button1_MouseDown);
            button1.MouseUp += new MouseEventHandler(button1_MouseUp);
            button2.MouseDown += new MouseEventHandler(button2_MouseDown);
            button2.MouseUp += new MouseEventHandler(button2_MouseUp);
            button3.MouseDown += new MouseEventHandler(button3_MouseDown);
            button3.MouseUp += new MouseEventHandler(button3_MouseUp);
            this.Paint += new PaintEventHandler(WelcomePanel_Paint);
        }

        public void WelcomePanel_Paint(Object o, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(backgroundImage, 0, 0, 800, 600);

        }

        public void button1_MouseUp(Object o, MouseEventArgs e)
        {
            button1.BackgroundImage = ButtonUpImage;
            form.showMisson();
        }

        public void button1_MouseDown(Object o, MouseEventArgs e)
        {
            button1.BackgroundImage = ButtonDownImage;
        }
        public void button2_MouseUp(Object o, MouseEventArgs e)
        {
            form.showgame();
        }

        public void button2_MouseDown(Object o, MouseEventArgs e)
        {

        }
        public void button3_MouseUp(Object o, MouseEventArgs e)
        {
            System.Environment.Exit(0);
        }

        public void button3_MouseDown(Object o, MouseEventArgs e)
        {
            
        }
    }
}
