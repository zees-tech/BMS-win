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
    public partial class Stock : Form
    {
        public Stock(string callas)
        {
            InitializeComponent();
            
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
            con.Open();
            string qurry = "Select * from Stock_T ";
            SqlCommand cmd = new SqlCommand(qurry, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dataDB = new DataTable();
            try
            {
                sda.Fill(dataDB);                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            int n = 0;
            while(dataDB.Rows.Count >n)
            {                
                dataGridView1.Rows[dataGridView1.NewRowIndex].Cells[0].Value = dataDB.Rows[n][1];
                dataGridView1.Rows[dataGridView1.NewRowIndex].Cells[1].Value = dataDB.Rows[n][2];
                dataGridView1.Rows[dataGridView1.NewRowIndex].Cells[2].Value = Calculator.ret_Name(dataDB.Rows[n][5].ToString(), "SupplierDB");
                dataGridView1.Rows[dataGridView1.NewRowIndex].Cells[3].Value = Calculator.ret_rate(dataDB.Rows[n][0].ToString(),"Stock_T");
                dataGridView1.Rows[dataGridView1.NewRowIndex].Cells[4].Value = Calculator.price_calculator(Convert.ToDouble(dataGridView1.Rows[n].Cells[0].Value));
                SqlConnection con5 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LedgerDB"].ConnectionString);            
                string querry = "select * from [Item_" + dataDB.Rows[n][1] + "_Ledge] ";
                cmd = new SqlCommand(querry, con5);
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
                dataGridView1.Rows[n].Cells[4].Value =bal.ToString() ;
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Ledger ss = new Ledger("Stock", dataGridView1.Rows[e.RowIndex].Cells[0].ToString());
            ss.Show();
        }
    }
}
