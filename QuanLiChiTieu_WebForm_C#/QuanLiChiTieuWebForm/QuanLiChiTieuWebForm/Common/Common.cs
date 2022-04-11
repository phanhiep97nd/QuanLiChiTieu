using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace QuanLiChiTieuWebForm.Common
{
    public class Common
    {
        public static string encode(string pass)
        {
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(pass);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                str_md5 += b.ToString("X2");
            }

            return str_md5;
        }

        public static string encode()
        {
            throw new NotImplementedException();
        }

        public static string GetErrorMessageValidate(List<string> input)
        {
            StringBuilder message = new StringBuilder();
            foreach(string item in input)
            {
                message.Append("<div class='alert alert-danger' role='alert'><strong>Error!</strong> " + item + "</div>");
            }
            return message.ToString();
        }
    }
}