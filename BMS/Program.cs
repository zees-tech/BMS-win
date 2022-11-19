using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //string tname = "Category_T";
            //category dt = new category();
            //dbo_Process.createDB(dt, Constant.StockDB, tname,true);
            //stock_item dt = new stock_item();
            //dbo_Process.createDB(dt, Constant.StockDB, "Item_T", true);
            //string query = "Select 'DROP TABLE\" '+table_name+'  \"'From Information_Schema.tables where table_name like '[Item]%'";
            //Fall.SaveDB(query, Constant.LedgerDB);
            //dbo_Process.NewCompanyDB("1");          
            //RJob rj = new RJob();
            //RJ_Sub rjs = new RJ_Sub();
            //dbo_Process.createDB(rj, Constant.TransDB, "AManual_JobRecieving_T", true);
            //dbo_Process.createDB(rjs, Constant.TransDB, "AManual_JobRecieving_D_T", true);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
