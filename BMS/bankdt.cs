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
    public partial class bankdt : nform
    {
        public bankdt(bankdtFdt ck)
        {
            lck = ck;
            InitializeComponent();
            fillds();
        }
        bankdtFdt lck = new bankdtFdt();
        DataTable ds = new DataTable();
        private int pos = 0;
        
        private void fillds()
        {
            ds = Fall.fill_ds("Select * from ["+CompanyDB.t_Bank_T+"] where "+CompanyDB.c_Bank_T.f_holder_fkey+" = "+lck.holder_id, Constant.CompanyDB);
            if (ds.Rows.Count>0)
            {
                newbtn.Show();
                newbtn.Enabled = true;
                nextbtn.Show();
                nextbtn.Enabled = true;
                previousbtn.Show();
                previousbtn.Enabled = true;
                savebtn.Hide();
                savebtn.Enabled = false;
                discardbtn.Hide();
                discardbtn.Enabled = false;
                Nav(0);
            }
            else
            {
                newbtn.Hide();
                newbtn.Enabled = false;
                nextbtn.Hide();
                nextbtn.Enabled = false;
                previousbtn.Hide();
                previousbtn.Enabled = false;
                savebtn.Show();
                savebtn.Enabled = true;
                discardbtn.Show();
                discardbtn.Enabled = true;
            }
        }
        private bool condition()
        {
            bool chk = true;

            return chk;
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            if (condition())
            {
                CompanyDB.Insert_Bank_T(lck.holder_id,lck.holder_tname, banknametxt.Text, AccNametxt.Text, AccNumtxt.Text, ifsctxt.Text);
                banknametxt.ReadOnly = true;
                AccNametxt.ReadOnly = true;
                AccNumtxt.ReadOnly = true;
                ifsctxt.ReadOnly = true;
                newbtn.Show();
                newbtn.Enabled = true;
                nextbtn.Show();
                nextbtn.Enabled = true;
                previousbtn.Show();
                previousbtn.Enabled = true;
                savebtn.Hide();
                savebtn.Enabled = false;
                discardbtn.Hide();
                discardbtn.Enabled = false;
            }
        }       
        private void discardbtn_Click(object sender, EventArgs e)
        {
            banknametxt.Clear();
            AccNametxt.Clear();
            AccNumtxt.Clear();
            ifsctxt.Clear();
        }
        private void newbtn_Click(object sender, EventArgs e)
        {
            banknametxt.ReadOnly = false;
            AccNametxt.ReadOnly = false;
            AccNumtxt.ReadOnly = false;
            ifsctxt.ReadOnly = false;
            newbtn.Hide();
            newbtn.Enabled = false;
            nextbtn.Hide();
            nextbtn.Enabled = false;
            previousbtn.Hide();
            previousbtn.Enabled = false;
            savebtn.Show();
            savebtn.Enabled = true;
            discardbtn.Show();
            discardbtn.Enabled = true;
        }
        private void Nav(int i)
        {
            if (ds.Rows.Count>0)
            {
                banknametxt.ReadOnly = false;
                AccNametxt.ReadOnly = false;
                AccNumtxt.ReadOnly = false;
                ifsctxt.ReadOnly = false;
                banknametxt.Text = ds.Rows[i][CompanyDB.c_Bank_T.f_bank_name].ToString();
                AccNametxt.Text = ds.Rows[i][CompanyDB.c_Bank_T.f_Name].ToString();
                AccNumtxt.Text = ds.Rows[i][CompanyDB.c_Bank_T.f_AccountNo].ToString();
                ifsctxt.Text = ds.Rows[i][CompanyDB.c_Bank_T.f_IFSC].ToString();
                banknametxt.ReadOnly = true;
                AccNametxt.ReadOnly = true;
                AccNumtxt.ReadOnly = true;
                ifsctxt.ReadOnly = true;
            }
        }
        private void nextbtn_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos > ds.Rows.Count - 1)
            {
                pos--;
            }
            Nav(pos);
        }

        private void previousbtn_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos < 0)
            {
                pos++;
            }
            Nav(pos);
        }
    }
   public class bankdtFdt
    {
        public string holder_id;
        public string holder_tname;
    }
}
