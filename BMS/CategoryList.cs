using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
    public partial class CategoryList : Form
    {
        public CategoryList(string database)
        {
            InitializeComponent();
            fillcatdgv(database);
        }
        
        private void fillcatdgv(string db)
        {
            DataTable ds = new DataTable();
            ds = Fall.fill_ds("Select * from Category_T", db);
            int i = 0;
            while (i<ds.Rows.Count)
            {
                dgv.Rows.Add(ds.Rows[i][CompanyDB.c_Category_T.f_Name].ToString());
                i++;
            }
        }

        public string cat;

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cat = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
        }
    }
}
