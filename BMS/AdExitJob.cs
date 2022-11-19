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
    public partial class AdExitJob : Form
    {
        public AdExitJob()
        {
            InitializeComponent();
            var CNT = Controls;
            comlbl.Text = Call.ret_Name(Call.GTD(Constant.Company_id),Constant.CompanyDB);
            foreach (Control item in CNT)
            {
                if (!(item is TextBox) && !(item is DataGridView) && !(item is Label))
                {
                    item.Enabled = false;
                    if (item is Button)
                    {
                        item.Hide();
                    }
                }
            }
            designtxt.Hide();
            savebtn.Show();
            savebtn.Enabled = true;
            discardbtn.Show();
            discardbtn.Enabled = true;
            addbtn.Show();
            delbtn.Show();
            NoEdit();

            fillpartycombo();
        }
        private void fillpartycombo()
        {
            string qurry = "Select Company_T.Name, Category_T.sub FROM Category_T INNER JOIN Company_T ON Category_T.Id = Company_T.category WHERE(Category_T.sub = 'Creditor')";
            List<string> itms = new List<string> { };
            itms = Fall.fill_ListDB(qurry, Constant.CompanyDB,"Select Party");
            partyccmbx.Enabled = true;
            partyccmbx.Items.Clear();
            int i = 0;
            while (itms.Count > i)
            {
                partyccmbx.Items.Add(itms[i]);
                i++;
            }
            partyccmbx.SelectedIndex = itms.Count - 1;

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
            qntytxt.ReadOnly = false;
            hsntxt.ReadOnly = false;
            descripttxt.ReadOnly = false;
        }
        private void dgvdelete()
        {
            int i = 0;
            while (dgvitemdt.Rows.Count>i)
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
                neworkchk.Enabled = true;
                neworkchk.Show();
                neworkchk.Checked = false;
               
                string qurry = "Select stockId from Item_T";
                List<string> itms = new List<string> { };
                itms = Fall.fill_ListDB(qurry, Constant.StockDB);
                itemcmb.Enabled = true;
                itemcmb.Items.Clear();
                int i = 0;
                while (itms.Count > i)
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
                string qurry = "Select stockId from Job_T where supplier_fkey='" + Call.ret_id("Name", partyccmbx.Text, Constant.CompanyDB,CompanyDB.t_Company_T) + "'";
                List<string> itms = new List<string> { };
                itms = Fall.fill_ListDB(qurry, Constant.StockDB);
                worknocmb.Enabled = true;
                int i = 0;
                if (itms.Count > i)
                {
                    worknocmb.Items.Clear();
                }
                while (itms.Count > i)
                {
                    worknocmb.Items.Add(itms[i]);
                    i++;
                }
                worknocmb.SelectedIndex = itms.Count - 1;
                neworkchk.Checked = false;
            }
            else
            {
                worknocmb.Enabled = false;                
            }
            
        }
        private void worknocmb_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (worknocmb.Text != "Select Variable" || neworkchk.Checked)
                {
                    if (!neworkchk.Checked)
                    {
                    Edit();
                    descripttxt.Text = Call.set_detail(worknocmb.Text, Constant.Job)[0];
                    hsntxt.Text = Call.set_detail(worknocmb.Text, Constant.Job)[1];
                    ratetxt.Text = Call.ret_work_rate(worknocmb.Text).ToString();
                    NoEdit();
                }
                    addbtn.Enabled = true;
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
        private void neworkchk_CheckedChanged(object sender, EventArgs e)
        {
            if (neworkchk.Checked)
            {               
                List<string> lst = new List<string> { };               
                string qurry = "Select name from Category_T";
                lst = Fall.fill_ListDB(qurry, Constant.StockDB);
                worknocmb.Enabled = true;
                worknocmb.Items.Clear();
                int i = 0;
                while (lst.Count > i)
                {
                    worknocmb.Items.Add(lst[i]);
                    i++;
                }
                worknocmb.SelectedIndex = worknocmb.Items.Count - 1;                
                descripttxt.ReadOnly = false;                
                hsntxt.ReadOnly = false;
                designtxt.Show();
                newcatchk.Show();
                newcatchk.Enabled = true;
                catlbl.Text = "Category";
            }
            else
            {             
                descripttxt.Clear();
                descripttxt.ReadOnly = true;
                hsntxt.Clear();
                hsntxt.ReadOnly = true;
                worknocmb.SelectedIndex = worknocmb.Items.Count - 1;
                worknocmb_SelectedIndexChanged(sender, e);
                designtxt.Hide();
                designtxt.Text = "Design No.";
                newcatchk.Checked = false;
                newcatchk.Hide();
                newcatchk.Enabled = false;
                catlbl.Text = "Work No.";
                itemcmb.SelectedIndex = itemcmb.Items.Count - 1;
                itemcmb_SelectedIndexChanged(sender, e);
            }
        }
        private void newcatchk_CheckedChanged(object sender, EventArgs e)
        {
            if (newcatchk.Checked)
            {
                worknocmb.Enabled = false;
                worknocmb.Hide();
                cattxt.Show();
            }
            else
            {
                worknocmb.Enabled = true;
                worknocmb.Show();
                cattxt.Hide();
            }
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            if (condition())
            {
                delbtn.Enabled = true;
                if (neworkchk.Checked)
                {
                    if (newcatchk.Checked)
                    {
                        dgvitemdt.Rows.Add(itemcmb.Text, Constant.NEW + cattxt.Text, descripttxt.Text, hsntxt.Text, qntytxt.Text, ratetxt.Text, designtxt.Text);
                        Call.add_new_category(cattxt.Text, " ",newcatchk.Checked.ToString(),Constant.StockDB);
                    }
                    else
                    {
                        dgvitemdt.Rows.Add(itemcmb.Text, Constant.NEW + worknocmb.Text, descripttxt.Text, hsntxt.Text, qntytxt.Text, ratetxt.Text, designtxt.Text);
                    }
                }
                else
                {
                    dgvitemdt.Rows.Add(itemcmb.Text, worknocmb.Text, descripttxt.Text, hsntxt.Text, qntytxt.Text, ratetxt.Text, designtxt.Text);
                }
                addbtn.Enabled = false;
                neworkchk.Checked = false;
                partyccmbx.Enabled = false;
            }
        }
        private void delbtn_Click(object sender, EventArgs e)
        {
            dgvitemdt.Rows.RemoveAt(dgvitemdt.SelectedRows[0].Index);
            if (dgvitemdt.Rows.Count < 1)
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
                    TranDB.Insert_Manual_Job_T("",(Convert.ToDouble(Fall.LBI(Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Job_T")) + 1).ToString(), DateTime.Today.ToString("dd-MM-yyyy"), Call.ret_id("Name", partyccmbx.Text, Constant.CompanyDB, CompanyDB.t_Company_T), "", "", "", Call.GTD(Constant.User_id), "", (Convert.ToDouble(Fall.LBI(Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Job_T")) + 1).ToString(), "","");
                   
                    TranDB.Insert_Manual_JobRecieving_T((Convert.ToDouble(Fall.LBI(Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Job_T"))).ToString(), (Convert.ToDouble(Fall.LBI(Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_JobRecieving_T")) + 1).ToString(), DateTime.Today.ToString("dd-MM-yyyy"), Call.ret_id("Name", partyccmbx.Text, Constant.CompanyDB, CompanyDB.t_Company_T), "", "", "", Call.GTD(Constant.User_id), "", (Convert.ToDouble(Fall.LBI(Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_JobRecieving_T")) + 1).ToString(), "", "");

                    Ledger_Process.Ledger_Update(Call.GTD(Constant.Company_id), Call.ret_id(CompanyDB.c_Company_T.f_Name, partyccmbx.Text, Constant.CompanyDB, CompanyDB.t_Company_T), DateTime.Today.ToString("dd-MM-yyyy"), Constant.Credit, (Convert.ToDouble(Fall.LBI(Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_JobRecieving_T"))).ToString(), " issued against this DocId", Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Job_T", form_id.adexitjob_fid.ToString());

                    int i = 0;
                    while (dgvitemdt.Rows.Count > i)
                    {
                        Item itm = new Item();                        
                        itm.Item_no = dgvitemdt.Rows[i].Cells[1].Value.ToString();
                        itm.stock_no = dgvitemdt.Rows[i].Cells[0].Value.ToString();                        
                        itm.description = dgvitemdt.Rows[i].Cells[2].Value.ToString();
                        itm.hsn = dgvitemdt.Rows[i].Cells[3].Value.ToString();
                        itm.rate = Convert.ToDouble(dgvitemdt.Rows[i].Cells[5].Value.ToString());
                        itm.supplier_ID_fkey = Call.ret_id("Name", partyccmbx.Text, Constant.CompanyDB,CompanyDB.t_Company_T);
                        itm.author_ID_fkey = Call.GTD(Constant.User_id);
                        if (itm.Item_no.Length > 2)
                        {
                            if (itm.Item_no.Substring(0, 3) == Constant.NEW)
                            {
                                dgvitemdt.Rows[i].Cells[1].Value = Call.add_new_work(itm);
                            }
                        }


                        TranDB.Insert_Manual_Job_D_T(dgvitemdt.Rows[i].Cells[4].Value.ToString(), "", (Convert.ToDouble(Fall.LBI(Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Job_T"))).ToString(), dgvitemdt.Rows[i].Cells[0].Value.ToString(), dgvitemdt.Rows[i].Cells[5].Value.ToString(), "",dgvitemdt.Rows[i].Cells[4].Value.ToString(), "");

                        TranDB.Insert_Manual_JobRecieving_D_T(dgvitemdt.Rows[i].Cells[1].Value.ToString(), (Convert.ToDouble(Fall.LBI(Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_JobRecieving_T"))).ToString(), dgvitemdt.Rows[i].Cells[0].Value.ToString(), dgvitemdt.Rows[i].Cells[5].Value.ToString(),"", dgvitemdt.Rows[i].Cells[4].Value.ToString(),"");

                        Ledger_Process.Item_Update(comlbl.Text, "Item_" + dgvitemdt.Rows[i].Cells[0].Value.ToString(), "Debit", (Convert.ToDouble(Fall.LBI(Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Job_T"))).ToString(), Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Job_T", form_id.adexitjob_fid.ToString());

                        itm.description = Call.ret_data(Constant.StockDB, "Item_T", "stockId", dgvitemdt.Rows[i].Cells[0].Value.ToString(),StockDB.c_Item_T.f_description) + " " + dgvitemdt.Rows[i].Cells[2].Value.ToString();
                        itm.hsn = dgvitemdt.Rows[i].Cells[3].Value.ToString();
                        itm.rate = Call.ret_item_rate(dgvitemdt.Rows[i].Cells[0].Value.ToString()) + Convert.ToDouble(dgvitemdt.Rows[i].Cells[5].Value.ToString());
                        dgvitemdt.Rows[i].Cells[0].Value += dgvitemdt.Rows[i].Cells[1].Value.ToString();
                        itm.Item_no = dgvitemdt.Rows[i].Cells[0].Value.ToString();

                        
                       
                        if (!Ledger_Process.IsLedger("Item_" + itm.Item_no))
                        {
                            Call.add_new_item(itm);
                        }
                        else
                        {
                            Call.save_rate(itm, "New", Constant.Item);
                        }
                        Ledger_Process.Item_Update(comlbl.Text, "Item_" + dgvitemdt.Rows[i].Cells[0].Value, "Credit", (Convert.ToDouble(Fall.LBI(Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_JobRecieving_T"))).ToString(), Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_JobRecieving_T", form_id.adexitjob_fid.ToString());
                        i++;
                    }

                    var CNT = Controls;
                    foreach (Control item in CNT)
                    {
                        if (!(item is TextBox) && !(item is DataGridView))
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
        private void qntytxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Call.ret_Balance(itemcmb.Text, Constant.Item) < Convert.ToDouble(qntytxt.Text))
                    {
                        qntytxt.Text = Call.ret_Balance(itemcmb.Text, Constant.Item).ToString();
                        MessageBox.Show("Available Stock is " + qntytxt.Text + " only");
                    }                
            }
            catch (Exception)
            {
                qntytxt.Text = "0";
            }
        }
    }
}
