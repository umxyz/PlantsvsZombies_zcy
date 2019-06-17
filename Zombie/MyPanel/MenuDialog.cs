using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using ZombiesVsPlants.MyPanel;

namespace ZombiesVsPlants
{
    class MenuDialog : Panel
    {
        private GamePanel p;
        private WelcomePanel w;

        public MenuDialog(GamePanel p)
        {
            this.p = p;
            this.BackColor = System.Drawing.Color.Transparent;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.AllPaintingInWmPaint, true);
            this.Paint += new PaintEventHandler(MenuDialog2_Paint);

            initImage();
            initButton();
        }

        private void initButton()
        {
            //
            //  第一个按钮
            //
            Restart = new MyButton("重新开始");
            Restart.SetBounds(150,60,113,41);
            Restart.MouseUp += new MouseEventHandler(p.GamePanel_MouseClick);
            Restart.MouseMove += new MouseEventHandler(MenuDialog_MouseMove);
            //
            //  第00个按钮
            //
            level0 = new MyButton("新手关");
            level0.SetBounds(90, 130, 113, 41);
            level0.MouseUp += new MouseEventHandler(p.GamePanel_MouseClick);
            level0.MouseMove += new MouseEventHandler(MenuDialog_MouseMove);
            //
            //  第二个按钮
            //
            FirstLevel = new MyButton("第一关");
            FirstLevel.SetBounds(210, 130, 113, 41);
            FirstLevel.MouseUp += new MouseEventHandler(p.GamePanel_MouseClick);
            FirstLevel.MouseMove += new MouseEventHandler(MenuDialog_MouseMove);
            //
            //  第三个按钮
            //
            SecondLevel = new MyButton("第二关");
            SecondLevel.SetBounds(90, 180, 113, 41);
            SecondLevel.MouseUp += new MouseEventHandler(p.GamePanel_MouseClick);
            SecondLevel.MouseMove += new MouseEventHandler(MenuDialog_MouseMove);
            //
            //  第四个按钮
            //
            level3 = new MyButton("第三关");
            level3.SetBounds(210, 180, 113, 41);
            level3.MouseUp += new MouseEventHandler(p.GamePanel_MouseClick);
            level3.MouseMove += new MouseEventHandler(MenuDialog_MouseMove);
            //
            //  第五个按钮
            //
            level4 = new MyButton("第四关");
            level4.SetBounds(90, 230, 113, 41);
            level4.MouseUp += new MouseEventHandler(p.GamePanel_MouseClick);
            level4.MouseMove += new MouseEventHandler(MenuDialog_MouseMove);
            //
            //  第六个按钮
            //
            level5 = new MyButton("第五关");
            level5.SetBounds(210, 230, 113, 41);
            level5.MouseUp += new MouseEventHandler(p.GamePanel_MouseClick);
            level5.MouseMove += new MouseEventHandler(MenuDialog_MouseMove);
            //
            //  第七个按钮
            //
            level6 = new MyButton("第六关");
            level6.SetBounds(90, 280, 113, 41);
            level6.MouseUp += new MouseEventHandler(p.GamePanel_MouseClick);
            level6.MouseMove += new MouseEventHandler(MenuDialog_MouseMove);
            //
            //  第八个按钮
            //
            level7 = new MyButton("无尽模式");
            level7.SetBounds(210, 280, 113, 41);
            level7.MouseUp += new MouseEventHandler(p.GamePanel_MouseClick);
            level7.MouseMove += new MouseEventHandler(MenuDialog_MouseMove);
            //
            //  backGame
            //
            backGame = new Label();
            backGame.Text = "返回游戏";
            backGame.Font = new Font("宋体",15);
            backGame.SetBounds(155,450, 120, 50);
            backGame.MouseUp += new MouseEventHandler(p.GamePanel_MouseClick);
            //
            //  backMeun
            //
            backMeun = new MyButton("返回主界面");
            backMeun.Font = new Font("宋体", 15);
            backMeun.SetBounds(210, 450, 120, 50);
            backMeun.MouseUp += new MouseEventHandler(p.GamePanel_MouseClick);
            backMeun.MouseMove += new MouseEventHandler(MenuDialog_MouseMove);

            this.Controls.Add(Restart);
            this.Controls.Add(FirstLevel);
            this.Controls.Add(SecondLevel);
            this.Controls.Add(level0);
            this.Controls.Add(level3);
            this.Controls.Add(level4);
            this.Controls.Add(level5);
            this.Controls.Add(level6);
            this.Controls.Add(level7);
            this.Controls.Add(backGame);
            //this.Controls.Add(backMeun);
            this.MouseMove += new MouseEventHandler(MenuDialog_MouseMove);
        }

