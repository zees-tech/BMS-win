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
    public partial class AdUser : Form
    {
        public AdUser()
        {
            InitializeComponent();            
        }

        private void AdUser_Load(object sender, EventArgs e)
        {
            if (!Call.ret_isRecord("Login_T",Constant.CompanyDB))
            {
                typecmb.SelectedIndex = 0;
                typecmb.Enabled = false;
            }
            else
            {
                typecmb.SelectedIndex = 1;
                typecmb.Enabled = true;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            string qurry = "insert into Login_T (LoginID,Password,Name,Type,date_) values('" + useridtxt.Text + "','" + passwordtxt.Text + "','" + nametxt.Text + "','" + typecmb.Text + "','" + DateTime.Today.ToString("yyyyMMdd") + "')";
            Fall.SaveDB(qurry, Constant.CompanyDB);
            this.Hide();
            this.Close();
        }

        private void useridtxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
