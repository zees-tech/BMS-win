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
    public partial class AdExitStock : Form
    {
        public AdExitStock()
        {
            InitializeComponent();
            var CNT = Controls;
            comlbl.Text = comlbl.Text = Call.ret_Name(Call.GTD(Constant.Company_id), Constant.CompanyDB);
            foreach (Control item in CNT)
            {
                if (!(item is TextBox) && !(item is DataGridView) && !(item is Label))
                {
                    item.Enabled = false;
                    if (item is Button || item is CheckBox)
                    {
                        item.Hide();
                    }
                }
            }
            savebtn.Show();
            savebtn.Enabled = true;
            discardbtn.Show();
            discardbtn.Enabled = true;
            addbtn.Show();
            delbtn.Show();
            newitemchk.Show();
            newitemchk.Enabled = true;
            NoEdit();

            fillpartycombo();                 
        }
        private void fillpartycombo()
        {
            combo dsr = new combo();
            dsr.database = Constant.CompanyDB;
            dsr.displayMember = "Name";
            dsr.valueMember = "Id";
            dsr.qurry = "SELECT Company_T.Name, Category_T.sub FROM Category_T INNER JOIN Company_T ON Category_T.Id = Company_T.category WHERE(Category_T.sub = 'Creditor')";

            partyccmbx.Enabled = true;
            partyccmbx.DisplayMember = dsr.displayMember;
            partyccmbx.ValueMember = dsr.valueMember;
            partyccmbx.DataSource = Fall.fill_ds(dsr.qurry,dsr.database);
            partyccmbx.Text = "Select Party";
                    
        }
        private void NoEdit()
        {
            dgvitemdt.ReadOnly = true;
            ratetxt.ReadOnly = true;
            qntytxt.ReadOnly = true;
            hsntxt.ReadOnly = true;
            descripttxt.ReadOnly = true;
        }
        private void Edit()
        {
            dgvitemdt.ReadOnly = false;
            ratetxt.ReadOnly = false;
            qntytxt.ReadOnly =  false;
            hsntxt.ReadOnly = false;
            descripttxt.ReadOnly = false;
        }
        private void dgvdelete()
        {
            int i = 0;
            while (dgvitemdt.Rows.Count > i)
            {
                dgvitemdt.Rows.RemoveAt(0);
                i++;
            }
        }
        private void Clear()
        {
            Edit();
            dgvdelete();
            ratetxt.Clear();
            qntytxt.Clear();
            hsntxt.Clear();
            descripttxt.Clear();
            NoEdit();
        }
        private void partyccmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (partyccmbx.Text != "Select Party")
            {
                newitemchk.Enabled = true;
                string qurry = "Select stockId from Item_T where supplier_fkey = '"+ Call.ret_id("Name", partyccmbx.Text, Constant.CompanyDB,CompanyDB.t_Company_T) + "'";
                List<string> itms = new List<string> { };
                itms = Fall.fill_ListDB(qurry,Constant.StockDB);
                itemcmb.Enabled = true;
                int i = 0;
                if (itms.Count > i)
                {
                    itemcmb.Items.Clear();
                }
                while (itms.Count>i)
                {
                    itemcmb.Items.Add(itms[i]);
                    i++;
                }
                itemcmb.SelectedIndex = itms.Count - 1;              
            }            
        }
        private void itemcmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemcmb.Text != "Select Variable")
            {
                Edit();
                descripttxt.Text = Call.set_detail(itemcmb.Text, Constant.Item)[0];
                hsntxt.Text = Call.set_detail(itemcmb.Text, Constant.Item)[1];
                ratetxt.Text = Call.ret_item_rate(itemcmb.Text).ToString();
                addbtn.Enabled = true;
                NoEdit();
                qntytxt.ReadOnly = false;
                ratetxt.ReadOnly = false;
            }
            else
            {                     
                Edit();
                descripttxt.Clear();
                hsntxt.Clear();
                ratetxt.Clear();
                qntytxt.Clear();
                addbtn.Enabled = false;
                NoEdit();
            }
        }
        private void newitemchk_CheckedChanged(object sender, EventArgs e)
        {
            if (newitemchk.Checked)
            {
                itemcmb.Enabled = false;
                descripttxt.ReadOnly = false;
                descripttxt.Clear();
                hsntxt.ReadOnly = false;
                hsntxt.Clear();
                qntytxt.ReadOnly = false;
                qntytxt.Clear();
                ratetxt.ReadOnly = false;
                ratetxt.Clear();
                addbtn.Enabled = true;      
            }
            else
            {
                itemcmb.Enabled = true;
                descripttxt.Clear();
                descripttxt.ReadOnly = true;
                hsntxt.Clear();
                hsntxt.ReadOnly = true;
                itemcmb_SelectedIndexChanged(sender, e);              
            }
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            if (condition())
            {
                delbtn.Enabled = true;
                if (newitemchk.Checked)
                {
                    dgvitemdt.Rows.Add(Constant.NEW, descripttxt.Text, hsntxt.Text, qntytxt.Text, ratetxt.Text);
                }
                else
                {
                    dgvitemdt.Rows.Add(itemcmb.Text, descripttxt.Text, hsntxt.Text, qntytxt.Text, ratetxt.Text);
                }
                addbtn.Enabled = false;
                newitemchk.Checked = false;
                partyccmbx.Enabled = false;
            }            
        }
        private void delbtn_Click(object sender, EventArgs e)
        {
            dgvitemdt.Rows.RemoveAt(dgvitemdt.SelectedRows[0].Index);
            if (dgvitemdt.Rows.Count<1)
            {
                delbtn.Enabled = false;
            }
        }
        private bool condition()
        {
            bool chk = true;
            try
            {
                Convert.ToDouble(qntytxt.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Quantity");
                chk = false;
            }
            try
            {
                Convert.ToDouble(ratetxt.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Rate");
                chk = false;
            }            
            return chk;
        }
        
        private void savebtn_Click(object sender, EventArgs e)
        {
            Authenticate ss = new Authenticate();
            ss.ShowDialog();
            if (Authenticate.authenticate)
            {
                if (dgvitemdt.Rows.Count > 0)
                {
                    TranDB.Insert_Manual_Stock_T((Convert.ToDouble(Fall.LBI(Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Stock_T")) + 1).ToString(), DateTime.Today.ToString("dd-MM-yyyy"), Call.ret_id("Name", partyccmbx.Text, Constant.CompanyDB, CompanyDB.t_Company_T), "Owned", "Manual", "", Call.GTD(Constant.User_id), "", (Convert.ToDouble(Fall.LBI(Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Stock_T")) + 1).ToString(), "", "");

                    double t_pcs = 0;
                    int n = 0;

                    while (dgvitemdt.Rows.Count > n)
                    {
                        t_pcs += Convert.ToDouble(dgvitemdt.Rows[n].Cells[3].Value.ToString());
                        n++; ;
                    }

                    Ledger_Process.Ledger_Update(Call.GTD(Constant.Company_id), Call.ret_id(CompanyDB.c_Company_T.f_Name, partyccmbx.Text, Constant.CompanyDB, CompanyDB.t_Company_T), DateTime.Today.ToString("dd-MM-yyyy"), Constant.Credit, (Convert.ToDouble(Fall.LBI(Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Stock_T"))).ToString(), t_pcs.ToString() + " issued against this DocId", Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Stock_T", form_id.adexitstock_fid.ToString());
                    int i = 0;
                    while (dgvitemdt.Rows.Count > i)
                    {
                        Item itm = new Item();                       
                        itm.Item_no = dgvitemdt.Rows[i].Cells[0].Value.ToString();                      
                        itm.description = dgvitemdt.Rows[i].Cells[1].Value.ToString();
                        itm.hsn = dgvitemdt.Rows[i].Cells[2].Value.ToString();
                        itm.rate = Convert.ToDouble(dgvitemdt.Rows[i].Cells[4].Value.ToString());
                        itm.supplier_ID_fkey = Call.ret_id("Name", partyccmbx.Text, Constant.CompanyDB, CompanyDB.t_Company_T);
                        itm.author_ID_fkey = Call.GTD(Constant.User_id);
                        if (dgvitemdt.Rows[i].Cells[0].Value.ToString() == Constant.NEW)
                        {                            
                            dgvitemdt.Rows[i].Cells[0].Value = itm.Item_no = Call.add_new_item(itm);
                        }                       
                        else
                        {
                            Call.save_rate(itm, "Manual",Constant.Item);
                        }

                        TranDB.Insert_Manual_Stock_D_T((Convert.ToDouble(Fall.LBI(Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Stock_T"))).ToString(), (dgvitemdt.Rows[i].Cells[0].Value.ToString()), (dgvitemdt.Rows[i].Cells[4].Value.ToString()), "0", (dgvitemdt.Rows[i].Cells[3].Value.ToString()), "");


                        Ledgerdt dt = new Ledgerdt();
                        dt.item = itm.Item_no;
                        dt.F_party = comlbl.Text;
                        dt.S_party = Call.ret_id("Name", partyccmbx.Text, Constant.CompanyDB, CompanyDB.t_Company_T);
                        dt.folio = Fall.LBI(Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Stock_T");
                        dt.credit = true;
                        dt.debit = false;
                        dt.date = DateTime.Now;
                        dt.form_id = form_id.adexitstock_fid.ToString();
                        dt.table_id = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Stock_T";
                        Ledger_Process.Item_Update(dt);
                        

                        i++;
                    }

                    var CNT = Controls;
                    foreach (Control item in CNT)
                    {
                        if (!(item is TextBox) && !(item is DataGridView) && !(item is Label))
                        {
                            item.Enabled = false;
                        }
                    }
                    NoEdit();
                    newbtn.Show();
                    newbtn.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No Record Added");
                }
            }
        }        
        private void discardbtn_Click(object sender, EventArgs e)
        {
            Edit();
            Clear();
            dgvdelete();
            NoEdit();
            fillpartycombo();
        }
        private void newbtn_Click(object sender, EventArgs e)
        {
            Edit();
            Clear();
            dgvdelete();
            NoEdit();
            fillpartycombo();
            newbtn.Hide();
            savebtn.Enabled = true;
            discardbtn.Enabled = true;
        }
    }
}