        public void initImage()
        {
            dialog_bottomleft = Image.FromFile("../../images/interface/dialog_bottomleft.png");
            dialog_bottomiddle = Image.FromFile("../../images/interface/dialog_bottommiddle.png");
            dialog_bottomright = Image.FromFile("../../images/interface/dialog_bottomright.png");
            dialog_centerleft = Image.FromFile("../../images/interface/dialog_centerleft.png");
            dialog_centermiddle = Image.FromFile("../../images/interface/dialog_centermiddle.png");
            dialog_centerright = Image.FromFile("../../images/interface/dialog_centerright.png");
            dialog_topleft = Image.FromFile("../../images/interface/dialog_topleft.png");
            dialog_topmiddle = Image.FromFile("../../images/interface/dialog_topmiddle.png");
            dialog_topright = Image.FromFile("../../images/interface/dialog_topright.png");
        }
     
        public void MenuDialog2_Paint(Object sender,PaintEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            //绘制背景
            DrawBackground(g);
        }

        private void DrawBackground(System.Drawing.Graphics g)
        {
            g.DrawImage(dialog_topleft, 0, 0, 107, 97);
            g.DrawImage(dialog_topmiddle, 107, 0, 93, 97);
            g.DrawImage(dialog_topmiddle, 200, 0, 93, 97);
            g.DrawImage(dialog_topright, 293, 0, 120, 97);
            g.DrawImage(dialog_centerleft, 0, 97, 107, 54);
            g.DrawImage(dialog_centermiddle, 107, 97, 93, 54);
            g.DrawImage(dialog_centermiddle, 200, 97, 93, 54);
            g.DrawImage(dialog_centerright, 293, 97, 105, 54);
            g.DrawImage(dialog_centerleft, 0, 151, 107, 54);
            g.DrawImage(dialog_centermiddle, 107, 151, 93, 54);
            g.DrawImage(dialog_centermiddle, 200, 151, 93, 54);
            g.DrawImage(dialog_centerright, 293, 151, 105, 54);
            g.DrawImage(dialog_centerleft, 0, 205, 107, 54);
            g.DrawImage(dialog_centermiddle, 107, 205, 93, 54);
            g.DrawImage(dialog_centermiddle, 200, 205, 93, 54);
            g.DrawImage(dialog_centerright, 293, 205, 105, 54);
            g.DrawImage(dialog_centerleft, 0, 259, 107, 54);
            g.DrawImage(dialog_centermiddle, 107, 259, 93, 54);
            g.DrawImage(dialog_centermiddle, 200, 259, 93, 54);
            g.DrawImage(dialog_centerright, 293, 259, 105, 54);
            g.DrawImage(dialog_centerleft, 0, 313, 107, 54);
            g.DrawImage(dialog_centermiddle, 107, 313, 93, 54);
            g.DrawImage(dialog_centermiddle, 200, 313, 93, 54);
            g.DrawImage(dialog_centerright, 293, 313, 105, 54);
            g.DrawImage(dialog_centerleft, 0, 367, 107, 54);
            g.DrawImage(dialog_centermiddle, 107, 367, 93, 54);
            g.DrawImage(dialog_centermiddle, 200, 367, 93, 54);
            g.DrawImage(dialog_centerright, 293, 367, 105, 54);
            g.DrawImage(dialog_bottomleft, 0, 421, 107, 97);
            g.DrawImage(dialog_bottomiddle, 107, 421, 93, 97);
            g.DrawImage(dialog_bottomiddle, 200, 421, 93, 97);
            g.DrawImage(dialog_bottomright, 293, 421, 108, 97);
        }


        public void MenuDialog_MouseMove(Object o, MouseEventArgs e)
        {
            if (o is MyButton || o is Label)
                Cursor = Cursors.Hand;
            else
                Cursor = Cursors.Arrow;
        }

        private Image dialog_bottomleft;
        private Image dialog_bottomiddle;
        private Image dialog_bottomright;
        private Image dialog_centermiddle;
        private Image dialog_centerleft;
        private Image dialog_centerright;
        private Image dialog_topleft;
        private Image dialog_topmiddle;
        private Image dialog_topright;
        private MyButton Restart;
        private MyButton FirstLevel;
        private MyButton SecondLevel;
        private MyButton level0;
        private MyButton level3;
        private MyButton level4;
        private MyButton level5;
        private MyButton level6;
        private MyButton level7;
        private Label backGame;
        private MyButton backMeun;
    }
}
