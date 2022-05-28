<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="QuanLiChiTieuWebForm.SignIn" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Sign In</title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round|Open+Sans" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" type="" href="../Style/SignIn.css">
</head>

<body> 
    <form id="form1" runat="server">
        <div class="signIn-box">
            <h1>Sign In</h1>
            <div id="codeAlert" runat="server" style="color: red;"></div>
            <div class="textbox">
                <i class="fas fa-user"></i>
                <asp:TextBox ID="LoginName" placeholder="Tài Khoản" runat="server"></asp:TextBox>
            </div>

            <div class="textbox">
                <i class="fas fa-lock"></i>
                <asp:TextBox ID="Pass" TextMode="Password" placeholder="Mật Khẩu" runat="server"></asp:TextBox>
            </div>

            <div class="textbox">
                <i class="fas fa-lock"></i>
                <asp:TextBox ID="ConfirmPass" TextMode="Password" placeholder="Xác Nhận Mật Khẩu" runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="SignInBtn" CssClass="btn" runat="server" Text="Đăng ký" OnClick="SignInBtn_Click" />

            <div class="signIn">
                <asp:LinkButton ID="LoginBtn" runat="server" CssClass="btn btn-primary" OnClick="LoginBtn_Click">Đăng nhập...</asp:LinkButton>
            </div>
        </div>
    </form>
</body>

</html>

