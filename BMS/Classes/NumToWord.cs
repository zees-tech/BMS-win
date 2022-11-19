using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace bms1
{
    class NumToWord
    {
        public static string ConvertNumbertoWords(double numbers)
        {
            int number = Convert.ToInt32(numbers - numbers % 1);
            if (number == 0) return "ZERO";
            if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 100000) + " LAKES ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                number %= 100;
            }
            if ((number / 10) > 0)
            {
                words += ConvertNumbertoWords(number / 10) + " RUPEES ";
                number %= 10;
            }
            if (number > 0)
            {
                if (words != "") words += "AND ";
                var unitsMap = new[]
                {
                    "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
                };
                var tensMap = new[]
                {
                    "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
                };
                if (number < 20)
                { words += unitsMap[number]; }
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }
        public static bool IsNumber(string num)
        {
            if (num.Length>0)
            {
                try
                {
                    Convert.ToDouble(num);
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Entry");
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
