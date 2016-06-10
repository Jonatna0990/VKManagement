using System;

namespace VKShop_Lite.Helpers
{
    public class CountNum
    {
        public static string GetDeclension(long number, string nominativ, string genetiv, string plural)
        {
            int s = number.ToString().Length;

            if (s < 6)
            {
                var ost = number % 100;
                if (ost > 9 && ost < 20)
                {
                    return String.Format("{0} {1}", number, plural); 
                }
                else
                {
                    ost = ost % 10;
                    if (ost == 1)
                        return String.Format("{0} {1}", number, nominativ); 
                    else if (ost > 1 && ost < 5)
                        return String.Format("{0} {1}", number, genetiv);
                    else return String.Format("{0} {1}", number, plural); 
                }
            }
            else if (s == 6)
            {
                double k = number / 1000;
                return String.Format("{0}K {1}", k, plural);
            }
            else if (s >= 7 && s <= 9)
            {
                decimal dValue = (decimal)number;
                 
                decimal k = Math.Round(dValue / Convert.ToDecimal(Math.Pow(10, 6)), 2);
                return String.Format("{0}M {1}", k, plural);
            }
            return "";

        }

    }
}
