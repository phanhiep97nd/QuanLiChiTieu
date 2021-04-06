using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLiChiTieu.Function
{
    public class Validate
    {
        internal static List<string> validateSignIn(string loginName, string pass, String confirmPass)
        {
            List<string> lstErr = new List<string>();
            if (string.Empty.Equals(loginName))
            {
                lstErr.Add("Tên đăng nhập là bắt buộc!");
            }
            else if(loginName.Length< 4 & loginName.Length > 24)
            {
                lstErr.Add("Tên đăng nhập phải có độ dài từ 4 đến 24 kí tự!");
            }
            
            if (string.Empty.Equals(pass))
            {
                lstErr.Add("Mật khẩu là bắt buộc!");
            }
            else if(pass.Length < 8 || pass.Length > 24)
            {
                lstErr.Add("Mật khẩu phải có đồ dài từ 8 đến 24 kí tự!");
            }
            else if (!Regex.IsMatch(pass, "[0-9]") || !Regex.IsMatch(pass, "[a-z]") || !Regex.IsMatch(pass, "[A-Z]"))
            {
                lstErr.Add("Mật khẩu phải bao gồm số, chữ hoa và chữ thường!");
            }

            if(lstErr.Count == 0 & !pass.Equals(confirmPass))
            {
                lstErr.Add("Xác nhận mật khẩu không khớp!");
            }
            return lstErr;
        }

        internal static List<string> validateLogin(string loginName, string pass)
        {
            List<string> lstErr = new List<string>();
            if (string.Empty.Equals(loginName))
            {
                lstErr.Add("Tên đăng nhập là bắt buộc!");
            }
            else if (loginName.Length < 4 & loginName.Length > 24)
            {
                lstErr.Add("Tên đăng nhập phải có độ dài từ 4 đến 24 kí tự!");
            }

            if (string.Empty.Equals(pass))
            {
                lstErr.Add("Mật khẩu là bắt buộc!");
            }
            return lstErr;
        }
    }
}
