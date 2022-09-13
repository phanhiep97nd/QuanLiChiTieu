<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="LoanDebt.aspx.cs" Inherits="QuanLiChiTieuWebForm.LoanDebt" %>

<!DOCTYPE html>
<html lang="en">

<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Quản lý vay nợ</title>
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
        function setMonthYear() {
            var today = new Date();
            var strMonth = "";
            var strYear = "";
            for (var i = 1; i <= 12; i++) {
                if (i == (today.getMonth() + 1)) {
                    strMonth += ("<option value=" + i + " selected >" + i + "</option>\n");
                } else {
                    strMonth += ("<option value=" + i + ">" + i + "</option>\n");
                }
            }
            for (var i = today.getFullYear() - 11; i <= today.getFullYear(); i++) {
                if (i == today.getFullYear()) {
                    strYear += ("<option value=" + i + " selected >" + i + "</option>\n");
                } else {
                    strYear += ("<option value=" + i + ">" + i + "</option>\n");
                }
            }
            var month = document.querySelectorAll('.month');
            var year = document.querySelectorAll('.year');
            month.forEach(element => {
                element.innerHTML = strMonth;
            });
            year.forEach(element => {
                element.innerHTML = strYear;
            });
        }

        function setFormatMonney() {
            document.getElementById("ValueLoan").classList.remove("is-invalid");
            var ValueLoan = document.getElementById("ValueLoan");
            if (ValueLoan.value != "") {
                var number = parseInt(ValueLoan.value);
                document.getElementById("Foratmonney").innerHTML = number.toLocaleString() + " VND";
            } else {
                document.getElementById("Foratmonney").innerHTML = "";
            }
            document.getElementById("ValueDebt").classList.remove("is-invalid");
            var valueDebt = document.getElementById("ValueDebt");
            if (valueDebt.value != "") {
                var number = parseInt(valueDebt.value);
                document.getElementById("ForatmonneyDebt").innerHTML = number.toLocaleString() + " VND";
            } else {
                document.getElementById("ForatmonneyDebt").innerHTML = "";
            }
        }

        function submitDebt() {
            var valueDebt = document.getElementById("ValueDebt");
            var dateDebt = document.getElementById("DateDebt");
            var HumanDebt = document.getElementById("HumanDebt");
            valueDebt.classList.remove("is-invalid");
            dateDebt.classList.remove("is-invalid");
            HumanDebt.classList.remove("is-invalid");
            var errorFlg = false;
            if (valueDebt.value == "") {
                valueDebt.classList.add("is-invalid");
                errorFlg = true;
            }
            if (dateDebt.value == "") {
                dateDebt.classList.add("is-invalid");
                errorFlg = true;
            }
            if (HumanDebt.value == "") {
                HumanDebt.classList.add("is-invalid");
                errorFlg = true;
            }
            if (!errorFlg) {
                return true;
            }
            else {
                return false;
            }
        }

        function submitLoan() {
            var ValueLoan = document.getElementById("ValueLoan");
            var dateLoan = document.getElementById("DateLoan");
            var HumanLoan = document.getElementById("HumanLoan");
            ValueLoan.classList.remove("is-invalid");
            dateLoan.classList.remove("is-invalid");
            HumanLoan.classList.remove("is-invalid");
            var form = document.forms.namedItem("form");
            var errorFlg = false;
            if (ValueLoan.value == "") {
                ValueLoan.classList.add("is-invalid");
                errorFlg = true;
            }
            if (dateLoan.value == "") {
                dateLoan.classList.add("is-invalid");
                errorFlg = true;
            }
            if (HumanLoan.value == "") {
                HumanLoan.classList.add("is-invalid");
                errorFlg = true;
            }
            if (!errorFlg) {
                return true;
            }
            else {
                return false;
            }
        }

        document.querySelectorAll("img").forEach((item) => {
            item.addEventListener("click", (event) => {
                const image = event.target.getAttribute("data-src");
                event.target.setAttribute("src", image);
            });
        });

        function DeleteLoan(id) {
            if (confirm("Bạn có muốn xóa bản ghi cho vay?")) {
                document.getElementById("IdDelete").value = id;
                document.getElementById("btnDeleteLoan").click();
            }
        }

        function DeleteDebt(id) {
            if (confirm("Bạn có muốn xóa bản ghi ds nợ?")) {
                document.getElementById("IdDelete").value = id;
                document.getElementById("btnDeleteDebt").click();
            }
        }

        var popupWindow = null;
        function OpenEditWindow(typeEdit, id) {
            //window.showModalDialog("EditLoanDebt.aspx?typeEdit=" + typeEdit + "&id=" + id, "", "center:yes;resizable:no;dialogHeight:480px;dialogWidth:750px;");
            popupWindow = window.open("EditLoanDebt.aspx?typeEdit=" + typeEdit + "&id=" + id, "_blank", 'directories=no,scrollbars=no,status=no,unadorned=no,location=no,toolbar=no,menubar=no,resizable=yes,help=no,height=737,width=1280');
        }

        function parent_disable() {
            if (popupWindow && !popupWindow.closed) {
                popupWindow.focus();
                document.getElementById("overlay").innerHTML = "<div style='position:absolute;left:0;top:0;width:100%;height:" + document.body.offsetHeight + "px;opacity:0.3;z-index:999;background:#000;'></div>";
            }
        }
        window.onunload = refreshParent;
        function refreshParent() {
            window.opener.location.reload();
        }
    </script>
