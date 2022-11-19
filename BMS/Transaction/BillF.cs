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
    public partial class BillF : nform 
    {
        BillFdt ck = new BillFdt();
        public BillF(BillFdt cks)
        {
            ck = cks;
            InitializeComponent();
            CallCheck();
        }
        DataTable ds = new DataTable();
        string qurry;
        int pos = 0;
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
            lblhead.Text = ck.lblHead;
            lblauthor.Text = Call.Ret_UserName();
            NoEdit();
            ewaybil_lbl.Hide();
            txtewaybill.Hide();
            qurry = "Select * from " + CompanyDB.t_Company_T + " where " + CompanyDB.c_Company_T.f_category + "='Transporter'";
            ds = Fall.fill_ds(qurry, Constant.CompanyDB);
            fillTransportcmb(ds);
            if (ck.mode == Constant.NEW)
            {
                btnsave.Show();
                btnsave.Enabled = true;
                btndiscard.Show();
                btndiscard.Enabled = true;
                btndelete.Show();
                btnadd.Show();
                if (!ck.Sell)
                {
                    chbxnew_item.Show();
                }

                ds = Fall.fill_ds("SELECT Company_T.Name, Category_T.Name AS category, Category_T.sub FROM Company_T INNER JOIN Category_T ON Company_T.category = Category_T.Id where " + CompanyDB.c_Category_T.f_sub + "='" + ck.callby+"'",Constant.CompanyDB);
                date_.Enabled = true;                
                if (ds.Rows.Count > 0)
                {
                    cmbparty.Enabled = true;
                    fillPartycmb(ds);
                    cmbtransport.Enabled = true;
                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("No beneficiary record exist.\nDo you want to add?", "Add Record?", MessageBoxButtons.YesNo))
                    {
                        CompanyFdt ss = new CompanyFdt();
                        ss = Constant.AddParty();
                        ss.callby = ck.callby;
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
            }
            else if (ck.mode == Constant.VIEW)
            {
                btnNext.Show();
                btnNext.Enabled = true;
                btnprevious.Show();
                btnprevious.Enabled = true;
                btnprnt.Show();
                btnprnt.Enabled = true;
                ds = Fall.fill_ds("Select * from [" + ck.tname1 + "]");
                pos = ds.Rows.Count - 1;
                Nav(pos);
            }
            else if (ck.mode == Constant.EDIT)
            {
               
            }
        }
        void Edit()
        {
            txtewaybill.ReadOnly = false;
            txtpaymentterm.ReadOnly = false;
            txtpackaging.ReadOnly = false;
            txttransport_charge.ReadOnly = false;
            txtbillid.ReadOnly = false;
            txttotal.ReadOnly = false;
            txtdiscount.ReadOnly = false;
            txtsubtotal.ReadOnly = false;
            txtgrtotal.ReadOnly = false;
            txtdiscrat.ReadOnly = false;
            txtnumofitm.ReadOnly = false;
            txtpcs.ReadOnly = false;
            txtnumwrd.ReadOnly = false;
            dgvitemdt.ReadOnly = false;
            txtigst.ReadOnly = false;
            txtttax.ReadOnly = false;
            txtcgst.ReadOnly = false;
            txtsgst.ReadOnly =  false;
            txtrate.ReadOnly =  false;
            txtqnty.ReadOnly = false;
            txthsn.ReadOnly =   false;
            txtdescrp.ReadOnly = false;
            dgvitemdt.ReadOnly = false;
        }
        void NoEdit()
        {
            txtewaybill.ReadOnly = true;
            txtpaymentterm.ReadOnly = true;
            txtpackaging.ReadOnly = true;
            txttransport_charge.ReadOnly = true;
            txtbillid.ReadOnly = true;
            txttotal.ReadOnly = true;
            txtdiscount.ReadOnly = true;
            txtsubtotal.ReadOnly = true;
            txtgrtotal.ReadOnly = true;
            txtdiscrat.ReadOnly = true;
            txtnumofitm.ReadOnly = true;
            txtpcs.ReadOnly = true;
            txtnumwrd.ReadOnly = true;
            txtigst.ReadOnly = true;
            txtttax.ReadOnly = true;
            txtcgst.ReadOnly = true;
            txtsgst.ReadOnly = true;
            txtrate.ReadOnly = true;
            txtqnty.ReadOnly = true;
            txthsn.ReadOnly = true;
            txtdescrp.ReadOnly = true;
            dgvitemdt.ReadOnly = true;
        }
        void fillPartycmb(DataTable dst)
        {
            int i = 0;
            while (i < dst.Rows.Count)
            {
                cmbparty.Items.Add(dst.Rows[i][CompanyDB.c_Company_T.f_Name].ToString());
                i++;
            }
            cmbparty.Items.Add("Select");
            cmbparty.SelectedIndex = cmbparty.Items.Count - 1;
        }        
        private void cmbparty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbparty.SelectedIndex != cmbparty.Items.Count - 1)
            {
                chbxnew_item.Enabled = true;
                chbxnew_item.Checked = false;
                cmbitem.Enabled = true;
                string tname = "";
                if (ck.Type == Constant.Item)
                {
                    tname = StockDB.t_Item_T;
                }
                else if (ck.Type == Constant.Service)
                {
                    tname = StockDB.t_Service_T;
                }
                if (ck.Sell)
                {
                    qurry = "Select * from [" + tname + "]";
                }
                else
                {  
                    qurry = "Select * from [" + tname + "] where " + StockDB.c_Item_T.f_supplier_fkey + "='" + Call.ret_id(CompanyDB.c_Company_T.f_Name, cmbparty.Text, Constant.CompanyDB, CompanyDB.t_Company_T) + "'";
                }                
                ds = Fall.fill_ds(qurry, Constant.StockDB);
                fillitemcmb(ds);               
            }
            else
            {
                cmbitem.Enabled = false;
                chbxnew_item.Checked = false;
                chbxnew_item.Enabled = false;
            }
        }
        void fillTransportcmb(DataTable dst)
        {
            cmbtransport.Items.Clear();
            int i = 0;
            while (i < dst.Rows.Count)
            {
                cmbtransport.Items.Add(dst.Rows[i][CompanyDB.c_Company_T.f_Name].ToString());
                i++;
            }
            cmbtransport.Items.Clear();
            cmbtransport.Items.Add("Hand Delivery");
            cmbtransport.SelectedIndex = cmbtransport.Items.Count - 1;
        }
        void fillitemcmb(DataTable dst)
        {
            cmbitem.Items.Clear();
            int i = 0;
            while (i < dst.Rows.Count)
            {
                cmbitem.Items.Add(dst.Rows[i][StockDB.c_Service_T.f_stockId].ToString());
                i++;
            }
            cmbitem.Items.Add("Select Item");
            cmbitem.SelectedIndex = cmbitem.Items.Count - 1;
        }
        void cal(int n, int sign)
        {
            txtnumofitm.Text = Convert.ToString(Convert.ToInt32(txtnumofitm.Text) + sign);
            txtpcs.Text = Convert.ToString(Convert.ToDouble(txtpcs.Text) + Convert.ToDouble(dgvitemdt.Rows[n].Cells[3].Value) * sign);
            txtsubtotal.Text =Math.Round(Convert.ToDouble(txtsubtotal.Text) + Convert.ToDouble(dgvitemdt.Rows[n].Cells[5].Value) * sign,2).ToString();
            subcal();
        }
        private void subcal()
        {
            txtdiscount.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtsubtotal.Text) * (Convert.ToDouble(txtdiscrat.Text) / 100),2));
            txttotal.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtsubtotal.Text) - Convert.ToDouble(txtdiscount.Text),2));


            Cal_dt cdt = new Cal_dt();
            cdt.amt = txttotal.Text;
            cdt.f_id = Call.GTD(Constant.Company_id);
            cdt.f_db = Constant.CompanyDB;
            cdt.s_id = Call.ret_id(CompanyDB.c_Company_T.f_Name, cmbparty.Text, Constant.CompanyDB, CompanyDB.t_Company_T);
            cdt.s_db = Constant.CompanyDB;
            GST gst = new GST();
            gst = Fall.ret_GST(cdt);
            txtcgst.Text = gst.cgst;
            txtsgst.Text = gst.sgst;
            txtigst.Text = gst.igst;
            txtttax.Text = gst.ttax;

            if (ck.callas!=Constant.challan)
            {
                txtgrtotal.Text = (Convert.ToDouble(txtgrtotal.Text) + Convert.ToDouble(txtttax.Text)).ToString();
                txtgrtotal.Text = Convert.ToString(Math.Round(Convert.ToDouble(txttotal.Text) + Convert.ToDouble(txtttax.Text) + Convert.ToDouble(txtpackaging.Text) + Convert.ToDouble(txttransport_charge.Text)));
            }
            else
            {
                if (true)
                {
                    txtgrtotal.Text = (Convert.ToDouble(txtgrtotal.Text) + Convert.ToDouble(txtttax.Text)).ToString();
                    txtgrtotal.Text = Convert.ToString(Math.Round(Convert.ToDouble(txttotal.Text) + Convert.ToDouble(txtttax.Text) + Convert.ToDouble(txtpackaging.Text) + Convert.ToDouble(txttransport_charge.Text)));
                }
                else
                {
                    txtgrtotal.Text = Convert.ToString(Math.Round(Convert.ToDouble(txttotal.Text) + Convert.ToDouble(txtpackaging.Text) + Convert.ToDouble(txttransport_charge.Text)));
                }
            }
            txtnumwrd.Text = NumToWord.ConvertNumbertoWords((Convert.ToDouble(txtgrtotal.Text)));
        }
        private void cmbitem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbitem.SelectedIndex != cmbitem.Items.Count - 1)
            {
                Edit();
                if (ck.Type == Constant.Item)
                {
                    List<string> dt_list = new List<string>();
                    dt_list = Call.set_detail(cmbitem.Text, Constant.Item);
                    txtdescrp.Text = dt_list[0];
                    txthsn.Text = dt_list[1];                                       
                    txtrate.Text = Call.ret_rate(cmbitem.Text, Constant.StockDB, Constant.Item);
                    txtqnty.Clear();
                }
                else
                {
                    List<string> dt_list = new List<string>();
                    dt_list = Call.set_detail(cmbitem.Text, Constant.Service);
                    txtdescrp.Text = dt_list[0];
                    txthsn.Text = dt_list[1];
                    txtrate.Text = Call.ret_rate(cmbitem.Text, Constant.StockDB, Constant.Service);
                    txtqnty.Clear();
                }
                if (ck.Sell)
                {
                    txtrate.Text= Call.price_calculator(Convert.ToDouble(txtrate.Text)).ToString();
                }
                lblprerate.Text = "Last time rate: "+ Call.ret_lreate(cmbitem.Text, Call.ret_id(CompanyDB.c_Company_T.f_Name, cmbparty.Text, Constant.CompanyDB, CompanyDB.t_Company_T), ck.tname1, ck.tname2,ck.Type);
                if (lblprerate.Text == "Last time rate: ")
                {
                    lblprerate.Text = "";
                }
                NoEdit();
                txtqnty.ReadOnly = false;
                txtrate.ReadOnly = false;
                txtdiscrat.ReadOnly = false;
                txttransport_charge.ReadOnly = false;
                txtpackaging.ReadOnly = false;
                txtpaymentterm.ReadOnly = false;
                btnadd.Enabled = true;
            }
            else
            {
                lblprerate.Text = "";
                Edit();
                txtdescrp.Clear();
                txthsn.Clear();
                txtrate.Text = "0";
                txtqnty.Clear();
                NoEdit();
                txtdiscrat.ReadOnly = false;
                txttransport_charge.ReadOnly = false;
                txtpackaging.ReadOnly = false;
                txtpaymentterm.ReadOnly = false;
                btnadd.Enabled = false;
            }
        }
        private void chbxnew_item_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxnew_item.Checked)
            {
                cmbitem.Enabled = false;
                txtdescrp.ReadOnly = false;
                txthsn.ReadOnly = false;
                txtqnty.ReadOnly = false;
                txtrate.ReadOnly = false;               
                btnadd.Enabled = true;
                lblprerate.Hide();
            }
            else
            {
                cmbitem.Enabled = true;
                txtdescrp.ReadOnly = true;
                txthsn.ReadOnly = true;
                lblprerate.Show();          
                if (cmbitem.SelectedIndex == cmbitem.Items.Count - 1)
                {
                    txtqnty.ReadOnly = true;
                    txtrate.ReadOnly = true;
                    btnadd.Enabled = false;
                }
                else
                {
                    txtqnty.ReadOnly = false;
                    txtrate.ReadOnly = false;
                    btnadd.Enabled = true;
                }
            }
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (condtiion())
            {
                Edit();
                btndelete.Enabled = true;
                btnsave.Enabled = true;
                btndiscard.Enabled = true;                
                string itno = "";
                if (chbxnew_item.Checked)
                {
                    itno = Constant.NEW;
                }
                else
                {
                    itno = cmbitem.Text;
                }
                double amt = Convert.ToDouble(txtrate.Text) * Convert.ToDouble(txtqnty.Text);
                dgvitemdt.Rows.Add(itno, txtdescrp.Text, txthsn.Text, txtqnty.Text, txtrate.Text, amt.ToString());
                cal(dgvitemdt.Rows.Count-1, 1);
                NoEdit();
                chbxnew_item.Checked = false;
                cmbtransport.Enabled = true;
                txtdiscrat.ReadOnly = false;
                txttransport_charge.ReadOnly = false;
                txtpackaging.ReadOnly = false;
                txtpaymentterm.ReadOnly = false;
                cmbparty.Enabled = false;
                cmbitem.SelectedIndex = cmbitem.Items.Count - 1;
            }            
        }
        private bool condtiion()
        {
            bool adchk = true;
            try
            {
                if (Convert.ToDouble(txtqnty.Text) <= 0 || Convert.ToDouble(txtrate.Text) <= 0)
                {
                    MessageBox.Show("Invalid Entry, please check quantity and rate");
                    adchk = false;
                }
                else if (chbxnew_item.Checked==false)
                {
                    if (Call.ret_Balance(cmbitem.Text, Constant.Item) < Convert.ToDouble(txtqnty.Text)&&ck.callby!="Creditor")
                    {
                        adchk = false;
                        MessageBox.Show("You dont have sufficient quantity.\n Available quantity is " + Call.ret_Balance(cmbitem.Text, Constant.Item).ToString() + " only!");
                    }
                }
            }
            catch (Exception)
            {
                adchk = false;
                MessageBox.Show("Invalid Entry, please check quantity and rate");
            }            
            return adchk;
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            cal(dgvitemdt.SelectedRows[0].Index, -1);
            dgvitemdt.Rows.RemoveAt(dgvitemdt.SelectedRows[0].Index);
            if (dgvitemdt.Rows.Count<1)
            {
                btndelete.Enabled = false;
                btnsave.Enabled = false;
                btndiscard.Enabled = false;
                cmbtransport.Enabled = false;
                txtdiscrat.ReadOnly = true;
                txttransport_charge.ReadOnly = true;
                txtpackaging.ReadOnly = true;
                txtpaymentterm.ReadOnly = true;
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            bool adchk = true;
            try
            {
                if (Convert.ToDouble(txtgrtotal.Text) <= 0)
                {
                    MessageBox.Show("Invalid Entry, please check!");
                    adchk = false;
                }
            }
            catch (Exception)
            {
                adchk = false;
                MessageBox.Show("Invalid Entry, please check!");
            }
            if (adchk)
            {
                string tnx = "";
                if (ck.Sell)
                {
                    tnx = Constant.Credit;
                }
                else
                {
                    tnx = Constant.Debit;
                }
                Edit();                
                ck.InsertBT.Invoke((Convert.ToDouble(Fall.LBI(ck.tname1, "billno",Constant.TransDB))+1).ToString(), date_.Text , Call.ret_id(CompanyDB.c_Company_T.f_Name, cmbparty.Text, Constant.CompanyDB, CompanyDB.t_Company_T), txtpaymentterm.Text ,txtewaybill.Text,"no agent", Call.GTD(Constant.User_id),Call.ret_id(CompanyDB.c_Company_T.f_Name, cmbtransport.Text, Constant.CompanyDB, CompanyDB.t_Company_T),"",txttransport_charge.Text , txtpackaging.Text);
                txtbillid.Text = Fall.LBI(ck.tname1, "billno");
                Ledger_Process.Ledger_Update(Call.GTD(Constant.Company_id), Call.ret_id(CompanyDB.c_Company_T.f_Name, cmbparty.Text, Constant.CompanyDB, CompanyDB.t_Company_T),date_.Text,tnx,txtbillid.Text,txtpcs.Text+" issued against this DocId",ck.tname1,Form.ActiveForm.Name);
                Call.InsertTaxdb(ck.tname1, Call.IsRevrsChrge(ck.Sell, Call.ret_Gst(Call.ret_id(CompanyDB.c_Company_T.f_Name, cmbparty.Text, Constant.CompanyDB, CompanyDB.t_Company_T), Constant.CompanyDB) != ""), ck.Sell, ck.callas != Constant.challan, Call.GTD(Constant.Company_id), Call.ret_id(CompanyDB.c_Company_T.f_Name, cmbparty.Text, Constant.CompanyDB, CompanyDB.t_Company_T), date_.Text, txtbillid.Text, txtttax.Text);
                int i = 0;
                while (i<dgvitemdt.Rows.Count)
                {
                    Item dt = new Item();
                    dt.Item_no = dgvitemdt.Rows[i].Cells[0].Value.ToString();                    
                    dt.date_ = date_.Text;
                    dt.description = dgvitemdt.Rows[i].Cells[1].Value.ToString();
                    dt.hsn = dgvitemdt.Rows[i].Cells[2].Value.ToString();
                    dt.rate = Convert.ToDouble(dgvitemdt.Rows[i].Cells[4].Value.ToString());
                    dt.supplier_ID_fkey = Call.ret_id(CompanyDB.c_Company_T.f_Name, cmbparty.Text, Constant.CompanyDB, CompanyDB.t_Company_T);
                    dt.name = "00";
                    dt.category = " ";
                    dt.unit = " ";
                    dt.ledgerReq = true.ToString();
                    if (dgvitemdt.Rows[i].Cells[0].Value.ToString() == Constant.NEW)
                    {
                        dgvitemdt.Rows[i].Cells[0].Value = dt.Item_no = Call.add_new_item(dt);
                    }
                    else
                    {
                        Call.save_rate(dt, txtbillid.Text, ck.Type);  
                    }
                    string itmtnx = null;
                    if (tnx==Constant.Credit)
                    {
                        itmtnx = Constant.Debit;
                    }
                    else
                    {
                        itmtnx = Constant.Credit;
                    }
                    
                    Ledger_Process.Item_Update(Call.GTD(Constant.Company_id), "Item_" + dt.Item_no, itmtnx, txtbillid.Text,ck.tname1, form_id.billf_fid.ToString());
                    ck.InsertBDT.Invoke(txtbillid.Text, dgvitemdt.Rows[i].Cells[0].Value.ToString(), dgvitemdt.Rows[i].Cells[4].Value.ToString(), txtdiscrat.Text, dgvitemdt.Rows[i].Cells[3].Value.ToString(), "");
                    i++;
                }
                NoEdit();
                foreach (Control item in Controls)
                {
                    if (!(item is TextBox)&& !(item is DataGridView)&& !(item is Label) && !(item is GroupBox))
                    {
                        item.Enabled = false;
                    }
                    else if (item is GroupBox)
                    {
                        foreach (Control gitem in item.Controls)
                        {
                            if (!(gitem is TextBox) && !(gitem is DataGridView) && !(gitem is Label) && !(gitem is GroupBox))
                            {
                                gitem.Enabled = false;
                            }
                        }
                    }
                }                
                btnnew.Show();
                btnprnt.Show();
                btnprnt.Enabled = true;
                btnnew.Enabled = true;
            }
        }
        private void dgvdelete()
        {
            Edit();
            
            while (0<dgvitemdt.Rows.Count)
            {
                cal(0, -1);
                dgvitemdt.Rows.RemoveAt(0);                
            }
            NoEdit();
        }
        private void btndiscard_Click(object sender, EventArgs e)
        {
            Edit();
            dgvdelete();
            NoEdit();
            cmbparty.Enabled = true;
            cmbparty.SelectedIndex = cmbparty.Items.Count - 1;
        }
        private void btnprnt_Click(object sender, EventArgs e)
        {
            PrntCom fm = new PrntCom();
            fm.datetxt = date_;
            fm.invoidtxt = txtbillid;
            fm.grtottxt = txtgrtotal;
            fm.igsttxt = txtigst;
            fm.itemdtdgv = dgvitemdt;
            fm.numwrdtxt = txtnumwrd;
            fm.packagingtxt = txtpackaging;
            fm.packlbl.Text = "";
            fm.pcstxt = txtpcs;
            fm.cgsttxt = txtcgst;
            fm.sgsttxt = txtsgst;
            fm.subttxt = txtsubtotal;
            fm.discrattxt = txtdiscrat;
            fm.disctxt = txtdiscount;
            fm.tottxt = txttotal;
            fm.transport_chargetxt = txttransport_charge;
            fm.ewaybilltxt = txtewaybill;
            PrntDocType pdt = new PrntDocType();
            pdt.doc_db = Constant.TransDB;
            pdt.doc_tname = ck.tname1;
            pdt.doc_type = ck.callas;
            pdt.head_label = lblhead.Text;
            Fall.PrintBill(fm,pdt);
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            
            btnsave.Enabled = false;
            btndiscard.Enabled = false;
            btndelete.Enabled = false;
            btnadd.Enabled = true;
            btnnew.Hide();
            btnnew.Enabled = false;
            btnprnt.Hide();
            btnprnt.Enabled = false;
            Edit();
            txtbillid.Text = Constant.Hash;
            dgvdelete();
            NoEdit();
            cmbparty.Enabled = true;
            cmbitem.Enabled = true;
            cmbtransport.Enabled = true;
            date_.Enabled = true;
            cmbparty.SelectedIndex = cmbparty.Items.Count - 1;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pos++;
            //Fall.LBI(ck.tname1, "billno");
            if (pos>ds.Rows.Count-1)
            {
                pos--;
            }
            Nav(pos);
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos <0)
            {
                pos++;
            }
            Nav(pos);
        }
        private void Nav(int n)
        {
            if (ds.Rows.Count>0)
            {
                Edit();
                txtbillid.Text = ds.Rows[n][TranDB.c_Bill_T.f_billno].ToString();
                cmbparty.Enabled = true;
                cmbparty.Text = Call.ret_Name(ds.Rows[n][TranDB.c_Bill_T.f_beneficiary_fkey].ToString(), Constant.CompanyDB);
                cmbparty.Enabled = false;
                txtewaybill.Text = ds.Rows[n][TranDB.c_Bill_T.f_ewaybill_no].ToString();
                date_.Enabled = true;
                date_.Text = (ds.Rows[n][TranDB.c_Bill_T.f_date_].ToString());
                date_.Enabled = false;
                txtpaymentterm.Text = ds.Rows[n][TranDB.c_Bill_T.f_payment_terms].ToString();
                cmbtransport.Enabled = true;
                cmbtransport.Text = Call.ret_Name(ds.Rows[n][TranDB.c_Bill_T.f_transport].ToString(), Constant.CompanyDB);
                cmbtransport.Enabled = false;               
                txtpackaging.Text = ds.Rows[n][TranDB.c_Bill_T.f_packaging].ToString();
                txttransport_charge.Text = ds.Rows[n][TranDB.c_Bill_T.f_transportation_charge].ToString();
                lblhead.Text = ck.lblHead;
                lblauthor.Text = Call.ret_data(Constant.CompanyDB,CompanyDB.t_Login_T,CompanyDB.c_Login_T.f_LoginID, ds.Rows[n][TranDB.c_Bill_T.f_author].ToString(),CompanyDB.c_Login_T.f_Name);
                dgvdelete();
                DataTable dst = new DataTable();                              
                qurry = "Select * from " + ck.tname2 + " where bill_ID_fkey =" + ds.Rows[n]["billno"].ToString();
                dst = Fall.fill_ds(qurry);
                int i = 0;
                while (i < dst.Rows.Count)
                {
                    txtdiscrat.Enabled = true;
                    txtdiscrat.Text = dst.Rows[i][TranDB.c_Bill_D_T.f_discount_rate].ToString();
                    txtdiscrat.Enabled = false;
                    double amt = Convert.ToDouble(dst.Rows[i][TranDB.c_Bill_D_T.f_rate].ToString()) * Convert.ToDouble(dst.Rows[i][TranDB.c_Bill_D_T.f_qnty].ToString());
                    string desp = "", hsn = "";
                    if (ck.Type == Constant.Item)
                    {
                        desp = Call.set_detail(dst.Rows[i][TranDB.c_Bill_D_T.f_item_no_fkey].ToString(), Constant.Item)[0];
                        hsn = Call.set_detail(dst.Rows[i][TranDB.c_Bill_D_T.f_item_no_fkey].ToString(), Constant.Item)[1];
                    }
                    else
                    {
                        desp = Call.set_detail(dst.Rows[i][TranDB.c_Bill_D_T.f_item_no_fkey].ToString(), Constant.Service)[0];
                        hsn = Call.set_detail(dst.Rows[i][TranDB.c_Bill_D_T.f_item_no_fkey].ToString(), Constant.Service)[1];
                    }
                    dgvitemdt.Rows.Add(dst.Rows[i][TranDB.c_Bill_D_T.f_item_no_fkey].ToString(), desp, hsn, dst.Rows[i][TranDB.c_Bill_D_T.f_qnty].ToString(), dst.Rows[i][TranDB.c_Bill_D_T.f_rate].ToString(), amt);
                    cal(i, 1);
                    i++;
                }
                NoEdit();
                st = true;
            }
            else
            {
                MessageBox.Show("No Record Found!");
                st = false;
                this.Close();
            }
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

        private void txtdiscrat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(txtdiscrat.Text);
            }
            catch (Exception)
            {
                txtdiscrat.Text = "0";
            }
            subcal();
        }

       
    }
    public class BillFdt : CompanyFdt
    {
        public string tname1;
        public string tname2;
        public TranDB.insert_bill_T InsertBT;
        public TranDB.insert_bill_D_T InsertBDT;
        public string id="0";
    }
}

