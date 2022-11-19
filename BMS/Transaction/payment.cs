using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{
    public partial class payment : nform 
    {       
        DataTable ds;
        string trans;
        paymentDT lck = new paymentDT();
        public payment(paymentDT ck)
        {
            lck = ck;
            lck.callby = ck.callby;
            lck.callas = ck.callas; ;
            InitializeComponent();
            CheckCallMethod(ck.callas);
            fillPartycombo(ck.callby);
           

        }
        void fillPartycombo(string obj)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[Constant.CompanyDB].ConnectionString);
            con.Open();
            string qurry = "Select * from Company_T INNER JOIN Category_T ON Company_T.category = Category_T.Id where Category_T.Name = '" + lck.callby + "'";
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
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[Constant.TransDB].ConnectionString);
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
                receipttxt.Text = ds.Rows[i][0].ToString();
                datetxt.Text = Convert.ToDateTime(ds.Rows[i][1].ToString()).ToString("dd-MM-yyyy");
                //comlbl.Text = Calculator.ret_Name(Calculator.GTD(Constant_And_Variable.Company_id), Constant_And_Variable.CompanyDB);
                partycmbx.Text = Call.ret_Name(ds.Rows[i][3].ToString(), Constant.CompanyDB);                
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
                        string sdate = reader.GetDateTime(2).ToString("dd-MM-yyyy");
                        string sbank = reader.GetString(3);
                        string strans_id = reader.GetString(4);
                        string samt = reader.GetDouble(5).ToString();
                        dgvcheque.AllowUserToAddRows = true;
                        dgvcheque.Rows.Add(sdate,sbank,strans_id,samt);
                        dgvcheque.AllowUserToAddRows = false;
                        cal(dgvcheque.Rows.Count - 1, 1);
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
        private void cal(int index, int sign)
        {
            Edit();
            try
            {
                amttxt.Text = (Convert.ToDouble(amttxt.Text) + sign * Convert.ToDouble(dgvcheque.Rows[index].Cells[3].Value)).ToString();
                inwordtxt.Text = NumToWord.ConvertNumbertoWords(Convert.ToDouble(amttxt.Text));
            }
            catch (Exception)
            {
                
            }
            NoEdit();
        }
        private void NoEdit()
        {           
            receipttxt.ReadOnly = true;
            amttxt.ReadOnly = true;
            inwordtxt.ReadOnly = true;
            receipttxt.ReadOnly = true;
            datetxt.ReadOnly = true;
           
        }
        private void Edit()
        {           
            receipttxt.ReadOnly = false;
            amttxt.ReadOnly = false;
            inwordtxt.ReadOnly = false;
            receipttxt.ReadOnly = false;
            datetxt.ReadOnly = true;                        
        }
        private void CheckCallMethod(string Callas)
        {

            if (Callas == "New")
            {
                //do setting
                Savebtn.Show();
                Discardbtn.Show();
                newbtn.Hide();
                prntbtn.Hide();

                receipttxt.Text = "#######";
                receipttxt.ReadOnly = true;
                datetxt.Text = DateTime.Now.ToString("dd-MM-yyyy");
                datetxt.ReadOnly = true;              
                partycmbx.Text = "Select Party";
                partylbl.Text = "M/s:";
                emplbl.Text = Call.GTD(Constant.User_id);
                if (lck.mode== "A/c_Transfer")
                {
                    dgvcheque.Hide();
                    addbtn.Hide();
                    deletebtn.Hide();
                }

            }
            else if (Callas == "View")
            {
                //do setting
                Savebtn.Hide();
                Discardbtn.Hide();
                newbtn.Hide();
                prntbtn.Hide();
               
                receipttxt.ReadOnly = true;                
                datetxt.ReadOnly = true;                
                partylbl.Text = "M/s:";

                fill_ds();
                NavRec();
            }


            else if (Callas == "Edit")
            {
                //do setting
            }

            if (lck.mode =="Cheque")
            {
                dgvcheque.Visible = true;
                addbtn.Visible = true;
                deletebtn.Visible = true;
                transIDlbl.Text = "Cheque No.";
            }
            else if (lck.mode == "A/c_Transfer")
            {
                dgvcheque.Visible = false;
                addbtn.Visible = false;
                deletebtn.Visible = false;
                transIDlbl.Text = "Transction ID";
            }
            amttxt.Text = "0";
            inwordtxt.Text = "Zero";
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
        private void transamttxt_TextChanged(object sender, EventArgs e)
        {
            if (NumToWord.IsNumber(transamttxt.Text))
            {
                if (lck.mode == "A/c_Transfer")
                {
                    amttxt.Text = transamttxt.Text;
                    inwordtxt.Text = NumToWord.ConvertNumbertoWords(Convert.ToDouble(amttxt.Text));
                }
            }            
        }
        private void addbtn_Click(object sender, EventArgs e)
        {            
            try
            {
                if (Convert.ToDouble(transamttxt.Text)>0)
                {                    
                    dgvcheque.ReadOnly = false;
                    dgvcheque.Rows.Add(Convert.ToDateTime(trans_date.Text).ToString("dd-MM-yyyy"), banktxt.Text, transidtxt.Text, transamttxt.Text);
                    dgvcheque.ReadOnly = true;
                    deletebtn.Enabled = true;
                    cal(dgvcheque.Rows.Count - 1, 1);
                }
                else
                {
                    transamttxt.Text = "0";
                    MessageBox.Show("Amount Can Not Be Zero");
                }
            }
            catch (Exception)
            {
                transamttxt.Text = "0";
                MessageBox.Show("Amount Can Not Be Zero");               
            }            
        }
        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                cal(dgvcheque.SelectedRows[0].Index, -1);
                dgvcheque.Rows.RemoveAt(dgvcheque.SelectedRows[0].Index);                
                if (dgvcheque.Rows.Count<1)
                {                    
                    deletebtn.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (check_condition())
            {
                receipttxt.Text = (Convert.ToDouble(Fall.LBI(lck.tname1, TranDB.c_Payment_T.f_receipt)) + 1).ToString();
                string datel = DateTime.Today.ToString();
                if (lck.mode == "A/c_Transfer")
                {
                    datel = trans_date.Text;
                    lck.InsertPT.Invoke(receipttxt.Text, datel, Call.ret_id(CompanyDB.c_Company_T.f_Name, partycmbx.Text, Constant.CompanyDB, CompanyDB.t_Company_T), lck.mode, banktxt.Text, referencetxt.Text, emplbl.Text);
                    lck.InsertPDT.Invoke(receipttxt.Text,datel ,banktxt.Text,transamttxt.Text,amttxt.Text);
                }
                else
                {
                    lck.InsertPT.Invoke(receipttxt.Text, datel, Call.ret_id(CompanyDB.c_Company_T.f_Name, partycmbx.Text, Constant.CompanyDB, CompanyDB.t_Company_T), lck.mode, banktxt.Text, referencetxt.Text, emplbl.Text);
                    int n = 0;
                    while (n < dgvcheque.Rows.Count)
                    {
                        lck.InsertPDT.Invoke(receipttxt.Text, dgvcheque.Rows[n].Cells[0].Value.ToString(), dgvcheque.Rows[n].Cells[1].Value.ToString(), dgvcheque.Rows[n].Cells[2].Value.ToString(), dgvcheque.Rows[n].Cells[3].Value.ToString());
                        n++;
                    }
                }
                
                string tnx, qurry = "SELECT Category_T.sub FROM Company_T INNER JOIN Category_T ON Company_T.category = Category_T.Id WHERE(Company_T.Name = '" + partycmbx.Text + "')";
                tnx = Fall.fill_ds(qurry, Constant.CompanyDB).Rows[0][CompanyDB.c_Category_T.f_sub].ToString();
                switch (tnx)
                {
                    case "Creditor":
                        tnx = "Credit";
                        trans = " given to ";
                        break;
                    case "Debitor":
                        tnx = "Debit";
                        trans = "recieved by ";
                        break;
                    default:
                        break;
                }
                Ledger_Process.Ledger_Update(Call.GTD(Constant.Company_id), partycmbx.SelectedValue.ToString(), datel, tnx, receipttxt.Text, lck.mode + " " + trans + " issued on ",lck.tname1,form_id.payment_fid.ToString());
              
              
                NoEdit();
              
                transamttxt.Enabled = false;
                transidtxt.Enabled = false;
                banktxt.Enabled = false;
                trans_date.Enabled = false;
                partycmbx.Enabled = false;
                addbtn.Enabled = false;
                deletebtn.Enabled = false;

                Savebtn.Enabled = false;
                Discardbtn.Enabled = false;
                newbtn.Visible = true;
                prntbtn.Visible = true;
            }
        }
        private void Discardbtn_Click(object sender, EventArgs e)
        {
            partycmbx.Text = "";
            //trans_date.Value
            receipttxt.Text = "#######";
            banktxt.Text = "";
            transidtxt.Text = "";
            transamttxt.Text = "";
            amttxt.Text = "0";
            inwordtxt.Text = "";
            while (dgvcheque.Rows.Count > 0)
            {
                cal(0, -1);
                dgvcheque.Rows.RemoveAt(0);
            }
        }
        private void newbtn_Click(object sender, EventArgs e)
        {
            Edit();
            partycmbx.Enabled = true;
            partycmbx.Text = "";
            //trans_date.Value
            receipttxt.Text = "#######";
            banktxt.Text = "";
            transidtxt.Text = "";
            transamttxt.Text = "";
            referencetxt.Text = "";
            amttxt.Text = "0";
            inwordtxt.Text = "";
            while(dgvcheque.Rows.Count>0)
            {
                cal(0, -1);
                dgvcheque.Rows.RemoveAt(0);
            }
            transamttxt.Enabled = true;
            transidtxt.Enabled = true;
            banktxt.Enabled = true;
            trans_date.Enabled = true;                
            newbtn.Visible = false;
            prntbtn.Visible = false;
            Savebtn.Enabled = true;
            Discardbtn.Enabled = true;
            addbtn.Enabled = true;
            deletebtn.Enabled = true;
            NoEdit();
        }
        private void prntbtn_Click(object sender, EventArgs e)
        {

        }
    }
    public class paymentDT
    {
        public string callby = "";
        public string callas = "";
        public string mode = "";
        public string tname1 = "";
        public string tname2 = "";
        public TranDB.insert_Payment_T InsertPT;
        public TranDB.insert_Payment_D_T InsertPDT;       
    }
}
