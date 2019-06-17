using System;
using System.Windows.Forms;
using System.IO;

namespace ZombiesVsPlants
{
    public partial class zhuce : Form
    {
        String str;
        public zhuce()
        {
            InitializeComponent();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            String strName, strPasswords;
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("不能为空");
            }
            else if (textBox1.Text.Length > 15 || textBox1.Text.Length < 3 || textBox2.Text.Length < 6 || textBox2.Text.Length > 12)
                MessageBox.Show("不是合法长度的用户名和密码");
            else
            {
                strName = textBox1.Text;
                strPasswords = textBox2.Text;
                str = textBox1.Text + "\r\n" + textBox2.Text + "\r";
                File.WriteAllText(@"VGhlX1NhdmVzLnR4dA==", str);
                Hide();
                StartMeun form2 = new StartMeun();
                form2.ShowDialog();
                this.Close();
            }
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }
    }
}
