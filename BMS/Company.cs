using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BMS.DataSet1TableAdapters;

namespace BMS
{
    public partial class Company : nform 
    {
        CompanyFdt ck = new CompanyFdt();
        public string callby;
        public Company(CompanyFdt agr)
        {
            ck = agr;
            callby = agr.callby;
            InitializeComponent();
            CallCheck();
        }
        int pos = 0,i=0;
        DataTable ds = new DataTable();
        List<byte[]> pics = new List<byte[]> { };
        OpenFileDialog ofd = new OpenFileDialog();
        string qurry;
        void CallCheck()
        {
            foreach (Control item in Controls)
            {
                if (item is Button || item is CheckBox)
                {
                    item.Enabled = false;
                    item.Hide();
                }
                else if (!(item is TextBox) && !(item is Label))
                {
                    item.Enabled = false;
                }
            }
            NoEdit();
            image.Show();
            txtnewcat.Hide();           
            if (ck.mode==Constant.NEW)
            {
                //btnaddcontact.Show();
                //btnaddcontact.Enabled = true;
                btninsert.Show();
                btninsert.Enabled = true;
                btndelete.Show();
                btndelete.Enabled = true;
                Savebtn.Show();
                Savebtn.Enabled = true;
                Discardbtn.Show();
                Discardbtn.Enabled = true;
                cmbstate.Enabled = true;
                cmbstate.SelectedIndex = cmbstate.Items.Count - 1;               
                cmbcategory.Enabled = true;
                chbxnewcat.Show();
                chbxnewcat.Enabled = true;
                chbxnewcat.Checked = false;        
                qurry = "Select * from " + CompanyDB.t_Category_T + " WHERE(NOT(Category_T.Name = 'Company')) ";
                ds = Fall.fill_ds(qurry, Constant.CompanyDB);
                filcategorycmb(ds);
                if (ck.callby==Constant.AddCompany().callby)
                {
                    cmbcategory.Items.Add(ck.callby);
                    cmbcategory.Text = ck.callby;
                    cmbcategory.Enabled = false;
                    cmbnewtype.Show();
                    cmbnewtype.Enabled = true;
                    cmbnewtype.Items.Add(ck.Type);
                    cmbnewtype.Text = ck.Type;
                    cmbnewtype.Enabled = false;
                    chbxnewcat.Checked = false;
                    chbxnewcat.Enabled = false;
                }               
                Edit();        
            }
            else if(ck.mode == Constant.VIEW)
            {
                cmbstate.Enabled = true;
                qurry = "Select * from " + CompanyDB.t_Category_T;
                ds = Fall.fill_ds(qurry, Constant.CompanyDB);
                cmbstate.Enabled = true;
                filcategorycmb(ds);
                cmbnewtype.Show();
                cmbnewtype.Enabled = true;
                if (ck.callby == Constant.AddCompany().callby)
                {
                    cmbnewtype.Items.Add(ck.Type);
                }
                cmbnewtype.Text = ck.Type;
                cmbnewtype.Enabled = false;
                chbxgenerateLedger.Show();
                chbxgenerateLedger.Enabled = true;
                btnaddcontact.Show();
                btnaddcontact.Enabled = true;
                nextbtn.Show();
                nextbtn.Enabled = true;
                previousbtn.Show();
                previousbtn.Enabled = true;
                qurry = "Select * from " + CompanyDB.t_Company_T + " INNER JOIN Category_T ON Company_T.category = Category_T.Id WHERE(Category_T.Name = '" + ck.callby + "')" ;
                ds = Fall.fill_ds(qurry,Constant.CompanyDB);
                Nav(0);
            }
            else if (ck.mode == Constant.EDIT)
            {

            }
        }
        void filcategorycmb(DataTable dst)
        {
            cmbcategory.Items.Clear();
            int i = 0;
            while (i < dst.Rows.Count)
            {
                cmbcategory.Items.Add(dst.Rows[i][CompanyDB.c_Category_T.f_Name].ToString());
                i++;
            }
            if (ck.callby == Constant.AddCompany().callby)
            {
                cmbcategory.Items.Add(ck.callby);
            }
                cmbcategory.Items.Add("Select Item");
            cmbcategory.SelectedIndex = cmbcategory.Items.Count - 1;
        }
        void NoEdit()
        {
            txtgstin.ReadOnly = true;
            txtpincode.ReadOnly = true;
            txtdistrict.ReadOnly = true;
            txtcity.ReadOnly = true;
            txtaddress.ReadOnly = true;
            txtalias.ReadOnly = true;
            txtname.ReadOnly = true;
            txtnewcat.ReadOnly = true;
        }
        void Edit()
        {
            txtgstin.ReadOnly = false;
            txtpincode.ReadOnly = false;
            txtdistrict.ReadOnly = false;
            txtcity.ReadOnly = false;
            txtaddress.ReadOnly = false;
            txtalias.ReadOnly = false;
            txtname.ReadOnly = false;
            txtnewcat.ReadOnly = false;
        }
        private void btninsert_Click(object sender, EventArgs e)
        {
            ofd.Filter = "PNG File|*.png|JPEG File|*.jpeg|GIF File|*.gif|TIFF Files|*.tif|BMP File|*.bmp";
            ofd.FilterIndex = 1;            
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                image.ImageLocation = ofd.FileName;
                pics.Add(Fall.ret_imo(ofd.FileName));
                i++;
            }
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            i--;
            pics[i] = null;
            image.Image = null;

