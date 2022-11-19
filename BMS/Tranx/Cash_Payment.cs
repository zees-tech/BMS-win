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
    public partial class Cash_Payment : Form
    {
        string Callas, type;
        DataTable ds;
        string trans;

        public Cash_Payment(string callas)
        {
            InitializeComponent();
            Callas = callas;
            CheckCallMethod(callas);
        }
        void fillPartycombo(string obj)
        {
            string Database = "abc", t_name = "abc";
            switch (obj)
            {
                case "Company":
                    Database = "CompanyDB";
                    t_name = "Company_T";
                    break;
                case "Supplier":
                    Database = "SupplierDB";
                    t_name = "Supplier_T";
                    break;
                case "Customer":
                    Database = "CustomerDB";
                    t_name = "Customer_T";
                    break;
                case "Servicer":
                    Database = "ServicerDB";
                    t_name = "Servicer_T";
                    break;
                default:
                    break;

            }
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[Database].ConnectionString);
            con.Open();
            string qurry = "Select * from [" + t_name + "] ";
            SqlCommand cmd = new SqlCommand(qurry, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            try
            {
                sda.Fill(data);
                partycmbx.ValueMember = "Id";
                partycmbx.DisplayMember = "Name";
                partycmbx.DataSource = data;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void fill_ds()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            ds = new DataTable();
            string qurry = "select * from [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Payment_T]";
            SqlCommand cmd = new SqlCommand(qurry, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();
        }
        private void NavRec(int i = 0)
        {
            if (ds.Rows.Count > 0)
            {
                Edit();
                receipttxt.Text = ds.Rows[i][0].ToString();
                dateTimePicker1.Text = Convert.ToDateTime(ds.Rows[i][1].ToString()).ToString("dd-MM-yyyy");                
                partycmbx.Text = Calculator.ret_Name(ds.Rows[i][3].ToString(), Constant_And_Variable.CustomerDB);
                receivertxt.Text = ds.Rows[i][5].ToString();

                //dgvDelete();
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
                string qurry = "select * from [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Pay_D_T] where pay_ID_fkey ='" + receipttxt.Text + "'";
                SqlCommand cmd = new SqlCommand(qurry, con);
                con.Open();
                try
                {
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        amttxt.Text = reader.GetDouble(5).ToString();
                    }
                }
                catch (Exception)
                {

                }
                con.Close();
                NoEdit();
                //Calculator.register_selected_data(Constant_And_Variable.Customer_id, ds.Rows[i][3].ToString());
                //Calculator.register_selected_data(Constant_And_Variable.Doc_date, ds.Rows[i][1].ToString());
            }
        }
        private void NoEdit()
        {
            partycmbx.Enabled = false;
            receipttxt.ReadOnly = true;
            amttxt.ReadOnly = true;
            inwordtxt.ReadOnly = true;
            receipttxt.ReadOnly = true;
            dateTimePicker1.Enabled = false;
            //itemcmbx.Enabled = false;
            //descrptxt.ReadOnly = true;
            //hsntxt.ReadOnly = true;
            //ratetxt.ReadOnly = true;
            //qntytxt.ReadOnly = true;
            //delbtn.Enabled = false;
            //itemdtdgv.ReadOnly = true;
            //ewaybilltxt.ReadOnly = true;
            //transportcmb.Enabled = false;
            //transport_chargetxt.ReadOnly = true;
            //packagingtxt.ReadOnly = true;
            //paymenttermtxt.ReadOnly = true;
        }
        private void Edit()
        {
            partycmbx.Enabled = true;
            receipttxt.ReadOnly = false;
            amttxt.ReadOnly = false;
            inwordtxt.ReadOnly = false;
            receipttxt.ReadOnly = false;
            dateTimePicker1.Enabled = true;
            //descrptxt.ReadOnly = false;
            //hsntxt.ReadOnly = false;
            //ratetxt.ReadOnly = false;
            //qntytxt.ReadOnly = false;
            //delbtn.Enabled = true;
            //itemdtdgv.ReadOnly = true;
            //ewaybilltxt.ReadOnly = false;
            //transportcmb.Enabled = true;
            //transport_chargetxt.ReadOnly = false;
            //packagingtxt.ReadOnly = false;
            //paymenttermtxt.ReadOnly = false;
        }
        private void CheckCallMethod(string CallAS)
        {

            if (CallAS == "Supplier")
            {
                //do setting
                Savebtn.Show();
                Discardbtn.Show();
                newbtn.Hide();               
                prntbtn.Hide();
                receipttxt.Text = "#######";
                receipttxt.ReadOnly = true;              
                fillPartycombo(CallAS);                
                partycmbx.Text = "Select Supplier";
                partylbl.Text = "To:";
                
            }

            else if (CallAS == "Servicer")
            {
                //do setting
                Savebtn.Show();
                Discardbtn.Show();
                newbtn.Hide();
                prntbtn.Hide();
                receipttxt.Text = "#######";
                receipttxt.ReadOnly = true;
                fillPartycombo(CallAS);
                partycmbx.Text = "Select Servicer";
                partylbl.Text = "To:";
                
            }

            else if (CallAS == "Customer")
            {
                //do setting
                Savebtn.Show();
                Discardbtn.Show();
                newbtn.Hide();
                prntbtn.Hide();
                receipttxt.Text = "#######";
                receipttxt.ReadOnly = true;
                fillPartycombo(CallAS);
                partycmbx.Text = "Select Customer";
                partylbl.Text = "From:";
                
            }

            else if (CallAS == "Edit")
            {
                //do setting
            }
        }
        bool check_condition()
        {
            bool chk = true;
            try
            {
                if (partycmbx.Text == "Select Party")
                {
                    chk = false;
                    MessageBox.Show("Party Detail is not given");
                }
            }
            catch (Exception)
            {
                chk = false;
                MessageBox.Show("Party Detail is not given");
            }
            if (Convert.ToDouble(amttxt.Text) <= 0)
            {
                chk = false;
                MessageBox.Show("Amount Detail is not given");
            }
            return chk;
        }
        int lastid_no()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            string qurry = "Select Id from [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Payment_T] ";
            SqlCommand cmd = new SqlCommand(qurry, con);
            int id_no = 0;
            try
            {
                SqlDataReader dataDB;
                dataDB = cmd.ExecuteReader();
                while (dataDB.Read())
                {
                    id_no = dataDB.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return id_no;
        }
        private void Save_Click(object sender, EventArgs e)
        {
            if(check_condition())
            {
               string tnx = "abc";
                switch (Callas)
                {
                    case "Company":
                        tnx = "Credit";
                        break;
                    case "Supplier":
                        tnx = "Credit";
                        break;
                    case "Servier":
                        tnx = "Credit";
                        break;
                    case "Customer":
                        tnx = "Debit";
                        break;
                    default:
                        break;
                }
                SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
                string qurry = "insert into [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Payment_T] ( receiver_id_fkey, date_, mode, collector,author_ID_fkey,type ) values('" + partycmbx.SelectedValue.ToString() + "','" + DateTime.Now.ToString("yyyyMMdd") + "','Cash ','" + emplbl.Text + "','" + Callas + "','" + type
                    + "') ";
                SqlCommand cmd1 = new SqlCommand(qurry, con1);
                con1.Open();

                try
                {
                    receipttxt.Text = lastid_no().ToString();
                    cmd1.ExecuteNonQuery();                    
                    Ledger_Process.Ledger_Update("Company_" + Calculator.get_temp_data(Constant_And_Variable.Company_id), "Customer_" + partycmbx.SelectedValue.ToString(),tnx, receipttxt.Text, Convert.ToDouble(amttxt.Text), amttxt.Text + " " + trans + " against " + receipttxt + " on " + dateTimePicker1.Value.Date.ToString("dd-MM-yyyy"));
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                con1.Close();
                SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);

                qurry = "insert into [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Pay_D_T] (pay_ID_fkey, date_, bank, transaction_ID, amt) values('" + receipttxt.Text + "','"+dateTimePicker1.Value.Date.ToString("yyyyMMdd")+"','In Hand','Cash"+receipttxt+"','" +amttxt.Text+ "') ";
                SqlCommand cmd2 = new SqlCommand(qurry, con2);
                con2.Open();
                try
                {
                    cmd2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                con2.Close();
                NoEdit();
                Savebtn.Enabled = false;
                Discardbtn.Enabled = false;
                newbtn.Show();
                prntbtn.Show();
            }
        }

        private void Discard_Click(object sender, EventArgs e)
        {
            partycmbx.Text = "Select "+Callas;
            amttxt.Text = "0";
            inwordtxt.Text = "Select Item";
            receivertxt.Text = "";           
        }

        private void amttxt_TextChanged(object sender, EventArgs e)
        {
            inwordtxt.Text = NumToWord.ConvertNumbertoWords(Convert.ToDouble(amttxt.Text));
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            Edit();
            partycmbx.Text = "Select " + Callas;
            amttxt.Text = "0";
            inwordtxt.Text = "Select Item";
            receivertxt.Text = "";
            newbtn.Hide();
            prntbtn.Hide();
        }
    }
}
