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
    public partial class Job_Challan_Recieve : Form
    {
        public Job_Challan_Recieve(string callas)
        {
            InitializeComponent();
            CheckCallMethod(callas);
        }
        double amt = 0;
        int pos = 0;
        private DataTable ds = new DataTable();

        void fillchallancombo()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Tranx"].ConnectionString);
            con.Open();
            string qurry = "Select * from [Job_Challan_T] ";
            SqlCommand cmd = new SqlCommand(qurry, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dataDB = new DataTable();
            try
            {
                sda.Fill(dataDB);
                challancmb.ValueMember = "Id";
                challancmb.DisplayMember = Calculator.ret_Name("send_id_fkey", Constant_And_Variable.TanxDB);
                challancmb.DataSource = dataDB;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            challancmb.Text = "Select Challan";
        }

        void fillservicecombo()
        {

            if (challancmb.Text != "Select Challan")
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JobWorkDB"].ConnectionString);
                con.Open();
                string qurry = "Select * from [Design_T] where Job_ID_fkey='" + worktxt.Text + "'";
                SqlCommand cmd = new SqlCommand(qurry, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                try
                {
                    DataTable dataDB = new DataTable();
                    sda.Fill(dataDB);
                    designcmb.ValueMember = "Id";
                    designcmb.DisplayMember = "Design";
                    designcmb.DataSource = dataDB;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                designcmb.Text = "Select Work";
            }
        }
        int lastbill_no()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            string qurry = "Select Id from ["+Calculator.get_temp_data(Constant_And_Variable.Company_id)+"Job_Recieve_Challan_T] ";
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
        //string ret_work_no(string itemno)
        //{
        //    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
        //    con.Open();
        //    string qurry = "Select * from Stock_T where Id='" + itemno + "'";
        //    SqlCommand cmd = new SqlCommand(qurry, con);
        //    string item_no = null;
        //    try
        //    {
        //        SqlDataReader dataDB;
        //        dataDB = cmd.ExecuteReader();
        //        while (dataDB.Read())
        //        {
        //            item_no = dataDB.GetString(1);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    return item_no;
        //}
        void setdate()
        {
            datetxt.ReadOnly = false;
            datetxt.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            datetxt.ReadOnly = true;
        }
        void cal(int n, int sign)
        {
            numofitmtxt.ReadOnly = false;
            tottxt.ReadOnly = false;
            grtottxt.ReadOnly = false;
            pcstxt.ReadOnly = false;
            disctxt.ReadOnly = false;
            subttxt.ReadOnly = false;
            discrattxt.ReadOnly = false;
            numwrdtxt.ReadOnly = false;
            itemdtdgv.ReadOnly = false;
            stockvaluetxt.ReadOnly = false;

            numofitmtxt.Text = Convert.ToString(itemdtdgv.Rows.Count);
            stockvaluetxt.Text = Convert.ToString(Convert.ToDouble(stockvaluetxt.Text) + Convert.ToDouble(itemdtdgv.Rows[n].Cells[3].Value) * ret_item_rate(itemdtdgv.Rows[n].Cells[1].Value.ToString()));
            pcstxt.Text = Convert.ToString(Convert.ToDouble(pcstxt.Text) + Convert.ToDouble(itemdtdgv.Rows[n].Cells[3].Value) * sign);
            subttxt.Text = Convert.ToString(Convert.ToDouble(subttxt.Text) + Convert.ToDouble(itemdtdgv.Rows[n].Cells[5].Value) * sign);
            disctxt.Text = Convert.ToString(Convert.ToDouble(subttxt.Text) * (Convert.ToDouble(discrattxt.Text) / 100));
            tottxt.Text = Convert.ToString(Convert.ToDouble(subttxt.Text) - Convert.ToDouble(disctxt.Text));
            grtottxt.Text = Convert.ToString(Convert.ToDouble(tottxt.Text));            
            numwrdtxt.Text = NumToWord.ConvertNumbertoWords(Convert.ToInt32(Convert.ToDouble(grtottxt.Text)));

            numofitmtxt.ReadOnly = true;
            tottxt.ReadOnly = true;
            grtottxt.ReadOnly = true;
            pcstxt.ReadOnly = true;
            disctxt.ReadOnly = true;
            subttxt.ReadOnly = true;
            discrattxt.ReadOnly = true;
            numwrdtxt.ReadOnly = true;
            itemdtdgv.ReadOnly = true;
            stockvaluetxt.ReadOnly = true;
        }        
        bool check_condition()
        {
            bool chk = true;
            if (suppliertxt.Text == "Select Servicer")
            {
                chk = false;
                MessageBox.Show("Supplier Detail is not given");
            }
            if (Convert.ToDouble(grtottxt.Text) <= 0)
            {
                chk = false;
                MessageBox.Show("Item Detail is not given");
            }
            return chk;
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
        private void NavRec(int i = 0)
        {

            Edit();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            billidtxt.Text = ds.Rows[i][0].ToString();
            string qurry = "select * from [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Job_Recieve_Challan_D_T] where Invo_ID_fkey ='" + billidtxt.Text + "'";
            SqlCommand cmd = new SqlCommand(qurry, con);
            datetxt.Text = Convert.ToDateTime(ds.Rows[i][1].ToString()).ToString("dd-MM-yyyy");
            comlbl.Text = ds.Rows[i][2].ToString();
            suppliertxt.Text = Calculator.ret_Name(ds.Rows[i][3].ToString(), Constant_And_Variable.SupplierDB);
            dgvDelete();
            try
            {
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    amt = reader.GetDouble(4) * reader.GetDouble(5);
                    string sitem = reader.GetString(2);
                    string sqnty = reader.GetDouble(4).ToString();
                    string srate = reader.GetDouble(5).ToString();
                    itemdtdgv.Rows.Add(sitem, "0", "0", sqnty, srate, amt.ToString());
                    set_detail();
                    cal(itemdtdgv.Rows.Count - 1, 1);
                }
            }
            catch (Exception)
            {

            }
            con.Close();
            NoEdit();
        }
        void set_detail()
        {
            int i = itemdtdgv.Rows.Count - 1;
            SqlConnection con4 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JobWorkDB"].ConnectionString);
            con4.Open();
            string qurry = "Select * from JobWork_T where Item_no='" + itemdtdgv.Rows[i].Cells[1].Value + "'";
            SqlCommand cmd1 = new SqlCommand(qurry, con4);
            SqlDataReader myreader;
            myreader = cmd1.ExecuteReader();
            try
            {
                while (myreader.Read())
                {
                    itemdtdgv.Rows[i].Cells[2].Value = myreader.GetString(2);
                    itemdtdgv.Rows[i].Cells[3].Value = myreader.GetString(3);
                }
            }
            catch (Exception)
            {

            }
            con4.Close();
        }
        private void NoEdit()
        {
            suppliertxt.Enabled = false;
            designcmb.Enabled = false;
            descrptxt.ReadOnly = true;
            hsntxt.ReadOnly = true;
            ratetxt.ReadOnly = true;
            qntytxt.ReadOnly = true;
            delbtn.Enabled = false;            
            itemdtdgv.ReadOnly = true;
            datetxt.ReadOnly = true;
            recievedbtn.Enabled = false;
            delbtn.Enabled = false;
            billidtxt.ReadOnly = true;
        }
        private void Edit()
        {
            suppliertxt.Enabled = false;
            designcmb.Enabled = false;
            descrptxt.ReadOnly = true;
            hsntxt.ReadOnly = true;
            ratetxt.ReadOnly = true;
            qntytxt.ReadOnly = true;
            delbtn.Enabled = false;
            //new_designchkbx.Enabled = false;
            itemdtdgv.ReadOnly = true;
            datetxt.ReadOnly = true;
            recievedbtn.Enabled = false;
            delbtn.Enabled = false;
            billidtxt.ReadOnly = true;
        }
        void fill_ds()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            string qurry = "select * from [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Job_Recieve_Challan_T]";
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
        double ret_item_rate(string itemno)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
            con.Open();
            string qurry = "Select * from rate_T where stock_ID_fkey='" + itemno + "'";
            SqlCommand cmd = new SqlCommand(qurry, con);
            double rate = 0;
            try
            {
                SqlDataReader dataDB;
                dataDB = cmd.ExecuteReader();
                while (dataDB.Read())
                {
                    rate = dataDB.GetDouble(4);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return rate;
        }
        string ret_service_name(string itemno)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
            con.Open();
            string qurry = "Select * from Stock_T where Id='" + itemno + "'";
            SqlCommand cmd = new SqlCommand(qurry, con);
            string item_no = null;
            try
            {
                SqlDataReader dataDB;
                dataDB = cmd.ExecuteReader();
                while (dataDB.Read())
                {
                    item_no = dataDB.GetString(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return item_no;
        }
        private void CheckCallMethod(string CallAS)
        {
            if (CallAS == "New")
            {
                //do setting
                savebtn.Hide();
                discardbtn.Hide();

                delbtn.Hide();
                prntbtn.Show();
                Nextbtn.Show();
                previousbtn.Show();
                comlbl.Text = "";
                recievedbtn.Show();
                itmlbl.Hide();

                Descrplbl.Show();
                descrptxt.Show();
                hsnlbl.Show();
                hsntxt.Show();
                ratelbl.Show();
                ratetxt.Show();
                qntylbl.Show();
                qntytxt.Show();
                AdItemgrp.Show();

                stockvaluetxt.Text = "0";
                ratetxt.Text = "0";
                qntytxt.Text = "0";
                discrattxt.Text = "0";
                numofitmtxt.Text = "0";
                tottxt.Text = "0";
                grtottxt.Text = "0";
                pcstxt.Text = "0";
                disctxt.Text = "0";
                subttxt.Text = "0";
                discrattxt.Text = "0";
                numwrdtxt.Text = "Zero";
                fillservicecombo();
                //fillItmcombo();
                setdate();
                datetxt.ReadOnly = true;
                numofitmtxt.ReadOnly = true;
                tottxt.ReadOnly = true;
                grtottxt.ReadOnly = true;
                pcstxt.ReadOnly = true;
                disctxt.ReadOnly = true;
                subttxt.ReadOnly = true;
                discrattxt.ReadOnly = true;
                numwrdtxt.ReadOnly = true;

                fill_ds();
                NavRec();

            }
            else if (CallAS == "View")
            {
                //do setting
                savebtn.Hide();
                discardbtn.Hide();
                //newbtn.Hide();
                delbtn.Hide();
                prntbtn.Show();
                Nextbtn.Show();
                previousbtn.Show();
                comlbl.Text = "";
                //addbtn.Hide();
                itmlbl.Hide();
                //itemcmbx.Hide();
                Descrplbl.Hide();
                descrptxt.Hide();
                hsnlbl.Hide();
                hsntxt.Hide();
                ratelbl.Hide();
                ratetxt.Hide();
                qntylbl.Hide();
                qntytxt.Hide();
                AdItemgrp.Hide();

                stockvaluetxt.Text = "0";
                ratetxt.Text = "0";
                qntytxt.Text = "0";
                discrattxt.Text = "0";
                numofitmtxt.Text = "0";
                tottxt.Text = "0";
                grtottxt.Text = "0";
                pcstxt.Text = "0";
                disctxt.Text = "0";
                subttxt.Text = "0";
                discrattxt.Text = "0";
                numwrdtxt.Text = "Zero";
                //fillservicercombo();
                //fillItmcombo();
                setdate();
                datetxt.ReadOnly = true;
                //newbtn.Visible = false;
                numofitmtxt.ReadOnly = true;
                tottxt.ReadOnly = true;
                grtottxt.ReadOnly = true;
                pcstxt.ReadOnly = true;
                disctxt.ReadOnly = true;
                subttxt.ReadOnly = true;
                discrattxt.ReadOnly = true;
                numwrdtxt.ReadOnly = true;
                //new_itemchbx.Visible = false;

                fill_ds();
                NavRec();
            }
            else if (CallAS == "Edit")
            {
                //do setting
            }
        }
        void add_new_item(int n)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JobWorkDB"].ConnectionString);
            con.Open();
            string qurry = "select Id from Design_T where Item_no ='" + itemdtdgv.Rows[n].Cells[1].Value + "'";
            SqlDataAdapter sda = new SqlDataAdapter(qurry, con);
            DataTable ds = new DataTable();

            try
            {
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            string itno = itemdtdgv.Rows[n].Cells[0].Value + "." + (ds.Rows.Count + 1);
            qurry = "insert into Stock_T (Item_no,description, hsn, date_, supplier_ID_fkey, author_ID_fkey) values('" + itno + "','" + itemdtdgv.Rows[n].Cells[1].Value + "','" + itemdtdgv.Rows[n].Cells[2].Value + "','" + DateTime.Now.ToString("yyyyMMdd") + "','" + suppliertxt.Text + "','" + emplbl.Text + "') ";
            SqlCommand cmd1 = new SqlCommand(qurry, con);

            try
            {
                cmd1.ExecuteNonQuery();
                Ledger_Process.New_Ledger("Item_" + itno);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            itemdtdgv.Rows[n].Cells[0].Value = itno;
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
                else if (worktxt.Text == "Select Work")
                {
                    MessageBox.Show("Please Select a job");
                    adchk = false;
                }
                else if (designcmb.Text == "Select Design")
                {
                    MessageBox.Show("Please Select a Design");
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
                    itemno = ret_service_name(designcmb.SelectedValue.ToString());                   
                    amt = Convert.ToDouble(qntytxt.Text) * Convert.ToDouble(ratetxt.Text);
                    itemdtdgv.ReadOnly = false;
                    itemdtdgv.Rows.Add(itemno, designcmb.Text, descrptxt.Text, hsntxt.Text, qntytxt.Text, ratetxt.Text, amt.ToString());
                    itemdtdgv.ReadOnly = true;
                    //new_designchkbx.Checked = false;
                    cal(itemdtdgv.RowCount - 1, 1);
                    descrptxt.ReadOnly = false;
                    hsntxt.ReadOnly = false;

                    descrptxt.Clear();
                    hsntxt.Clear();
                    ratetxt.Clear();
                    qntytxt.Clear();

                    descrptxt.ReadOnly = true;
                    hsntxt.ReadOnly = true;
                    suppliertxt.Enabled = false;
                    designcmb.Text = "Select Design";
                    worktxt.Text = "Select Job";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
        private void prntbtn_Click(object sender, EventArgs e)
        {

        }


        //private void itemcmbx_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    hsntxt.ReadOnly = false;
        //    descrptxt.ReadOnly = false;
        //    SqlConnection con4 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
        //    con4.Open();
        //    string qurry = "Select * from Stock_T where Id='" + designcmb.SelectedValue + "'";
        //    SqlCommand cmd1 = new SqlCommand(qurry, con4);
        //    try
        //    {
        //        SqlDataReader myreader = cmd1.ExecuteReader();
        //        while (myreader.Read())
        //        {
        //            descrptxt.Text = myreader.GetString(2);
        //            hsntxt.Text = myreader.GetString(3);
        //        }
        //    }
        //    catch (Exception)
        //    { }
        //    con4.Close();
        //    designcmb.Text = "Select Item";
        //    qurry = "Select * from rate_T where stock_ID_fkey='" + ret_service_name
        //        (worktxt.Text.ToString()) + "'";
        //    SqlCommand cmd2 = new SqlCommand(qurry, con4);
        //    con4.Open();
        //    try
        //    {
        //        SqlDataReader myreader = cmd2.ExecuteReader();
        //        while (myreader.Read())
        //        {
        //            ratetxt.Text = myreader.GetDouble(4).ToString();
        //        }
        //    }
        //    catch (Exception)
        //    { }
        //    con4.Close();
        //    hsntxt.ReadOnly = true;
        //    descrptxt.ReadOnly = true;
        //}
        private void suppliercmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fillItmcombo();
            if (suppliertxt.Text == "Select Servicer")
            {
                designcmb.Enabled = false;
                //new_designchkbx.Enabled = false;
                recievedbtn.Enabled = false;
                delbtn.Enabled = false;
            }
            else
            {
                designcmb.Enabled = true;
                //new_designchkbx.Enabled = true;
                recievedbtn.Enabled = true;
                delbtn.Enabled = true;
            }
        }

        private void Job_Challan_Load(object sender, EventArgs e)
        {

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

        //private void newbtn_Click_1(object sender, EventArgs e)
        //{
        //    suppliercmbx.Text = "Select Servicer";
        //    billidtxt.Enabled = true;
        //    billidtxt.Text = "#######";
        //    billidtxt.Enabled = false;
        //    discrattxt.Text = "0";
        //    designcmb.Text = "Select Design";
        //    descrptxt.Text = "";
        //    hsntxt.Text = "";
        //    ratetxt.Text = "";
        //    qntytxt.Text = "";
        //    newbtn.Visible = false;
        //    Edit();
        //    dgvDelete();
        //    savebtn.Enabled = true;
        //    discardbtn.Enabled = true;
        //    if (suppliercmbx.Text == "Select Servicer")
        //    {
        //        itemcmbx.Enabled = false;
        //        servicecmb.Enabled = false;
        //        new_itemchbx.Enabled = false;
        //        addbtn.Enabled = false;
        //        delbtn.Enabled = false;
        //    }
        //}

        
        private void discardbtn_Click(object sender, EventArgs e)
        {
            Edit();
            suppliertxt.Text = "Select Servicer";
            dgvDelete();
            discrattxt.Text = "0";
            designcmb.Text = "";
            descrptxt.Text = "";
            hsntxt.Text = "";
            ratetxt.Text = "";
            qntytxt.Text = "";
            if (suppliertxt.Text == "Select Servicer")
            {
                designcmb.Enabled = false;
                //new_designchkbx.Enabled = false;
                recievedbtn.Enabled = false;
                delbtn.Enabled = false;
            }
            else
            {
                designcmb.Enabled = true;
                //new_designchkbx.Enabled = true;
                recievedbtn.Enabled = true;
                delbtn.Enabled = true;
            }
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

        private void delbtn_Click_1(object sender, EventArgs e)
        {
            if (itemdtdgv.SelectedRows.Count > 0)
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

        ////private void suppliercmbx_SelectedIndexChanged(object sender, EventArgs e)
        ////{
        ////    if (suppliertxt.Text == "Select Servicer")
        ////    {
        ////        designcmb.Enabled = false;
        ////        worktxt.Enabled = false;
        ////        //new_designchkbx.Enabled = false;
        ////        recievedbtn.Enabled = false;
        ////        delbtn.Enabled = false;
        ////    }
        ////}


        private void savebtn_Click(object sender, EventArgs e)
        {
            if (check_condition())
            {
                SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
                string qurry = "insert into [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Job_Recieve_Challan_T] (Com_ID_fkey, send_id_fkey, date_, discrate, author_ID_fkey, stock_value) values('" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "','" + suppliertxt.Text.ToString() + "','" + DateTime.Now.ToString("yyyyMMdd") + "','" + discrattxt.Text + "','" + emplbl.Text + "','"+stockvaluetxt.Text+"') ";
                SqlCommand cmd1 = new SqlCommand(qurry, con1);
                con1.Open();

                try
                {
                    cmd1.ExecuteNonQuery();
                    billidtxt.Text = lastbill_no().ToString();
                    Ledger_Process.Ledger_Update("Company_" + Calculator.get_temp_data(Constant_And_Variable.Company_id), "Supplier_" + suppliertxt.Text.ToString(), "Debit", billidtxt.Text, Convert.ToDouble(grtottxt.Text), "Work " + qntytxt.Text + " recieved @ discount " + discrattxt.Text + "%");
                    Ledger_Process.Ledger_Update("Company_" + Calculator.get_temp_data(Constant_And_Variable.Company_id), "Supplier_" + suppliertxt.Text.ToString(), "Debit", billidtxt.Text, Convert.ToDouble(grtottxt.Text), "Saree " + qntytxt.Text + " recieved @ discount " + discrattxt.Text + "%");
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
                    if (itemdtdgv.Rows[n].Cells[0].Value=="New")
                    {
                        add_new_item(n);
                    }
                    qurry = "insert into [" + Calculator.get_temp_data(Constant_And_Variable.Company_id) + "Job_Recieve_Challan_D_T] (Invo_ID_fkey, item_no_fkey,job_ID_fkey, rate, qnty) values('" + billidtxt.Text + "','" + itemdtdgv.Rows[n].Cells[0].Value + "','" + itemdtdgv.Rows[n].Cells[1].Value + "','" + itemdtdgv.Rows[n].Cells[5].Value + "','" + itemdtdgv.Rows[n].Cells[4].Value + "') ";
                    SqlCommand cmd2 = new SqlCommand(qurry, con2);
                    con2.Open();
                    try
                    {

                        cmd2.ExecuteNonQuery();
                        Ledger_Process.New_Ledger("Item_");
                        Ledger_Process.Item_Update(comlbl.Text, "Item_" + itemdtdgv.Rows[n].Cells[0].Value.ToString(), "Credit", billidtxt.Text, Convert.ToDouble(itemdtdgv.Rows[n].Cells[5].Value.ToString()));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    con2.Close();

                    SqlConnection con3 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
                    qurry = "insert into rate_T (stock_ID_fkey,date_, bill_ID_fkey, rate) values('" + itemdtdgv.Rows[n].Cells[0].Value.ToString() + "','" + itemdtdgv.Rows[n].Cells[1].Value.ToString() + "','" + DateTime.Now.ToString("yyyyMMdd") + "','" + billidtxt.Text + "','" + itemdtdgv.Rows[n].Cells[5].Value + "')";
                    SqlCommand cmd3 = new SqlCommand(qurry, con3);
                    try
                    {
                        con3.Open();
                        cmd3.ExecuteNonQuery();
                        con3.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    n = n + 1;
                }
                billidtxt.Text = lastbill_no().ToString();
                NoEdit();
                savebtn.Enabled = false;
                discardbtn.Enabled = false;
                //newbtn.Visible = true;
            }
        }          

        private void nextitembtn_Click(object sender, EventArgs e)
        {

        }

        private void previousitembtn_Click(object sender, EventArgs e)
        {

        }

        private void delbtn_Click(object sender, EventArgs e)
        {

        }

        private void recievedbtn_Click(object sender, EventArgs e)
        {
            if (new_itemchbx.Checked==true)
            {
                itemdtdgv.Rows[itemdtdgv.NewRowIndex].Cells[0].Value =itemtxt+".New";
            }
            else if (new_itemchbx.Checked == false)
            {
                itemdtdgv.Rows[itemdtdgv.NewRowIndex].Cells[0].Value =Calculator.ret_item_no(itemtxt.Text,designcmb.SelectedValue.ToString()); 
            }
        }

        private void new_designchkbx_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void newbtn_Click(object sender, EventArgs e)
        {

        }

        private void challancmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillservicecombo();
        }

        private void new_itemchbx_CheckedChanged(object sender, EventArgs e)
        {
            if (new_itemchbx.Checked==true)
            {
                designcmb.Enabled = false;
            }
            else if (new_itemchbx.Checked==false)
            {
                designcmb.Enabled = true;
            }
        }
    }
}
