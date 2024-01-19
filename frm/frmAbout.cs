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
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            this.StartPosition = FormStartPosition.CenterScreen;//居中显示
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            //this.BackgroundImage = St20241031.Properties.Resources.books;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAbout_SizeChanged(object sender, EventArgs e)//拓展练习，调整照片的位置
        {
            pictureBox1.Left = this.Width - 100;
            pictureBox1.Top = this.Height - 100;
            
        }
    }
}
