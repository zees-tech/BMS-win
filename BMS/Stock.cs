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
    public partial class Stock : nform 
    {
        public Stock(string callas)
        {
            InitializeComponent();
            
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            string qurry = "Select * from Item_T ";           
            DataTable dataDB = new DataTable();
            dataDB = Fall.fill_ds(qurry,Constant.StockDB);           
            int n = 0;
            while(dataDB.Rows.Count >n)
            {
                double bal = 0;//Call.ret_Balance(dataDB.Rows[n][1].ToString(), Constant.Item);
                dataGridView1.Rows.Add(dataDB.Rows[n][StockDB.c_Item_T.f_stockId], dataDB.Rows[n][StockDB.c_Item_T.f_description], combinedname(dataDB.Rows[n][StockDB.c_Item_T.f_supplier_fkey].ToString()), Call.ret_item_rate(dataDB.Rows[n][StockDB.c_Item_T.f_stockId].ToString()), Call.price_calculator(Convert.ToDouble(Call.ret_item_rate(dataDB.Rows[n][StockDB.c_Item_T.f_stockId].ToString()))),bal.ToString());
                n++;
            }
        }
      private string combinedname(string str)
        {
            try
            {
                Convert.ToInt32(str);
                return Call.ret_Name(str, Constant.CompanyDB);
            }
            catch (Exception)
            {
                List<string> names = new List<string> { };
                string nms = "";
                names = Call.Break_String(str);
                int i = 0;
                while (i<names.Count)
                {
                    nms += Call.ret_Name(names[i], Constant.CompanyDB);
                    if (i<names.Count-1)
                    {
                        nms += " ";
                    }
                    i++;
                }                
                return nms;
            }            
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Ledger ss = new Ledger("Item", dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            ss.Show();
        }
    }
}
