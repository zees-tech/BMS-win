using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace bms1
{
    class Calculator
    {
        //public delegate string get_data(string Id);
        public static double price_calculator(double rate)
        {
            if (rate <= 900)
            {
                rate = rate / 0.65;
            }
            if (rate > 900)
            {
                rate = rate / 0.7;
            }
            return rate;
        }
        public static string get_temp_data(string Id)
        {

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TempDB"].ConnectionString);
            string qurry = "Select * from Temp where data_Id='" + Id + "'";
            SqlCommand cmd = new SqlCommand(qurry, con);
            con.Open();
            SqlDataReader myreader = cmd.ExecuteReader();
            var Data = "";
            try
            {
                while (myreader.Read())
                {
                    Data = myreader.GetString(2);
                }
            }
            catch (Exception)
            {
                throw;
            }
            con.Close();
            return Data;
        }
        public static void register_selected_data(string Id, string data)
        {
            SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TempDB"].ConnectionString);
            string qurry = "insert into Temp (data_Id, data) values('" + Id + "','" + data + "')";
            SqlCommand cmd1 = new SqlCommand(qurry, con1);
            con1.Open();
            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            con1.Close();
        }
        public static void insert_temp_data(string Id, string data)
        {
            SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TempDB"].ConnectionString);
            string qurry = "insert into Temp (data_Id, data) values('" + Id + "','" + data + "')";
            SqlCommand cmd1 = new SqlCommand(qurry, con1);
            con1.Open();

            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            con1.Close();
        }
        public static string ret_logger_name(string id)
        {

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
            string qurry = "select * from Login_T where LoginID ='" + id + "'";
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            con.Open();
            SqlDataReader myreader = cmd1.ExecuteReader();
            var Data = "";
            try
            {
                while (myreader.Read())
                {
                    Data = myreader.GetString(3);
                }
            }
            catch (Exception)
            {

            }
            con.Close();
            return Data;
        }
        public static string ret_Name(string id, string DataBase)
        {
            string t_name = " ";
            switch (DataBase)
            {
                case "CompanyDB":
                    t_name = "Company_T";
                    break;
                case "SupplierDB":
                    t_name = "Supplier_T";
                    break;
                case "CustomerDB":
                    t_name = "Customer_T";
                    break;
                case "StockDB":
                    t_name = "Stock_T";
                    break;
                //case "LedgerDB":
                //    t_name = "_T";
                //    break;
                //case "TanxDB":
                //    t_name = "_T";
                //    break;
                //case "TanxDB":
                //    t_name = "Company_T";
                //    break;
                default:
                    break;
            }

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[DataBase].ConnectionString);
            string qurry = "select * from [" + t_name + "] where Id ='" + id + "'";
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            con.Open();
            SqlDataReader myreader = cmd1.ExecuteReader();
            var Data = "";
            try
            {
                while (myreader.Read())
                {
                    Data = myreader.GetString(1);
                }
            }
            catch (Exception)
            {

            }
            con.Close();
            return Data;
        }
        public static string ret_Gst(string id, string DataBase)
        {

            string t_name = " ";
            switch (DataBase)
            {
                case "CompanyDB":
                    t_name = "Company_T";
                    break;
                case "SupplierDB":
                    t_name = "Supplier_T";
                    break;
                case "CustomerDB":
                    t_name = "Customer_T";
                    break;
                default:
                    break;
            }

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[DataBase].ConnectionString);
            string qurry = "select * from [" + t_name + "] where Id ='" + id + "'";
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            con.Open();
            SqlDataReader myreader = cmd1.ExecuteReader();
            var Data = "";
            try
            {
                while (myreader.Read())
                {
                    Data = myreader.GetString(3);
                }
            }
            catch (Exception)
            {

            }
            con.Close();
            return Data;
        }
        public static string ret_Address(string id, string DataBase)
        {

            string t_name = "Adres_T ";


            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[DataBase].ConnectionString);
            string qurry = "select * from [" + t_name + "] where Id ='" + id + "'";
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            con.Open();
            SqlDataReader myreader = cmd1.ExecuteReader();
            var Data = "";
            try
            {
                while (myreader.Read())
                {
                    if (DataBase == Constant_And_Variable.CompanyDB)
                    {
                        Data = myreader.GetString(2) + ", " + myreader.GetString(3) + ", " + myreader.GetString(5) + "-" + myreader.GetString(6);
                    }
                    else
                    {
                        Data = myreader.GetString(2);
                    }
                }
            }
            catch (Exception)
            {

            }
            con.Close();
            return Data;
        }
        public static string ret_City(string id, string DataBase)
        {

            string t_name = "Adres_T ";


            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[DataBase].ConnectionString);
            string qurry = "select * from [" + t_name + "] where Id ='" + id + "'";
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            con.Open();
            SqlDataReader myreader = cmd1.ExecuteReader();
            var Data = "";
            try
            {
                while (myreader.Read())
                {
                    Data = myreader.GetString(3);
                }
            }
            catch (Exception)
            {

            }
            con.Close();
            return Data;
        }
        public static string ret_Distric(string id, string DataBase)
        {

            string t_name = "Adres_T ";


            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[DataBase].ConnectionString);
            string qurry = "select * from [" + t_name + "] where Id ='" + id + "'";
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            con.Open();
            SqlDataReader myreader = cmd1.ExecuteReader();
            var Data = "";
            try
            {
                while (myreader.Read())
                {
                    Data = myreader.GetString(4);
                }
            }
            catch (Exception)
            {

            }
            con.Close();
            return Data;
        }
        public static string ret_State(string id, string DataBase)
        {

            string t_name = "Adres_T ";


            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[DataBase].ConnectionString);
            string qurry = "select * from [" + t_name + "] where Id ='" + id + "'";
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            con.Open();
            SqlDataReader myreader = cmd1.ExecuteReader();
            var Data = "";
            try
            {
                while (myreader.Read())
                {
                    Data = myreader.GetString(5);
                }
            }
            catch (Exception)
            {

            }
            con.Close();
            return Data;
        }
        public static string ret_Pincode(string id, string DataBase)
        {

            string t_name = "Adres_T ";


            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[DataBase].ConnectionString);
            string qurry = "select * from [" + t_name + "] where Id ='" + id + "'";
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            con.Open();
            SqlDataReader myreader = cmd1.ExecuteReader();
            var Data = "";
            try
            {
                while (myreader.Read())
                {
                    Data = myreader.GetString(6);
                }
            }
            catch (Exception)
            {

            }
            con.Close();
            return Data;
        }
        public static string ret_Alias(string id, string DataBase)
        {

            string t_name = " ";
            switch (DataBase)
            {
                case "CompanyDB":
                    t_name = "Company_T";
                    break;
                case "SupplierDB":
                    t_name = "Supplier_T";
                    break;
                case "CustomerDB":
                    t_name = "Customer_T";
                    break;
                default:
                    break;
            }


            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[DataBase].ConnectionString);
            string qurry = "select * from [" + t_name + "] where Id ='" + id + "'";
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            con.Open();
            SqlDataReader myreader = cmd1.ExecuteReader();
            var Data = "";
            try
            {
                while (myreader.Read())
                {
                    Data = myreader.GetString(2);
                }
            }
            catch (Exception)
            {

            }
            con.Close();
            return Data;
        }
        public static string ret_id(string field_name, string data,string DataBase, string t_name = "")
        {            
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[DataBase].ConnectionString);
            string qurry = "select * from [" + t_name + "] where "+field_name+" ='" + data + "'";
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            con.Open();
            SqlDataReader myreader = cmd1.ExecuteReader();
            var Data = "";
            try
            {
                while (myreader.Read())
                {
                    Data = myreader.GetString(0);
                    MessageBox.Show("Id=" + Data);
                }
            }
            catch (Exception)
            {

            }
            con.Close();
            return Data;
        }
        public static string ret_isRecordTrans(string table, string database)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[database].ConnectionString);
            string qurry = "Select * from [" + table + "] ";
            SqlCommand cmd = new SqlCommand(qurry, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            con.Open();

            try
            {
                sda.Fill(ds);
            }
            catch (Exception)
            {

            }
            con.Close();
            if (ds.Rows.Count > 0)
            {
                return "1";
            }
            else
            { return "0"; }
        }
        public static string ret_rate(string id, string DataBase)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[DataBase].ConnectionString);
            string qurry = "select * from [rate_T] where Id ='" + id + "'";
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            con.Open();
            SqlDataReader myreader = cmd1.ExecuteReader();
            var Data = "";
            try
            {
                while (myreader.Read())
                {
                    Data = myreader.GetString(0);
                }
            }
            catch (Exception)
            {

            }
            con.Close();
            return Data;
        }
        public static string ret_Balance(string id, string DataBase)
        {

            string t_name = " ";
            switch (DataBase)
            {
                case "Company":
                    t_name = "Company_"+id+"_Ledge";
                    break;
                case "Supplier":
                    t_name = "Supplier_" + id + "_Ledge";
                    break;
                case "Customer":
                    t_name = "Customer_" + id + "_Ledge";
                    break;
                case "Servicer":
                    t_name = "Servicer_" + id + "_Ledge";
                    break;
                default:
                    break;
            }


            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LedgerDB"].ConnectionString);
            string qurry = "select * from [" + t_name + "]";
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            con.Open();
            SqlDataReader myreader = cmd1.ExecuteReader();
            double Data = 0;
            try
            {
                while (myreader.Read())
                {
                    Data += Convert.ToDouble(myreader.GetString(4)) - Convert.ToDouble(myreader.GetString(5));
                }
            }
            catch (Exception)
            {

            }
            con.Close();
            return Data.ToString();
        }
        public static string ret_item_no(string itemno)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
            con.Open();
            string qurry = "Select * from Stock_T where Id=" + itemno + "";
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
        public static string ret_item_no(string itemno, string desgn)
        {
            //SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
            //con.Open();
            //string qurry = "Select * from Stock_T where Id=" + itemno + ret_id(desgn,Constant_And_Variable.JobWorkDB, "JobWork_T");
            //SqlCommand cmd = new SqlCommand(qurry, con);
            string item_no = null;
            item_no = itemno +"."+ desgn;
            return item_no;
        }
        public static int count_data_row(string database, string tname)
        {

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[database].ConnectionString);
            con.Open();
            string qurry = "Select * from ["+tname+"]";
            SqlCommand cmd = new SqlCommand(qurry, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            try
            {
                sda.Fill(data);                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return data.Rows.Count;
        }
    }
}
