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
    public partial class frm99 : Form
    {
        public frm99()
        {
            InitializeComponent();
        }

        private void frm99_Load(object sender, EventArgs e)
        {
            int[,] num = new int[10, 10]; //建立10*10的数组类型
            int i,j;
            label2.Text = "";
            for (i=1; i<=9;i++)//限制列
            {
                for(j=1; j<=i;j++)//限制行
                {
                    
                    num[j, i] = j * i;
                    label2.Text= label2.Text + j + "*" + i + "=" + num[j, i] + "   ";//当乘积大于9之后，后续显示就会出现偏差，对不上
                    if(num[j, i] <= 9)
                    {
                        label2.Text += "  ";
                    }
                    if(i==j)
                    {
                        label2.Text += "\n ";  //注意 += 需要合并在一起 在每行的末尾添加换行符
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
