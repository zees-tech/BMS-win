using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace BMS
{
    class Call
    {
        public delegate  string get_data(string Id);
        public static double price_calculator(double rate)
        {
            if (rate <= 900)
            {
                rate = rate / 0.65;
            }
            else if (rate > 900)
            {
                rate = rate / 0.7;
            }

            if (rate%100<25)
            {
                rate += -rate % 100 + 25;
            }
            else if (rate % 100 > 25 && rate % 100 < 50)
            {
                rate += -rate % 100 + 50;
            }
            else if (rate % 100 > 50 && rate % 100 < 75)
            {
                rate += -rate % 100 + 75;
            }
            else if (rate % 100 >75)
            {
                rate += -rate % 100 + 100;
            }
            return rate;
        }
        public static string GTD(string Id)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[Constant.CompanyDB].ConnectionString);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            con.Close();
            return Data;
        }
        public static void RSD(string Id, string data)
        {
            SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[Constant.CompanyDB].ConnectionString);
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
        public static string ret_Name(string id, string DataBase,string t_name= "Company_T")
        {
            return ret_data(DataBase, t_name, "Id", id, CompanyDB.c_Company_T.f_Name);           
        }
        public static string ret_Gst(string id, string DataBase)
        {
            string t_name = CompanyDB.t_Company_T;
           
            return ret_data(DataBase, t_name, "Id", id, CompanyDB.c_Company_T.f_GSTIN);           
        }
        public static string ret_Address(string id, string DataBase)
        {
            string t_name = CompanyDB.t_Address_T;
            return (ret_data(DataBase, t_name, CompanyDB.c_Address_T.f_addri_fkey, id, CompanyDB.c_Address_T.f_address));
              
        }
        public static string ret_City(string id, string DataBase)
        {
            string t_name = CompanyDB.t_Address_T;

            return ret_data(DataBase, t_name, CompanyDB.c_Address_T.f_addri_fkey, id, CompanyDB.c_Address_T.f_city);          
        }
        public static string ret_phone(string id, string tid,string DataBase)
        {
            string t_name = CompanyDB.t_Contact_T;
            List<string> field = new List<string> { CompanyDB.c_Contact_T.f_holder_fkey, CompanyDB.c_Contact_T.f_holder_table };
            List<string> val = new List<string> { id, tid };
            return ret_data(DataBase, t_name, field, val, CompanyDB.c_Contact_T.f_phone);
        }
        public static string ret_Distric(string id, string DataBase)
        {
            string t_name = CompanyDB.t_Address_T;

            return ret_data(DataBase, t_name, CompanyDB.c_Address_T.f_addri_fkey, id, CompanyDB.c_Address_T.f_district);            
        }
        public static string ret_State(string id, string DataBase)
        {
            string t_name = CompanyDB.t_Address_T;

            return ret_data(DataBase, t_name, CompanyDB.c_Address_T.f_addri_fkey, id, CompanyDB.c_Address_T.f_state);
        }
        public static string ret_Pincode(string id, string DataBase)
        {
            string t_name = CompanyDB.t_Address_T;

            return ret_data(DataBase, t_name, CompanyDB.c_Address_T.f_addri_fkey, id, CompanyDB.c_Address_T.f_pincode);           
        }
        public static string ret_Alias(string id, string DataBase)
        {
            string t_name = CompanyDB.t_Company_T;

            return ret_data(DataBase, t_name, CompanyDB.c_Company_T.f_Alias, id, 2);           
        }       
        public static string ret_id(string field_name, string data, string DataBase, string t_name)
        {            
           return ret_data(DataBase, t_name, field_name, data, 0, "int");           
        }
        public static bool ret_isRecord(string table, string database)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[database].ConnectionString);
            string qurry = "Select * from [" + table + "]";
            SqlCommand cmd = new SqlCommand(qurry, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            con.Open();

            try
            {
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();
            if (ds.Rows.Count > 0)
            {
                return true;
            }
            else
            { return false; }
        }
        public static bool ret_isRecord(string table, string database,string field,string val)
        {
            string qurry = "Select * from [" + table + "] where " + field + " ='" + val + "'";
            DataTable ds = new DataTable();
            ds = Fall.fill_ds(qurry, database);
            if (ds.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }
        public static string ret_rate(string id, string DataBase,string _for)
        {
            string qurry = "select * from [rate_T] where " + StockDB.c_rate_T.f_item_fkey + " ='" + id + "' And " + StockDB.c_rate_T.f_item_table + " ='" + StockDB.t_Item_T + "'";
            if (_for==Constant.Job)
            {
                qurry = "select * from [rate_T] where " + StockDB.c_rate_T.f_item_fkey + " ='" + id + "' And " + StockDB.c_rate_T.f_item_table + " ='" + StockDB.t_Job_T + "'";
            }
            var Data = "0";
            try
            {
                Data = Fall.fill_ds(qurry, DataBase).Rows[0][StockDB.c_rate_T.f_rate_].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No rate recod!");              
            }
            return Data;
        }
        public static double ret_Balance(string id, string for_)
        {
            string t_name = "";            
            switch (for_)
            {               
                case "Item":
                    t_name = "Item_" + id + "_Ledge";
                    break;
                default:
                    t_name = "Company_" + id + "_Ledge";
                    break;
            }
            string qurry = "select * from [" + t_name + "] where Com_Id ='" + GTD(Constant.Company_id) + "'";
            if (for_ == "Company")
            {
                qurry = "select * from [" + t_name + "]";
            }
            DataTable dst = new DataTable();
            dst = Fall.fill_ds(qurry, Constant.LedgerDB);
            double Data = 0;
            if (dst.Rows.Count>0)
            {
                int i = 0; 
                DataTable dt = new DataTable();
                while (i<dst.Rows.Count)
                {
                    t_name = dst.Rows[i]["table_id"].ToString().Substring(0, dst.Rows[i]["table_id"].ToString().Length - 1) + "D_T";
                    

                    if (for_ == "-Item")
                    {
                        string itno = "";
                        dt = Call.ret_dt("Select * from " + t_name + " where bill_ID_fkey ='" + dst.Rows[i]["folio"].ToString() + "' And " + TranDB.c_Bill_D_T.f_item_no_fkey + " = '" +id+"'", Constant.TransDB);
                        int n = 0;
                        while (dt.Rows.Count>n)
                        {
                            try
                            {
                                itno = dt.Rows[n][TranDB.c_Bill_D_T.f_item_no_fkey].ToString() + dt.Rows[n][TranDB.c_Job_Bill_D_T.f_job_fkey].ToString();
                                try
                                {
                                    dt.Rows[n][TranDB.c_Job_Bill_D_T.f_recieved].ToString();
                                    itno = dt.Rows[n][TranDB.c_Bill_D_T.f_item_no_fkey].ToString();
                                }
                                catch (Exception)
                                {
                                }
                            }
                            catch (Exception)
                            {
                                itno = dt.Rows[n][TranDB.c_Bill_D_T.f_item_no_fkey].ToString();
                            }

                            if (Convert.ToBoolean(dst.Rows[i]["credit"]))
                            {
                                Data += Convert.ToDouble(dt.Rows[n][TranDB.c_Bill_D_T.f_qnty]);
                            }
                            else if (Convert.ToBoolean(dst.Rows[i]["debit"]))
                            {
                                Data -= Convert.ToDouble(dt.Rows[n][TranDB.c_Bill_D_T.f_qnty]);
                            }
                            n++;
                        }
                    }                    
                    else
                    {
                        int n = 0;
                        dt = Call.ret_dt("Select * from " + t_name + " where bill_ID_fkey ='" + dst.Rows[i]["folio"].ToString() + "'", Constant.TransDB);
                        while (dt.Rows.Count > n)
                        {
                            switch (for_)
                            {
                                case "Item":
                                    {
                                        string itno = "";
                                        try
                                        {
                                            itno = dt.Rows[n][TranDB.c_Bill_D_T.f_item_no_fkey].ToString() + dt.Rows[n][TranDB.c_Job_Bill_D_T.f_job_fkey].ToString();
                                            try
                                            {
                                                dt.Rows[n][TranDB.c_Job_Bill_D_T.f_recieved].ToString();
                                                itno = dt.Rows[n][TranDB.c_Bill_D_T.f_item_no_fkey].ToString();
                                            }
                                            catch (Exception)
                                            {
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            itno = dt.Rows[n][TranDB.c_Bill_D_T.f_item_no_fkey].ToString();
                                        }
                                        if (itno == id)
                                        {
                                            if (Convert.ToBoolean(dst.Rows[i]["credit"]))
                                            {
                                                Data += Convert.ToDouble(dt.Rows[n][TranDB.c_Bill_D_T.f_qnty]);
                                            }
                                            else if (Convert.ToBoolean(dst.Rows[i]["debit"]))
                                            {
                                                Data -= Convert.ToDouble(dt.Rows[n][TranDB.c_Bill_D_T.f_qnty]);
                                            }
                                        }
                                        break;
                                    }

                                default:
                                    {
                                        if (Convert.ToBoolean(dst.Rows[i]["credit"]))
                                        {
                                            Data += Convert.ToDouble(dt.Rows[n][TranDB.c_Bill_D_T.f_qnty]) * Convert.ToDouble(dt.Rows[n][TranDB.c_Bill_D_T.f_rate]);
                                        }
                                        else if (Convert.ToBoolean(dst.Rows[i]["debit"]))
                                        {
                                            Data -= Convert.ToDouble(dt.Rows[n][TranDB.c_Bill_D_T.f_qnty]) * Convert.ToDouble(dt.Rows[n][TranDB.c_Bill_D_T.f_rate]);
                                        }
                                        break;
                                    }
                            }

                            n++;
                        }
                    }                    
                    i++;
                }
            }
            return Data;
        }        
        public static double ret_transValue(string folio,string tname,string type_,List<string> field , List<string> f_val)
        {
            string qurry = "Select * from [" + tname + "] where [" + TranDB.c_Bill_D_T.f_bill_ID_fkey + "] = '" + folio + "'";
            int i = 0;
            foreach (var item in field)
            {
                //if (i == field.Count - 1)
                //{
                //    qurry += " And ";
                //}
                //else
                //{
                //    qurry += " , ";
                //}
                qurry += " And "+item + " ='" + f_val[i] + "'";                
                i++;
            }           
            DataTable ds = new DataTable();
            ds = Fall.fill_ds(qurry);
            i=0;
            double sum = 0;
            while(i<ds.Rows.Count)
            {
                switch (type_)
                {
                    case "r*q":
                        {
                            sum += Convert.ToDouble(ds.Rows[i][TranDB.c_Bill_D_T.f_qnty]) * Convert.ToDouble(ds.Rows[i][TranDB.c_Bill_D_T.f_rate])*(1- Convert.ToDouble(ds.Rows[i][TranDB.c_Bill_D_T.f_discount_rate]));                            
                            break;
                        }
                    case "q":
                        {
                            sum += Convert.ToDouble(ds.Rows[i][TranDB.c_Bill_D_T.f_qnty]);
                            break;
                        }
                    case "r":
                        {
                            sum += Convert.ToDouble(ds.Rows[i][TranDB.c_Bill_D_T.f_rate]);
                            break;
                        }
                }
                i++;
            }
            return sum;
        }
        public static string ret_item_no(string id)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
            con.Open();
            string qurry = "Select * from Stock_T where Id=" + id + "";
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
        public static string format_date(DateTime date)
        {
            var date_ = "";            
            date_ = date.ToString("dd MM yyyy");
            return date_;
        }
        public static string ret_data(string DataBase, string t_name , List<string> field, List<string> val, int dt_index, string data_type="string")
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[DataBase].ConnectionString);
            string qurry = "select * from [" + t_name + "] where ";
            
            con.Open();
            int i = 0;
            
            double Data =0;            
            foreach (var item in field)
            {
                if (i > 0)
                {
                    qurry += " And ";
                }
                qurry += item + " ='" + val[i] + "'";

                i++;
            }
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            SqlDataReader myreader = cmd1.ExecuteReader();
            try
            {
                while (myreader.Read())
                {
                    switch (data_type)
                    {
                        case "double":
                            Data+= Convert.ToDouble(myreader.GetString(dt_index).ToString());
                            break;
                       
                        default:                            
                            return myreader.GetString(dt_index).ToString();
                            break;
                    }
                }
            }
            catch (Exception)
            {
                
            }
            return Data.ToString();
        }
        public static string ret_data(string DataBase, string t_name, List<string> field, List<string> val, string dt_index, string data_type = "string")
        {                      
            int i = 0;
            string Data = "";
            string qurry = "select * from [" + t_name + "] where ";
            foreach (var item in field)
            {
                if (i > 0)
                {
                    qurry += " And ";
                }
                qurry += item + " ='" + val[i] + "'";

                i++;
            }
            DataTable ds = new DataTable();
            ds = Fall.fill_ds(qurry, DataBase);
            i = 0;
            while (i < ds.Rows.Count)
            {

                if (data_type == Constant.Yes)
                {
                    Data = (Convert.ToDouble(Data) + Convert.ToDouble(ds.Rows[i][dt_index].ToString())).ToString();
                }
                else
                {
                    Data = ds.Rows[i][dt_index].ToString();
                }
                i++;
            }
            return Data.ToString();
        }
        public static string ret_data(string DataBase, string t_name, string field, string val, int dt_index, string data_type = "string")
        {
            string qurry = "select * from [" + t_name + "] where " + field + "='" + val + "'";
            DataTable ds = new DataTable();
            ds = Fall.fill_ds(qurry, DataBase);
            string Data = "";
            int i = 0;
            while (i < ds.Rows.Count)
            {

                if (data_type == Constant.Yes)
                {
                    Data = (Convert.ToDouble(Data) + Convert.ToDouble(ds.Rows[i][dt_index].ToString())).ToString();
                }
                else
                {
                    Data = ds.Rows[i][dt_index].ToString();
                }
                i++;
            }
            return Data.ToString();
        }
        public static string ret_data(string DataBase, string t_name, string field, string val, string dt_index, string data_type = "string")
        {
            string qurry = "select * from [" + t_name + "] where " + field + "='" + val + "'";
            DataTable ds = new DataTable();
            ds = Fall.fill_ds(qurry, DataBase);
            string Data = "";
            int i = 0;
            while (i < ds.Rows.Count)
            {

                if (data_type == Constant.Yes)
                {
                    Data = (Convert.ToDouble(Data) + Convert.ToDouble(ds.Rows[i][dt_index].ToString())).ToString();
                }
                else
                {
                    Data = ds.Rows[i][dt_index].ToString();
                }
                i++;
            }
            return Data.ToString();
        }       
        public static double ret_work_rate(string itemno)
        {
            return Convert.ToDouble(ret_rate(itemno, Constant.StockDB,Constant.Job));
        }
        public static double ret_item_rate(string itemno)
        {
            return Convert.ToDouble(ret_rate(itemno,Constant.StockDB,Constant.Item));            
        }
        public static double ret_serve_rate(string itemno)
        {
            return Convert.ToDouble(ret_rate(itemno, Constant.StockDB, Constant.Service));
        }
        public static string add_new_item(Item Dts)
        {           
            string qurry = "select * from " + StockDB.t_Item_T;
            DataTable ds = new DataTable();
            ds = Fall.fill_ds(qurry, Constant.StockDB);
            if (Dts.Item_no.Length>2)
            {
                if (Dts.Item_no.Substring(0,3) == "New")
                {
                    int i = 0;
                    if (ds.Rows.Count>0)
                    {
                        while (i < ds.Rows.Count)
                        {
                            if (Convert.ToDouble(ds.Rows[i][StockDB.c_Item_T.f_stock_no].ToString()) >= Convert.ToDouble(Dts.stock_no))
                            {
                                Dts.Item_no = Dts.stock_no = (Convert.ToDouble(ds.Rows[i][StockDB.c_Item_T.f_stock_no].ToString()) + 1).ToString();
                            }
                            i++;
                        }
                    }
                   else
                    {
                        Dts.Item_no = Dts.stock_no = "1";
                    }
                }                
            }
            StockDB.Insert_Item_T(Dts.Item_no,Dts.stock_no,Dts.hsn,Dts.date_,Dts.Item_no,Dts.description,Dts.category,Dts.supplier_ID_fkey,Call.GTD(Constant.User_id),Dts.unit,Dts.ledgerReq);           
            save_rate(Dts, "New", Constant.Item);
            Ledger_Process.New_Ledger("Item_" + Dts.Item_no, "Item");
            return Dts.Item_no;
        }
        public static string add_new_work(Item Dts)
        {
            string qurry = "", work_no = "";
            work_no = Dts.Item_no.Substring(3);
            DataTable ds = new DataTable();
           
            qurry = "select * from " + StockDB.t_Category_T + " where " + StockDB.c_Category_T.f_Name + " ='" + work_no + "'";
            ds = Fall.fill_ds(qurry, Constant.StockDB);
            int id = 0;
            if (ds.Rows.Count>0)
            {
                id = Convert.ToInt32(ds.Rows[ds.Rows.Count - 1]["Id"].ToString());
                Dts.ledgerReq = ds.Rows[ds.Rows.Count - 1][StockDB.c_Job_T.f_LedgerReq].ToString();
            }            
            qurry = "select * from " + StockDB.t_Job_T + " where " + StockDB.c_Job_T.f_category + " ='" + id + "'" ;
            ds = Fall.fill_ds(qurry, Constant.StockDB);
            Dts.category = id.ToString();
            string itno = Dts.Item_no = Constant.Ret_Alpha(id) + "" + (00 + ds.Rows.Count + 1);
            StockDB.Insert_Job_T( Dts.ledgerReq, itno, Dts.hsn, Dts.date_, itno, Dts.description, Dts.category, Dts.supplier_ID_fkey, Dts.author_ID_fkey,Dts.unit, Dts.ledgerReq);
            save_rate(Dts, "New", Constant.Job);
            return itno;            
        }
        public static string ret_substring(string str, char val)
        {
            int i = 0;
            while (i<str.Length)
            {
                if(str[i]==val)
                {
                    break;
                }                
                i++;
            }
            if (i < str.Length)
            {
                str = str.Substring(i + 1, str.Length - (i + 1));
            }
            return str;
        }
        public static string ret_substring(string str, bool alphaNum,bool dir_right, bool in_str)
        {
            int i = 0;
            while (i < str.Length)
            {
               if (Char.IsLetter(str[i]) && alphaNum)
                {
                    i -= 1 * Convert.ToInt16(in_str);
                    break;
                }
                else if (!Char.IsLetter(str[i]) && !alphaNum)
                {
                    i -= 1 * Convert.ToInt16(in_str);
                    break;
                }                  
                i++;
            }
            if (i<str.Length)
            {
                if (dir_right)
                {
                    str = str.Substring(i + 1, str.Length - (i + 1));
                }
                else
                {
                    str=str.Substring(0, i+1);
                }
            }
            return str;
        }
        class genNewitm
        {
            string state
            {
                set
                {
                    if (value!="Checked" || value != "Unchecked")
                    {
                        MessageBox.Show("Invalid Data");
                    }
                    else
                    {
                        state = value;
                    }
                }
                get
                {
                    return state;
                }
            }
        }       
        public static void add_new_category(string name, string sub, string genNewItm, string DB)
        {
            string qurry = "insert into ["+CompanyDB.t_Category_T+ "] (name,sub,date_,LedgerReq) values('" + name + "','" + sub + "','" + DateTime.Now.ToString() + "','" + genNewItm + "')";
            Fall.SaveDB(qurry, DB);
        }
        public static void save_rate(Item Dts,string Doc_Id,string for_)
        {
            string tname = StockDB.t_Item_T;          
            if (for_ == Constant.Job)
            {
                tname = StockDB.t_Job_T;
            }
            StockDB.Insert_rate_T(Dts.Item_no,tname, Doc_Id, Dts.rate.ToString(), "");
        }       
        public static List<string> set_detail(string val, string _for)
        {           
            List<string> data = new List<string> { "", "" ,""};
            string qurry = "",hascol="";
            if (_for == Constant.Item)
            {
                qurry = "Select * from [Item_T] where stockId='" + val + "'";
                hascol = StockDB.c_Item_T.f_HSN;
            }
            else if(_for == Constant.Job)
            {
                qurry = "Select * from [Job_T] where stockId='" + val + "'";
                hascol = StockDB.c_Job_T.f_SAC;
            }
            else
            {
                qurry = "Select * from [Service_T] where stockId='" + val + "'";
                hascol = StockDB.c_Service_T.f_SAC;
            }
            DataTable dst = new DataTable();
            dst = Fall.fill_ds(qurry, Constant.StockDB);
            if (dst.Rows.Count>0)
            {
                data[0] = dst.Rows[0][StockDB.c_Item_T.f_description].ToString();
                data[1] = dst.Rows[0][hascol].ToString();
                if (_for == Constant.Item)
                {
                    data[2] = dst.Rows[0][StockDB.c_Item_T.f_stock_no].ToString();
                }
            }
            return data;
        }
        public static List<string> Break_String(string str )
        {
            List<string> list = new List<string> { };
            int i = 0, m = 0, ofadj = 0;
            while(i<str.Length)
            {
                if (str.Substring(i, 1)==Constant.strbrk||str.Length-1==i)
                {
                    if (i!=0)
                    {
                        list.Add(str.Substring(m+ofadj, i-m));
                        ofadj = 1;
                        m = i;
                    }
                    else
                    {
                        list.Add("");
                    }
                }
                i++;
            }

            return list;
        }       
        public static DataTable ret_dt(string qurry,string database)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[database].ConnectionString);
            con.Open();
            //string qurry = "select * from [" + Call.GTD(Constant.Company_id) + "Bill_D_T] where Bill_ID_fkey ='" + billidtxt.Text + "'";
            DataTable dgv = new DataTable();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                SqlDataAdapter reader = new SqlDataAdapter(cmd);
                reader.Fill(dgv);      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }           
             if(dgv.Rows.Count<1)
            {
                dgv.NewRow();

            }     
            con.Close();
            return dgv;
        }
        public static string formatQuote(string var)
            {
            string newstring = "";
            foreach (char item in var)
            {
                if (item=='\'')
                {
                     
                    newstring += "\\'";
                }
                else
                {
                    newstring += item;
                }
            }
            
            return newstring;
        }
        public static string Ret_UserName()

        {
           return Call.ret_data(Constant.CompanyDB, "Login_T", "LoginID", Call.GTD(Constant.User_id), "Name");
        }
        public static string ret_lreate(string itno,string party,string tname1,string tname2,string _for)
        {
            string dt = "";
            DataTable ds = new DataTable();
            string query = "";
            if (_for == Constant.Item)
            {
                query = "SELECT " + tname1 + ".beneficiary_fkey, " + tname2 + ".item_no_fkey, " + tname2 + ".rate FROM " + tname1 + " INNER JOIN " + tname2 + " ON " + tname1 + ".billno = " + tname2 + ".bill_ID_fkey where " + tname1 + "." + TranDB.c_Bill_T.f_beneficiary_fkey + " = " + party;
            }
            else if (_for == Constant.Job)
            {
                query = "SELECT " + tname1 + ".beneficiary_fkey, " + tname2 + ".item_no_fkey, " + tname2 + ".rate, " + tname2 + ".job_fkey FROM " + tname1 + " INNER JOIN " + tname2 + " ON " + tname1 + ".billno = " + tname2 + ".bill_ID_fkey where " + tname1 + "." + TranDB.c_Bill_T.f_beneficiary_fkey + " = " + party;
            }
            
            ds = Fall.fill_ds(query);
            int i = 0;
            while (ds.Rows.Count>i)
            {
                if (_for==Constant.Item)
                {
                    if (ds.Rows[i][TranDB.c_Bill_D_T.f_item_no_fkey].ToString() == itno)
                    {
                        dt = ds.Rows[i][TranDB.c_Bill_D_T.f_rate].ToString();
                    }                      
                }
                else if (_for == Constant.Job)
                {
                    if (ds.Rows[i][TranDB.c_Job_Bill_D_T.f_job_fkey].ToString() == itno)
                    {
                        dt = ds.Rows[i][TranDB.c_Bill_D_T.f_rate].ToString();
                    }
                }
                i++;
            }
            return dt;
        }
        private static bool InsertGST(string doc_t, bool isRC, bool sell, bool registeredsell, LedgerObj ldt, bool interstate,bool unnttry)
        {
            bool chk = false;
            if (interstate)
            {
                chk= TranDB.Insert_IGST(doc_t,isRC.ToString(),sell.ToString(),registeredsell.ToString(),ldt.date_, ldt.particular, ldt.folio, ldt.credit, ldt.debit);
            }
            else 
            {
                if (unnttry)
                {
                    chk = TranDB.Insert_CGST(doc_t, isRC.ToString(), sell.ToString(), registeredsell.ToString(), ldt.date_, ldt.particular, ldt.folio, (Convert.ToDouble(ldt.credit)/2).ToString(), (Convert.ToDouble(ldt.debit) / 2).ToString());
                    chk = TranDB.Insert_UGST(doc_t, isRC.ToString(), sell.ToString(), registeredsell.ToString(), ldt.date_, ldt.particular, ldt.folio, (Convert.ToDouble(ldt.credit) / 2).ToString(), (Convert.ToDouble(ldt.debit) / 2).ToString());
                }
                else
                {
                    chk = TranDB.Insert_CGST(doc_t, isRC.ToString(), sell.ToString(), registeredsell.ToString(), ldt.date_, ldt.particular, ldt.folio, (Convert.ToDouble(ldt.credit) / 2).ToString(), (Convert.ToDouble(ldt.debit) / 2).ToString());
                    chk = TranDB.Insert_SGST(doc_t, isRC.ToString(), sell.ToString(), registeredsell.ToString(), ldt.date_, ldt.particular, ldt.folio, (Convert.ToDouble(ldt.credit) / 2).ToString(), (Convert.ToDouble(ldt.debit) / 2).ToString());
                }
            }            
            return chk;
        }
        private static bool isuniontertory(string estate)
        {
            int i = 0;
            while (Constant.uniontertory.Count>i)
            {
                if (Constant.uniontertory[i]==estate)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool InsertTaxdb( string doc_t,bool isRC, bool sell, bool registeredsell, string f_party,string s_party,string date_,string folio,string amt)
        {
            bool chk = false;
            LedgerObj ldt = new LedgerObj();
            ldt.date_ = date_;
            ldt.folio = folio; 
            
            if (sell)
            {
                ldt.debit = amt;
                ldt.credit = "0";
                if (registeredsell)
                {
                    ldt.particular = "Debit by registered sell";
                    chk = InsertGST(doc_t,isRC,sell,registeredsell, ldt, (Call.ret_State(f_party, Constant.CompanyDB) != Call.ret_State(s_party, Constant.CompanyDB)), (isuniontertory(Call.ret_State(f_party, Constant.CompanyDB)) || isuniontertory(Call.ret_State(s_party, Constant.CompanyDB))));
                }
                else
                {
                    ldt.particular = "Debit by unregistered sell";
                    chk = InsertGST(doc_t, isRC, sell, registeredsell, ldt, (Call.ret_State(f_party, Constant.CompanyDB) != Call.ret_State(s_party, Constant.CompanyDB)), (isuniontertory(Call.ret_State(f_party, Constant.CompanyDB)) || isuniontertory(Call.ret_State(s_party, Constant.CompanyDB))));
                }
            }
            else
            {
                ldt.debit = "0";
                ldt.credit = amt;
                if (registeredsell)
                {
                    ldt.particular = "Credit by registered purchase";
                    chk = InsertGST(doc_t, isRC, sell, registeredsell, ldt, (Call.ret_State(f_party, Constant.CompanyDB) != Call.ret_State(s_party, Constant.CompanyDB)), (isuniontertory(Call.ret_State(f_party, Constant.CompanyDB)) || isuniontertory(Call.ret_State(s_party, Constant.CompanyDB))));
                }
                else
                {
                    ldt.debit = ldt.credit;
                    ldt.credit = "0";
                    ldt.particular = "RC debit by unregistered purchase";
                    chk = InsertGST(doc_t, isRC, sell, registeredsell, ldt, (Call.ret_State(f_party, Constant.CompanyDB) != Call.ret_State(s_party, Constant.CompanyDB)), (isuniontertory(Call.ret_State(f_party, Constant.CompanyDB)) || isuniontertory(Call.ret_State(s_party, Constant.CompanyDB))));
                    ldt.credit = ldt.debit;
                    ldt.debit = "0";
                    ldt.particular = "Credit by unregistered purchase againt RC";
                    chk = InsertGST(doc_t, isRC, sell, registeredsell, ldt, (Call.ret_State(f_party, Constant.CompanyDB) != Call.ret_State(s_party, Constant.CompanyDB)), (isuniontertory(Call.ret_State(f_party, Constant.CompanyDB)) || isuniontertory(Call.ret_State(s_party, Constant.CompanyDB))));
                }
            }
            
            return chk;        
        }
        public static bool IsRevrsChrge(bool sell, bool IsBeneRegd)
        {
            if (sell==false && IsBeneRegd==false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Bankdt ret_bankdt(Bankdt dt)
        {
            string qurry = "select * from [" + CompanyDB.t_Bank_T + "] where " + CompanyDB.c_Bank_T.f_holder_fkey + "='" + dt.holder_fkey + "'";
            DataTable ds = new DataTable();
            ds = Fall.fill_ds(qurry, Constant.CompanyDB);
            if (ds.Rows.Count>0)
            {
                dt.bank_name = ds.Rows[0][CompanyDB.c_Bank_T.f_bank_name].ToString();
                dt.Name = ds.Rows[0][CompanyDB.c_Bank_T.f_Name].ToString();
                dt.AccountNo = ds.Rows[0][CompanyDB.c_Bank_T.f_AccountNo].ToString();
                dt.IFSC = ds.Rows[0][CompanyDB.c_Bank_T.f_IFSC].ToString();
            }
            return dt;
        }
        public static bool Reset_Indentity(int num,string tname)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[Constant.CompanyDB].ConnectionString);
            string qurry = "DBCC CHECKIDENT (["+tname+"],RESEED,'" + num + "')";
            SqlCommand cmd = new SqlCommand(qurry, con);
            con.Open();
            cmd.ExecuteNonQuery();        
            con.Close();
            return true;
        }
        public static double ret_stockValue(string stockId,double qnty,string for_)
        {
            double amt = 0;
            if (for_==Constant.Item)
            {
                amt = ret_item_rate(stockId) * qnty;
            }
            else if (for_==Constant.Job)
            {
                amt = ret_work_rate(stockId) * qnty;
            }
            else
            {

            }
            return amt;
        }
    }
    
}
