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
    public partial class Invoice : Form
    {
        public Invoice(string callas)
        {            
            InitializeComponent();
            CheckCallMethod(callas);            
        }
        int pos = 0;
        double amt = 0;
        private DataTable ds = new DataTable();
        //this.btnaddcustomer.Click += new System.EventHandler(this.btnaddcustomer_Click);
        

        void fillCuscombo()
        {

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString);
            con.Open();
            string qurry = "Select * from Customer_T ";
            SqlCommand cmd = new SqlCommand(qurry, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();            
            try
            {
                sda.Fill(data);
                Cuscmbx.ValueMember = "Id";
                Cuscmbx.DisplayMember = "Name";
                Cuscmbx.DataSource = data;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }
        void fillItmcombo()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
            con.Open();
            string qurry = "Select * from Stock_T ";
            SqlCommand cmd = new SqlCommand(qurry, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                DataTable dataDB = new DataTable();
                sda.Fill(dataDB);
                itemcmbx.ValueMember = "Id";
                itemcmbx.DisplayMember = "Item_no";
                itemcmbx.DataSource = dataDB;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            itemcmbx.Text = "Select Item";
        }
        int lastinvo_no()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            string qurry = "Select Id from [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Invoice_T] ";
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
        void setdate()
        {
            datetxt.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
        }
        void cal(int n, int sign)
        {
            sgsttxt.ReadOnly = false;
            cgsttxt.ReadOnly = false;
            igsttxt.ReadOnly = false;
            ttaxtxt.ReadOnly = false;
            numofitmtxt.ReadOnly = false;
            tottxt.ReadOnly = false;
            grtottxt.ReadOnly = false;
            pcstxt.ReadOnly = false;
            disctxt.ReadOnly = false;
            subttxt.ReadOnly = false;
            numwrdtxt.ReadOnly = false;
            itemdtdgv.ReadOnly = false;

            numofitmtxt.Text = Convert.ToString(Convert.ToInt32(numofitmtxt.Text) + sign);
            pcstxt.Text = Convert.ToString(Convert.ToDouble(pcstxt.Text) + Convert.ToDouble(itemdtdgv.Rows[n].Cells[3].Value) * sign);
            subttxt.Text = Convert.ToString(Convert.ToDouble(subttxt.Text) + Convert.ToDouble(itemdtdgv.Rows[n].Cells[5].Value) * sign);
            subcal();

            sgsttxt.ReadOnly = true;
            cgsttxt.ReadOnly = true;
            igsttxt.ReadOnly = true;
            ttaxtxt.ReadOnly = true;
            numofitmtxt.ReadOnly = true;
            tottxt.ReadOnly = true;
            grtottxt.ReadOnly = true;
            pcstxt.ReadOnly = true;
            disctxt.ReadOnly = true;
            subttxt.ReadOnly = true;
            numwrdtxt.ReadOnly = true;
            itemdtdgv.ReadOnly = true;
        }
        void filltransportcombo()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[Constant_And_Variable.CompanyDB].ConnectionString);
            con.Open();
            string qurry = "Select * from Transport_T ";
            SqlCommand cmd = new SqlCommand(qurry, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                DataTable dataDB = new DataTable();
                sda.Fill(dataDB);
                transportcmb.ValueMember = "Id";
                transportcmb.DisplayMember = "Name";
                transportcmb.DataSource = dataDB;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            transportcmb.Text = "Select Item";
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

            grtottxt.Text = Convert.ToString(Convert.ToDouble(tottxt.Text) + Convert.ToDouble(ttaxtxt.Text) + Convert.ToDouble(transport_chargetxt.Text) + Convert.ToDouble(packagingtxt.Text));
            
            numwrdtxt.Text = NumToWord.ConvertNumbertoWords(Convert.ToInt32(Convert.ToDouble(grtottxt.Text)));
        }

        private void dgvDelete()
        {
            while (itemdtdgv.SelectedRows.Count > 0)
            {

                try
                {
                    cal(0, -1);
                    itemdtdgv.ReadOnly = false;
                    itemdtdgv.Rows.RemoveAt(0);
                    itemdtdgv.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
        void fill_ds()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            string qurry = "select * from [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Invoice_T]";
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
        void set_detail()
        {
            int i = itemdtdgv.Rows.Count - 1;
            SqlConnection con4 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
            con4.Open();
            string qurry = "Select * from Stock_T where Item_no='" + itemdtdgv.Rows[i].Cells[0].Value + "'";
            SqlCommand cmd1 = new SqlCommand(qurry, con4);
            SqlDataReader myreader;
            myreader = cmd1.ExecuteReader();
            try
            {
                while (myreader.Read())
                {
                    itemdtdgv.Rows[i].Cells[1].Value = myreader.GetString(2);
                    itemdtdgv.Rows[i].Cells[2].Value = myreader.GetString(3);
                }
            }
            catch (Exception)
            {

            }
            con4.Close();
        }
        private void NavRec(int i = 0)
        {
            if (ds.Rows.Count > 0)
            {
                Edit();
                invoidtxt.Text = ds.Rows[i][0].ToString();
                datetxt.Text = Convert.ToDateTime(ds.Rows[i][1].ToString()).ToString("dd-MM-yyyy");
                comlbl.Text = Calculator.ret_Name(Calculator.get_temp_data(Constant_And_Variable.Company_id), Constant_And_Variable.CompanyDB);
                Cuscmbx.Text = Calculator.ret_Name(ds.Rows[i][3].ToString(), Constant_And_Variable.CustomerDB);
                paymenttermtxt.Text = ds.Rows[i][9].ToString();
                transportcmb.Text = ds.Rows[i][5].ToString();
                transport_chargetxt.Text = ds.Rows[i][7].ToString();
                packagingtxt.Text = ds.Rows[i][8].ToString();
                if (true)
                {
                    ewaybilltxt.Text = ds.Rows[i][6].ToString();
                }
                dgvDelete();
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
                string qurry = "select * from [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Invo_D_T] where Invo_ID_fkey ='" + invoidtxt.Text + "'";
                SqlCommand cmd = new SqlCommand(qurry, con);
                con.Open();
                try
                {
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        amt = reader.GetDouble(4) * reader.GetDouble(3);
                        string sitem = reader.GetString(2);
                        string sqnty = reader.GetDouble(4).ToString();
                        string srate = reader.GetDouble(3).ToString();
                        itemdtdgv.Rows.Add(sitem, "0", "0", sqnty, srate, amt.ToString());
                        
                        cal(itemdtdgv.Rows.Count - 1, 1);
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
        private void NoEdit()
        {
            Cuscmbx.Enabled = false;
            invoidtxt.ReadOnly = true;
            itemcmbx.Enabled = false;
            descrptxt.ReadOnly = true;
            hsntxt.ReadOnly = true;
            ratetxt.ReadOnly = true;
            qntytxt.ReadOnly = true;
            delbtn.Enabled = false;
            itemdtdgv.ReadOnly = true;
            ewaybilltxt.ReadOnly = true;
            transportcmb.Enabled = false;
            transport_chargetxt.ReadOnly = true;
            packagingtxt.ReadOnly = true;
            paymenttermtxt.ReadOnly = true;
        }
        private void Edit()
        {
            Cuscmbx.Enabled = true;
            itemcmbx.Enabled = true;
            invoidtxt.ReadOnly = false;
            descrptxt.ReadOnly = false;
            hsntxt.ReadOnly = false;
            ratetxt.ReadOnly = false;
            qntytxt.ReadOnly = false;
            delbtn.Enabled = true;
            itemdtdgv.ReadOnly = true;
            ewaybilltxt.ReadOnly = false;
            transportcmb.Enabled = true;
            transport_chargetxt.ReadOnly = false;
            packagingtxt.ReadOnly = false;
            paymenttermtxt.ReadOnly = false;
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
                ewaybilltxt.Hide();
                ewaybil_lbl.Hide();
                //Main ss = new Main();
                comlbl.Text = Calculator.ret_Name(Calculator.get_temp_data(Constant_And_Variable.Company_id), Constant_And_Variable.CompanyDB);
                emplbl.Text = Calculator.get_temp_data("LoginID");
                addbtn.Show();
                delbtn.Show();
                itmlbl.Show();
                itemcmbx.Show();
                Descrplbl.Show();
                descrptxt.Show();
                hsnlbl.Show();
                hsntxt.Show();
                ratelbl.Show();
                ratetxt.Show();
                qntylbl.Show();
                qntytxt.Show();
                AdItemgrp.Show();

                invoidtxt.Text = "#######";
                invoidtxt.ReadOnly = true;
                ratetxt.Text = "0";
                qntytxt.Text = "0";
                discrattxt.Text = "0";
                sgsttxt.Text = "0";
                cgsttxt.Text = "0";
                igsttxt.Text = "0";
                ttaxtxt.Text = "0";
                numofitmtxt.Text = "0";
                tottxt.Text = "0";
                grtottxt.Text = "0";
                pcstxt.Text = "0";
                disctxt.Text = "0";
                subttxt.Text = "0";
                discrattxt.Text = "0";
                numwrdtxt.Text = "Zero";
                transport_chargetxt.Text = "0";
                packagingtxt.Text = "0";
                fillCuscombo();
                fillItmcombo();
                filltransportcombo();
                setdate();
                invoidtxt.ReadOnly = true;
                datetxt.ReadOnly = true;
                newbtn.Visible = false;
                sgsttxt.ReadOnly = true;
                cgsttxt.ReadOnly = true;
                igsttxt.ReadOnly = true;
                ttaxtxt.ReadOnly = true;
                numofitmtxt.ReadOnly = true;
                tottxt.ReadOnly = true;
                grtottxt.ReadOnly = true;
                pcstxt.ReadOnly = true;
                disctxt.ReadOnly = true;
                subttxt.ReadOnly = true;
                numwrdtxt.ReadOnly = true;
                Cuscmbx.Text = "Select Customer";
            }
            else if (CallAS == "View")
            {
                //do setting
                savebtn.Hide();
                dsicardbtn.Hide();
                newbtn.Hide();
                delbtn.Hide();
                prntbtn.Show();
                Nextbtn.Show();
                previousbtn.Show();
                comlbl.Text = "";
                addbtn.Hide();
                itmlbl.Hide();
                itemcmbx.Hide();
                Descrplbl.Hide();
                descrptxt.Hide();
                hsnlbl.Hide();
                hsntxt.Hide();
                ratelbl.Hide();
                ratetxt.Hide();
                qntylbl.Hide();
                qntytxt.Hide();
                AdItemgrp.Hide();

                ratetxt.Text = "0";
                qntytxt.Text = "0";
                discrattxt.Text = "0";
                sgsttxt.Text = "0";
                cgsttxt.Text = "0";
                igsttxt.Text = "0";
                ttaxtxt.Text = "0";
                numofitmtxt.Text = "0";
                tottxt.Text = "0";
                grtottxt.Text = "0";
                pcstxt.Text = "0";
                disctxt.Text = "0";
                subttxt.Text = "0";
                discrattxt.Text = "0";
                numwrdtxt.Text = "Zero";
                transport_chargetxt.Text = "0";
                packagingtxt.Text = "0";
                fillCuscombo();
                fillItmcombo();
                setdate();
                datetxt.ReadOnly = true;
                newbtn.Visible = false;
                sgsttxt.ReadOnly = true;
                cgsttxt.ReadOnly = true;
                igsttxt.ReadOnly = true;
                ttaxtxt.ReadOnly = true;
                numofitmtxt.ReadOnly = true;
                tottxt.ReadOnly = true;
                grtottxt.ReadOnly = true;
                pcstxt.ReadOnly = true;
                disctxt.ReadOnly = true;
                subttxt.ReadOnly = true;
                numwrdtxt.ReadOnly = true;

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
                if (Cuscmbx.Text == "Select Customer")
                {
                    chk = false;
                    MessageBox.Show("Customer Detail is not given");
                }
            }
            catch (Exception)
            {
                chk = false;
                MessageBox.Show("Customer Detail is not given");
            }
            if (Convert.ToDouble(grtottxt.Text) <= 0)
            {
                chk = false;
                MessageBox.Show("Item Detail is not given");
            }
            return chk;
        }
        double rate_pre_if()
        {
            double rate = 0;
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            string qurry = "select Id from [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Invoice_T] where receiver_id_fkey ='" + Cuscmbx.SelectedValue + "'";
            SqlCommand cmd = new SqlCommand(qurry, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            con.Open();
            con.Open();
            try
            {
                sda.Fill(ds);
            }
            catch (Exception)
            { }
            int i = 0;
            while (i < ds.Rows.Count - 1)
            {
                qurry = "select rate from [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Invo_D_T] where Invo_ID_fkey ='" + ds.Rows[i][0].ToString() + "' And item_no_fkey='" + itemcmbx.Text + "'";
                cmd = new SqlCommand(qurry, con);
                SqlDataReader myreader;
                myreader = cmd.ExecuteReader();
                try
                {
                    string srate = "";
                    bool chk = true;
                    while (myreader.Read())
                    {
                        if (rate != myreader.GetDouble(0) && i > 0)
                        {
                            srate += myreader.GetDouble(0) + ", ";
                            if (rate < myreader.GetDouble(0))
                            {
                                rate = myreader.GetDouble(0);
                            }
                        }
                        else if (chk)
                        {
                            srate = myreader.GetDouble(0) + ", ";
                            chk = false;
                            rate = myreader.GetDouble(0);
                        }
                    }

                    info.Text = "Already given at following " + srate; ;
                }
                catch (Exception)
                { }
            }
            return rate;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            bool adchk = true;
            try
            {
                if (Convert.ToDouble(qntytxt.Text) <= 0 || Convert.ToDouble(ratetxt.Text) <= 0)
                {
                    MessageBox.Show("Invalid Entry, please check quantity and rate");
                    adchk = false;
                }
                SqlConnection con5 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LedgerDB"].ConnectionString);
                string tname = Calculator.ret_item_no(itemcmbx.SelectedValue.ToString());
                string querry = "select * from [Item_" + tname + "_Ledge] ";
                SqlCommand cmd = new SqlCommand(querry, con5);
                con5.Open();
                SqlDataReader myreader = cmd.ExecuteReader();
                double crd = 0, dbt = 0, bal = 0;
                try
                {
                    while (myreader.Read())
                    {

                        crd += myreader.GetDouble(4);
                        dbt += myreader.GetDouble(5);
                        bal = crd - dbt;
                    }
                }
                catch (Exception)
                {

                }
                con5.Close();
                if (bal < Convert.ToDouble(qntytxt.Text))
                {
                    MessageBox.Show("You dont have sufficient quantity in stock.\nAvailable quantity is " + bal + ". ");
                    qntytxt.ForeColor = Color.DarkRed;
                    adchk = false;
                }
            }
            catch (Exception)
            {
                adchk = false;
                MessageBox.Show("Invalid Entry, please check quantity and rate");
            }
            if (adchk)
            {
                string itemno = "0";
                try
                {
                    itemno = Calculator.ret_item_no(itemcmbx.SelectedValue.ToString());
                    amt = Convert.ToDouble(qntytxt.Text) * Convert.ToDouble(ratetxt.Text);
                    itemdtdgv.ReadOnly = false;
                    itemdtdgv.Rows.Add(itemno, descrptxt.Text, hsntxt.Text, qntytxt.Text, ratetxt.Text, amt.ToString());
                    itemdtdgv.ReadOnly = true;
                    cal(itemdtdgv.RowCount - 1, 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (Convert.ToDouble(grtottxt.Text) >= 50000)
            {
                ewaybilltxt.Show();
                ewaybil_lbl.Show();
            }
            itemcmbx.Text = "Select item";
            descrptxt.ReadOnly = false;
            hsntxt.ReadOnly = false;

            descrptxt.Clear();
            hsntxt.Clear();
            ratetxt.Clear();
            qntytxt.Clear();

            descrptxt.ReadOnly = true;
            hsntxt.ReadOnly = true;
        }
        private void itemcmbx_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        private void newbtn_Click(object sender, EventArgs e)
        {
            Cuscmbx.Text = "Select Customer";
            itemcmbx.Text = "Select Item";
            invoidtxt.Enabled = true;
            invoidtxt.Text = "#######";
            invoidtxt.Enabled = false;
            discrattxt.Text = "0";
            itemcmbx.Text = "";
            descrptxt.Text = "";
            hsntxt.Text = "";
            ratetxt.Text = "";
            qntytxt.Text = "";
            packagingtxt.Text = "0";
            transport_chargetxt.Text = "0";
            newbtn.Visible = false;
            Edit();
            dgvDelete();
            savebtn.Enabled = true;
            dsicardbtn.Enabled = true;

        }
        private void savbtn_Click(object sender, EventArgs e)
        {
            if (check_condition())
            {
                SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
                string qurry = "insert into [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Invoice_T] ( receiver_id_fkey, date_, discrate, author_ID_fkey, transportation,[ewaybill_no.],transportation_charge,packaging,[payment_terms.]) values('" + Cuscmbx.SelectedValue.ToString() + "','" + DateTime.Now.ToString("yyyyMMdd") + "','" + discrattxt.Text + "','" + emplbl.Text + "','" + transportcmb.SelectedValue + "','" + ewaybilltxt.Text + "','" + transport_chargetxt.Text + "','" + packagingtxt.Text + "','" + paymenttermtxt.Text + "') ";
                SqlCommand cmd1 = new SqlCommand(qurry, con1);
                con1.Open();

                try
                {
                    cmd1.ExecuteNonQuery();
                    invoidtxt.Text = lastinvo_no().ToString();
                    Ledger_Process.Ledger_Update("Company_" + Calculator.get_temp_data(Constant_And_Variable.Company_id), "Customer_" + Cuscmbx.SelectedValue.ToString(), "Credit", invoidtxt.Text, Convert.ToDouble(grtottxt.Text), "Sarees "+pcstxt.Text+ " issued @ discount " + discrattxt.Text+"%");
                    Ledger_Process.Ledger_Update_GST(Calculator.get_temp_data(Constant_And_Variable.Company_id), Calculator.get_temp_data(Constant_And_Variable.Customer_id), "Debit", invoidtxt.Text, Convert.ToDouble(tottxt.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                con1.Close();
                SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
                int n = 0;
                while (n < itemdtdgv.Rows.Count)
                {
                    qurry = "insert into [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Invo_D_T] (Invo_ID_fkey, item_no_fkey, rate, qnty) values('" + invoidtxt.Text + "','" + itemdtdgv.Rows[n].Cells[0].Value + "','" + itemdtdgv.Rows[n].Cells[4].Value + "','" + itemdtdgv.Rows[n].Cells[3].Value + "') ";
                    SqlCommand cmd2 = new SqlCommand(qurry, con2);
                    con2.Open();
                    try
                    {

                        cmd2.ExecuteNonQuery();
                        Ledger_Process.Item_Update(comlbl.Text, "Item_" + itemdtdgv.Rows[n].Cells[0].Value.ToString(), "Debit", invoidtxt.Text, Convert.ToInt32(itemdtdgv.Rows[n].Cells[3].Value.ToString()));
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
                Calculator.register_selected_data(Constant_And_Variable.Doc_date, invoidtxt.Text);
                savebtn.Enabled = false;
                dsicardbtn.Enabled = false;
                newbtn.Visible = true;
                prntbtn.Visible = true;
            }
        }
        private void dsicardbtn_Click(object sender, EventArgs e)
        {
            Cuscmbx.Text = "Select Customer";
            discrattxt.Text = "0";
            itemcmbx.Text = "Select Item";
            descrptxt.Text = "";
            hsntxt.Text = "";
            ratetxt.Text = "";
            qntytxt.Text = "";
            packagingtxt.Text = "0";
            transport_chargetxt.Text = "0";
            dgvDelete();
        }
        private void delbtn_Click(object sender, EventArgs e)
        {
            if (this.itemdtdgv.SelectedRows.Count > 0)
            {
                
                try
                {
                    cal(itemdtdgv.SelectedRows[0].Index, -1);
                    itemdtdgv.Rows.RemoveAt(itemdtdgv.SelectedRows[0].Index);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void itemcmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            hsntxt.ReadOnly = false;
            descrptxt.ReadOnly = false;
            //qntytxt.ForeColor = Color.Black;
            SqlConnection con4 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
            con4.Open();
            string qurry = "Select * from Stock_T where Id=" + itemcmbx.SelectedValue + "";
            SqlCommand cmd1 = new SqlCommand(qurry, con4);
            try
            {
                SqlDataReader myreader = cmd1.ExecuteReader();
                while (myreader.Read())
                {
                    descrptxt.Text = myreader.GetString(2);
                    hsntxt.Text = myreader.GetString(3);
                }
            }
            catch (Exception)
            { }
            con4.Close();
            //qurry = "Select * from rate_T where stock_ID_fkey='" + Calculator.ret_item_no(itemcmbx.SelectedValue.ToString()) + "'";
            //SqlCommand cmd2 = new SqlCommand(qurry, con4);
            //con4.Open();
            //try
            //{
            //    SqlDataReader myreader = cmd2.ExecuteReader();
            //    while (myreader.Read())
            //    {
            //        ratetxt.Text = myreader.GetDouble(4).ToString();
            //    }
            //}
            //catch (Exception)
            //{ }
            //con4.Close();
            hsntxt.ReadOnly = true;
            descrptxt.ReadOnly = true;
            if (rate_pre_if() > 0)
            {
                info.Visible = true;
                ratetxt.Text = rate_pre_if().ToString();
            }
            else
            {
                info.Visible = false;
            }
        }
        private void prntbtn_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
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
        private void packagingtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(packagingtxt.Text) > 0)
                {
                    subcal();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Entry");
                packagingtxt.Text = "0";
            }
        }
        private void transport_chargetxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(transport_chargetxt.Text) > 0)
                {
                    subcal();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Entry");
                transport_chargetxt.Text = "0";
                subcal();
            }

        }

        private void discrattxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(discrattxt.Text) > 0)
                {
                    subcal();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Entry");
                discrattxt.Text = "0";
                subcal();
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float size = 10;
            int x = 325, y = 30;
            int tempy = 0;
            Font plain_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Regular);
            Font bold_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Bold);

            StringFormat formatLeft = new StringFormat(StringFormatFlags.NoClip);
            StringFormat formatCenter = new StringFormat(formatLeft);
            StringFormat formatRight = new StringFormat(formatLeft);

            formatCenter.Alignment = StringAlignment.Center;
            formatRight.Alignment = StringAlignment.Far;
            formatLeft.Alignment = StringAlignment.Near;
            //print first party gst            
            PointF pth = new PointF(x, y);
            e.Graphics.DrawString("GST No." + Calculator.ret_Gst(Calculator.get_temp_data(Constant_And_Variable.Company_id), Constant_And_Variable.CompanyDB).ToString(), bold_font, Brushes.Black, pth);
            //print first party name
            x = 250; y += 10; size = 25;
            bold_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Bold);
            pth = new PointF(x, y);
            e.Graphics.DrawString(Calculator.ret_Name(Calculator.get_temp_data(Constant_And_Variable.Company_id), Constant_And_Variable.CompanyDB).ToString(), bold_font, Brushes.Black, pth);
            //print first party address
            x = 150; y += 35; size = 10;
            bold_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Bold);
            pth = new PointF(x, y);
            e.Graphics.DrawString(Calculator.ret_Address(Calculator.get_temp_data(Constant_And_Variable.Company_id), Constant_And_Variable.CompanyDB).ToString(), bold_font, Brushes.Black, pth);

            x = 40; tempy = y += 20; size = 2;
            int wd = 550, ht = 100;
            Pen pen = new Pen(Brushes.Black, size);
            Rectangle rect = new Rectangle(x, y, wd, ht);
            e.Graphics.DrawRectangle(pen, rect);
            //print second party name
            x = 40; y = y += 0; size = 15;
            bold_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Bold);
            pth = new PointF(x, y);
            SizeF layoutsize = new SizeF(wd, ht);
            RectangleF layout = new RectangleF(pth, layoutsize);
            e.Graphics.DrawString(Calculator.ret_Name(Calculator.get_temp_data(Constant_And_Variable.Customer_id), Constant_And_Variable.CustomerDB).ToString(), bold_font, Brushes.Black, layout, formatRight);
            e.Graphics.DrawString("M/s:", plain_font, Brushes.Black, layout, formatLeft);
            //print second party Alias
            x = 40; y += 20; size = 10;
            plain_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Regular);
            pth = new PointF(x, y);
            layoutsize = new SizeF(wd, ht);
            layout = new RectangleF(pth, layoutsize);
            e.Graphics.DrawString(Calculator.ret_Alias(Calculator.get_temp_data(Constant_And_Variable.Customer_id), Constant_And_Variable.CustomerDB), plain_font, Brushes.Black, layout, formatRight);
            //print second party address
            x = 40; y += 20; size = 10;
            pth = new PointF(x, y);
            layoutsize = new SizeF(wd, ht);
            layout = new RectangleF(pth, layoutsize);
            e.Graphics.DrawString(Calculator.ret_Address(Calculator.get_temp_data(Constant_And_Variable.Customer_id), Constant_And_Variable.CustomerDB), plain_font, Brushes.Black, layout, formatRight);
            //print second party city
            x = 40; y += 20; size = 10;
            pth = new PointF(x, y);
            layoutsize = new SizeF(wd, ht);
            layout = new RectangleF(pth, layoutsize);
            e.Graphics.DrawString(Calculator.ret_City(Calculator.get_temp_data(Constant_And_Variable.Customer_id), Constant_And_Variable.CustomerDB), plain_font, Brushes.Black, layout, formatRight);
            //print second party state & pincode
            x = 40; y += 20; size = 10;
            pth = new PointF(x, y);
            layoutsize = new SizeF(wd, ht);
            layout = new RectangleF(pth, layoutsize);
            string sp = Calculator.ret_State(Calculator.get_temp_data(Constant_And_Variable.Customer_id), Constant_And_Variable.CustomerDB) + "-" + Calculator.ret_Pincode(Calculator.get_temp_data(Constant_And_Variable.Customer_id), Constant_And_Variable.CustomerDB);
            e.Graphics.DrawString(sp, plain_font, Brushes.Black, layout, formatRight);
            //print second party gst
            e.Graphics.DrawString("GSTIN :" + Calculator.ret_Gst(Calculator.get_temp_data(Constant_And_Variable.Customer_id), Constant_And_Variable.CustomerDB), plain_font, Brushes.Black, layout, formatLeft);

            x = 40 + wd + 20; tempy += 0; size = 2;
            wd = 180; ht = 40;
            pen = new Pen(Brushes.Black, size);
            rect = new Rectangle(x, tempy, wd, ht);
            e.Graphics.DrawRectangle(pen, rect);
            //print date
            size = 10; tempy = tempy += 5;
            pth = new PointF(x, tempy);
            layoutsize = new SizeF(wd, ht);
            layout = new RectangleF(pth, layoutsize);
            bold_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Bold);
            plain_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Regular);
            e.Graphics.DrawString("Date :", plain_font, Brushes.Black, layout, formatLeft);
            e.Graphics.DrawString(datetxt.Text, bold_font, Brushes.Black, layout, formatRight);
            //print invoice no.
            tempy += 20;
            pth = new PointF(x, tempy);
            layoutsize = new SizeF(wd, ht);
            layout = new RectangleF(pth, layoutsize);
            e.Graphics.DrawString("Invo No.: ", plain_font, Brushes.Black, layout, formatLeft);
            e.Graphics.DrawString(invoidtxt.Text, bold_font, Brushes.Black, layout, formatRight);

            //print eway bill no.
            x = 40; y += 40;
            wd = 750; ht = 20; size = 20;
            pth = new PointF(x, y);
            layoutsize = new SizeF(wd, ht);
            layout = new RectangleF(pth, layoutsize);
            if (Convert.ToDouble(grtottxt.Text) > 50000)
            {
                e.Graphics.DrawString("Eway Bill :" + ewaybilltxt.Text, bold_font, Brushes.Black, layout, formatCenter);
            }

            //print detail table
            x = 40; y += 40; size = 2;
            wd = 750; ht = 20;
            pen = new Pen(Brushes.Black, size);
            rect = new Rectangle(x, y, wd, ht);
            e.Graphics.FillRectangle(Brushes.LightGray, rect);
            e.Graphics.DrawRectangle(pen, rect);

            int i = 0;
            int chk = 1;
            layout.Y += 20;
            while (i <= 20)
            {
                layout.Y += 20;
                rect = new Rectangle(Convert.ToInt32(layout.X), Convert.ToInt32(layout.Y), Convert.ToInt32(layout.Width), Convert.ToInt32(layout.Height));
                if (chk == 1)
                {
                    e.Graphics.FillRectangle(Brushes.LightGray, rect);
                }
                chk *= -1;
                i++;
            }

            x = 40; y += 0; size = 2;
            wd = 41; ht = 420;
            pen = new Pen(Brushes.Black, size);
            rect = new Rectangle(x, y, wd, ht);
            e.Graphics.DrawRectangle(pen, rect);
            pth = new PointF(x, y + 5);
            layoutsize = new SizeF(wd, 20);
            RectangleF Serial_layout = new RectangleF(pth, layoutsize);

            x += wd; wd = 70;
            rect = new Rectangle(x, y, wd, ht);
            e.Graphics.DrawRectangle(pen, rect);
            pth = new PointF(x, y + 5);
            layoutsize = new SizeF(wd, 20);
            RectangleF Itmno_layout = new RectangleF(pth, layoutsize);

            x += wd; wd = 324;
            rect = new Rectangle(x, y, wd, ht);
            e.Graphics.DrawRectangle(pen, rect);
            pth = new PointF(x, y + 5);
            layoutsize = new SizeF(wd, 20);
            RectangleF Descript_layout = new RectangleF(pth, layoutsize);

            x += wd; wd = 83;
            rect = new Rectangle(x, y, wd, ht);
            e.Graphics.DrawRectangle(pen, rect);
            pth = new PointF(x, y + 5);
            layoutsize = new SizeF(wd, 20);
            RectangleF HSN_layout = new RectangleF(pth, layoutsize);

            x += wd; wd = 41;
            rect = new Rectangle(x, y, wd, ht);
            e.Graphics.DrawRectangle(pen, rect);
            pth = new PointF(x, y + 5);
            layoutsize = new SizeF(wd, 20);
            RectangleF Qnty_layout = new RectangleF(pth, layoutsize);

            x += wd; wd = 83;
            rect = new Rectangle(x, y, wd, ht);
            e.Graphics.DrawRectangle(pen, rect);
            pth = new PointF(x, y + 5);
            layoutsize = new SizeF(wd, 20);
            RectangleF Rate_layout = new RectangleF(pth, layoutsize);

            x += wd; wd = 108;
            rect = new Rectangle(x, y, wd, ht);
            e.Graphics.DrawRectangle(pen, rect);
            pth = new PointF(x, y + 5);
            layoutsize = new SizeF(wd, 20);
            RectangleF Amt_layout = new RectangleF(pth, layoutsize);
            //print Header
            size = 8;
            bold_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Bold);
            e.Graphics.DrawString("S No.", bold_font, Brushes.Black, Serial_layout, formatCenter);
            e.Graphics.DrawString(itemdtdgv.Columns[0].HeaderText, bold_font, Brushes.Black, Itmno_layout, formatCenter);
            e.Graphics.DrawString(itemdtdgv.Columns[1].HeaderText, bold_font, Brushes.Black, Descript_layout, formatCenter);
            e.Graphics.DrawString(itemdtdgv.Columns[2].HeaderText, bold_font, Brushes.Black, HSN_layout, formatCenter);
            e.Graphics.DrawString("Qnty", bold_font, Brushes.Black, Qnty_layout, formatCenter);
            e.Graphics.DrawString(itemdtdgv.Columns[4].HeaderText, bold_font, Brushes.Black, Rate_layout, formatCenter);
            e.Graphics.DrawString(itemdtdgv.Columns[5].HeaderText, bold_font, Brushes.Black, Amt_layout, formatCenter);
            i = 0;
            while (i < itemdtdgv.RowCount)
            {
                Serial_layout.Y += 20;
                e.Graphics.DrawString((i + 1).ToString(), bold_font, Brushes.Black, Serial_layout, formatCenter);
                Itmno_layout.Y += 20;
                e.Graphics.DrawString((itemdtdgv.Rows[i].Cells[0].Value).ToString(), bold_font, Brushes.Black, Itmno_layout, formatCenter);
                Descript_layout.Y += 20;
                e.Graphics.DrawString((itemdtdgv.Rows[i].Cells[1].Value).ToString(), bold_font, Brushes.Black, Descript_layout, formatCenter);
                HSN_layout.Y += 20;
                e.Graphics.DrawString((itemdtdgv.Rows[i].Cells[2].Value).ToString(), bold_font, Brushes.Black, HSN_layout, formatCenter);
                Qnty_layout.Y += 20;
                e.Graphics.DrawString((itemdtdgv.Rows[i].Cells[3].Value).ToString(), bold_font, Brushes.Black, Qnty_layout, formatCenter);
                Rate_layout.Y += 20;
                e.Graphics.DrawString((itemdtdgv.Rows[i].Cells[4].Value).ToString(), bold_font, Brushes.Black, Rate_layout, formatCenter);
                Amt_layout.Y += 20;
                e.Graphics.DrawString((itemdtdgv.Rows[i].Cells[5].Value).ToString(), bold_font, Brushes.Black, Amt_layout, formatCenter);
                i++;
            }
            //print quantity details
            HSN_layout.Y = y + ht + 3;
            e.Graphics.DrawString("Pieces", bold_font, Brushes.Black, HSN_layout, formatCenter);
            Qnty_layout.Y = y + ht + 3;
            e.Graphics.DrawString(pcstxt.Text, bold_font, Brushes.Black, Qnty_layout, formatCenter);
            rect = new Rectangle(Convert.ToInt32(Qnty_layout.X), Convert.ToInt32(Qnty_layout.Y) - 3, Convert.ToInt32(Qnty_layout.Width), Convert.ToInt32(Qnty_layout.Height));
            e.Graphics.DrawRectangle(pen, rect);
            //print subtotal
            Amt_layout.Y = HSN_layout.Y + 20;
            layout = Amt_layout;
            layout.Height = 20;
            Amt_layout.Width += 100;
            Amt_layout.X -= Amt_layout.Width;
            e.Graphics.DrawString("Subtotal ", bold_font, Brushes.Black, Amt_layout, formatRight);
            Amt_layout.X += Amt_layout.Width;
            Amt_layout.Width -= 100;
            float yc = Amt_layout.Y;
            e.Graphics.DrawString(subttxt.Text, bold_font, Brushes.Black, Amt_layout, formatCenter);
            if (Convert.ToDouble(discrattxt.Text) != 0)
            {
                layout.Height += 20;
                Amt_layout.Y += 20;
                Amt_layout.Width += 100;
                Amt_layout.X -= Amt_layout.Width;
                e.Graphics.DrawString("Discount @ " + discrattxt.Text + "% ", bold_font, Brushes.Black, Amt_layout, formatRight);
                Amt_layout.X += Amt_layout.Width;
                Amt_layout.Width -= 100;
                e.Graphics.DrawString(disctxt.Text, bold_font, Brushes.Black, Amt_layout, formatCenter);
                layout.Height += 20;
                Amt_layout.Y += 20;
                Amt_layout.Width += 100;
                Amt_layout.X -= Amt_layout.Width;
                e.Graphics.DrawString("Total With Discount ", bold_font, Brushes.Black, Amt_layout, formatRight);
                Amt_layout.X += Amt_layout.Width;
                Amt_layout.Width -= 100;
                e.Graphics.DrawString(tottxt.Text, bold_font, Brushes.Black, Amt_layout, formatCenter);
            }
            yc += 40;
            if (Convert.ToDouble(igsttxt.Text) != 0)
            {
                layout.Height += 20;
                Amt_layout.Y += 20;
                Amt_layout.Width += 100;
                Amt_layout.X -= Amt_layout.Width;
                e.Graphics.DrawString("IGST @ 5% ", bold_font, Brushes.Black, Amt_layout, formatRight);
                Amt_layout.X += Amt_layout.Width;
                Amt_layout.Width -= 100;
                e.Graphics.DrawString(igsttxt.Text, bold_font, Brushes.Black, Amt_layout, formatCenter);
            }
            else
            {
                layout.Height += 20;
                Amt_layout.Y += 20;
                Amt_layout.Width += 100;
                Amt_layout.X -= Amt_layout.Width;
                e.Graphics.DrawString("SGST @ 2.5% ", bold_font, Brushes.Black, Amt_layout, formatRight);
                Amt_layout.X += Amt_layout.Width;
                Amt_layout.Width -= 100;
                e.Graphics.DrawString(sgsttxt.Text, bold_font, Brushes.Black, Amt_layout, formatCenter);
                layout.Height += 20;
                Amt_layout.Y += 20;
                Amt_layout.Width += 100;
                Amt_layout.X -= Amt_layout.Width;
                e.Graphics.DrawString("CGST @ 2.5% ", bold_font, Brushes.Black, Amt_layout, formatRight);
                Amt_layout.X += Amt_layout.Width;
                Amt_layout.Width -= 100;
                e.Graphics.DrawString(cgsttxt.Text, bold_font, Brushes.Black, Amt_layout, formatCenter);
            }
            yc += 40;
            try
            {
                if (Convert.ToDouble(packagingtxt.Text) > 0)
                {
                    layout.Height += 20;
                    Amt_layout.Y += 20;
                    Amt_layout.Width += 100;
                    Amt_layout.X -= Amt_layout.Width;
                    e.Graphics.DrawString(packlbl.Text, bold_font, Brushes.Black, Amt_layout, formatRight);
                    Amt_layout.X += Amt_layout.Width;
                    Amt_layout.Width -= 100;
                    e.Graphics.DrawString(packagingtxt.Text, bold_font, Brushes.Black, Amt_layout, formatCenter);
                }
            }
            catch (Exception)
            {
                packagingtxt.Text = "0";
            }
            yc += 20;
            try
            {
                if (Convert.ToDouble(transport_chargetxt.Text) > 0)
                {
                    layout.Height += 20;
                    Amt_layout.Y += 20;
                    Amt_layout.Width += 100;
                    Amt_layout.X -= Amt_layout.Width;
                    e.Graphics.DrawString(packlbl.Text, bold_font, Brushes.Black, Amt_layout, formatRight);
                    Amt_layout.X += Amt_layout.Width;
                    Amt_layout.Width -= 100;
                    e.Graphics.DrawString(transport_chargetxt.Text, bold_font, Brushes.Black, Amt_layout, formatCenter);
                }
            }
            catch (Exception)
            {
                transport_chargetxt.Text = "0";
            }
            yc += 20;
            rect = new Rectangle(Convert.ToInt32(layout.X), Convert.ToInt32(layout.Y) - 3, Convert.ToInt32(layout.Width), Convert.ToInt32(layout.Height));
            e.Graphics.DrawRectangle(pen, rect);

            Amt_layout.Y += 20;
            layout.Height = 20;
            Amt_layout.Y += 20;
            size = 15;
            Amt_layout.Width += 100;
            Amt_layout.X -= Amt_layout.Width;
            bold_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Bold);
            e.Graphics.DrawString("Grand Total ", bold_font, Brushes.Black, Amt_layout, formatRight);
            Amt_layout.X += Amt_layout.Width;
            Amt_layout.Width -= 100;
            e.Graphics.DrawString(grtottxt.Text, bold_font, Brushes.Black, Amt_layout, formatCenter);
            rect = new Rectangle(Convert.ToInt32(Amt_layout.X), Convert.ToInt32(Amt_layout.Y), Convert.ToInt32(Amt_layout.Width), Convert.ToInt32(Amt_layout.Height) + 5);
            e.Graphics.DrawRectangle(pen, rect);
            yc += 40;
            size = 10;
            layout.Y = yc + 40;
            bold_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Bold);
            layout = new RectangleF(40, layout.Y + 40 + layout.Height, Serial_layout.Width + Itmno_layout.Width, 20);
            e.Graphics.DrawString("In Words", plain_font, Brushes.Black, layout, formatCenter);
            rect = new Rectangle(Convert.ToInt32(layout.X), Convert.ToInt32(layout.Y) - 3, Convert.ToInt32(layout.Width), Convert.ToInt32(layout.Height));
            e.Graphics.DrawRectangle(pen, rect);
            layout.X += layout.Width;
            layout.Width = Descript_layout.Width + HSN_layout.Width + Qnty_layout.Width + Rate_layout.Width + Amt_layout.Width;
            e.Graphics.DrawString(numwrdtxt.Text, bold_font, Brushes.Black, layout, formatCenter);
            rect.X = Convert.ToInt32(layout.X);
            rect.Width = Convert.ToInt32(layout.Width);
            e.Graphics.DrawRectangle(pen, rect);

            layout.X = 40;
            layout.Y += 40;
            layout.Height = 80;
            layout.Width = Qnty_layout.Width + Rate_layout.Width + Amt_layout.Width;
            rect = new Rectangle(Convert.ToInt32(layout.X), Convert.ToInt32(layout.Y) - 3, Convert.ToInt32(layout.Width), Convert.ToInt32(layout.Height));
            e.Graphics.DrawRectangle(pen, rect);
            e.Graphics.DrawString("Account Details", bold_font, Brushes.Black, layout, formatCenter);


            layout.X += Serial_layout.Width + Itmno_layout.Width + Descript_layout.Width + HSN_layout.Width;
            rect.X = Convert.ToInt32(layout.X);
            e.Graphics.DrawRectangle(pen, rect);
            rect.Height = 20;
            e.Graphics.FillRectangle(Brushes.LightGray, rect);
            e.Graphics.DrawRectangle(pen, rect);
            e.Graphics.DrawString("Proprietor", bold_font, Brushes.Black, layout, formatCenter);

            layout.X = 40;
            layout.Y += layout.Height + 40;
            layout.Height = 20;
            layout.Width = 750;
            e.Graphics.DrawString("SUBJECT TO VARANASI JURIDICTION ONLY", bold_font, Brushes.Black, layout, formatCenter);
        }

        private void grtottxt_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(grtottxt.Text) > 50000)
            {
                ewaybilltxt.Visible = true;
                ewaybil_lbl.Visible = true;
            }
            else
            {
                ewaybilltxt.Visible = false;
                ewaybil_lbl.Visible = false;
            }
        }

        private void totlbl_Click(object sender, EventArgs e)
        {

        }

        private void invoice_Load(object sender, EventArgs e)
        {
            DataTable dst = new DataTable();

        }
    }
}
