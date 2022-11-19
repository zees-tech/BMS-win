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
    public partial class ChangePwd : Form
    {
        public ChangePwd()
        {
            InitializeComponent();
            savebtn.Enabled = false;
        }

        private void confirmpasstxt_TextChanged(object sender, EventArgs e)
        {
            if (confirmpasstxt.Text==newpasstxt.Text)
            {
                confirmpasstxt.ForeColor = Color.Green;
                savebtn.Enabled = true;
            }
            else
            {
                confirmpasstxt.ForeColor = Color.Red;
                savebtn.Enabled = false;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            string uid = Call.GTD(Constant.User_id);
            string qurry = "Update [Login_T] SET [Password]='" + newpasstxt.Text+ "' where [LoginID] = '" +Call.GTD(Constant.User_id) + "' ";
            if (Fall.SaveDB(qurry, Constant.CompanyDB))
            {
                MessageBox.Show("Password change successfully");
            }
            else
            {
                MessageBox.Show("Operation Fail");
            }
            this.Close();
        }
    }
}
