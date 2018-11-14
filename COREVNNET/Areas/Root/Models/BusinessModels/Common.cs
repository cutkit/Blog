using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace COREVNNET.Areas.Root.Models.BusinessModels
{
    public class Common
    {
        public static string EncryptMD5(string data)
        {
            MD5CryptoServiceProvider myD5 = new MD5CryptoServiceProvider();
            byte[] b = System.Text.Encoding.UTF8.GetBytes(data);
            b = myD5.ComputeHash(b);
            StringBuilder s = new StringBuilder();
            foreach (byte p in b)
            {
                s.Append(p.ToString("x").ToLower());

            }
            return s.ToString();
        }
    }
}