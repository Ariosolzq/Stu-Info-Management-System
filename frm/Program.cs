using St20241031;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;//�ڳ��������������̨Install-Package System.Data.OleDb
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
        //�������ݿ������ַ���
        //Access 2003��
        //public const string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "ѧ����Ϣ.mdb" + ";Persist Security Info=False";

        //Access 2007���ϰ�
        public const string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ѧ����Ϣ.accdb;Persist Security Info=False;";

        OleDbConnection myConnection = new OleDbConnection(DbConnection.connString);

        //public OleDbConnection myConnection = new OleDbConnection(connString);
        //OleDbConnection myConnection = new OleDbConnection(connString);

        /// <summary>
        /// ��ʼ�������б�򡪡�ʹ�������ӱ��ֵķ�ʽ�������ݿ�
        /// </summary>
        /// <param name="strSQL">������ԴSQL</param>
        /// <param name="cboInit">��Ҫ��ʼ���������б��</param>
        /// <returns>1�����ɹ���0����ʧ��</returns>
        public int InitCombo(string strSQL, ComboBox cboInit)
        {
            // �����ݿ���ж�ȡѧ��������ݣ���ʼ�������б��
            //strSQL = "SELECT ID, S_Type FROM Tbl_StudentType Order by ID;";

            cboInit.Items.Clear();
            try
            {
                myConnection.Open();        //������  
                OleDbCommand mycmd = new OleDbCommand(strSQL, myConnection);    //�½�SqlCommand����  
                //ExecuteReader������ CommandText ���͵� Connection ������һ�� OleDbDataReader  
                OleDbDataReader sdr = mycmd.ExecuteReader();
                //*
                while (sdr.Read())
                {
                    //ѭ����ȡ����  
                    cboInit.Items.Add(sdr[1]);
                    //cboStType
                }
                // */

                sdr.Close();//��ȡ��ϼ��ر�OleDbDataReader  
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
                myConnection.Close();//�ر�����  
            }

            return (1);
        }

        /// <summary>
        /// ��ʼ�������б�򡪡�ʹ�������ӱ��ֵķ�ʽ�������ݿ�
        /// </summary>
        /// <param name="strSQL">������ԴSQL</param>
        /// <param name="cboInit">��Ҫ��ʼ���������б��</param>
        /// <returns>1�����ɹ���0����ʧ��</returns>
        public int InitComboDataSet(string strSQL, ComboBox cboInit, string sFieldName)
        {
            // �����ݿ���ж�ȡѧ��������ݣ���ʼ�������б��
            //strSQL = "SELECT ID, S_Type FROM Tbl_StudentType Order by ID;";

            cboInit.Items.Clear();

            try
            {
                myConnection.Open();        //������  
                //DataAdapter�����ṩDataSet����������Դ֮������ӡ�
                OleDbDataAdapter da = new OleDbDataAdapter(strSQL, myConnection);
                //�������ݼ�DataSet�����ڴ�����ݵı��ظ���
                DataSet ds = new DataSet();
                da.Fill(ds, "dsTable");     //Fill����������ݼ�
                //����DataSet���ݼ�
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
                myConnection.Close();//�ر�����  
            }

            return (1);
        }

    }
}