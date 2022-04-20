 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="QuanLiChiTieuWebForm.Home" %>
<!DOCTYPE html>
<html lang="en">

<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Home</title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round|Open+Sans" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KyZXEAg3QhqLMpG8r+8fhAXLRk2vvoC2f3B09zVXn8CA5QIVfZOJ3BCsw2P0p/We" crossorigin="anonymous">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.3/dist/umd/popper.min.js" integrity="sha384-eMNCOe7tC1doHpGoWe/6oMVemdAVTMs2xqW4mwXrXsW0L84Iytr2wi5v2QjrP/xp" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.min.js" integrity="sha384-cn7l7gDp0eyniUwwAZgrzD06kc/tftFf19TOAs2zVinnD/C7E91j9yyk5//jjpt/" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.6.0/Chart.min.js"></script>
    <link rel="stylesheet" type="" href="../Style/QuanLiChiTieu.css">
    <script>
        //function setMonthYear() {
        //    var today = new Date();
        //    var strMonth = "";
        //    var strYear = "";
        //    for (var i = 1; i <= 12; i++) {
        //        if (i == (today.getMonth() + 1)) {
        //            strMonth += ("<option value=" + i + " selected >" + i + "</option>\n");
        //        } else {
        //            strMonth += ("<option value=" + i + ">" + i + "</option>\n");
        //        }
        //    }
        //    for (var i = today.getFullYear() - 11; i <= today.getFullYear(); i++) {
        //        if (i == today.getFullYear()) {
        //            strYear += ("<option value=" + i + " selected >" + i + "</option>\n");
        //        } else {
        //            strYear += ("<option value=" + i + ">" + i + "</option>\n");
        //        }
        //    }
        //    var month = document.querySelectorAll('.month');
        //    var year = document.querySelectorAll('.year');
        //    month.forEach(element => {
        //        element.innerHTML = strMonth;
        //    });
        //    year.forEach(element => {
        //        element.innerHTML = strYear;
        //    });
        //}

        function setNow() {
            var today = new Date();
            document.getElementById("dateIncome").value = today.getFullYear() + "-" + (today.getUTCMonth().toString().length == 1 ? "0" + (today.getUTCMonth() + 1) : today.getUTCMonth() + 1) + "-" + (today.getDate().toString().length == 1 ? "0" + today.getDate() : today.getDate());
        }

        function setFormatMonney() {
            document.getElementById("ValueIncome").classList.remove("is-invalid");
            var valueIncome = document.getElementById("ValueIncome");
            if (valueIncome.value != "") {
                var number = parseInt(valueIncome.value);
                document.getElementById("Foratmonney").innerHTML = number.toLocaleString() + " VND";
            } else {
                document.getElementById("Foratmonney").innerHTML = "";
            }
            document.getElementById("ValueSpending").classList.remove("is-invalid");
            var valueSpending = document.getElementById("ValueSpending");
            if (valueSpending.value != "") {
                var number = parseInt(valueSpending.value);
                document.getElementById("ForatmonneySpending").innerHTML = number.toLocaleString() + " VND";
            } else {
                document.getElementById("ForatmonneySpending").innerHTML = "";
            }
        }

        function submitSpending() {
            var valueSpending = document.getElementById("ValueSpending");
            var dateSpending = document.getElementById("DateSpending");
            valueSpending.classList.remove("is-invalid");
			dateSpending.classList.remove("is-invalid");
            var errorFlg = false;
            if (valueSpending.value == "") {
                valueSpending.classList.add("is-invalid");
                errorFlg = true;
            }
            if (dateSpending.value == "") {
                dateSpending.classList.add("is-invalid");
                errorFlg = true;
            }
            if (!errorFlg) {
                return true;
            }
            else {
                return false;
            }
        }

        function submitIncome() {
            var valueIncome = document.getElementById("ValueIncome");
            var dateIncome = document.getElementById("DateIncome");
            valueIncome.classList.remove("is-invalid");
			dateIncome.classList.remove("is-invalid");
            var form = document.forms.namedItem("form");
            var errorFlg = false;
            if (valueIncome.value == "") {
                valueIncome.classList.add("is-invalid");
                errorFlg = true;
            }
            if (dateIncome.value == "") {
                dateIncome.classList.add("is-invalid");
                errorFlg = true;
            }
			if (!errorFlg) {
                return true;
			}
			else {
				return false;
			}
        }

        function setDispDetailTab() {
            document.getElementById("home-tab").setAttribute("class", "nav-link");
            document.getElementById("home-tab").setAttribute("aria-selected", "false");
            document.getElementById("home").setAttribute("class", "tab-pane fade");
            document.getElementById("profile-tab").setAttribute("class", "nav-link active");
            document.getElementById("profile-tab").setAttribute("aria-selected", "true");
            document.getElementById("profile").setAttribute("class", "tab-pane fade show active");
        }
    </script>
