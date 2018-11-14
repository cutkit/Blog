using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COREVNNET.Models
{
    public class ConvertTitleSeo
    {
        #region Chuan hoa ten, tieu de cho seo
        private static string[] a = new string[] { "à", "á", "ạ", "ả", "â", "ã", "ậ", "ẩ", "ẫ", "ă", "ẳ", "ắ", "ằ", "ặ", "ẩ", "ầ", "ấ", "ậ", "a" };
        private static string[] d = new string[] { "d", "đ" };
        private static string[] e = new string[] { "è", "é", "ẹ", "ẻ", "ẽ", "ê", "ề", "ế", "ệ", "ể", "ễ", "e" };
        private static string[] ii = new string[] { "ì", "í", "ị", "ỉ", "ĩ", "i" };
        private static string[] y = new string[] { "y", "ý", "ỳ", "ỷ", "ỵ", "ỹ" };
        private static string[] o = new string[] { "ò", "ó", "ọ", "ỏ", "õ", "ô", "ổ", "ố", "ồ", "ỗ", "ộ", "ơ", "ớ", "ở", "ờ", "ỡ", "ợ", "o" };
        private static string[] u = new string[] { "u", "ú", "ù", "ụ", "ủ", "ũ", "ư", "ữ", "ử", "ừ", "ứ", "ự" };

        public static string ConvertTitle(string Name)
        {
            string result = "";
            string currentchar = "";
            Name = Name.Replace(" ", "-");
            Name = Name.Replace(")", "");
            Name = Name.Replace("(", "");
            Name = Name.Replace("*", "");
            Name = Name.Replace("]", "");
            Name = Name.Replace("[", "");
            Name = Name.Replace("}", "");
            Name = Name.Replace("{", "");
            Name = Name.Replace(">", "");
            Name = Name.Replace("<", "");
            Name = Name.Replace("=", "");
            Name = Name.Replace(":", "");
            Name = Name.Replace(",", "");
            Name = Name.Replace("'", "");
            Name = Name.Replace("/", "");
            Name = Name.Replace("\"", "");
            Name = Name.Replace("\\", "");
            Name = Name.Replace("&", "");
            Name = Name.Replace("?", "");
            Name = Name.Replace(";", "");
            Name = Name.ToLower();
            int len = Name.Length;
            if (Name.Length > 0)
            {
                int i;
                for (i = 0; i < len; i++)
                {
                    currentchar = Name.Substring(i, 1);
                    result = result + ChangeChar(currentchar);
                }

            }
            else
            {
                result = "";
            }
            return result;
        }
        #endregion
        #region "Chuyen ky tu tieng viet co dau thanh khong dau"
        public static string ChangeChar(string charinput)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].Equals(charinput))
                {
                    return "a";
                }
            }
            for (int i = 0; i < d.Length; i++)
            {
                if (d[i].Equals(charinput))
                {
                    return "d";
                }
            }
            for (int i = 0; i < e.Length; i++)
            {
                if (e[i].Equals(charinput))
                {
                    return "e";
                }
            }
            for (int i = 0; i < ii.Length; i++)
            {
                if (ii[i].Equals(charinput))
                {
                    return "i";
                }
            }
            for (int i = 0; i < y.Length; i++)
            {
                if (y[i].Equals(charinput))
                {
                    return "y";
                }
            }
            for (int i = 0; i < o.Length; i++)
            {
                if (o[i].Equals(charinput))
                {
                    return "o";
                }
            }
            for (int i = 0; i < u.Length; i++)
            {
                if (u[i].Equals(charinput))
                {
                    return "u";
                }
            }
            return charinput;
        }
#endregion
    }
}