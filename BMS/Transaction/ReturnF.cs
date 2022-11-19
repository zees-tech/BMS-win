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
    public partial class ReturnF : nform 
    {
        ReturnFdt lck = new ReturnFdt();
        public ReturnF(ReturnFdt ck)
        {
            lck = ck;
            InitializeComponent();
            CallCheck();
        }
        string qurry;
        int i;
        DataTable ds = new DataTable();        
        private int pos;

        void CallCheck()
        {
            foreach (Control item in Controls)
            {
                if (item is GroupBox)
                {
                    foreach (Control gitem in item.Controls)
                    {
                        if (!(gitem is Label) && !(gitem is TextBox) && !(gitem is DataGridView))
                        {
                            gitem.Enabled = false;
                            if (!(gitem is ComboBox) && !(gitem is DateTimePicker))
                            {
                                gitem.Hide();
                            }
                        }                        
                    }
                    
                }
                else if (!(item is Label) && !(item is TextBox) && !(item is DataGridView))
                {
                    item.Enabled = false;
                    if (!(item is ComboBox) && !(item is DateTimePicker))
                    {
                        item.Hide();
                    }
                }             
            }
            lblhead.Text = lck.lblHead;
            lblauthor.Text = Call.Ret_UserName();
            NoEdit();           
            if (lck.mode==Constant.NEW)
            {
                savebtn.Show();
                savebtn.Enabled = true;
                dsicardbtn.Show();
                dsicardbtn.Enabled = true;
                deletebtn.Show();
                addbtn.Show();
                loadbtn.Show();
                loadbtn.Enabled = true;
                billcombo.Enabled = true;
                postsalechk.Show();

                qurry = "Select * from [" + lck.Rtname1 + "]";     
                fillBillNocmb(qurry);
                fillTransportcmb(Fall.fill_ds("Select * from " + CompanyDB.t_Company_T + " where " + CompanyDB.c_Company_T.f_category + " = 'Transporter'", Constant.CompanyDB));            
            }
            else if (lck.mode==Constant.VIEW)
            {
                Nextbtn.Show();
                Nextbtn.Enabled = true;
                previousbtn.Show();
                previousbtn.Enabled = true;
                prntbtn.Show();
                prntbtn.Enabled = true;
                qurry = "select * from [" + lck.tname1 + "]";
                ds = Fall.fill_ds(qurry);
                NavRec(0);
            }
        }
        void NoEdit()
        {
            grtottxt.ReadOnly = true;
            tottxt.ReadOnly = true;
            pcstxt.ReadOnly = true;
            disctxt.ReadOnly = true;
            subttxt.ReadOnly = true;
            discrattxt.ReadOnly = true;
            numwrdtxt.ReadOnly = true;            
            igsttxt.ReadOnly = true;
            ttaxtxt.ReadOnly = true;
            cgsttxt.ReadOnly = true;
            sgsttxt.ReadOnly = true;
            Custxt.ReadOnly = true;
            postsaleamt.ReadOnly = true;
            noteidtxt.ReadOnly = true;
            reffIdtxt.ReadOnly = true;
            dgvinvolist.ReadOnly = true;
            dgvItemloaded.ReadOnly = true;
            dgvadditm.ReadOnly = true;
            txtpackaging.ReadOnly = true;
            txttransport_charge.ReadOnly = true;
            txtnumofitm.ReadOnly = true;
        }
        void Edit()
        {
            grtottxt.ReadOnly = false;
            tottxt.ReadOnly = false;
            pcstxt.ReadOnly = false;
            disctxt.ReadOnly = false;
            subttxt.ReadOnly = false;
            discrattxt.ReadOnly = false;
            numwrdtxt.ReadOnly = false;
            igsttxt.ReadOnly = false;
            ttaxtxt.ReadOnly = false;
            cgsttxt.ReadOnly = false;
            sgsttxt.ReadOnly = false;
            Custxt.ReadOnly = false;
            postsaleamt.ReadOnly = false;
            noteidtxt.ReadOnly = false;
            reffIdtxt.ReadOnly = false;
            dgvinvolist.ReadOnly = false;
            dgvItemloaded.ReadOnly = false;
            dgvadditm.ReadOnly = false;
            txtpackaging.ReadOnly = false;
            txttransport_charge.ReadOnly = false;
            txtnumofitm.ReadOnly = false;
        }
        void fillBillNocmb(string agr)
        {             
            ds = Fall.fill_ds(agr, Constant.TransDB);
            i = 0;
            billcombo.Items.Clear();
            while (i < ds.Rows.Count)
            {
                billcombo.Items.Add(ds.Rows[i]["billno"].ToString());
                i++;
            }
            billcombo.Items.Add("Select");
            billcombo.SelectedIndex = billcombo.Items.Count - 1;
        }
        void fillTransportcmb(DataTable dst)
        {
            transportcmb.Items.Clear();
            int i = 0;
            while (i < dst.Rows.Count)
            {
                transportcmb.Items.Add(dst.Rows[i][CompanyDB.c_Company_T.f_Name].ToString());
                i++;
            }
            transportcmb.Items.Clear();
            transportcmb.Items.Add("Hand Delivery");
            transportcmb.SelectedIndex = transportcmb.Items.Count - 1;
        }
        private void loadbtn_Click(object sender, EventArgs e)
        {         
            if(billcombo.SelectedIndex!=billcombo.Items.Count-1)
            {
                Edit();
                loadbtn.Enabled = false;
                postsalechk.Enabled = true;
                postsalechk.Checked = false;
                addbtn.Enabled = true;
                date_.Enabled = true;
                Custxt.Text = Call.ret_Name(ds.Rows[billcombo.SelectedIndex][TranDB.c_Bill_T.f_beneficiary_fkey].ToString(), Constant.CompanyDB);                
                billcombo.Enabled = false;
                
                qurry = "select * from [" +lck.Rtname2+"] where "+TranDB.c_Bill_D_T.f_bill_ID_fkey+" ='" + billcombo.Text + "'";
                ds = Fall.fill_ds(qurry);
                i = 0;
                
                while (i < ds.Rows.Count)
                {
                    double amts = Convert.ToDouble(ds.Rows[i][TranDB.c_Bill_D_T.f_qnty].ToString()) * Convert.ToDouble(ds.Rows[i][TranDB.c_Bill_D_T.f_rate].ToString());
                    dgvItemloaded.Rows.Add(false, ds.Rows[i][TranDB.c_Bill_D_T.f_item_no_fkey].ToString(), Call.set_detail(ds.Rows[i][TranDB.c_Bill_D_T.f_item_no_fkey].ToString(), Constant.Item)[0], Call.set_detail(ds.Rows[i][TranDB.c_Bill_D_T.f_item_no_fkey].ToString(), Constant.Item)[1], (Convert.ToDouble(ds.Rows[i][TranDB.c_Bill_D_T.f_qnty].ToString()) - Convert.ToDouble(ds.Rows[i][TranDB.c_Bill_D_T.f_grqnty].ToString())).ToString(), ds.Rows[i][TranDB.c_Bill_D_T.f_rate].ToString(), amts.ToString());                    
                    discrattxt.Text = ds.Rows[i][TranDB.c_Bill_D_T.f_discount_rate].ToString();                    
                    i++;
                }
                NoEdit();
                txttransport_charge.ReadOnly = false;
                txtpackaging.ReadOnly = false;
                transportcmb.Enabled = true;
                reffIdtxt.ReadOnly = false;
                dgvItemloaded.ReadOnly = false;
                dgvItemloaded.Columns[2].ReadOnly = true;
                dgvItemloaded.Columns[3].ReadOnly = true;
                dgvItemloaded.Columns[4].ReadOnly = true;
                dgvItemloaded.Columns[5].ReadOnly = true;
                dgvItemloaded.Columns[6].ReadOnly = true;
            }
        }
        private void postsalechk_CheckedChanged(object sender, EventArgs e)
        {
            if (postsalechk.Checked == true)
            {
                postsaleamt.ReadOnly = false;
            }
            else if (postsalechk.Checked != true)
            {
                postsaleamt.Text = "0";
                postsaleamt.ReadOnly = true;
            }
        }        
        private void addbtn_Click(object sender, EventArgs e)
        {
            if (dgvItemloaded.Rows.Count > 0)
            {
                int it = 0;bool chk = true;
                while (it<dgvItemloaded.Rows.Count)
                {
                    if (!check_stock(it))
                    {
                        chk = false;
                        break;
                    }
                    it++;
                }
                if (chk)
                {
                    addbtn.Enabled = false;
                    postsalechk.Checked = false;
                    postsalechk.Enabled = false;
                    int n = 0;
                    while (n < dgvItemloaded.Rows.Count)
                    {
                        dgvadditm.ReadOnly = false;

                        if (Convert.ToBoolean(dgvItemloaded.Rows[n].Cells[0].Value.ToString()))
                        {
                            deletebtn.Enabled = true;

                            if (dgvadditm.Rows.Count == 0)
                            {
                                dgvadditm.Rows.Add(billcombo.Text, dgvItemloaded.Rows[n].Cells[1].Value, dgvItemloaded.Rows[n].Cells[2].Value, dgvItemloaded.Rows[n].Cells[3].Value, dgvItemloaded.Rows[n].Cells[4].Value, dgvItemloaded.Rows[n].Cells[5].Value, dgvItemloaded.Rows[n].Cells[6].Value);
                                cal(dgvadditm.Rows.Count - 1, 1);
                                goto NR;
                            }
                            else
                            {
                                int i = 0;
                                while (dgvadditm.Rows.Count > i)
                                {
                                    if (dgvItemloaded.Rows[n].Cells[1].Value.ToString() == dgvadditm.Rows[i].Cells[1].Value.ToString() && billcombo.Text == dgvadditm.Rows[i].Cells[0].Value.ToString())
                                    {
                                        cal(i, -1);
                                        dgvadditm.Rows[i].Cells[4].Value = (Convert.ToDouble(dgvadditm.Rows[i].Cells[4].Value.ToString()) + Convert.ToDouble(dgvItemloaded.Rows[n].Cells[4].Value.ToString())).ToString();
                                        dgvadditm.Rows[i].Cells[6].Value = (Convert.ToDouble(dgvadditm.Rows[i].Cells[4].Value.ToString()) * Convert.ToDouble(dgvadditm.Rows[i].Cells[5].Value.ToString()));
                                        cal(i, 1);
                                        goto NR;
                                    }
                                    i++;
                                }
                            }
                            dgvadditm.Rows.Add(billcombo.Text, dgvItemloaded.Rows[n].Cells[1].Value, dgvItemloaded.Rows[n].Cells[2].Value, dgvItemloaded.Rows[n].Cells[3].Value, dgvItemloaded.Rows[n].Cells[4].Value, dgvItemloaded.Rows[n].Cells[5].Value, dgvItemloaded.Rows[n].Cells[6].Value);
                            cal(dgvadditm.Rows.Count - 1, 1);
                        }
                    NR:
                        n++;
                        dgvadditm.ReadOnly = true;
                    }
                    if (postsalechk.Checked == true)
                    {
                        dgvadditm.Rows.Add(billcombo.Text, "POS", "Discount Taken Post Sale", "null", "null", "null", postsaleamt.Text);
                        n = dgvadditm.Rows.Count - 1;
                        cal(n, 1);
                    }
                    dgvinvolist_update(billcombo.Text);
                    cleardgvloaded();
                    billcombo.Enabled = true;
                    fillBillNocmb("Select * from [" + lck.Rtname1 + "] where " + TranDB.c_Bill_T.f_beneficiary_fkey + "='" + Call.ret_id("Name", Custxt.Text, Constant.CompanyDB, "Company_T") + "'");
                    loadbtn.Enabled = true;
                    if (dgvadditm.Rows.Count > 0)
                    {
                        deletebtn.Enabled = true;
                    }
                }
            }
        }
        private void deletebtn_Click(object sender, EventArgs e)
        {
            string val = dgvadditm.Rows[dgvadditm.SelectedRows[0].Index].Cells[0].Value.ToString();
            cal(dgvadditm.SelectedRows[0].Index, -1);
            try
            {
                dgvadditm.Rows.RemoveAt(dgvadditm.SelectedRows[0].Index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            dgvinvolist_update(val, -1);
            if (dgvadditm.Rows.Count < 1)
            {
                deletebtn.Enabled = false;
            }
        }
        private void cleardgvloaded()
        {           
            while (dgvItemloaded.Rows.Count > 0)
            {
                dgvItemloaded.Rows.RemoveAt(0);
            }
            discrattxt.Text = "0";            
            postsaleamt.Text = "0";
            postsalechk.Checked = false;
            postsalechk.Enabled = false;
            reffIdtxt.Text = "";
        }
        private void dgvinvolist_update(string id_val = "null", int id = 1)
        {
            i = 0;
            while (dgvinvolist.Rows.Count > i)
            {
                if (Convert.ToInt32(id_val) == Convert.ToInt32(dgvinvolist.Rows[i].Cells[0].Value))
                {
                    id = -1;
                }
                i++;
            }
            if (id == 1)
            {
                qurry = "Select * from [" + lck.Rtname1 + "] where Id='" + id_val + "'";
                ds = Fall.fill_ds(qurry);
                dgvinvolist.ReadOnly = false;
                if (ds.Rows.Count>0)
                {
                    dgvinvolist.Rows.Add(id_val, Call.format_date(Convert.ToDateTime(ds.Rows[0][TranDB.c_Bill_T.f_date_])),discrattxt.Text , reffIdtxt.Text);
                }
                dgvinvolist.ReadOnly = true;
            }
            if (id_val != "null")
            {
                i = 0;
                id = 0;
                while (dgvadditm.Rows.Count > i)
                {
                    if (id_val == dgvadditm.Rows[i].Cells[0].Value.ToString())
                    {
                        id = -1;
                    }
                    i++;
                }
                i = 0;
                if (id == 0)
                {
                    while (dgvinvolist.Rows.Count > i)
                    {
                        if (id_val == dgvinvolist.Rows[i].Cells[0].Value.ToString())
                        {
                            dgvinvolist.Rows.RemoveAt(i);
                        }
                        i++;
                    }
                }
            }

        }
        private void dgvItemloaded_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //if (dgvItemloaded.RowCount > 0)
            //{
            //    if (Ledger_Process.Ledger_Balance("Item_" + dgvItemloaded.Rows[e.RowIndex].Cells[1].Value.ToString()) < Convert.ToDouble(dgvItemloaded.Rows[e.RowIndex].Cells[4].Value.ToString()))
            //    {
            //        dgvItemloaded.Rows[e.RowIndex].Cells[4].Value = Ledger_Process.Ledger_Balance("Item_" + dgvItemloaded.Rows[e.RowIndex].Cells[1].Value.ToString());
            //    }

            //    dgvItemloaded.Rows[e.RowIndex].Cells[6].Value = Convert.ToDouble(dgvItemloaded.Rows[e.RowIndex].Cells[4].Value) * Convert.ToDouble(dgvItemloaded.Rows[e.RowIndex].Cells[5].Value);
            //}
        }
        private bool check_condition()
        {
            bool chk = true;
            try
            {
                if (dgvadditm.Rows.Count < 1 && postsalechk.Checked == true)
                {
                    if (Convert.ToDouble(postsaleamt.Text) > 0)
                    {
                        chk = false;
                        MessageBox.Show("Add Credit details detail");
                    }
                }
            }
            catch (Exception)
            {
                chk = false;
                MessageBox.Show("Add Credit details detail");
            }
            if (Convert.ToDouble(grtottxt.Text) <= 0)
            {
                chk = false;
                MessageBox.Show("Item Detail is not given");
            }
            return chk;
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            if (check_condition())
            {
                this.i = 0;
                string reff = "";
                while (dgvinvolist.RowCount > this.i)
                {
                    reff += dgvinvolist.Rows[this.i].Cells[3].Value.ToString() + ",";
                    this.i++;
                }
                string tnx = "";
                if (lck.Sell)
                {
                    tnx = Constant.Debit;
                }
                else
                {
                    tnx = Constant.Credit;
                }
                noteidtxt.Text = (Convert.ToDouble(Fall.LBI(lck.tname1,"noteno")) + 1).ToString();
                lck.InsertBT.Invoke(noteidtxt.Text, date_.Text, Call.ret_id("Name", Custxt.Text, Constant.CompanyDB, "Company_T"), reffIdtxt.Text, Call.GTD(Constant.User_id), transportcmb.Text, "", txttransport_charge.Text, txtpackaging.Text);              
                
                Ledger_Process.Ledger_Update(Call.GTD(Constant.Company_id), Call.ret_id("Name", Custxt.Text, Constant.CompanyDB, "Company_T"), date_.Text, tnx, noteidtxt.Text,  "Sarees " + pcstxt.Text + " return @ discount " + discrattxt.Text + "%",lck.tname1,form_id.returnf_fid.ToString());
                Call.InsertTaxdb(lck.tname1, Call.IsRevrsChrge(lck.Sell, Call.ret_Gst(Call.ret_id(CompanyDB.c_Company_T.f_Name, Custxt.Text, Constant.CompanyDB, CompanyDB.t_Company_T), Constant.CompanyDB) != ""), lck.Sell, lck.callas != Constant.challan, Call.GTD(Constant.Company_id), Call.ret_id(CompanyDB.c_Company_T.f_Name, Custxt.Text, Constant.CompanyDB, CompanyDB.t_Company_T), date_.Text, noteidtxt.Text, subttxt.Text);
                string itmtnx = null;
                if (tnx == Constant.Credit)
                {
                    itmtnx = Constant.Debit;
                }
                else
                {
                    itmtnx = Constant.Credit;
                }
                i = 0;
                while (i < dgvadditm.Rows.Count)
                {                   
                    lck.InsertBDT.Invoke("1", dgvadditm.Rows[i].Cells[0].Value.ToString(), dgvadditm.Rows[i].Cells[1].Value.ToString(), dgvadditm.Rows[i].Cells[5].Value.ToString(), discrattxt.Text, dgvadditm.Rows[i].Cells[4].Value.ToString(), "", "");
                    Ledger_Process.Item_Update(Call.GTD(Constant.Company_id), "Item_" + dgvadditm.Rows[i].Cells[1].Value.ToString(), itmtnx, noteidtxt.Text, lck.tname1,form_id.returnf_fid.ToString());
                    i++;
                }
                NoEdit();
                billcombo.Enabled = false;
                date_.Enabled = false;
                loadbtn.Enabled = false;
                postsalechk.Enabled = false;
                savebtn.Enabled = false;
                dsicardbtn.Enabled = false;
                newbtn.Visible = true;
                newbtn.Enabled = true;
                prntbtn.Visible = true;
                prntbtn.Enabled = true;
            }
        }
        private void dgvDelete()
        {
            while (dgvadditm.SelectedRows.Count > 0)
            {
                try
                {
                    cal(0, -1);
                    dgvadditm.ReadOnly = false;
                    dgvadditm.Rows.RemoveAt(0);
                    dgvadditm.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            while (dgvinvolist.Rows.Count > 0)
            {
                dgvinvolist.ReadOnly = false;
                dgvinvolist.Rows.RemoveAt(0);
                dgvinvolist.ReadOnly = true;
            }  
        }
        private void dsicardbtn_Click(object sender, EventArgs e)
        {
            Edit();
            dgvDelete();
            cleardgvloaded();
            Custxt.Enabled = true;
            Custxt.Text = "";
            Custxt.Enabled = false;
            postsalechk.Checked = false;
            postsalechk.Enabled = false;
            reffIdtxt.Text = "";
            NoEdit();
            fillBillNocmb("Select * from [" + lck.Rtname1 + "]");
            loadbtn.Enabled = true;
            billcombo.Enabled = true;
            postsalechk.Checked = false;
            postsalechk.Enabled = false;            
            addbtn.Enabled = false;
            deletebtn.Enabled = false;
        }
        private void newbtn_Click(object sender, EventArgs e)
        {
            Edit();
            noteidtxt.Text = Constant.Hash;
            dgvDelete();            
            Custxt.Text = "";            
            billcombo.Enabled = true;
            fillBillNocmb("Select * from [" + lck.Rtname1 + "]");
            loadbtn.Enabled = true;
            postsalechk.Enabled = true;
            NoEdit();
            savebtn.Enabled = true;
            dsicardbtn.Enabled = true;
            newbtn.Hide();
            prntbtn.Hide();
        }
        private void Nextbtn_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos > ds.Rows.Count-1)
            {
                pos--;
            }
            NavRec(pos);
        }
        private void previousbtn_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos < 0)
            {
                pos++;
            }
            NavRec(pos);
        }
        private void NavRec(int n)
        {
            if (ds.Rows.Count > 0)
            {
                Edit();
                noteidtxt.Text = ds.Rows[n][TranDB.c_Resturn_Note_T.f_noteno].ToString();
                date_.Text = ds.Rows[n][TranDB.c_Resturn_Note_T.f_date_].ToString();                                
                Custxt.Text = Call.ret_Name(ds.Rows[n][TranDB.c_Resturn_Note_T.f_beneficiary_fkey].ToString(), Constant.CompanyDB);
                double amts;
                List<string> reffs = Call.Break_String(ds.Rows[pos][5].ToString());
                dgvDelete();
                DataTable dst = new DataTable();
                qurry = "select * from ["+ lck.tname2 + "] where "+TranDB.c_Resturn_Note_D_T.f_noteno_fkey+" ='" + noteidtxt.Text + "'";
                dst = Fall.fill_ds(qurry);
                int it = 0;
                while (it < dst.Rows.Count)
                {
                    amts = Convert.ToDouble(dst.Rows[it][TranDB.c_Resturn_Note_D_T.f_qnty].ToString()) * Convert.ToDouble(dst.Rows[it][TranDB.c_Resturn_Note_D_T.f_rate].ToString());


                    dgvadditm.Rows.Add(dst.Rows[it][TranDB.c_Resturn_Note_D_T.f_bill_ID_fkey].ToString(), dst.Rows[it][TranDB.c_Resturn_Note_D_T.f_item_no_fkey].ToString(), "0", "0", dst.Rows[it][TranDB.c_Resturn_Note_D_T.f_qnty].ToString(), dst.Rows[it][TranDB.c_Resturn_Note_D_T.f_rate].ToString(), amts.ToString());
                    cal(dgvadditm.Rows.Count - 1, 1);
                    dgvinvolist_update(dst.Rows[it][TranDB.c_Bill_D_T.f_bill_ID_fkey].ToString());
                    it++;
                }
                it = 0;
                while (it < dgvinvolist.RowCount)
                {
                    dgvinvolist.Rows[it].Cells[3].Value = reffs[it];
                    it++;
                }
                NoEdit();
            }
        }
        private void subcal()
        {          
            disctxt.Text = Convert.ToString(Math.Round(Convert.ToDouble(subttxt.Text) * (Convert.ToDouble(discrattxt.Text) / 100), 2));
            tottxt.Text = Convert.ToString(Math.Round(Convert.ToDouble(subttxt.Text) - Convert.ToDouble(disctxt.Text), 2));

            Cal_dt cdt = new Cal_dt();
            cdt.amt = tottxt.Text;
            GST gst = new GST();
            cdt.f_id = Call.GTD(Constant.Company_id);
            cdt.f_db = Constant.CompanyDB;
            cdt.s_id = Call.ret_id(CompanyDB.c_Company_T.f_Name, Custxt.Text, Constant.CompanyDB, CompanyDB.t_Company_T);
            cdt.s_db = Constant.CompanyDB;
            gst = Fall.ret_GST(cdt);
            cgsttxt.Text = gst.cgst;
            sgsttxt.Text = gst.sgst;
            igsttxt.Text = gst.igst;
            ttaxtxt.Text = gst.ttax;
            grtottxt.Text = Convert.ToString(Math.Round(Convert.ToDouble(tottxt.Text) + Convert.ToDouble(txttransport_charge.Text) + Convert.ToDouble(txtpackaging.Text)));
                           
                grtottxt.Text = Convert.ToString(Math.Round(Convert.ToDouble(tottxt.Text) + Convert.ToDouble(ttaxtxt.Text) + Convert.ToDouble(txtpackaging.Text) + Convert.ToDouble(txttransport_charge.Text)));
            
            numwrdtxt.Text = NumToWord.ConvertNumbertoWords((Convert.ToDouble(grtottxt.Text)));
        }
        private void cal(int n, int sign)
        {
            if (dgvadditm.Rows[n].Cells[4].Value.ToString() != "null")
            {
                pcstxt.Text = Convert.ToString(Convert.ToDouble(pcstxt.Text) + Convert.ToDouble(dgvadditm.Rows[n].Cells[4].Value) * sign);
            }
            subttxt.Text = Convert.ToString(Convert.ToDouble(subttxt.Text) + Convert.ToDouble(dgvadditm.Rows[n].Cells[6].Value) * sign);
            subcal();
        }
        private void prntbtn_Click(object sender, EventArgs e)
        {
            PrntCom fm = new PrntCom();
            fm.datetxt = date_;
            fm.invoidtxt = noteidtxt;
            fm.grtottxt = grtottxt;
            fm.igsttxt = igsttxt;
            fm.itemdtdgv = dgvadditm;
            fm.numwrdtxt = numwrdtxt;
            fm.packagingtxt = txtpackaging;
            fm.packlbl.Text = "";
            fm.pcstxt = pcstxt;
            fm.cgsttxt = cgsttxt;
            fm.sgsttxt = sgsttxt;
            fm.subttxt = subttxt;
            fm.discrattxt = discrattxt;
            fm.disctxt = disctxt;
            fm.tottxt = tottxt;
            fm.transport_chargetxt = txttransport_charge;
            //fm.ewaybilltxt = txtewaybill;
            PrntDocType pdt = new PrntDocType();
            pdt.doc_db = Constant.TransDB;
            pdt.doc_tname = lck.tname1;
            pdt.doc_type = lck.callas;
            pdt.head_label = lblhead.Text;
            Fall.PrintBill(fm, pdt);
        }
        private void dgvItemloaded_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItemloaded.Rows.Count > 0)
            {
                if (e.ColumnIndex == 0)
                {
                    if (Convert.ToBoolean(dgvItemloaded.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    {
                        dgvItemloaded.Rows[e.RowIndex].Cells[4].ReadOnly = false;
                    }
                    else
                    {
                        dgvItemloaded.Rows[e.RowIndex].Cells[4].Value = (Convert.ToDouble(ds.Rows[e.RowIndex][TranDB.c_Bill_D_T.f_qnty].ToString()) - Convert.ToDouble(ds.Rows[e.RowIndex][TranDB.c_Bill_D_T.f_grqnty].ToString())).ToString();
                        dgvItemloaded.Rows[e.RowIndex].Cells[4].ReadOnly = true;
                    }
                }
                if (e.ColumnIndex == 4)
                {
                    check_stock(e.RowIndex);
                }
            }
        }
        private bool check_stock(int ind)
        {
            bool chk = true;
            try
            {
                if (!lck.Sell)
                {
                    i = 0; double adstk = 0;
                    while (dgvadditm.Rows.Count > i)
                    {
                        if (dgvItemloaded.Rows[ind].Cells[1].Value.ToString() == dgvadditm.Rows[i].Cells[1].Value.ToString() & billcombo.Text == dgvadditm.Rows[ind].Cells[0].Value.ToString())
                        {
                            adstk = Convert.ToDouble(dgvadditm.Rows[i].Cells[4].Value.ToString());
                        }
                        i++;
                    }
                    if (Ledger_Process.Ledger_Balance("Item_" + dgvItemloaded.Rows[ind].Cells[1].Value.ToString()) < Convert.ToDouble(dgvItemloaded.Rows[ind].Cells[4].Value.ToString()) + adstk)
                    {
                        chk = false;
                        MessageBox.Show("Your Stock is " + Ledger_Process.Ledger_Balance("Item_" + dgvItemloaded.Rows[ind].Cells[1].Value.ToString()) + " only!");
                        dgvItemloaded.Rows[ind].Cells[4].Value = Ledger_Process.Ledger_Balance("Item_" + dgvItemloaded.Rows[ind].Cells[1].Value.ToString()) - adstk;
                    }
                    else if (Convert.ToDouble(dgvItemloaded.Rows[ind].Cells[4].Value.ToString()) + adstk > (Convert.ToDouble(ds.Rows[ind][TranDB.c_Bill_D_T.f_qnty].ToString()) - Convert.ToDouble(ds.Rows[ind][TranDB.c_Bill_D_T.f_grqnty].ToString())))
                    {
                        chk = false;
                        MessageBox.Show(Call.ret_Balance(dgvItemloaded.Rows[ind].Cells[1].Value.ToString(), Constant.Item) + " unit was ISSUED with  Doc ID:" + billcombo.SelectedValue.ToString());
                        dgvItemloaded.Rows[ind].Cells[4].Value = (Convert.ToDouble(ds.Rows[ind][TranDB.c_Bill_D_T.f_qnty].ToString()) - Convert.ToDouble(ds.Rows[ind][TranDB.c_Bill_D_T.f_grqnty].ToString()) - adstk).ToString();
                    }
                }
                else
                {
                    i = 0; double adstk = 0;
                    while (dgvadditm.Rows.Count > i)
                    {
                        if (dgvItemloaded.Rows[ind].Cells[1].Value.ToString() == dgvadditm.Rows[i].Cells[1].Value.ToString() && billcombo.Text == dgvItemloaded.Rows[ind].Cells[0].Value.ToString())
                        {
                            adstk = Convert.ToDouble(dgvadditm.Rows[i].Cells[4].Value.ToString());
                        }
                        i++;
                    }
                    if (Convert.ToDouble(dgvItemloaded.Rows[ind].Cells[4].Value.ToString()) + adstk > (Convert.ToDouble(ds.Rows[ind][TranDB.c_Bill_D_T.f_qnty].ToString()) - Convert.ToDouble(ds.Rows[ind][TranDB.c_Bill_D_T.f_grqnty].ToString())))
                    {
                        chk = false;
                        MessageBox.Show(Convert.ToDouble(ds.Rows[ind][TranDB.c_Bill_D_T.f_qnty].ToString()) + " unit was ISSUED with Doc ID:" + billcombo.Text);
                        dgvItemloaded.Rows[ind].Cells[4].Value = (Convert.ToDouble(ds.Rows[ind][TranDB.c_Bill_D_T.f_qnty].ToString()) - Convert.ToDouble(ds.Rows[ind][TranDB.c_Bill_D_T.f_grqnty].ToString()) - adstk).ToString();
                    }
                }
                dgvItemloaded.Rows[ind].Cells[6].Value = Convert.ToDouble(dgvItemloaded.Rows[ind].Cells[4].Value) * Convert.ToDouble(dgvItemloaded.Rows[ind].Cells[5].Value);
            }
            catch (Exception)
            {
                chk = false;
                dgvItemloaded.Rows[ind].Cells[4].Value = ds.Rows[ind][TranDB.c_Bill_D_T.f_qnty].ToString();
                MessageBox.Show("Invalid Entry");
            }
            return chk;
        }

        private void txtpackaging_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(txtpackaging.Text);
            }
            catch (Exception)
            {
                txtpackaging.Text = "0";
            }
            subcal();
        }

        private void txttransport_charge_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(txttransport_charge.Text);
            }
            catch (Exception)
            {
                txttransport_charge.Text = "0";
            }
            subcal();
        }
    }

    public class ReturnFdt : CompanyFdt
    {
        public string tname1;
        public string tname2;
        public string Rtname1;
        public string Rtname2;
        public TranDB.insert_Resturn_Note_T InsertBT;
        public TranDB.insert_Resturn_Note_D_T InsertBDT;
    }
}
