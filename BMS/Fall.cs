using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using System.IO;


namespace BMS
{
    class Fall
    {
        public static ComboBox fillcombo(combo ds, string caption = "Select Variable")
        {
            ComboBox combo = new ComboBox();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[ds.database].ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(ds.qurry, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dataDB = new DataTable();
            try
            {
                sda.Fill(dataDB);
                combo.ValueMember = ds.valueMember;
                combo.DisplayMember = ds.displayMember;
                int dt = dataDB.Columns.IndexOf(ds.displayMember);
                combo.DataSource = dataDB;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            combo.Text = caption;
            return combo;
        }
        /// <summary>
        ///  Retrun last record ID.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string LBI(string table, string  rname="billno", string db = "TransDB",int callbillno=0)
        {

            string qurry = "Select * from [" + table + "]";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[db].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            int invo_no = 0;
            try
            {
                DataTable dataDB = new DataTable();
                dataDB = Fall.fill_ds(qurry);
                int i = 0;
                if (dataDB.Rows.Count<1)
                {
                    invo_no = callbillno;
                }
                while (dataDB.Rows.Count>i)
                {
                    invo_no = Convert.ToInt32(dataDB.Rows[i][rname].ToString());
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return invo_no.ToString();            
        }
        public static string LRI(string table, string db = "TranxDB")
        {

            string qurry = "Select * from [" + table + "]";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[db].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            int invo_no = 0;
            try
            {
                SqlDataReader dataDB;
                dataDB = cmd.ExecuteReader();
                while (dataDB.Read())
                {
                    invo_no = dataDB.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return invo_no.ToString();
        }
        public static DataTable fill_ds(string qurry, string database = "TransDB")
        {
            
            DataTable ds = new DataTable();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[database].ConnectionString);
            con.Open();
            
            SqlCommand cmd = new SqlCommand(qurry, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            con.Close();
            return ds;
        }
        public static GST ret_GST(Cal_dt cdt)
        {
            GST Gst = new GST();

            if (Call.ret_State(cdt.f_id, cdt.f_db) != Call.ret_State(cdt.s_id, cdt.s_db))
            {
                Gst.igst = Convert.ToString(Math.Round(Convert.ToDouble(cdt.amt) * 0.05,2));
                Gst.ttax = Gst.igst;
            }
            else if (Call.ret_State(cdt.f_id, cdt.f_db) == Call.ret_State(cdt.s_id, cdt.s_db))
            {
                Gst.cgst = Convert.ToString(Math.Round(Convert.ToDouble(cdt.amt) * 0.025,2));
                Gst.sgst = Convert.ToString(Math.Round(Convert.ToDouble(cdt.amt) * 0.025, 2));
                Gst.ttax = Convert.ToString(Convert.ToDouble(Gst.cgst) + Convert.ToDouble(Gst.sgst));
            }
            return Gst;
        }
        public static bool SaveDB(string qurry, string db = "TransDB")
        {
            bool state = true;
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[db].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                state = false;
            }
            con.Close();
            return state;
        }
        /// <summary>
        /// Parameter must be @img
        /// </summary>
        /// <param name="qurry"></param>
        /// <param name="img"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool SaveDB(string qurry, byte[] img, string db = "TransDB")
        {
            bool state = true;
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[db].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.AddWithValue("@img", img);
            bool rt = SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool SaveDB(SqlCommand cmd)
        {
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static void Updateitem(Item it)
        {
            string qurry = "UPDATE [Item_T] SET HSN ='"+it.hsn+ "', date_ ='" + it.date_ + "', Name ='" + it.name + "', description ='" + it.description + "', category ='" + it.category + "', supplier_fkey ='" + it.supplier_ID_fkey + "', author ='" + it.author_ID_fkey + "', Unit ='" + it.unit + "',LedgerReq ='" + it.ledgerReq + "' WHERE(stockId = '" + it.Item_no+"')";
            SaveDB(qurry, Constant.StockDB);
            if (it.rate>0)
            {
                Call.save_rate(it, "New", Constant.Item);
            }
        }
        public static void Updatejob(job_item it,string rt)
        {
            string qurry = "UPDATE  Job_T SET  Gen_New_No ='" + it.Gen_New_No + "', stockId ='" + it.stockId + "', SAC ='" + it.SAC + "', date_ ='" + it.date_ + "', Name ='" + it.Name + "', description ='" + it.description + "', category ='" + it.category + "', supplier_fkey ='" + it.supplier_fkey + "', author ='" + it.author + "', Unit ='" + it.Unit + "', LedgerReq ='" + it.LedgerReq + "' WHERE(stockId = '" + it.stockId + "')";
            SaveDB(qurry, Constant.StockDB);
            //if (rt > 0)
            //{
            //    Call.save_rate(rt, "New", Constant.Service);
            //}
        }
        
        public static List<string> fill_ListDB(string qurry, string database, string dfault = "Select Variable")
        {
            List<string> lst = new List<string> { };
            try
            {
                DataTable dt = new DataTable();
                dt = Fall.fill_ds(qurry, database);

                int i = 0;
                while (dt.Rows.Count > i)
                {
                    lst.Add(dt.Rows[i][0].ToString());
                    i++;
                }
                lst.Add(dfault);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return lst;
        }
        public static bool IsObj(string t_name, string db)
        {
            bool status = false;
            string querry = "select table_name from information_schema.tables where table_type='base table' And table_name='" + t_name + "'";
            if (Fall.fill_ds(querry, db).Rows.Count > 0)
            {
                status = true;
            }
            return status;
        }
        //public static List<string> Ret_GRT1T2(BillFdt lck)
        //{
        //    List<string> tt = new List<string> { };
        //    if (lck.mode == Constant.NEW)
        //    {
        //        if (lck.Sell && lck.callas != Constant.challan)
        //        {
        //            if (lck.Type != Constant.Job)
        //            {
        //                tt.Add(TranDB.t_Sell_Bill_T);
        //                tt.Add(TranDB.t_Sell_Bill_D_T);
        //            }
        //            else
        //            {
        //                tt.Add(TranDB.t_Sell_Job_Bill_T);
        //                tt.Add(TranDB.t_Sell_Job_Bill_D_T);
        //            }
        //        }
        //        else if (lck.Sell && lck.callas == Constant.challan)
        //        {
        //            if (lck.Type != Constant.Job)
        //            {
        //                tt.Add(TranDB.t_Sell_Challan_T);
        //                tt.Add(TranDB.t_Sell_Challan_D_T);
        //            }
        //            else
        //            {
        //                tt.Add(TranDB.t_Sell_Job_Challan_T);
        //                tt.Add(TranDB.t_Sell_Job_Challan_D_T);
        //            }
        //        }
        //        if (!lck.Sell && lck.callas != Constant.challan)
        //        {
        //            if (lck.Type != Constant.Job)
        //            {
        //                tt.Add(TranDB.t_Purchase_Bill_T);
        //                tt.Add(TranDB.t_Purchase_Bill_D_T);
        //            }
        //            else
        //            {
        //                tt.Add(TranDB.t_Purchase_Job_Bill_T);
        //                tt.Add(TranDB.t_Purchase_Job_Bill_D_T);
        //            }
        //        }
        //        else if (!lck.Sell && lck.callas == Constant.challan)
        //        {
        //            if (lck.Type != Constant.Job)
        //            {
        //                tt.Add(TranDB.t_Purchase_Challan_T);
        //                tt.Add(TranDB.t_Purchase_Challan_D_T);
        //            }
        //            else
        //            {
        //                tt.Add(TranDB.t_Purchase_Job_Challan_T);
        //                tt.Add(TranDB.t_Purchase_Job_Challan_D_T);
        //            }
        //        }
        //    }
        //    return tt;
        //}
        public static byte[] ret_imo(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            return br.ReadBytes((int)fs.Length);
        }
        public static TextBox ewaybill(string num,TextBox tb)
        {
            if (Convert.ToDouble(num) > 50000)
            {                
                tb.ReadOnly = false;
            }          
            return tb;
        }
        static PrntCom fm = new PrntCom();
        static PrntDocType pdt = new PrntDocType();
        public static void PrintBill(PrntCom fms, PrntDocType doctype)
        {
            fm = fms;
            pdt = doctype;
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printBillDocument_PrintPage);
            PrintPreviewDialog printpdlg = new PrintPreviewDialog();
            printpdlg.Document = printDoc;
            printpdlg.ShowDialog();
        }
        private static void printBillDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float size = 10;
            int x = 40, y = 30;
            int tempy = 0;
            Font plain_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Regular);
            Font bold_font = new Font(FontFamily.GenericSansSerif, size, FontStyle.Bold);

            StringFormat formatLeft = new StringFormat(StringFormatFlags.NoClip);
            StringFormat formatCenter = new StringFormat(formatLeft);
            StringFormat formatRight = new StringFormat(formatLeft);

            formatCenter.Alignment = StringAlignment.Center;
            formatRight.Alignment = StringAlignment.Far;
            formatLeft.Alignment = StringAlignment.Near;
            //print first party gst            
            inkText(pdt.head_label, x, y, 750, 20, bold_font, formatCenter, e);
            //print first party gst            
            y += 20;
            inkText("GST No." + Call.ret_Gst(Call.GTD(Constant.Company_id), Constant.CompanyDB), x, y, 750, 20, bold_font, formatCenter,e);

            PointF pth = new PointF(x, y);
            //print first party phone
            x = 40; /*y += 20;*/ size = 10;
            pth = new PointF(x, y);           
            e.Graphics.DrawString("Mob:" + Call.ret_phone(Call.GTD(Constant.Company_id), CompanyDB.t_Company_T, Constant.CompanyDB), plain_font, Brushes.Black, pth, formatLeft);
            //print first party name
            x = 250; y += 10; size = 25;
            bold_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Bold);
            pth = new PointF(x, y);
            e.Graphics.DrawString(Call.ret_Name(Call.GTD(Constant.Company_id), Constant.CompanyDB).ToString(), bold_font, Brushes.Black, pth);
            //print first party address
            x = 150; y += 35; size = 10;
            bold_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Bold);
            pth = new PointF(x, y);
            e.Graphics.DrawString(Call.ret_Address(Call.GTD(Constant.Company_id), Constant.CompanyDB) + ","+ Call.ret_City(Call.GTD(Constant.Company_id), Constant.CompanyDB)+","+ Call.ret_State(Call.GTD(Constant.Company_id), Constant.CompanyDB)+"-"+ Call.ret_Pincode(Call.GTD(Constant.Company_id), Constant.CompanyDB), bold_font, Brushes.Black, pth);

            x = 40; tempy = y += 20; size = 2;
            int wd = 550, ht = 100;
            Pen pen = new Pen(Brushes.Black, size);
            Rectangle rect = new Rectangle(x, y, wd, ht);
            e.Graphics.DrawRectangle(pen, rect);

            //print second party name
            string sp_id = Call.ret_data(pdt.doc_db, pdt.doc_tname, "billno", fm.invoidtxt.Text, TranDB.c_Bill_T.f_beneficiary_fkey).ToString();
            x = 40; y = y += 0; size = 15;
            bold_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Bold);
            pth = new PointF(x, y);
            SizeF layoutsize = new SizeF(wd, ht);
            RectangleF layout = new RectangleF(pth, layoutsize);
            e.Graphics.DrawString(Call.ret_Name(sp_id,Constant.CompanyDB,CompanyDB.t_Company_T), bold_font, Brushes.Black, layout, formatRight);
            e.Graphics.DrawString("M/s:", plain_font, Brushes.Black, layout, formatLeft);
            //print second party Alias
            x = 40; y += 20; size = 10;
            plain_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Regular);
            pth = new PointF(x, y);
            layoutsize = new SizeF(wd, ht);
            layout = new RectangleF(pth, layoutsize);
            e.Graphics.DrawString(Call.ret_Alias(sp_id, Constant.CompanyDB), plain_font, Brushes.Black, layout, formatRight);
            //print second party address
            x = 40; y += 20; size = 10;
            pth = new PointF(x, y);
            layoutsize = new SizeF(wd, ht);
            layout = new RectangleF(pth, layoutsize);
            e.Graphics.DrawString(Call.ret_Address(sp_id, Constant.CompanyDB), plain_font, Brushes.Black, layout, formatRight);
            //print second party city
            x = 40; y += 20; size = 10;
            pth = new PointF(x, y);
            layoutsize = new SizeF(wd, ht);
            layout = new RectangleF(pth, layoutsize);
            e.Graphics.DrawString(Call.ret_City(sp_id, Constant.CompanyDB), plain_font, Brushes.Black, layout, formatRight);
            //print second party phone
            x = 40; /*y += 20;*/ size = 10;
            pth = new PointF(x, y);
            layoutsize = new SizeF(wd, ht);
            layout = new RectangleF(pth, layoutsize);            
            e.Graphics.DrawString("Mob:"+Call.ret_phone(sp_id,CompanyDB.t_Company_T ,Constant.CompanyDB), plain_font, Brushes.Black, layout, formatLeft);
            //print second party state & pincode
            x = 40; y += 20; size = 10;
            pth = new PointF(x, y);
            layoutsize = new SizeF(wd, ht);
            layout = new RectangleF(pth, layoutsize);
            string sp = Call.ret_State(sp_id, Constant.CompanyDB) + "-" + Call.ret_Pincode(sp_id, Constant.CompanyDB);
            e.Graphics.DrawString(sp, plain_font, Brushes.Black, layout, formatRight);
            //print second party gst
            e.Graphics.DrawString("GSTIN :" + Call.ret_Gst(sp_id, Constant.CompanyDB), plain_font, Brushes.Black, layout, formatLeft);

            x = 40 + wd + 20; tempy += 0; size = 2;
            wd = 180; ht = 40;
            pen = new Pen(Brushes.Black, size);
            rect = new Rectangle(x, tempy, wd, ht);
            e.Graphics.DrawRectangle(pen, rect);
            //print date
            size = 10; tempy = tempy += 5;
            pth = new PointF(x, tempy);
            layoutsize = new SizeF(wd, ht);
            layout = new RectangleF(pth, layoutsize);
            bold_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Bold);
            plain_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Regular);
            e.Graphics.DrawString("Date :", plain_font, Brushes.Black, layout, formatLeft);
            e.Graphics.DrawString(fm.datetxt.Text, bold_font, Brushes.Black, layout, formatRight);
            //print invoice no.
            tempy += 20;
            pth = new PointF(x, tempy);
            layoutsize = new SizeF(wd, ht);
            layout = new RectangleF(pth, layoutsize);
            e.Graphics.DrawString("Invo No.: ", plain_font, Brushes.Black, layout, formatLeft);
            e.Graphics.DrawString(fm.invoidtxt.Text, bold_font, Brushes.Black, layout, formatRight);

