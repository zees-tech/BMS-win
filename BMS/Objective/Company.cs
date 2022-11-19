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
    public partial class Company : Form
    {
        public Company(string callas)
        {
            InitializeComponent();
            CheckCallMethod(callas);
        }
        int pos = 0;
        DataTable ds = new DataTable();
        private void CheckCallMethod(string CallAS)
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
                supfmlbl.Text = "Add Company";
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
                supfmlbl.Text = "View Company";
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
                con.Open();
                string qurry = "select * from Company_T";
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
            statecmb.Enabled = false;
            pincodetxt.ReadOnly = false;
            gstintxt.ReadOnly = false;
        }

        int lastid_no()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
            con.Open();
            string qurry = "Select Id from Company_T";
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
        private void NavRec(int i = 0)
        {

            Edit();
            nametxt.Text = ds.Rows[i][1].ToString();
            aliastxt.Text = ds.Rows[i][2].ToString();
            gstintxt.Text = ds.Rows[i][3].ToString();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
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

        private void Savebtn_Click(object sender, EventArgs e)
        {
            Savebtn.Enabled = false;
            Discardbtn.Enabled = false;
            newbtn.Visible = true;
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
            con.Open();
            string qurry = "insert into Company_T (Name, Alias, GSTIN,author_ID_fkey) values('" + nametxt.Text + "','" + aliastxt.Text + "','" + gstintxt.Text + "','" + Calculator.get_temp_data(Constant_And_Variable.Logger_id) + "')";
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
                Ledger_Process.New_Ledger("Company_" + lastid_no());
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
            con.Close();
            create_invoice_T();
            create_credit_T();
            create_Bill_T();
            create_Debit_T();
            create_payment_T();
            create_GR_Challan_T();
            create_Job_Challan_T();
            create_Pur_Challan_T();
            create_Job_Recieve_Challan_T();
        }
        void create_invoice_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "Invoice_T] ( [Id]INT IDENTITY (1, 1) NOT NULL,[date_] DATE NOT NULL, [com_id_fkey]   VARCHAR(MAX) NOT NULL, [receiver_id_fkey] VARCHAR(MAX) NOT NULL,   [discrate]    FLOAT(53)    NULL,    [author_ID_fkey]   VARCHAR(MAX) NOT NULL, [transportation]         VARCHAR(MAX)    NOT NULL, [ewaybill_no.]         VARCHAR(MAX)    NULL,   [transportation_charge]         FLOAT(53)    NOT NULL, [packaging]         FLOAT(53)    NOT NULL, [payment_terms.]         VARCHAR(MAX)    NULL, PRIMARY KEY CLUSTERED([Id] ASC));";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();
            create_invoice_D_T();
        }
        void create_invoice_D_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "Invo_D_T] (    [Id]           INT IDENTITY (1, 1) NOT NULL,    [Invo_ID_fkey] VARCHAR(MAX) NOT NULL,    [item_no_fkey] VARCHAR(MAX) NOT NULL,    [rate]         FLOAT(53)    NOT NULL,    [qnty]         FLOAT(53)    NOT NULL,PRIMARY KEY CLUSTERED ([Id] ASC)); ";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();
        }
        void create_Bill_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "Bill_T] ( [Id]INT IDENTITY (1, 1) NOT NULL,[date_] DATE NOT NULL, [com_id_fkey]   VARCHAR(MAX) NOT NULL, [send_id_fkey] VARCHAR(MAX) NOT NULL,   [discrate]    FLOAT(53)    NULL,    [author_ID_fkey]   VARCHAR(MAX) NOT NULL, [transportation]         VARCHAR(MAX)    NOT NULL, [ewaybill_no.]         VARCHAR(MAX)    NULL,   [transportation_charge]         FLOAT(53)    NOT NULL, [packaging]         FLOAT(53)    NOT NULL, [payment_terms.]         VARCHAR(MAX)    NULL, PRIMARY KEY CLUSTERED([Id] ASC));";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();
            create_Bill_D_T();
        }
        void create_Bill_D_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "Bill_D_T] (    [Id]           INT IDENTITY (1, 1) NOT NULL,    [Bill_ID_fkey] VARCHAR(MAX) NOT NULL,    [item_no_fkey] VARCHAR(MAX) NOT NULL,    [rate]         FLOAT(53)    NOT NULL,    [qnty]         FLOAT(53)    NOT NULL,PRIMARY KEY CLUSTERED ([Id] ASC)); ";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();
        }
        void create_credit_T()
        {
            string qurry = "CREATE TABLE [dbo].["+ lastid_no() +"Credit_Note_T](    [Id][int] IDENTITY(1, 1) NOT NULL,    [date_] [date]        NOT NULL,    [com_id_fkey] [varchar](max) NOT NULL,    [receiver_id_fkey] [varchar](max) NOT NULL,    [discrate] [float] NULL,	[author_ID_fkey]        [varchar](max) NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC))";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();
            create_credit_D_T();
        }
        void create_credit_D_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "Crdn_D_T](    [Id][int] IDENTITY(1, 1) NOT NULL,    [Cre_ID_fkey] [varchar](max) NOT NULL,    [item_no_fkey] [varchar](max) NOT NULL,    [rate] [float] NOT NULL,    [qnty] [float] NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC))";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();            
        }
        void create_Debit_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "Debit_Note_T](    [Id][int] IDENTITY(1, 1) NOT NULL,    [date_] [date]        NOT NULL,    [com_id_fkey] [varchar](max) NOT NULL,    [receiver_id_fkey] [varchar](max) NOT NULL,    [discrate] [float] NULL,	[author_ID_fkey]        [varchar](max) NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC))";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();
            create_Debit_D_T();
        }
        void create_Debit_D_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "Dbt_D_T](    [Id][int] IDENTITY(1, 1) NOT NULL,    [Cre_ID_fkey] [varchar](max) NOT NULL,    [item_no_fkey] [varchar](max) NOT NULL,    [rate] [float] NOT NULL,    [qnty] [float] NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC))";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();            
        }
        void create_payment_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "Payment_T]([Id][int] IDENTITY(1, 1) NOT NULL,[date_][date]        NOT NULL,    [com_id_fkey] [varchar](max) NOT NULL,    [receiver_id_fkey] [varchar](max) NOT NULL,    [mode] [varchar](max) NOT NULL,    [collector] [varchar](max) NOT NULL,  [author_ID_fkey] [varchar](max) NOT NULL,    [type] [varchar](max) NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC))";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();
            create_payment_D_T();
        }
        void create_payment_D_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "Pay_D_T](    [Id][int] IDENTITY(1, 1) NOT NULL,    [pay_ID_fkey] [varchar](max) NOT NULL,    [date_] [date]        NOT NULL,    [bank] [varchar](max) NOT NULL,    [transaction_ID] [varchar](max) NOT NULL,    [amt] [float] NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC))";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();            
        }
        void create_GR_Challan_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "GR_Challan_T](    [Id][int] IDENTITY(1, 1) NOT NULL,    [date_] [date]        NOT NULL,    [com_id_fkey] [varchar](max) NOT NULL,    [send_id_fkey] [varchar](max) NOT NULL,    [discrate] [float] NULL,	[author_ID_fkey]        [varchar](max) NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC))";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();
            create_GR_Challan_D_T();
        }
        void create_GR_Challan_D_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "GR_Challan_D_T](    [Id][int] IDENTITY(1, 1) NOT NULL,    [Invo_ID_fkey] [varchar](max) NOT NULL,    [item_no_fkey] [varchar](max) NOT NULL,    [rate] [float] NOT NULL,    [qnty] [float] NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC))";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();
        }
        void create_Job_Challan_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "Job_Challan_T](    [Id][int] IDENTITY(1, 1) NOT NULL,    [date_] [date]        NOT NULL,    [com_id_fkey] [varchar](max) NOT NULL,    [send_id_fkey] [varchar](max) NOT NULL,    [discrate] [float] NULL,	[author_ID_fkey]        [varchar](max) NOT NULL,    [stock_value] [float] NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC))";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();
            create_Job_Challan_D_T();
        }
        void create_Job_Challan_D_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "Job_Challan_D_T](    [Id][int] IDENTITY(1, 1) NOT NULL,    [Invo_ID_fkey] [varchar](max) NOT NULL,    [item_no_fkey] [varchar](max) NOT NULL,    [job_ID_fkey] [varchar](max) NOT NULL,    [qnty] [float] NOT NULL,    [rate] [nchar](10) NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC))";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();
        }
        void create_Pur_Challan_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "Pur_Challan_T](    [Id][int] IDENTITY(1, 1) NOT NULL,    [date_] [date]        NOT NULL,    [com_id_fkey] [varchar](max) NOT NULL,    [send_id_fkey] [varchar](max) NOT NULL,    [discrate] [float] NULL,	[author_ID_fkey]        [varchar](max) NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC))";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();
            create_Pur_Challan_D_T();
        }
        void create_Pur_Challan_D_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "Pur_Challan_D_T]([Id][int] IDENTITY(1, 1) NOT NULL,    [Invo_ID_fkey] [varchar](max) NOT NULL,    [item_no_fkey] [varchar](max) NOT NULL,    [rate] [float] NOT NULL,    [qnty] [float] NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC))";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();
        }
        void create_Job_Recieve_Challan_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "Job_Recieve_Challan_T] (    [Id]             INT IDENTITY (1, 1) NOT NULL,    [date_]          DATE NOT NULL,    [com_id_fkey]    VARCHAR(MAX) NOT NULL,    [send_id_fkey]   VARCHAR(MAX) NOT NULL,    [discrate]       FLOAT(53)    NULL,    [author_ID_fkey] VARCHAR(MAX) NOT NULL,    [stock_value]    FLOAT(53)    NOT NULL,  PRIMARY KEY CLUSTERED([Id] ASC));";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();
            create_Job_Recieve_Challan_D_T();
        }
        void create_Job_Recieve_Challan_D_T()
        {
            string qurry = "CREATE TABLE [dbo].[" + lastid_no() + "Job_Recieve_Challan_D_T] (    [Id]           INT IDENTITY (1, 1) NOT NULL,    [Invo_ID_fkey] VARCHAR(MAX) NOT NULL,    [item_no_fkey] VARCHAR(MAX) NOT NULL,    [job_ID_fkey]  VARCHAR(MAX) NOT NULL,    [qnty]         FLOAT(53)    NOT NULL,    [rate]         NCHAR(10)    NOT NULL,PRIMARY KEY CLUSTERED ([Id] ASC));";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con.Close();
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
    }
}
