using St20241031;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;//在程序包管理器控制台Install-Package System.Data.OleDb
using System.Windows.Forms;

namespace WinFormsApp2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new frmLogin());
            //Application.Run(new frmScore());
            //Application.Run(new frm99());
            //Application.Run(new frmAbout());
            //Application.Run(new frmFormEvent());
            Application.Run(new frmStinfo_Access());
            //Application.Run(new MDI());
        }
    }

    public class DbConnection
    {
        //定义数据库连接字符串
        //Access 2003版
        //public const string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "学生信息.mdb" + ";Persist Security Info=False";

        //Access 2007以上版
        public const string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=学生信息.accdb;Persist Security Info=False;";

        OleDbConnection myConnection = new OleDbConnection(DbConnection.connString);

        //public OleDbConnection myConnection = new OleDbConnection(connString);
        //OleDbConnection myConnection = new OleDbConnection(connString);

        /// <summary>
        /// 初始化下拉列表框——使用有连接保持的方式访问数据库
        /// </summary>
        /// <param name="strSQL">数据来源SQL</param>
        /// <param name="cboInit">需要初始化的下拉列表框</param>
        /// <returns>1——成功；0——失败</returns>
        public int InitCombo(string strSQL, ComboBox cboInit)
        {
            // 从数据库表中读取学生类别数据，初始化下拉列表框
            //strSQL = "SELECT ID, S_Type FROM Tbl_StudentType Order by ID;";

            cboInit.Items.Clear();
            try
            {
                myConnection.Open();        //打开连接  
                OleDbCommand mycmd = new OleDbCommand(strSQL, myConnection);    //新建SqlCommand对象  
                //ExecuteReader方法将 CommandText 发送到 Connection 并生成一个 OleDbDataReader  
                OleDbDataReader sdr = mycmd.ExecuteReader();
                //*
                while (sdr.Read())
                {
                    //循环读取数据  
                    cboInit.Items.Add(sdr[1]);
                    //cboStType
                }
                // */

                sdr.Close();//读取完毕即关闭OleDbDataReader  
            }

            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
                return (0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return (0);
            }
            finally
            {
                myConnection.Close();//关闭连接  
            }

            return (1);
        }

        /// <summary>
        /// 初始化下拉列表框——使用无连接保持的方式访问数据库
        /// </summary>
        /// <param name="strSQL">数据来源SQL</param>
        /// <param name="cboInit">需要初始化的下拉列表框</param>
        /// <returns>1——成功；0——失败</returns>
        public int InitComboDataSet(string strSQL, ComboBox cboInit, string sFieldName)
        {
            // 从数据库表中读取学生类别数据，初始化下拉列表框
            //strSQL = "SELECT ID, S_Type FROM Tbl_StudentType Order by ID;";

            cboInit.Items.Clear();

            try
            {
                myConnection.Open();        //打开连接  
                //DataAdapter对象提供DataSet对象与数据源之间的连接。
                OleDbDataAdapter da = new OleDbDataAdapter(strSQL, myConnection);
                //创建数据集DataSet，用于存放数据的本地副本
                DataSet ds = new DataSet();
                da.Fill(ds, "dsTable");     //Fill方法填充数据集
                //遍历DataSet数据集
                for (int ii = 0; ii < ds.Tables["dsTable"].Rows.Count; ii++)
                {
                    cboInit.Items.Add(ds.Tables["dsTable"].Rows[ii][sFieldName].ToString());
                }
            }

            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
                return (0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return (0);
            }
            finally
            {
                myConnection.Close();//关闭连接  
            }

            return (1);
        }

    }
}