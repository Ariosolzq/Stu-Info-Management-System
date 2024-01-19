using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace St20241031
{
    public partial class frmLogin : Form
    {
        
        frmStinfo frmstinfo = new frmStinfo();
        MDI MDI = new MDI();
        public frmLogin()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = St20241031.Properties.Resources.books;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text =="" || textBox2.Text=="")
            {
                MessageBox.Show("请输入账号或密码");
                textBox1.Focus();
            }
            else 
            {
                MessageBox.Show("欢迎登录");
                MDI.Show();
                this.Hide();
            }
        }
    }
}
