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
    public partial class contactf : Form
    {
        ContactFdt lck = new ContactFdt();
        public contactf(ContactFdt ck)
        {
            InitializeComponent();
            lck = ck;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numbertxt.TextLength>5)
            {
                string qurry = "insert into " + CompanyDB.t_Contact_T + " (" + CompanyDB.c_Contact_T.f_holder_fkey + "," + CompanyDB.c_Contact_T.f_holder_table + "," + CompanyDB.c_Contact_T.f_name + "," + CompanyDB.c_Contact_T.f_phone + ") values('" + lck.fkey + "','" + lck.holder_tbl + "','" + nametxt.Text + "','" + numbertxt.Text + "')";
                Fall.SaveDB(qurry, Constant.CompanyDB);
                nametxt.Enabled = false;
                numbertxt.Enabled = false;
                button1.Enabled = false;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Entry");
            }
        }
    }
    public class ContactFdt
    {
        public string fkey;
        public string holder_tbl;
    }
}
