using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace bms1
{
    class Ledger_Process
    {
        private static string tname;
        public static void Ledger_Update(string fpart, string separt, string tnx, string docID, double amt, string particular)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LedgerDB"].ConnectionString);
            tname = separt + "_Ledge";
            con.Open();
            var trans = "";            
            if (tnx == "Credit")
            {
                trans = "Debit";               
            }
            else if (tnx == "Debit")
            {
                trans = "Credit";                
            }
            
            string qurry = "insert into [" + tname + "] (date_,Particular,folio," + tnx + ") values('" + DateTime.Now.ToString("yyyyMMdd") + "','" + particular + "','" + docID + "','" + amt + "') ";
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            tname = fpart + "_Ledge";
            qurry = "insert into [" + tname + "] (date_,Particular,folio," + trans + ") values('" + DateTime.Now.ToString("yyyyMMdd") + "','" + particular + "','" + docID + "','" + amt + "') ";

            SqlCommand cmd2 = new SqlCommand(qurry, con);
            try
            {
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "Ledger Update Error");
            }
            con.Close();
        }
        public static void Item_Update(string fpart, string itmno_, string tnx, string docID, double qnty)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LedgerDB"].ConnectionString);
            string qurry = "";

            tname = itmno_ + "_Ledge";
            con.Open();
            string spartl = "";
            if (tnx == "Credit")
            {
                spartl = qnty + " pieces recieved againt Doc " + docID + " by " + fpart;
            }
            else if (tnx == "Debit")
            {
                spartl = qnty + " pieces given againt Doc " + docID + " by " + fpart;
            }
            qurry = "insert into [" + tname + "] (date_,Particular,folio," + tnx + ") values('" + DateTime.Now.ToString("yyyyMMdd") + "','" + spartl + "','" + docID + "','" + qnty + "') ";
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "Item Update Error");

            }
        }
        public static void New_Ledger(string obj)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LedgerDB"].ConnectionString);
            con.Open();
            tname = obj + "_Ledge";
            string qurry = "CREATE TABLE [dbo].[" + tname + "] (    [Id] INT NOT NULL PRIMARY KEY IDENTITY,    [date_] DATE NOT NULL,     [Particular] VARCHAR(MAX) NOT NULL,    [folio] VARCHAR(MAX) NOT NULL,    [Credit] FLOAT DEFAULT ((0)) NULL,    [Debit] FLOAT DEFAULT ((0)) NULL)";
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static void Ledger_Update_GST(string fpart, string separt, string tnx, string docID, double amt)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[Constant_And_Variable.TaxDB].ConnectionString);
            //tname = separt + "_Ledge";
            con.Open();
            string spartl = "";
            spartl = "Tax " + tnx + " againt issued Doc No." + docID + "";
            string qurry = "";
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            double tax = 0;

            if (Calculator.ret_State(fpart, Constant_And_Variable.CompanyDB) != Calculator.ret_State(separt, Constant_And_Variable.CustomerDB))
            {
                tax = amt * 0.05;
                qurry = "insert into IGST_Ledger (date_,Particular,folio," + tnx + ") values('" + DateTime.Now.ToString("yyyyMMdd") + "','" + spartl + "','" + docID + "','" + tax + "') ";
                cmd1 = new SqlCommand(qurry, con);
                try
                {
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
            }
            else if (Calculator.ret_State(fpart, Constant_And_Variable.CompanyDB) == Calculator.ret_State(separt, Constant_And_Variable.CustomerDB))
            {
                tax = amt * 0.025;
                qurry = "insert into SGST_Ledger (date_,Particular,folio," + tnx + ") values('" + DateTime.Now.ToString("yyyyMMdd") + "','" + spartl + "','" + docID + "','" + tax + "') ";
                cmd1 = new SqlCommand(qurry, con);
                try
                {
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
                qurry = "insert into CGST_Ledger (date_,Particular,folio," + tnx + ") values('" + DateTime.Now.ToString("yyyyMMdd") + "','" + spartl + "','" + docID + "','" + tax + "') ";
                cmd1 = new SqlCommand(qurry, con);
                try
                {
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
            }
            con.Close();
        }
    }
}
