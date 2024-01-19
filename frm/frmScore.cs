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
    public partial class frmScore : Form
    {
        double score;
        string ? resault = null; //设置为可以返回空值 ，此为定义转换成绩为优良中等的方法
        
        public frmScore()
        {
            InitializeComponent();
        }

        public string Scorechange(double score)  //定义成绩转换方法
        {
            if (score >= 90)
            {
                resault = "优";
            }
            else if (score >= 80 && score < 90)
            {
                resault = "良";
            }
            else if (score >= 70 && score < 80)
            {
                resault = "中";
            }
            else if (score >= 60 && score < 70)
            {
                resault = "及格";
            }
            else if (score < 60)
            {
                resault = "不及格";
            }
            else
                MessageBox.Show("成绩输入错误，请重新输入");
            return resault;
        }


        private void textBox3_leave(object sender, EventArgs e)  //光标离开时输出成绩等级
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                textBox3.Text = "";
                MessageBox.Show("请输入相关成绩");
            }
            else
            {
                score = (4.0 / 10 * Convert.ToDouble(textBox1.Text) + 6.0 / 10 * Convert.ToDouble(textBox2.Text));
                textBox3.Text = this.Scorechange(score);       //调用方法
            }
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                textBox3.Text = "";
                MessageBox.Show("请输入平时成绩");
            }
            /*else
            {
                textBox3.Text = (Convert.ToInt32(textBox1.Text) * Convert.ToInt32(textBox2.Text)).ToString();
                textBox3.Text = (4.0 / 10 * Convert.ToDouble(textBox1.Text) + 6.0 / 10 * Convert.ToDouble(textBox2.Text)).ToString();
            }*/
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox3.Text = "";
                MessageBox.Show("请输入考试成绩");
            }
            /*else                 为不调用方法时，成绩改变后即输出成绩
            {
                textBox3.Text = (Convert.ToInt32(textBox1.Text) * Convert.ToInt32(textBox2.Text)).ToString();
                score = ((4.0 / 10 * Convert.ToDouble(textBox1.Text) + 6.0 / 10 * Convert.ToDouble(textBox2.Text)));
                if (score >= 90)
                {
                    textBox3.Text = "优";
                }
                else if (score >= 80 && score < 90)
                {
                    textBox3.Text = "良";
                }
                else if (score >= 70 && score < 80)
                {
                    textBox3.Text = "中";
                }
                else if (score >= 60 && score < 70)
                {
                    textBox3.Text = "及格";
                }
                else if (score < 60)
                {
                    textBox3.Text = "不及格";
                }
                else
                    MessageBox.Show("成绩输入错误，请重新输入");
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
