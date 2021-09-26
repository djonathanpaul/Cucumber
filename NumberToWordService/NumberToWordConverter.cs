using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWordService
{
    public class NumberToWordConverter:INumberToWordConverter
    {
        static readonly List<String> literals = new List<string>();
        static readonly string[] tens = new string[15];
        static readonly string[] scales = { "", "THOUSAND", "MILLION", "BILLION" };

        static NumberToWordConverter()
        {
            ComputeTensLiterals();
            SetLiteralsZeroTo99();
        }

        static void ComputeTensLiterals()
        {
            tens[1] = "zero";
            tens[2] = "TWENTY";
            tens[3] = "THIRTY";
            tens[4] = "FORTY";
            tens[5] = "FIFTY";
            tens[6] = "SIXTY";
            tens[7] = "SEVENTY";
            tens[8] = "EIGHTY";
            tens[9] = "NINETY";
            tens[10] = "HUNDRED";
        }

        static void SetLiteralsZeroTo99()
        {
            literals.Add("ZERO");
            literals.Add("ONE");
            literals.Add("TWO");
            literals.Add("THREE");
            literals.Add("FOUR");
            literals.Add("FIVE");
            literals.Add("SIX");
            literals.Add("SEVEN");
            literals.Add("EIGHT");
            literals.Add("NINE");
            literals.Add("TEN");
            literals.Add("ELEVEN");
            literals.Add("TWELVE");
            literals.Add("THIRTEEN");
            literals.Add("FOURTEEN");
            literals.Add("FIFTEEN");
            literals.Add("SIXTEEN");
            literals.Add("SEVENTEEN");
            literals.Add("EIGHTEEN");
            literals.Add("NINETEEN");
            literals.Add("TWENTY");

            for (int i = 21; i <= 99; i++)
            {
                literals.Add(tens[i / 10] + (i % 10 == 0 ? "" : " " + literals[i % 10]));
            }
        }

        public string GenerateLiteralForAmount(decimal amount)
        {
            try
            {
                string amountLiteral = "";
                int dollars = (int)Math.Floor(amount);
                int cents = (int)((amount % 1) * 100);

                if (dollars != 0)
                    amountLiteral += FormLiteralForNum(dollars) + " DOLLARS";
                else
                    return "ZERO";

                if (cents == 0)
                    return amountLiteral;

                if ((cents != 0) && (dollars == 0))
                    amountLiteral += FormLiteralForNum(cents) + " CENTS";
                else
                    amountLiteral += " AND " + FormLiteralForNum(cents) + " CENTS";

                //s += (cents != 0) && (dollars == 0) ? formLiteralForNum(cents) + " CENTS" : " AND " + formLiteralForNum(cents) + " CENTS";

                return amountLiteral;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        string FormLiteralFor3Digits(int num)
        {
            if (num < 99)
                return literals[num];
            else
                return literals[(num / 100)] + " " + tens[10] + (num % 100 == 0 ? "" : " AND " + literals[num % 100]);
        }

        public string FormLiteralForNum(int num)
        {
            string numberLiteral = null;
            if (num < 99)
            {
                numberLiteral = literals[num];
            }
            else
            {
                int sIndex = 0;
                while (num > 0)
                {
                    string threeDigitLiteral = null;
                    if (num % 1000 == 0)
                    {
                        num = num / 1000;
                        sIndex++;
                    }
                    else
                    {
                        threeDigitLiteral = FormLiteralFor3Digits(num % 1000);
                        numberLiteral = threeDigitLiteral + ((sIndex != 0) ? (" " + scales[sIndex]) : null) + ((sIndex != 0 && numberLiteral != null) ? " AND " + numberLiteral : numberLiteral);
                        num = num / 1000;
                        sIndex++;
                    }
                }
            }

            return numberLiteral;
        }
    }
}
