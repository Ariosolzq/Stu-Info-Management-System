using System.Data;

namespace St20241031
{
    public partial class frmStinfo : Form
    {
        public frmStinfo()
        {
            InitializeComponent();
        }

        public struct Student  //定义一个结构体存储数据，值类型，注意位置
        {
            public string stNo;
            public string stName;
            public string stGender;
            public int stAge;
            public DateTime stDate;
            public string stStyle;
            public string stSchool;
            public string stMajor;
            public string stEmail;
            public string stPhone;
            public string stID;
            public bool stIsParty;
            public string stMemo;
        }

        Student[] student = new Student[6];//创建数组，大小根据保存内容而定
        int iStNo;//用于数组内部的索引选择赋值
        Boolean txtchanged = false;//内容没有改变，为true关闭时提示是否保存

        public int Save()//定义保存相关信息的方法
        {
            if (iStNo >= 5)//索引充值
            {
                iStNo = 0;
            }

            if (txtNo.Text == "" || txtNo.TextLength != 8)//学号不为空，等于8位
            {
                MessageBox.Show("请重新输入学号");
                txtNo.Text = "";
                return (0);
            }
            student[iStNo].stNo = txtNo.Text;

            if (txtNo.Name == "")//姓名不为空
            {
                MessageBox.Show("请重新输入姓名");
                txtName.Text = "";
                return (0);
            }
            student[iStNo].stName = txtName.Text;

            if (txtID.Text == "" || txtID.TextLength != 8)//身份证号不为空，等于18位
            {
                MessageBox.Show("请重新输入身份证号码");
                txtID.Text = "";
                return (0);
            }
            student[iStNo].stID = txtID.Text;

            if (txtAge.Text == "")
            {
                MessageBox.Show("请重新输入年龄");
                txtAge.Text = "";
                return (0);
            }
            else
            {
                student[iStNo].stAge = Convert.ToInt32(txtAge.Text); //注意转化位整型
            }

            if (rbtnMale.Checked == true)
            {
                student[iStNo].stGender = "Male";//男性
            }
            else
            {
                student[iStNo].stGender = "Female";
            }

            student[iStNo].stDate = Convert.ToDateTime(dateTimePicker1.Text);//入学时间转化！不是整型

            iStNo++;//对保存的索引进行增加！！！

            txtchanged = false;//内容没有改变，关闭时提示是否保存

            return (1);
        }


        private void frmStinfo_Load(object sender, EventArgs e)//进行学院和学生类别的初始化
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            string[] stStyle = new string[4]        //注意这里不能加分号，下拉列表内容初始化
            { "本科生","研究生","博士","博士后" };
            string[] stSchool = new string[5]
            { "经管学院","电气学院","计算机学院","法学院","交通运输学院",};
            //string[] stMajor =  new string[3] ，因为学院与专业的联动，所有先不在这里定义
            cobStyle.Items.Clear();
            cobSchool.Items.Clear();//清空
            cobMajor.Items.Clear();

            //对选择项进行添加，即为初始化。也可以在属性Items中填入
            for (int j = 0; j < stStyle.Length; j++)
            {
                cobStyle.Items.Add(stStyle[j]);
            }

            for (int j = 0; j < stSchool.Length; j++)
            {
                cobSchool.Items.Add(stSchool[j]);
            }

            cobStyle.Text = cobStyle.Items[0].ToString();//这里设置初值，注意要转换为字符串型

            cobSchool.Text = cobSchool.Items[0].ToString();//设置为第一个学院

            txtchanged = false;//内容没有改变
        }


        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')   //注意将删除键backspace计入
            {
                if (e.KeyChar >= '0' && e.KeyChar <= '9') { } //补充{}，不进行操作
                else
                {
                    e.Handled = true;//事件已经处理
                }
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "图像文件(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG; *.GIF|所有文件(*.*)|*.*";
            saveFileDialog1.ShowDialog();
        }




        private void cobSchool_SelectedIndexChanged(object sender, EventArgs e)//注意不是Value值改变的事件
        {
            string[,] stMajor = new string[6, 6];
            stMajor[0, 0] = "信息管理与信息系统";
            stMajor[0, 1] = "经济学";
            stMajor[1, 0] = "电子机械";
            stMajor[1, 1] = "机械工程";
            stMajor[2, 0] = "计算机科学与技术";
            stMajor[3, 0] = "劳动法";
            stMajor[4, 0] = "交通工程";

            cobMajor.Items.Clear();//注意这里要对原始的数据进行清理

            switch (cobSchool.Text)
            {
                case "经管学院":
                    for (int i = 0; i <= 1; i++)//i<=1，两个专业
                    {
                        cobMajor.Items.Add(stMajor[0, i]);
                    }
                    break;
                case "电气学院":
                    for (int i = 0; i <= 0; i++)
                    {
                        cobMajor.Items.Add(stMajor[1, i]);
                    }
                    break;
                case "计算机学院":
                    for (int i = 0; i <= 0; i++)
                    {
                        cobMajor.Items.Add(stMajor[2, i]);
                    }
                    break;

                case "法学院":
                    for (int i = 0; i <= 0; i++)
                    {
                        cobMajor.Items.Add(stMajor[3, i]);
                    }
                    break;
                case "交通运输学院":
                    for (int i = 0; i <= 0; i++)
                    {
                        cobMajor.Items.Add(stMajor[4, i]);
                    }
                    break;

            }
            cobMajor.Text = cobMajor.Items[0].ToString();//这里设置初值，注意要转换为字符串型,同load
        }

        private void btnSave_Click(object sender, EventArgs e)//对学号、姓名、身份证号码的完整性和正确性认证在Save方法中，根据返回值确定结果
        {
            if (Save() == 1)
            {
                MessageBox.Show("保存成功");
            }
            else return;//不成功
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Save() == 1)
            {
                MessageBox.Show("添加成功");
            }
            else
            {
                txtNo.Text = "";
                txtName.Text = "";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNo_TextChanged(object sender, EventArgs e)
        {
            txtchanged = false;//内容没有改变，关闭时提示是否保存
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtchanged = false;//内容没有改变，关闭时提示是否保存
        }

        private void cobStyle_TextChanged(object sender, EventArgs e)
        {
            txtchanged = false;//内容没有改变，关闭时提示是否保存
        }

        private void cobSchool_TabIndexChanged(object sender, EventArgs e)
        {
            txtchanged = false;//内容没有改变，关闭时提示是否保存
        }

        private void frmStinfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtchanged == true)
            {
                DialogResult result = MessageBox.Show("内容未保存，您要关闭吗？", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; //取消事件
                }
                //不能else，死循环了
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "图像文件(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG; *.GIF|所有文件(*.*)|*.*";
            openFileDialog1.ShowDialog();
        }

        private void SAVEtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "图像文件(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG; *.GIF|所有文件(*.*)|*.*";
            saveFileDialog1.ShowDialog();
        }

        private void CLOSEtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
