using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ZombiesVsPlants
{
    public partial class StartMeun : Form
    {
        String strName, strPasswords;
        public StartMeun()
        {
            String Words = "免责声明：此项目修改仅用于个人好玩\n      欢迎进入曾晨宇的修改的游戏\n                祝您游戏愉快\n     修改不易请勿抄袭\n警告:\n    请勿修改文件夹内任何内容";
            if (ZombiesVsPlants.PlansTime.flag == false)
                MessageBox.Show(Words);
            ZombiesVsPlants.PlansTime.flag = true;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = ZombiesVsPlants.FilesPath.AudioShort;
            player.Load();
            player.PlayLooping();
            InitializeComponent();
            //this.ControlBox = false;   // 设置不出现关闭按钮
        }

        private void 登陆菜单_Load(object sender, EventArgs e)
        {

        }

        private void 用户名_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("VGhlX1NhdmVzLnR4dA==", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s;
            s = sr.ReadLine();
            int i = 0;
            while (s != null)
            {
                if (i == 0)
                    strName = s;
                else
                    strPasswords = s;
                s = sr.ReadLine();
                i++;
            }
            if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text))
                if ((textBox1.Text == strName && textBox2.Text == strPasswords) || (textBox1.Text == "admin" && textBox2.Text == "admin"))
                {
                    MessageBox.Show("登陆成功");
                    this.Hide();
                    StartForm fm = new StartForm();
                    fm.ShowDialog();
                }
                else if (textBox1.Text.Length > 15 || textBox1.Text.Length < 3 || textBox2.Text.Length < 6 || textBox2.Text.Length > 12)
                    MessageBox.Show("不是合法长度的用户名和密码");
                else
                    MessageBox.Show("用户名或密码请重新输入");
            else
                MessageBox.Show("不能为空");
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Hide();
            zhuce form2 = new zhuce();
            form2.ShowDialog();
            this.Close();
        }
    }
}