            //print eway bill no.
            x = 40; y += 40;
            wd = 750; ht = 20; size = 20;
            pth = new PointF(x, y);
            layoutsize = new SizeF(wd, ht);
            layout = new RectangleF(pth, layoutsize);
            if (Convert.ToDouble(fm.grtottxt.Text) > 50000)
            {
                e.Graphics.DrawString("Eway Bill :" + fm.ewaybilltxt.Text, bold_font, Brushes.Black, layout, formatCenter);
            }

            //print detail table
            x = 40; y += 40; size = 2;
            wd = 750; ht = 20;
            pen = new Pen(Brushes.Black, size);
            rect = new Rectangle(x, y, wd, ht);
            e.Graphics.FillRectangle(Brushes.LightGray, rect);
            e.Graphics.DrawRectangle(pen, rect);

            int i = 0;
            int chk = 1;
            layout.Y += 20;
            while (i <= 20)
            {
                layout.Y += 20;
                rect = new Rectangle(Convert.ToInt32(layout.X), Convert.ToInt32(layout.Y), Convert.ToInt32(layout.Width), Convert.ToInt32(layout.Height));
                if (chk == 1)
                {
                    e.Graphics.FillRectangle(Brushes.LightGray, rect);
                }
                chk *= -1;
                i++;
            }       
            
