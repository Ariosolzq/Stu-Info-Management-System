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
    public partial class frmFormEvent : Form
    {
        
        frmAbout frmabout = new frmAbout();
        frmLogin frmlogin = new frmLogin();
        
        public frmFormEvent()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "HelloWorld";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void frmFormEvent_Click(object sender, EventArgs e)
        {
            this.Text = "欢迎使用C#";
        }

        private void frmFormEvent_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = St20241031.Properties.Resources.leaf;
        }

        private void frmFormEvent_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("确认要关闭吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                e.Cancel = true;//当选择No的时候取消当前关闭窗体的事件
            }
        }

        private void frmFormEvent_SizeChanged(object sender, EventArgs e)
        {
            //textBox1.Width = this.Width - 100; 
        }

        private void frmFormEvent_DoubleClick(object sender, EventArgs e)
        {
            frmabout.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmlogin.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmlogin.Hide();
        }
    }
}
