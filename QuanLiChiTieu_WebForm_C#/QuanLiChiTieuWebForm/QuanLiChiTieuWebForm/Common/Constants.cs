using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiChiTieuWebForm.Common
{
    public class Constants
    {
        public const string SCRIPT_ALERT_CLOSE = "<script> window.setTimeout(function () {$('.alert').fadeTo(500, 0).slideUp(500, function () {$(this).remove();});}, 2000);</script>";

        public const string VALIDATE_EXIST_LOGINNAME = "Tên đăng nhập đã tồn tại!";
        public const string LOGIN_FALSE = "<div class='alert alert-danger' role='alert'><strong>NOT Success!</strong> Tên đăng nhập hoặc mật khẩu không chính xác!</div>";
        public const string HTML_ERROR_IMPORT_INCOME = "<div class='alert alert-danger' role='alert'><strong>ERROR!</strong> Create Income was an ERROR!</div>";
        public const string HTML_ERROR_IMPORT_SPENDING = "<div class='alert alert-danger' role='alert'><strong>ERROR!</strong> Create Spending was an ERROR!</div>";

        public const string HTML_SUCCESS_IMPORT_INCOME = "<div class='alert alert-success' role='alert'><strong>Success!</strong> Create Income successfully!</div>";
        public const string HTML_SUCCESS_IMPORT_SPENDING = "<div class='alert alert-success' role='alert'><strong>Success!</strong> Create Spending successfully!</div>";
    }
}