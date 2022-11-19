using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{
    public partial class Main : nform
    {
        public Main()
        {           
            InitializeComponent();                 
        }
        
       
        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Company ss = new Company(Constant.AddParty());
            Open(ss);
        }        
      
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (Call.ret_isRecord("Item_T", Constant.StockDB))
            {
                Stock ss = new Stock("View");
                Open(ss);
            }
            else
            {
                MessageBox.Show("No Record Created!");
            }
        }
        
        private void changeCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PreMain ss = new PreMain("");
            ss.Show();
        }
        
        private void addManualStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdExitStock ss = new AdExitStock();
            ss.ShowDialog();
        }

        private void addManualWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdExitJob ss = new AdExitJob();
            ss.ShowDialog();
        }

        private void adminLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Fall.fill_ds("Select * from [Login_T] where [LoginID] ='"+Call.GTD(Constant.User_id)+"'",Constant.CompanyDB).Rows[0]["Type"].ToString()==Constant.MKey)
            {
                Authenticate sa = new Authenticate(Constant.MKey);
                sa.ShowDialog();
                if (Authenticate.authenticate)
                {
                    AdUser ss = new AdUser();
                    ss.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("You are Not Authorise!");
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Authenticate sa = new Authenticate();
            sa.ShowDialog();
            if (Authenticate.authenticate)
            {
                ChangePwd ss = new ChangePwd();
                ss.ShowDialog();
            }
        }        
        void  Open(nform  ss)
        {            
            bool isopen = false;
            foreach (nform item in Application.OpenForms)
            {
                if (item.Name == ss.Name)
                {
                    isopen = true;
                }
            }
            if (!isopen)
            {
                ss.MdiParent = this;
                if (ss.st)
                {
                    ss.Show();
                }     
            }
        }

        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryList sa = new CategoryList(Constant.CompanyDB);
            sa.ShowDialog();
            Object_List ss = new Object_List(sa.cat);
            Open(ss);
        }

        private void partyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryList sa = new CategoryList(Constant.CompanyDB);
            sa.ShowDialog();
            CompanyFdt agr = new CompanyFdt();
            agr = Constant.ViewParty();
            agr.callby = sa.cat;
            Company ss = new Company(agr);
            Open(ss);
        }

        private void cashToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CategoryList sa = new CategoryList(Constant.CompanyDB);
            sa.ShowDialog();
            Cash_PaymentDT cpt = new Cash_PaymentDT();
            cpt.callas = "View";
            cpt.callby = sa.cat;
            cpt.mode = "Cash";
            DataTable ds = new DataTable();
            ds = Fall.fill_ds("Select * from Category_T where " + CompanyDB.c_Category_T.f_Name + " = '" + cpt.callby + "'", Constant.CompanyDB);
            switch (ds.Rows[0][CompanyDB.c_Category_T.f_sub].ToString())
            {
                case "Creditor":
                    cpt.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Payment_T;
                    cpt.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Payment_D_T;
                    cpt.InsertPT = TranDB.Insert_Purchase_Payment_T;
                    cpt.InsertPDT = TranDB.Insert_Purchase_Payment_D_T;
                    break;
                case "Debitor":
                    cpt.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Payment_T;
                    cpt.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Payment_D_T;
                    cpt.InsertPT = TranDB.Insert_Sell_Payment_T;
                    cpt.InsertPDT = TranDB.Insert_Sell_Payment_D_T;
                    break;
                default:
                    break;
            }
            Cash_Payment ss = new Cash_Payment(cpt);
            Open(ss);
        }

        private void chequeToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CategoryList sa = new CategoryList(Constant.CompanyDB);
            sa.ShowDialog();
            paymentDT pdt = new paymentDT();
            pdt.callby = sa.cat;
            pdt.callas = "View";
            pdt.mode = "Cheque";
            DataTable ds = new DataTable();
            ds = Fall.fill_ds("Select * from Category_T where " + CompanyDB.c_Category_T.f_Name + " = '" + pdt.callby + "'", Constant.CompanyDB);
            switch (ds.Rows[0][CompanyDB.c_Category_T.f_sub].ToString())
            {
                case "Creditor":
                    pdt.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Payment_T;
                    pdt.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Payment_D_T;
                    pdt.InsertPT = TranDB.Insert_Purchase_Payment_T;
                    pdt.InsertPDT = TranDB.Insert_Purchase_Payment_D_T;
                    break;
                case "Debitor":
                    pdt.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Payment_T;
                    pdt.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Payment_D_T;
                    pdt.InsertPT = TranDB.Insert_Sell_Payment_T;
                    pdt.InsertPDT = TranDB.Insert_Sell_Payment_D_T;
                    break;
                default:
                    break;
            }
            payment ss = new payment(pdt);
            Open(ss);
        }

        private void acTransferToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CategoryList sa = new CategoryList(Constant.CompanyDB);
            sa.ShowDialog();
            paymentDT pdt = new paymentDT();
            pdt.callby = sa.cat;
            pdt.callas = "View";
            pdt.mode = "A/c_Transfer";
            DataTable ds = new DataTable();
            ds = Fall.fill_ds("Select * from Category_T where " + CompanyDB.c_Category_T.f_Name + " = '" + pdt.callby + "'", Constant.CompanyDB);
            switch (ds.Rows[0][CompanyDB.c_Category_T.f_sub].ToString())
            {
                case "Creditor":
                    pdt.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Payment_T;
                    pdt.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Payment_D_T;
                    pdt.InsertPT = TranDB.Insert_Purchase_Payment_T;
                    pdt.InsertPDT = TranDB.Insert_Purchase_Payment_D_T;
                    break;
                case "Debitor":
                    pdt.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Payment_T;
                    pdt.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Payment_D_T;
                    pdt.InsertPT = TranDB.Insert_Sell_Payment_T;
                    pdt.InsertPDT = TranDB.Insert_Sell_Payment_D_T;
                    break;
                default:
                    break;
            }
            payment ss = new payment(pdt);
            Open(ss);            
        }

        private void cashToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CategoryList sa = new CategoryList(Constant.CompanyDB);
            sa.ShowDialog();
            Cash_PaymentDT cpt = new Cash_PaymentDT();
            cpt.callas = "New";
            cpt.callby = sa.cat;
            cpt.mode = "Cash";
            DataTable ds = new DataTable();
            ds = Fall.fill_ds("Select * from Category_T where " + CompanyDB.c_Category_T.f_Name + " = '" + cpt.callby + "'", Constant.CompanyDB);
            switch (ds.Rows[0][CompanyDB.c_Category_T.f_sub].ToString())
            {
                case "Creditor":
                    cpt.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Payment_T;
                    cpt.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Payment_D_T;
                    cpt.InsertPT = TranDB.Insert_Purchase_Payment_T;
                    cpt.InsertPDT = TranDB.Insert_Purchase_Payment_D_T;
                    break;
                case "Debitor":
                    cpt.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Payment_T;
                    cpt.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Payment_D_T;
                    cpt.InsertPT = TranDB.Insert_Sell_Payment_T;
                    cpt.InsertPDT = TranDB.Insert_Sell_Payment_D_T;
                    break;
                default:
                    break;
            }
            Cash_Payment ss = new Cash_Payment(cpt);
            Open(ss);
        }

        private void chequeToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CategoryList sa = new CategoryList(Constant.CompanyDB);
            sa.ShowDialog();
            paymentDT pdt = new paymentDT();
            pdt.callby = sa.cat;
            pdt.callas = "New";
            pdt.mode = "Cheque";
            DataTable ds = new DataTable();
            ds = Fall.fill_ds("Select * from Category_T where " + CompanyDB.c_Category_T.f_Name + " = '" + pdt.callby + "'", Constant.CompanyDB);
            switch (ds.Rows[0][CompanyDB.c_Category_T.f_sub].ToString())
            {
                case "Creditor":
                    pdt.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Payment_T;
                    pdt.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Payment_D_T;
                    pdt.InsertPT = TranDB.Insert_Purchase_Payment_T;
                    pdt.InsertPDT = TranDB.Insert_Purchase_Payment_D_T;
                    break;
                case "Debitor":
                    pdt.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Payment_T;
                    pdt.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Payment_D_T;
                    pdt.InsertPT = TranDB.Insert_Sell_Payment_T;
                    pdt.InsertPDT = TranDB.Insert_Sell_Payment_D_T;
                    break;
                default:
                    break;
            }
            payment ss = new payment(pdt);
            Open(ss);
        }

        private void acTransferToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CategoryList sa = new CategoryList(Constant.CompanyDB);
            sa.ShowDialog();
            paymentDT pdt = new paymentDT();
            pdt.callby = sa.cat;
            pdt.callas = "New";
            pdt.mode = "A/c_Transfer";
            DataTable ds = new DataTable();
            ds = Fall.fill_ds("Select * from Category_T where " + CompanyDB.c_Category_T.f_Name + " = '" + pdt.callby + "'", Constant.CompanyDB);
            switch (ds.Rows[0][CompanyDB.c_Category_T.f_sub].ToString())
            {
                case "Creditor":
                    pdt.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Payment_T;
                    pdt.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Payment_D_T;
                    pdt.InsertPT = TranDB.Insert_Purchase_Payment_T;
                    pdt.InsertPDT = TranDB.Insert_Purchase_Payment_D_T;
                    break;
                case "Debitor":
                    pdt.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Payment_T;
                    pdt.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Payment_D_T;
                    pdt.InsertPT = TranDB.Insert_Sell_Payment_T;
                    pdt.InsertPDT = TranDB.Insert_Sell_Payment_D_T;
                    break;
                default:
                    break;
            }
            payment ss = new payment(pdt);
            Open(ss);           
        }

        private void goodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillF ss = new BillF(Constant.SellItem());
            Open(ss);
        }

        private void serviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillF ss = new BillF(Constant.SellService());
            Open(ss);
        }

        private void jobToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            JobBillF ss = new JobBillF(Constant.SellJob());
            Open(ss);
        }

        private void goodsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BillF ss = new BillF(Constant.BuyItem());
            Open(ss);
        }

        private void serviceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BillF ss = new BillF(Constant.BuyService());
            Open(ss);
        }

        private void jobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JobBillF ss = new JobBillF(Constant.BuyJob());
            Open(ss);
        }

        private void goodsToolStripMenuItem2_Click(object sender, EventArgs e)
        {          
            BillF ss = new BillF(Constant.ChSellItem());
            Open(ss);
        }

        private void serviceToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            BillF ss = new BillF(Constant.ChSellService());
            Open(ss);
        }

        private void jobsToolStripMenuItem1_Click(object sender, EventArgs e)
        {           
            JobBillF ss = new JobBillF(Constant.ChSellJob());
            Open(ss);
        }

        private void goodsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            BillF ss = new BillF(Constant.ChBuyItem());
            Open(ss);
        }

        private void serviceToolStripMenuItem3_Click(object sender, EventArgs e)
        {           
            BillF ss = new BillF(Constant.ChBuyService());
            Open(ss);
        }

        private void jobsToolStripMenuItem2_Click(object sender, EventArgs e)
        {          
            JobBillF ss = new JobBillF(Constant.ChBuyJob());
            Open(ss);
        }




        private void goodsToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ReturnF ss = new ReturnF(Constant.SellRetItem());
            Open(ss);
        }

        private void serviceToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ReturnF ss = new ReturnF(Constant.SellRetService());
            Open(ss);
        }

        private void jobsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Return Form");
        }

        private void goodsToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ReturnF ss = new ReturnF(Constant.BuyRetItem());
            Open(ss);
        }

        private void serviceToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ReturnF ss = new ReturnF(Constant.BuyRetService());
            Open(ss);
        }

        private void jobsToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Return Form");
        }

        private void goodsToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ReturnFdt sa = new ReturnFdt();
            sa=Constant.ChSellRetItem();
            sa.callas = Constant.challan;
            ReturnF ss = new ReturnF(sa);
            Open(ss);
        }

        private void serviceReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnFdt sa = new ReturnFdt();
            sa = Constant.ChSellRetService();
            sa.callas = Constant.challan;
            ReturnF ss = new ReturnF(sa);
            Open(ss);
        }

        private void jobsReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Return Form");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ReturnFdt sa = new ReturnFdt();
            sa = Constant.BuyRetItem();
            sa.callas = Constant.challan;
            ReturnF ss = new ReturnF(sa);
            Open(ss);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ReturnFdt sa = new ReturnFdt();
            sa = Constant.BuyRetService();
            sa.callas = Constant.challan;
            ReturnF ss = new ReturnF(sa);
            Open(ss);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Return Form");
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JRecievingF ss = new JRecievingF(Constant.BuyJRecieving());
            Open(ss);
        }

        private void challanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JRFdt sa = new JRFdt();
            sa = Constant.ChBuyJRecieving();            
            JRecievingF ss = new JRecievingF(sa);
            Open(ss);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            BillF ss = new BillF(Constant.VSitem());
            Open(ss);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            BillF ss = new BillF(Constant.VSservice());
            Open(ss);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            JobBillF ss = new JobBillF(Constant.VSjob());
            Open(ss);
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            BillF ss = new BillF(Constant.VBitem());
            Open(ss);
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            BillF ss = new BillF(Constant.VBservice());
            Open(ss);
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            JobBillF ss = new JobBillF(Constant.VBjob());
            Open(ss);
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {           
            BillF ss = new BillF(Constant.ChVSitem());
            Open(ss);
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {            
            BillF ss = new BillF(Constant.ChVSservice());
            Open(ss);
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {            
            JobBillF ss = new JobBillF(Constant.ChVSjob());
            Open(ss);
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            BillF ss = new BillF(Constant.ChVBitem());
            Open(ss);
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            BillF ss = new BillF(Constant.ChVBservice());
            Open(ss);
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            JobBillF ss = new JobBillF(Constant.ChVBjob());
            Open(ss);
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            Challan_to_bill ss = new Challan_to_bill(Constant.C2BSellItem());
            Open(ss);
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            Challan_to_bill ss = new Challan_to_bill(Constant.C2BSellService());
            Open(ss);
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            Challan_to_bill ss = new Challan_to_bill(Constant.C2BBuyItem());
            Open(ss);
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
            Challan_to_bill ss = new Challan_to_bill(Constant.C2BBuyService());
            Open(ss);
        }      

        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {
            ReturnF ss = new ReturnF(Constant.VSRetItem());
            Open(ss);
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
            ReturnF ss = new ReturnF(Constant.VSRetService());
            Open(ss);
        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Return Form");
        }

        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {
            ReturnF ss = new ReturnF(Constant.VBRetItem());
            Open(ss);
        }

        private void toolStripMenuItem40_Click(object sender, EventArgs e)
        {
            ReturnF ss = new ReturnF(Constant.VBRetService());
            Open(ss);
        }

        private void toolStripMenuItem41_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Return Form");
        }

        private void toolStripMenuItem44_Click(object sender, EventArgs e)
        {
            ReturnFdt sa = new ReturnFdt();
            sa = Constant.VSRetItem();
            sa.callas = Constant.challan;
            ReturnF ss = new ReturnF(sa);
            Open(ss);
        }

        private void toolStripMenuItem45_Click(object sender, EventArgs e)
        {
            ReturnFdt sa = new ReturnFdt();
            sa = Constant.VSRetService();
            sa.callas = Constant.challan;
            ReturnF ss = new ReturnF(sa);
            Open(ss);
        }

        private void toolStripMenuItem46_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Return Form");
        }

        private void toolStripMenuItem48_Click(object sender, EventArgs e)
        {
            ReturnFdt sa = new ReturnFdt();
            sa = Constant.VBRetItem();
            sa.callas = Constant.challan;
            ReturnF ss = new ReturnF(sa);
            Open(ss);
        }

        private void toolStripMenuItem49_Click(object sender, EventArgs e)
        {
            ReturnFdt sa = new ReturnFdt();
            sa = Constant.VBRetService();
            sa.callas = Constant.challan;
            ReturnF ss = new ReturnF(sa);
            Open(ss);
        }

        private void toolStripMenuItem50_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Return Form");
        }

        private void toolStripMenuItem52_Click(object sender, EventArgs e)
        {
            JRecievingF ss = new JRecievingF(Constant.VBJRecieving());
            Open(ss);
        }

        private void toolStripMenuItem53_Click(object sender, EventArgs e)
        {
            JRFdt sa = new JRFdt();
            sa = Constant.ChVBJRecieving();
            JRecievingF ss = new JRecievingF(sa);
            Open(ss);
        }
    }
    public class nform:Form
    {
        public bool st = true;
       
    }    
    
}