            size = 8;
            bold_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Bold);
            i = 0;
            int mrgn = 0;
            while (i < fm.itemdtdgv.ColumnCount)
            {
                double colwd = fm.itemdtdgv.Columns[i].Width;
                double tabwd = fm.itemdtdgv.Width;
                mrgn += (int)(709 * colwd / tabwd);
                i++;
            }
            mrgn = 709 - mrgn;
            x = 40; y += 0; size = 2;
            wd = 41+mrgn; ht = 420;
            pen = new Pen(Brushes.Black, size);
            rect = new Rectangle(x, y, wd, ht);
            e.Graphics.DrawRectangle(pen, rect);
            pth = new PointF(x, y + 5);
            layoutsize = new SizeF(wd, 20);
            RectangleF Serial_layout = new RectangleF(pth, layoutsize);
            e.Graphics.DrawString("S No.", bold_font, Brushes.Black, Serial_layout, formatCenter);
            i = 0;
            while (i < fm.itemdtdgv.ColumnCount)
            {
                double colwd = fm.itemdtdgv.Columns[i].Width;
                double tabwd = fm.itemdtdgv.Width;
                x += wd;
                wd =(int)(709 * colwd/tabwd);
                rect = new Rectangle(x, y, wd, ht);
                e.Graphics.DrawRectangle(pen, rect);
                pth = new PointF(x, y+5);
                layoutsize = new SizeF(wd, 20);
                RectangleF dgvlayout = new RectangleF(pth, layoutsize);
                if (fm.itemdtdgv.Columns[i].HeaderText=="HSN Code")
                {
                    e.Graphics.DrawString("HSN", bold_font, Brushes.Black, dgvlayout, formatCenter);
                }
                else if (fm.itemdtdgv.Columns[i].HeaderText == "Quantity")
                {
                    e.Graphics.DrawString("Qnty", bold_font, Brushes.Black, dgvlayout, formatCenter);
                }
                else
                {
                    e.Graphics.DrawString(fm.itemdtdgv.Columns[i].HeaderText, bold_font, Brushes.Black, dgvlayout, formatCenter);
                }
                i++;
            }
            i = 0;
            while (i < fm.itemdtdgv.RowCount)
            {
                x = 40; y += 20;
                wd = 41 + mrgn;ht = 20;
                pth = new PointF(x, y + 5);
                layoutsize = new SizeF(wd, ht);
                Serial_layout = new RectangleF(pth, layoutsize);
                e.Graphics.DrawString((i + 1).ToString(), bold_font, Brushes.Black, Serial_layout, formatCenter);               
                int j = 0;
                while (j< fm.itemdtdgv.ColumnCount)
                {
                    double colwd = fm.itemdtdgv.Columns[j].Width;
                    double tabwd = fm.itemdtdgv.Width;
                    x += wd;
                    wd = (int)(709 * colwd / tabwd);                 
                    pth = new PointF(x, y+5);
                    layoutsize = new SizeF(wd, 20);
                    RectangleF dgvlayout = new RectangleF(pth, layoutsize);                    
                    e.Graphics.DrawString(fm.itemdtdgv.Rows[i].Cells[j].Value.ToString(), bold_font, Brushes.Black, dgvlayout, formatCenter);
                    j++;
                }
                i++;
            }
            //print quantity details
            int wds = 41 + mrgn;
            i = 0;
            x = 40+41+mrgn;
            while (i < fm.itemdtdgv.ColumnCount && fm.itemdtdgv.Columns[i].HeaderText!="Quantity")
            {
                double colwd = fm.itemdtdgv.Columns[i].Width;
                double tabwd = fm.itemdtdgv.Width;                
                wds+=wd = (int)(709 * colwd / tabwd);
                x += wd;                
                i++;
            }
            y = 705;
            pth = new PointF(40, y);
            layoutsize = new SizeF(wds, ht);
            layout = new RectangleF(pth, layoutsize);
            e.Graphics.DrawString("Pieces", bold_font, Brushes.Black, layout, formatRight);