</head>

<body onload="createChart()">
    <div id="codeAlert" runat="server" style="color: red;"></div>
    <form id="form1" runat="server" method="post">
        <header>
            <div class="home">
                <a href="https://phanhiep97nd.github.io/hiepphan/Hieplayout/Hiep-Profile.html" target="_blank">POWER BY Phan Văn Hiệp</a>
            </div>
        </header>
        <nav class="navbar navbar-expand-lg navbar-light bg-light" style="background-color: #398ddc;">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">
                    <h3>Hi <b><asp:Label ID="UserNameLabel" runat="server"></asp:Label></b>!</h3>
                </a>
                <asp:Button ID="BtnLogOut" runat="server" ForeColor="Red" Text="Log Out" OnClientClick="return confirm('Are you sure?');" CssClass="btn btn-danger" BackColor="247, 179, 179"/>
            </div>
        </nav>
        <div style="height: 2px"></div>
        <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #3ebeda;">
            <div class="container-fluid header menu">
                <a class="navbar-brand" href="#">
                    <h2>QUẢN LÍ CHI TIÊU <b>(Finance Management)</b></h2>
                    <b style="font-size: small; color: white">Giúp bạn tính toán các khoản thu nhập và chi tiêu để hoạch định số tiền cần đầu tư!</b>
                </a>
                <div class="d-flex" id="navbarText">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a href="#" class="btn btn-primary mx-auto d-block " data-bs-toggle="modal" data-bs-target="#modalForm"><i class="material-icons">&#xE147;</i> <span>Add New
                                    Income</span></a>
                        </li>
                        <li style="margin-right: 10px;"></li>
                        <li class="nav-item">
                            <a href="#" class="btn btn-primary mx-auto d-block" data-bs-toggle="modal" data-bs-target="#modalFormSpending"><i class="material-icons">&#xE147;</i> <span>Add New
                                    Spending</span></a>
                        </li>
                        <li class="nav-item">
                            <a href="#" class="btn btn-primary"><i class="material-icons">&#xE24D;</i> <span>Export to
                                    CSV</span></a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <div style="height: 20px"></div>
        <ul class="nav nav-tabs" id="myTab" role="tablist">
            <li class="nav-item" role="presentation">
                <button class="nav-link active" id="home-tab" data-bs-toggle="tab" data-bs-target="#home" type="button" role="tab" aria-controls="home" aria-selected="true">BẢNG TỔNG QUÁT</button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link" id="profile-tab" data-bs-toggle="tab" data-bs-target="#profile" type="button" role="tab" aria-controls="profile" aria-selected="false">BẢNG CHI TIẾT</button>
            </li>
        </ul>
        <div class="tab-content" id="myTabContent">
            <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                <div class="row">
                    <div class="col-md" style="padding: 10px;">
                        <div class="w-100 p-3 h-auto" style="background-color: rgb(142, 218, 242); border-radius: 3px;">
                            <div>
                                <h1>Quản lý chi tiêu hàng tháng</h1>
                                <p>Thống kê thu nhập và các khoản chi tiêu hàng tháng, bạn sẽ có cái nhìn rõ hơn về tình trạng tài chính để hoạch định cho tương lai!</p>
                                <hr style="color: white;">
                                <div class="form-group">
                                    <h4>Tháng:</h4>
                                    <%--<select class="form-select month" id="monthOverView" aria-label="Default select example">
                                    </select>--%>
                                    <asp:DropDownList id="MonthOverView" AutoPostBack="true"
                                        runat="server"
                                        CssClass="form-select month">
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
                                </div>
                                <div class="form-group">
                                    <h4>Năm:</h4>
                                    <%--<select class="form-select year" id="yearOverView" aria-label="Default select example">
                                    </select>--%>
                                    <asp:DropDownList id="YearOverView" AutoPostBack="true"
                                        runat="server"
                                        CssClass="form-select year">
                                    </asp:DropDownList>
                                </div>
                                <hr style="border: 1px solid rgb(66, 157, 196);">
                                <h3>Tổng thu nhập</h3>
                                <h2><asp:Label ID="TotalIncome" runat="server"></asp:Label> VND</h2>
                                <hr style="border: 1px solid rgb(66, 157, 196);">
                                <h3>Tổng chi tiêu</h3>
                                <h2><asp:Label ID="TotalSpending" runat="server"></asp:Label> VND</h2>
                                <hr style="border: 1px solid rgb(66, 157, 196);">
                                <h3>Tích lũy tài chính</h3>
                                <h2><asp:Label ID="TotalSaveMoney" runat="server"></asp:Label> VND</h2>
                            </div>
                        </div>
                    </div>
                    <div class="col-md">
                        <div class="">
                            <table style="width: 90%;" cellspacing="30px" cellpadding="10px">
                                <tr>
                                    <td style="width: 70%;">
                                        <h2 style="color: #1348ab;">Thu nhập tháng</h2>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td style="color: #3ebeda;">Tiền lương</td>
                                    <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b><asp:Label ID="ValueIncomeType1" runat="server"></asp:Label> VND</b></td>
                                </tr>
                                <tr>
                                    <td style="color: #3ebeda;">Thu nhập khác</td>
                                    <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b><asp:Label ID="ValueIncomeType2" runat="server"></asp:Label> VND</b></td>
                                </tr>
                            </table>
                            <hr style="color: rgb(54, 109, 138);">
                            <table style="width: 90%;" cellspacing="30px" cellpadding="10px">
                                <tr>
                                    <td style="width: 70%;">
                                        <h2 style="color: #1348ab;">Chi tiêu tháng</h2>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td style="color: #3ebeda;">Nhà/Sinh hoạt phí</td>
                                    <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b><asp:Label ID="ValueSpendingType1" runat="server"></asp:Label> VND</b></td>
                                </tr>
                                <tr>
                                    <td style="color: #3ebeda;">Ăn uống</td>
                                    <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b><asp:Label ID="ValueSpendingType2" runat="server"></asp:Label> VND</b></td>
                                </tr>
                                <tr>
                                    <td style="color: #3ebeda;">Mua sắm</td>
                                    <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b><asp:Label ID="ValueSpendingType3" runat="server"></asp:Label> VND</b></td>
                                </tr>
                                <tr>
                                    <td style="color: #3ebeda;">Quỹ tài chính/Bảo hiểm</td>
                                    <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b><asp:Label ID="ValueSpendingType4" runat="server"></asp:Label> VND</b></td>
                                </tr>
                                <tr>
                                    <td style="color: #3ebeda;">Trả nợ vay</td>
                                    <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b><asp:Label ID="ValueSpendingType5" runat="server"></asp:Label> VND</b></td>
                                </tr>
                                <tr>
                                    <td style="color: #3ebeda;">Di chuyển</td>
                                    <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b><asp:Label ID="ValueSpendingType6" runat="server"></asp:Label> VND</b></td>
                                </tr>
                                <tr>
                                    <td style="color: #3ebeda;">Giải trí</td>
                                    <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b><asp:Label ID="ValueSpendingType7" runat="server"></asp:Label> VND</b></td>
                                </tr>
                                <tr>
                                    <td style="color: #3ebeda;">Giáo dục/Sức khỏe</td>
                                    <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b><asp:Label ID="ValueSpendingType8" runat="server"></asp:Label> VND</b></td>
                                </tr>
                                <tr>
                                    <td style="color: #3ebeda;">Khác</td>
                                    <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b><asp:Label ID="ValueSpendingType9" runat="server"></asp:Label> VND</b></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                <div class="row">
                    <div class="col-md">
                        <div style="margin:10px">
                          <asp:CheckBox ID="ViewAllOnYear" runat="server" Text="Hiển Thị Tất Cả Theo Năm" CssClass="" AutoPostBack="true" Checked="false"/>
                        </div>
                        <h3>Danh Sách Thu Nhập</h3>
                        <div id="codeAlertIncome" runat="server" style="color: red;"></div>
                        <asp:GridView ID="GridView1" runat="server" RowStyle-CssClass="GvRowStyle" Width="100%" ForeColor="#566787" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" Style="margin-bottom: 0px" CellSpacing="5"
                             DataKeyNames="INCOME_ID" CssClass="myGrv" AllowSorting="True" CellPadding="5" HorizontalAlign="Center" ShowFooter="True">
                            <AlternatingRowStyle BackColor="#e6e6e6" />
                            <Columns>
                                <asp:TemplateField HeaderText="Ngày Tháng Năm" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="fullName" runat="server"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.[DATE_INCOME]") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="EditDateIncome" TextMode="Date" runat="server" CssClass="form-control" Text='<%# (object)DateTime.ParseExact(DataBinder.Eval(Container, "DataItem.[DATE_INCOME]").ToString(),"dd/MM/yyyy",null).ToString("yyyy-MM-dd") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterStyle Width="200px" />
                                    <HeaderStyle HorizontalAlign="Center" Width="250px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" Width="250px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Số Tiền" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="valueIncome" runat="server"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.[VALUE_INCOME]", "{0:###,###}") + " VND" %> '>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="EditValueIncome" runat="server" CssClass="form-control form-control-sm"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.[VALUE_INCOME]") %>' TextMode="Number"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Loại Thu Nhập" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="phone" runat="server"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.[TYPE_INCOME]").ToString() == "1" ? "Tiền lương" : "Thu nhập khác" %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList id="EditTypeIncome"
                                            runat="server"
                                            CssClass="form-control" SelectedIndex='<%# int.Parse(DataBinder.Eval(Container, "DataItem.[TYPE_INCOME]").ToString()) - 1 %>'>
                                          <asp:ListItem Value="1"> Tiền Lương </asp:ListItem>
                                          <asp:ListItem Value="2"> Khác </asp:ListItem>
                                       </asp:DropDownList>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="250px" />
                                    <ItemStyle HorizontalAlign="Center" Width="250px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ghi Chú" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="address" runat="server"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.[NOTE_INCOME]") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="EditNoteIncome" runat="server" CssClass="form-control" Text='<%# DataBinder.Eval(Container, "DataItem.[NOTE_INCOME]") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="500px" />
                                    <ItemStyle HorizontalAlign="Center" Width="500px" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="EditButton"
                                            runat="server"
                                            CommandName="Edit"
                                            Text="Edit" CssClass="btn btn-link btn-sm" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="UpdateButton" ForeColor="#299be4"
                                            runat="server"
                                            CommandName="Update"
                                            Text="Update" />&nbsp;
                                        <asp:LinkButton ID="Cancel" ForeColor="#299be4"
                                            runat="server"
                                            CommandName="Cancel"
                                            Text="Cancel" />
                                    </EditItemTemplate>
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="deletebtn" runat="server" CommandName="Delete" CssClass="btn btn-link btn-sm"
                                            Text="Delete" OnClientClick="return confirm('Are you sure?');" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle HorizontalAlign="Left" BackColor="#ddddbb" />
                            <FooterStyle BackColor="142, 218, 242" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle BackColor="142, 218, 242" Font-Size="Large" Height="50px" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            <PagerStyle BackColor="142, 218, 242" ForeColor="White" HorizontalAlign="Center" CssClass="PagingCss" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        <hr style="color: rgb(54, 109, 138);">
                        <h3>Danh Sách Chi Tiêu</h3>
                        <asp:GridView ID="GridView2" runat="server" RowStyle-CssClass="GvRowStyle" Width="100%" ForeColor="#566787" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" Style="margin-bottom: 0px" CellSpacing="5"
                             DataKeyNames="SPENDING_ID" CssClass="myGrv" AllowSorting="True" CellPadding="5" HorizontalAlign="Center" ShowFooter="True">
                            <AlternatingRowStyle BackColor="#e6e6e6" />
                            <Columns>
                                <asp:TemplateField HeaderText="Ngày Tháng Năm" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="fullName" runat="server"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.[DATE_SPENDING]") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="EditDateSPENDING" TextMode="Date" runat="server" CssClass="form-control" Text='<%# (object)DateTime.ParseExact(DataBinder.Eval(Container, "DataItem.[DATE_SPENDING]").ToString(),"dd/MM/yyyy",null).ToString("yyyy-MM-dd") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterStyle Width="200px" />
                                    <HeaderStyle HorizontalAlign="Center" Width="250px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" Width="250px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Số Tiền" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="valueSPENDING" runat="server"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.[VALUE_SPENDING]", "{0:###,###}") + " VND" %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="EditValueSPENDING" runat="server" CssClass="form-control form-control-sm"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.[VALUE_SPENDING]") %>' TextMode="Number"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Loại Thu Nhập" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="phone" runat="server"
                                            Text='<%# ShowTypeSpending(DataBinder.Eval(Container, "DataItem.[TYPE_SPENDING]")) %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="EditPhone" runat="server" CssClass="form-control"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.[TYPE_SPENDING]") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="250px" />
                                    <ItemStyle HorizontalAlign="Center" Width="250px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ghi Chú" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="address" runat="server"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.[NOTE_SPENDING]") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="EditAddress" runat="server" CssClass="form-control" Text='<%# DataBinder.Eval(Container, "DataItem.[NOTE_SPENDING]") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="500px" />
                                    <ItemStyle HorizontalAlign="Center" Width="500px" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="EditButton"
                                            runat="server"
                                            CommandName="Edit"
                                            Text="Edit" CssClass="btn btn-link btn-sm" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="UpdateButton" ForeColor="#299be4"
                                            runat="server"
                                            CommandName="Update"
                                            Text="Update" />&nbsp;
                                        <asp:LinkButton ID="Cancel" ForeColor="#299be4"
                                            runat="server"
                                            CommandName="Cancel"
                                            Text="Cancel" />
                                    </EditItemTemplate>
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="deletebtn" runat="server" CommandName="Delete" CssClass="btn btn-link btn-sm"
                                            Text="Delete" OnClientClick="return confirm('Are you sure?');" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle HorizontalAlign="Left" BackColor="#ddddbb" />
                            <FooterStyle BackColor="142, 218, 242" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle BackColor="142, 218, 242" Font-Size="Large" Height="50px" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            <PagerStyle BackColor="142, 218, 242" ForeColor="White" HorizontalAlign="Center" CssClass="PagingCss" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        <hr style="color: rgb(54, 109, 138);">
                        <div class="container">
                          <div class="row" style="color: crimson;">
                            <div class="col">
                              <h7><asp:Label ID="TotalIncomeOfYear" runat="server"></asp:Label></h7>
                            </div>
                            <div class="col">
                              <h7><asp:Label ID="TotalSpendingOfYear" runat="server"></asp:Label></h7>
                            </div>
                            <div class="col">
                              <h7><asp:Label ID="TotalSaveMoneyOfYear" runat="server"></asp:Label></h7>
                            </div>
                          </div>
                        </div>
                    </div>
                    <div class="col-md">
                        <div class="right-content-detail">
                            <canvas id="myChart"></canvas>
                            <canvas id="myLineChart"></canvas>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal -->
        <div class="modal fade" id="modalForm" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">KHAI THU NHẬP</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <%--<form style="padding:15px" action="" method="" id="form">--%>
                            <div class="form-group">
                                <label for="exampleFormControlTextarea1">Ngày Nhận Được Thu Nhập (tháng/ngày/năm)</label>
                                <asp:TextBox ID="DateIncome" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                    Hãy nhập ngày tháng.
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="exampleFormControlInput1">Số Tiền Thu Nhập (VND)</label>
                                <asp:TextBox ID="ValueIncome" runat="server" CssClass="form-control" TextMode="Number" placeholder="Nhập số tiền ..." onchange="setFormatMonney();"></asp:TextBox>
                                <label style="color:darkseagreen; font-size:15px" id="Foratmonney"></label>
                                <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                    Hãy nhập số tiền.
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="exampleFormControlSelect1">Loại Thu Nhập</label>
                                <%--<select class="form-control" id="typeIncome">
                                    <option value="1" selected>Tiền Lương</option>
                                    <option value="2">Khác</option>
                                </select>--%>
                                <asp:DropDownList id="TypeIncome"
                                    runat="server"
                                    CssClass="form-control">
                                  <asp:ListItem Selected="True" Value="1"> Tiền Lương </asp:ListItem>
                                  <asp:ListItem Value="2"> Khác </asp:ListItem>
                               </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="exampleFormControlTextarea1">Ghi Chú</label>
                                <%--<textarea class="form-control" id="noteIncome" rows="3"></textarea>--%>
                                <asp:TextBox ID="NoteIncome" runat="server" CssClass="form-control" TextMode="multiline" placeholder="Note ..."></asp:TextBox>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                <%--<button type="button" class="btn btn-primary" onclick="submitIncome()">Submit</button>--%>
                                <asp:Button ID="SubmitIncome" runat="server" Text="Submit" OnClientClick="return submitIncome()" CssClass="btn btn-primary"/>
                            </div>
                        <%--</form>--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modalFormSpending" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">KHAI CHI TIÊU</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <%--<form style="padding:15px" action="" method="" id="form">--%>
                            <div class="form-group">
                                <label for="exampleFormControlTextarea1">Ngày Thực hiện chi tiêu (tháng/ngày/năm)</label>
                                <asp:TextBox ID="DateSpending" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                    Hãy nhập ngày tháng.
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="exampleFormControlInput1">Số Tiền Chi Tiêu (VND)</label>
                                <asp:TextBox ID="ValueSpending" runat="server" CssClass="form-control" TextMode="Number" placeholder="Nhập số tiền ..." onchange="setFormatMonney();"></asp:TextBox>
                                <label style="color:darkseagreen; font-size:15px" id="ForatmonneySpending"></label>
                                <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                    Hãy nhập số tiền.
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="exampleFormControlSelect1">Loại Chi Tiêu</label>
                                <asp:DropDownList id="TypeSpending"
                                    runat="server"
                                    CssClass="form-control">
                                  <asp:ListItem Selected="True" Value="1"> Nhà/Sinh hoạt phí </asp:ListItem>
                                  <asp:ListItem Value="2"> Ăn uống </asp:ListItem>
                                  <asp:ListItem Value="3"> Mua sắm </asp:ListItem>
                                  <asp:ListItem Value="4"> Quỹ tài chính/Bảo hiểm </asp:ListItem>
                                  <asp:ListItem Value="5"> Trả nợ vay </asp:ListItem>
                                  <asp:ListItem Value="6"> Di chuyển </asp:ListItem>
                                  <asp:ListItem Value="7"> Giải trí </asp:ListItem>
                                  <asp:ListItem Value="8"> Giáo dục/Sức khỏe </asp:ListItem>
                                  <asp:ListItem Value="9"> Khác </asp:ListItem>
                               </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="exampleFormControlTextarea1">Ghi Chú</label>
                                <%--<textarea class="form-control" id="noteSpending" rows="3"></textarea>--%>
                                <asp:TextBox ID="NoteSpending" runat="server" CssClass="form-control" TextMode="multiline" placeholder="Note ..."></asp:TextBox>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                <%--<button type="button" class="btn btn-primary" onclick="submitSpending()">Submit</button>--%>
                                <asp:Button ID="SubmitSpending" runat="server" Text="Submit" OnClientClick="return submitSpending()" CssClass="btn btn-primary"/>
                            </div>
                        <%--</form>--%>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
<script type="text/javascript">
    function createChart(incomeValue, spendingValue) {
        let lstIncome = [];
        let lstSpending = [];
        for (let i = 0; i < 12; i++) {
            lstIncome[i] = incomeValue.split("|")[i] != "" ? parseInt(incomeValue.split("|")[i]) : 0;
        }
        for (let i = 0; i < 12; i++) {
            lstSpending[i] = spendingValue.split("|")[i] != "" ? parseInt(spendingValue.split("|")[i]) : 0;
        }
        let myChart = document.getElementById('myChart').getContext('2d');
        // Global Options
        Chart.defaults.global.defaultFontFamily = 'Lato';
        Chart.defaults.global.defaultFontSize = 18;
        Chart.defaults.global.defaultFontColor = '#777';

        let massPopChart = new Chart(myChart, {
            type: 'bar', // bar, horizontalBar, pie, line, doughnut, radar, polarArea
            data: {
                labels: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"],
                datasets: [{
                    label: 'Thu',
                    data: [lstIncome[0], lstIncome[1], lstIncome[2], lstIncome[3], lstIncome[4], lstIncome[5], lstIncome[6], lstIncome[7], lstIncome[8], lstIncome[9], lstIncome[10], lstIncome[11]],
                    backgroundColor: "rgba(151,249,190,0.5)",
                    borderWidth: 1,
                    borderColor: '#777',
                    hoverBorderWidth: 3,
                    hoverBorderColor: '#000'
                }, {
                    label: 'Chi',
                    data: [lstSpending[0], lstSpending[1], lstSpending[2], lstSpending[3], lstSpending[4], lstSpending[5], lstSpending[6], lstSpending[7], lstSpending[8], lstSpending[9], lstSpending[10], lstSpending[11]],
                    backgroundColor: "rgba(252,147,65,0.5)",
                    borderWidth: 1,
                    borderColor: '#777',
                    hoverBorderWidth: 3,
                    hoverBorderColor: '#000'
                }]
            },
            options: {
                title: {
                    display: true,
                    text: 'Biểu đồ chi và tiêu',
                    fontSize: 25
                },
                legend: {
                    display: true,
                    position: 'right',
                    labels: {
                        fontColor: '#000'
                    }
                },
                layout: {
                    padding: {
                        left: 50,
                        right: 0,
                        bottom: 0,
                        top: 0
                    }
                },
                tooltips: {
                    enabled: true
                }
            }
        });
        let myLineChart = document.getElementById('myLineChart').getContext('2d');

        let massPopLineChart = new Chart(myLineChart, {
            type: 'line', // bar, horizontalBar, pie, line, doughnut, radar, polarArea
            data: {
                labels: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"],
                datasets: [{
                    label: 'Tích lũy',
                    data: [lstIncome[0] - lstSpending[0], lstIncome[1] - lstSpending[1], lstIncome[2] - lstSpending[2], lstIncome[3] - lstSpending[3], lstIncome[4] - lstSpending[4], lstIncome[5] - lstSpending[5], lstIncome[6] - lstSpending[6], lstIncome[7] - lstSpending[7], lstIncome[8] - lstSpending[8], lstIncome[9] - lstSpending[9], lstIncome[10] - lstSpending[10], lstIncome[11] - lstSpending[11]],
                    borderColor: "rgba(252,147,65,0.5)",
                    pointBackgroundColor: "red",
                    backgroundColor: "rgb(211, 219, 189)",
                }]
            },
            options: {
                title: {
                    display: true,
                    text: 'Biểu đồ tích lũy tài chính',
                    fontSize: 25
                },
                legend: {
                    display: true,
                    position: 'right',
                    labels: {
                        fontColor: '#000'
                    }
                },
                layout: {
                    padding: {
                        left: 50,
                        right: 0,
                        bottom: 0,
                        top: 0
                    }
                },
                tooltips: {
                    enabled: true
                }
            }
        });
    }
</script>
</html>