using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{
    class Constant
    {
        public static string Company_id = "Company_Id";
        public static string User_id = "Login_id";
        public static string User_name = "Name";
        public static string Doc_date = "Doc_date";
        public static string Supplier_id = "Supplier_Id";
        public static string Customer_id = "Customer_Id";
        public static string CompanyDB = "CompanyDB";        

        public static string StockDB = "StockDB";
        public static string LedgerDB = "LedgerDB";
        public static string TransDB = "TransDB";
        //public static string TempDB = "TempDB";
        //public static string TaxDB = "TaxDB";            
        public static string Yes = "Yes";
        public static string Item = "Item";
        public static string HSN = "HSN";
        public static string Job = "Work";
        public static string Service = "Serve";
        public static string Hash = "#####";
        public static string MKey = "Master";
        public static List<char> Alpha = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'X', 'Y', 'Z' };
        int[] a = { 1, 2, 3 };
             
        public static string Ret_Alpha(int index)
        {
            int ind = index - 1;
            try
            {
                //if (ind > Alpha.Count)
                //{
                    
                //    //return Convert.ToString(Alpha[Alpha.Count] + Alpha[ind - Alpha.Count]);
                //}
                string abc = "";
                string alpha(int idx)
                {                    
                    while (idx > 25)
                    {
                        abc += Alpha[24].ToString();
                        idx -= 25;
                    }
                    return abc + Alpha[idx].ToString();
                }                
                return alpha(ind);
            }
            catch (Exception)
            {
                return "";
            }            
        }
        public static string Ret_Alpha(string index)
        {
            try
            {
                return Ret_Alpha(Convert.ToInt32(index));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return "";
            }
        }
        public static string NWR = "No Work";
        public static string NEW = "New";
        public static string VIEW = "View";
        public static string EDIT = "Edit";
        public static string regd = "Registered";
        //public static Unit[] BaseUnit = new Unit[] { meter, kilogram, second, ampere, kelvin, mole, candel };
        //    static Unit meter = new Unit() { Quantity = "Length", name = "meter", symbol = "m" };
        //    static Unit kilogram = new Unit() { Quantity = "Mass", name = "kilogram", symbol = "kg" };
        //    static Unit second = new Unit() { Quantity = "Time", name = "second", symbol = "s" };
        //    static Unit ampere = new Unit() { Quantity = "Electric Current", name = "ampere", symbol = "A" };
        //    static Unit kelvin = new Unit() { Quantity = "Thermodynamic Temperature", name = "kelvin", symbol = "K" };
        //    static Unit mole = new Unit() { Quantity = "Amount of substance", name = "mole", symbol = "mol" };
        //    static Unit candel = new Unit() { Quantity = "Luminous Intensity", name = "candel", symbol = "cd" };
        //public static DriveUnit[] DriveUnit = new DriveUnit[] { };
        //    static DriveUnit hertz = new DriveUnit() { Quantity = "Frequency", name = "meter", symbol = "1/s",formula="1/"+second.Quantity };
        //    static DriveUnit newton = new DriveUnit() { Quantity = "Force", name = "kilogram", symbol = "N", formula = kilogram.Quantity + "*" + meter.Quantity + "*" +"1/("+ second.Quantity + "*" + second.Quantity+")" };
        //    static DriveUnit pascal = new DriveUnit() { Quantity = "Pressure", name = "pascal", symbol = "Pa", formula = newton.Quantity+"*"+"1/("+meter.Quantity+"*"+meter.Quantity+")" };
        //    static DriveUnit joule = new DriveUnit() { Quantity = "Energy", name = "joule", symbol = "J", formula = newton.Quantity+"*"+meter.Quantity };
        //    static DriveUnit coulomb = new DriveUnit() { Quantity = "Electric Charge", name = "coulomb", symbol = "C", formula =second.Quantity +"*"+ampere.Quantity };
        //    static DriveUnit volt = new DriveUnit() { Quantity = "Electric Potential", name = "volt", symbol = "V", formula =watt.Quantity +"/"+ampere.Quantity };
        //    static DriveUnit ohm = new DriveUnit() { Quantity = "Electric Resistanc", name = "ohm", symbol = "ohm", formula = volt.Quantity+"/"+ampere.Quantity };
        //    static DriveUnit degree_Celsius = new DriveUnit() { Quantity = "Celcius Temperature", name = "degree Celcius", symbol = "C", formula =kelvin.Quantity+ "-273.15" };
        //    static DriveUnit watt = new DriveUnit() { Quantity = "Power", name = "watt", symbol = "W", formula = joule.Quantity+"/"+second.Quantity };
        public static List<string> uniontertory = new List<string> { };

        public static string challan { get { return "Challan"; }}
        public static string strbrk { get { return "$"; } }

        public static string Catrgory { get { return "Category"; } }

        public static string Credit { get { return "Credit"; } }
        public static string Debit { get { return "Debit"; } }

        static CompanyFdt GND()
        {
            CompanyFdt ss = new CompanyFdt();
            ss.callby = "Supplier";
            ss.callas = "Bill";
            ss.Sell = false;
            ss.Type = "Main";
            ss.mode = Constant.NEW;
            return ss;
        }
        public static CompanyFdt AddCompany()
        {
            CompanyFdt ss = new CompanyFdt();
            ss = GND();
            ss.mode = Constant.NEW;
            ss.callby = "Company";
            ss.Type = "Main";
            return ss;
        }
        public static CompanyFdt ViewCompany()
        {
            CompanyFdt ss = new CompanyFdt();
            ss = AddCompany();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static CompanyFdt AddParty()
        {
            CompanyFdt ss = new CompanyFdt();
            ss = GND();
            ss.mode = Constant.NEW;
            ss.callby = "Party";
            return ss;
        }
        public static CompanyFdt ViewParty()
        {
            CompanyFdt ss = new CompanyFdt();
            ss = AddParty();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static CompanyFdt AddCreditor()
        {
            CompanyFdt ss = new CompanyFdt();
            ss = GND();
            ss.mode = Constant.NEW;
            ss.Type = "Creditor";
            ss.callby = "Party";
            return ss;
        }
        public static CompanyFdt ViewCreditor()
        {
            CompanyFdt ss = new CompanyFdt();
            ss = AddCreditor();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static CompanyFdt AddDebitor()
        {
            CompanyFdt ss = new CompanyFdt();
            ss = GND();
            ss.mode = Constant.NEW;
            ss.Type = "Debitor";
            ss.callby = "Party";
            return ss;
        }
        public static CompanyFdt ViewDebitor()
        {
            CompanyFdt ss = new CompanyFdt();
            ss = AddDebitor();
            ss.mode = Constant.VIEW;
            return ss;
        }
       
        static BillFdt BFGND()
        {
            BillFdt ss = new BillFdt();
            ss.callas = "Bill";
            ss.callby = "Debitor";
            ss.lblHead = "Tax Invoice";
            ss.mode = Constant.NEW;
            ss.Sell = true;
            ss.Type = Constant.Item;
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id))+ TranDB.t_Sell_Bill_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Bill_D_T;
            ss.InsertBT = TranDB.Insert_Sell_Bill_T;
            ss.InsertBDT = TranDB.Insert_Sell_Bill_D_T;
            return ss;
        }
        public static BillFdt BuyItem()
        {
            BillFdt ss = new BillFdt();
            ss = BFGND();
            ss.callby = "Creditor";
            ss.lblHead = "Tax Bill";
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Bill_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Bill_D_T;
            ss.Sell = false;
            ss.InsertBT = TranDB.Insert_Purchase_Bill_T;
            ss.InsertBDT = TranDB.Insert_Purchase_Bill_D_T;
            return ss;
        }
        public static BillFdt BuyService()
        {
            BillFdt ss = new BillFdt();
            ss = BuyItem();
            ss.callby = "Creditor";
            ss.Type = Constant.Service;
            return ss;
        }       
        public static BillFdt SellItem()
        {
            BillFdt ss = new BillFdt();   
            ss = BFGND();
            ss.id = "105";   
            return ss;
        }
        public static BillFdt SellService()
        {
            BillFdt ss = new BillFdt();
            ss = SellItem();
            ss.Type = Constant.Service;
            ss.callby = "Debitor";
            return ss;
        }
        public static BillFdt VBitem()
        {
            BillFdt ss = new BillFdt();
            ss = BuyItem();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static BillFdt VBservice()
        {
            BillFdt ss = new BillFdt();
            ss = BuyService();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static BillFdt VSitem()
        {
            BillFdt ss = new BillFdt();
            ss = SellItem();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static BillFdt VSservice()
        {
            BillFdt ss = new BillFdt();
            ss = SellService();
            ss.mode = Constant.VIEW;
            return ss;
        }
        //challan
        static BillFdt ChBFGND()
        {
            BillFdt ss = new BillFdt();
            ss.callas = challan;
            ss.callby = "Debitor";
            ss.lblHead = "Challan";
            ss.mode = Constant.NEW;
            ss.Sell = true;
            ss.Type = Constant.Item;           
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Challan_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Challan_D_T;
            ss.InsertBT = TranDB.Insert_Sell_Challan_T;
            ss.InsertBDT = TranDB.Insert_Sell_Challan_D_T;
            return ss;
        }
        public static BillFdt ChBuyItem()
        {
            BillFdt ss = new BillFdt();
            ss = ChBFGND();
            ss.callby = "Creditor";
            ss.lblHead = "Challan";
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Challan_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Challan_D_T;
            ss.Sell = false;
            ss.InsertBT = TranDB.Insert_Purchase_Challan_T;
            ss.InsertBDT = TranDB.Insert_Purchase_Challan_D_T;
            return ss;
        }
        public static BillFdt ChBuyService()
        {
            BillFdt ss = new BillFdt();
            ss = ChBuyItem();            
            ss.Type = Constant.Service;
            return ss;
        }
        public static BillFdt ChSellItem()
        {
            BillFdt ss = new BillFdt();
            ss = ChBFGND();           
            return ss;
        }
        public static BillFdt ChSellService()
        {
            BillFdt ss = new BillFdt();
            ss = ChSellItem();
            ss.Type = Constant.Service;            
            return ss;
        }
        public static BillFdt ChVBitem()
        {
            BillFdt ss = new BillFdt();
            ss = ChBuyItem();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static BillFdt ChVBservice()
        {
            BillFdt ss = new BillFdt();
            ss = ChBuyService();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static BillFdt ChVSitem()
        {
            BillFdt ss = new BillFdt();
            ss = ChSellItem();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static BillFdt ChVSservice()
        {
            BillFdt ss = new BillFdt();
            ss = ChSellService();
            ss.mode = Constant.VIEW;
            return ss;
        }

        static JBillFdt JBFGND()
        {
            JBillFdt ss = new JBillFdt();
            ss.callas = "Bill";
            ss.callby = "Debitor";
            ss.lblHead = "Tax Invoice";
            ss.mode = Constant.NEW;
            ss.Sell = true;
            ss.Type = Constant.Job;
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Job_Bill_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Job_Bill_D_T;
            ss.InsertBT = TranDB.Insert_Sell_Job_Bill_T;
            ss.InsertBDT = TranDB.Insert_Sell_Job_Bill_D_T;
            return ss;
        }
        public static JBillFdt SellJob()
        {
            JBillFdt ss = new JBillFdt();
            ss = JBFGND();
            return ss;
        }
        public static JBillFdt BuyJob()
        {
            JBillFdt ss = new JBillFdt();
            ss = SellJob();
            ss.Sell = false;
            ss.callby = "Creditor";
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Job_Bill_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Job_Bill_D_T;
            ss.InsertBT = TranDB.Insert_Purchase_Job_Bill_T;
            ss.InsertBDT = TranDB.Insert_Purchase_Job_Bill_D_T;
            ss.Type = Constant.Job;
            return ss;
        }
        public static JBillFdt VBjob()
        {
            JBillFdt ss = new JBillFdt();
            ss = BuyJob();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static JBillFdt VSjob()
        {
            JBillFdt ss = new JBillFdt();
            ss = SellJob();
            ss.mode = Constant.VIEW;
            return ss;
        }
        //Challan
        static JBillFdt ChJBFGND()
        {
            JBillFdt ss = new JBillFdt();
            ss.callas = challan;
            ss.callby = "Debitor";
            ss.lblHead = "Challan";
            ss.mode = Constant.NEW;
            ss.Sell = true;
            ss.Type = Constant.Job;
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Job_Bill_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Job_Bill_D_T;
            ss.InsertBT = TranDB.Insert_Sell_Job_Bill_T;
            ss.InsertBDT = TranDB.Insert_Sell_Job_Bill_D_T;
            return ss;
        }
        public static JBillFdt ChSellJob()
        {
            JBillFdt ss = new JBillFdt();
            ss = ChJBFGND();
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Job_Challan_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Job_Challan_D_T;
            ss.InsertBT = TranDB.Insert_Sell_Job_Challan_T;
            ss.InsertBDT = TranDB.Insert_Sell_Job_Challan_D_T;
            return ss;
        }
        public static JBillFdt ChBuyJob()
        {
            JBillFdt ss = new JBillFdt();
            ss = ChSellJob();
            ss.Sell = false;
            ss.callby = "Creditor";
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Job_Challan_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Job_Challan_D_T;
            ss.InsertBT = TranDB.Insert_Purchase_Job_Challan_T;
            ss.InsertBDT = TranDB.Insert_Purchase_Job_Challan_D_T;
            return ss;
        }
        public static JBillFdt ChVBjob()
        {
            JBillFdt ss = new JBillFdt();
            ss = ChBuyJob();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static JBillFdt ChVSjob()
        {
            JBillFdt ss = new JBillFdt();
            ss = ChSellJob();
            ss.mode = Constant.VIEW;
            return ss;
        }

        static ReturnFdt RetTGND()
        {
            ReturnFdt ss = new ReturnFdt();
            ss.callas = "Note";
            ss.callby = "Debitor";
            ss.lblHead = "Credit Note";
            ss.Sell = true;
            ss.mode = Constant.NEW;
            ss.Type = Constant.Item;
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Resturn_Note_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Resturn_Note_D_T;
            ss.Rtname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Bill_T;
            ss.Rtname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Bill_D_T;
            ss.InsertBT = TranDB.Insert_Sell_Resturn_Note_T;
            ss.InsertBDT = TranDB.Insert_Sell_Resturn_Note_D_T;    
            return ss;
        }
        public static ReturnFdt BuyRetItem()
        {
            ReturnFdt ss = new ReturnFdt();
            ss = RetTGND();
            ss.Sell = false;
            ss.lblHead = "Debit Note";
            ss.callby = "Creditor";
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Resturn_Note_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Resturn_Note_D_T;
            ss.Rtname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Bill_T;
            ss.Rtname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Bill_D_T;

            ss.InsertBT = TranDB.Insert_Purchase_Resturn_Note_T;
            ss.InsertBDT = TranDB.Insert_Purchase_Resturn_Note_D_T;
            return ss;
        }
        public static ReturnFdt BuyRetService()
        {
            ReturnFdt ss = new ReturnFdt();
            ss = BuyRetItem();
            ss.Type = Constant.Service;
            return ss;
        }        
        public static ReturnFdt SellRetItem()
        {
            ReturnFdt ss = new ReturnFdt();
            ss = RetTGND();            
            return ss;
        }
        public static ReturnFdt SellRetService()
        {
            ReturnFdt ss = new ReturnFdt();
            ss = SellRetItem();
            ss.Type = Constant.Service;            
            return ss;
        }
        public static ReturnFdt VBRetItem()
        {
            ReturnFdt ss = new ReturnFdt();
            ss = BuyRetItem();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static ReturnFdt VBRetService()
        {
            ReturnFdt ss = new ReturnFdt();
            ss = BuyRetService();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static ReturnFdt VSRetItem()
        {
            ReturnFdt ss = new ReturnFdt();
            ss = SellRetItem();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static ReturnFdt VSRetService()
        {
            ReturnFdt ss = new ReturnFdt();
            ss = SellRetService();
            ss.mode = Constant.VIEW;
            return ss;
        }
        //challan
        static ReturnFdt ChRetTGND()
        {
            ReturnFdt ss = new ReturnFdt();
            ss.callas = challan;
            ss.callby = "Debitor";
            ss.lblHead = "Credit Challan";
            ss.Sell = true;
            ss.mode = Constant.NEW;
            ss.Type = Constant.Item;
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Resturn_Challan_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Resturn_Challan_D_T;
            ss.Rtname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Challan_T;
            ss.Rtname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Challan_D_T;
            ss.InsertBT = TranDB.Insert_Sell_Resturn_Challan_T;
            ss.InsertBDT = TranDB.Insert_Sell_Resturn_Challan_D_T;
            return ss;
        }
        public static ReturnFdt ChBuyRetItem()
        {
            ReturnFdt ss = new ReturnFdt();
            ss = ChRetTGND();
            ss.callby = "Creditor";
            ss.Sell = false;
            ss.lblHead = "Debit Challan";
            ss.callas = Constant.challan;
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Resturn_Challan_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Resturn_Challan_D_T;
            ss.Rtname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Challan_T;
            ss.Rtname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Challan_D_T;

            ss.InsertBT = TranDB.Insert_Purchase_Resturn_Challan_T;
            ss.InsertBDT = TranDB.Insert_Purchase_Resturn_Challan_D_T;
            return ss;
        }
        public static ReturnFdt ChBuyRetService()
        {
            ReturnFdt ss = new ReturnFdt();
            ss = ChBuyRetItem();
            ss.Type = Constant.Service;
            return ss;
        }
        public static ReturnFdt ChSellRetItem()
        {
            ReturnFdt ss = new ReturnFdt();
            ss = ChRetTGND();           
            return ss;
        }
        public static ReturnFdt ChSellRetService()
        {
            ReturnFdt ss = new ReturnFdt();
            ss = ChSellRetItem();
            ss.Type = Constant.Service;
            return ss;
        }
        public static ReturnFdt ChVBRetItem()
        {
            ReturnFdt ss = new ReturnFdt();
            ss = ChBuyRetItem();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static ReturnFdt ChVBRetService()
        {
            ReturnFdt ss = new ReturnFdt();
            ss = ChBuyRetService();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static ReturnFdt ChVSRetItem()
        {
            ReturnFdt ss = new ReturnFdt();
            ss = ChSellRetItem();
            ss.mode = Constant.VIEW;
            return ss;
        }
        public static ReturnFdt ChVSRetService()
        {
            ReturnFdt ss = new ReturnFdt();
            ss = ChSellRetService();
            ss.mode = Constant.VIEW;
            return ss;
        }

        static JRFdt JRFGND()
        {
            JRFdt ss = new JRFdt();
            ss.callas = "Bill";
            ss.callby = "Creditor";
            ss.lblHead = "Tax Bill";
            ss.Sell = false;
            ss.mode = Constant.NEW;
            ss.Type = Constant.Item;
            ss.Rtname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Job_Bill_T;
            ss.Rtname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Job_Bill_D_T;
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_JobRecieving_Bill_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_JobRecieving_Bill_D_T;
            ss.InsertBT = TranDB.Insert_Purchase_JobRecieving_Bill_T;
            ss.InsertBDT = TranDB.Insert_Purchase_JobRecieving_Bill_D_T;
            return ss;
        }
        public static JRFdt BuyJRecieving()
        {
            JRFdt ss = new JRFdt();
            ss = JRFGND();
            return ss;
        }
        public static JRFdt VBJRecieving()
        {
            JRFdt ss = new JRFdt();
            ss = BuyJRecieving();
            ss.mode = Constant.VIEW;
            return ss;
        }
        //challan
        static JRFdt ChJRFGND()
        {
            JRFdt ss = new JRFdt();
            ss.callas = challan;
            ss.callby = "Creditor";
            ss.lblHead = "Challan";
            ss.Sell = false;
            ss.mode = Constant.NEW;
            ss.Type = Constant.Item;
            ss.Rtname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Job_Challan_T;
            ss.Rtname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Job_Challan_D_T;
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_JobRecieving_Challan_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_JobRecieving_Challan_D_T;
            ss.InsertBT = TranDB.Insert_Purchase_JobRecieving_Challan_T;
            ss.InsertBDT = TranDB.Insert_Purchase_JobRecieving_Challan_D_T;
            return ss;
        }
        public static JRFdt ChBuyJRecieving()
        {
            JRFdt ss = new JRFdt();
            ss = ChJRFGND();
            return ss;
        }
        public static JRFdt ChVBJRecieving()
        {
            JRFdt ss = new JRFdt();
            ss = ChBuyJRecieving();
            ss.mode = Constant.VIEW;
            return ss;
        }

        static C2BillFdt C2BGND()
        {
            C2BillFdt ss = new C2BillFdt();
            ss.callas = "Bill";
            ss.callby = "Debitor";
            ss.lblHead = "Tax Invoice";
            ss.Sell = true;
            ss.mode = Constant.NEW;
            ss.Type = Constant.Item;
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Bill_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Bill_D_T;
            ss.Rtname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Challan_T;
            ss.Rtname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Challan_D_T;
            ss.InsertBT = TranDB.Insert_Sell_Bill_T;
            ss.InsertBDT = TranDB.Insert_Sell_Bill_D_T;
            return ss;
        }
        public static C2BillFdt C2BSellItem()
        {
            C2BillFdt ss = new C2BillFdt();
            ss = C2BGND();
            return ss;
        }
        public static C2BillFdt C2BSellService()
        {
            C2BillFdt ss = new C2BillFdt();
            ss = C2BGND();
            ss.Type = Constant.Service;
            return ss;
        }
        public static C2BillFdt C2BBuyItem()
        {
            C2BillFdt ss = new C2BillFdt();
            ss = C2BGND();
            ss.callby = "Creditor";
            ss.Sell = false;
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Bill_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Bill_D_T;
            ss.Rtname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Challan_T;
            ss.Rtname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Challan_D_T;
            ss.InsertBT = TranDB.Insert_Purchase_Bill_T;
            ss.InsertBDT = TranDB.Insert_Purchase_Bill_D_T;
            return ss;
        }
        public static C2BillFdt C2BBuyService()
        {
            C2BillFdt ss = new C2BillFdt();
            ss = C2BBuyItem();
            ss.Type = Constant.Service;
            return ss;
        }
        public static C2BillFdt C2BSellJob()
        {
            C2BillFdt ss = new C2BillFdt();
            ss = C2BGND();
            ss.Type = Constant.Job;
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Job_Bill_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Job_Bill_D_T;
            ss.Rtname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Job_Challan_T;
            ss.Rtname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Sell_Job_Challan_D_T;
            ss.InsertJBT = TranDB.Insert_Sell_Job_Bill_T;
            ss.InsertJBDT = TranDB.Insert_Sell_Job_Bill_D_T;
            return ss;
        }      
        public static C2BillFdt C2BBuyJob()
        {
            C2BillFdt ss = new C2BillFdt();
            ss = C2BGND();
            ss.Sell = false;
            ss.tname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Job_Bill_T;
            ss.tname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Job_Bill_D_T;
            ss.Rtname1 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Job_Challan_T;
            ss.Rtname2 = Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_Purchase_Job_Challan_D_T;
            TranDB.insert_Job_Bill_T InsertBT = TranDB.Insert_Purchase_Job_Bill_T;
            TranDB.insert_Job_Bill_D_T InsertBDT = TranDB.Insert_Purchase_Job_Bill_D_T;
            return ss;
        }

        //public static C2BillFdt C2BVSellItem()
        //{
        //    C2BillFdt ss = new C2BillFdt();
        //    ss = C2BGND();
        //    ss.mode = Constant.VIEW;
        //    return ss;
        //}
        //public static C2BillFdt C2BVSellService()
        //{
        //    C2BillFdt ss = new C2BillFdt();
        //    ss = C2BGND();
        //    ss.Type = Constant.Service;
        //    ss.mode = Constant.VIEW;
        //    return ss;
        //}
        //public static C2BillFdt C2BVBuyItem()
        //{
        //    C2BillFdt ss = new C2BillFdt();
        //    ss = C2BGND();
        //    ss.Sell = false;
        //    ss.mode = Constant.VIEW;
        //    return ss;
        //}
        //public static C2BillFdt C2BVBuyService()
        //{
        //    C2BillFdt ss = new C2BillFdt();
        //    ss = C2BGND();
        //    ss.Type = Constant.Service;
        //    ss.Sell = false;
        //    ss.mode = Constant.VIEW;
        //    return ss;
        //}
        
    }
    class form_id
    {
        public static int bankdt_fid = 0;
        public static int company_fid = 1;
        public static int ledger_fid = 2;
        public static int login_fid = 3;
        public static int main_fid = 4;
        public static int object_list_fid = 5;
        public static int premain_fid = 6;
        public static int stock_fid = 7;
        public static int billf_fid = 8;
        public static int cash_payment_fid = 9;
        public static int challan_to_bill_fid = 10;
        public static int job_billf_fid = 11;
        public static int jreceivef_fid = 12;
        public static int payment_fid = 13;
        public static int returnf_fid = 14;
        public static int adexitbal_fid = 15;
        public static int adexitjob_fid = 16;
        public static int adexitstock_fid = 17;
        public static int aduser_fid = 18;
    }
    class CompanyDB
    {
        public static string t_Company_T = "Company_T";
        public static class c_Company_T
        {
            public static string f_RegdId = "RegdId";
            public static string f_date_ = "date_";
            public static string f_Name = "Name";
            public static string f_Alias = "Alias";
            public static string f_GSTIN = "GSTIN";
            public static string f_author = "author";
            public static string f_category = "category";
        }
        public delegate bool insert_Company_T(string RegdId, string date_, string Name, string Alias, string GSTIN, string author, string category);
        public static bool Insert_Company_T(string RegdId, string date_, string Name, string Alias, string GSTIN, string author, string category)
        {
            string qurry = "insert into Company_T (RegdId,date_,Name,Alias,GSTIN,author,category) values(@RegdId,@date_,@Name,@Alias,@GSTIN,@author,@category)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@RegdId", RegdId);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@Name", Name);
            cmd.Parameters.Add("@Alias", Alias);
            cmd.Parameters.Add("@GSTIN", GSTIN);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@category", category);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public static string t_Address_T = "Address_T";
        public static class c_Address_T
        {
            public static string f_addri_fkey = "addri_fkey";
            public static string f_addr_table = "addr_table";
            public static string f_address = "address";
            public static string f_city = "city";
            public static string f_district = "district";
            public static string f_state = "state";
            public static string f_pincode = "pincode";
        }
        public delegate bool insert_Address_T(string addri_fkey, string addr_table, string address, string city, string district, string state, string pincode);
        public static bool Insert_Address_T(string addri_fkey, string addr_table, string address, string city, string district, string state, string pincode)
        {
            string qurry = "insert into Address_T (addri_fkey,addr_table,address,city,district,state,pincode) values(@addri_fkey,@addr_table,@address,@city,@district,@state,@pincode)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@addri_fkey", addri_fkey);
            cmd.Parameters.Add("@addr_table", addr_table);
            cmd.Parameters.Add("@address", address);
            cmd.Parameters.Add("@city", city);
            cmd.Parameters.Add("@district", district);
            cmd.Parameters.Add("@state", state);
            cmd.Parameters.Add("@pincode", pincode);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public static string t_Category_T = "Category_T";
        public static class c_Category_T
        {
            public static string f_Name = "Name";
            public static string f_date_ = "date_";
            public static string f_sub = "sub";
            public static string f_LedgerReq = "LedgerReq";
        }
        public static bool Insert_Category_T(string Name, string date_, string sub, string LedgerReq)
        {
            string qurry = "insert into Category_T (Name,date_,sub,LedgerReq) values(@Name,@date_,@sub,@LedgerReq)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@Name", Name);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@sub", sub);
            cmd.Parameters.Add("@LedgerReq", LedgerReq);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public static string t_Bank_T = "Bank_T";
        public static class c_Bank_T
        {
            public static string f_holder_fkey = "holder_fkey";
            public static string f_holder_table = "holder_table";
            public static string f_bank_name = "bank_name";
            public static string f_Name = "Name";
            public static string f_AccountNo = "AccountNo";
            public static string f_IFSC = "IFSC";
        }
        public static bool Insert_Bank_T(string holder_fkey, string holder_table, string bank_name, string Name, string AccountNo, string IFSC)
        {
            string qurry = "insert into Bank_T (holder_fkey,holder_table,bank_name,Name,AccountNo,IFSC) values(@holder_fkey,@holder_table,@bank_name,@Name,@AccountNo,@IFSC)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@holder_fkey", holder_fkey);
            cmd.Parameters.Add("@holder_table", holder_table);
            cmd.Parameters.Add("@bank_name", bank_name);
            cmd.Parameters.Add("@Name", Name);
            cmd.Parameters.Add("@AccountNo", AccountNo);
            cmd.Parameters.Add("@IFSC", IFSC);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public static string t_Person_T = "Person_T";
        public static class c_Person_T
        {
            public static string f_Designation = "Designation";
            public static string f_Enroll_Id = "Enroll_Id";
            public static string f_fisrt_name = "fisrt_name";
            public static string f_last_name = "last_name";
            public static string f_date_ = "date_";
            public static string f_DOB = "DOB";
            public static string f_sex = "sex";
            public static string f_nationality = "nationality";
        }
        public static bool Insert_Person_T(string Designation, string Enroll_Id, string fisrt_name, string last_name, string date_, string DOB, string sex, string nationality)
        {
            string qurry = "insert into Person_T (Designation,Enroll_Id,fisrt_name,last_name,date_,DOB,sex,nationality) values(@Designation,@Enroll_Id,@fisrt_name,@last_name,@date_,@DOB,@sex,@nationality)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@Designation", Designation);
            cmd.Parameters.Add("@Enroll_Id", Enroll_Id);
            cmd.Parameters.Add("@fisrt_name", fisrt_name);
            cmd.Parameters.Add("@last_name", last_name);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@DOB", DOB);
            cmd.Parameters.Add("@sex", sex);
            cmd.Parameters.Add("@nationality", nationality);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public static string t_Employee_T = "Employee_T";
        public static class c_Employee_T
        {
            public static string f_person_fkey = "person_fkey";
            public static string f_salary = "salary";
            public static string f_isActive = "isActive";
        }
        public static bool Insert_Employee_T(string person_fkey, string salary, string isActive)
        {
            string qurry = "insert into Employee_T (person_fkey,salary,isActive) values(@person_fkey,@salary,@isActive)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@person_fkey", person_fkey);
            cmd.Parameters.Add("@salary", salary);
            cmd.Parameters.Add("@isActive", isActive);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public static string t_Contact_T = "Contact_T";
        public static class c_Contact_T
        {
            public static string f_holder_fkey = "holder_fkey";
            public static string f_holder_table = "holder_table";
            public static string f_name = "name";
            public static string f_phone = "phone";
            public static string f_email = "email";
            public static string f_website = "website";
        }
        public static bool Insert_Contact_T(string holder_fkey, string holder_table, string name, string phone, string email, string website)
        {
            string qurry = "insert into Contact_T (holder_fkey,holder_table,name,phone,email,website) values(@holder_fkey,@holder_table,@name,@phone,@email,@website)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@holder_fkey", holder_fkey);
            cmd.Parameters.Add("@holder_table", holder_table);
            cmd.Parameters.Add("@name", name);
            cmd.Parameters.Add("@phone", phone);
            cmd.Parameters.Add("@email", email);
            cmd.Parameters.Add("@website", website);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public static string t_Image_T = "Image_T";
        public static class c_Image_T
        {
            public static string f_object_fkey = "object_fkey";
            public static string f_object_table = "object_table";
            public static string f_image = "image";
            public static string f_description = "description";
        }
        public static bool Insert_Image_T(string object_fkey, string object_table, byte[] image, string description)
        {
            string qurry = "insert into Image_T (object_fkey,object_table,image,description) values(@object_fkey,@object_table,@image,@description)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@object_fkey", object_fkey);
            cmd.Parameters.Add("@object_table", object_table);
            cmd.Parameters.Add("@image", image);
            cmd.Parameters.Add("@description", description);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public static string t_Login_T = "Login_T";
        public static class c_Login_T
        {
            public static string f_date_ = "date_";
            public static string f_Name = "Name";
            public static string f_LoginID = "LoginID";
            public static string f_Password = "Password";
            public static string f_Type = "Type";
        }
        public static bool Insert_Login_T(string date_, string Name, string LoginID, string Password, string Type)
        {
            string qurry = "insert into Login_T (date_,Name,LoginID,Password,Type) values(@date_,@Name,@LoginID,@Password,@Type)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@Name", Name);
            cmd.Parameters.Add("@LoginID", LoginID);
            cmd.Parameters.Add("@Password", Password);
            cmd.Parameters.Add("@Type", Type);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
    }
    class StockDB
    {
        public static string t_Item_T = "Item_T";
        public static class c_Item_T
        {
            public static string f_stockId = "stockId";
            public static string f_stock_no = "stock_no";
            public static string f_HSN = "HSN";
            public static string f_date_ = "date_";
            public static string f_Name = "Name";
            public static string f_description = "description";
            public static string f_category = "category";
            public static string f_supplier_fkey = "supplier_fkey";
            public static string f_author = "author";
            public static string f_Unit = "Unit";
            public static string f_LedgerReq = "LedgerReq";
        }
        public static bool Insert_Item_T(string stockId, string stock_no,string HSN, string date_, string Name, string description, string category, string supplier_fkey, string author, string Unit, string LedgerReq)
        {
            string qurry = "insert into Item_T (stockId,stock_no,HSN,date_,Name,description,category,supplier_fkey,author,Unit,LedgerReq) values(@stockId,@stock_no,@HSN,@date_,@Name,@description,@category,@supplier_fkey,@author,@Unit,@LedgerReq)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@stockId", stockId);
            cmd.Parameters.Add("@stock_no", stock_no);
            cmd.Parameters.Add("@HSN", HSN);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@Name", Name);
            cmd.Parameters.Add("@description", description);
            cmd.Parameters.Add("@category", category);
            cmd.Parameters.Add("@supplier_fkey", supplier_fkey);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@Unit", Unit);
            cmd.Parameters.Add("@LedgerReq", LedgerReq);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public static string t_Service_T = "Service_T";
        public static class c_Service_T
        {
            public static string f_stockId = "stockId";
            public static string f_SAC = "SAC";
            public static string f_date_ = "date_";
            public static string f_Name = "Name";
            public static string f_description = "description";
            public static string f_category = "category";
            public static string f_supplier_fkey = "supplier_fkey";
            public static string f_author = "author";
            public static string f_Unit = "Unit";
            public static string f_LedgerReq = "LedgerReq";
        }
        public static bool Insert_Service_T(string stockId, string SAC, string date_, string Name, string description, string category, string supplier_fkey, string author, string Unit, string LedgerReq)
        {
            string qurry = "insert into Service_T (stockId,SAC,date_,Name,description,category,supplier_fkey,author,Unit,LedgerReq) values(@stockId,@SAC,@date_,@Name,@description,@category,@supplier_fkey,@author,@Unit,@LedgerReq)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@stockId", stockId);
            cmd.Parameters.Add("@SAC", SAC);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@Name", Name);
            cmd.Parameters.Add("@description", description);
            cmd.Parameters.Add("@category", category);
            cmd.Parameters.Add("@supplier_fkey", supplier_fkey);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@Unit", Unit);
            cmd.Parameters.Add("@LedgerReq", LedgerReq);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public static string t_Job_T = "Job_T";
        public static class c_Job_T
        {
            public static string f_Gen_New_No = "Gen_New_No";
            public static string f_stockId = "stockId";
            public static string f_SAC = "SAC";
            public static string f_date_ = "date_";
            public static string f_Name = "Name";
            public static string f_description = "description";
            public static string f_category = "category";
            public static string f_supplier_fkey = "supplier_fkey";
            public static string f_author = "author";
            public static string f_Unit = "Unit";
            public static string f_LedgerReq = "LedgerReq";
        }
        public static bool Insert_Job_T(string Gen_New_No, string stockId, string SAC, string date_, string Name, string description, string category, string supplier_fkey, string author, string Unit, string LedgerReq)
        {
            string qurry = "insert into Job_T (Gen_New_No,stockId,SAC,date_,Name,description,category,supplier_fkey,author,Unit,LedgerReq) values(@Gen_New_No,@stockId,@SAC,@date_,@Name,@description,@category,@supplier_fkey,@author,@Unit,@LedgerReq)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@Gen_New_No", Gen_New_No);
            cmd.Parameters.Add("@stockId", stockId);
            cmd.Parameters.Add("@SAC", SAC);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@Name", Name);
            cmd.Parameters.Add("@description", description);
            cmd.Parameters.Add("@category", category);
            cmd.Parameters.Add("@supplier_fkey", supplier_fkey);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@Unit", Unit);
            cmd.Parameters.Add("@LedgerReq", LedgerReq);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public static string t_Image_T = "Image_T";
        public static class c_Image_T
        {
            public static string f_object_fkey = "object_fkey";
            public static string f_object_table = "object_table";
            public static string f_image = "image";
            public static string f_description = "description";
        }
        public static bool Insert_Image_T(string object_fkey, string object_table, byte[] image, string description)
        {
            string qurry = "insert into Image_T (object_fkey,object_table,image,description) values(@object_fkey,@object_table,@image,@description)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@object_fkey", object_fkey);
            cmd.Parameters.Add("@object_table", object_table);
            cmd.Parameters.Add("@image", image);
            cmd.Parameters.Add("@description", description);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public static string t_rate_T = "rate_T";
        public static class c_rate_T
        {
            public static string f_item_fkey = "item_fkey";
            public static string f_item_table = "item_table";
            public static string f_docID_fkey = "docID_fkey";
            public static string f_rate_ = "rate_";
            public static string f_reason = "reason";
        }
        public static bool Insert_rate_T(string item_fkey, string item_table, string docID_fkey, string rate_, string reason)
        {
            string qurry = "insert into rate_T (item_fkey,item_table,docID_fkey,rate_,reason) values(@item_fkey,@item_table,@docID_fkey,@rate_,@reason)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@item_fkey", item_fkey);
            cmd.Parameters.Add("@item_table", item_table);
            cmd.Parameters.Add("@docID_fkey", docID_fkey);
            cmd.Parameters.Add("@rate_", rate_);
            cmd.Parameters.Add("@reason", reason);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public static string t_Category_T = "Category_T";
        public static class c_Category_T
        {
            public static string f_Name = "Name";
            public static string f_date_ = "date_";
            public static string f_sub = "sub";
            public static string f_LedgerReq = "LedgerReq";
        }
        public static bool Insert_Category_T(string Name, string date_, string sub, string LedgerReq)
        {
            string qurry = "insert into Category_T (Name,date_,sub,LedgerReq) values(@Name,@date_,@sub,@LedgerReq)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StockDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@Name", Name);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@sub", sub);
            cmd.Parameters.Add("@LedgerReq", LedgerReq);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
    }
    public class TranDB
    {
        public static class c_Bill_T
        {
            public static string f_billno = "billno";
            public static string f_date_ = "date_";
            public static string f_beneficiary_fkey = "beneficiary_fkey";
            public static string f_payment_terms = "payment_terms";
            public static string f_ewaybill_no = "ewaybill_no";
            public static string f_agenet = "agenet";
            public static string f_author = "author";
            public static string f_transport = "transport";
            public static string f_Doc_id = "Doc_id";
            public static string f_transportation_charge = "transportation_charge";
            public static string f_packaging = "packaging";
        }
        public static class c_Bill_D_T
        {
            public static string f_bill_ID_fkey = "bill_ID_fkey";
            public static string f_item_no_fkey = "item_no_fkey";
            public static string f_rate = "rate";
            public static string f_discount_rate = "discount_rate";
            public static string f_qnty = "qnty";
            public static string f_challan_fkey = "challan_fkey";
            public static string f_grqnty = "grqnty";
        }

        public static string t_Sell_Bill_T = "Sell_Bill_T";

        public static string t_Sell_Bill_D_T = "Sell_Bill_D_T";

        public static string t_Sell_Challan_T = "Sell_Challan_T";

        public static string t_Sell_Challan_D_T = "Sell_Challan_D_T";

        public static string t_Purchase_Bill_T = "Purchase_Bill_T";

        public static string t_Purchase_Bill_D_T = "Purchase_Bill_D_T";

        public static string t_Purchase_Challan_T = "Purchase_Challan_T";

        public static string t_Purchase_Challan_D_T = "Purchase_Challan_D_T";


        public static class c_Resturn_Note_T
        {
            public static string f_noteno = "noteno";
            public static string f_date_ = "date_";
            public static string f_beneficiary_fkey = "beneficiary_fkey";
            public static string f_reference = "reference";
            public static string f_author = "author";
            public static string f_transport = "transport";
            public static string f_Doc_id = "Doc_id";
            public static string f_transportation_charge = "transportation_charge";
            public static string f_packaging = "packaging";
        }
        public static class c_Resturn_Note_D_T
        {
            public static string f_noteno_fkey = "noteno_fkey";
            public static string f_bill_ID_fkey = "bill_ID_fkey";
            public static string f_item_no_fkey = "item_no_fkey";
            public static string f_rate = "rate";
            public static string f_discount_rate = "discount_rate";
            public static string f_qnty = "qnty";
            public static string f_challan_fkey = "challan_fkey";
            public static string f_grqnty = "grqnty";
        }

        public static string t_Purchase_Resturn_Note_T = "Purchase_Resturn_Note_T";

        public static string t_Purchase_Resturn_Note_D_T = "Purchase_Resturn_Note_D_T";

        public static string t_Purchase_Resturn_Challan_T = "Purchase_Resturn_Challan_T";

        public static string t_Purchase_Resturn_Challan_D_T = "Purchase_Resturn_Challan_D_T";

        public static string t_Sell_Resturn_Note_T = "Sell_Resturn_Note_T";

        public static string t_Sell_Resturn_Note_D_T = "Sell_Resturn_Note_D_T";

        public static string t_Sell_Resturn_Challan_T = "Sell_Resturn_Challan_T";

        public static string t_Sell_Resturn_Challan_D_T = "Sell_Resturn_Challan_D_T";

        public static class c_Job_Bill_T
        {
            public static string f_goodsValue = "goodsValue";
            public static string f_billno = "billno";
            public static string f_date_ = "date_";
            public static string f_beneficiary_fkey = "beneficiary_fkey";
            public static string f_payment_terms = "payment_terms";
            public static string f_ewaybill_no = "ewaybill_no";
            public static string f_agenet = "agenet";
            public static string f_author = "author";
            public static string f_transport = "transport";
            public static string f_Doc_id = "Doc_id";
            public static string f_transportation_charge = "transportation_charge";
            public static string f_packaging = "packaging";
        }
        public static class c_Job_Bill_D_T
        {
            public static string f_recieved = "recieved";
            public static string f_job_fkey = "job_fkey";
            public static string f_bill_ID_fkey = "bill_ID_fkey";
            public static string f_item_no_fkey = "item_no_fkey";
            public static string f_rate = "rate";
            public static string f_discount_rate = "discount_rate";
            public static string f_qnty = "qnty";
            public static string f_challan_fkey = "challan_fkey";
            public static string f_grqnty = "grqnty";
        }

        public static string t_Sell_Job_Bill_T = "Sell_Job_Bill_T";

        public static string t_Sell_Job_Bill_D_T = "Sell_Job_Bill_D_T";

        public static string t_Sell_Job_Challan_T = "Sell_Job_Challan_T";

        public static string t_Sell_Job_Challan_D_T = "Sell_Job_Challan_D_T";

        public static string t_Purchase_Job_Bill_T = "Purchase_Job_Bill_T";

        public static string t_Purchase_Job_Bill_D_T = "Purchase_Job_Bill_D_T";

        public static string t_Purchase_Job_Challan_T = "Purchase_Job_Challan_T";

        public static string t_Purchase_Job_Challan_D_T = "Purchase_Job_Challan_D_T";


        public static class c_JobRecieving_Bill_T
        {
            public static string f_bill_fkey = "bill_fkey";
            public static string f_billno = "billno";
            public static string f_date_ = "date_";
            public static string f_beneficiary_fkey = "beneficiary_fkey";
            public static string f_payment_terms = "payment_terms";
            public static string f_ewaybill_no = "ewaybill_no";
            public static string f_agenet = "agenet";
            public static string f_author = "author";
            public static string f_transport = "transport";
            public static string f_Doc_id = "Doc_id";
            public static string f_transportation_charge = "transportation_charge";
            public static string f_packaging = "packaging";
        }
        public static class c_JobRecieving_Bill_D_T
        {
            public static string f_job_fkey = "job_fkey";
            public static string f_bill_ID_fkey = "bill_ID_fkey";
            public static string f_item_no_fkey = "item_no_fkey";
            public static string f_rate = "rate";
            public static string f_discount_rate = "discount_rate";
            public static string f_qnty = "qnty";
            public static string f_challan_fkey = "challan_fkey";
            public static string f_grqnty = "grqnty";
        }

        public static string t_Purchase_JobRecieving_Bill_T = "Purchase_JobRecieving_Bill_T";

        public static string t_Purchase_JobRecieving_Bill_D_T = "Purchase_JobRecieving_Bill_D_T";

        public static string t_Purchase_JobRecieving_Challan_T = "Purchase_JobRecieving_Challan_T";

        public static string t_Purchase_JobRecieving_Challan_D_T = "Purchase_JobRecieving_Challan_D_T";
        public static class c_Payment_T
        {
            public static string f_receipt = "receipt";
            public static string f_date_ = "date_";
            public static string f_beneficiary_fkey = "beneficiary_fkey";
            public static string f_mode = "mode";
            public static string f_collector = "collector";
            public static string f_reference = "reference";
            public static string f_author = "author";
        }
        public static class c_Payment_D_T
        {
            public static string f_pay_fkey = "pay_fkey";
            public static string f_date_ = "date_";
            public static string f_bank = "bank";
            public static string f_transaction_ID = "transaction_ID";
            public static string f_amount = "amount";
        }

        public static string t_Purchase_Payment_T = "Purchase_Payment_T";

        public static string t_Purchase_Payment_D_T = "Purchase_Payment_D_T";

        public static string t_Sell_Payment_T = "Sell_Payment_T";

        public static string t_Sell_Payment_D_T = "Sell_Payment_D_T";

        public static string t_IGST = "IGST";
        public static class c_IGST
        {
            public static string f_doc_table = "doc_table";
            public static string f_isRC = "isRC";
            public static string f_inward = "inward";
            public static string f_isRegBene = "isRegBene";
            public static string f_date_ = "date_";
            public static string f_particular = "particular";
            public static string f_folio = "folio";
            public static string f_credit = "credit";
            public static string f_debit = "debit";
        }

        public static string t_CGST = "CGST";
        public static class c_CGST
        {
            public static string f_doc_table = "doc_table";
            public static string f_isRC = "isRC";
            public static string f_inward = "inward";
            public static string f_isRegBene = "isRegBene";
            public static string f_date_ = "date_";
            public static string f_particular = "particular";
            public static string f_folio = "folio";
            public static string f_credit = "credit";
            public static string f_debit = "debit";
        }

        public static string t_SGST = "SGST";
        public static class c_SGST
        {
            public static string f_doc_table = "doc_table";
            public static string f_isRC = "isRC";
            public static string f_inward = "inward";
            public static string f_isRegBene = "isRegBene";
            public static string f_date_ = "date_";
            public static string f_particular = "particular";
            public static string f_folio = "folio";
            public static string f_credit = "credit";
            public static string f_debit = "debit";
        }

        public static string t_UGST = "UGST";
        public static class c_UGST
        {
            public static string f_doc_table = "doc_table";
            public static string f_isRC = "isRC";
            public static string f_inward = "inward";
            public static string f_isRegBene = "isRegBene";
            public static string f_date_ = "date_";
            public static string f_particular = "particular";
            public static string f_folio = "folio";
            public static string f_credit = "credit";
            public static string f_debit = "debit";
        }

        public static string t_CESS = "CESS";
        public static class c_CESS
        {
            public static string f_doc_table = "doc_table";
            public static string f_isRC = "isRC";
            public static string f_inward = "inward";
            public static string f_isRegBene = "isRegBene";
            public static string f_date_ = "date_";
            public static string f_particular = "particular";
            public static string f_folio = "folio";
            public static string f_credit = "credit";
            public static string f_debit = "debit";
        }
        public static string t_FEES = "FEES";
        public static class c_FEES
        {
            public static string f_gstcolmn = "gstcolmn";
            public static string f_date_ = "date_";
            public static string f_particular = "particular";
            public static string f_folio = "folio";
            public static string f_credit = "credit";
            public static string f_debit = "debit";
        }

        public static string t_PENALTY = "PENALTY";
        public static class c_PENALTY
        {
            public static string f_gstcolmn = "gstcolmn";
            public static string f_date_ = "date_";
            public static string f_particular = "particular";
            public static string f_folio = "folio";
            public static string f_credit = "credit";
            public static string f_debit = "debit";
        }

        public static string t_INTEREST = "INTEREST";
        public static class c_INTEREST
        {
            public static string f_gstcolmn = "gstcolmn";
            public static string f_date_ = "date_";
            public static string f_particular = "particular";
            public static string f_folio = "folio";
            public static string f_credit = "credit";
            public static string f_debit = "debit";
        }

        public static string t_OTHER = "OTHER";
        public static class c_OTHER
        {
            public static string f_gstcolmn = "gstcolmn";
            public static string f_date_ = "date_";
            public static string f_particular = "particular";
            public static string f_folio = "folio";
            public static string f_credit = "credit";
            public static string f_debit = "debit";
        }
        
        public static string t_GSTPAY_T = "GSTPAY_T";
        public static class c_GSTPAY_T
        {
            public static string f_date = "date";
            public static string f_ARN = "ARN";
            public static string f_igst = "igst";
            public static string f_cgst = "cgst";
            public static string f_sgst = "sgst";
            public static string f_ugst = "ugst";
            public static string f_cess = "cess";
            public static string f_feesigst = "feesigst";
            public static string f_feescgst = "feescgst";
            public static string f_feessgst = "feessgst";
            public static string f_feesugst = "feesugst";
            public static string f_feescess = "feescess";
            public static string f_penaltyigst = "penaltyigst";
            public static string f_penaltycgst = "penaltycgst";
            public static string f_penaltysgst = "penaltysgst";
            public static string f_penaltyugst = "penaltyugst";
            public static string f_penaltycess = "penaltycess";
            public static string f_interestigst = "interestigst";
            public static string f_interestcgst = "interestcgst";
            public static string f_interestsgst = "interestsgst";
            public static string f_interestugst = "interestugst";
            public static string f_interestcess = "interestcess";
            public static string f_otherigst = "otherigst";
            public static string f_othercgst = "othercgst";
            public static string f_othersgst = "othersgst";
            public static string f_otherugst = "otherugst";
            public static string f_othercess = "othercess";
            public static string f_amount = "amount";
            public static string f_com_id = "com_id";
        }

        public delegate bool insert_bill_T(string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging);
        public delegate bool insert_bill_D_T(string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey);
        public static bool Insert_Sell_Bill_T(string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Sell_Bill_T (billno,date_,beneficiary_fkey,payment_terms,ewaybill_no,agenet,author,transport,Doc_id,transportation_charge,packaging) values(@billno,@date_,@beneficiary_fkey,@payment_terms,@ewaybill_no,@agenet,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TransDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@billno", billno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@payment_terms", payment_terms);
            cmd.Parameters.Add("@ewaybill_no", ewaybill_no);
            cmd.Parameters.Add("@agenet", agenet);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Sell_Bill_D_T(string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Sell_Bill_D_T (bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TransDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            int zero = 0;
            cmd.Parameters.Add("@grqnty", zero);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Sell_Challan_T(string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Sell_Challan_T (billno,date_,beneficiary_fkey,payment_terms,ewaybill_no,agenet,author,transport,Doc_id,transportation_charge,packaging) values(@billno,@date_,@beneficiary_fkey,@payment_terms,@ewaybill_no,@agenet,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TransDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@billno", billno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@payment_terms", payment_terms);
            cmd.Parameters.Add("@ewaybill_no", ewaybill_no);
            cmd.Parameters.Add("@agenet", agenet);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Sell_Challan_D_T(string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Sell_Challan_D_T (bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TransDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            int zero = 0;
            cmd.Parameters.Add("@grqnty", zero);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Purchase_Bill_T(string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_Bill_T (billno,date_,beneficiary_fkey,payment_terms,ewaybill_no,agenet,author,transport,Doc_id,transportation_charge,packaging) values(@billno,@date_,@beneficiary_fkey,@payment_terms,@ewaybill_no,@agenet,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TransDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@billno", billno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@payment_terms", payment_terms);
            cmd.Parameters.Add("@ewaybill_no", ewaybill_no);
            cmd.Parameters.Add("@agenet", agenet);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Purchase_Bill_D_T(string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_Bill_D_T (bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TransDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            int zero = 0;
            cmd.Parameters.Add("@grqnty", zero);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Purchase_Challan_T(string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_Challan_T (billno,date_,beneficiary_fkey,payment_terms,ewaybill_no,agenet,author,transport,Doc_id,transportation_charge,packaging) values(@billno,@date_,@beneficiary_fkey,@payment_terms,@ewaybill_no,@agenet,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TransDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@billno", billno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@payment_terms", payment_terms);
            cmd.Parameters.Add("@ewaybill_no", ewaybill_no);
            cmd.Parameters.Add("@agenet", agenet);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Purchase_Challan_D_T(string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_Challan_D_T (bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TransDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            int zero = 0;
            cmd.Parameters.Add("@grqnty", zero);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public delegate bool insert_Resturn_Note_T(string noteno, string date_, string beneficiary_fkey, string reference, string author, string transport, string Doc_id, string transportation_charge, string packaging);
        public delegate bool insert_Resturn_Note_D_T(string noteno_fkey, string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey, string grqnty);
        public static bool Insert_Purchase_Resturn_Note_T(string noteno, string date_, string beneficiary_fkey, string reference, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_Resturn_Note_T (noteno,date_,beneficiary_fkey,reference,author,transport,Doc_id,transportation_charge,packaging) values(@noteno,@date_,@beneficiary_fkey,@reference,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@noteno", noteno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@reference", reference);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Purchase_Resturn_Note_D_T(string noteno_fkey, string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey, string grqnty)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_Resturn_Note_D_T (noteno_fkey,bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@noteno_fkey,@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@noteno_fkey", noteno_fkey);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            cmd.Parameters.Add("@grqnty", grqnty);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            if (rt)
            {
                Update_D_T("TranxDB", Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_Bill_D_T", qnty, bill_ID_fkey, item_no_fkey);
            }
            return rt;
        }
        public static bool Insert_Purchase_Resturn_Challan_T(string noteno, string date_, string beneficiary_fkey, string reference, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_Resturn_Challan_T (noteno,date_,beneficiary_fkey,reference,author,transport,Doc_id,transportation_charge,packaging) values(@noteno,@date_,@beneficiary_fkey,@reference,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@noteno", noteno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@reference", reference);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Purchase_Resturn_Challan_D_T(string noteno_fkey, string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey, string grqnty)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_Resturn_Challan_D_T (noteno_fkey,bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@noteno_fkey,@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@noteno_fkey", noteno_fkey);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            cmd.Parameters.Add("@grqnty", grqnty);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            if (rt)
            {
                Update_D_T("TranxDB", Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_Challan_D_T", qnty, bill_ID_fkey, item_no_fkey);
            }
            return rt;
        }
        public static bool Insert_Sell_Resturn_Note_T(string noteno, string date_, string beneficiary_fkey, string reference, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Sell_Resturn_Note_T (noteno,date_,beneficiary_fkey,reference,author,transport,Doc_id,transportation_charge,packaging) values(@noteno,@date_,@beneficiary_fkey,@reference,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@noteno", noteno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@reference", reference);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Sell_Resturn_Note_D_T(string noteno_fkey, string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey, string grqnty)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Sell_Resturn_Note_D_T (noteno_fkey,bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@noteno_fkey,@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@noteno_fkey", noteno_fkey);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            cmd.Parameters.Add("@grqnty", grqnty);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            if (rt)
            {
                Update_D_T("TranxDB", Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Sell_Bill_D_T", qnty, bill_ID_fkey, item_no_fkey);
            }
            return rt;
        }
        public static bool Insert_Sell_Resturn_Challan_T(string noteno, string date_, string beneficiary_fkey, string reference, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Sell_Resturn_Challan_T (noteno,date_,beneficiary_fkey,reference,author,transport,Doc_id,transportation_charge,packaging) values(@noteno,@date_,@beneficiary_fkey,@reference,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@noteno", noteno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@reference", reference);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Sell_Resturn_Challan_D_T(string noteno_fkey, string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey, string grqnty)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Sell_Resturn_Challan_D_T (noteno_fkey,bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@noteno_fkey,@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@noteno_fkey", noteno_fkey);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            cmd.Parameters.Add("@grqnty", grqnty);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            if (rt)
            {
                Update_D_T("TranxDB", Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Sell_Challan_D_T", qnty, bill_ID_fkey, item_no_fkey);
            }
            return rt;
        }
        static bool Update_D_T(string db,string tname,string qnty,string bill_id,string itno)
        {
            string qurry = "Update "+tname+" SET grqnty = @qnty where bill_ID_fkey = @bill_id AND item_no_fkey = @itno ";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[db].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            //cmd.Parameters.Add("@tname", tname);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@bill_id", bill_id);
            cmd.Parameters.Add("@itno", itno);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public delegate bool insert_Job_Bill_T(string goodsValue, string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging);
        public delegate bool insert_Job_Bill_D_T(string recieved, string job_fkey, string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey);
        public static bool Insert_Sell_Job_Bill_T(string goodsValue, string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Sell_Job_Bill_T (goodsValue,billno,date_,beneficiary_fkey,payment_terms,ewaybill_no,agenet,author,transport,Doc_id,transportation_charge,packaging) values(@goodsValue,@billno,@date_,@beneficiary_fkey,@payment_terms,@ewaybill_no,@agenet,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@goodsValue", goodsValue);
            cmd.Parameters.Add("@billno", billno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@payment_terms", payment_terms);
            cmd.Parameters.Add("@ewaybill_no", ewaybill_no);
            cmd.Parameters.Add("@agenet", agenet);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);            
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Sell_Job_Bill_D_T(string recieved, string job_fkey, string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Sell_Job_Bill_D_T (recieved,job_fkey,bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@recieved,@job_fkey,@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@recieved", recieved);
            cmd.Parameters.Add("@job_fkey", job_fkey);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            int zero = 0;
            cmd.Parameters.Add("@grqnty", zero);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Sell_Job_Challan_T(string goodsValue, string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Sell_Job_Challan_T (goodsValue,billno,date_,beneficiary_fkey,payment_terms,ewaybill_no,agenet,author,transport,Doc_id,transportation_charge,packaging) values(@goodsValue,@billno,@date_,@beneficiary_fkey,@payment_terms,@ewaybill_no,@agenet,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@goodsValue", goodsValue);
            cmd.Parameters.Add("@billno", billno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@payment_terms", payment_terms);
            cmd.Parameters.Add("@ewaybill_no", ewaybill_no);
            cmd.Parameters.Add("@agenet", agenet);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Sell_Job_Challan_D_T(string recieved, string job_fkey, string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Sell_Job_Challan_D_T (recieved,job_fkey,bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@recieved,@job_fkey,@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@recieved", recieved);
            cmd.Parameters.Add("@job_fkey", job_fkey);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            int zero = 0;
            cmd.Parameters.Add("@grqnty", zero);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Purchase_Job_Bill_T(string goodsValue, string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_Job_Bill_T (goodsValue,billno,date_,beneficiary_fkey,payment_terms,ewaybill_no,agenet,author,transport,Doc_id,transportation_charge,packaging) values(@goodsValue,@billno,@date_,@beneficiary_fkey,@payment_terms,@ewaybill_no,@agenet,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@goodsValue", goodsValue);
            cmd.Parameters.Add("@billno", billno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@payment_terms", payment_terms);
            cmd.Parameters.Add("@ewaybill_no", ewaybill_no);
            cmd.Parameters.Add("@agenet", agenet);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Purchase_Job_Bill_D_T(string recieved, string job_fkey, string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_Job_Bill_D_T (recieved,job_fkey,bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@recieved,@job_fkey,@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@recieved", recieved);
            cmd.Parameters.Add("@job_fkey", job_fkey);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            int zero = 0;
            cmd.Parameters.Add("@grqnty", zero);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Purchase_Job_Challan_T(string goodsValue, string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_Job_Challan_T (goodsValue,billno,date_,beneficiary_fkey,payment_terms,ewaybill_no,agenet,author,transport,Doc_id,transportation_charge,packaging) values(@goodsValue,@billno,@date_,@beneficiary_fkey,@payment_terms,@ewaybill_no,@agenet,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@goodsValue", goodsValue);
            cmd.Parameters.Add("@billno", billno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@payment_terms", payment_terms);
            cmd.Parameters.Add("@ewaybill_no", ewaybill_no);
            cmd.Parameters.Add("@agenet", agenet);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Purchase_Job_Challan_D_T(string recieved, string job_fkey, string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_Job_Challan_D_T (recieved,job_fkey,bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@recieved,@job_fkey,@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@recieved", recieved);
            cmd.Parameters.Add("@job_fkey", job_fkey);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            int zero = 0;
            cmd.Parameters.Add("@grqnty", zero);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        
        public delegate bool insert_JobRecieving_Bill_T(string bill_fkey, string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging);
        public delegate bool insert_JobRecieving_Bill_D_T(string job_fkey, string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey);               
        public static bool Insert_Purchase_JobRecieving_Bill_T(string bill_fkey, string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_JobRecieving_Bill_T (bill_fkey,billno,date_,beneficiary_fkey,payment_terms,ewaybill_no,agenet,author,transport,Doc_id,transportation_charge,packaging) values(@bill_fkey,@billno,@date_,@beneficiary_fkey,@payment_terms,@ewaybill_no,@agenet,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@bill_fkey", bill_fkey);
            cmd.Parameters.Add("@billno", billno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@payment_terms", payment_terms);
            cmd.Parameters.Add("@ewaybill_no", ewaybill_no);
            cmd.Parameters.Add("@agenet", agenet);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Purchase_JobRecieving_Bill_D_T(string job_fkey, string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_JobRecieving_Bill_D_T (job_fkey,bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@job_fkey,@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@job_fkey", job_fkey);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            int zero = 0;
            cmd.Parameters.Add("@grqnty", zero);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Purchase_JobRecieving_Challan_T(string bill_fkey, string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_JobRecieving_Challan_T (bill_fkey,billno,date_,beneficiary_fkey,payment_terms,ewaybill_no,agenet,author,transport,Doc_id,transportation_charge,packaging) values(@bill_fkey,@billno,@date_,@beneficiary_fkey,@payment_terms,@ewaybill_no,@agenet,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@bill_fkey", bill_fkey);
            cmd.Parameters.Add("@billno", billno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@payment_terms", payment_terms);
            cmd.Parameters.Add("@ewaybill_no", ewaybill_no);
            cmd.Parameters.Add("@agenet", agenet);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Purchase_JobRecieving_Challan_D_T(string job_fkey, string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_JobRecieving_Challan_D_T (job_fkey,bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@job_fkey,@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@job_fkey", job_fkey);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            int zero = 0;
            cmd.Parameters.Add("@grqnty", zero);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public delegate bool insert_Payment_T(string receipt, string date_, string beneficiary_fkey, string mode, string collector, string reference, string author);
        public delegate bool insert_Payment_D_T(string pay_fkey, string date_, string bank, string transaction_ID, string amount);
        public static bool Insert_Purchase_Payment_T(string receipt, string date_, string beneficiary_fkey, string mode, string collector, string reference, string author)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_Payment_T (receipt,date_,beneficiary_fkey,mode,collector,reference,author) values(@receipt,@date_,@beneficiary_fkey,@mode,@collector,@reference,@author)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[Constant.TransDB].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@receipt", receipt);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@mode", mode);
            cmd.Parameters.Add("@collector", collector);
            cmd.Parameters.Add("@reference", reference);
            cmd.Parameters.Add("@author", author);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Purchase_Payment_D_T(string pay_fkey, string date_, string bank, string transaction_ID, string amount)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Purchase_Payment_D_T (pay_fkey,date_,bank,transaction_ID,amount) values(@pay_fkey,@date_,@bank,@transaction_ID,@amount)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[Constant.TransDB].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@pay_fkey", pay_fkey);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@bank", bank);
            cmd.Parameters.Add("@transaction_ID", transaction_ID);
            cmd.Parameters.Add("@amount", amount);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Sell_Payment_T(string receipt, string date_, string beneficiary_fkey, string mode, string collector, string reference, string author)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Sell_Payment_T (receipt,date_,beneficiary_fkey,mode,collector,reference,author) values(@receipt,@date_,@beneficiary_fkey,@mode,@collector,@reference,@author)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@receipt", receipt);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@mode", mode);
            cmd.Parameters.Add("@collector", collector);
            cmd.Parameters.Add("@reference", reference);
            cmd.Parameters.Add("@author", author);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Sell_Payment_D_T(string pay_fkey, string date_, string bank, string transaction_ID, string amount)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Sell_Payment_D_T (pay_fkey,date_,bank,transaction_ID,amount) values(@pay_fkey,@date_,@bank,@transaction_ID,@amount)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@pay_fkey", pay_fkey);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@bank", bank);
            cmd.Parameters.Add("@transaction_ID", transaction_ID);
            cmd.Parameters.Add("@amount", amount);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

       
        public static bool Insert_IGST(string doc_table, string isRC, string inward, string isRegBene, string date_, string particular, string folio, string credit, string debit)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "IGST (doc_table,isRC,inward,isRegBene,date_,particular,folio,credit,debit) values(@doc_table,@isRC,@inward,@isRegBene,@date_,@particular,@folio,@credit,@debit)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@doc_table", doc_table);
            cmd.Parameters.Add("@isRC", isRC);
            cmd.Parameters.Add("@inward", inward);
            cmd.Parameters.Add("@isRegBene", isRegBene);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@particular", particular);
            cmd.Parameters.Add("@folio", folio);
            cmd.Parameters.Add("@credit", credit);
            cmd.Parameters.Add("@debit", debit);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_CGST(string doc_table, string isRC, string inward, string isRegBene, string date_, string particular, string folio, string credit, string debit)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "CGST (doc_table,isRC,inward,isRegBene,date_,particular,folio,credit,debit) values(@doc_table,@isRC,@inward,@isRegBene,@date_,@particular,@folio,@credit,@debit)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TransDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@doc_table", doc_table);
            cmd.Parameters.Add("@isRC", isRC);
            cmd.Parameters.Add("@inward", inward);
            cmd.Parameters.Add("@isRegBene", isRegBene);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@particular", particular);
            cmd.Parameters.Add("@folio", folio);
            cmd.Parameters.Add("@credit", credit);
            cmd.Parameters.Add("@debit", debit);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_SGST(string doc_table, string isRC, string inward, string isRegBene, string date_, string particular, string folio, string credit, string debit)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "SGST (doc_table,isRC,inward,isRegBene,date_,particular,folio,credit,debit) values(@doc_table,@isRC,@inward,@isRegBene,@date_,@particular,@folio,@credit,@debit)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TransDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@doc_table", doc_table);
            cmd.Parameters.Add("@isRC", isRC);
            cmd.Parameters.Add("@inward", inward);
            cmd.Parameters.Add("@isRegBene", isRegBene);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@particular", particular);
            cmd.Parameters.Add("@folio", folio);
            cmd.Parameters.Add("@credit", credit);
            cmd.Parameters.Add("@debit", debit);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_UGST(string doc_table, string isRC, string inward, string isRegBene, string date_, string particular, string folio, string credit, string debit)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "UGST (doc_table,isRC,inward,isRegBene,date_,particular,folio,credit,debit) values(@doc_table,@isRC,@inward,@isRegBene,@date_,@particular,@folio,@credit,@debit)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@doc_table", doc_table);
            cmd.Parameters.Add("@isRC", isRC);
            cmd.Parameters.Add("@inward", inward);
            cmd.Parameters.Add("@isRegBene", isRegBene);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@particular", particular);
            cmd.Parameters.Add("@folio", folio);
            cmd.Parameters.Add("@credit", credit);
            cmd.Parameters.Add("@debit", debit);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_CESS(string doc_table, string isRC, string inward, string isRegBene, string date_, string particular, string folio, string credit, string debit)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "CESS (doc_table,isRC,inward,isRegBene,date_,particular,folio,credit,debit) values(@doc_table,@isRC,@inward,@isRegBene,@date_,@particular,@folio,@credit,@debit)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@doc_table", doc_table);
            cmd.Parameters.Add("@isRC", isRC);
            cmd.Parameters.Add("@inward", inward);
            cmd.Parameters.Add("@isRegBene", isRegBene);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@particular", particular);
            cmd.Parameters.Add("@folio", folio);
            cmd.Parameters.Add("@credit", credit);
            cmd.Parameters.Add("@debit", debit);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_FEES(string gstcolmn, string date_, string particular, string folio, string credit, string debit)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "FEES (gstcolmn,date_,particular,folio,credit,debit) values(@gstcolmn,@date_,@particular,@folio,@credit,@debit)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@gstcolmn", gstcolmn);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@particular", particular);
            cmd.Parameters.Add("@folio", folio);
            cmd.Parameters.Add("@credit", credit);
            cmd.Parameters.Add("@debit", debit);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_PENALTY(string gstcolmn, string date_, string particular, string folio, string credit, string debit)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "PENALTY (gstcolmn,date_,particular,folio,credit,debit) values(@gstcolmn,@date_,@particular,@folio,@credit,@debit)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@gstcolmn", gstcolmn);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@particular", particular);
            cmd.Parameters.Add("@folio", folio);
            cmd.Parameters.Add("@credit", credit);
            cmd.Parameters.Add("@debit", debit);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_INTEREST(string gstcolmn, string date_, string particular, string folio, string credit, string debit)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "INTEREST (gstcolmn,date_,particular,folio,credit,debit) values(@gstcolmn,@date_,@particular,@folio,@credit,@debit)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@gstcolmn", gstcolmn);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@particular", particular);
            cmd.Parameters.Add("@folio", folio);
            cmd.Parameters.Add("@credit", credit);
            cmd.Parameters.Add("@debit", debit);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_OTHER(string gstcolmn, string date_, string particular, string folio, string credit, string debit)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "OTHER (gstcolmn,date_,particular,folio,credit,debit) values(@gstcolmn,@date_,@particular,@folio,@credit,@debit)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@gstcolmn", gstcolmn);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@particular", particular);
            cmd.Parameters.Add("@folio", folio);
            cmd.Parameters.Add("@credit", credit);
            cmd.Parameters.Add("@debit", debit);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }        
        public static bool Insert_GSTPAY_T(string date, string ARN, string igst, string cgst, string sgst, string ugst, string cess, string feesigst, string feescgst, string feessgst, string feesugst, string feescess, string penaltyigst, string penaltycgst, string penaltysgst, string penaltyugst, string penaltycess, string interestigst, string interestcgst, string interestsgst, string interestugst, string interestcess, string otherigst, string othercgst, string othersgst, string otherugst, string othercess, string amount, string com_id)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "GSTPAY_T (date,ARN,igst,cgst,sgst,ugst,cess,feesigst,feescgst,feessgst,feesugst,feescess,penaltyigst,penaltycgst,penaltysgst,penaltyugst,penaltycess,interestigst,interestcgst,interestsgst,interestugst,interestcess,otherigst,othercgst,othersgst,otherugst,othercess,amount,com_id) values(@date,@ARN,@igst,@cgst,@sgst,@ugst,@cess,@feesigst,@feescgst,@feessgst,@feesugst,@feescess,@penaltyigst,@penaltycgst,@penaltysgst,@penaltyugst,@penaltycess,@interestigst,@interestcgst,@interestsgst,@interestugst,@interestcess,@otherigst,@othercgst,@othersgst,@otherugst,@othercess,@amount,@com_id)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@date", date);
            cmd.Parameters.Add("@ARN", ARN);
            cmd.Parameters.Add("@igst", igst);
            cmd.Parameters.Add("@cgst", cgst);
            cmd.Parameters.Add("@sgst", sgst);
            cmd.Parameters.Add("@ugst", ugst);
            cmd.Parameters.Add("@cess", cess);
            cmd.Parameters.Add("@feesigst", feesigst);
            cmd.Parameters.Add("@feescgst", feescgst);
            cmd.Parameters.Add("@feessgst", feessgst);
            cmd.Parameters.Add("@feesugst", feesugst);
            cmd.Parameters.Add("@feescess", feescess);
            cmd.Parameters.Add("@penaltyigst", penaltyigst);
            cmd.Parameters.Add("@penaltycgst", penaltycgst);
            cmd.Parameters.Add("@penaltysgst", penaltysgst);
            cmd.Parameters.Add("@penaltyugst", penaltyugst);
            cmd.Parameters.Add("@penaltycess", penaltycess);
            cmd.Parameters.Add("@interestigst", interestigst);
            cmd.Parameters.Add("@interestcgst", interestcgst);
            cmd.Parameters.Add("@interestsgst", interestsgst);
            cmd.Parameters.Add("@interestugst", interestugst);
            cmd.Parameters.Add("@interestcess", interestcess);
            cmd.Parameters.Add("@otherigst", otherigst);
            cmd.Parameters.Add("@othercgst", othercgst);
            cmd.Parameters.Add("@othersgst", othersgst);
            cmd.Parameters.Add("@otherugst", otherugst);
            cmd.Parameters.Add("@othercess", othercess);
            cmd.Parameters.Add("@amount", amount);
            cmd.Parameters.Add("@com_id", com_id);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public static string t_Manual_Stock_T = "Manual_Stock_T";
        public static class c_Manual_Stock_T
        {
            public static string f_billno = "billno";
            public static string f_date_ = "date_";
            public static string f_beneficiary_fkey = "beneficiary_fkey";
            public static string f_payment_terms = "payment_terms";
            public static string f_ewaybill_no = "ewaybill_no";
            public static string f_agenet = "agenet";
            public static string f_author = "author";
            public static string f_transport = "transport";
            public static string f_Doc_id = "Doc_id";
            public static string f_transportation_charge = "transportation_charge";
            public static string f_packaging = "packaging";
        }

        public static string t_Manual_Stock_D_T = "Manual_Stock_D_T";
        public static class c_Manual_Stock_D_T
        {
            public static string f_bill_ID_fkey = "bill_ID_fkey";
            public static string f_item_no_fkey = "item_no_fkey";
            public static string f_rate = "rate";
            public static string f_discount_rate = "discount_rate";
            public static string f_qnty = "qnty";
            public static string f_challan_fkey = "challan_fkey";
            public static string f_grqnty = "grqnty";
        }       

        public delegate bool insert_Manual_Stock_T(string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging);
        public delegate bool insert_Manual_Stock_D_T(string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey);
        public static bool Insert_Manual_Stock_T(string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Stock_T (billno,date_,beneficiary_fkey,payment_terms,ewaybill_no,agenet,author,transport,Doc_id,transportation_charge,packaging) values(@billno,@date_,@beneficiary_fkey,@payment_terms,@ewaybill_no,@agenet,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TransDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@billno", billno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@payment_terms", payment_terms);
            cmd.Parameters.Add("@ewaybill_no", ewaybill_no);
            cmd.Parameters.Add("@agenet", agenet);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Manual_Stock_D_T(string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Stock_D_T (bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TransDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            int zero = 0;
            cmd.Parameters.Add("@grqnty", zero);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public static string t_Manual_Job_T = "Manual_Job_T";
        public static class c_Manual_Job_T
        {
            public static string f_goodsValue = "goodsValue";
            public static string f_billno = "billno";
            public static string f_date_ = "date_";
            public static string f_beneficiary_fkey = "beneficiary_fkey";
            public static string f_payment_terms = "payment_terms";
            public static string f_ewaybill_no = "ewaybill_no";
            public static string f_agenet = "agenet";
            public static string f_author = "author";
            public static string f_transport = "transport";
            public static string f_Doc_id = "Doc_id";
            public static string f_transportation_charge = "transportation_charge";
            public static string f_packaging = "packaging";
        }

        public static string t_Manual_Job_D_T = "Manual_Job_D_T";
        public static class c_Manual_Job_D_T
        {
            public static string f_job_fkey = "job_fkey";
            public static string f_recieved = "recieved";
            public static string f_bill_ID_fkey = "bill_ID_fkey";
            public static string f_item_no_fkey = "item_no_fkey";
            public static string f_rate = "rate";
            public static string f_discount_rate = "discount_rate";
            public static string f_qnty = "qnty";
            public static string f_challan_fkey = "challan_fkey";
            public static string f_grqnty = "grqnty";
        }

        public delegate bool insert_Manual_Job_T(string goodsValue, string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging);
        public delegate bool insert_Manual_Job_D_T(string recieved, string job_fkey, string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey);
        public static bool Insert_Manual_Job_T(string goodsValue, string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Job_T (goodsValue,billno,date_,beneficiary_fkey,payment_terms,ewaybill_no,agenet,author,transport,Doc_id,transportation_charge,packaging) values(@goodsValue,@billno,@date_,@beneficiary_fkey,@payment_terms,@ewaybill_no,@agenet,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@goodsValue", goodsValue);
            cmd.Parameters.Add("@billno", billno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@payment_terms", payment_terms);
            cmd.Parameters.Add("@ewaybill_no", ewaybill_no);
            cmd.Parameters.Add("@agenet", agenet);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Manual_Job_D_T(string recieved, string job_fkey, string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_Job_D_T (recieved,job_fkey,bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@recieved,@job_fkey,@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@recieved", recieved);
            cmd.Parameters.Add("@job_fkey", job_fkey);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            int zero = 0;
            cmd.Parameters.Add("@grqnty", zero);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }

        public static bool Insert_Manual_JobRecieving_T(string bill_fkey, string billno, string date_, string beneficiary_fkey, string payment_terms, string ewaybill_no, string agenet, string author, string transport, string Doc_id, string transportation_charge, string packaging)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_JobRecieving_T (bill_fkey,billno,date_,beneficiary_fkey,payment_terms,ewaybill_no,agenet,author,transport,Doc_id,transportation_charge,packaging) values(@bill_fkey,@billno,@date_,@beneficiary_fkey,@payment_terms,@ewaybill_no,@agenet,@author,@transport,@Doc_id,@transportation_charge,@packaging)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@bill_fkey", bill_fkey);
            cmd.Parameters.Add("@billno", billno);
            cmd.Parameters.Add("@date_", date_);
            cmd.Parameters.Add("@beneficiary_fkey", beneficiary_fkey);
            cmd.Parameters.Add("@payment_terms", payment_terms);
            cmd.Parameters.Add("@ewaybill_no", ewaybill_no);
            cmd.Parameters.Add("@agenet", agenet);
            cmd.Parameters.Add("@author", author);
            cmd.Parameters.Add("@transport", transport);
            cmd.Parameters.Add("@Doc_id", Doc_id);
            cmd.Parameters.Add("@transportation_charge", transportation_charge);
            cmd.Parameters.Add("@packaging", packaging);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
        public static bool Insert_Manual_JobRecieving_D_T(string job_fkey, string bill_ID_fkey, string item_no_fkey, string rate, string discount_rate, string qnty, string challan_fkey)
        {
            string qurry = "insert into " + Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + "Manual_JobRecieving_D_T (job_fkey,bill_ID_fkey,item_no_fkey,rate,discount_rate,qnty,challan_fkey,grqnty) values(@job_fkey,@bill_ID_fkey,@item_no_fkey,@rate,@discount_rate,@qnty,@challan_fkey,@grqnty)";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TranxDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qurry, con);
            cmd.Parameters.Add("@job_fkey", job_fkey);
            cmd.Parameters.Add("@bill_ID_fkey", bill_ID_fkey);
            cmd.Parameters.Add("@item_no_fkey", item_no_fkey);
            cmd.Parameters.Add("@rate", rate);
            cmd.Parameters.Add("@discount_rate", discount_rate);
            cmd.Parameters.Add("@qnty", qnty);
            cmd.Parameters.Add("@challan_fkey", challan_fkey);
            int zero = 0;
            cmd.Parameters.Add("@grqnty", zero);
            bool rt = Fall.SaveDB(cmd);
            con.Close();
            return rt;
        }
    }
    public class GST
    {
        public string igst = "0";
        public string cgst = "0";
        public string sgst = "0";
        public string ttax = "0";
    }
    public class Item
    {
        public string Item_no = "";
        public string stock_no = "0";
        public string description = "";
        public string hsn = "5210";
        public string date_ = DateTime.Now.ToString();
        public string supplier_ID_fkey = "";
        public string author_ID_fkey = "";
        public double rate = 0;
        public string name = "";
        public string category = "";
        public string unit = "";
        public string ledgerReq = "";
    }
    public class combo : data_SR
    {
        public string valueMember;
        public string displayMember;
        public string qurry;
    }
    public class data_SRC : data_SR
    {
        public string x_name;
        public string x_value;
    }
    public class data_SR
    {
        public string database;
        public string table;
        public string column;
        string CHECK;
    }
    class Cal_dt
    {
        public string f_id;
        public string f_db;
        public string s_id;
        public string s_db;
        public string amt;
    }
    public class Ledgerdt
    {
        public string F_party;
        public string S_party;
        public DateTime date;
        public string particular;
        public string folio;
        public bool credit = true;
        public bool debit = false;
        public string form_id = "";
        public string table_id = "";
        public string item = "";
        public string com_id = Call.GTD(Constant.Company_id);
    }
   
    public class Temp
    {
       public string data_Id="NOT NULL";
        public string data = "NOT NULL";
    }
    class expense
    {
        public string transportation_charge = "NULL";
        public string packaging = "NULL";
    }
    class bill:expense
    {
        public string billno ="NULL";
        public string date_ = "NOT NULL";
        public string beneficiary_fkey = "NOT NULL";

        public string payment_terms = "NULL";
        public string ewaybill_no = "NULL";
        public string agenet = "NULL";
        public string author = "NOT NULL";
        public string transport = "NULL";
        public string Doc_id = "NULL";//transport doc number

    }
    //Tranction Database Object
    class b_Sub
    {
        public string bill_ID_fkey = "NOT NULL";
        public string item_no_fkey = "NOT NULL";
        public string rate = "NOT NULL";
        public string discount_rate = "NOT NULL";
        public string qnty = "NOT NULL";
        public string challan_fkey = "NULL";//This field filled when bill is generated from challan purchase
        public string grqnty = "NULL";//this filed filled when item is return
    }
    class b_challan : bill
    {
        public string isRegister = "NULL";
    }
    class RetStock:expense
    {
        public string noteno = "NULL";
        public string date_ = "NOT NULL";
        public string beneficiary_fkey = "NOT NULL";

        public string reference = "NULL";
        public string author = "NOT NULL";
        public string transport = "NULL";
        public string Doc_id = "NULL";
    }
    class RS_Sub:b_Sub
    {
        public string noteno_fkey = "NOT NULL";
       
    }
    class RS_challan : RetStock
    {
        public string isRegister = "NULL";
    }
    class Job:bill
    {
        public string goodsValue = "NOT NULL";
    }
    class J_Sub : b_Sub
    {
        public string job_fkey = "NOT NULL";
        public string recieved = "NOT NULL";
    }
    class J_challan : Job
    {
        public string isRegister = "NULL";
    }
    class RJob:bill
    {
        public string bill_fkey = "NOT NULL";
    }
    class RJ_Sub : b_Sub
    {
        public string job_fkey = "NOT NULL";
    }
    class RJ_challan : RJob
    {
        public string isRegister = "NULL";
    }
    class Pay
    {
        public string receipt = "NOT NULL";
        public string date_ = "NOT NULL";
        public string beneficiary_fkey = "NOT NULL";
        public string mode="NOT NULL";
        public string collector= "NOT NULL";

        public string reference = "NULL";
        public string author = "NOT NULL";
    }
    class P_sub
    {
        public string pay_fkey = "NOT NULL";
        public string date_ = "NOT NULL";
        public string bank = "NOT NULL";
        public string transaction_ID = "NOT NULL";
        public string amount = "NOT NULL";
    }
    //Company Database Object
    class CompanyObj
    {
        public string RegdId  = "NOT NULL";
        public string date_ = "NOT NULL";
        public string Name = "NOT NULL";
        public string Alias = "NULL";
        public string GSTIN = "NULL";
        public string author = "NOT NULL";        
        public string category = "NOT NULL";       
    }
   
    class Address
    {
        public string addri_fkey = "NOT NULL";
        public string addr_table = "NOT NULL";
        public string address = "NOT NULL";
        public string city = "NOT NULL";
        public string district = "NOT NULL";
        public string state = "NOT NULL";
        public string pincode = "NOT NULL";
    }    
    class category
    {
        public string Name = "NOT NULL";
        public string date_ = "NOT NULL";
        public string sub = "NOT NULL";
        public string LedgerReq = "NOT NULL";
    }
    //Account Database Object
    public class LedgerObj
    {
        public string date_ = "NOT NULL";
        public string particular = "NOT NULL";
        public string folio = "NOT NULL";
        public string credit = "NOT NULL";
        public string debit = "NOT NULL";        
    }
    class Beneficiary_ledger:LedgerObj
    {
        public string first_party_fkey = "NOT NULL";
    }
    class Bankdt
    {
        /// <summary>
        ///takes hold the id of object to which record is link  
        /// </summary>
        public string holder_fkey = "NOT NULL";
        public string holder_table = "NOT NULL";
        public string bank_name = "NOT NULL";
        public string Name = "NOT NULL";
        public string AccountNo = "NOT NULL";
        public string IFSC = "NOT NULL";
    }    
    class rate
    {
        public string item_fkey = "NOT NULL";
        public string item_table = "NOT NULL";
        public string docID_fkey = "NOT NULL";
        public string rate_ = "NOT NULL";
        public string reason = "NULL";
    }
    class item
    {
        public string date_ = "Not NULL";
        public string Name = "Not NULL";
        public string description = "Not NULL";        
        public string category = "Not NULL";
        public string supplier_fkey = "Not NULL";
        public string author = "NOT NULL";
        public string Unit = "Not NULL";
        public string LedgerReq = "NOT NULL";
    }
    class stock_item:item
    {
        public string stockId = "Not NULL";
        public string stock_no = "Not NULL";
        public string HSN = "Not NULL";
    }
    class servicer_item:item
    {
        public string stockId = "Not NULL";
        public string SAC = "Not NULL";
    }
    class job_item:servicer_item
    {
        public string Gen_New_No = "Not NULL";
    }
    //Unit System Database Object
    class Unit
    {        
        public string name = "Not NULL";
        public string symbol = "Not NULL";
        public string Quantity = "Not NULL";
    }
    class DriveUnit:Unit
    {
        public string formula = "NULL";
    }
    //Person Database Object
    class Person
    {
        public string fisrt_name = "NOT NULL";
        public string last_name = "NOT NULL";
        public string date_ = "NOT NULL";
        public string DOB = "NOT NULL";
        public string sex = "NOT NULL";
        public string nationality = "NOT NULL";
    }    
    //Company People Database Object
    class CompanyPreson:Person
    {
        public string Designation = "NOT NULL";
        public string Enroll_Id = "NOT NULL";
    }
    class contact
    {
        /// <summary>
        ///takes hold the id of object to which record is link  
        /// </summary>
        public string holder_fkey = "NOT NULL";
        public string holder_table = "NOT NULL";
        public string name = "NULL";
        public string phone = "NOT NULL";
        public string email = "NULL";
        public string website = "NULL";
    }
    class Employee
    {/// <summary>
     ///takes the companyperson unique id  
     /// </summary>
        public string person_fkey = "NOT NULL";
        public string salary = "NOT NULL";
        public string isActive = "NOT NULL";
    }    
    //Other
    class photo
    {
        public string object_fkey = "NOT NULL";
        public string object_table = "NOT NULL";
        public string image = "NOT NULL";
        public string description = "NOT NULL";
    }
    class Logindt
    {
        public string date_ = "NOT NULL";
        public string Name = "NOT NULL";
        public string LoginID = "NOT NULL";
        public string Password = "NOT NULL";
        public string Type = "NOT NULL";
    }
    class Ledgedt
    {
        public string date = "NOT NULL";
        public string particular = "NOT NULL";
        public string folio = "NOT NULL";
        public string credit = "NOT NULL";
        public string debit = "NOT NULL";
        public string form_id = "NOT NULL";
        public string table_id = "NOT NULL";
        public string com_id = "NOT NULL";
    }
    public class GSTDB
    {
        public class gst: LedgerObj
        {
            public string doc_table = "NOT NULL";
            public string isRC = "NOT NULL";
            public string inward = "NOT NULL";
            public string isRegBene = "NOT NULL";

        }       
        public class gstliability : LedgerObj
        {
            /// <summary>
            /// takes variable as IGST, CGST, SGST and UGST
            /// </summary>
            public string gstcolmn = "NOT NULL";
        }       
    }
    public  class gstpaymt
    {
        public string date = "NOT NULL";
        public string ARN = "NOT NULL";

        public string igst = "NOT NULL";
        public string cgst = "NOT NULL";
        public string sgst = "NOT NULL";
        public string ugst = "NOT NULL";
        public string cess = "NOT NULL";

        public string feesigst = "NOT NULL";
        public string feescgst = "NOT NULL";
        public string feessgst = "NOT NULL";
        public string feesugst = "NOT NULL";
        public string feescess = "NOT NULL";

        public string penaltyigst = "NOT NULL";
        public string penaltycgst = "NOT NULL";
        public string penaltysgst = "NOT NULL";
        public string penaltyugst = "NOT NULL";
        public string penaltycess = "NOT NULL";

        public string interestigst = "NOT NULL";
        public string interestcgst = "NOT NULL";
        public string interestsgst = "NOT NULL";
        public string interestugst = "NOT NULL";
        public string interestcess = "NOT NULL";

        public string otherigst = "NOT NULL";
        public string othercgst = "NOT NULL";
        public string othersgst = "NOT NULL";
        public string otherugst = "NOT NULL";
        public string othercess = "NOT NULL";

        public string amount = "NOT NULL";
        public string com_id = "NOT NULL";
    }
}