            double colwds = fm.itemdtdgv.Columns[i].Width;
            double tabwds = fm.itemdtdgv.Width;
            wd = (int)(709 * colwds / tabwds);           
            pth = new PointF(x, y);
            layoutsize = new SizeF(wd, ht);
            layout = new RectangleF(pth, layoutsize);
            e.Graphics.DrawString(fm.pcstxt.Text, bold_font, Brushes.Black, layout, formatCenter);
            rect = new Rectangle(Convert.ToInt32(layout.X), Convert.ToInt32(layout.Y) - 3, Convert.ToInt32(layout.Width), Convert.ToInt32(layout.Height));
            e.Graphics.DrawRectangle(pen, rect);
            //print subtotal
            int yc = 0;
            wds = 41 + mrgn;
            i = 0;
            x = 40 + 41 + mrgn;
            while (i < fm.itemdtdgv.ColumnCount && fm.itemdtdgv.Columns[i].HeaderText != "Amount")
            {
                double colwd = fm.itemdtdgv.Columns[i].Width;
                double tabwd = fm.itemdtdgv.Width;
                wds += wd = (int)(709 * colwd / tabwd);
                x += wd;
                i++;
            }
            yc = y +=20 ;
            pth = new PointF(30, y);
            layoutsize = new SizeF(wds, ht);
            layout = new RectangleF(pth, layoutsize);
            Font normal = new Font(FontFamily.GenericMonospace, 10);
            e.Graphics.DrawString("Subtotal ", bold_font, Brushes.Black, layout, formatRight);

            colwds = fm.itemdtdgv.Columns[i].Width;
            tabwds = fm.itemdtdgv.Width;
            wd = (int)(709 * colwds / tabwds);
            pth = new PointF(x-10, y);
            layoutsize = new SizeF(wd+10, ht);
            layout = new RectangleF(pth, layoutsize);          
            e.Graphics.DrawString(fm.subttxt.Text, bold_font, Brushes.Black, layout, formatRight);
            //discount details
            
            if (Convert.ToDouble(fm.discrattxt.Text) != 0)
            {
                wds = 41 + mrgn;
                i = 0;
                x = 40 + 41 + mrgn;
                while (i < fm.itemdtdgv.ColumnCount && fm.itemdtdgv.Columns[i].HeaderText != "Amount")
                {
                    double colwd = fm.itemdtdgv.Columns[i].Width;
                    double tabwd = fm.itemdtdgv.Width;
                    wds += wd = (int)(709 * colwd / tabwd);
                    x += wd;
                    i++;
                }
                y += 20;
                pth = new PointF(30, y);
                layoutsize = new SizeF(wds, ht);
                layout = new RectangleF(pth, layoutsize);
                e.Graphics.DrawString("Discount @ " + fm.discrattxt.Text + "% ", bold_font, Brushes.Black, layout, formatRight);

                colwds = fm.itemdtdgv.Columns[i].Width;
                tabwds = fm.itemdtdgv.Width;
                wd = (int)(709 * colwds / tabwds);
                pth = new PointF(x - 10, y);
                layoutsize = new SizeF(wd + 10, ht);
                layout = new RectangleF(pth, layoutsize);
                e.Graphics.DrawString(fm.disctxt.Text, bold_font, Brushes.Black, layout, formatRight);

                wds = 41 + mrgn;
                i = 0;
                x = 40 + 41 + mrgn;
                while (i < fm.itemdtdgv.ColumnCount && fm.itemdtdgv.Columns[i].HeaderText != "Amount")
                {
                    double colwd = fm.itemdtdgv.Columns[i].Width;
                    double tabwd = fm.itemdtdgv.Width;
                    wds += wd = (int)(709 * colwd / tabwd);
                    x += wd;
                    i++;
                }
                y += 20;
                pth = new PointF(30, y);
                layoutsize = new SizeF(wds, ht);
                layout = new RectangleF(pth, layoutsize);
                e.Graphics.DrawString("Total With Discount ", bold_font, Brushes.Black, layout, formatRight);

                colwds = fm.itemdtdgv.Columns[i].Width;
                tabwds = fm.itemdtdgv.Width;
                wd = (int)(709 * colwds / tabwds);
                pth = new PointF(x - 10, y);
                layoutsize = new SizeF(wd + 10, ht);
                layout = new RectangleF(pth, layoutsize);
                e.Graphics.DrawString(fm.tottxt.Text, bold_font, Brushes.Black, layout, formatRight);
            }

