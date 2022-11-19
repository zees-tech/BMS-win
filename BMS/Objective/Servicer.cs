using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bms1
{
    public partial class Servicer : Form
    {
        private string CallAS;
        DataTable ds = new DataTable();
        int pos = 0;
        public Servicer(string callAS)
        {
            InitializeComponent();
            CallAS = callAS;
            CheckCallMethod();
        }
        private bool check_condition()
        {
            bool chk = true;
            if (nametxt.Text == "")
            {
                MessageBox.Show("Company Name is mandatory");
                chk = false;
            }
            if (addresstxt.Text == "")
            {
                MessageBox.Show(" is mandatory");
                chk = false;
            }
            if (citytxt.Text == "")
            {
                MessageBox.Show(" is mandatory");
                chk = false;
            }
            if (districttxt.Text == "")
            {
                MessageBox.Show(" is mandatory");
                chk = false;
            }
            if (statecmb.Text == "")
            {
                MessageBox.Show(" is mandatory");
                chk = false;
            }
            if (pincodetxt.Text == "")
            {
                MessageBox.Show(" is mandatory");
                chk = false;
            }
            return chk;
        }
        private void CheckCallMethod()
        {
            if (CallAS == "New")
            {
                //do setting
                Savebtn.Show();
                Discardbtn.Show();
                newbtn.Hide();
                Adrepresenterbtn.Hide();
                nextbtn.Hide();
                previousbtn.Hide();
            }
            else if (CallAS == "View")
            {
                //do setting
                Savebtn.Hide();
                Discardbtn.Hide();
                newbtn.Hide();
                Adrepresenterbtn.Hide();
                nextbtn.Show();
                previousbtn.Show();
                islocalrbtn.Hide();
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SupplierDB"].ConnectionString);
                con.Open();
                string qurry = "select * from Supplier_T";
                SqlDataAdapter dta = new SqlDataAdapter(qurry, con);
                dta.Fill(ds);
                NavRec();
            }
            else if (CallAS == "Edit")
            {
                //do setting
            }
        }

        private void NoEdit()
        {
            nametxt.ReadOnly = true;
            aliastxt.ReadOnly = true;
            addresstxt.ReadOnly = true;
            citytxt.ReadOnly = true;
            districttxt.ReadOnly = true;
            statecmb.Enabled = false;
            pincodetxt.ReadOnly = true;
            gstintxt.ReadOnly = true;
        }

        private void Edit()
        {
            nametxt.ReadOnly = false;
            aliastxt.ReadOnly = false;
            addresstxt.ReadOnly = false;
            citytxt.ReadOnly = false;
            districttxt.ReadOnly = false;
            statecmb.Enabled = true;
            pincodetxt.ReadOnly = false;
            gstintxt.ReadOnly = false;
        }

        int lastid_no()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SupplierDB"].ConnectionString);
            con.Open();
            string qurry = "Select Id from Supplier_T";
            SqlCommand cmd = new SqlCommand(qurry, con);
            int invo_no = 0;
            try
            {
                SqlDataReader dataDB;
                dataDB = cmd.ExecuteReader();
                while (dataDB.Read())
                {
                    invo_no = dataDB.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return invo_no;
        }
        private void islocalrbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (islocalrbtn.Checked)
            {
                citytxt.Text = Calculator.ret_City(Calculator.get_temp_data(Constant_And_Variable.Company_id), Constant_And_Variable.CompanyDB);
                districttxt.Text = Calculator.ret_Distric(Calculator.get_temp_data(Constant_And_Variable.Company_id), Constant_And_Variable.CompanyDB);
                statecmb.Text = Calculator.ret_State(Calculator.get_temp_data(Constant_And_Variable.Company_id), Constant_And_Variable.CompanyDB);
                citytxt.ReadOnly = true;
                districttxt.ReadOnly = true;
                statecmb.Enabled = false;
            }
            else
            {
                citytxt.ReadOnly = false;
                districttxt.ReadOnly = false;
                statecmb.Enabled = true;
            }
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            Edit();
            Savebtn.Enabled = true;
            Discardbtn.Enabled = true;
            newbtn.Visible = false;
            nametxt.Clear();
            aliastxt.Clear();
            addresstxt.Clear();
            citytxt.Clear();
            districttxt.Clear();
            statecmb.Text = "";
            pincodetxt.Clear();
            gstintxt.Clear();
        }

        private void Discardbtn_Click(object sender, EventArgs e)
        {
            nametxt.Clear();
            aliastxt.Clear();
            addresstxt.Clear();
            citytxt.Clear();
            districttxt.Clear();
            statecmb.Text = "";
            pincodetxt.Clear();
            gstintxt.Clear();
        }
        private void NavRec(int i = 0)
        {

            Edit();
            nametxt.Text = ds.Rows[i][1].ToString();
            aliastxt.Text = ds.Rows[i][2].ToString();
            gstintxt.Text = ds.Rows[i][3].ToString();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SupplierDB"].ConnectionString);
            con.Open();
            string qurry = "select * from Adres_T where addri_id_fkey ='" + ds.Rows[i][0] + "'";
            SqlCommand sda = new SqlCommand(qurry, con);

            try
            {
                SqlDataReader reader = sda.ExecuteReader();
                while (reader.Read())
                {
                    addresstxt.Text = reader.GetString(2);
                    citytxt.Text = reader.GetString(3);
                    districttxt.Text = reader.GetString(4);
                    statecmb.Text = reader.GetString(5);
                    pincodetxt.Text = reader.GetString(6);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            NoEdit();
        }
        private void nextbtn_Click(object sender, EventArgs e)
        {
            pos = pos + 1;
            if (pos < ds.Rows.Count)
            {
                NavRec(pos);
            }
            else
            {
                pos = ds.Rows.Count - 1;
            }
        }

        private void previousbtn_Click(object sender, EventArgs e)
        {
            pos = pos - 1;
            if (pos >= 0)
            {
                NavRec(pos);
            }
            else
            {
                pos = 0;
            }
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (check_condition())
            {
                Savebtn.Enabled = false;
                Discardbtn.Enabled = false;
                newbtn.Visible = true;
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ServicerDB"].ConnectionString);
                con.Open();
                string qurry = "insert into Servicer_T (Name, Alias, GSTIN,author_ID_fkey) values('" + nametxt.Text + "','" + aliastxt.Text + "','" + gstintxt.Text + "','" + Calculator.get_temp_data(Constant_And_Variable.Logger_id) + "')";
                SqlCommand cmd = new SqlCommand(qurry, con);
                try
                {
                    cmd.ExecuteNonQuery();
                    Ledger_Process.New_Ledger("Servicer_" + lastid_no());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                string qurry1 = "insert into Adres_T (addri_id_fkey, Address, City, District, State, Pincode) values('" + lastid_no().ToString() + "','" + addresstxt.Text + "','" + citytxt.Text + "','" + districttxt.Text + "','" + statecmb.Text + "','" + pincodetxt.Text + "')";
                SqlCommand cmd1 = new SqlCommand(qurry1, con);
                try
                {
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                NoEdit();
            }
        }
    }
}
