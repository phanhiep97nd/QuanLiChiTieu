<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditLoanDebt.aspx.cs" Inherits="QuanLiChiTieuWebForm.EditLoanDebt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý vay nợ(Edit)</title>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round|Open+Sans" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KyZXEAg3QhqLMpG8r+8fhAXLRk2vvoC2f3B09zVXn8CA5QIVfZOJ3BCsw2P0p/We" crossorigin="anonymous">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.3/dist/umd/popper.min.js" integrity="sha384-eMNCOe7tC1doHpGoWe/6oMVemdAVTMs2xqW4mwXrXsW0L84Iytr2wi5v2QjrP/xp" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.min.js" integrity="sha384-cn7l7gDp0eyniUwwAZgrzD06kc/tftFf19TOAs2zVinnD/C7E91j9yyk5//jjpt/" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="" href="../Style/LoanDebt.css">
    <script>
        window.onbeforeunload = refreshParent;
        function refreshParent() {
            window.opener.document.getElementById("overlay").innerHTML = "";
        }

        function closeUpdateWindow(typeEdit) {
            alert(typeEdit == "loan" ? "Update danh sách cho vay thành công!" : "Update danh sách nợ thành công!");
            window.close();
            window.opener.focus();
            window.opener.document.getElementById("SearchBtn").click();
        }

        function setFormatMonney() {
            document.getElementById("ValueEdit").classList.remove("is-invalid");
            var ValueEdit = document.getElementById("ValueEdit");
            if (ValueEdit.value != "") {
                var number = parseInt(ValueEdit.value);
                document.getElementById("Foratmonney").innerHTML = number.toLocaleString() + " VND";
            } else {
                document.getElementById("Foratmonney").innerHTML = "";
            }
        }

        function submitEdit() {
            var valueEdit = document.getElementById("ValueEdit");
            var dateEdit = document.getElementById("DateEdit");
            var HumanEdit = document.getElementById("HumanEdit");
            var StatusEditCheckBox = document.getElementById("StatusEditCheckBox");
            var dateEditFinish = document.getElementById("DateEditFinish");
            valueEdit.classList.remove("is-invalid");
            dateEdit.classList.remove("is-invalid");
            HumanEdit.classList.remove("is-invalid");
            var errorFlg = false;
            if (valueEdit.value == "") {
                valueEdit.classList.add("is-invalid");
                errorFlg = true;
            }
            if (dateEdit.value == "") {
                dateEdit.classList.add("is-invalid");
                errorFlg = true;
            }
            if (HumanEdit.value == "") {
                HumanEdit.classList.add("is-invalid");
                errorFlg = true;
            }
            if (StatusEditCheckBox.checked) {
                if (dateEditFinish.value == "") {
                    dateEditFinish.classList.add("is-invalid");
                    errorFlg = true;
                }
            }
            if (!errorFlg) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header>
                <div class="home">
                    <a href="https://phanhiep97nd.github.io/hiepphan/Hieplayout/Hiep-Profile.html" target="_blank">POWER BY Phan Văn Hiệp</a>
                </div>
            </header>
            <nav class="navbar navbar-expand-lg navbar-light bg-light" style="background-color: #398ddc;">
                <div class="container-fluid">
                    <a class="navbar-brand" href="#">
                        <h3>Hiiii <b>
                            <asp:Label ID="UserNameLabel" runat="server"></asp:Label></b>!</h3>
                    </a>
                    <asp:Button ID="BtnLogOut" runat="server" ForeColor="Red" Text="Log Out" OnClientClick="return confirm('Are you sure?');" CssClass="btn btn-danger" BackColor="247, 179, 179" />
                </div>
            </nav>
            <div class="pos-f-t">
                <nav class="navbar navbar-light bg-light">
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarToggleExternalContent" aria-controls="navbarToggleExternalContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                </nav>
                <div class="collapse" id="navbarToggleExternalContent">
                    <div class="list-group">
                        <asp:Button ID="HomeBtn" runat="server" CssClass="list-group-item list-group-item-info list-group-item-action" Text=" > Home" />
                        <button type="button" class="list-group-item list-group-item-info list-group-item-action">Quản Lý Vay Nợ</button>
                        <button type="button" class="list-group-item list-group-item-info list-group-item-action">> Quản Lý Danh Sách Hiếu Hỷ</button>
                    </div>
                </div>
            </div>
            <nav class="navbar navbar-expand-lg navbar-collapse">
                #Bạn đang ở trang chỉnh sửa Quản lý danh sách vay nợ!
            </nav>
            <div style="height: 2px"></div>
            <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #aed2a3;">
                <div class="container-fluid header menu">
                    <a class="navbar-brand" href="#">
                        <h2>QUẢN LÍ CHI TIÊU <b>(Finance Management)</b></h2>
                        <b style="font-size: small; color: white">Giúp bạn tính toán các khoản thu nhập và chi tiêu để hoạch định số tiền cần đầu tư!</b>
                    </a>
                </div>
            </nav>
            <div style="height: 20px"></div>
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">CHỈNH SỬA CHI TIẾT (<asp:Label ID="TypeEditLabel" runat="server"></asp:Label>)</h5>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="exampleFormControlTextarea1">Ngày Tháng (*)</label>
                        <asp:TextBox ID="DateEdit" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        <div id="validationServerUsernameFeedback" class="invalid-feedback">
                            Hãy nhập ngày tháng.
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlSelect1">Người(*)</label>
                        <asp:TextBox ID="HumanEdit" runat="server" CssClass="form-control" placeholder="Nhập tên người vay ..."></asp:TextBox>
                        <div id="validationServerUsernameFeedback" class="invalid-feedback">
                            Hãy nhập tên người vay.
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlInput1">Số Tiền (VND)(*)</label>
                        <asp:TextBox ID="ValueEdit" runat="server" CssClass="form-control" TextMode="Number" placeholder="Nhập số tiền ..." onchange="setFormatMonney();"></asp:TextBox>
                        <label style="color: darkseagreen; font-size: 15px" id="Foratmonney"></label>
                        <div id="validationServerUsernameFeedback" class="invalid-feedback">
                            Hãy nhập số tiền.
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlTextarea1">Ghi Chú</label>
                        <asp:TextBox ID="NoteEdit" runat="server" CssClass="form-control" TextMode="multiline" placeholder="Note ..."></asp:TextBox>
                    </div>
                    <div class="form-group mb-3">
                        <label for="formFileSm" class="form-label">Đính kèm ảnh</label>
                        <div class="card">
                            <div class="card-body">
                                <p id="NotiDelImg" runat="server" style="color: red"></p>
                                <asp:Image ID="PictureEdit" runat="server" CssClass="img-thumbnail" Style="width: 50%" />
                                <asp:Button ID="BtnDelImg" runat="server" Text="(X)Xóa ảnh" OnClientClick="return confirm('Are you sure delete this image?');" CssClass="btn btn-danger" />
                            </div>
                        </div>
                        <asp:FileUpload runat="server" class="form-control form-control-sm" ID="OFileEdit" type="file" accept="image/png, image/gif, image/jpeg" />
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlTextarea1">Trạng thái</label>
                        <div class="card">
                            <div class="card-body">
                                <label class="form-control">
                                    <asp:CheckBox ID="StatusEditCheckBox" runat="server" CssClass="CheckBox" AutoPostBack="true" />
                                    Trạng thái đã trả hay chưa
                                </label>
                            </div>
                            <div runat="server" id="FinishRegion" class="card" style="margin: 15px; background-color:lawngreen">
                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item">
                                        <label for="exampleFormControlTextarea1">Ngày Tháng Trả(*)</label>
                                        <asp:TextBox ID="DateEditFinish" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                            Hãy nhập ngày tháng.
                                        </div>
                                    </li>
                                    <li class="list-group-item">
                                        <label for="exampleFormControlTextarea1">Ghi Chú Trạng Thái Trả</label>
                                        <asp:TextBox ID="NoteEditFinish" runat="server" CssClass="form-control" TextMode="multiline" placeholder="Note finish..."></asp:TextBox>
                                    </li>
                                    <li class="list-group-item">
                                        <label for="formFileSm" class="form-label">Đính kèm ảnh trạng thái đã trả</label>
                                        <p id="NotiDelImgFinish" runat="server" style="color: red"></p>
                                        <asp:Image ID="PictureEditFinish" runat="server" CssClass="img-thumbnail" Style="width: 50%" />
                                        <asp:Button ID="BtnDelImgFinish" runat="server" Text="(X)Xóa ảnh" OnClientClick="return confirm('Are you sure delete this image?');" CssClass="btn btn-danger" />
                                        <asp:FileUpload runat="server" class="form-control form-control-sm" ID="OFileEditFinish" type="file" accept="image/png, image/gif, image/jpeg" />
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div>
                        <asp:Button ID="SubmitEditBtn" runat="server" Text="Submit" OnClientClick="return submitEdit()" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
            <%--<input id="TypeEditHidden"  type="hidden" runat="server" />
        <input id="IdEditHidden"  type="hidden" runat="server" />--%>
        </div>
    </form>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</body>
</html>
