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
    public partial class AdExistBal : Form
    {
        public AdExistBal(Ledgerdt dt)
        {
            InitializeComponent();
            credittn.Checked = true;
            debitbtn.Checked = false;
            credittn.Show();
            debitbtn.Show();
            l_dt = dt;
        }
        Ledgerdt l_dt = new Ledgerdt();
        
        private void savebtn_Click(object sender, EventArgs e)
        {
            l_dt.credit = credittn.Checked;
            l_dt.debit = debitbtn.Checked;
            l_dt.particular = particulartxt.Text;
            l_dt.folio = "Manual";
            l_dt.date = DateTime.Now;
            Authenticate ss = new Authenticate();
            ss.ShowDialog(); 
            if (Authenticate.authenticate)
            {
                Ledger_Process.Ledger_Update(l_dt);
            }           
            savebtn.Enabled = false;
            this.Close();
        }

        private void amttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(amttxt.Text);
            }
            catch (Exception)
            {
                amttxt.Text = "0";
                MessageBox.Show("Invalid Amount");
            }
        }

        private void credittn_CheckedChanged(object sender, EventArgs e)
        {
            if (credittn.Checked)
            {
                debitbtn.Checked = false;
            }
        }

        private void debitbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (debitbtn.Checked)
            {
                credittn.Checked = false;
            }
        }
    }
}
