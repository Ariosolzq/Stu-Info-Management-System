using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing;
using System.Windows.Forms;

namespace St20241031
{
    public partial class frmStinfo_Access : Form
    {
        static string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Student.accdb;Persist Security Info=False;";
        OleDbConnection myConnection = new OleDbConnection(connString);
        OleDbConnection myConnection1 = new OleDbConnection(connString);
        

        Student[] student = new Student[5];
        int iStNo = 0;
        int ii;
        Boolean blnIsModified = false;

        public frmStinfo_Access()
        {
            InitializeComponent();
        }

        private void InitUserInterfaceBlank()
        {
            txtNo.Text = "";
            txtName.Text = "";
            rbtnFeMale.Checked = true;
            txtAge.Text = "";
            dateTimePicker1.Text = "";
            cobStyle.Text = cobStyle.Items[0].ToString();
            cobSchool.Text = cobSchool.Items[0].ToString();
            cobMajor.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtID.Text = "";
            checkParty.Checked = false;
            txtNote.Text = "";
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

        //以下内容需要注释
        //Student[] student = new Student[6];//创建数组，大小根据保存内容而定
        //int iStNo;//用于数组内部的索引选择赋值
        Boolean txtchanged = false;//内容没有改变，为true关闭时提示是否保存

        public int Save()//定义保存相关信息的方法
        {
            if (iStNo >= 5)//索引重置
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

        private int RecSaveDB()
        {
            if (txtNo.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("学号和姓名不能为空！", "提示", MessageBoxButtons.OK);
                return (1);
            }

            if (txtNo.TextLength != 8 || txtID.TextLength != 18)
            {
                MessageBox.Show("学号或身份证输入错误！", "提示", MessageBoxButtons.OK);
                return (2);
            }
            string strSQL, strGender;
            strSQL = "SELECT StNo, StName, StType, stGender, stSpecialty, stSchool, stEmail, stID, stPhone, stEnrollmentDate, stAge, stIsParty, stMemo"
                + " FROM Tbl_StInfo"
                + " Where StNo='" + txtNo.Text + "'";
            //strSQL = "";
            OleDbCommand cmd = new OleDbCommand(strSQL, myConnection);
            myConnection.Open();
            if (rbtnFeMale.Checked == true)
            {
                strGender = "女";
            }
            else
            {
                strGender = "男";
            }
            if (null == cmd.ExecuteScalar())
            {
                strSQL = "INSERT INTO Tbl_StInfo ( StNo, StName, StType, stGender, stSpecialty, stSchool,"
                           + " stEmail, stID, stPhone, stEnrollmentDate, stAge, stIsParty, stMemo ) Values ('"
                           + txtNo.Text + "', '" + txtName.Text + "', '" + cobStyle.Text + "', '" + strGender + "', '"
                           + cobMajor.Text + "', '" + cobSchool.Text + "', '" + txtEmail.Text + "', '" + txtID.Text + "', '"
                           + txtPhone.Text + "', #" + dateTimePicker1.Text + "#, " + txtAge.Text + ", " + checkParty.Checked + ", '" + txtNote.Text + "'";
            }
            else
            {
                strSQL = "UPDATE Tbl_StInfo SET Tbl_StInfo.StNo = '" + txtNo.Text + "', Tbl_StInfo.StName = '" + txtName.Text
                + "', Tbl_StInfo.StType = '" + cobStyle.Text + "', Tbl_StInfo.stGender = '" + strGender
                + "', Tbl_StInfo.stSpecialty = '" + cobMajor.Text + "', Tbl_StInfo.stSchool = '" + cobSchool.Text
                + "', Tbl_StInfo.stEmail = '" + txtEmail.Text + "', Tbl_StInfo.stID = '" + txtID.Text
                + "', Tbl_StInfo.stPhone = '" + txtPhone.Text + "', Tbl_StInfo.stEnrollmentDate = #" + Convert.ToDateTime(dateTimePicker1.Text)
                + "#, Tbl_StInfo.stAge = " + txtAge.Text + ", Tbl_StInfo.stIsParty = " + checkParty.Checked
                + ", Tbl_StInfo.stMemo = '" + txtNote.Text + "'"
                    + " Where StNo = '" + txtNo.Text + "'";
            }
            cmd = new OleDbCommand(strSQL, myConnection);
            cmd.ExecuteNonQuery();
            myConnection.Close();
            return (-1);
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

            string strSQL;
            strSQL = "SELECT Distinct Tbl_Major.S_School"
                + " FROM Tbl_Major; ";
            myConnection.Open();

            OleDbCommand mycmOleDbCommandd = new OleDbCommand(strSQL, myConnection);
            OleDbDataReader sdr = mycmOleDbCommandd.ExecuteReader();

            cobSchool.Items.Clear();

            while (sdr.Read())
            {
                
                cobSchool.Items.Add(sdr[0]);
            }
            //下拉列表框初值的设置
            cobSchool.Text = cobSchool.Items[0].ToString();
            sdr.Close();

            strSQL = "SELECT Distinct S_Type"
                + " FROM Tbl_StudentType; ";
            OleDbDataAdapter da = new OleDbDataAdapter(strSQL, myConnection);

            DataSet ds = new DataSet();
            da.Fill(ds, "dsTable");

            for (int ii = 0; ii < ds.Tables["dsTable"].Rows.Count; ii++)
            {
                cobStyle.Items.Add(ds.Tables["dsTable"].Rows[ii]["S_Type"].ToString());
            }
            //下拉列表框初值的设置
            cobStyle.Text = cobStyle.Items[0].ToString();

            //读取第一条记录
            //strSQL = "Select * From tbl_StInfo";
            strSQL = "SELECT StNo, StName, StType, stGender, stSpecialty, stSchool, stEmail, stID, stPhone, stEnrollmentDate, stAge, stIsParty, stMemo"
                + " FROM Tbl_StInfo;";

            da = new OleDbDataAdapter(strSQL, myConnection);

            ds = new DataSet();
            da.Fill(ds, "dsTable");

            txtNo.Text = ds.Tables["dsTable"].Rows[0]["StNo"].ToString();
            txtName.Text = ds.Tables["dsTable"].Rows[0]["StName"].ToString();
            cobStyle.Text = ds.Tables["dsTable"].Rows[0]["StType"].ToString();
            if (ds.Tables["dsTable"].Rows[0]["stGender"].ToString() == "男")
            { rbtnMale.Checked = true; }
            else
            { rbtnFeMale.Checked = true; }
            txtAge.Text = (ds.Tables["dsTable"].Rows[0]["stAge"].ToString());

            myConnection.Close();

            blnIsModified = false;
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

        

        private void btnDel_Click(object sender, EventArgs e)
        {
            string strSQL;
            DialogResult result;

            if (txtNo.Text == "")
            {
                MessageBox.Show("请先输入要删除学生的学号！", "提示", MessageBoxButtons.OK);
                txtNo.Focus();
                return;
            }
            else
            {
                result = MessageBox.Show("确认要删除该学生的信息？", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;
            }

            myConnection.Open();
            strSQL = "SELECT StNo, StName, StType, stGender, stSpecialty, stSchool, stEmail,"
                + " stID, stPhone, stEnrollmentDate, stAge, stIsParty, stMemo"
                + " FROM Tbl_StInfo"
                + " Where StNo = '" + txtNo.Text + "'";

            //DataAdapter对象提供DataSet对象与数据源之间的连接。
            OleDbDataAdapter da = new OleDbDataAdapter(strSQL, myConnection);
            //创建数据集DataSet，用于存放数据的本地副本
            DataSet ds = new DataSet();
            da.Fill(ds, "dsTable");     //Fill方法填充数据集
            if (ds.Tables["dsTable"].Rows.Count > 0)
            {
                //InitUserInterface2(false, ds.Tables["dsTable"].Rows[0]);
                strSQL = "DELETE FROM Tbl_StInfo"
                    + " Where StNo = '" + txtNo.Text + "'";
                OleDbCommand cmd = new OleDbCommand(strSQL, myConnection);
                cmd.ExecuteNonQuery();
                //删除成功
            }
            else
            {
                //InitUserInterface2(true, ds.Tables["dsTable"].NewRow());
                MessageBox.Show("没有找到满足条件的记录！", "提示", MessageBoxButtons.OK);
            }
            myConnection.Close();//关闭连接  

            InitUserInterfaceBlank();//情况
        }

    }
}
