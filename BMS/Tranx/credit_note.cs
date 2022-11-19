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
    public partial class credit_note : Form
    {
        public credit_note(string callas)
        {
            InitializeComponent();
            CheckCallMethod(callas);
        }
        DataTable ds;
        private void cleardgvloaded( )
        {
            dgvItemloaded.Enabled = true;
            while (dgvItemloaded.Rows.Count>0)
            {                
                dgvItemloaded.Rows.RemoveAt(0);
            }
            dgvItemloaded.Enabled = false;
            postsaleamt.Text = "0";
            postsalechk.Checked = false;
        }
        void fill_ds()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            string qurry = "select * from [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Credit_Note_T]";
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
        private void CheckCallMethod(string CallAS)
        {
            if (CallAS == "New")
            {
                //do setting
                savebtn.Show();
                dsicardbtn.Show();
                newbtn.Hide();
                Nextbtn.Hide();
                previousbtn.Hide();
                prntbtn.Hide();               
                
                //Main ss = new Main();
                comlbl.Text = Calculator.ret_Name(Calculator.get_temp_data(Constant_And_Variable.Company_id), Constant_And_Variable.CompanyDB);
                emplbl.Text = Calculator.get_temp_data("LoginID");
                addbtn.Show();
                deletebtn.Show();               

                noteidtxt.Text = "#######";
                noteidtxt.ReadOnly = true;               
                discrattxt.Text = "0";
                sgsttxt.Text = "0";
                cgsttxt.Text = "0";
                igsttxt.Text = "0";
                ttaxtxt.Text = "0";               
                tottxt.Text = "0";
                grtottxt.Text = "0";
                pcstxt.Text = "0";
                disctxt.Text = "0";
                subttxt.Text = "0";
                discrattxt.Text = "0";
                numwrdtxt.Text = "Zero";
                postsaleamt.Text = "0";

                datetxt.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                noteidtxt.ReadOnly = true;
                datetxt.ReadOnly = true;
                newbtn.Visible = false;
                sgsttxt.ReadOnly = true;
                cgsttxt.ReadOnly = true;
                igsttxt.ReadOnly = true;
                ttaxtxt.ReadOnly = true;                
                tottxt.ReadOnly = true;
                grtottxt.ReadOnly = true;
                pcstxt.ReadOnly = true;
                disctxt.ReadOnly = true;
                subttxt.ReadOnly = true;
                numwrdtxt.ReadOnly = true;
                postsaleamt.ReadOnly = true;
                Cuscmbx.Enabled = false;
                postsalechk.Enabled = false;
                invo_notxt.Text = "Select Invoice";
            }
            else if (CallAS == "View")
            {
                //do setting
                savebtn.Hide();
                dsicardbtn.Hide();
                newbtn.Hide();
                deletebtn.Hide();
                prntbtn.Show();
                Nextbtn.Show();
                previousbtn.Show();
                comlbl.Text = Calculator.ret_Name(Calculator.get_temp_data(Constant_And_Variable.Company_id), Constant_And_Variable.CompanyDB);
                addbtn.Hide();                

             
                discrattxt.Text = "0";
                sgsttxt.Text = "0";
                cgsttxt.Text = "0";
                igsttxt.Text = "0";
                ttaxtxt.Text = "0";
                tottxt.Text = "0";
                grtottxt.Text = "0";
                pcstxt.Text = "0";
                disctxt.Text = "0";
                subttxt.Text = "0";
                discrattxt.Text = "0";
                numwrdtxt.Text = "Zero";
                postsaleamt.Text = "0";

                datetxt.ReadOnly = true;
                newbtn.Visible = false;
                sgsttxt.ReadOnly = true;
                cgsttxt.ReadOnly = true;
                igsttxt.ReadOnly = true;
                ttaxtxt.ReadOnly = true;                
                tottxt.ReadOnly = true;
                grtottxt.ReadOnly = true;
                pcstxt.ReadOnly = true;
                disctxt.ReadOnly = true;
                subttxt.ReadOnly = true;
                numwrdtxt.ReadOnly = true;
                postsaleamt.ReadOnly = true;
                Cuscmbx.Enabled = false;
                fill_ds();
                NavRec();
            }
            else if (CallAS == "Edit")
            {
                //do setting
            }
        }
        private void dgvDelete()
        {
            while (dgvadditm.SelectedRows.Count > 0)
            {

                try
                {
                    cal(0, -1);
                    dgvadditm.ReadOnly = false;
                    dgvadditm.Rows.RemoveAt(0);
                    dgvadditm.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
        private void NavRec(int i = 0)
        {
            if (ds.Rows.Count > 0)
            {
                Edit();
                noteidtxt.Text = ds.Rows[i][0].ToString();
                datetxt.Text = Convert.ToDateTime(ds.Rows[i][1].ToString()).ToString("dd-MM-yyyy");
                comlbl.Text = Calculator.ret_Name(Calculator.get_temp_data(Constant_And_Variable.Company_id), Constant_And_Variable.CompanyDB);
                Cuscmbx.Text = Calculator.ret_Name(ds.Rows[i][3].ToString(), Constant_And_Variable.CustomerDB);
                double amt;
                dgvDelete();
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
                string qurry = "select * from [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Crdn_D_T] where Cre_ID_fkey ='" + noteidtxt.Text + "'";
                SqlCommand cmd = new SqlCommand(qurry, con);
                con.Open();
                try
                {
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        amt = reader.GetDouble(4) * reader.GetDouble(3);
                        string sinvo = reader.GetString(1);
                        string sitem = reader.GetString(2);
                        string sqnty = reader.GetDouble(4).ToString();
                        string srate = reader.GetDouble(3).ToString();
                        dgvadditm.Rows.Add(sitem, "0", "0", sqnty, srate, amt.ToString());                        
                        cal(dgvadditm.Rows.Count - 1, 1);
                    }
                }
                catch (Exception)
                {

                }
                con.Close();
                NoEdit();
                Calculator.register_selected_data(Constant_And_Variable.Customer_id, ds.Rows[i][3].ToString());
                Calculator.register_selected_data(Constant_And_Variable.Doc_date, ds.Rows[i][1].ToString());
            }
        }
        private void subcal()
        {
            disctxt.Text = Convert.ToString(Convert.ToDouble(subttxt.Text) * (Convert.ToDouble(discrattxt.Text) / 100));
            tottxt.Text = Convert.ToString(Convert.ToDouble(subttxt.Text) - Convert.ToDouble(disctxt.Text));
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString);
            con.Open();
            string qurry = "Select State from Adres_T where addri_id_fkey=" + Cuscmbx.SelectedValue + "";
            SqlCommand cmd = new SqlCommand(qurry, con);
            string sstate = "";
            try
            {
                SqlDataReader dataDB;
                dataDB = cmd.ExecuteReader();
                while (dataDB.Read())
                {
                    sstate = dataDB.GetString(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (sstate != "Uttar Pradesh")
            {
                igsttxt.Text = Convert.ToString(Convert.ToDouble(tottxt.Text) * 0.05);
                ttaxtxt.Text = Convert.ToString(Convert.ToDouble(igsttxt.Text));
            }
            else if (sstate == "Uttar Pradesh")
            {
                cgsttxt.Text = Convert.ToString(Convert.ToDouble(tottxt.Text) * 0.025);
                sgsttxt.Text = Convert.ToString(Convert.ToDouble(tottxt.Text) * 0.025);
                ttaxtxt.Text = Convert.ToString(Convert.ToDouble(cgsttxt.Text) + Convert.ToDouble(sgsttxt.Text));
            }

            grtottxt.Text = Convert.ToString(Convert.ToDouble(tottxt.Text) + Convert.ToDouble(ttaxtxt.Text));

            numwrdtxt.Text = NumToWord.ConvertNumbertoWords(Convert.ToInt32(Convert.ToDouble(grtottxt.Text)));
        }
        void cal(int n, int sign)
        {
            sgsttxt.ReadOnly = false;
            cgsttxt.ReadOnly = false;
            igsttxt.ReadOnly = false;
            ttaxtxt.ReadOnly = false;            
            tottxt.ReadOnly = false;
            grtottxt.ReadOnly = false;
            pcstxt.ReadOnly = false;
            disctxt.ReadOnly = false;
            subttxt.ReadOnly = false;
            numwrdtxt.ReadOnly = false;
            dgvadditm.ReadOnly = false;
            
            pcstxt.Text = Convert.ToString(Convert.ToDouble(pcstxt.Text) + Convert.ToDouble(dgvadditm.Rows[n].Cells[3].Value) * sign);
            subttxt.Text = Convert.ToString(Convert.ToDouble(subttxt.Text) + Convert.ToDouble(dgvadditm.Rows[n].Cells[6].Value) * sign);
            subcal();

            sgsttxt.ReadOnly = true;
            cgsttxt.ReadOnly = true;
            igsttxt.ReadOnly = true;
            ttaxtxt.ReadOnly = true;            
            tottxt.ReadOnly = true;
            grtottxt.ReadOnly = true;
            pcstxt.ReadOnly = true;
            disctxt.ReadOnly = true;
            subttxt.ReadOnly = true;
            numwrdtxt.ReadOnly = true;
            dgvadditm.ReadOnly = true;
        }
        private void NoEdit()
        {
            Cuscmbx.Enabled = false;
            noteidtxt.ReadOnly = true;
            postsaleamt.ReadOnly = true;

            deletebtn.Enabled = false;
            dgvadditm.ReadOnly = true;
            dgvItemloaded.ReadOnly = true;
            dgvinvolist.ReadOnly = true;
        }
        private void Edit()
        {
            Cuscmbx.Enabled = true;            
            noteidtxt.ReadOnly = false;
            postsaleamt.ReadOnly = false;
           
            deletebtn.Enabled = true;
            dgvadditm.ReadOnly = true;
            dgvItemloaded.ReadOnly = true;
            dgvinvolist.ReadOnly = true;
        }
        private void loadbtn_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            string qurry = "Select * from [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Invo_D_T] where Invo_ID_fkey=" + invo_notxt + "";
            SqlCommand cmd = new SqlCommand(qurry, con);            
            ds = new DataTable();
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
            if (ds.Rows.Count < 1)
            {
                MessageBox.Show("Not Found, Check the details.");
            }
            else
            {
                invo_notxt.Enabled = false;
                loadbtn.Enabled = false;
                postsalechk.Enabled = true;
                postsaleamt.ReadOnly = false;
                string cusid = "";
                con.Open();
                qurry = "Select * from [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Invoice_T] where Id=" + invo_notxt + "";
                cmd = new SqlCommand(qurry, con);
                try
                {
                    SqlDataReader dataDB;
                    dataDB = cmd.ExecuteReader();
                    while (dataDB.Read())
                    {
                        cusid = dataDB.GetString(3);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                con.Close();
                Cuscmbx.Enabled = true;
                Cuscmbx.DisplayMember = Calculator.ret_Name(cusid, Constant_And_Variable.CustomerDB);
                Cuscmbx.ValueMember = cusid;
                Cuscmbx.Enabled = false;
                dgvItemloaded.Enabled = true;
                int n = 0;
                while (n < ds.Rows.Count)
                {
                    dgvItemloaded.Rows[dgvItemloaded.NewRowIndex].Cells[1].Value = ds.Rows[n][2].ToString();
                    con.Open();
                    qurry = "Select * from Stock_T where Item_no=" + ds.Rows[n][1].ToString() + "";
                    SqlCommand cmd1 = new SqlCommand(qurry, con);
                    try
                    {
                        SqlDataReader myreader = cmd1.ExecuteReader();
                        while (myreader.Read())
                        {
                            dgvItemloaded.Rows[dgvItemloaded.NewRowIndex].Cells[2].Value = myreader.GetString(2);
                            dgvItemloaded.Rows[dgvItemloaded.NewRowIndex].Cells[3].Value = myreader.GetString(3);
                        }
                    }
                    catch (Exception)
                    { }
                    con.Close();

                    dgvItemloaded.Rows[dgvItemloaded.NewRowIndex].Cells[4].Value = ds.Rows[n][4].ToString();
                    dgvItemloaded.Rows[dgvItemloaded.NewRowIndex].Cells[5].Value = ds.Rows[n][3].ToString();
                    dgvItemloaded.Rows[dgvItemloaded.NewRowIndex].Cells[6].Value = Convert.ToDouble(ds.Rows[n][4].ToString()) * Convert.ToDouble(ds.Rows[n][3].ToString());
                    n++;
                }
                dgvItemloaded.Enabled = false;
            }
        }

        private void dgvItemloaded_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvItemloaded.Rows[e.RowIndex].Cells[0];
                if (chk.Value == chk.TrueValue)
                {
                    dgvItemloaded.Rows[e.RowIndex].Cells[4].ReadOnly = false;
                }
                else
                {
                    dgvItemloaded.Rows[e.RowIndex].Cells[4].Value = ds.Rows[e.RowIndex][4].ToString();
                    dgvItemloaded.Rows[e.RowIndex].Cells[4].ReadOnly = true;
                }
                if (dgvItemloaded.Rows.Count > 0)
                {
                    addbtn.Enabled = true;
                    deletebtn.Enabled = true;
                }
                else
                {
                    addbtn.Enabled = false;
                    deletebtn.Enabled = false;
                }
            }
        }

        private void dgvItemloaded_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvItemloaded.Rows[e.RowIndex].Cells[0];
            if (chk.Value == chk.TrueValue)
            {
                if ((double)dgvItemloaded.Rows[e.RowIndex].Cells[4].Value > (double)ds.Rows[e.RowIndex][4])
                {
                    MessageBox.Show("Only " + ds.Rows[e.RowIndex][4].ToString() + "has issued!");
                    dgvItemloaded.Rows[e.RowIndex].Cells[4].Value = ds.Rows[e.RowIndex][4].ToString();
                }
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (dgvItemloaded.Rows.Count > 0)
            {
                int n = 0;
                while (n < dgvItemloaded.Rows.Count)
                {
                    dgvadditm.ReadOnly = false;
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvItemloaded.Rows[n].Cells[0];
                    if (chk.Value == chk.TrueValue)
                    {
                        dgvadditm.Rows[dgvadditm.NewRowIndex].Cells[0].Value = invo_notxt.Text;
                        dgvadditm.Rows[dgvadditm.NewRowIndex].Cells[1].Value = dgvItemloaded.Rows[n].Cells[1].Value;
                        dgvadditm.Rows[dgvadditm.NewRowIndex].Cells[2].Value = dgvItemloaded.Rows[n].Cells[2].Value;
                        dgvadditm.Rows[dgvadditm.NewRowIndex].Cells[3].Value = dgvItemloaded.Rows[n].Cells[3].Value;
                        dgvadditm.Rows[dgvadditm.NewRowIndex].Cells[4].Value = dgvItemloaded.Rows[n].Cells[4].Value;
                        dgvadditm.Rows[dgvadditm.NewRowIndex].Cells[5].Value = dgvItemloaded.Rows[n].Cells[5].Value;
                        dgvadditm.Rows[dgvadditm.NewRowIndex].Cells[6].Value = dgvItemloaded.Rows[n].Cells[6].Value;
                        cal(n, 1);
                    }
                    n++;
                    dgvadditm.ReadOnly = true;
                }
                if (postsalechk.Checked==true)
                {
                    dgvadditm.Rows[dgvadditm.NewRowIndex].Cells[0].Value = invo_notxt.Text;
                    dgvadditm.Rows[dgvadditm.NewRowIndex].Cells[1].Value = "POS";
                    dgvadditm.Rows[dgvadditm.NewRowIndex].Cells[2].Value = "Discount Taken Post Sale";
                    dgvadditm.Rows[dgvadditm.NewRowIndex].Cells[3].Value = "null";
                    dgvadditm.Rows[dgvadditm.NewRowIndex].Cells[4].Value = "null";
                    dgvadditm.Rows[dgvadditm.NewRowIndex].Cells[5].Value = "null";
                    dgvadditm.Rows[dgvadditm.NewRowIndex].Cells[6].Value = postsaleamt.Text;
                    cal(n, 1);
                }
                cleardgvloaded();
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
                con.Open();
                string qurry = "Select * from [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Invoice_T] where Id=" + invo_notxt + "";
                SqlCommand cmd = new SqlCommand(qurry, con);
                cmd = new SqlCommand(qurry, con);
                try
                {
                    SqlDataReader dataDB;
                    dataDB = cmd.ExecuteReader();
                    dgvinvolist.Enabled = true;
                    while (dataDB.Read())
                    {
                        dgvinvolist.Rows[dgvinvolist.NewRowIndex].Cells[0].Value = dataDB.GetString(0);
                        dgvinvolist.Rows[dgvinvolist.NewRowIndex].Cells[1].Value = dataDB.GetString(1);
                        dgvinvolist.Rows[dgvinvolist.NewRowIndex].Cells[4].Value = dataDB.GetString(1);
                    }
                    dgvinvolist.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                con.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (postsalechk.Checked == true)
            {
                postsaleamt.Enabled = true;
            }
            else
            {
                postsaleamt.Enabled = false;
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvadditm.RowCount > 0)
                {
                    dgvadditm.Rows.RemoveAt(dgvadditm.SelectedRows[0].Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        int lastinvo_no()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            string qurry = "Select Id from [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Credit_Note_T] ";
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
        bool check_condition()
        {
            bool chk = true;
            try
            {
                if (dgvadditm.Rows.Count<1 && postsalechk.Checked==true)
                {
                    if(Convert.ToDouble(postsaleamt.Text)>0)
                    {
                        chk = false;
                        MessageBox.Show("Add Credit details detail");
                    }
                }
            }
            catch (Exception)
            {
                chk = false;
                MessageBox.Show("Add Credit details detail");
            }
            if (Convert.ToDouble(grtottxt.Text) <= 0)
            {
                chk = false;
                MessageBox.Show("Item Detail is not given");
            }
            return chk;
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            if (check_condition())
            {
                SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
                string qurry = "insert into [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Credit_Note_T] ( receiver_id_fkey, date_, discrate, author_ID_fkey, ) values('" + Cuscmbx.SelectedValue.ToString() + "','" + DateTime.Now.ToString("yyyyMMdd") + "','" + discrattxt.Text + "','" + emplbl.Text + "') ";
                SqlCommand cmd1 = new SqlCommand(qurry, con1);
                con1.Open();

                try
                {
                    cmd1.ExecuteNonQuery();
                    noteidtxt.Text = lastinvo_no().ToString();
                    Ledger_Process.Ledger_Update("Company_" + Calculator.get_temp_data(Constant_And_Variable.Company_id), "Customer_" + Cuscmbx.SelectedValue.ToString(), "Debit", noteidtxt.Text, Convert.ToDouble(grtottxt.Text), "Sarees " + pcstxt.Text + " issued @ discount " + discrattxt.Text + "%");
                    Ledger_Process.Ledger_Update_GST(Calculator.get_temp_data(Constant_And_Variable.Company_id), Calculator.get_temp_data(Constant_And_Variable.Customer_id), "Credit", noteidtxt.Text, Convert.ToDouble(tottxt.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                con1.Close();
                SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
                int n = 0;
                while (n < dgvadditm.Rows.Count)
                {
                    qurry = "insert into [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Crdn_D_T] (Cre_ID_fkey, item_no_fkey, rate, qnty) values('" + noteidtxt.Text + "','" + dgvadditm.Rows[n].Cells[0].Value + "','" + dgvadditm.Rows[n].Cells[4].Value + "','" + dgvadditm.Rows[n].Cells[3].Value + "') ";
                    SqlCommand cmd2 = new SqlCommand(qurry, con2);
                    con2.Open();
                    try
                    {

                        cmd2.ExecuteNonQuery();
                        Ledger_Process.Item_Update(comlbl.Text, "Item_" + dgvadditm.Rows[n].Cells[0].Value.ToString(), "Credit", dgvadditm.Text, Convert.ToInt32(dgvadditm.Rows[n].Cells[3].Value.ToString()));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    con2.Close();
                    n = n + 1;
                }
                NoEdit();
                Calculator.register_selected_data(Constant_And_Variable.Customer_id, Cuscmbx.SelectedValue.ToString());
                Calculator.register_selected_data(Constant_And_Variable.Doc_date, noteidtxt.Text);
                savebtn.Enabled = false;
                dsicardbtn.Enabled = false;
                newbtn.Visible = true;
                prntbtn.Visible = true;
            }
        }
        private void dsicardbtn_Click(object sender, EventArgs e)
        {
            dgvDelete();
        }

        private void postsaleamt_TextChanged(object sender, EventArgs e)
        {
            NumToWord.IsNumber(postsaleamt.Text);
        }
        int pos = 0;
        private void Nextbtn_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos >= ds.Rows.Count)
            {
                pos--;
            }
            NavRec(pos);
        }

        private void previousbtn_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos < 0)
            {
                pos++;
            }
            NavRec(pos);
        }

        private void newbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
