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
    public partial class JobBillF : nform
    {
        JBillFdt lck = new JBillFdt();
        public JobBillF(JBillFdt ck)
        {
            lck = ck;
            InitializeComponent();
            CallCheck();
        }
        string qurry;
        int i,pos = 0;
        private DataTable ds = new DataTable();
        private string amt;

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
            NoEdit();
            emplbl.Text = Call.Ret_UserName();
            if (lck.mode == Constant.NEW)
            {
                suppliercmbx.Enabled = true;
                qurry = "Select * from " + CompanyDB.t_Company_T + " INNER JOIN "+CompanyDB.t_Category_T+" ON " + CompanyDB.t_Company_T+"."+ CompanyDB.c_Company_T.f_category + "="+ CompanyDB.t_Category_T + ".Id where "+ CompanyDB.t_Category_T + "."+ CompanyDB.c_Category_T.f_sub +"='"+lck.callby+"'";
                if (Fall.fill_ds(qurry,Constant.CompanyDB).Rows.Count<1)                
                 {
                    if (DialogResult.Yes == MessageBox.Show("No beneficiary record exist.\nDo you want to add?", "Add Record?", MessageBoxButtons.YesNo))
                    {
                        CompanyFdt ss = new CompanyFdt();
                        ss = Constant.AddParty();
                        ss.callby = lck.callby;
                        Company sss = new Company(ss);
                        sss.ShowDialog();
                        CallCheck();
                        st = true;
                    }
                    else
                    {
                        st = false;
                        this.Close();
                    }                    
                }
                fillservicercombo(qurry);
                new_itemchbx.Show();                
                addbtn.Show();
                delbtn.Show();
                savebtn.Show();
                savebtn.Enabled = true;
                discardbtn.Show();
                discardbtn.Enabled = true;
                date_.Enabled = true;
                if (!this.lck.Sell)
                {
                    new_itemchbx.Show();
                }
            }
            else if (lck.mode == Constant.VIEW)
            {
                previousbtn.Show();
                previousbtn.Enabled = true;
                Nextbtn.Show();
                Nextbtn.Enabled = true;
                prntbtn.Show();
                prntbtn.Enabled = true;
                ds = Fall.fill_ds("Select * from " + lck.tname1);
                Nav(0);
            }
            else if (lck.mode == Constant.EDIT)
            {

            }
        }
        void NoEdit()
        {
            txtpaymentterm.ReadOnly = true;
            numofitmtxt.ReadOnly = true;
            txtigst.ReadOnly = true;
            txtttax.ReadOnly = true;
            txtcgst.ReadOnly = true;
            txtsgst.ReadOnly = true;
            ratetxt.ReadOnly = true;
            qntytxt.ReadOnly = true;
            hsntxt.ReadOnly = true;
            descrptxt.ReadOnly = true;            
            cattxt.ReadOnly = true;
            billidtxt.ReadOnly = true;
            stockvaluetxt.ReadOnly = true;
            numofitmtxt.ReadOnly = true;
            pcstxt.ReadOnly = true;
            numwrdtxt.ReadOnly = true;
            tottxt.ReadOnly = true;
            disctxt.ReadOnly = true;
            subttxt.ReadOnly = true;
            grtottxt.ReadOnly = true;
            discrattxt.ReadOnly = true;
            txtpackaging.ReadOnly = true;
            txttransport_charge.ReadOnly = true;
            itemdtdgv.ReadOnly = true;
        }
        void Edit()
        {
            txtpaymentterm.ReadOnly = false;
            numofitmtxt.ReadOnly = false;
            txtigst.ReadOnly = false;
            txtttax.ReadOnly = false;
            txtcgst.ReadOnly = false;
            txtsgst.ReadOnly = false;
            ratetxt.ReadOnly = false;
            qntytxt.ReadOnly = false;
            hsntxt.ReadOnly = false;
            descrptxt.ReadOnly = false;
            cattxt.ReadOnly = false;
            billidtxt.ReadOnly = false;
            stockvaluetxt.ReadOnly = false;
            numofitmtxt.ReadOnly = false;
            pcstxt.ReadOnly = false;
            numwrdtxt.ReadOnly = false;
            tottxt.ReadOnly = false;
            disctxt.ReadOnly = false;
            subttxt.ReadOnly = false;
            grtottxt.ReadOnly = false;
            discrattxt.ReadOnly = false;
            txtpackaging.ReadOnly = false;
            txttransport_charge.ReadOnly = false;
            itemdtdgv.ReadOnly = false;
        }
        private void fillservicercombo(string qurry)
        {
            ds = Fall.fill_ds(qurry, Constant.CompanyDB);
            suppliercmbx.Items.Clear();
           i = 0;
            while (i < ds.Rows.Count)
            {
                suppliercmbx.Items.Add(ds.Rows[i][CompanyDB.c_Company_T.f_Name].ToString());
                i++;
            }
            suppliercmbx.Items.Add("Select");
            suppliercmbx.SelectedIndex = suppliercmbx.Items.Count - 1;
        }
        private void fillTransportcmb()
        {
            cmbtransport.Items.Clear();
            qurry = "Select * from " + CompanyDB.t_Company_T + " where " + CompanyDB.c_Company_T.f_category + "='Transporter'";
            ds = Fall.fill_ds(qurry, Constant.CompanyDB);
            int i = 0;
            while (i < ds.Rows.Count)
            {
                cmbtransport.Items.Add(ds.Rows[i][CompanyDB.c_Company_T.f_Name].ToString());
                i++;
            }
            cmbtransport.Items.Add("Hand Delivery");
            cmbtransport.Items.Add("Select");
            cmbtransport.SelectedIndex = cmbtransport.Items.Count - 1;
        }
        private void suppliercmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppliercmbx.SelectedIndex != suppliercmbx.Items.Count - 1)
            {
                itemcmbx.Enabled = true;
                cmbtransport.Enabled = true;              
                string tname = StockDB.t_Item_T;
                qurry = "Select * from [" + tname + "]";
                fillitemcmb(qurry);
                fillTransportcmb();
            }
            else
            {
                itemcmbx.SelectedIndex = itemcmbx.Items.Count - 1;
                itemcmbx.Enabled = false;
                cmbtransport.Enabled = false;
            }
        }        
        private void fillitemcmb(string qurry)
        {
            itemcmbx.Items.Clear();
            ds = Fall.fill_ds(qurry, Constant.StockDB);
            i = 0;
            while (i < ds.Rows.Count)
            {
                itemcmbx.Items.Add(ds.Rows[i][StockDB.c_Item_T.f_stockId].ToString());
                i++;
            }
            itemcmbx.Items.Add("Select");
            itemcmbx.SelectedIndex = itemcmbx.Items.Count - 1;
        }
        private void itemcmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemcmbx.SelectedIndex != itemcmbx.Items.Count - 1)
            {
                servicecmb.Enabled = true;
                new_itemchbx.Enabled = true;
                new_itemchbx.Checked = false;
                string tname = StockDB.t_Job_T;
                if (lck.Sell)
                {
                    qurry = "Select * from [" + tname + "]";
                }
                else
                {
                    qurry = "Select * from [" + tname + "]";// where "+ StockDB.c_Job_T.f_supplier_fkey + "='" + Call.ret_id(CompanyDB.c_Company_T.f_Name, suppliercmbx.Text, Constant.CompanyDB, CompanyDB.t_Company_T) + "'";
                }
                
                filljobcmb(qurry);
                txttransport_charge.ReadOnly = false;
                txtpackaging.ReadOnly = false;
            }
            else
            {
                servicecmb.SelectedIndex = servicecmb.Items.Count - 1;
                servicecmb.Enabled = false;
                new_itemchbx.Checked = false;
                new_itemchbx.Enabled = false;
                txttransport_charge.ReadOnly = true;
                txtpackaging.ReadOnly = true;
            }
        }
        private void servicecmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (servicecmb.SelectedIndex != servicecmb.Items.Count - 1)
            {
                Edit();

                descrptxt.Text = Call.set_detail(servicecmb.Text, Constant.Job)[0];
                hsntxt.Text = Call.set_detail(servicecmb.Text, Constant.Job)[1];
                ratetxt.Text = Call.ret_rate(servicecmb.Text, Constant.StockDB, Constant.Job);
                qntytxt.Clear();
                if (lck.Sell)
                {
                    ratetxt.Text = Call.price_calculator(Convert.ToDouble(ratetxt.Text)).ToString();
                }
                lblprerate.Text = "Last time rate: " + Call.ret_lreate(servicecmb.Text, Call.ret_id(CompanyDB.c_Company_T.f_Name, suppliercmbx.Text, Constant.CompanyDB, CompanyDB.t_Company_T), lck.tname1, lck.tname2, lck.Type);
                if (lblprerate.Text == "Last time rate: ")
                {
                    lblprerate.Text = "";
                }

                NoEdit();
                qntytxt.ReadOnly = false;
                ratetxt.ReadOnly = false;
                addbtn.Enabled = true;
            }
            else
            {
                Edit();
                descrptxt.Clear();
                hsntxt.Clear();
                ratetxt.Text = "0";
                qntytxt.Clear();
                addbtn.Enabled = false;
                NoEdit();
            }
        }
        private void new_itemchbx_CheckedChanged(object sender, EventArgs e)
        {
            if (new_itemchbx.Checked)
            {
                worklbl.Text = "Category";
                servicecmb.Enabled = false;
                servicecmb.Hide();
                categorycmb.Show();
                categorycmb.Enabled = true;
                qurry = "Select * from [" + StockDB.t_Category_T + "]";
                fillcategoryecombo(qurry);
                categorychk.Show();
                categorychk.Enabled = true;
                categorychk.Checked = false;               
                ratetxt.Text = "0";
                lblprerate.Text = "";
            }
            else
            {
                worklbl.Text = "Work";
                categorycmb.Enabled = false;
                categorycmb.Hide();
                servicecmb.Show();
                servicecmb.Enabled = true;
                categorychk.Hide();
                categorychk.Checked = false;
                cattxt.Clear();
                ratetxt.Text = "0";
                addbtn.Enabled = false;
            }
        }
        private void fillcategoryecombo(string qurry)
        {
            categorycmb.Items.Clear();
            ds = Fall.fill_ds(qurry, Constant.StockDB);
            i = 0;
            while (i < ds.Rows.Count)
            {
                categorycmb.Items.Add(ds.Rows[i][StockDB.c_Category_T.f_Name].ToString());
                i++;
            }
            categorycmb.Items.Add("Select Category");
            categorycmb.SelectedIndex = categorycmb.Items.Count - 1;
        }
        private void categorycmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categorycmb.SelectedIndex != categorycmb.Items.Count - 1)
            {
                Edit();

                descrptxt.Clear();
                hsntxt.Clear();
                ratetxt.Clear();
                qntytxt.Clear();               

                NoEdit();
                descrptxt.ReadOnly = false;
                hsntxt.ReadOnly = false;
                qntytxt.ReadOnly = false;
                ratetxt.ReadOnly = false;
                addbtn.Enabled = true;
            }
            else
            {
                Edit();
                descrptxt.Clear();
                hsntxt.Clear();
                ratetxt.Text = "0";
                qntytxt.Clear();
                addbtn.Enabled = false;
                NoEdit();
            }
        }
        private void categorychk_CheckedChanged(object sender, EventArgs e)
        {            
            if (categorychk.Checked == true)
            {
                catlbl.Visible = true;                
                cattxt.Visible = true;
                cattxt.Enabled = true;
                cattxt.ReadOnly = false;
                cattxt.Text = "Name";
                genNewItmNo.Visible = true;
                genNewItmNo.Enabled = true;
                genNewItmNo.Checked = true;
                categorycmb.Enabled = false;
                descrptxt.ReadOnly = false;
                hsntxt.ReadOnly = false;
                qntytxt.ReadOnly = false;
                ratetxt.ReadOnly = false;
                addbtn.Enabled = true;
            }
            else
            {
                catlbl.Visible = false;
                cattxt.Visible = false;
                cattxt.Enabled = false;
                genNewItmNo.Checked = false;
                genNewItmNo.Visible = false;
                genNewItmNo.Enabled = false;
                descrptxt.ReadOnly = true;
                hsntxt.ReadOnly = true;
                qntytxt.ReadOnly = true;
                ratetxt.ReadOnly = true;
                addbtn.Enabled = false;
                categorycmb.Enabled = true;
                categorycmb.SelectedIndex = categorycmb.Items.Count - 1;
            }
        }        
        private void filljobcmb(string qurry)
        {
            servicecmb.Items.Clear();
            ds = Fall.fill_ds(qurry, Constant.StockDB);
            i = 0;
            while (i < ds.Rows.Count)
            {
                servicecmb.Items.Add(ds.Rows[i][StockDB.c_Job_T.f_stockId].ToString());
                i++;
            }
            servicecmb.Items.Add("Select");
            servicecmb.SelectedIndex = servicecmb.Items.Count - 1;
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            bool adchk = true;
            string tname = "Item_" + itemcmbx.Text;
            try
            {
                double bal = Call.ret_Balance(itemcmbx.Text, Constant.Item);
                if (new_itemchbx.Checked == false)
                {
                    if ((Convert.ToDouble(qntytxt.Text) <= 0 || Convert.ToDouble(ratetxt.Text) <= 0))
                    {
                        MessageBox.Show("Invalid Entry, please check quantity and rate");
                        adchk = false;
                    }
                }
                else if (bal < Convert.ToDouble(qntytxt.Text))
                {
                    MessageBox.Show("You dont have sufficient quantity in stock.\nAvailable quantity is " + bal + ". ");
                    qntytxt.ForeColor = Color.DarkRed;
                    adchk = false;
                }
                else if ((Convert.ToDouble(qntytxt.Text) <= 0))
                {
                    MessageBox.Show("Invalid Entry, please check quantity");
                    adchk = false;
                }
                else if (servicecmb.Text == "Select Work" && categorychk.Checked == false && new_itemchbx.Checked == false)
                {
                    MessageBox.Show("Please Select a job");
                    adchk = false;
                }
                else if (itemcmbx.Text == "Select Item")
                {
                    MessageBox.Show("Please Select a Item");
                    adchk = false;
                }
            }

            catch (Exception)
            {
                adchk = false;
                MessageBox.Show("Invalid Entry, please check quantity and rate");
            }

            if (adchk)
            {
                Edit();
                string workno = "0";
                try
                {
                    if (new_itemchbx.Checked && categorychk.Checked)
                    {
                        workno = Constant.NEW + cattxt.Text;
                        Call.add_new_category(cattxt.Text, " ", genNewItmNo.Checked.ToString(), Constant.StockDB);                        
                    }
                    else if (new_itemchbx.Checked && categorychk.Checked == false)
                    {
                        workno = "New" + categorycmb.Text;
                    }
                    else
                    {
                        workno = servicecmb.Text;
                    }

                    try
                    {
                        if (new_itemchbx.Checked)
                        {
                            Convert.ToDouble(ratetxt.Text);
                        }
                    }
                    catch (Exception)
                    {
                        ratetxt.Text = "Not Declare";
                    }
                    if (ratetxt.Text != "Not Declare")
                    {
                        amt = (Convert.ToDouble(qntytxt.Text) * Convert.ToDouble(ratetxt.Text)).ToString();
                    }
                    itemdtdgv.ReadOnly = false;
                    itemdtdgv.Rows.Add(itemcmbx.Text, workno, descrptxt.Text, hsntxt.Text, qntytxt.Text, ratetxt.Text, amt);
                    itemdtdgv.ReadOnly = true;
                    delbtn.Enabled = true;
                    addbtn.Enabled = false;
                    new_itemchbx.Checked = false;
                    cal(itemdtdgv.RowCount - 1, 1);
                    descrptxt.ReadOnly = false;
                    hsntxt.ReadOnly = false;

                    descrptxt.Clear();
                    hsntxt.Clear();
                    ratetxt.Clear();
                    qntytxt.Clear();
                    qurry = "Select name from [" + StockDB.t_Category_T + "]";
                    fillcategoryecombo(qurry);
                    descrptxt.ReadOnly = true;
                    hsntxt.ReadOnly = true;
                    suppliercmbx.Enabled = false;
                    itemcmbx.SelectedIndex = itemcmbx.Items.Count - 1;                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                NoEdit();
            }
        }
        private void delbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cal(itemdtdgv.SelectedRows[0].Index, -1);
                itemdtdgv.Rows.RemoveAt(itemdtdgv.SelectedRows[0].Index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (itemdtdgv.SelectedRows.Count < 1)
            {
                delbtn.Enabled = false;
            }
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            if (check_condition())
            {
                Edit();
                billidtxt.Text = (Convert.ToDouble(Fall.LBI(lck.tname1)) + 1).ToString();
                lck.InsertBT.Invoke(stockvaluetxt.Text,billidtxt.Text, date_.Text, Call.ret_id(CompanyDB.c_Company_T.f_Name, suppliercmbx.Text, Constant.CompanyDB, CompanyDB.t_Company_T), txtpaymentterm.Text, "", "No agent", emplbl.Text, Call.ret_id(CompanyDB.c_Company_T.f_Name, cmbtransport.Text, Constant.CompanyDB, CompanyDB.t_Company_T), "", txttransport_charge.Text, txtpackaging.Text);                
                string tnx = Constant.Debit;
                if (lck.Sell)
                {
                    tnx = Constant.Credit;
                }               
                int n = 0;
                while (n < itemdtdgv.Rows.Count)
                {
                    lck.InsertBDT.Invoke("0", "", billidtxt.Text, itemdtdgv.Rows[n].Cells[0].Value.ToString(), itemdtdgv.Rows[n].Cells[5].Value.ToString(), discrattxt.Text, itemdtdgv.Rows[n].Cells[4].Value.ToString(), "");
                    Ledgerdt it = new Ledgerdt();
                    it.item = itemdtdgv.Rows[n].Cells[0].Value.ToString();
                    it.debit = true;
                    it.credit = false;
                    it.folio = billidtxt.Text;
                    it.F_party = lblhead.Text;
                    it.S_party = suppliercmbx.Text;
                    it.particular = "Given For Work";
                    it.form_id = form_id.job_billf_fid.ToString();
                    it.table_id = lck.tname1;
                    Ledger_Process.Item_Update(it);
                    n = n + 1;
                }

                NoEdit();
                savebtn.Enabled = false;
                discardbtn.Enabled = false;
                cmbtransport.Enabled = false;
                itemcmbx.Enabled = false;
                date_.Enabled = false;
                newbtn.Show();
                newbtn.Enabled = true;
                prntbtn.Show();
                prntbtn.Enabled = true;
            }
        }
        private void discardbtn_Click(object sender, EventArgs e)
        {
            Edit();
            dgvDelete();
            NoEdit();
            suppliercmbx.Enabled = true;
            suppliercmbx.SelectedIndex = suppliercmbx.Items.Count - 1;
        }
        private void prntbtn_Click(object sender, EventArgs e)
        {
            PrntCom fm = new PrntCom();
            fm.datetxt = date_;
            fm.invoidtxt = billidtxt;
            fm.grtottxt = grtottxt;
            fm.igsttxt = txtigst;
            fm.itemdtdgv = itemdtdgv;
            fm.numwrdtxt = numwrdtxt;
            fm.packagingtxt = txtpackaging;
            fm.packlbl.Text = "";
            fm.pcstxt = pcstxt;
            fm.cgsttxt = txtcgst;
            fm.sgsttxt = txtsgst;
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
        private void newbtn_Click(object sender, EventArgs e)
        {
            suppliercmbx.Enabled = true;
            suppliercmbx.SelectedIndex = suppliercmbx.Items.Count - 1;

            Edit();
            billidtxt.Text = Constant.Hash;
            discrattxt.Text = "0";
            NoEdit();
            newbtn.Hide();
            prntbtn.Hide();
            dgvDelete();
            savebtn.Enabled = true;
            discardbtn.Enabled = true;
            suppliercmbx.Enabled = true;
            date_.Enabled = true;
        }
        private void Nextbtn_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos > ds.Rows.Count-1)
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
        void cal(int n, int sign)
        {
            numofitmtxt.Text = Convert.ToString(Convert.ToInt32(numofitmtxt.Text) + sign);
            pcstxt.Text = Convert.ToString(Convert.ToDouble(pcstxt.Text) + Convert.ToDouble(itemdtdgv.Rows[n].Cells[4].Value) * sign);
            subttxt.Text = Convert.ToString(Convert.ToDouble(subttxt.Text) + Convert.ToDouble(itemdtdgv.Rows[n].Cells[6].Value) * sign);
            stockvaluetxt.Text = Convert.ToString(Convert.ToDouble(stockvaluetxt.Text) + Call.ret_stockValue(itemdtdgv.Rows[n].Cells[0].Value.ToString(), Convert.ToDouble(itemdtdgv.Rows[n].Cells[4].Value), Constant.Item));
            subcal();
        }
        private void subcal()
        {
            disctxt.Text = Convert.ToString(Convert.ToDouble(subttxt.Text) * (Convert.ToDouble(discrattxt.Text) / 100));
            tottxt.Text = Convert.ToString(Convert.ToDouble(subttxt.Text) - Convert.ToDouble(disctxt.Text));

            Cal_dt cdt = new Cal_dt();
            cdt.amt = tottxt.Text;
            GST gst = new GST();
            cdt.f_id = Call.GTD(Constant.Company_id);
            cdt.f_db = Constant.CompanyDB;
            cdt.s_id = Call.ret_id(CompanyDB.c_Company_T.f_Name, suppliercmbx.Text, Constant.CompanyDB,CompanyDB.t_Company_T);
            cdt.s_db = Constant.CompanyDB;
            gst = Fall.ret_GST(cdt);
            txtcgst.Text = gst.cgst;
            txtsgst.Text = gst.sgst;
            txtigst.Text = gst.igst;
            txtttax.Text = gst.ttax;
            if (lck.callas != Constant.challan)
            {
                grtottxt.Text = (Convert.ToDouble(grtottxt.Text) + Convert.ToDouble(txtttax.Text)).ToString();
                grtottxt.Text = Convert.ToString(Math.Round(Convert.ToDouble(tottxt.Text) + Convert.ToDouble(txtttax.Text) + Convert.ToDouble(txtpackaging.Text) + Convert.ToDouble(txttransport_charge.Text)));
            }
            else
            {
                grtottxt.Text = Convert.ToString(Math.Round(Convert.ToDouble(tottxt.Text) + Convert.ToDouble(txtpackaging.Text) + Convert.ToDouble(txttransport_charge.Text)));
            }            
            numwrdtxt.Text = NumToWord.ConvertNumbertoWords(Convert.ToInt32(Convert.ToDouble(grtottxt.Text)));
        }
        private void Nav(int pos)
        {
            if (ds.Rows.Count>0)
            {
                Edit();
                billidtxt.Text = ds.Rows[pos][TranDB.c_Job_Bill_T.f_billno].ToString();
                date_.Enabled = true;
                date_.Text = ds.Rows[pos][TranDB.c_Job_Bill_T.f_date_].ToString();
                date_.Enabled = false;
                suppliercmbx.Enabled = true;
                suppliercmbx.Text = Call.ret_Name(ds.Rows[pos][TranDB.c_Job_Bill_T.f_beneficiary_fkey].ToString(), Constant.CompanyDB);
                suppliercmbx.Enabled = false;
                emplbl.Text = ds.Rows[pos][TranDB.c_Job_Bill_T.f_author].ToString();
                stockvaluetxt.Text = ds.Rows[pos][TranDB.c_Job_Bill_T.f_goodsValue].ToString();
                dgvDelete();
                string qurry = "select * from [" + lck.tname2 + "] where " + TranDB.c_Bill_D_T.f_bill_ID_fkey + "='" + billidtxt.Text + "'";
                DataTable dst = new DataTable();
                dst = Fall.fill_ds(qurry);
                i = 0;
                while (i < dst.Rows.Count)
                {
                    string sitem = dst.Rows[i][TranDB.c_Job_Bill_D_T.f_item_no_fkey].ToString();
                    string swork = dst.Rows[i][TranDB.c_Job_Bill_D_T.f_job_fkey].ToString();
                    string sqnty = dst.Rows[i][TranDB.c_Job_Bill_D_T.f_qnty].ToString();
                    string srate = dst.Rows[i][TranDB.c_Job_Bill_D_T.f_rate].ToString();
                    string sdespt = Call.set_detail(swork, Constant.Job)[0];
                    string shsn = Call.set_detail(swork, Constant.Job)[1];
                    try
                    {
                        amt = (Convert.ToDouble(srate) * Convert.ToDouble(sqnty)).ToString();
                    }
                    catch (Exception)
                    {
                        amt = "0";
                    }
                    itemdtdgv.Rows.Add(sitem, swork, sdespt, shsn, sqnty, srate, amt.ToString());
                    cal(itemdtdgv.Rows.Count - 1, 1);
                    i++;
                }
                NoEdit();
            }
            else
            {
                MessageBox.Show("No Record Found!");
            }
        }
        bool check_condition()
        {
            bool chk = true;
            if (suppliercmbx.Text == "Select Servicer")
            {
                chk = false;
                MessageBox.Show("Supplier Detail is not given");
            }
            if (itemdtdgv.Rows.Count < 1)
            {
                chk = false;
                MessageBox.Show("Item Detail is not given");
            }
            return chk;
        }
        private void dgvDelete()
        {
            while (itemdtdgv.SelectedRows.Count > 0)
            {
                try
                {
                    cal(0, -1);
                    itemdtdgv.ReadOnly = false;
                    itemdtdgv.Rows.RemoveAt(0);
                    itemdtdgv.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
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
        private void discrattxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(discrattxt.Text);

            }
            catch (Exception)
            {
                discrattxt.Text = "0";
            }
            subcal();
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
    }
    public class JBillFdt : CompanyFdt
    {
        public string tname1;
        public string tname2;
        public TranDB.insert_Job_Bill_T InsertBT;
        public TranDB.insert_Job_Bill_D_T InsertBDT;
    }
}