            if (pics.Count-1 > 0)
            {
                if (i==0)
                {
                    ImaNav(i + 1);
                }
                else if (i==pics.Count-1)
                {
                    ImaNav(i - 1);
                }
            }

            int m = 0;           
            List<byte[]> npics = new List<byte[]> { };
            while (m<pics.Count)
            {
                if (pics[m]!=null)
                {
                    npics.Add(pics[m]);
                }
                m++;
            }
            pics =npics;            
        }
        private void chbxnewcat_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxnewcat.Checked)
            {
                chbxgenerateLedger.Show();
                chbxgenerateLedger.Enabled = true;
                txtnewcat.Show();
                txtnewcat.Text = "New Category Name";
                cmbcategory.Enabled = false;
                cmbnewtype.Show();
                cmbnewtype.Enabled = true;
                cmbnewtype.SelectedIndex = cmbnewtype.Items.Count - 1;
            }
            else
            {
                chbxgenerateLedger.Hide();
                chbxgenerateLedger.Enabled = false;
                txtnewcat.Hide();
                txtnewcat.Text = "New Category Name";
                cmbcategory.Enabled = true;
                cmbnewtype.Hide();
                cmbnewtype.Enabled = false;
            }
        }
        private void btnaddcontact_Click(object sender, EventArgs e)
        {
            ContactFdt ck = new ContactFdt();
            ck.fkey = ds.Rows[pos][0].ToString();
            ck.holder_tbl = CompanyDB.t_Company_T;
            contactf ss = new contactf(ck);            
            ss.ShowDialog();
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (condition())
            {
                bool IsLedger = false;
                string catgy = "";
                if (chbxnewcat.Checked)
                {
                    Call.add_new_category(txtnewcat.Text, cmbnewtype.Text,chbxgenerateLedger.Checked.ToString(), Constant.CompanyDB);
                    catgy = Call.ret_id(CompanyDB.c_Category_T.f_Name, txtnewcat.Text, Constant.CompanyDB, CompanyDB.t_Category_T);                    
                    IsLedger = chbxgenerateLedger.Checked;
                }
                else
                {
                    catgy = Call.ret_id(CompanyDB.c_Category_T.f_Name, cmbcategory.Text, Constant.CompanyDB, CompanyDB.t_Category_T);
                    IsLedger = Convert.ToBoolean(Fall.fill_ds("Select * from " + CompanyDB.t_Category_T + " where " + CompanyDB.c_Category_T.f_Name + "='" + cmbcategory.Text + "'",Constant.CompanyDB).Rows[0][CompanyDB.c_Category_T.f_LedgerReq]);
                }
                qurry = "insert into " + CompanyDB.t_Company_T + " (" + CompanyDB.c_Company_T.f_RegdId + "," + CompanyDB.c_Company_T.f_Name + "," + CompanyDB.c_Company_T.f_Alias + "," + CompanyDB.c_Company_T.f_GSTIN + "," + CompanyDB.c_Company_T.f_date_ + "," + CompanyDB.c_Company_T.f_category + "," + CompanyDB.c_Company_T.f_author + ") values('" + ck.callby + "','" + Call.formatQuote(txtname.Text) + "','" + txtalias.Text + "','" + txtgstin.Text + "','" + DateTime.Today.ToString() + "','" + catgy + "','" + Call.GTD(Constant.User_id) + "')";
                Fall.SaveDB(qurry, Constant.CompanyDB);

                if (IsLedger)
                {
                    Ledger_Process.New_Ledger("Company_" + Fall.LRI(CompanyDB.t_Company_T, Constant.CompanyDB), "Company");
                }
                qurry = "insert into " + CompanyDB.t_Address_T + "(" + CompanyDB.c_Address_T.f_addri_fkey + "," + CompanyDB.c_Address_T.f_addr_table + "," + CompanyDB.c_Address_T.f_address + "," + CompanyDB.c_Address_T.f_city + "," + CompanyDB.c_Address_T.f_district + "," + CompanyDB.c_Address_T.f_state + "," + CompanyDB.c_Address_T.f_pincode + ") values('" + Fall.LRI(CompanyDB.t_Company_T, Constant.CompanyDB) + "','" + CompanyDB.t_Company_T + "','" + txtaddress.Text + "','" + txtcity.Text + "','" + txtdistrict.Text + "','" + cmbstate.Text + "','" + txtpincode.Text + "')";
                Fall.SaveDB(qurry, Constant.CompanyDB);
                i = 0;
                while (i < pics.Count)
                {
                    qurry = "insert into " + CompanyDB.t_Image_T + "(" + CompanyDB.c_Image_T.f_object_fkey + "," + CompanyDB.c_Image_T.f_object_table + "," + CompanyDB.c_Image_T.f_image + "," + CompanyDB.c_Image_T.f_description + ") values('" + Fall.LRI(CompanyDB.t_Company_T, Constant.CompanyDB) + "','" + CompanyDB.t_Company_T + "',@img,'" + txtname.Text + i + "')";                    
                    Fall.SaveDB(qurry, pics[i], Constant.CompanyDB);
                    i++;
                }

                if (ck.callby==Constant.AddCompany().callby)
                {
                    Call.RSD(Constant.Company_id, Fall.LRI(CompanyDB.t_Company_T, Constant.CompanyDB));
                    Call.RSD(Constant.Catrgory, Call.ret_data(Constant.CompanyDB, CompanyDB.t_Company_T, "Id", Call.GTD(Constant.Company_id), CompanyDB.c_Company_T.f_category));
                    dbo_Process.NewCompanyDB(Call.GTD(Constant.Company_id));
                }
                NoEdit();               
                foreach (Control item in Controls)
                {
                    if (!(item is TextBox) && !(item is Label))
                    {
                        item.Enabled = false;
                    }
                }
                newbtn.Enabled = true;
                newbtn.Show();
                adbankdtbtn.Enabled = true;
                adbankdtbtn.Show();
            }
            else
            {
                MessageBox.Show("Fill properly required info");
            }
        }
        private bool condition()
        {
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    if (item.Name!=txtgstin.Name && item.Name!=txtalias.Name)
                    {
                        TextBox tb = new TextBox();
                        tb = (TextBox)item;
                        if (tb.Text == null) return false;
                    }
                }               
            }
            if (cmbcategory.SelectedIndex==cmbcategory.Items.Count-1 && chbxnewcat.Checked==false)
            {
                return false;
            }
            if (cmbstate.SelectedIndex == cmbstate.Items.Count - 1)
            {
                return false;
            }
            if (cmbnewtype.SelectedIndex == cmbnewtype.Items.Count - 1 && cmbnewtype.Text!="Main")
            {
                return false;
            }
            return true;
        }
        private void Discardbtn_Click(object sender, EventArgs e)
        {
            image.Enabled = true;
            image.Image = null;
            image.Enabled = false;
            pics = new List<byte[]> { };
            i = 0;
            while (i<pics.Count)
            {
                pics[i] = null;
                i++;
            }            
            txtname.Clear();
            txtalias.Clear();
            txtaddress.Clear();
            txtcity.Clear();
            txtdistrict.Clear();
            txtpincode.Clear();
            txtgstin.Clear();            
            cmbstate.SelectedIndex = cmbstate.Items.Count - 1;
            if (ck.callby!=Constant.AddCompany().callby)
            {
                cmbcategory.SelectedIndex = cmbcategory.Items.Count - 1;
            }

        }
        private void newbtn_Click(object sender, EventArgs e)
        {
            image.Enabled = true;
            image.Image = null;
            image.Enabled = false;
            pics = new List<byte[]> { };
            i = 0;
            while (i < pics.Count)
            {
                pics[i] = null;
                i++;
            }
            Edit();
            txtname.Clear();
            txtalias.Clear();
            txtaddress.Clear();
            txtcity.Clear();
            txtdistrict.Clear();
            txtpincode.Clear();
            txtgstin.Clear();
            cmbstate.Enabled = true;
            cmbstate.SelectedIndex = cmbstate.Items.Count - 1;
            if (ck.callby!=Constant.AddCompany().callby)
            {
                cmbcategory.Enabled = true;
                chbxnewcat.Enabled = true;
                chbxnewcat.Checked = false;
                qurry = "Select * from " + CompanyDB.t_Category_T + " WHERE(NOT(Category_T.Name = 'Company')) ";
                ds = Fall.fill_ds(qurry, Constant.CompanyDB);
                filcategorycmb(ds);
            }            
            newbtn.Enabled = false;
            newbtn.Hide();
            adbankdtbtn.Enabled = false;
            adbankdtbtn.Hide();
            //btnaddcontact.Enabled = true;
            //btnaddcontact.Show();
            btninsert.Enabled = true ;
            btndelete.Enabled = true ;
            Savebtn.Enabled = true;
            Discardbtn.Enabled = true;
        }
        void Nav(int n)
        {
            if (ds.Rows.Count > 0)
            {
                adbankdtbtn.Enabled = true;
                adbankdtbtn.Show();
                Edit();
                txtname.Text = ds.Rows[n][CompanyDB.c_Company_T.f_Name].ToString();
                txtalias.Text = ds.Rows[n][CompanyDB.c_Company_T.f_Alias].ToString();
                txtgstin.Text = ds.Rows[n][CompanyDB.c_Company_T.f_GSTIN].ToString();
                cmbcategory.Enabled = true;
                cmbcategory.Text = Call.ret_Name(ds.Rows[n][CompanyDB.c_Company_T.f_category].ToString(), Constant.CompanyDB, CompanyDB.t_Category_T); cmbcategory.Enabled = true;
                cmbcategory.Enabled = false;
                cmbnewtype.Enabled = false;
                cmbnewtype.Text = Call.ret_data(Constant.CompanyDB, CompanyDB.t_Category_T, "Id", ds.Rows[n][CompanyDB.c_Company_T.f_category].ToString(), CompanyDB.c_Category_T.f_sub);
                cmbnewtype.Enabled = false;
                chbxgenerateLedger.Enabled = true;
                chbxgenerateLedger.Checked= Convert.ToBoolean(ds.Rows[n][CompanyDB.c_Category_T.f_LedgerReq].ToString());
                chbxgenerateLedger.Enabled = false;
                DataTable dst = new DataTable();
                qurry = "Select * from " + CompanyDB.t_Address_T + " where " + CompanyDB.c_Address_T.f_addri_fkey + " = '" + ds.Rows[n]["Id"].ToString() + "' and " + CompanyDB.c_Address_T.f_addr_table + " = '" + CompanyDB.t_Company_T + "'";
                dst = Fall.fill_ds(qurry, Constant.CompanyDB);
                i = 0;
                while (dst.Rows.Count > i)
                {
                    txtaddress.Text = dst.Rows[i][CompanyDB.c_Address_T.f_address].ToString();
                    txtcity.Text = dst.Rows[i][CompanyDB.c_Address_T.f_city].ToString();
                    txtdistrict.Text = dst.Rows[i][CompanyDB.c_Address_T.f_district].ToString();
                    cmbstate.Enabled = true;
                    cmbstate.Text = dst.Rows[i][CompanyDB.c_Address_T.f_state].ToString();
                    cmbstate.Enabled = false;
                    txtpincode.Text = dst.Rows[i][CompanyDB.c_Address_T.f_pincode].ToString();
                    i++;
                }
                qurry = "Select * from " + CompanyDB.t_Image_T + " where " + CompanyDB.c_Image_T.f_object_fkey + "='" + ds.Rows[n]["Id"].ToString() + "' and " + CompanyDB.c_Image_T.f_object_table + "='" + CompanyDB.t_Company_T + "'";
                dst = Fall.fill_ds(qurry, Constant.CompanyDB);
                try
                {
                    image.Enabled = true;
                    MemoryStream fs = new MemoryStream((byte[])dst.Rows[0][CompanyDB.c_Image_T.f_image]);
                    image.Image = System.Drawing.Image.FromStream(fs);
                    image.Enabled = false;
                }
                catch (Exception)
                {
                    image.Image = null;
                }
                NoEdit();   
            }
        }
        void ImaNav(int n)
        {  
            if (pics[n]!=null)
            {
                try
                {
                    image.Enabled = true;
                    MemoryStream fs = new MemoryStream(pics[n]);
                    image.Image = System.Drawing.Image.FromStream(fs);
                    image.Enabled = false;
                }
                catch (Exception)
                {

                }
            }
            else
            {
                image.Image = null;
            }
        }
        private void nextbtn_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos>ds.Rows.Count-1)
            {
                pos--;
            }
            Nav(pos);
        }
        private void cmbcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcategory.SelectedIndex!=cmbcategory.Items.Count-1)
            {
                cmbnewtype.Enabled = true;
                cmbnewtype.Text = Call.ret_data(Constant.CompanyDB, CompanyDB.t_Category_T, CompanyDB.c_Category_T.f_Name, cmbcategory.Text, CompanyDB.c_Category_T.f_sub);
                cmbnewtype.Enabled = false;
            }
        }

        private void adbankdtbtn_Click(object sender, EventArgs e)
        {
            bankdtFdt dt = new bankdtFdt();
            dt.holder_id = Call.ret_id(CompanyDB.c_Company_T.f_Name, txtname.Text, Constant.CompanyDB, CompanyDB.t_Company_T);
            dt.holder_tname = CompanyDB.t_Company_T;
            bankdt ss = new bankdt(dt);
            ss.ShowDialog();
        }

        private void previousbtn_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos <0)
            {
                pos++;
            }
            Nav(pos);
        }
    }
    public class CompanyFdt
    {
        /// <summary>
        /// Take Category of party callng
        /// </summary>
        public string callby;
        /// <summary>
        /// Take Value as Bill or Challan
        /// </summary>
        public string callas;
        /// <summary>
        /// Take Value as Item, Work, Service
        /// </summary>
        public string Type;
        /// <summary>
        /// Take true or false
        /// </summary>
        public bool Sell;
        /// <summary>
        /// Take Value for Label Head eg:Tax Invoice.
        /// </summary>
        public string lblHead;
        /// <summary>
        /// Take Value as 'New', 'View' or 'Edit' to release the controls accordingly.
        /// </summary>
        public string mode;

        //public CompanyDB. InsertBT;
        //public CompanyDB.insert_bill_D_T InsertBDT;
    }
}
