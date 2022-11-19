using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BMS
{
    public partial class Ledger : nform
    {
        string Callas;
        public Ledger(string callas, string party)
        {
            InitializeComponent();
            Callas = callas;
            set_label(party);
            loadData(party);
        }
        private void Edit()
        {
            dataGridView1.ReadOnly = false;
        }
        private void NoEdit()
        {
            dataGridView1.ReadOnly = true;
        }
        private void set_label(string obj)
        {
            ledgerlbl.Text = obj + " Ledger";
        }
        private void dgvdelete()
        {
            while (dataGridView1.Rows.Count > 0)
            {
                try
                {
                    dataGridView1.Rows.RemoveAt(0);
                }
                catch (Exception)
                {

                }
            }
        }
        private void loadData(string obj)
        {
            string t_name = "abc";
            switch (Callas)
            {
                case "Item":
                    adManualRecbtn.Hide();
                    t_name = "Item_" + obj + "_Ledge";
                    break;
                default:
                    obj = Call.ret_id("Name", obj, Constant.CompanyDB, "Company_T");
                    t_name = "Company_" + obj + "_Ledge";
                    break;
            }
            string qurry = "";
            qurry = "Select * from [" + t_name + "] where com_id ='" + Call.GTD(Constant.Company_id) + "'";
            if (Callas == "Item" || Callas == "Company")
            {
                qurry = "Select * from [" + t_name + "]";
            }

            dgvdelete();
            DataTable data = new DataTable();
            DataTable ds = new DataTable();
            data = Fall.fill_ds(qurry, Constant.LedgerDB);
            int n = 0, i = 0;
            double bal = 0;
            string type_ = ""; 
                         

            Edit();
            if (data.Rows.Count > 0)
            {
                while (data.Rows.Count > n)
                {
                    List<string> field = new List<string>();
                    List<string> f_val = new List<string>();
                    string part = data.Rows[n]["particular"].ToString();
                    double ent = 1;                   
                    string crd = "NA", dbt = "NA";
                    
                    switch (Call.ret_substring(data.Rows[n]["table_id"].ToString(), '_'))
                    {
                        case "Job_T":
                            {
                                if (Callas == "Item")
                                {
                                    type_ = "q";
                                    field.Add("item_no_fkey");
                                    if (field[0] == "item_no_fkey")
                                    {
                                        f_val.Add(Call.ret_substring(obj,false ,false,false));
                                    }
                                    //field.Add("job_fkey");                                    
                                    //if (field[1]== "job_fkey")
                                    //{
                                    //    f_val.Add(Call.ret_substring(obj, true,true,true));
                                    //}

                                }
                                else
                                {
                                    type_ = "r*q";
                                }
                                ent *= Call.ret_transValue(data.Rows[n]["folio"].ToString(), data.Rows[n]["table_id"].ToString().Substring(0, data.Rows[n]["table_id"].ToString().Length - 1) + "D_T", type_, field, f_val);
                                break;
                            }
                        case "JobRecieving_T":
                            {
                                if (Callas == "Item")
                                {
                                    type_ = "q";
                                    field.Add("item_no_fkey");
                                    if (field[0] == "item_no_fkey")
                                    {
                                        f_val.Add(Call.ret_substring(obj, false, false, false));
                                    }
                                    field.Add("job_fkey");
                                    if (field[1] == "job_fkey")
                                    {
                                        f_val.Add(Call.ret_substring(obj, true, true, true));
                                    }
                                }
                                else
                                {
                                    type_ = "r*q";
                                }
                                ent *= Call.ret_transValue(data.Rows[n]["folio"].ToString(), data.Rows[n]["table_id"].ToString().Substring(0, data.Rows[n]["table_id"].ToString().Length - 1) + "D_T", type_, field, f_val);
                                break;
                            }
                        case "Stock_T":
                            {
                                if (Callas == "Item")
                                {
                                    type_ = "q";
                                    field.Add("item_no_fkey");
                                    f_val.Add(obj);
                                    //if (field[0] == "item_no_fkey")
                                    //{
                                    //    f_val.Add(Call.ret_substring(obj, false, false, false));
                                    //}                                    
                                }
                                else
                                {
                                    type_ = "r*q";
                                }
                                    ent *= Call.ret_transValue(data.Rows[n]["folio"].ToString(), data.Rows[n]["table_id"].ToString().Substring(0, data.Rows[n]["table_id"].ToString().Length - 1) + "D_T", type_, field, f_val);
                                break;
                            }
                        case "Bill_T":
                            {
                                if (Callas == "Item")
                                {
                                    type_ = "q";
                                    field.Add("item_no_fkey");
                                    f_val.Add(obj);
                                    //if (field[0] == "item_no_fkey")
                                    //{
                                    //    f_val.Add(Call.ret_substring(obj, false, false, false));
                                    //}
                                }
                                else
                                {
                                    type_ = "r*q";
                                }
                                ent *= Call.ret_transValue(data.Rows[n]["folio"].ToString(), data.Rows[n]["table_id"].ToString().Substring(0, data.Rows[n]["table_id"].ToString().Length - 1) + "D_T", type_, field, f_val);
                                break;
                            }
                        case "Challan_T":
                            {
                                if (Callas == "Item")
                                {
                                    type_ = "q";
                                    field.Add("item_no_fkey");
                                    if (field[0] == "item_no_fkey")
                                    {
                                        f_val.Add(Call.ret_substring(obj, false, false, false));
                                    }
                                }
                                else
                                {
                                    type_ = "r*q";
                                }
                                ent *= Call.ret_transValue(data.Rows[n]["folio"].ToString(), data.Rows[n]["table_id"].ToString().Substring(0, data.Rows[n]["table_id"].ToString().Length - 1) + "D_T", type_, field, f_val);
                                break;
                            }
                        case "Job_Bill_T":
                            {
                                if (Callas == "Item")
                                {
                                    type_ = "q";
                                    field.Add("item_no_fkey");
                                    if (field[0] == "item_no_fkey")
                                    {
                                        f_val.Add(Call.ret_substring(obj, false, false, false));
                                    }
                                    field.Add("job_fkey");
                                    if (field[1] == "job_fkey")
                                    {
                                        f_val.Add(Call.ret_substring(obj, true, true, true));
                                    }
                                }
                                else
                                {
                                    type_ = "r*q";
                                }
                                ent *= Call.ret_transValue(data.Rows[n]["folio"].ToString(), data.Rows[n]["table_id"].ToString().Substring(0, data.Rows[n]["table_id"].ToString().Length - 1) + "D_T", type_, field, f_val);
                                break;
                            }
                        case "Job_Challan_T":
                            {
                                if (Callas == "Item")
                                {
                                    type_ = "q";
                                    field.Add("item_no_fkey");
                                    if (field[0] == "item_no_fkey")
                                    {
                                        f_val.Add(Call.ret_substring(obj, false, false, false));
                                    }
                                    field.Add("job_fkey");
                                    if (field[1] == "job_fkey")
                                    {
                                        f_val.Add(Call.ret_substring(obj, true, true, true));
                                    }
                                }
                                else
                                {
                                    type_ = "r*q";
                                }
                                ent *= Call.ret_transValue(data.Rows[n]["folio"].ToString(), data.Rows[n]["table_id"].ToString().Substring(0, data.Rows[n]["table_id"].ToString().Length - 1) + "D_T", type_, field, f_val);
                                break;
                            }
                        case "JobRecieving_Bill_T":
                            {
                                if (Callas == "Item")
                                {
                                    type_ = "q";
                                    field.Add("item_no_fkey");
                                    if (field[0] == "item_no_fkey")
                                    {
                                        f_val.Add(Call.ret_substring(obj, false, false, false));
                                    }
                                    field.Add("job_fkey");
                                    if (field[1] == "job_fkey")
                                    {
                                        f_val.Add(Call.ret_substring(obj, true, true, true));
                                    }
                                }
                                else
                                {
                                    type_ = "r*q";
                                }
                                ent *= Call.ret_transValue(data.Rows[n]["folio"].ToString(), data.Rows[n]["table_id"].ToString().Substring(0, data.Rows[n]["table_id"].ToString().Length - 1) + "D_T", type_, field, f_val);
                                break;
                            }
                        case "JobRecieving_Challan_T":
                            {
                                if (Callas == "Item")
                                {
                                    type_ = "q";
                                    field.Add("item_no_fkey");
                                    if (field[0] == "item_no_fkey")
                                    {
                                        f_val.Add(Call.ret_substring(obj, false, false, false));
                                    }
                                    field.Add("job_fkey");
                                    if (field[1] == "job_fkey")
                                    {
                                        f_val.Add(Call.ret_substring(obj, true, true, true));
                                    }
                                }
                                else
                                {
                                    type_ = "r*q";
                                }
                                ent *= Call.ret_transValue(data.Rows[n]["folio"].ToString(), data.Rows[n]["table_id"].ToString().Substring(0, data.Rows[n]["table_id"].ToString().Length - 1) + "D_T", type_, field, f_val);
                                break;
                                break;
                            }
                        case "Payment_T":
                            {
                                ds = Fall.fill_ds("Select * from " + data.Rows[n]["table_id"].ToString().Substring(0, data.Rows[n]["table_id"].ToString().Length - 1) + "D_T where " + TranDB.c_Payment_D_T.f_pay_fkey + " = '" + data.Rows[n]["folio"].ToString() + "'");
                                if (ds.Rows.Count > 0)
                                {
                                    while (ds.Rows.Count > i)
                                    {
                                        ent *= Convert.ToDouble(ds.Rows[i]["amount"].ToString());
                                        if (ent > 0)
                                        {
                                            crd = ent.ToString();
                                        }
                                        else if (ent < 0)
                                        {
                                            dbt = (ent * -1).ToString();
                                        }
                                        bal += ent;
                                        dataGridView1.Rows.Add(data.Rows[n]["date"].ToString(), part, data.Rows[n]["folio"].ToString(), crd, dbt, bal);
                                        i++;
                                    }
                                }
                                goto ABC;
                                break;
                            }
                        case "Resturn_Challan_T":
                            {
                                if (Callas == "Item")
                                {
                                    type_ = "q";
                                    field.Add("item_no_fkey");
                                    if (field[0] == "item_no_fkey")
                                    {
                                        f_val.Add(Call.ret_substring(obj, false, false, false));
                                    }                                   
                                }
                                else
                                {
                                    type_ = "r*q";
                                }
                                ent *= Call.ret_transValue(data.Rows[n]["folio"].ToString(), data.Rows[n]["table_id"].ToString().Substring(0, data.Rows[n]["table_id"].ToString().Length - 1) + "D_T", type_, field, f_val);
                                break;
                                break;
                            }
                        case "Resturn_Note_T":
                            {
                                if (Callas == "Item")
                                {
                                    type_ = "q";
                                    field.Add("item_no_fkey");
                                    if (field[0] == "item_no_fkey")
                                    {
                                        f_val.Add(Call.ret_substring(obj, false, false, false));
                                    }
                                }
                                else
                                {
                                    type_ = "r*q";
                                }
                                ent *= Call.ret_transValue(data.Rows[n]["folio"].ToString(), data.Rows[n]["table_id"].ToString().Substring(0, data.Rows[n]["table_id"].ToString().Length - 1) + "D_T", type_, field, f_val);
                                break;
                                break;
                            }
                    }

                    if (Convert.ToBoolean(data.Rows[n]["credit"].ToString()))
                    {
                        crd = ent.ToString();
                        bal += ent;
                    }
                    else if (Convert.ToBoolean(data.Rows[n]["debit"].ToString()))
                    {
                        dbt = ent.ToString();
                        bal -= ent;
                    }                         
                    dataGridView1.Rows.Add(data.Rows[n]["date"].ToString(), part, data.Rows[n]["folio"].ToString(), crd, dbt, bal);
                ABC:
                    n++;
                }
                Object_List.st = true;
            }
            else
            {
                MessageBox.Show("No record found");
                //this.Close();
                Object_List.st = true;
            }
            NoEdit();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void adManualRecbtn_Click(object sender, EventArgs e)
        {
            Ledgerdt dt = new Ledgerdt();
            dt.F_party = Call.GTD(Constant.Company_id);
            int len = ledgerlbl.Text.Length - " Ledger".Length;

            dt.S_party = "Company_" + Call.ret_id("Name", ledgerlbl.Text.Substring(0, len), Constant.CompanyDB, CompanyDB.t_Company_T);
            AdExistBal ss = new AdExistBal(dt);
            ss.ShowDialog();
            loadData(ledgerlbl.Text.Substring(0, len));
        }
    }
}
