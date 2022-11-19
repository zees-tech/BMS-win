using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
namespace BMS
{
    public partial class Login : nform
    {
        public Login()
        {
            //dbo_Process.NewCompanyDB();
            if (!isUser())
            {
                AdUser ss = new AdUser();
                ss.ShowDialog();
            }
            InitializeComponent();
        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
            con.Open();
            string qurry = "Select * from Login_T where LoginID= '"+logintxt.Text+"' and Password='"+pwdtxt.Text+"'";           
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                SqlDataAdapter dataDB = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataDB.Fill(dt);
                if (dt.Rows.Count < 1)
                {
                    MessageBox.Show("Invalid Credential");
                }                
                else if (dt.Rows.Count > 0)
                {
                    if (Fall.IsObj("Temp",Constant.CompanyDB))
                    {
                        qurry = "drop table [Temp]";
                        Fall.SaveDB(qurry, Constant.CompanyDB);
                    }
                    Temp ps = new Temp();
                    dbo_Process.createDB(ps,Constant.CompanyDB,"Temp");
                    Call.RSD(Constant.User_id, logintxt.Text);                    
                    this.Hide();
                    PreMain ss = new PreMain(dt.Rows[0][3].ToString());
                    ss.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();              
        }
        private void clearbtn_Click(object sender, EventArgs e)
        {
            logintxt.Text = "";
            pwdtxt.Text = "";           
        }
        void create_temp()
        {
            SqlConnection contemp = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TempDB"].ConnectionString);
            contemp.Open();
            string qurry = "select * from sys.all_objects where name ='temp'";
            SqlCommand cmd = new SqlCommand(qurry, contemp);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();

            try
            {
                sda.Fill(ds);
            }
            catch (Exception)
            {
                MessageBox.Show("");
            }

            if (ds.Rows.Count > 0)
            {
                qurry = "drop table [Temp]";
                cmd = new SqlCommand(qurry, contemp);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Temp Fail to Generate!");
                }
            }
            qurry = "CREATE TABLE [dbo].[Temp] (    [Id]      INT IDENTITY (1, 1) NOT NULL,    [data_Id] VARCHAR(MAX) DEFAULT((0)) NOT NULL,    [data]    VARCHAR(MAX) DEFAULT((0)) NOT NULL,PRIMARY KEY CLUSTERED ([Id] ASC));";
            cmd = new SqlCommand(qurry, contemp);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Temp Fail to Generate!");
            }
        }

       
    }
}