            //yc += 40;
            //GST Details
            if (Convert.ToDouble(fm.igsttxt.Text) != 0)
            {
                wds = 41 + mrgn;
                i = 0;
                x = 40 + 41 + mrgn;
                while (i < fm.itemdtdgv.ColumnCount && fm.itemdtdgv.Columns[i].HeaderText != "Amount")
                {
                    double colwd = fm.itemdtdgv.Columns[i].Width;
                    double tabwd = fm.itemdtdgv.Width;
                    wds += wd = (int)(709 * colwd / tabwd);
                    x += wd;
                    i++;
                }
                y += 20;
                pth = new PointF(30, y);
                layoutsize = new SizeF(wds, ht);
                layout = new RectangleF(pth, layoutsize);
                e.Graphics.DrawString("IGST @ 5% ", bold_font, Brushes.Black, layout, formatRight);

                colwds = fm.itemdtdgv.Columns[i].Width;
                tabwds = fm.itemdtdgv.Width;
                wd = (int)(709 * colwds / tabwds);
                pth = new PointF(x - 10, y);
                layoutsize = new SizeF(wd + 10, ht);
                layout = new RectangleF(pth, layoutsize);
                e.Graphics.DrawString(fm.igsttxt.Text, bold_font, Brushes.Black, layout, formatRight);
            }
            else
            {
                wds = 41 + mrgn;
                i = 0;
                x = 40 + 41 + mrgn;
                while (i < fm.itemdtdgv.ColumnCount && fm.itemdtdgv.Columns[i].HeaderText != "Amount")
                {
                    double colwd = fm.itemdtdgv.Columns[i].Width;
                    double tabwd = fm.itemdtdgv.Width;
                    wds += wd = (int)(709 * colwd / tabwd);
                    x += wd;
                    i++;
                }
                y += 20;
                pth = new PointF(30, y);
                layoutsize = new SizeF(wds, ht);
                layout = new RectangleF(pth, layoutsize);
                e.Graphics.DrawString("CGST @ 2.5% ", bold_font, Brushes.Black, layout, formatRight);

                colwds = fm.itemdtdgv.Columns[i].Width;
                tabwds = fm.itemdtdgv.Width;
                wd = (int)(709 * colwds / tabwds);
                pth = new PointF(x - 10, y);
                layoutsize = new SizeF(wd + 10, ht);
                layout = new RectangleF(pth, layoutsize);
                e.Graphics.DrawString(fm.cgsttxt.Text, bold_font, Brushes.Black, layout, formatRight);

                wds = 41 + mrgn;
                i = 0;
                x = 40 + 41 + mrgn;
                while (i < fm.itemdtdgv.ColumnCount && fm.itemdtdgv.Columns[i].HeaderText != "Amount")
                {
                    double colwd = fm.itemdtdgv.Columns[i].Width;
                    double tabwd = fm.itemdtdgv.Width;
                    wds += wd = (int)(709 * colwd / tabwd);
                    x += wd;
                    i++;
                }
                y += 20;
                pth = new PointF(30, y);
                layoutsize = new SizeF(wds, ht);
                layout = new RectangleF(pth, layoutsize);
                e.Graphics.DrawString("SGST @ 2.5%", bold_font, Brushes.Black, layout, formatRight);

                colwds = fm.itemdtdgv.Columns[i].Width;
                tabwds = fm.itemdtdgv.Width;
                wd = (int)(709 * colwds / tabwds);
                pth = new PointF(x - 10, y);
                layoutsize = new SizeF(wd + 10, ht);
                layout = new RectangleF(pth, layoutsize);
                e.Graphics.DrawString(fm.sgsttxt.Text, bold_font, Brushes.Black, layout, formatRight);
            }           
            //yc += 40;
            //packaging deatails
            if (Convert.ToDouble(fm.packagingtxt.Text) > 0)
            {
                wds = 41 + mrgn;
                i = 0;
                x = 40 + 41 + mrgn;
                while (i < fm.itemdtdgv.ColumnCount && fm.itemdtdgv.Columns[i].HeaderText != "Amount")
                {
                    double colwd = fm.itemdtdgv.Columns[i].Width;
                    double tabwd = fm.itemdtdgv.Width;
                    wds += wd = (int)(709 * colwd / tabwd);
                    x += wd;
                    i++;
                }
                y += 20;
                pth = new PointF(30, y);
                layoutsize = new SizeF(wds, ht);
                layout = new RectangleF(pth, layoutsize);
                e.Graphics.DrawString(fm.packlbl.Text, bold_font, Brushes.Black, layout, formatRight);

                colwds = fm.itemdtdgv.Columns[i].Width;
                tabwds = fm.itemdtdgv.Width;
                wd = (int)(709 * colwds / tabwds);
                pth = new PointF(x - 10, y);
                layoutsize = new SizeF(wd + 10, ht);
                layout = new RectangleF(pth, layoutsize);
                e.Graphics.DrawString(fm.packagingtxt.Text, bold_font, Brushes.Black, layout, formatRight);
            }

            //yc += 20;
            //transport details
            if (Convert.ToDouble(fm.packagingtxt.Text) > 0)
            {
                wds = 41 + mrgn;
                i = 0;
                x = 40 + 41 + mrgn;
                while (i < fm.itemdtdgv.ColumnCount && fm.itemdtdgv.Columns[i].HeaderText != "Amount")
                {
                    double colwd = fm.itemdtdgv.Columns[i].Width;
                    double tabwd = fm.itemdtdgv.Width;
                    wds += wd = (int)(709 * colwd / tabwd);
                    x += wd;
                    i++;
                }
                y += 20;
                pth = new PointF(30, y);
                layoutsize = new SizeF(wds, ht);
                layout = new RectangleF(pth, layoutsize);
                e.Graphics.DrawString(fm.trasportlbl.Text, bold_font, Brushes.Black, layout, formatRight);

                colwds = fm.itemdtdgv.Columns[i].Width;
                tabwds = fm.itemdtdgv.Width;
                wd = (int)(709 * colwds / tabwds);
                pth = new PointF(x - 10, y);
                layoutsize = new SizeF(wd + 10, ht);
                layout = new RectangleF(pth, layoutsize);
                e.Graphics.DrawString(fm.transport_chargetxt.Text, bold_font, Brushes.Black, layout, formatRight);
            }
                        
            rect = new Rectangle(Convert.ToInt32(layout.X),yc - 3, Convert.ToInt32(layout.Width), y-yc+Convert.ToInt32(layout.Height));
            e.Graphics.DrawRectangle(pen, rect);

