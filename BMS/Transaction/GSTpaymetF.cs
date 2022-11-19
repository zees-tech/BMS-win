using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS.Transaction
{
    public partial class GSTpaymetF : Form
    {
        public GSTpaymetF()
        {
            InitializeComponent();
        }
        double amt=0;
        private void savebtn_Click(object sender, EventArgs e)
        {
            TranDB.Insert_GSTPAY_T(date_.Text, arntxt.Text, taxigsttxt.Text, taxcgsttxt.Text, taxsgsttxt.Text, "", taxcesstxt.Text, feesigsttxt.Text, feescgsttxt.Text, feessgsttxt.Text, "", feescesstxt.Text, penaltyigsttxt.Text, penaltycgsttxt.Text, penaltysgsttxt.Text, "", penaltycesstxt.Text, interestigsttxt.Text, interestcgsttxt.Text, interestsgsttxt.Text, "", interestcesstxt.Text, otherigsttxt.Text, othercgsttxt.Text, othersgsttxt.Text, "", othercesstxt.Text,amt.ToString(), Call.GTD(Constant.Company_id));
            receiptidxt.Text = Fall.LBI(Constant.Ret_Alpha(Call.GTD(Constant.Company_id)) + TranDB.t_GSTPAY_T);
            TranDB.Insert_IGST("Cash Payment", false.ToString(), false.ToString(), true.ToString(), date_.Text, "Offset by direct cash payment", receiptidxt.Text, "0", taxigsttxt.Text);
            TranDB.Insert_CGST("Cash Payment", false.ToString(), false.ToString(), true.ToString(), date_.Text, "Offset by direct cash payment", receiptidxt.Text, "0", taxcgsttxt.Text);
            TranDB.Insert_SGST("Cash Payment", false.ToString(), false.ToString(), true.ToString(), date_.Text, "Offset by direct cash payment", receiptidxt.Text, "0", taxsgsttxt.Text);
            TranDB.Insert_CESS("Cash Payment", false.ToString(), false.ToString(), true.ToString(), date_.Text, "Offset by direct cash payment", receiptidxt.Text, "0", taxcesstxt.Text);

            TranDB.Insert_FEES("IGST", date_.Text, "", receiptidxt.Text, "0", feesigsttxt.Text);
            TranDB.Insert_INTEREST("IGST", date_.Text, "", receiptidxt.Text, "0", interestigsttxt.Text);
            TranDB.Insert_PENALTY("IGST", date_.Text, "", receiptidxt.Text, "0", penaltyigsttxt.Text);
            TranDB.Insert_OTHER("IGST", date_.Text, "", receiptidxt.Text, "0", otherigsttxt.Text);

            TranDB.Insert_FEES("CGST", date_.Text, "", receiptidxt.Text, "0", feescgsttxt.Text);
            TranDB.Insert_INTEREST("CGST", date_.Text, "", receiptidxt.Text, "0", interestcgsttxt.Text);
            TranDB.Insert_PENALTY("CGST", date_.Text, "", receiptidxt.Text, "0", penaltycgsttxt.Text);
            TranDB.Insert_OTHER("CGST", date_.Text, "", receiptidxt.Text, "0", othercgsttxt.Text);

            TranDB.Insert_FEES("SGST", date_.Text, "", receiptidxt.Text, "0", feessgsttxt.Text);
            TranDB.Insert_INTEREST("SGST", date_.Text, "", receiptidxt.Text, "0", interestsgsttxt.Text);
            TranDB.Insert_PENALTY("SGST", date_.Text, "", receiptidxt.Text, "0", penaltysgsttxt.Text);
            TranDB.Insert_OTHER("SGST", date_.Text, "", receiptidxt.Text, "0", othersgsttxt.Text);            
        }
        private void amtupdt()
        {
            foreach (Control item in Controls)
            {
                if (item is GroupBox)
                {
                    foreach (TextBox sitem in item.Controls)
                    {
                        if (sitem is TextBox)
                        {
                            TextBox tb = new TextBox();
                            tb =sitem;
                            amt += Convert.ToDouble(tb.Text);
                        }
                    }
                }
            }
        }
      
        private void taxigsttxt_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Convert.ToDouble(taxigsttxt.Text);
            }
            catch (Exception)
            {
                taxigsttxt.Text = "0";
            }
        }

        private void feesigsttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(feesigsttxt.Text);
            }
            catch (Exception)
            {
                feesigsttxt.Text = "0";
            }
        }

        private void penaltyigsttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(penaltyigsttxt.Text);
            }
            catch (Exception)
            {
                penaltyigsttxt.Text = "0";
            }
        }

        private void interestigsttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(interestigsttxt.Text);
            }
            catch (Exception)
            {
                interestigsttxt.Text = "0";
            }
        }

        private void otherigsttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(otherigsttxt.Text);
            }
            catch (Exception)
            {
                otherigsttxt.Text = "0";
            }
        }

        private void taxcgsttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(taxcgsttxt.Text);
            }
            catch (Exception)
            {
                taxcgsttxt.Text = "0";
            }
        }

        private void feescgsttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(feescgsttxt.Text);
            }
            catch (Exception)
            {
                feescgsttxt.Text = "0";
            }
        }

        private void penaltycgsttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(penaltycgsttxt.Text);
            }
            catch (Exception)
            {
                penaltycgsttxt.Text = "0";
            }
        }

        private void interestcgsttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(interestcgsttxt.Text);
            }
            catch (Exception)
            {
                interestcgsttxt.Text = "0";
            }
        }

        private void othercgsttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(othercgsttxt.Text);
            }
            catch (Exception)
            {
                othercgsttxt.Text = "0";
            }
        }

        private void taxsgsttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(taxsgsttxt.Text);
            }
            catch (Exception)
            {
                taxsgsttxt.Text = "0";
            }
        }

        private void feessgsttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(feessgsttxt.Text);
            }
            catch (Exception)
            {
                feessgsttxt.Text = "0";
            }
        }

        private void penaltysgsttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(penaltysgsttxt.Text);
            }
            catch (Exception)
            {
                penaltysgsttxt.Text = "0";
            }
        }

        private void interestsgsttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(interestsgsttxt.Text);
            }
            catch (Exception)
            {
                interestsgsttxt.Text = "0";
            }
        }

        private void othersgsttxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(othersgsttxt.Text);
            }
            catch (Exception)
            {
                othersgsttxt.Text = "0";
            }
        }

        private void taxcesstxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(taxcesstxt.Text);
            }
            catch (Exception)
            {
                taxcesstxt.Text = "0";
            }
        }

        private void feescesstxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(feescesstxt.Text);
            }
            catch (Exception)
            {
                feescesstxt.Text = "0";
            }
        }

        private void penaltycesstxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(penaltycesstxt.Text);
            }
            catch (Exception)
            {
                penaltycesstxt.Text = "0";
            }
        }

        private void interestcesstxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(interestcesstxt.Text);
            }
            catch (Exception)
            {
                interestcesstxt.Text = "0";
            }
        }

        private void othercesstxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(othercesstxt.Text);
            }
            catch (Exception)
            {
                othercesstxt.Text = "0";
            }
        }
    }
}
