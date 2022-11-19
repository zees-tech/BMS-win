using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BMS
{
    public partial class PreMain : nform
    {
        public PreMain(string callas)
        {
            InitializeComponent();
            fillcompanycombo(callas);
            premainlbl.Text = "Select A Company";
            emplbl.Text = Call.GTD(Constant.User_name);
        }

        void fillcompanycombo(string callas)
        {
            string qurry = "Select * from Company_T where " + CompanyDB.c_Company_T.f_category + "='" + Call.ret_id("sub", "main",Constant.CompanyDB,CompanyDB.t_Category_T) + "'";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
            con.Open();
            
            SqlCommand cmd = new SqlCommand(qurry, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dataDB = new DataTable();
            try
            {
                sda.Fill(dataDB);
                companycmbtxt.ValueMember = "Id";
                companycmbtxt.DisplayMember = "Name";
                companycmbtxt.DataSource = dataDB;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            companycmbtxt.Text = "Select Company";
            if (dataDB.Rows.Count==0)
            {
                Company ss = new Company(Constant.AddCompany());
                ss.ShowDialog();
                fillcompanycombo(callas);
            }
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
            con.Open();
            string qurry = "Select * from Company_T";
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            try
            {
                sda.Fill(dt1);
            }
            catch (Exception)
            {
            }
            if (dt1.Rows.Count > 0)
            {
                if (companycmbtxt.Text != "Select Company")
                {
                    qurry = "Select * from Company_T where Id= " + companycmbtxt.SelectedValue.ToString() + "";                /*' and password='" + passwordtxt.Text + "'*/
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
                            Call.RSD(Constant.Company_id, companycmbtxt.SelectedValue.ToString());
                            Call.RSD(Constant.Catrgory, Call.ret_data(Constant.CompanyDB, CompanyDB.t_Company_T, "Id", Call.GTD(Constant.Company_id), CompanyDB.c_Company_T.f_category));
                            this.Hide();
                            Main ss = new Main();
                            ss.Show();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("No Company Selected.");
                }
            }
            else
            {
                MessageBox.Show("NO Comapany has Created.\n Kindly Create to proceed");
            }
            con.Close();
        }
        private void PreMain_Load(object sender, EventArgs e)
        {

        }
        private void clearbtn_Click(object sender, EventArgs e)
        {
            companycmbtxt.ValueMember = "0";
            passwordtxt.Clear();
            //this.Hide();
            //Main ss = new Main();
            //ss.Show();
        }
        
        private void companycmbtxt_DropDown(object sender, EventArgs e)
        {
            companycmbtxt.Text = "Select Company";
        }

        private void companycmbtxt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void viewCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Company ss = new Company(Constant.AddCompany());
            ss.ShowDialog();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Company ss = new Company(Constant.ViewCompany());
            ss.ShowDialog();
        }
    }
}
