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
    public partial class Cash_Payment : nform 
    {
        
        DataTable ds;
        string trans="";
        Cash_PaymentDT lck = new Cash_PaymentDT();
        public Cash_Payment(Cash_PaymentDT ck)
        {
            InitializeComponent();
            lck = ck;         
            CheckCallMethod(ck.callas);
            fillPartycombo(ck.callby);
        }
        void fillPartycombo(string obj)
        {                 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[Constant.CompanyDB].ConnectionString);
            con.Open();
            string qurry = "Select * from Company_T INNER JOIN Category_T ON Company_T.category = Category_T.Id where Category_T.Name = '" + lck.callby+"'";
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
            string qurry = "select * from [" + lck.tname1 + "]";
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
                receipttxt.Text = ds.Rows[i][TranDB.c_Payment_T.f_receipt].ToString();
                dateTimePicker1.Text = Convert.ToDateTime(ds.Rows[i][TranDB.c_Payment_T.f_date_].ToString()).ToString("dd-MM-yyyy");                
                partycmbx.Text = Call.ret_Name(ds.Rows[i][TranDB.c_Payment_T.f_beneficiary_fkey].ToString(), Constant.CompanyDB);
                receivertxt.Text = ds.Rows[i][TranDB.c_Payment_T.f_collector].ToString();
                referrencetxt.Text= ds.Rows[i][TranDB.c_Payment_T.f_reference].ToString();

                //dgvDelete();
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
                string qurry = "select * from [" + Call.GTD(Constant.Company_id) + "Pay_D_T] where pay_ID_fkey ='" + receipttxt.Text + "'";
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
        }
        private void Edit()
        {
            partycmbx.Enabled = true;
            receipttxt.ReadOnly = false;
            amttxt.ReadOnly = false;
            inwordtxt.ReadOnly = false;
            receipttxt.ReadOnly = false;
            dateTimePicker1.Enabled = true;         
        }
        private void CheckCallMethod(string CallAS)
        {

            if (CallAS == "New")
            {
                //do setting
                Savebtn.Show();
                Discardbtn.Show();
                newbtn.Hide();               
                prntbtn.Hide();
                receipttxt.Text = "#######";
                receipttxt.ReadOnly = true;              
                        
                partycmbx.Text = "Select Party";
                partylbl.Text = "M/s:";
                emplbl.Text = Call.GTD(Constant.User_id);
                
            }

            else if (CallAS == "View")
            {
                //do setting
                Savebtn.Hide();
                Discardbtn.Hide();
                newbtn.Hide();
                prntbtn.Show();
               
                receipttxt.ReadOnly = true;
                partycmbx.Enabled = false;
                amttxt.ReadOnly = true;
                receivertxt.ReadOnly = true;
                partylbl.Text = "M/s:";
                fill_ds();
                NavRec();
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
      
        private void Save_Click(object sender, EventArgs e)
        {
            if(check_condition())
            {
                string tnx, qurry = "SELECT Category_T.sub FROM Company_T INNER JOIN Category_T ON Company_T.category = Category_T.Id WHERE(Company_T.Name = '"+partycmbx.Text+"')";
                tnx = Fall.fill_ds(qurry, Constant.CompanyDB).Rows[0][CompanyDB.c_Category_T.f_sub].ToString();
                lck.InsertPT.Invoke((Convert.ToDouble(Fall.LBI(lck.tname1, TranDB.c_Payment_T.f_receipt))+1).ToString(), dateTimePicker1.Text, partycmbx.Text, lck.mode, receivertxt.Text, receivertxt.Text, emplbl.Text);
                receipttxt.Text = Fall.LBI(lck.tname1, TranDB.c_Payment_T.f_receipt);
                switch (tnx)
                {
                    case "Creditor":
                        tnx = "Credit";
                        trans = " given to ";
                        break;
                    case "Debitor":
                        tnx = "Debit";
                        trans = "recieved by";
                        break;
                    default:
                        break;
                }
                Ledger_Process.Ledger_Update(Call.GTD(Constant.Company_id), Call.ret_id(CompanyDB.c_Company_T.f_Name, partycmbx.Text, Constant.CompanyDB, CompanyDB.t_Company_T), dateTimePicker1.Text, tnx, receipttxt.Text,  "Cash " + trans +  receivertxt.Text,lck.tname1,form_id.cash_payment_fid.ToString());
                lck.InsertPDT.Invoke(receipttxt.Text, dateTimePicker1.Text, "Cash", "null", amttxt.Text);
                NoEdit();
                amttxt.ReadOnly = true;
                receivertxt.ReadOnly = true;
                Savebtn.Enabled = false;
                Discardbtn.Enabled = false;
                newbtn.Show();
                prntbtn.Show();
            }
        }
        private void Discard_Click(object sender, EventArgs e)
        {
            Edit();
            partycmbx.Text = "Select Party";
            amttxt.Text = "0";
            inwordtxt.Text = "Zero";
            receivertxt.Text = "";
            receipttxt.Text = Constant.Hash;
            receipttxt.ReadOnly = true;       
        }
        private void amttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                inwordtxt.Text = NumToWord.ConvertNumbertoWords(Convert.ToDouble(amttxt.Text));
            }
            catch (Exception)
            {
                amttxt.Text = "0";
                inwordtxt.Text = NumToWord.ConvertNumbertoWords(Convert.ToDouble(amttxt.Text));
            }
        }
        private void newbtn_Click(object sender, EventArgs e)
        {
            Edit();
            partycmbx.Text = "Select Party";
            amttxt.Text = "0";
            inwordtxt.Text = "Zero";
            receivertxt.Text = "";
            receipttxt.Text = Constant.Hash;
            newbtn.Hide();
            prntbtn.Hide();
            receipttxt.ReadOnly = true;
            amttxt.ReadOnly = false;
            receivertxt.ReadOnly = false;

            Savebtn.Enabled = true;
            Discardbtn.Enabled = true;
        }
    }
    public class Cash_PaymentDT
    {
        public string callby = "";
        public string callas = "";
        public string mode = "";
        public string tname1;
        public string tname2;
        public TranDB.insert_Payment_T InsertPT;
        public TranDB.insert_Payment_D_T InsertPDT;
    }
}
