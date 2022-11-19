using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace BMS
{
    class Ledger_Process
    {
        private static string tname;
        public static void Ledger_Update(string fpart, string separt, string date_, string tnx, string docID, string particular, string table_id, string formid ,double Stock_Val=0)
        {
            bool crd = false, dbt = false;
            if (tnx == "Credit")
            {
                crd = true;
            }
            else if (tnx == "Debit")
            {
                dbt = true;
            }

            if (form_id.adexitbal_fid.ToString()==formid|| form_id.adexitbal_fid.ToString()==formid)
            {              
                tname = "Company_" + fpart + "_Ledge";
                InsertLedge(tname, date_, particular, docID, crd, dbt, table_id, formid, Call.GTD(Constant.Company_id));
            }
            else
            {
                tname = "Company_" + separt + "_Ledge";
                InsertLedge(tname, date_, particular, docID, crd, dbt, table_id, formid, Call.GTD(Constant.Company_id));

                crd = !crd;
                dbt = !dbt;

                tname = "Company_" + fpart + "_Ledge";
                InsertLedge(tname, date_, particular, docID, crd, dbt, table_id, formid, Call.GTD(Constant.Company_id));
            }
        }
        public static void Ledger_Update(Ledgerdt dt)
        {
            if (form_id.adexitbal_fid.ToString() == dt.form_id || form_id.adexitbal_fid.ToString() == dt.form_id)
            {
                tname = "Company_" + dt.F_party + "_Ledge";
                InsertLedge(tname, dt.date.ToString(), dt.particular + " for " + Call.ret_Name(dt.S_party.Substring(8, dt.S_party.Length - 8), Constant.CompanyDB, CompanyDB.t_Company_T), dt.folio, dt.credit, dt.debit, dt.table_id, dt.form_id, Call.GTD(Constant.Company_id));
            }
            else
            {
                tname = dt.S_party + "_Ledge";
                InsertLedge(tname, dt.date.ToString(), dt.particular, dt.folio, dt.credit, dt.debit, dt.table_id, dt.form_id, Call.GTD(Constant.Company_id));


                dt.debit = !dt.debit;
                dt.credit = !dt.credit;

                tname = "Company_" + dt.F_party + "_Ledge";
                InsertLedge(tname, dt.date.ToString(), dt.particular + " for " + Call.ret_Name(dt.S_party.Substring(8, dt.S_party.Length - 8), Constant.CompanyDB, CompanyDB.t_Company_T), dt.folio, dt.credit, dt.debit, dt.table_id, dt.form_id, Call.GTD(Constant.Company_id));
            }          
        }
        public static void Item_Update(string fpart, string itmno_, string tnx, string docID, string table_id,string form_id)
        {           
            tname = itmno_ + "_Ledge";            
            string spartl = "";
            bool crd = false, dbt = false;
            string querry = "Select* from " + table_id.Substring(0, table_id.Length - 1) + "D_T where bill_ID_fkey = '" + docID + "'";
            DataTable ds= Call.ret_dt(querry,Constant.TransDB);
            double qnty =0;           
            int i = 0;
            while (i < ds.Rows.Count)
            {
                qnty += Convert.ToDouble(ds.Rows[i]["qnty"].ToString());
                i++;
            }
            if (tnx == "Credit")
            {
                crd = true;
                spartl = qnty + " pieces recieved againt Doc " + docID + " by " + fpart;
            }
            else if (tnx == "Debit")
            {
                dbt = true;
                spartl = qnty + " pieces given againt Doc " + docID + " by " + fpart;
            }
            InsertLedge(tname,DateTime.Now.ToString("dd-MM-yyyy"),"",docID,crd,dbt,table_id, form_id,Call.GTD(Constant.Company_id));
        }
        public static void Item_Update(Ledgerdt dt)
        {           
            string qurry = "", spartl = "";
            tname = "Item_" + dt.item + "_Ledge";
           
            if (dt.credit)
            {
                spartl = dt.credit + " pieces recieved againt Doc " + dt.folio + " by " + dt.F_party;
            }
            else if (dt.debit)
            {
                spartl = dt.debit + " pieces given againt Doc " + dt.folio + " by " + dt.F_party;
            }
            InsertLedge(tname, dt.date.ToString(), spartl, dt.folio, dt.credit, dt.debit,dt.table_id, dt.form_id, Call.GTD(Constant.Company_id));
        }
       static bool InsertLedge(string tn,string date, string particular, string folio, bool credit, bool debit, string table_id, string form_id, string com_id)
        {
            string qurry = "insert into ["+tn+ "] (date,particular,folio,credit,debit,form_id,table_id,com_id) values(@date,@particular,@folio,@credit,@debit, @form_id,@table_id,@com_id)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LedgerDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@date", date);
            cmd.Parameters.Add("@particular", particular);
            cmd.Parameters.Add("@folio", folio);
            cmd.Parameters.Add("@credit", credit.ToString());
            cmd.Parameters.Add("@debit", debit.ToString());
            cmd.Parameters.Add("@form_id", form_id);
            cmd.Parameters.Add("@table_id", table_id);
            cmd.Parameters.Add("@com_id", com_id);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static void New_Ledger(string obj,string for_)
        {
            tname = obj + "_Ledge";            
            Ledgedt dt = new Ledgedt();
            dbo_Process.createDB(dt,Constant.LedgerDB,tname);
        }
        public static void Ledger_Update_GST(string fpart, string separt, string tnx, string docID, double amt,string seDB, string isReg = "Not")
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[Constant.CompanyDB].ConnectionString);
            //tname = separt + "_Ledge";
            con.Open();
            string spartl = "";
            spartl = "Tax " + tnx + " againt issued Doc No." + docID + "";
            string qurry = "";
            SqlCommand cmd1 = new SqlCommand(qurry, con);
            double tax = 0;

            if (Call.ret_State(fpart, Constant.CompanyDB) != Call.ret_State(separt, seDB))
            {
                tax = amt * 0.05;
                qurry = "insert into IGST (date,Particular,folio," + tnx + ",Com_fkey_Id,IsRegister) values('" + DateTime.Now.ToString("yyyyMMdd") + "','" + spartl + "','" + docID + "','" + tax + "','"+ Call.GTD(Constant.Company_id)+"','"+isReg+"') ";
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
            else if (Call.ret_State(fpart, Constant.CompanyDB) == Call.ret_State(separt, seDB))
            {
                tax = amt * 0.025;
                qurry = "insert into SGST (date,Particular,folio," + tnx + ",Com_fkey_Id,IsRegister) values('" + DateTime.Now.ToString("yyyyMMdd") + "','" + spartl + "','" + docID + "','" + tax + "','"+Call.GTD(Constant.Company_id)+ "','" + isReg + "') ";
                cmd1 = new SqlCommand(qurry, con);
                try
                {
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
                qurry = "insert into CGST (date,Particular,folio," + tnx + ",Com_fkey_Id,IsRegister) values('" + DateTime.Now.ToString("yyyyMMdd") + "','" + spartl + "','" + docID + "','" + tax + "','" + Call.GTD(Constant.Company_id)+ "','" + isReg + "') ";
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
        public static double Ledger_Balance(string tname)
        {           
            string querry = "select * from [" + tname + "_Ledge] ";
           
            DataTable ds = new DataTable();
            ds = Fall.fill_ds(querry,Constant.LedgerDB);
            double crd = 0, dbt = 0, bal = 0;
            int i = 0;
            while (ds.Rows.Count>i)
            {
                crd += Convert.ToDouble(ds.Rows[i]["credit"].ToString());
                dbt += Convert.ToDouble(ds.Rows[i]["debit"].ToString());
                bal = crd - dbt;
                i++;
            }
            return bal;
        }
        
        public static bool IsLedger(string agr)
        {
           return Fall.IsObj(agr += "_Ledge",Constant.LedgerDB);
        }
    }
}
