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
    public partial class Object_List : nform 
    {
        string Callas;
        DataTable dataDB = new DataTable();
        public Object_List(string callas)
        {
            Callas = callas;
            InitializeComponent();
            label1.Text = callas + " List";
            loadData();
        }
        private void Edit()
        {
            dataGridView1.ReadOnly = false;
        }
        private void NoEdit()
        {
            dataGridView1.ReadOnly = true;
        }
        private void loadData()
        {
            string t_name = CompanyDB.t_Company_T, DataBase = Constant.CompanyDB;
            string cat_id = Call.ret_data(DataBase, "Category_T", "Name", Callas, 0);
            string qurry = "Select * from [" + t_name + "] Where Company_T.category = '"+cat_id+"'";
            dataDB = Fall.fill_ds(qurry, DataBase);
            Edit();
            int n = 0;
            if (dataDB.Rows.Count > n)
            {
                dataGridView1.ReadOnly = false;
                while (dataDB.Rows.Count > n)
                {
                    dataGridView1.Rows.Add(dataDB.Rows[n][CompanyDB.c_Company_T.f_Name].ToString(), dataDB.Rows[n][CompanyDB.c_Company_T.f_Alias].ToString(), dataDB.Rows[n][CompanyDB.c_Company_T.f_GSTIN].ToString(), Call.ret_Balance(dataDB.Rows[n]["Id"].ToString(), Callas));
                    n++;
                }
                dataGridView1.ReadOnly = true;
            }
            else
            {
                dataGridView1.Rows.Add("No Record Available!");
            }
            NoEdit();
        }
        public static bool st = true;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(dataDB.Rows[e.RowIndex][CompanyDB.c_Category_T.f_LedgerReq].ToString()))
            {
                Ledger ss = new Ledger(Callas, dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (st)
                {
                    ss.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("It is non accountable A/c!");
            }        
        }
    }
}