</head>

<body onFocus="parent_disable();" onclick="parent_disable();">
    <%--<div style="position:absolute;width:100%;height:stretch;opacity:0.3;z-index:999;background:#000;"></div>--%>
    <form id="form1" runat="server" method="post">
        <div id="codeAlert" runat="server" style="color: red;"></div>
        <header>
            <div class="home">
                <a href="https://phanhiep97nd.github.io/hiepphan/Hieplayout/Hiep-Profile.html" target="_blank">POWER BY Phan Văn Hiệp</a>
            </div>
        </header>
        <nav class="navbar navbar-expand-lg navbar-light bg-light" style="background-color: #398ddc;">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">
                    <h3>Hi <b>
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
                    <button type="button" class="list-group-item list-group-item-info list-group-item-action" disabled>> Quản Lý Vay Nợ</button>
                    <asp:Button ID="WeddingListBtn" runat="server" CssClass="list-group-item list-group-item-info list-group-item-action" Text=" > Quản Lý Danh Sách Hiếu Hỷ"/>
                </div>
            </div>
        </div>
        <nav class="navbar navbar-expand-lg navbar-collapse">
            #Bạn đang ở trang Quản lý danh sách vay nợ!
        </nav>
        <div style="height: 2px"></div>
        <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #aed2a3;">
            <div class="container-fluid header menu">
                <a class="navbar-brand" href="#">
                    <h2>QUẢN LÍ CHI TIÊU <b>(Finance Management)</b></h2>
                    <b style="font-size: small; color: white">Giúp bạn tính toán các khoản thu nhập và chi tiêu để hoạch định số tiền cần đầu tư!</b>
                </a>
                <div class="d-flex" id="navbarText">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a href="#" class="btn btn-primary mx-auto d-block btn-right" data-bs-toggle="modal" data-bs-target="#modalForm"><i class="material-icons">&#xE147;</i> <span>Thêm mới danh sách cho vay</span></a>
                        </li>
                        <li style="margin-right: 10px;"></li>
                        <li class="nav-item">
                            <a href="#" class="btn btn-primary mx-auto d-block btn-right" data-bs-toggle="modal" data-bs-target="#modalFormDebt"><i class="material-icons">&#xE147;</i> <span>Thêm mới danh sách nợ</span></a>
                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="ExportCsv" runat="server" CssClass="btn btn-primary btn-right" OnClientClick="return confirm('Do you want export all data?');"><i class="material-icons">&#xE24D;</i> <span>Export to
                                    Excel</span></asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <div style="height: 20px"></div>
        <nav class="navbar navbar-light bg-light">
            <div class="container-fluid">
                <div class="navbar-brand">
                    <label class="form-control">
                        <asp:CheckBox ID="ViewAllCheckBox" runat="server" CssClass="CheckBox" AutoPostBack="true" />
                        Hiển Thị Toàn Bộ Năm
                    </label>
                </div>
                <div class="d-flex">
                    <asp:Label runat="server" ID="MonthSearchLabel"><h6 class="navbar-brand">Tháng:</h6></asp:Label>
                    <asp:DropDownList ID="MonthSearch"
                        runat="server"
                        CssClass="form-select form-select-sm month" Style="width: 20%; margin-right: 10px;">
                        <asp:ListItem Value="01"> 01 </asp:ListItem>
                        <asp:ListItem Value="02"> 02 </asp:ListItem>
                        <asp:ListItem Value="03"> 03 </asp:ListItem>
                        <asp:ListItem Value="04"> 04 </asp:ListItem>
                        <asp:ListItem Value="05"> 05 </asp:ListItem>
                        <asp:ListItem Value="06"> 06 </asp:ListItem>
                        <asp:ListItem Value="07"> 07 </asp:ListItem>
                        <asp:ListItem Value="08"> 08 </asp:ListItem>
                        <asp:ListItem Value="09"> 09 </asp:ListItem>
                        <asp:ListItem Value="10"> 10 </asp:ListItem>
                        <asp:ListItem Value="11"> 11 </asp:ListItem>
                        <asp:ListItem Value="12"> 12 </asp:ListItem>
                    </asp:DropDownList>
                    <h6 class="navbar-brand">Năm:</h6>
                    <asp:DropDownList ID="YearSearch"
                        runat="server"
                        CssClass="form-select form-select-sm year" Style="width: 30%; margin-right: 10px;">
                    </asp:DropDownList>
                    <h6 class="navbar-brand">| Trạng thái:</h6>
                    <asp:DropDownList ID="StatusSearch"
                        runat="server"
                        CssClass="form-select form-select-sm" Style="width: 50%; margin-right: 10px;">
                        <asp:ListItem Value="1"> Tất cả </asp:ListItem>
                        <asp:ListItem Value="2"> Chưa trả </asp:ListItem>
                        <asp:ListItem Value="3"> Đã trả </asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="NameSearch" runat="server" CssClass="form-control me-2" type="search" placeholder="Người vay/ Cho vay" aria-label="Search"></asp:TextBox>
                    <asp:Button ID="SearchBtn" runat="server" CssClass="btn btn-outline-success" Text="Search" />
                </div>
            </div>
        </nav>
        <hr style="color: rgb(54, 109, 138);">
        <div class="row">
            <div class="col-md">
                <h4 style="text-align: center; color: rgb(174, 199, 118);">Danh sách cho vay</h4>
                <div id="Loan" runat="server">
                    <div class="card bg-light">
                        <div class="card-header" id="heading">
                            <h5 class="mb-0">
                                <div class="container">
                                    <div class="row">
                                        <div class="col">
                                            <asp:LinkButton ID="LinkSortDateLoan" runat="server">Ngày tháng</asp:LinkButton>
                                        </div>
                                        <div class="col">
                                            <asp:LinkButton ID="LinkSortHumanLoan" runat="server">Người vay</asp:LinkButton>
                                        </div>
                                        <div class="col">
                                            <asp:LinkButton ID="LinkSortValueLoan" runat="server">Số tiền</asp:LinkButton>
                                        </div>
                                        <div class="col">
                                            <asp:LinkButton ID="LinkSortStatusLoan" runat="server">Trạng thái</asp:LinkButton>
                                        </div>
                                        <div class="col">
                                        </div>
                                    </div>
                                </div>
                            </h5>
                        </div>
                    </div>
                    <div id="ElementLoan" runat="server"></div>
                    <%--<div class="card bg-light">
                        <div class="card-header" id="heading">
                            <h5 class="mb-0">
                                <div class="container">
                                    <div class="row">
                                        <div class="col">
                                            <asp:LinkButton runat="server">Ngày tháng</asp:LinkButton>
                                        </div>
                                        <div class="col">
                                            <asp:LinkButton runat="server">Người</asp:LinkButton>
                                        </div>
                                        <div class="col">
                                            <asp:LinkButton runat="server">Số tiền</asp:LinkButton>
                                        </div>
                                        <div class="col">
                                            <asp:LinkButton runat="server">Trạng thái</asp:LinkButton>
                                        </div>
                                        <div class="col">
                                        </div>
                                    </div>
                                </div>
                            </h5>
                        </div>
                    </div>
                    <div class="card card-loan">
                        <div class="card-header" id="headingOneLoan">
                            <h5 class="mb-0">
                                <div class="container">
                                    <div class="row">
                                        <div class="col">
                                            2022/01/01
                                        </div>
                                        <div class="col">
                                            Tươi
                                        </div>
                                        <div class="col">
                                            2000000000 VND
                                        </div>
                                        <div class="col">
                                            Chưa trả <i class="fa fa-times-circle-o" style="font-size: 20px; color: red"></i>
                                        </div>
                                        <div class="col">
                                            <a class="btn btn-link" data-toggle="collapse" data-target="#collapseOneLoan" aria-expanded="true" aria-controls="collapseOne" style="color: #00b8e6">#Xem Chi tiết
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </h5>
                        </div>
                        <div id="collapseOneLoan" class="collapse" aria-labelledby="headingOne" data-parent="#accordion" runat="server">
                            <div class="card-body">
                                <div class="container">
                                    <div class="row">
                                        <div class="col">
                                            Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird
                                        on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat
                                        craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                        </div>
                                        <div class="col">
                                            <img src="../Images/2020-06-06.png" class="img-thumbnail" alt="..." onclick="window.open('Images/sss.png', '_blank');">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr style="color: rgb(54, 109, 138);">
                            <div class="container">
                                <div class="row">
                                    <div class="col">
                                        <h4>Đã trả ngày : 2022/10/03</h4>
                                        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird
                                        on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat
                                        craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                    </div>
                                    <div class="col">
                                        <img src="../Images/sss.png" class="img-thumbnail" alt="..." onclick="window.open('Images/sss.png', '_blank');">
                                    </div>
                                </div>
                            </div>
                            <button type="button" class="btn btn-outline-danger btn-row">Delete</button>
                            <button type="button" class="btn btn-outline-primary btn-row">Edit</button>
                        </div>
                    </div>
                    <div class="card card-loan-done">
                        <div class="card-header" id="headingTwo">
                            <h5 class="mb-0">
                                <div class="container">
                                    <div class="row">
                                        <div class="col">
                                            2022/01/01
                                        </div>
                                        <div class="col">
                                            Ngọc Trâm
                                        </div>
                                        <div class="col">
                                            2000000 VND
                                        </div>
                                        <div class="col">
                                            Đã trả <i class="fa fa-check-circle" style="font-size: 20px; color: yellow"></i>
                                        </div>
                                        <div class="col">
                                            <button class="btn btn-link" data-toggle="collapse" data-target="#collapseTwoLoan" aria-expanded="true" aria-controls="collapseOne">
                                                #Xem Chi tiết
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </h5>
                        </div>
                        <div id="collapseTwoLoan" class="collapse" aria-labelledby="headingTwo" data-parent="#accordion">
                            <div class="card-body">
                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird
                            on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft
                            beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                            </div>
                        </div>
                    </div>
                    <div class="card card-loan">
                        <div class="card-header" id="headingThree">
                            <h5 class="mb-0">
                                <div class="container">
                                    <div class="row">
                                        <div class="col">
                                            2022/01/01
                                        </div>
                                        <div class="col">
                                            Tươi
                                        </div>
                                        <div class="col">
                                            2000000 VND
                                        </div>
                                        <div class="col">
                                            Chưa trả <i class="fa fa-times-circle-o" style="font-size: 20px; color: red"></i>
                                        </div>
                                        <div class="col">
                                            <button class="btn btn-link" data-toggle="collapse" data-target="#collapseThreeLoan" aria-expanded="true" aria-controls="collapseOne">
                                                #Xem Chi tiết
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </h5>
                        </div>
                        <div id="collapseThreeLoan" class="collapse" aria-labelledby="headingThree" data-parent="#accordion">
                            <div class="card-body">
                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird
                            on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft
                            beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                            </div>
                        </div>
                    </div>--%>
                </div>
            </div>
            <div class="col-md">
                <h4 style="text-align: center; color: rgb(174, 199, 118);">Danh sách Nợ</h4>
                <div id="accordion Debt">
                    <div class="card bg-light">
                        <div class="card-header" id="headingDebt">
                            <h5 class="mb-0">
                                <div class="container">
                                    <div class="row">
                                        <div class="col">
                                            <asp:LinkButton ID="LinkSortDateDebt" runat="server">Ngày tháng</asp:LinkButton>
                                        </div>
                                        <div class="col">
                                            <asp:LinkButton ID="LinkSortHumanDebt" runat="server">Người cho vay</asp:LinkButton>
                                        </div>
                                        <div class="col">
                                            <asp:LinkButton ID="LinkSortValueDebt" runat="server">Số tiền</asp:LinkButton>
                                        </div>
                                        <div class="col">
                                            <asp:LinkButton ID="LinkSortStatusDebt" runat="server">Trạng thái</asp:LinkButton>
                                        </div>
                                        <div class="col">
                                        </div>
                                    </div>
                                </div>
                            </h5>
                        </div>
                    </div>
                    <div id="ElementDebt" runat="server"></div>
                    <%--<div class="card card-debt">
                        <div class="card-header" id="headingOne">
                            <h5 class="mb-0">
                                <div class="container">
                                    <div class="row">
                                        <div class="col">
                                            2022/01/01
                                        </div>
                                        <div class="col">
                                            Tươi
                                        </div>
                                        <div class="col">
                                            2000000 VND
                                        </div>
                                        <div class="col">
                                            Chưa trả <i class="fa fa-times-circle-o" style="font-size: 20px; color: red"></i>
                                        </div>
                                        <div class="col">
                                            <button class="btn btn-link" data-toggle="collapse" data-target="#collapseOneDebt" aria-expanded="true" aria-controls="collapseOne">
                                                #Xem Chi tiết
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </h5>
                        </div>
                        <div id="collapseOneDebt" class="collapse" aria-labelledby="headingOne" data-parent="#accordion">
                            <div class="card-body">
                                <div class="container">
                                    <div class="row">
                                        <div class="col">
                                            Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird
                                        on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat
                                        craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                        </div>
                                        <div class="col">
                                            <img src="test.jpg" class="img-thumbnail" alt="...">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <img src="test.jpg" class="img-thumbnail" alt="...">
                            </div>
                            <button type="button" class="btn btn-outline-danger btn-row">Delete</button>
                            <button type="button" class="btn btn-outline-primary btn-row">Edit</button>
                        </div>
                    </div>
                    <div class="card card-debt">
                        <div class="card-header" id="headingTwo">
                            <h5 class="mb-0">
                                <div class="container">
                                    <div class="row">
                                        <div class="col">
                                            2022/01/01
                                        </div>
                                        <div class="col">
                                            Tươi
                                        </div>
                                        <div class="col">
                                            2000000 VND
                                        </div>
                                        <div class="col">
                                            Chưa trả <i class="fa fa-times-circle-o" style="font-size: 20px; color: red"></i>
                                        </div>
                                        <div class="col">
                                            <button class="btn btn-link" data-toggle="collapse" data-target="#collapseTwoDebt" aria-expanded="true" aria-controls="collapseOne">
                                                #Xem Chi tiết
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </h5>
                        </div>
                        <div id="collapseTwoDebt" class="collapse" aria-labelledby="headingTwo" data-parent="#accordion">
                            <div class="card-body">
                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird
                            on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft
                            beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                            </div>
                        </div>
                    </div>
                    <div class="card card-debt-done">
                        <div class="card-header" id="headingThree">
                            <h5 class="mb-0">
                                <div class="container">
                                    <div class="row">
                                        <div class="col">
                                            2022/01/01
                                        </div>
                                        <div class="col">
                                            Tươi
                                        </div>
                                        <div class="col">
                                            2000000 VND
                                        </div>
                                        <div class="col">
                                            Đã trả <i class="fa fa-check-circle" style="font-size: 20px; color: yellow"></i>
                                        </div>
                                        <div class="col">
                                            <button class="btn btn-link" data-toggle="collapse" data-target="#collapseThreeDebt" aria-expanded="true" aria-controls="collapseOne">
                                                #Xem Chi tiết
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </h5>
                        </div>
                        <div id="collapseThreeDebt" class="collapse" aria-labelledby="headingThree" data-parent="#accordion">
                            <div class="card-body">
                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird
                            on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft
                            beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                            </div>
                            <img src="test.jpg" class="img-thumbnail" alt="...">
                        </div>
                    </div>--%>
                </div>
            </div>
        </div>
        <!-- Modal -->
        <div class="modal fade" id="modalForm" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">THÊM MỚI DANH SÁCH CHO VAY</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="exampleFormControlTextarea1">Ngày Cho Vay (tháng/ngày/năm)(*)</label>
                            <asp:TextBox ID="DateLoan" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập ngày tháng.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlSelect1">Người Vay(*)</label>
                            <asp:TextBox ID="HumanLoan" runat="server" CssClass="form-control" placeholder="Nhập tên người vay ..."></asp:TextBox>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập tên người vay.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlInput1">Số Tiền Cho Vay (VND)(*)</label>
                            <asp:TextBox ID="ValueLoan" runat="server" CssClass="form-control" TextMode="Number" placeholder="Nhập số tiền ..." onchange="setFormatMonney();"></asp:TextBox>
                            <label style="color: darkseagreen; font-size: 15px" id="Foratmonney"></label>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập số tiền.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlTextarea1">Ghi Chú</label>
                            <asp:TextBox ID="NoteLoan" runat="server" CssClass="form-control" TextMode="multiline" placeholder="Note ..."></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="formFileSm" class="form-label">Đính kèm ảnh</label>
                            <asp:FileUpload runat="server" class="form-control form-control-sm" ID="OFileLoan" type="file" accept="image/png, image/gif, image/jpeg" />
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <asp:Button ID="SubmitLoan" runat="server" Text="Submit" OnClientClick="return submitLoan()" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modalFormDebt" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">THÊM MỚI DANH SÁCH NỢ</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="exampleFormControlTextarea1">Ngày Vay (tháng/ngày/năm)(*)</label>
                            <asp:TextBox ID="DateDebt" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập ngày tháng.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlSelect1">Người Cho Vay(*)</label>
                            <asp:TextBox ID="HumanDebt" runat="server" CssClass="form-control" placeholder="Nhập tên người cho vay ..."></asp:TextBox>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập tên người vay.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlInput1">Số Tiền Vay (VND)(*)</label>
                            <asp:TextBox ID="ValueDebt" runat="server" CssClass="form-control" TextMode="Number" placeholder="Nhập số tiền ..." onchange="setFormatMonney();"></asp:TextBox>
                            <label style="color: darkseagreen; font-size: 15px" id="ForatmonneyDebt"></label>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập số tiền.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlTextarea1">Ghi Chú</label>
                            <asp:TextBox ID="NoteDebt" runat="server" CssClass="form-control" TextMode="multiline" placeholder="Note ..."></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="formFileSm" class="form-label">Đính kèm ảnh</label>
                            <asp:FileUpload runat="server" class="form-control form-control-sm" ID="OFileDebt" type="file" accept="image/png, image/gif, image/jpeg" />
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <asp:Button ID="SubmitDebt" runat="server" Text="Submit" OnClientClick="return submitDebt()" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Button runat="server" ID="btnDeleteLoan" ClientIDMode="Static" Text="" style="display:none;" OnClick="btnDeleteLoan_Click" />
        <asp:Button runat="server" ID="btnDeleteDebt" ClientIDMode="Static" Text="" style="display:none;" OnClick="btnDeleteDebt_Click" />
        <input id="IdDelete"  type="hidden" runat="server" />
    </form>
    <div id="overlay"></div>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</body>

</html>
