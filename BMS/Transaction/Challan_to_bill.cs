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
    public partial class Challan_to_bill : nform
    {
        C2BillFdt lck = new C2BillFdt();
        public Challan_to_bill(C2BillFdt ck)
        {
            lck = ck;
            InitializeComponent();
            CheckCallMethod();
        }
        DataTable ds;
        void CheckCallMethod()
        {
            //No Control
            NoControl();
            //Code
            if (lck.mode == Constant.NEW)
            {
                lblhead.Text = lck.lblHead;
                lblauthor.Text = Call.Ret_UserName();
                date_.Enabled = true;
                savebtn.Show();
                discardbtn.Show();
                addbtn.Show();
                delbtn.Show();
                fillchallancmb("Select * from " + lck.Rtname1 + " where not isRegister <>'" +Constant.regd  + "'");           
                challancmbx.Enabled = true;
            }
            else if (lck.mode == Constant.VIEW)
            {
                Nextbtn.Show();
                previousbtn.Show();
                prntbtn.Show();
                ds = new DataTable();
                ds = Fall.fill_ds("select * from [" + lck.tname1 + "]");
                NavRec(0);
            }
            else if (lck.mode == Constant.EDIT)
            {
                //do setting
            }
        }
        private void fillPartytxt(string chlnid)
        {
            suppliertxt.Text = Call.ret_Name(Call.ret_data(Constant.TransDB,lck.Rtname1,"Id", chlnid,TranDB.c_Bill_T.f_beneficiary_fkey), Constant.CompanyDB);
        }
        void NoControl()
        {
            //Button
            previousbtn.Enabled = false;
            previousbtn.Hide();
            delbtn.Enabled = false;
            delbtn.Hide();
            prntbtn.Enabled = false;
            prntbtn.Hide();
            discardbtn.Enabled = false;
            discardbtn.Hide();
            savebtn.Enabled = false;
            savebtn.Hide();
            newbtn.Enabled = false;
            newbtn.Hide();
            Nextbtn.Enabled = false;
            Nextbtn.Hide();
            addbtn.Enabled = false;
            addbtn.Hide();
            //ComboBox
            transportcmb.Enabled = false;
            challancmbx.Enabled = false;
            //TextBox
            NoEdit();
        }
        void Edit()
        {
            ewaybilltxt.ReadOnly = false;
            paymenttermtxt.ReadOnly = false;
            packagingtxt.ReadOnly = false;
            transport_chargetxt.ReadOnly = false;
            billidtxt.ReadOnly = false;            
            tottxt.ReadOnly = false;
            subttxt.ReadOnly = false;
            grtottxt.ReadOnly = false;
            numofitmtxt.ReadOnly = false;
            pcstxt.ReadOnly = false;
            numwrdtxt.ReadOnly = false;
            itemdtdgv.ReadOnly = false;
            igsttxt.ReadOnly = false;
            ttaxtxt.ReadOnly = false;
            cgsttxt.ReadOnly = false;
            sgsttxt.ReadOnly = false;
            discratetxt.ReadOnly = false;
            qntytxt.ReadOnly = false;
            amttxt.ReadOnly = false;
            suppliertxt.ReadOnly = false;
            descriptxt.ReadOnly = false;
        }
        void NoEdit()
        {
            ewaybilltxt.ReadOnly = true;
            paymenttermtxt.ReadOnly = true;
            packagingtxt.ReadOnly = true;
            transport_chargetxt.ReadOnly = true;
            billidtxt.ReadOnly = true;
            tottxt.ReadOnly = true;
            subttxt.ReadOnly = true;
            grtottxt.ReadOnly = true;
            numofitmtxt.ReadOnly = true;
            pcstxt.ReadOnly = true;
            numwrdtxt.ReadOnly = true;
            igsttxt.ReadOnly = true;
            ttaxtxt.ReadOnly = true;
            cgsttxt.ReadOnly = true;
            sgsttxt.ReadOnly = true;
            discratetxt.ReadOnly = true;
            qntytxt.ReadOnly = true;
            amttxt.ReadOnly = true;
            suppliertxt.ReadOnly = true;
            descriptxt.ReadOnly = true;
        }
        private void NavRec(int i)
        {
            Edit();
            billidtxt.Text = ds.Rows[i][0].ToString();
            date_.Text = Call.format_date(Convert.ToDateTime(ds.Rows[i][1].ToString()));
            paymenttermtxt.Text = ds.Rows[i][0].ToString();
            suppliertxt.Text = Call.ret_Name(ds.Rows[i][2].ToString(), Constant.CompanyDB);
            paymenttermtxt.Text = ds.Rows[i][9].ToString();
            List<string> a, b;
            a = new List<string> { "Id" }; b = new List<string> { ds.Rows[i][5].ToString() };
            transportcmb.Text = Call.ret_data(Constant.CompanyDB, "Transport_T", a, b, 1);
            transport_chargetxt.Text = ds.Rows[i][7].ToString();
            packagingtxt.Text = ds.Rows[i][8].ToString();
            dgvDelete();
            string qurry = "select * from [" + Call.GTD(Constant.Company_id) + "Bill_D_T] where Bill_ID_fkey ='" + billidtxt.Text + "'";
            Call.ret_dt(qurry, Constant.TransDB);
            cal(itemdtdgv.Rows.Count - 1, 1);
            NoEdit();
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
        private void cal(int n, int sign)
        {
            Edit();

            numofitmtxt.Text = Convert.ToString(itemdtdgv.Rows.Count);
            pcstxt.Text = Convert.ToString(Convert.ToDouble(pcstxt.Text) + Convert.ToDouble(itemdtdgv.Rows[n].Cells[2].Value) * sign);
            subttxt.Text = Convert.ToString(Convert.ToDouble(subttxt.Text) + Convert.ToDouble(itemdtdgv.Rows[n].Cells[4].Value) * sign);
            subcal();
            NoEdit();
            ewaybilltxt = Fall.ewaybill(grtottxt.Text, ewaybilltxt);
        }
        private void subcal()
        {
            tottxt.Text = Convert.ToString(Convert.ToDouble(subttxt.Text));
            Cal_dt cdt = new Cal_dt();            
            cdt.amt = tottxt.Text;            
            cdt.f_id = Call.GTD(Constant.Company_id);
            cdt.f_db = Constant.CompanyDB;
            cdt.s_id = Call.ret_id("Name",suppliertxt.Text, Constant.CompanyDB, CompanyDB.t_Company_T);
            cdt.s_db = Constant.CompanyDB;
            GST gst = new GST();
            gst = Fall.ret_GST(cdt);
            cgsttxt.Text = gst.cgst;
            sgsttxt.Text = gst.sgst;
            igsttxt.Text = gst.igst;
            ttaxtxt.Text = gst.ttax;
            grtottxt.Text = Convert.ToString(Convert.ToDouble(tottxt.Text) + Convert.ToDouble(ttaxtxt.Text) + Convert.ToDouble(packagingtxt.Text) + Convert.ToDouble(transport_chargetxt.Text));
            numwrdtxt.Text = NumToWord.ConvertNumbertoWords(Convert.ToInt32(Convert.ToDouble(grtottxt.Text)));
        }
        private void challancmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            chalancmb();
        }
        private void fillchallancmb(string qurry)
        {
            DataTable dst = new DataTable();
            dst = Fall.fill_ds(qurry, Constant.TransDB);
            int i = 0;
            while (i < dst.Rows.Count)
            {
                challancmbx.Items.Add(dst.Rows[i]["Id"].ToString());
                i++;
            }
            challancmbx.Items.Add("Select");
            challancmbx.SelectedIndex = challancmbx.Items.Count - 1;
        }
        private void filltransportcmb(string qurry)
        {
            DataTable dst = new DataTable();
            dst = Fall.fill_ds(qurry, Constant.CompanyDB);
            int i = 0;
            while (i < dst.Rows.Count)
            {
                transportcmb.Items.Add(dst.Rows[i][CompanyDB.c_Company_T.f_Name].ToString());
                i++;
            }
            transportcmb.Items.Add("Select");
            transportcmb.SelectedIndex = transportcmb.Items.Count - 1;
        }
        private void chalancmb()
        {
            if (challancmbx.SelectedIndex != challancmbx.Items.Count-1 && challancmbx.Items.Count>1 && challancmbx.Enabled==true)
            {
                fillPartytxt(challancmbx.Text);
                string qurry = "Select * from [" + lck.Rtname2 + "] where "+TranDB.c_Bill_D_T.f_bill_ID_fkey+"='" + challancmbx.Text + "'";
                DataTable dst = new DataTable();
                dst = Fall.fill_ds(qurry, Constant.TransDB);
                Edit();
                int i = 0;
                double sqnty = 0, samt = 0;
                while (dst.Rows.Count > i)
                {
                    sqnty += Convert.ToDouble(dst.Rows[i][TranDB.c_Bill_D_T.f_qnty]);
                    samt += Convert.ToDouble(dst.Rows[i][TranDB.c_Bill_D_T.f_rate]) * sqnty;
                    i++;
                }
                descriptxt.Text = sqnty.ToString() + " Saree of " + i + " varity is Purchase againt Challan No." + challancmbx.Text;
                qntytxt.Text = sqnty.ToString();
                amttxt.Text = samt.ToString();
                discratetxt.Text = Call.ret_data(Constant.TransDB, lck.Rtname2 , "Id", challancmbx.Text,TranDB.c_Bill_D_T.f_discount_rate, "double")+"%";
                NoEdit();
                addbtn.Enabled = true;
            }
            else
            {
                descriptxt.Text = "";
                qntytxt.Text = "0";
                amttxt.Text = "0";
                discratetxt.Text = "0";
                addbtn.Enabled = false;
            }
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            Edit();
            itemdtdgv.Rows.Add(challancmbx.Text, suppliertxt.Text, qntytxt.Text, discratetxt.Text, amttxt.Text);
            NoEdit();
            cal(itemdtdgv.RowCount - 1, 1);
            packagingtxt.ReadOnly = false;
            transport_chargetxt.ReadOnly = false;
            transportcmb.Enabled = true;
            paymenttermtxt.ReadOnly = false;       
            delbtn.Enabled = true;
            addbtn.Enabled = false;
            savebtn.Enabled = true;
            discardbtn.Enabled = true;
            challancmbx.SelectedIndex = challancmbx.Items.Count - 1;
        }
        private void delbtn_Click(object sender, EventArgs e)
        {
            cal(itemdtdgv.SelectedRows[0].Index, -1);
            itemdtdgv.Rows.RemoveAt(itemdtdgv.SelectedRows[0].Index);
            if (itemdtdgv.Rows.Count<1)
            {
                packagingtxt.Text = "0";
                packagingtxt.ReadOnly = true;
                transport_chargetxt.Text = "0";
                transport_chargetxt.ReadOnly = true;
                transportcmb.SelectedIndex = transportcmb.Items.Count - 1;
                transportcmb.Enabled = false;
                paymenttermtxt.ReadOnly = true;
                delbtn.Enabled = false;
            }
            challancmbx.SelectedIndex = challancmbx.Items.Count - 1;
        }
        private void transportcmb_EnabledChanged(object sender, EventArgs e)
        {
            string qurry = "Select * from " + CompanyDB.t_Company_T + " where " + CompanyDB.c_Company_T.f_category + "='Transporter'";
            ds = Fall.fill_ds(qurry, Constant.CompanyDB);
            fillTransportcmb(ds);
        }
        private void fillTransportcmb(DataTable dst)
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
        private void packagingtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(packagingtxt.Text);
            }
            catch (Exception)
            {
                packagingtxt.Text = "0";
            }
            subcal();
        }
        private void transport_chargetxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(transport_chargetxt.Text);
            }
            catch (Exception)
            {
                transport_chargetxt.Text = "0";
            }
            subcal();
        }
        private void discardbtn_Click(object sender, EventArgs e)
        {
            dgvDelete();
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
                if (lck.Type!=Constant.Job)
                {
                    lck.InsertBT.Invoke("", date_.Text, Call.ret_id(CompanyDB.c_Company_T.f_Name, suppliertxt.Text, Constant.CompanyDB, CompanyDB.t_Company_T), paymenttermtxt.Text, "", "no agent", Call.GTD(Constant.User_id), Call.ret_id(CompanyDB.c_Company_T.f_Name, transportcmb.Text, Constant.CompanyDB, CompanyDB.t_Company_T), "", transport_chargetxt.Text, packagingtxt.Text);
                }
                else
                {
                    lck.InsertJBT.Invoke("", "", date_.Text, Call.ret_id(CompanyDB.c_Company_T.f_Name, suppliertxt.Text, Constant.CompanyDB, CompanyDB.t_Company_T), paymenttermtxt.Text, "", "no agent", Call.GTD(Constant.User_id), Call.ret_id(CompanyDB.c_Company_T.f_Name, transportcmb.Text, Constant.CompanyDB, CompanyDB.t_Company_T), "", transport_chargetxt.Text, packagingtxt.Text);
                }
                billidtxt.Text = Fall.LBI(lck.tname1);
                Ledger_Process.Ledger_Update(Call.GTD(Constant.Company_id), suppliertxt.Text, date_.ToString(), "Debit", billidtxt.Text, "Bill issued for challans on which gst is added of same amount",lck.tname1,form_id.challan_to_bill_fid.ToString());
                Call.InsertTaxdb(lck.tname1, Call.IsRevrsChrge(lck.Sell, Call.ret_Gst(Call.ret_id(CompanyDB.c_Company_T.f_Name, suppliertxt.Text, Constant.CompanyDB, CompanyDB.t_Company_T), Constant.CompanyDB) != ""), lck.Sell, lck.callas != Constant.challan, Call.GTD(Constant.Company_id), Call.ret_id(CompanyDB.c_Company_T.f_Name, suppliertxt.Text, Constant.CompanyDB, CompanyDB.t_Company_T), date_.Text, billidtxt.Text, subttxt.Text);
                int i = 0;
                while (itemdtdgv.Rows.Count > i)
                {
                    ds = Fall.fill_ds("Select * from "+lck.Rtname2+" where "+TranDB.c_Bill_D_T.f_bill_ID_fkey+"='"+ itemdtdgv.Rows[i].Cells["challancol"] + "'");
                    int n = 0;
                    while (ds.Rows.Count>n)
                    {
                        if (lck.Type != Constant.Job)
                        {
                            lck.InsertBDT.Invoke(billidtxt.Text, ds.Rows[n][TranDB.c_Bill_D_T.f_item_no_fkey].ToString(), ds.Rows[n][TranDB.c_Bill_D_T.f_rate].ToString(), ds.Rows[n][TranDB.c_Bill_D_T.f_discount_rate].ToString(), ds.Rows[n][TranDB.c_Bill_D_T.f_qnty].ToString(), itemdtdgv.Rows[i].Cells[0].Value.ToString());
                        }
                        else
                        {
                            lck.InsertJBDT(ds.Rows[n][TranDB.c_Job_Bill_D_T.f_recieved].ToString(), ds.Rows[n][TranDB.c_Job_Bill_D_T.f_job_fkey].ToString(), billidtxt.Text, ds.Rows[n][TranDB.c_Job_Bill_D_T.f_item_no_fkey].ToString(), ds.Rows[n][TranDB.c_Job_Bill_D_T.f_rate].ToString(), ds.Rows[n][TranDB.c_Job_Bill_D_T.f_discount_rate].ToString(), ds.Rows[n][TranDB.c_Job_Bill_D_T.f_qnty].ToString(), itemdtdgv.Rows[i].Cells[0].Value.ToString());
                        }
                        n++;
                    }
                    string qurry = "Update [" + lck.Rtname1 +"] SET [isRegister]='" + Constant.regd + "' where Id='" + itemdtdgv.Rows[i].Cells[0].Value.ToString() + "'";
                    Fall.SaveDB(qurry);
                    i++;
                }
                NoControl();
                savebtn.Show();
                discardbtn.Show();               
                newbtn.Show();
                newbtn.Enabled = true;
                prntbtn.Show();
                prntbtn.Enabled = true;

            }
        }
        private void newbtn_Click(object sender, EventArgs e)
        {           
            newbtn.Enabled = false;
            newbtn.Hide();
            prntbtn.Enabled = false;
            prntbtn.Hide();
            savebtn.Enabled = true;
            discardbtn.Enabled = true;
            dgvDelete();
            billidtxt.Enabled = true;
            billidtxt.Text = Constant.Hash;
            billidtxt.Enabled = false;
            challancmbx.Enabled = true;
            challancmbx.Text = "Select Variable";
            challancmbx.Enabled = false;
            chalancmb();
        }
    }
    public class C2BillFdt : CompanyFdt
    {
        public string tname1;
        public string tname2;
        public string Rtname1;
        public string Rtname2;
        public TranDB.insert_bill_T InsertBT;
        public TranDB.insert_bill_D_T InsertBDT;
        public TranDB.insert_Job_Bill_T InsertJBT;
        public TranDB.insert_Job_Bill_D_T InsertJBDT;
    }
}