            //grand total
            wds = 41 + mrgn;
            i = 0;
            x = 40 + 41 + mrgn;
            while (i < fm.itemdtdgv.ColumnCount && fm.itemdtdgv.Columns[i].HeaderText != "Amount")
            {
                double colwd = fm.itemdtdgv.Columns[i].Width;
                double tabwd = fm.itemdtdgv.Width;
                wds += wd = (int)(709 * colwd / tabwd);
                x += wd;
                i++;
            }
            y += 50;
            pth = new PointF(30, y);
            layoutsize = new SizeF(wds, ht);
            layout = new RectangleF(pth, layoutsize);
            size = 10;
            bold_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Bold);
            e.Graphics.DrawString("Grand Total", bold_font, Brushes.Black, layout, formatRight);

            colwds = fm.itemdtdgv.Columns[i].Width;
            tabwds = fm.itemdtdgv.Width;
            wd = (int)(709 * colwds / tabwds);
            pth = new PointF(x-10, y);
            layoutsize = new SizeF(wd+10, ht);
            layout = new RectangleF(pth, layoutsize);
            e.Graphics.DrawString(fm.grtottxt.Text, bold_font, Brushes.Black, layout, formatCenter);
            rect = new Rectangle(Convert.ToInt32(layout.X), Convert.ToInt32(layout.Y), Convert.ToInt32(layout.Width), Convert.ToInt32(layout.Height));
            e.Graphics.DrawRectangle(pen, rect);

            //Inword Grand Total
           
            i = 0;
            x = 40 + 41 + mrgn;
            wds = 41 + mrgn;
            while (i < fm.itemdtdgv.ColumnCount && fm.itemdtdgv.Columns[i].HeaderText != "Description")
            {
                double colwd = fm.itemdtdgv.Columns[i].Width;
                double tabwd = fm.itemdtdgv.Width;
                wds += wd = (int)(709 * colwd / tabwd);
                x += wd;
                i++;
            }
            y += 25;
            pth = new PointF(40, y);
            layoutsize = new SizeF(wds, ht);
            layout = new RectangleF(pth, layoutsize);
            size = 10;
            bold_font = new Font(FontFamily.GenericMonospace, size, FontStyle.Bold);
            e.Graphics.DrawString("In Words", bold_font, Brushes.Black, layout, formatCenter);
            rect = new Rectangle(Convert.ToInt32(layout.X), Convert.ToInt32(layout.Y), Convert.ToInt32(layout.Width), Convert.ToInt32(layout.Height));
            e.Graphics.DrawRectangle(pen, rect);

            wds = 0;
            while (i < fm.itemdtdgv.ColumnCount)
            {
                double colwd = fm.itemdtdgv.Columns[i].Width;
                double tabwd = fm.itemdtdgv.Width;
                wds += wd = (int)(709 * colwd / tabwd);                
                i++;
            }
            
            pth = new PointF(x, y);
            layoutsize = new SizeF(wds, ht);
            layout = new RectangleF(pth, layoutsize);
            e.Graphics.DrawString(fm.numwrdtxt.Text, bold_font, Brushes.Black, layout, formatCenter);
            rect = new Rectangle(Convert.ToInt32(layout.X), Convert.ToInt32(layout.Y), Convert.ToInt32(layout.Width), Convert.ToInt32(layout.Height));
            e.Graphics.DrawRectangle(pen, rect);

            //A/c Details
            wds = 350;
            x = 40 + 41 + mrgn;           
            yc = y = 705;
            inkText("Account Details",x, y, wds, ht, bold_font, formatCenter, e);
            Bankdt dt = new Bankdt();
            dt.holder_fkey = Call.GTD(Constant.Company_id);
            dt = Call.ret_bankdt(dt);
            y += 20;
            inkText(dt.bank_name, x, y, wds, ht, bold_font, formatCenter, e);
            y += 20;
            inkText(dt.Name, x, y, wds, ht, bold_font, formatCenter, e);
            y += 20;
            inkText(dt.AccountNo, x, y, wds, ht, bold_font, formatCenter, e);
            y += 20;
            inkText(dt.IFSC, x, y, wds, ht, bold_font, formatCenter, e);

            //Proprietor
            wds = 250;
            x = 40 + 41 + mrgn;
            i = 0;
            while (i < fm.itemdtdgv.ColumnCount)
            {
                double colwd = fm.itemdtdgv.Columns[i].Width;
                double tabwd = fm.itemdtdgv.Width;
                x+= (int)(709 * colwd / tabwd);
                i++;
            }
            x -= wds;
            y = 1010;
            inkfill(x, y, wds, ht, Brushes.Gray, e);
            inkText("Proprietor", x, y, wds, ht, bold_font, formatCenter, e);            
            inkdraw(x, y, wds, ht, Brushes.Black, 2, e);            
            y += 20;           
            inkdraw(x, y, wds, ht*4, Brushes.Black, 2, e);

            //Juridiction
            inkText("SUBJECT TO VARANASI JURIDICTION ONLY", 40, 1125, 750, 40, bold_font, formatCenter, e);

        }
        static void inkText(string text,int x,int y,int width,int height,Font font, StringFormat align, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PointF pth = new PointF(x, y);
            SizeF layoutsize = new SizeF(width, height);
            RectangleF layout = new RectangleF(pth, layoutsize);
            e.Graphics.DrawString(text, font, Brushes.Black, layout, align);
        }
        static void inkdraw(int x,int y,int width,int height,Brush brush, float size,System.Drawing.Printing.PrintPageEventArgs e)
        {
            Pen pen = new Pen(brush,size);
            Rectangle rect = new Rectangle(x,y,width,height);
            e.Graphics.DrawRectangle(pen, rect);
        }
        static void inkfill(int x, int y, int width, int height, Brush brush, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            Rectangle rect = new Rectangle(x, y, width, height);
            e.Graphics.FillRectangle(brush, rect);
        }
    }
    class PrntCom
    {
        public DateTimePicker datetxt = new DateTimePicker();
        public TextBox invoidtxt = new TextBox();
        public TextBox grtottxt = new TextBox();
        public DataGridView itemdtdgv = new DataGridView();
        public TextBox pcstxt = new TextBox();
        public TextBox subttxt = new TextBox();
        public TextBox discrattxt = new TextBox();
        public TextBox disctxt = new TextBox();
        public TextBox tottxt = new TextBox();
        public TextBox igsttxt = new TextBox();
        public TextBox cgsttxt = new TextBox();
        public TextBox sgsttxt = new TextBox();
        public TextBox packagingtxt = new TextBox();
        public TextBox transport_chargetxt = new TextBox();
        public Label packlbl = new Label();
        public Label trasportlbl = new Label();
        public TextBox numwrdtxt = new TextBox();
        public TextBox ewaybilltxt = new TextBox();
    }
    class PrntDocType
    {
        public string head_label;
        public string doc_type;
        public string doc_db;
        public string doc_tname;
    }
    class dbo_Process
    {
        static string str, dbs, fn;
        static string[] ftr = { "", "", "", "" };
        public static void createDB(object ps, string database, string t_name,bool drop=false)
        {
            if (drop)
            {
                Fall.SaveDB("DROP TABLE " + t_name, database);
            }
            string qurry = "Create Table [dbo].[" + t_name + "] \n(\n[Id] INT IDENTITY (1, 1) NOT NULL";//Table Name
            if (dbs != database)
            {
                str += ("\nclass " + database + "\n{ ");
                dbs = database;
            }
            string rstr = str;
            str = rstr.Substring(0, rstr.Length - 1) + ("\npublic static string t_" + t_name.Substring(0) + " =\"" + t_name.Substring(0) + "\";");
            str += ("\npublic static class c_" + t_name.Substring(0) + "\n{");
            ftr[0] = "\npublic static bool Insert_" + t_name + "(";
            ftr[1] = "\nstring qurry=\"insert into " + t_name + " ("; ftr[3] = " values(";
            ftr[2] = "\nSqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[\"" + database + "\"].ConnectionString);\ncon.Open();\nSqlCommand cmd = new SqlCommand(qurry, con);";
            foreach (FieldInfo item in ps.GetType().GetFields())
            {
                switch (item.Name)
                {
                    case "image":
                        qurry += ",\n [" + item.Name + "] VARBINARY(MAX) " + item.GetValue(ps).ToString();
                        ftr[0] += "byte[] " + item.Name + ",";
                        break;

                    default:
                        qurry += ",\n [" + item.Name + "] VARCHAR(MAX) " + item.GetValue(ps).ToString() + "";
                        ftr[0] += "string " + item.Name + ",";
                        break;
                }
                ftr[1] += item.Name + ","; ftr[3] += "@" + item.Name + ",";
                ftr[2] += "\ncmd.Parameters.Add(\"@" + item.Name + "\"," + item.Name + ");";
                str += ("\npublic static string f_" + item.Name + " =\"" + item.Name + "\";");
            }
            rstr = ftr[0];
            ftr[0] = ftr[0].Substring(0, rstr.Length - 1) + ")\n{";
            rstr = ftr[1];
            ftr[1] = ftr[1].Substring(0, rstr.Length - 1) + ")";
            ftr[2] += "\nbool rt= Fall.SaveDB(cmd);\ncon.Close();\nreturn rt;";
            rstr = ftr[3];
            ftr[3] = ftr[3].Substring(0, rstr.Length - 1) + ")\";";
            fn += ftr[0] + ftr[1] + ftr[3] + ftr[2] + "\n}";
            str += ("\n}" + "\n}");
            qurry += ",\nPRIMARY KEY CLUSTERED ([Id] ASC)\n);";
            Fall.SaveDB(qurry, database);
        }
        public static void NewCompanyDB(string Com_id="0",bool IsReset=false)
        {
            string id = "";
            //if (Convert.ToInt32(Call.GTD(Constant.Company_id))<0)
            //{
            //    id = Constant.Ret_Alpha(Call.GTD(Constant.Company_id));
            //}
            //else
            {
                id = Constant.Ret_Alpha(Com_id);
            }
            string database = Constant.TransDB;
            //Ledger Flush
            string qurry = "Select Id from Company_T";
            DataTable ds = Fall.fill_ds(qurry, Constant.CompanyDB);
            //if (ds.Rows.Count>0)
            //{
            //    int i = 0;
            //    while (ds.Rows.Count > i)
            //    {            
            //        Ledgedt dt = new Ledgedt();
            //        createDB(dt, Constant.LedgerDB, "Company_" + ds.Rows[i][0].ToString() + "_Ledge", true);
            //        i++;
            //    }
            //}
            //qurry = "Select stockId from Item_T";
            //ds = Fall.fill_ds(qurry, Constant.StockDB);
            //if (ds.Rows.Count > 0)
            //{
            //    int i = 0;
            //    while (ds.Rows.Count > i)
            //    {                                        
            //        Ledgedt dt = new Ledgedt();
            //        createDB(dt, Constant.LedgerDB, "Item_" + ds.Rows[i][0].ToString() + "_Ledge", true);
            //        i++;
            //    }
            //}
            //Billing Table
            bill db = new bill();
            b_Sub dbs = new b_Sub();
            b_challan ch_db = new b_challan();
            //Outward Billing Table           
            dbo_Process.createDB(db, database, id + "Sell_Bill_T",IsReset);
            dbo_Process.createDB(dbs, database, id + "Sell_Bill_D_T", IsReset);
            ////Unregistered
            dbo_Process.createDB(ch_db, database, id + "Sell_Challan_T", IsReset);
            dbo_Process.createDB(dbs, database, id + "Sell_Challan_D_T", IsReset);
            //Inward Billing Table
            dbo_Process.createDB(db, database, id + "Purchase_Bill_T", IsReset);
            dbo_Process.createDB(dbs, database, id + "Purchase_Bill_D_T", IsReset);
            ////Unregistered
            dbo_Process.createDB(ch_db, database, id + "Purchase_Challan_T", IsReset);
            dbo_Process.createDB(dbs, database, id + "Purchase_Challan_D_T", IsReset);
            ////Manual Entries/Initial Entries
            dbo_Process.createDB(db, database, id + "Manual_Stock_T", IsReset);
            dbo_Process.createDB(dbs, database, id + "Manual_Stock_D_T", IsReset);

            //Return Table
            RetStock rd = new RetStock();
            RS_Sub rds = new RS_Sub();
            RS_challan ch_rd = new RS_challan();
            //OutWard Return Table           
            dbo_Process.createDB(rd, database, id + "Purchase_Resturn_Note_T", IsReset);
            dbo_Process.createDB(rds, database, id + "Purchase_Resturn_Note_D_T", IsReset);
            ////Unregistered
            dbo_Process.createDB(ch_rd, database, id + "Purchase_Resturn_Challan_T", IsReset);
            dbo_Process.createDB(rds, database, id + "Purchase_Resturn_Challan_D_T", IsReset);
            //Inward Return Table
            dbo_Process.createDB(rd, database, id + "Sell_Resturn_Note_T", IsReset);
            dbo_Process.createDB(rds, database, id + "Sell_Resturn_Note_D_T", IsReset);
            ////Unregistered
            dbo_Process.createDB(ch_rd, database, id + "Sell_Resturn_Challan_T", IsReset);
            dbo_Process.createDB(rds, database, id + "Sell_Resturn_Challan_D_T", IsReset);

            //Job table
            Job jb = new Job();
            J_Sub jbs = new J_Sub();
            J_challan ch_jb = new J_challan();
            //Outward Job table            
            dbo_Process.createDB(jb, database, id + "Sell_Job_Bill_T", IsReset);
            dbo_Process.createDB(jbs, database, id + "Sell_Job_Bill_D_T", IsReset);
            ////Unregistered
            dbo_Process.createDB(ch_jb, database, id + "Sell_Job_Challan_T", IsReset);
            dbo_Process.createDB(jbs, database, id + "Sell_Job_Challan_D_T", IsReset);
            //Inward Job table
            dbo_Process.createDB(jb, database, id + "Purchase_Job_Bill_T", IsReset);
            dbo_Process.createDB(jbs, database, id + "Purchase_Job_Bill_D_T", IsReset);
            ////Unregistered
            dbo_Process.createDB(ch_jb, database, id + "Purchase_Job_Challan_T", IsReset);
            dbo_Process.createDB(jbs, database, id + "Purchase_Job_Challan_D_T", IsReset);
            //Manual/Initial Job table            
            dbo_Process.createDB(jb, database, id + "Manual_Job_T", IsReset);
            dbo_Process.createDB(jbs, database, id + "Manual_Job_D_T", IsReset);

            //Job Recieving table
            RJob rj = new RJob();
            RJ_Sub rjs = new RJ_Sub();
            RJ_challan ch_rj = new RJ_challan();
            //Inward JobRecieving table
            dbo_Process.createDB(rj, database, id + "Purchase_JobRecieving_Bill_T", IsReset);
            dbo_Process.createDB(rjs, database, id + "Purchase_JobRecieving_Bill_D_T", IsReset);
            ////Unregistered
            dbo_Process.createDB(ch_rj, database, id + "Purchase_JobRecieving_Challan_T", IsReset);
            dbo_Process.createDB(rjs, database, id + "Purchase_JobRecieving_Challan_D_T", IsReset);
            //Manual/Initial JobRecieving table
            dbo_Process.createDB(rj, database, id + "Manual_JobRecieving_T", IsReset);
            dbo_Process.createDB(rjs, database, id + "Manual_JobRecieving_D_T", IsReset);
            //Payment Table
            Pay pt = new Pay();
            P_sub pts = new P_sub();
            //Inward Payment Table
            dbo_Process.createDB(pt, database, id + "Purchase_Payment_T", IsReset);
            dbo_Process.createDB(pts, database, id + "Purchase_Payment_D_T", IsReset);
            //Outward Payment Table
            dbo_Process.createDB(pt, database, id + "Sell_Payment_T", IsReset);
            dbo_Process.createDB(pts, database, id + "Sell_Payment_D_T", IsReset);

            //GST Table
            GSTDB.gst gst = new GSTDB.gst();
            dbo_Process.createDB(gst, database, id + "IGST", IsReset);            
            dbo_Process.createDB(gst, database, id + "CGST", IsReset);
            dbo_Process.createDB(gst, database, id + "SGST", IsReset);
            dbo_Process.createDB(gst, database, id + "UGST", IsReset);
            dbo_Process.createDB(gst, database, id + "CESS", IsReset);

            GSTDB.gstliability gstlbt = new GSTDB.gstliability();
            dbo_Process.createDB(gstlbt, database, id + "FEES", IsReset);
            dbo_Process.createDB(gstlbt, database, id + "PENALTY", IsReset);
            dbo_Process.createDB(gstlbt, database, id + "INTEREST", IsReset);
            dbo_Process.createDB(gstlbt, database, id + "OTHER", IsReset);
            //GST Payment
            gstpaymt gp = new gstpaymt();
            dbo_Process.createDB(gp, database, id + "GSTPAY_T", IsReset);

        }
        public static void NewAppDB()
        {
            string database = Constant.CompanyDB;
            string intial = null;

            CompanyObj cmp = new CompanyObj();
            createDB(cmp, database, intial + "Company_T");

            Address adrs = new Address();
            createDB(adrs, database, intial + "Address_T");

            category ct = new category();
            createDB(ct, database, intial + "Category_T");

            Bankdt bk = new Bankdt();
            createDB(bk, database, intial + "Bank_T");

            CompanyPreson cp = new CompanyPreson();
            createDB(cp, database, intial + "Person_T");

            Employee emp = new Employee();
            createDB(emp, database, intial + "Employee_T");

            contact ph = new contact();
            createDB(ph, database, intial + "Contact_T");

            photo pns = new photo();
            createDB(pns, database, intial + "Image_T");

            Logindt Id = new Logindt();
            createDB(Id, database, "Login_T");

            database = Constant.StockDB;

            stock_item itm = new stock_item();
            createDB(itm, database, intial + "Item_T");

            servicer_item srv = new servicer_item();
            createDB(srv, database, intial + "Service_T");

            job_item jtm = new job_item();
            createDB(jtm, database, intial + "Job_T");

            photo pn = new photo();
            createDB(pn, database, intial + "Image_T");

            rate rt = new rate();
            createDB(rt, database, intial + "rate_T");

            createDB(ct, database, intial + "Category_T");
            //Update database with initial Data
            Fall.SaveDB("insert into [Category_T] (Name,date_,sub,LedgerReq) values('Company','" + DateTime.Today.ToString() + "','main','" + true.ToString() + "')", Constant.CompanyDB);
        }
    }
}
