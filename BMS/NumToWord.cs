using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace BMS
{
    class NumToWord
    {
        readonly static string[] arrOneToNine = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        readonly static string[] arrTenToTwenty = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
                                                         "Sixteen", "Seventeen", "Eighteen", "Nineteen", "Twenty" };
        readonly static string[] arrThirtyToNinety = new string[] { "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        readonly static string strInvalidNumber = "Please enter valid number and try again....";

        public static string ConvertNumbertoWords(double numbers)
       {            
            string resultVal;
            double fract = numbers % 1;
            numbers -= fract;
            fract = dectoint(fract);
            string inputNum = numbers.ToString();
            if (fract<0)
            {
                fract *= -1;
            }
            try
            {
                //First cehck if input is numeric (not alpha numeric)
                try
                {
                    Convert.ToDouble(inputNum);
                    if (inputNum == "0")
                        return "Zero only";

                   // Number is not Zero, it may start with Minus or may not, so check the condition and take decision
                    if (inputNum.StartsWith("-"))
                        resultVal = String.Format("Minus {0}", StartConversion(inputNum.Substring(1, inputNum.Length - 1)));
                    else
                        resultVal = StartConversion(inputNum);
                    resultVal += " Rupees";
                }
                catch (Exception)
                {
                    return strInvalidNumber;
                }
            }
            catch
            {
                //Handle the exception, log it in appropriate location
                return "Something went wrong, please try again!";
            }
            if (fract>0)
            {
                resultVal += " And " + StartConversion(fract.ToString()) + " Paise";
            }
            return string.IsNullOrEmpty(resultVal) ? strInvalidNumber : string.Concat(resultVal, " Only");
        }

        private static double dectoint(double fract)
        {
            fract *= 10;
            if (fract%1>0)
            {
                fract=dectoint(fract);
            }
            return fract;
        }

        private static String StartConversion(String inputNumber)
        {
            bool isCompleted = false;
            string resultStr = string.Empty;
            double number = (Convert.ToDouble(inputNumber));

            if (number > 0)
            {
                int currentPosition = 0;
                int numDigits = inputNumber.Length;
                String currentPlace = string.Empty;
                switch (numDigits)
                {
                    case 1:
                        resultStr = ConvertOnes(inputNumber);
                        isCompleted = true;
                        break;
                    case 2:
                        resultStr = ConvertTens(inputNumber);
                        isCompleted = true;
                        break;
                    case 3:
                        currentPosition = (numDigits % 3) + 1;
                        currentPlace = " Hundred ";
                        break;
                    case 4:
                    case 5:
                        currentPosition = (numDigits % 4) + 1;
                        currentPlace = " Thousand ";
                        break;
                    case 6:
                        currentPosition = (numDigits % 6) + 1;
                        currentPlace = " Lac ";
                        break;
                    case 7:
                    case 8:
                    case 9:
                        currentPosition = (numDigits % 7) + 1;
                        currentPlace = " Million ";
                        break;
                    case 10:
                    case 11:
                    case 12:
                        currentPosition = (numDigits % 10) + 1;
                        currentPlace = " Billion ";
                        break;
                    default:
                        isCompleted = true;
                        break;
                }
                if (!isCompleted)
                {
                    if (inputNumber.Substring(0, currentPosition) != "0" && inputNumber.Substring(currentPosition) != "0")
                        resultStr = StartConversion(inputNumber.Substring(0, currentPosition)) + currentPlace + StartConversion(inputNumber.Substring(currentPosition));
                    else
                        resultStr = StartConversion(inputNumber.Substring(0, currentPosition)) + StartConversion(inputNumber.Substring(currentPosition));
                }

                if (resultStr.Trim().Equals(currentPlace.Trim()))
                    resultStr = string.Empty;
            }
            return resultStr.Trim();
        }
        private static String ConvertTens(String inputNumber)
        {
            Int64 number = Convert.ToInt64(inputNumber);

            if (number >= 10 && number <= 20)
                return arrTenToTwenty[number - 10];
            else if (number >= 30 && number <= 90 && number % 10 == 0)
                return arrThirtyToNinety[(number / 10) - 3];
            else if (number > 0)
                return string.Concat(ConvertTens(inputNumber.Substring(0, 1) + "0"), " ", ConvertOnes(inputNumber.Substring(1)));

            return string.Empty;
        }
        private static String ConvertOnes(String inputNumber)
        {
            return arrOneToNine[Convert.ToInt64(inputNumber) - 1];
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
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
