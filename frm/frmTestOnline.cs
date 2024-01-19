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
    public partial class frmTestOnline : Form
    {
        public frmTestOnline()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "1.窗体的显示方法正确的是：A.Frm.Show()  B.Frm.Open()";
            timer1.Enabled = true;
            for (int i = 120; i >=0; i--)
            {
                textBox4.Text = "i";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
