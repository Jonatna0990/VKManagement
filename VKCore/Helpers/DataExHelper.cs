using System;

namespace VKCore.Helpers
{
    public static class DataExHelper
    {
        public static string GetStringCount(int count)
        {
            string str_count = count.ToString();
            if (str_count.Length >= 2)
            {

                if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                {
                    return count + " аудиозапись" ;
                }
                else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                {
                    return count + " аудиозаписей";
                }
                else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                    || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                    || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                {
                    return count + " аудиозаписи" ;
                }
                else return  count + " аудиозаписей" ;


            }
            else
            {
                if (count == 1)
                {
                    return   count + " аудиозапись" ;
                }
                else if (count >= 2 && count <= 4)
                {
                    return  count + " аудиозаписи" ;
                }
                else return count + " аудиозаписей" ;


            }
        }
    }
}
