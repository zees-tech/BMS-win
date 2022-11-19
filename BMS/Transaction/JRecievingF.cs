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
    public partial class JRecievingF : nform
    {
        JRFdt lck = new JRFdt();
        public JRecievingF(JRFdt ck)
        {
            lck = ck;
            InitializeComponent();
            CallCheck();
        }
        string qurry;
        int i, pos = 0;
        private DataTable ds = new DataTable();
        private string amt;
        private void CallCheck()
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
            NoEdit();
            lblhead.Text=lck.lblHead;
            emplbl.Text = Call.Ret_UserName();
            lblnoteno.Text = lck.callas +"No.";
            if (lck.mode==Constant.NEW)
            {
                date_.Enabled = true;
                savebtn.Show();
                savebtn.Enabled=true;
                discardbtn.Show();
                discardbtn.Enabled = true;
                loadbtn.Show();
                loadbtn.Enabled = true;
                recievedbtn.Show();
                delbtn.Show();
                cmbtransport.Enabled = true;
                nextitembtn.Show();
                previousitembtn.Show();
                filltransportcmb();
                challancmb.Enabled = true;
                qurry = "Select * from " + lck.Rtname1;
                fillchallancmb(qurry);              
            }
            else if (lck.mode==Constant.VIEW)
            {
                previousbtn.Show();
                previousbtn.Enabled = true;
                Nextbtn.Show();
                Nextbtn.Enabled = true;
                prntbtn.Show();
                prntbtn.Enabled = true;
                qurry = "Select * from ["+lck.tname1+"]";
                ds = Fall.fill_ds(qurry);
                Nav(0);
            }
            else if (lck.mode==Constant.EDIT)
            {

            }
        }
        private void filltransportcmb()
        {
            qurry = "Select * from [" + CompanyDB.t_Company_T + "] where " + CompanyDB.c_Company_T.f_category + "='Transporter'";
            ds = Fall.fill_ds(qurry, Constant.CompanyDB);
            int i = 0;
            while (i < ds.Rows.Count)
            {
                cmbtransport.Items.Add(ds.Rows[i][CompanyDB.c_Company_T.f_Name].ToString());
                i++;
            }
            cmbtransport.Items.Add("Hand Delivery");
            cmbtransport.SelectedIndex = cmbtransport.Items.Count - 1;
        }
        private void fillchallancmb(string qurry)
        {
            ds = Fall.fill_ds(qurry);
            int n = 0;
            while (n<ds.Rows.Count)
            {
                qurry = "Select * from " + lck.Rtname2 + " where " + TranDB.c_Job_Bill_D_T.f_bill_ID_fkey + " ='" + ds.Rows[n]["billno"].ToString() + "'";
                DataTable dst = Fall.fill_ds(qurry);
                int m = 0;
                while (m<dst.Rows.Count)
                {
                    if (Convert.ToDouble(dst.Rows[m][TranDB.c_Job_Bill_D_T.f_qnty].ToString()) - Convert.ToDouble(dst.Rows[m][TranDB.c_Job_Bill_D_T.f_recieved].ToString()) > 0)
                    {
                        challancmb.Items.Add(ds.Rows[n]["billno"].ToString());
                        break;
                    }
                    m++;
                }
                n++;
            }
            challancmb.Items.Add("Select");
            challancmb.SelectedIndex = challancmb.Items.Count - 1;
        }
        private void NoEdit()
        {
            stockvaluetxt.ReadOnly = true;
            txtpackaging.ReadOnly = true;
            txttransport_charge.ReadOnly = true;
            txtpaymentterm.ReadOnly = true;
            PreWork.ReadOnly = true;
            desgntxt.ReadOnly = true;
            suppliertxt.ReadOnly = true;
            dgvloaditem.ReadOnly = true;
            dgvrecieveitm.ReadOnly = true;            
            billidtxt.ReadOnly = true;
            numofitmtxt.ReadOnly = true;
            pcstxt.ReadOnly = true;
            numwrdtxt.ReadOnly = true;
            tottxt.ReadOnly = true;
            subttxt.ReadOnly = true;
            grtottxt.ReadOnly = true;
            disctxt.ReadOnly = true;
            discrattxt.ReadOnly = true;
            txtcgst.ReadOnly = true;
            txtigst.ReadOnly = true;
            txtsgst.ReadOnly = true;
            txtttax.ReadOnly = true;
            itemtxt.ReadOnly = true;
            descrptxt.ReadOnly = true;
            hsntxt.ReadOnly = true;
            qntytxt.ReadOnly = true;
            ratetxt.ReadOnly = true;
        }             
        private void Edit()
        {
            stockvaluetxt.ReadOnly = false;
            txtpackaging.ReadOnly = false;
            txttransport_charge.ReadOnly = false;
            txtpaymentterm.ReadOnly = false;
            PreWork.ReadOnly = false;
            desgntxt.ReadOnly = false;
            suppliertxt.ReadOnly = false;
            dgvloaditem.ReadOnly = false;
            dgvrecieveitm.ReadOnly = false;            
            billidtxt.ReadOnly = false;
            numofitmtxt.ReadOnly = false;
            pcstxt.ReadOnly = false;
            numwrdtxt.ReadOnly = false;
            tottxt.ReadOnly = false;
            subttxt.ReadOnly = false;
            grtottxt.ReadOnly = false;
            disctxt.ReadOnly = false;
            discrattxt.ReadOnly = false;
            txtcgst.ReadOnly = false;
            txtigst.ReadOnly = false;
            txtsgst.ReadOnly = false;
            txtttax.ReadOnly = false;
            itemtxt.ReadOnly = false;
            descrptxt.ReadOnly = false;
            hsntxt.ReadOnly = false;
            qntytxt.ReadOnly = false;
            ratetxt.ReadOnly = false;
        }
        private void loadbtn_Click(object sender, EventArgs e)
        {
            if (challancmb.SelectedIndex!=challancmb.Items.Count-1)
            {
                qurry = "Select * from  [" + lck.Rtname1 + "] where billno ='" + challancmb.Text + "'";
                ds = Fall.fill_ds(qurry);
                Edit();
                suppliertxt.Text = Call.ret_Name(ds.Rows[0][TranDB.c_Job_Bill_T.f_beneficiary_fkey].ToString(), Constant.CompanyDB);

                dgvDelete();
                qurry = "Select * from [" + lck.Rtname2 + "] where "+TranDB.c_JobRecieving_Bill_D_T.f_bill_ID_fkey+"='" + challancmb.Text + "'";
                DataTable dst = new DataTable();
                dst= Fall.fill_ds(qurry);
                int n = 0;
                while (dst.Rows.Count > n)
                {
                    string sitm = dst.Rows[n][TranDB.c_Job_Bill_D_T.f_item_no_fkey].ToString();
                    string swork = dst.Rows[n][TranDB.c_Job_Bill_D_T.f_job_fkey].ToString();
                    string sqnty = (Convert.ToDouble(dst.Rows[n][TranDB.c_Job_Bill_D_T.f_qnty].ToString()) - Convert.ToDouble(dst.Rows[n][TranDB.c_Job_Bill_D_T.f_recieved].ToString())).ToString();
                    string srate = dst.Rows[n][TranDB.c_Job_Bill_D_T.f_rate].ToString();
                    string samt = "";
                    string shsn = "";
                    string sdescrpt = "";
                    try
                    {
                        samt = (Convert.ToDouble(srate) * Convert.ToDouble(sqnty)).ToString();
                    }
                    catch (Exception)
                    {
                        samt = "0";
                    }
                    if (swork.Length>2)
                    {
                        if (swork.Substring(0, 3) != Constant.NEW)
                        {
                            sdescrpt = Call.set_detail(swork, Constant.Job)[0];
                            shsn = Call.set_detail(swork, Constant.Job)[1];
                        }
                    }
                    if (Convert.ToDouble(sqnty) >0)
                    {
                        dgvloaditem.Rows.Add(sitm, swork, sdescrpt, shsn, sqnty, srate, samt);
                    }
                    nextitembtn.Enabled = true;
                    previousitembtn.Enabled = true;
                    workcmb.Enabled = true;
                    if (dgvloaditem.Rows.Count>0)
                    {
                        spitData(0);
                    }
                    n++;
                }
                NoEdit();
                ratetxt.ReadOnly = false;
                qntytxt.ReadOnly = false;
                discrattxt.ReadOnly = false;
                txtpackaging.ReadOnly = false;
                txttransport_charge.ReadOnly = false;
                txtpaymentterm.ReadOnly = false;             
                challancmb.Enabled = false;
                loadbtn.Enabled = false;
                nextitembtn.Enabled = true;
                previousitembtn.Enabled = true;                
            }
        }
        private void dgvDelete()
        {
            try
            {
                while (dgvrecieveitm.SelectedRows.Count > 0)
                {
                    Edit();
                    cal(0, -1);
                    dgvrecieveitm.ReadOnly = false;
                    dgvrecieveitm.Rows.RemoveAt(0);
                    dgvrecieveitm.ReadOnly = true;
                    NoEdit();
                }
                while (dgvloaditem.SelectedRows.Count > 0)
                {
                    Edit();
                    dgvloaditem.ReadOnly = false;
                    dgvloaditem.Rows.RemoveAt(0);
                    dgvloaditem.ReadOnly = true;
                    NoEdit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void cal(int n, int sign)
        {
            numofitmtxt.Text = Convert.ToString(Convert.ToInt32(numofitmtxt.Text) + sign);
            pcstxt.Text = Convert.ToString(Convert.ToDouble(pcstxt.Text) + Convert.ToDouble(dgvrecieveitm.Rows[n].Cells[4].Value) * sign);
            subttxt.Text = Convert.ToString(Convert.ToDouble(subttxt.Text) + Convert.ToDouble(dgvrecieveitm.Rows[n].Cells[6].Value) * sign);
            stockvaluetxt.Text = Convert.ToString(Convert.ToDouble(stockvaluetxt.Text) + (Convert.ToDouble(Call.ret_item_rate(dgvrecieveitm.Rows[n].Cells[0].Value.ToString())) * Convert.ToDouble(dgvrecieveitm.Rows[n].Cells[4].Value) * sign));
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
            cdt.s_id = Call.ret_id(CompanyDB.c_Company_T.f_Name, suppliertxt.Text, Constant.CompanyDB, CompanyDB.t_Company_T);
            cdt.s_db = Constant.CompanyDB;
            gst = Fall.ret_GST(cdt);
            txtcgst.Text = gst.cgst;
            txtsgst.Text = gst.sgst;
            txtigst.Text = gst.igst;
            txtttax.Text = gst.ttax;
            grtottxt.Text = Convert.ToString(Convert.ToDouble(tottxt.Text) + Convert.ToDouble(txtpackaging.Text) + Convert.ToDouble(txttransport_charge.Text));
            if (lck.callas != Constant.challan)
            {
                grtottxt.Text = (Convert.ToDouble(grtottxt.Text) + Convert.ToDouble(txtttax.Text)).ToString();
            }
            numwrdtxt.Text = NumToWord.ConvertNumbertoWords(Convert.ToInt32(Convert.ToDouble(grtottxt.Text)));
        }
        private void spitData(int n)
        { 
            itemtxt.Text = dgvloaditem.Rows[n].Cells[0].Value.ToString();
            workcmb.Enabled = true;
            fillworkcombo();
            PreWork.Text = workcmb.Text= dgvloaditem.Rows[n].Cells[1].Value.ToString();
            descrptxt.Text = dgvloaditem.Rows[n].Cells[2].Value.ToString();
            hsntxt.Text = dgvloaditem.Rows[n].Cells[3].Value.ToString();
            qntytxt.Text = dgvloaditem.Rows[n].Cells[4].Value.ToString();
            ratetxt.Text = dgvloaditem.Rows[n].Cells[5].Value.ToString();            
            recievedbtn.Enabled = true;
            if (PreWork.Text.Length>3)
            {
                if (PreWork.Text.Substring(0, 3) == Constant.NEW)
                {
                    descrptxt.ReadOnly = false;
                    hsntxt.ReadOnly = false;
                }
            }
            else
            {
                descrptxt.ReadOnly = true;
                hsntxt.ReadOnly = true;
            }                        
        }
        private void fillworkcombo()
        {
            workcmb.Items.Clear();
            if (suppliertxt.Text != "")
            {
                qurry = "Select * from [" + StockDB.t_Job_T + "] ";// where " + StockDB.c_Job_T.f_supplier_fkey + "='" + Call.ret_id(CompanyDB.c_Company_T.f_Name, suppliertxt.Text, Constant.CompanyDB, CompanyDB.t_Company_T) + "'";
                DataTable dst = Fall.fill_ds(qurry, Constant.StockDB);
                i = 0;
                bool cks = true;
                while (i < dst.Rows.Count)
                {
                    workcmb.Items.Add(dst.Rows[i][StockDB.c_Job_T.f_stockId].ToString());
                    if (dgvloaditem.Rows[dgvloaditem.SelectedRows[0].Index].Cells[workcolld.Name].Value.ToString() == dst.Rows[i][StockDB.c_Job_T.f_stockId].ToString())
                    {
                        workcmb.SelectedIndex = i;
                        cks = false;
                    }
                    i++;
                }
                if (cks)
                {
                    workcmb.Items.Add(dgvloaditem.Rows[dgvloaditem.SelectedRows[0].Index].Cells[workcolld.Name].Value.ToString());
                    workcmb.SelectedIndex = i - 1;
                }
                workcmb.Items.Add(Constant.NWR);
            }
            else
            {
                workcmb.Items.Add(Constant.NWR);
                workcmb.SelectedIndex = 0;
                workcmb.Enabled = false;
                Edit();
                descrptxt.Clear();
                NoEdit();
            }
        }
        private void recievedbtn_Click(object sender, EventArgs e)
        {
            bool adchk = true;
            try
            {
                if (Convert.ToDouble(qntytxt.Text) <= 0 || Convert.ToDouble(ratetxt.Text) <= 0)
                {
                    MessageBox.Show("Invalid Entry, please check quantity and rate");
                    adchk = false;
                }
                else if (workcmb.Text == "Select Work")
                {
                    MessageBox.Show("Please Select a job");
                    adchk = false;
                }
                else
                {
                    List<string> a, b;
                    a = new List<string> { TranDB.c_Job_Bill_D_T.f_bill_ID_fkey, TranDB.c_Job_Bill_D_T.f_item_no_fkey, TranDB.c_Job_Bill_D_T.f_job_fkey };
                    b = new List<string> { challancmb.Text, dgvloaditem.Rows[dgvloaditem.SelectedRows[0].Index].Cells[0].Value.ToString(), dgvloaditem.Rows[dgvloaditem.SelectedRows[0].Index].Cells[1].Value.ToString() };
                    string issued = Call.ret_data(Constant.TransDB,lck.Rtname2, a, b, 7, "double");
                    string recieved = Call.ret_data(Constant.TransDB, lck.Rtname2, a, b, 2, "double");
                    double bal = Convert.ToDouble(issued) - Convert.ToDouble(recieved);
                    if (Convert.ToDouble(qntytxt.Text) > bal)
                    {
                        MessageBox.Show("You Issued " + issued + " and recieved " + recieved + " pending unit is " + bal);
                        qntytxt.Text = bal.ToString();
                        adchk = false;
                    }                    
                }

            }
            catch (Exception)
            {
                adchk = false;
                MessageBox.Show("Invalid Entry, please check quantity and rate");
            }

            if (adchk)
            {
                try
                {
                    double amt = Convert.ToDouble(qntytxt.Text) * Convert.ToDouble(ratetxt.Text);
                    
                    dgvrecieveitm.Rows.Add(itemtxt.Text, workcmb.Text, descrptxt.Text, hsntxt.Text, qntytxt.Text, ratetxt.Text, amt.ToString(), desgntxt.Text, PreWork.Text);
                    
                    cal(dgvrecieveitm.RowCount - 1, 1);
                    if (dgvloaditem.SelectedRows[0].Cells[4].Value.ToString() == qntytxt.Text.ToString())
                    {
                        dgvloaditem.Rows.RemoveAt(dgvloaditem.SelectedRows[0].Index);
                    }
                    else
                    {
                        dgvloaditem.SelectedRows[0].Cells[4].Value = (Convert.ToDouble(dgvloaditem.SelectedRows[0].Cells[4].Value.ToString()) - Convert.ToDouble(qntytxt.Text)).ToString();
                    }         
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Rate, Please provide a valid rate");
                }
                if (dgvloaditem.Rows.Count > 0)
                {
                    dgvloaditem.Rows[0].Selected = true;
                    spitData(dgvloaditem.SelectedRows[0].Index);
                    delbtn.Enabled = true;
                }
                else
                {
                    recievedbtn.Enabled = false;
                    delbtn.Enabled = true;
                    nextitembtn.Enabled = false;
                    previousitembtn.Enabled = false;
                    workcmb.SelectedIndex = workcmb.Items.Count - 1;                 
                    workcmb.Enabled = false;
                    Edit();
                    itemtxt.Clear();
                    descrptxt.Clear();
                    hsntxt.Clear();
                    qntytxt.Clear();
                    ratetxt.Clear();
                    NoEdit();
                }
                discrattxt.ReadOnly = false;
                txtpackaging.ReadOnly = false;
                txttransport_charge.ReadOnly = false;
                txtpaymentterm.ReadOnly = false;
            }
        }
        private void workcmb_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (workcmb.Text != "No Work")
            {
                if (workcmb.Text.Length > 2)
                {
                    if (workcmb.Text.Substring(0, 3) == Constant.NEW)
                    {
                        Ad_design.Show();
                        Yesrdbtn.Show();
                        Yesrdbtn.Enabled = true;
                        Yesrdbtn.Checked = false;
                        nordbtn.Show();
                        nordbtn.Enabled = true;
                        nordbtn.Checked = true;
                        desgntxt.ReadOnly = true;
                        desgntxt.Text = "Design No.";
                        descrptxt.ReadOnly = false;
                        descrptxt.Clear();
                        hsntxt.ReadOnly = false;
                        hsntxt.Clear();
                        ratetxt.ReadOnly = false;
                        qntytxt.ReadOnly = false;
                    }                    
                }
                else
                {
                    Ad_design.Hide();
                    desgntxt.Hide();
                    Yesrdbtn.Hide();
                    Yesrdbtn.Checked = false;
                    nordbtn.Hide();
                    nordbtn.Checked = true;
                    descrptxt.Text = Call.set_detail(workcmb.Text, Constant.Job)[0];
                    hsntxt.Text = Call.set_detail(workcmb.Text, Constant.Job)[1];
                    descrptxt.ReadOnly = true;
                    hsntxt.ReadOnly = true;
                    ratetxt.ReadOnly = false;
                    ratetxt.Text = Call.ret_work_rate(workcmb.Text).ToString();
                    qntytxt.ReadOnly = false;
                }
            }
            else
            {
                Ad_design.Hide();
                desgntxt.Hide();
                Yesrdbtn.Hide();
                Yesrdbtn.Checked = false;
                nordbtn.Hide();
                nordbtn.Checked = true;
                descrptxt.ReadOnly = false;
                hsntxt.ReadOnly = false;
                qntytxt.ReadOnly = false;
                ratetxt.ReadOnly = false;
                descrptxt.Text = "Return Without Work";
                hsntxt.Text = "";
                ratetxt.Text = "0";                
                descrptxt.ReadOnly = true;
                hsntxt.ReadOnly = true;
                ratetxt.ReadOnly = true;
                qntytxt.ReadOnly = true;
            }
        }
        private void delbtn_Click(object sender, EventArgs e)
        {
            try
            {
                bool prest = true;
                i = 0;
                int ind = dgvrecieveitm.SelectedRows[0].Index;
                cal(ind, -1);
                while (dgvloaditem.Rows.Count > i)
                {

                    if (dgvloaditem.Rows[i].Cells[0].Value.ToString() == dgvrecieveitm.Rows[ind].Cells[0].Value.ToString() && dgvloaditem.Rows[i].Cells[1].Value.ToString() == dgvrecieveitm.Rows[ind].Cells[8].Value.ToString())
                    {
                        dgvloaditem.Rows[i].Cells[4].Value = (Convert.ToDouble(dgvloaditem.Rows[i].Cells[4].Value) + Convert.ToDouble(dgvrecieveitm.Rows[ind].Cells[4].Value)).ToString();
                        prest = false;
                        dgvloaditem.Rows[i].Selected = true;
                    }
                    i++;
                }
                if (prest)
                {
                    List<string> field = new List<string> { TranDB.c_Job_Bill_D_T.f_bill_ID_fkey, TranDB.c_Job_Bill_D_T.f_item_no_fkey, TranDB.c_Job_Bill_D_T.f_job_fkey };
                    List<string> values = new List<string> { challancmb.Text, dgvrecieveitm.Rows[ind].Cells[0].Value.ToString(), dgvrecieveitm.Rows[ind].Cells[8].Value.ToString() };
                    string srate = Call.ret_data(Constant.TransDB,  lck.Rtname2, field, values, 5);
                    string samt = "0";
                    string sdescrpt = "";
                    string shsn = "";
                    if (dgvrecieveitm.Rows[ind].Cells[1].Value.ToString()!=Constant.NWR)
                    {
                        if (dgvrecieveitm.Rows[ind].Cells[1].Value.ToString().Substring(0, 3) != Constant.NEW)
                        {
                            sdescrpt = Call.set_detail(dgvrecieveitm.Rows[ind].Cells[1].Value.ToString(), Constant.Job)[0];
                            shsn = Call.set_detail(dgvrecieveitm.Rows[ind].Cells[1].Value.ToString(), Constant.Job)[1];
                        }
                    }
                    else
                    {
                        sdescrpt = "Return without work";
                        shsn = "";
                    }
                    try
                    {
                        samt = (Convert.ToDouble(dgvrecieveitm.Rows[ind].Cells[4].Value) * Convert.ToDouble(srate)).ToString();
                    }
                    catch (Exception)
                    {
                        samt = "0";
                    }
                    dgvloaditem.Rows.Add(dgvrecieveitm.Rows[ind].Cells[0].Value.ToString(), dgvrecieveitm.Rows[ind].Cells[8].Value.ToString(),sdescrpt , shsn, dgvrecieveitm.Rows[ind].Cells[4].Value.ToString(), srate, samt);
                    dgvloaditem.Rows[0].Selected = true;                    
                }
                spitData(dgvloaditem.SelectedRows[0].Index);
                dgvrecieveitm.Rows.RemoveAt(ind);               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (dgvrecieveitm.Rows.Count <1)
            {
                delbtn.Enabled = false;
            }            
        }
        private void previousitembtn_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos < 0)
            {
                pos++;
            }
            dump_dgvselection();
            dgvloaditem.Rows[pos].Selected = true;
            spitData(pos);
        }       
        private void nextitembtn_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos >= dgvloaditem.Rows.Count)
            {
                pos--;
            }
            dump_dgvselection();
            dgvloaditem.Rows[pos].Selected = true;
            spitData(pos);
        }
        private void dump_dgvselection()
        {
            i = 0;
            while (dgvloaditem.Rows.Count > i)
            {
                dgvloaditem.Rows[i].Selected = false;
                i++;
            }
        }
        private void Yesrdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (Yesrdbtn.Checked)
            {
                desgntxt.Show();
                desgntxt.ReadOnly = false;
                nordbtn.Checked = false;
            }
            else
            {
                desgntxt.Text = "Design No.";
                desgntxt.Hide();
            }
        }        
        private void nordbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (nordbtn.Checked)
            {
                desgntxt.Hide();
                Yesrdbtn.Checked = false;
            }
        }
        private bool check_condition()
        {
            bool chk = true;
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
                billidtxt.Text = (Convert.ToDouble(Fall.LBI(lck.tname1)) + 1).ToString();
                lck.InsertBT.Invoke(challancmb.Text, billidtxt.Text, date_.Text, Call.ret_id(CompanyDB.c_Company_T.f_Name, suppliertxt.Text, Constant.CompanyDB, CompanyDB.t_Company_T), txtpaymentterm.Text, "", "no agent", Call.GTD(Constant.User_id), cmbtransport.Text, "", txttransport_charge.Text, txtpackaging.Text);
                
                Ledger_Process.Ledger_Update(Call.GTD(Constant.Company_id), Call.ret_id("Name", suppliertxt.Text.ToString(), Constant.CompanyDB, CompanyDB.t_Company_T), date_.Text, "Debit", billidtxt.Text,  "Work Saree " + qntytxt.Text + " recieved @ discount " + discrattxt.Text + "%",lck.tname1,form_id.jreceivef_fid.ToString());
                Call.InsertTaxdb(lck.tname1, Call.IsRevrsChrge(lck.Sell, Call.ret_Gst(Call.ret_id(CompanyDB.c_Company_T.f_Name, suppliertxt.Text, Constant.CompanyDB, CompanyDB.t_Company_T), Constant.CompanyDB) != ""), lck.Sell, lck.callas != Constant.challan, Call.GTD(Constant.Company_id), Call.ret_id(CompanyDB.c_Company_T.f_Name, suppliertxt.Text, Constant.CompanyDB, CompanyDB.t_Company_T), date_.Text, billidtxt.Text, subttxt.Text);
                int n = 0;
                while (n < dgvrecieveitm.Rows.Count)
                {
                    Item ItmDts = new Item();
                    ItmDts.description = Call.ret_data(Constant.StockDB, StockDB.t_Item_T, StockDB.c_Item_T.f_stockId, dgvrecieveitm.Rows[n].Cells[0].Value.ToString(), StockDB.c_Item_T.f_description) + " " + dgvrecieveitm.Rows[n].Cells[2].Value.ToString();
                    ItmDts.hsn = dgvrecieveitm.Rows[n].Cells[3].Value.ToString();
                    ItmDts.date_ = date_.Text;
                    ItmDts.supplier_ID_fkey = Call.ret_data(Constant.CompanyDB, "Company_T", "name", suppliertxt.Text, 0, "int");
                    ItmDts.author_ID_fkey = emplbl.Text;
                    ItmDts.unit = " ";
                    ItmDts.stock_no= dgvrecieveitm.Rows[n].Cells[0].Value.ToString();
                    ItmDts.Item_no = dgvrecieveitm.Rows[n].Cells[1].Value.ToString();
                    ItmDts.rate = Convert.ToDouble(dgvrecieveitm.Rows[n].Cells[5].Value.ToString());
                    if (ItmDts.Item_no.Length > 3)
                    {
                        if (ItmDts.Item_no.Substring(0, 3) == Constant.NEW)
                        {
                            dgvrecieveitm.Rows[n].Cells[1].Value = ItmDts.Item_no = Call.add_new_work(ItmDts);
                        }
                    }
                    else
                    {
                        Call.save_rate(ItmDts, billidtxt.Text, Constant.Job);
                    }
                    if (ItmDts.Item_no != Constant.NWR)
                    {
                        ItmDts.supplier_ID_fkey += Constant.strbrk + Call.ret_data(Constant.StockDB, StockDB.t_Item_T, StockDB.c_Item_T.f_stockId, dgvrecieveitm.Rows[n].Cells[0].Value.ToString(), StockDB.c_Item_T.f_supplier_fkey);
                        ItmDts.rate = Call.ret_item_rate(dgvrecieveitm.Rows[n].Cells[0].Value.ToString()) + Convert.ToDouble(dgvrecieveitm.Rows[n].Cells[5].Value.ToString());
                        if (Fall.fill_ds("Select * from Job_T where stockId ='" + dgvrecieveitm.Rows[n].Cells[1].Value.ToString() + "'", Constant.StockDB).Rows[0][StockDB.c_Job_T.f_LedgerReq].ToString() == true.ToString())
                        {
                             ItmDts.Item_no =  dgvrecieveitm.Rows[n].Cells[0].Value.ToString() + dgvrecieveitm.Rows[n].Cells[1].Value.ToString();
                            if (!Call.ret_isRecord(StockDB.t_Item_T,Constant.StockDB,StockDB.c_Item_T.f_stockId,ItmDts.Item_no))
                            {
                                Call.add_new_item(ItmDts);
                            }
                            else
                            {
                                Call.save_rate(ItmDts, billidtxt.Text, Constant.Item);
                            }                       
                        }
                        else
                        {
                            ItmDts.Item_no = dgvrecieveitm.Rows[n].Cells[0].Value.ToString();
                            Call.save_rate(ItmDts, billidtxt.Text, Constant.Item);                            
                        }
                        Ledger_Process.Item_Update("Company_" + Call.GTD(Constant.Company_id), "Item_" + ItmDts.Item_no, "Credit", billidtxt.Text, lck.tname1, form_id.jreceivef_fid.ToString());
                    }
                    lck.InsertBDT.Invoke(dgvrecieveitm.Rows[n].Cells[1].Value.ToString(), billidtxt.Text, dgvrecieveitm.Rows[n].Cells[0].Value.ToString(), dgvrecieveitm.Rows[n].Cells[ratecol.Name].Value.ToString(), discrattxt.Text, dgvrecieveitm.Rows[n].Cells[qntycol.Name].Value.ToString(), "");

                    List<string> field, values;
                    field = new List<string> { TranDB.c_Job_Bill_D_T.f_bill_ID_fkey, TranDB.c_Job_Bill_D_T.f_item_no_fkey, TranDB.c_Job_Bill_D_T.f_job_fkey };
                    values = new List<string> { challancmb.Text, dgvrecieveitm.Rows[n].Cells[0].Value.ToString(), dgvrecieveitm.Rows[n].Cells[8].Value.ToString() };
                    string id = Call.ret_data(Constant.TransDB, lck.Rtname2, field, values, "Id", "int");
                    dgvrecieveitm.Rows[n].Cells[0].Value = ItmDts.Item_no;
                    string rcvd = (Convert.ToDouble(dgvrecieveitm.Rows[n].Cells[4].Value.ToString()) + Convert.ToDouble(Call.ret_data(Constant.TransDB, lck.Rtname2, field, values, TranDB.c_Job_Bill_D_T.f_recieved))).ToString();

                    qurry = "Update [" + lck.Rtname2 + "] SET [recieved]='" + rcvd;
                    if (Call.ret_data(Constant.TransDB, lck.Rtname2, field, values, 5) == "Not Declare")
                    {
                        qurry += "' , [rate] ='" + dgvrecieveitm.Rows[n].Cells[5].Value.ToString();
                    }
                    qurry += "' where Id= '" + id + "' ";
                    Fall.SaveDB(qurry);

                    n = n + 1;
                }
                NoEdit();
                workcmb.Enabled = false;
                cmbtransport.Enabled = false;
                loadbtn.Enabled = false;
                savebtn.Enabled = false;
                discardbtn.Enabled = false;
                recievedbtn.Enabled = false;
                delbtn.Enabled = false;
                nextitembtn.Enabled = false;
                previousitembtn.Enabled = false;
                Yesrdbtn.Enabled = false;
                nordbtn.Enabled = false;
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
            suppliertxt.Text = "0";
            dgvDelete();
            discrattxt.Text = "0";
            descrptxt.Text = "";
            hsntxt.Text = "";
            ratetxt.Text = "0";
            qntytxt.Text = "0";
            NoEdit();
            Ad_design.Hide();
            Yesrdbtn.Hide();
            nordbtn.Hide();
            challancmb.Enabled = true;
            challancmb.SelectedIndex = challancmb.Items.Count - 1;
            loadbtn.Enabled = true;
            recievedbtn.Enabled = false;
            delbtn.Enabled = false;            
        }
        private void Nextbtn_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos >= ds.Rows.Count)
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
        private void Nav(int pos)
        {
            Edit();
            billidtxt.Text = ds.Rows[i]["Id"].ToString();            
            date_.Text = ds.Rows[i][TranDB.c_JobRecieving_Bill_T.f_date_].ToString();
            suppliertxt.Text = Call.ret_Name(ds.Rows[i][TranDB.c_JobRecieving_Bill_T.f_beneficiary_fkey].ToString(), Constant.CompanyDB);
            cmbtransport.Text= Call.ret_Name(ds.Rows[i][TranDB.c_JobRecieving_Bill_T.f_transport].ToString(), Constant.CompanyDB);
            txtpackaging.Text = ds.Rows[i][TranDB.c_JobRecieving_Bill_T.f_packaging].ToString();
            txttransport_charge.Text = ds.Rows[i][TranDB.c_JobRecieving_Bill_T.f_transportation_charge].ToString();
            txtpaymentterm.Text = ds.Rows[i][TranDB.c_JobRecieving_Bill_T.f_payment_terms].ToString();
            dgvDelete();
            DataTable dst = new DataTable();
            dst = Fall.fill_ds(qurry);
            string stock = "0";
            i++;
            while (i < dst.Rows.Count)
            {
                string sitem = dst.Rows[i][TranDB.c_JobRecieving_Bill_D_T.f_item_no_fkey].ToString();
                string swork = dst.Rows[i][TranDB.c_JobRecieving_Bill_D_T.f_job_fkey].ToString();
                string sqnty = dst.Rows[i][TranDB.c_JobRecieving_Bill_D_T.f_qnty].ToString();
                string srate = dst.Rows[i][TranDB.c_JobRecieving_Bill_D_T.f_rate].ToString();
                string sdecpt = Call.set_detail(sitem, Constant.Job)[0];
                string shsn = Call.set_detail(sitem, Constant.Job)[1];
                discrattxt.Text = dst.Rows[i][TranDB.c_JobRecieving_Bill_D_T.f_discount_rate].ToString();
                double amt = Convert.ToDouble(sqnty) * Convert.ToDouble(srate);
                dgvrecieveitm.Rows.Add(sitem, swork, sdecpt, shsn, sqnty, srate, amt.ToString());
                cal(dgvrecieveitm.Rows.Count - 1, 1);
                string itno = dgvrecieveitm.Rows[dgvrecieveitm.Rows.Count - 1].Cells[0].Value.ToString();
                if (dgvrecieveitm.Rows[dgvrecieveitm.Rows.Count - 1].Cells[1].Value.ToString() != Constant.NWR)
                {
                    itno = itno.Substring(0, itno.Length - dgvrecieveitm.Rows[dgvrecieveitm.Rows.Count - 1].Cells[1].Value.ToString().Length);
                }
                stock = Convert.ToString(Convert.ToDouble(stock) + Convert.ToDouble(dgvrecieveitm.Rows[dgvrecieveitm.Rows.Count - 1].Cells[4].Value) * Call.ret_item_rate(itno) * 1);
                i++;
            }
            stockvaluetxt.Text = stock;
            NoEdit();
        }
        private void newbtn_Click(object sender, EventArgs e)
        {
            Edit();
            suppliertxt.Text = "";
            billidtxt.Text = Constant.Hash;           
            discrattxt.Text = "0";            
            descrptxt.Text = "";
            hsntxt.Text = "";
            ratetxt.Text = "0";
            qntytxt.Text = "0";
            dgvDelete();
            NoEdit();
            workcmb.Enabled = true;
            cmbtransport.Enabled = true;
            fillworkcombo();            
            newbtn.Hide();
            prntbtn.Hide();
            date_.Enabled = true;
            savebtn.Enabled = true;
            discardbtn.Enabled = true;
            loadbtn.Enabled = true;
            challancmb.Enabled = true;            
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
        private void prntbtn_Click(object sender, EventArgs e)
        {
            PrntCom fm = new PrntCom();
            fm.datetxt = date_;
            fm.invoidtxt = billidtxt;
            fm.grtottxt = grtottxt;
            fm.igsttxt = txtigst;
            fm.itemdtdgv = dgvrecieveitm;
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
    }
    public class JRFdt:CompanyFdt
    {
        public string tname1;
        public string tname2;
        public TranDB.insert_JobRecieving_Bill_T InsertBT;
        public TranDB.insert_JobRecieving_Bill_D_T InsertBDT;
        internal string Rtname1;
        internal string Rtname2;
    }
}
