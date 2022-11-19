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
    public partial class Authenticate : Form
    {
        public  Authenticate(string User_type="Standard")
        {
            InitializeComponent();
            user_t = User_type;       
        }
        bool CK = true;
        string user_t;
        private void keytxt_TextChanged(object sender, EventArgs e)
        {
            if (CK)
            {
                keytxt.Clear();
                keytxt.UseSystemPasswordChar = true;
                CK = false;
            }            
        }
        public static bool authenticate = false;
        private void confirmbtn_Click(object sender, EventArgs e)
        {
            DataTable ds = new DataTable();
            ds = Fall.fill_ds("Select * from Login_T where LoginID = '" + Call.GTD(Constant.User_id) + "' and Password = '" + keytxt.Text + "'", Constant.CompanyDB);
            if (ds.Rows.Count>0)
            {
                authenticate = true;                         
            }
            else
            {
                MessageBox.Show("Authentication fails");
            }
            this.Close();
        }
    }
}
