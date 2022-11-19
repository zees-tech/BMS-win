using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bms1
{
    public partial class payment : Form
    {
        string Callas,type;
        DataTable ds;
        string trans;
               
        public payment(string callby,string callas)
        {
            Callas = callas;
            InitializeComponent();
            CheckCallMethod(callby);
            if (callby == "Customer")
            {
                trans = "Debit";
                type = "Credit";
            }
            else
            {
                trans = "Credit";
                type = "Debit";
            }

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
                datetxt.Text = Convert.ToDateTime(ds.Rows[i][1].ToString()).ToString("dd-MM-yyyy");
                //comlbl.Text = Calculator.ret_Name(Calculator.get_temp_data(Constant_And_Variable.Company_id), Constant_And_Variable.CompanyDB);
                partycmbx.Text = Calculator.ret_Name(ds.Rows[i][3].ToString(), Constant_And_Variable.CustomerDB);                
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
            amttxt.Text = (Convert.ToDouble(amttxt.Text) + sign*Convert.ToDouble(dgvcheque.Rows[index].Cells[3].Value)).ToString();
            inwordtxt.Text = NumToWord.ConvertNumbertoWords(Convert.ToDouble(amttxt.Text));
            NoEdit();
        }

        private void NoEdit()
        {
            //partycmbx.Enabled = false;
            receipttxt.ReadOnly = true;
            amttxt.ReadOnly = true;
            inwordtxt.ReadOnly = true;
            receipttxt.ReadOnly = true;
            datetxt.ReadOnly = true;
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
            //partycmbx.Enabled = true;
            receipttxt.ReadOnly = false;
            amttxt.ReadOnly = false;
            inwordtxt.ReadOnly = false;
            receipttxt.ReadOnly = false;
            datetxt.ReadOnly = true;            
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
        private void CheckCallMethod(string Callby)
        {

            if (Callby == "Supplier")
            {
                //do setting
                Savebtn.Show();
                Discardbtn.Show();
                newbtn.Hide();
                prntbtn.Hide();
                receipttxt.Text = "#######";
                receipttxt.ReadOnly = true;
                fillPartycombo(Callby);
                partycmbx.Text = "Select Supplier";
                partylbl.Text = "To:";

            }

            else if (Callby == "Servicer")
            {
                //do setting
                Savebtn.Show();
                Discardbtn.Show();
                newbtn.Hide();
                prntbtn.Hide();
                receipttxt.Text = "#######";
                receipttxt.ReadOnly = true;
                fillPartycombo(Callby);
                partycmbx.Text = "Select Servicer";
                partylbl.Text = "To:";

            }

            else if (Callby == "Customer")
            {
                //do setting
                Savebtn.Show();
                Discardbtn.Show();
                newbtn.Hide();
                prntbtn.Hide();
                receipttxt.Text = "#######";
                receipttxt.ReadOnly = true;
                fillPartycombo(Callby);
                partycmbx.Text = "Select Customer";
                partylbl.Text = "From:";

            }

            else if (Callby == "Edit")
            {
                //do setting
            }

            if (Callas =="Cheque")
            {
                dgvcheque.Visible = true;
                addbtn.Visible = true;
                deletebtn.Visible = true;
                transIDlbl.Text = "Cheque No.";
            }
            else if (Callas == "A/c_Transfer")
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

        private void transamttxt_TextChanged(object sender, EventArgs e)
        {
            if (NumToWord.IsNumber(transamttxt.Text))
            {
                if (Callas == "A/c_Transfer")
                {
                    amttxt.Text = transamttxt.Text;
                }
            }
            else
                transamttxt.Text = "0";
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            dgvcheque.AllowUserToAddRows = true;
            dgvcheque.Rows[dgvcheque.NewRowIndex].Cells[0].Value = Convert.ToDateTime(trans_date).ToString("yyyyMMdd");
            dgvcheque.Rows[dgvcheque.NewRowIndex].Cells[1].Value = banktxt.Text;
            dgvcheque.Rows[dgvcheque.NewRowIndex].Cells[2].Value = transidtxt.Text;
            dgvcheque.Rows[dgvcheque.NewRowIndex].Cells[3].Value = transamttxt.Text;
            dgvcheque.AllowUserToAddRows = false;
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            dgvcheque.Rows.RemoveAt(dgvcheque.SelectedRows[0].Index);
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (check_condition())
            {
                SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
                string qurry = "insert into [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Payment_T] ( receiver_id_fkey, date_, mode, collector,author_ID_fkey,type ) values('" + partycmbx.SelectedValue.ToString() + "','" + DateTime.Now.ToString("yyyyMMdd") + "','" + Callas + "','" + emplbl.Text + "','"+Callas+"','"+type
                    +"') ";
                SqlCommand cmd1 = new SqlCommand(qurry, con1);
                con1.Open();               
                try
                {
                    cmd1.ExecuteNonQuery();
                    receipttxt.Text = lastid_no().ToString();
                    Ledger_Process.Ledger_Update("Company_" + Calculator.get_temp_data(Constant_And_Variable.Company_id), "Customer_" + partycmbx.SelectedValue.ToString(), trans, receipttxt.Text, Convert.ToDouble(amttxt.Text),amttxt.Text+" "+trans+" against "+receipttxt+" on "+ DateTime.Now.ToString("yyyyMMdd"));
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                con1.Close();
                SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
                int n = 0;
                while (n < dgvcheque.Rows.Count)
                {
                    qurry = "insert into [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Pay_D_T] (pay_ID_fkey, date_, bank, transaction_ID, amt) values('" + receipttxt.Text + "','" + dgvcheque.Rows[n].Cells[0].Value + "','" + dgvcheque.Rows[n].Cells[1].Value + "','" + dgvcheque.Rows[n].Cells[2].Value + "','" + dgvcheque.Rows[n].Cells[3].Value + "') ";
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
                    n = n + 1;
                }
                NoEdit();
                Calculator.register_selected_data(Constant_And_Variable.Customer_id, partycmbx.SelectedValue.ToString());
                Calculator.register_selected_data(Constant_And_Variable.Doc_date, receipttxt.Text);
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
            amttxt.Text = "";
            inwordtxt.Text = "";
            while (dgvcheque.RowCount > 0)
            {
                cal(0, -1);
                dgvcheque.AllowUserToAddRows = true;
                dgvcheque.Rows.RemoveAt(0);
                dgvcheque.AllowUserToAddRows = true;
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
            amttxt.Text = "";
            inwordtxt.Text = "";
            while(dgvcheque.RowCount>0)
            {
                cal(0, -1);
                dgvcheque.AllowUserToAddRows = true;
                dgvcheque.Rows.RemoveAt(0);
                dgvcheque.AllowUserToAddRows = true;
            }
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
}
