<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeddingMonney.aspx.cs" Inherits="QuanLiChiTieuWebForm.WeddingMonney" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Danh sách tiền mừng cưới hỏi ...</title>
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
        function setFormatMonney() {
            document.getElementById("ValueGive").classList.remove("is-invalid");
            var ValueGive = document.getElementById("ValueGive");
            if (ValueGive.value != "") {
                var number = parseInt(ValueGive.value);
                document.getElementById("Foratmonney").innerHTML = number.toLocaleString() + " VND";
            } else {
                document.getElementById("Foratmonney").innerHTML = "";
            }
            document.getElementById("ValueTake").classList.remove("is-invalid");
            var valueTake = document.getElementById("ValueTake");
            if (valueTake.value != "") {
                var number = parseInt(valueTake.value);
                document.getElementById("ForatmonneyTake").innerHTML = number.toLocaleString() + " VND";
            } else {
                document.getElementById("ForatmonneyTake").innerHTML = "";
            }
        }

        function submitTake() {
            var valueTake = document.getElementById("ValueTake");
            var dateTake = document.getElementById("DateTake");
            var HumanTake = document.getElementById("HumanTake");
            var GroupTake = document.getElementById("GroupTake");
            valueTake.classList.remove("is-invalid");
            dateTake.classList.remove("is-invalid");
            HumanTake.classList.remove("is-invalid");
            GroupTake.classList.remove("is-invalid");
            var errorFlg = false;
            if (valueTake.value == "") {
                valueTake.classList.add("is-invalid");
                errorFlg = true;
            }
            if (dateTake.value == "") {
                dateTake.classList.add("is-invalid");
                errorFlg = true;
            }
            if (HumanTake.value == "") {
                HumanTake.classList.add("is-invalid");
                errorFlg = true;
            }
            if (GroupTake.value == "") {
                GroupTake.classList.add("is-invalid");
                errorFlg = true;
            }
            if (!errorFlg) {
                return true;
            }
            else {
                return false;
            }
        }

        function submitGive() {
            var ValueGive = document.getElementById("ValueGive");
            var dateGive = document.getElementById("DateGive");
            var HumanGive = document.getElementById("HumanGive");
            ValueGive.classList.remove("is-invalid");
            dateGive.classList.remove("is-invalid");
            HumanGive.classList.remove("is-invalid");
            GroupGive.classList.remove("is-invalid");
            var form = document.forms.namedItem("form");
            var errorFlg = false;
            if (ValueGive.value == "") {
                ValueGive.classList.add("is-invalid");
                errorFlg = true;
            }
            if (dateGive.value == "") {
                dateGive.classList.add("is-invalid");
                errorFlg = true;
            }
            if (HumanGive.value == "") {
                HumanGive.classList.add("is-invalid");
                errorFlg = true;
            }
            if (GroupGive.value == "") {
                GroupGive.classList.add("is-invalid");
                errorFlg = true;
            }
            if (!errorFlg) {
                return true;
            }
            else {
                return false;
            }
        }

        function changeTab(tabIndex) {
            document.getElementById("TabIndex").value = tabIndex;
        }

        function setDispSecondTab() {
            document.getElementById("give-tab").setAttribute("class", "nav-link");
            document.getElementById("give-tab").setAttribute("aria-selected", "false");
            document.getElementById("give").setAttribute("class", "tab-pane fade");
            document.getElementById("take-tab").setAttribute("class", "nav-link active");
            document.getElementById("take-tab").setAttribute("aria-selected", "true");
            document.getElementById("take").setAttribute("class", "tab-pane fade show active");
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="codeAlert" runat="server" style="color: red;"></div>
            <header>
                <div class="home">
                    <a href="https://phanhiep97nd.github.io/hiepphan/Hieplayout/Hiep-Profile.html" target="_blank">POWER BY Phan Văn Hiệp</a>
                </div>
            </header>
            <nav class="navbar navbar-expand-lg navbar-light bg-light" style="background-color: #4db8ff;">
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
                        <asp:Button ID="LoanDebtBtn" runat="server" CssClass="list-group-item list-group-item-info list-group-item-action" Text=" > Quản Lý Vay Nợ" />
                        <button type="button" class="list-group-item list-group-item-info list-group-item-action" disabled>Quản Lý Danh Sách Hiếu Hỷ</button>
                    </div>
                </div>
            </div>
            <nav class="navbar navbar-expand-lg navbar-collapse">
                #Bạn đang ở trang Quản lý danh sách tiền mừng...!
            </nav>
            <div style="height: 2px"></div>
            <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #999999;">
                <div class="container-fluid header menu">
                    <a class="navbar-brand" href="#">
                        <h2>QUẢN LÍ CHI TIÊU <b>(Finance Management)</b></h2>
                        <b style="font-size: small; color: white">Giúp bạn tính toán các khoản thu nhập và chi tiêu để hoạch định số tiền cần đầu tư!</b>
                    </a>
                    <div class="d-flex" id="navbarText">
                        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                            <li class="nav-item">
                                <a href="#" class="btn btn-primary mx-auto d-block btn-right" data-bs-toggle="modal" data-bs-target="#modalGive"><i class="material-icons">&#xE147;</i> <span>Thêm mới danh sách đi tiền</span></a>
                            </li>
                            <li style="margin-right: 10px;"></li>
                            <li class="nav-item">
                                <a href="#" class="btn btn-primary mx-auto d-block btn-right" data-bs-toggle="modal" data-bs-target="#modalFormTake"><i class="material-icons">&#xE147;</i> <span>Thêm mới danh sách nhận tiền</span></a>
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
                        <asp:TextBox ID="NameSearch" runat="server" CssClass="form-control me-2" type="search" placeholder="Người..." aria-label="Search"></asp:TextBox>
                        <asp:Button ID="SearchBtn" runat="server" CssClass="btn btn-outline-success" Text="Search" />
                    </div>
                </div>
            </nav>
            <ul class="nav nav-tabs" id="myTab" role="tablist">
                <li class="nav-item" role="presentation">
                    <button class="nav-link active" id="give-tab" data-bs-toggle="tab" data-bs-target="#give" type="button" role="tab" aria-controls="give" aria-selected="true" onclick="changeTab('1');">DS ĐI CHO NGƯỜI KHÁC</button>
                </li>
                <li class="nav-item" role="presentation">
                    <button class="nav-link" id="take-tab" data-bs-toggle="tab" data-bs-target="#take" type="button" role="tab" aria-controls="take" aria-selected="false" onclick="changeTab('2');">DS NGƯỜI KHÁC ĐI CHO MÌNH</button>
                </li>
            </ul>
            <div class="tab-content" id="myTabContent">
                <div class="tab-pane fade show active" id="give" role="tabpanel" aria-labelledby="give-tab">
                    <div id="codeAlertGive" runat="server" style="color: red;"></div>
                    <div style="height: 20px"></div>
                    <asp:GridView ID="GridView1" runat="server" RowStyle-CssClass="GvRowStyle" Width="100%" ForeColor="#566787" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" Style="margin-bottom: 0px" CellSpacing="5"
                        DataKeyNames="WFM_GIVE_ID" CssClass="myGrv" AllowSorting="True" CellPadding="5" HorizontalAlign="Center" ShowFooter="True">
                        <AlternatingRowStyle BackColor="#e6e6e6" />
                        <Columns>
                            <asp:TemplateField HeaderText="Ngày Tháng Năm" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" SortExpression="DATE_WFM_GIVE_SORT">
                                <ItemTemplate>
                                    <asp:Label ID="fullName" runat="server"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[DATE_WFM_GIVE]") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="EditDateGive" TextMode="Date" runat="server" CssClass="form-control" Text='<%# (object)DateTime.ParseExact(DataBinder.Eval(Container, "DataItem.[DATE_WFM_GIVE]").ToString(),"dd/MM/yyyy",null).ToString("yyyy-MM-dd") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterStyle Width="200px" />
                                <HeaderStyle HorizontalAlign="Center" Width="250px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="250px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Số Tiền" HeaderStyle-CssClass="text-center" SortExpression="VALUE_WFM_GIVE">
                                <ItemTemplate>
                                    <asp:Label ID="valueGive" runat="server"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[VALUE_WFM_GIVE]", "{0:###,###}") + " VND" %> '>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="EditValueGive" runat="server" CssClass="form-control form-control-sm"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[VALUE_WFM_GIVE]") %>' TextMode="Number"></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Loại" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="typeGive" runat="server"
                                        Text='<%# ShowType(DataBinder.Eval(Container, "DataItem.[TYPE_WFM_GIVE]")) %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="EditTypeGive"
                                        runat="server"
                                        CssClass="form-control" SelectedIndex='<%# int.Parse(DataBinder.Eval(Container, "DataItem.[TYPE_WFM_GIVE]").ToString()) - 1 %>'>
                                        <asp:ListItem Value="1"> Mừng cưới </asp:ListItem>
                                        <asp:ListItem Value="2"> Đám hiếu </asp:ListItem>
                                        <asp:ListItem Value="3"> Mừng nhà </asp:ListItem>
                                        <asp:ListItem Value="4"> Khác </asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="250px" />
                                <ItemStyle HorizontalAlign="Center" Width="250px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Người nhận" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="humanGive" runat="server" Style="word-wrap: normal; word-break: break-all;"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[HUMAN_WFM_GIVE]") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="EditHumanGive" runat="server" CssClass="form-control" Text='<%# DataBinder.Eval(Container, "DataItem.[HUMAN_WFM_GIVE]") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="500px" />
                                <ItemStyle HorizontalAlign="Center" Width="500px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nhóm (Quan hệ)" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="groupGive" runat="server" Style="word-wrap: normal; word-break: break-all;"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[GROUP_WFM_GIVE]") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="EditGroupGive" runat="server" CssClass="form-control" Text='<%# DataBinder.Eval(Container, "DataItem.[GROUP_WFM_GIVE]") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="500px" />
                                <ItemStyle HorizontalAlign="Center" Width="500px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ghi Chú" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="noteGive" runat="server" Style="word-wrap: normal; word-break: break-all;"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[NOTE_WFM_GIVE]") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="EditNoteGive" runat="server" CssClass="form-control" Text='<%# DataBinder.Eval(Container, "DataItem.[NOTE_WFM_GIVE]") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="500px" />
                                <ItemStyle HorizontalAlign="Center" Width="500px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Trạng thái" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="statusGive" runat="server" Style='<%# DataBinder.Eval(Container, "DataItem.[STATUS_WFM_GIVE]").ToString() == "1" ? "color: #00e600" : "color: Red" %>'
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[STATUS_WFM_GIVE]").ToString() == "1" ? "Đã đi lại ✓!" : "Chưa đi lại ✗!" %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList id="EditStatusGive"
                                            runat="server"
                                            CssClass="form-control" SelectedIndex='<%# int.Parse(DataBinder.Eval(Container, "DataItem.[STATUS_WFM_GIVE]").ToString()) %>'>
                                          <asp:ListItem Value="0"> Đã trả </asp:ListItem>
                                          <asp:ListItem Value="1"> Chưa trả </asp:ListItem>
                                       </asp:DropDownList>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="500px" />
                                <ItemStyle HorizontalAlign="Center" Width="500px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ngày Đi Lại" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="dateGiveFinish" runat="server"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[DATE_WFM_GIVE_FINISH]") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="EditDateGiveFinish" TextMode="Date" runat="server" CssClass="form-control" Text='<%# DataBinder.Eval(Container, "DataItem.[DATE_WFM_GIVE_FINISH]").ToString() == "" ? DateTime.Now.ToString("yyyy-MM-dd") : (object)DateTime.ParseExact(DataBinder.Eval(Container, "DataItem.[DATE_WFM_GIVE_FINISH]").ToString(),"dd/MM/yyyy",null).ToString("yyyy-MM-dd") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterStyle Width="200px" />
                                <HeaderStyle HorizontalAlign="Center" Width="250px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="250px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ghi Chú(Đi Lại)" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="noteGiveFinish" runat="server" Style="word-wrap: normal; word-break: break-all;"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[NOTE_WFM_GIVE_FINISH]") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="EditNoteGiveFinish" runat="server" CssClass="form-control" Text='<%# DataBinder.Eval(Container, "DataItem.[NOTE_WFM_GIVE_FINISH]") %>'></asp:TextBox>
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
                        <FooterStyle BackColor="#bf4040" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#bf4040" Font-Size="Large" Height="50px" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        <PagerStyle BackColor="142, 218, 242" ForeColor="White" HorizontalAlign="Center" CssClass="PagingCss" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </div>
                <div class="tab-pane fade" id="take" role="tabpanel" aria-labelledby="take-tab">
                    <div style="height: 20px"></div>
                    <asp:GridView ID="GridView2" runat="server" RowStyle-CssClass="GvRowStyle" Width="100%" ForeColor="#566787" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" Style="margin-bottom: 0px" CellSpacing="5"
                        DataKeyNames="WFM_TAKE_ID" CssClass="myGrv" AllowSorting="True" CellPadding="5" HorizontalAlign="Center" ShowFooter="True">
                        <AlternatingRowStyle BackColor="#e6e6e6" />
                        <Columns>
                            <asp:TemplateField HeaderText="Ngày Tháng Năm" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" SortExpression="DATE_WFM_TAKE_SORT">
                                <ItemTemplate>
                                    <asp:Label ID="fullName" runat="server"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[DATE_WFM_TAKE]") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="EditDateTake" TextMode="Date" runat="server" CssClass="form-control" Text='<%# (object)DateTime.ParseExact(DataBinder.Eval(Container, "DataItem.[DATE_WFM_TAKE]").ToString(),"dd/MM/yyyy",null).ToString("yyyy-MM-dd") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterStyle Width="200px" />
                                <HeaderStyle HorizontalAlign="Center" Width="250px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="250px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Số Tiền" HeaderStyle-CssClass="text-center" SortExpression="VALUE_WFM_TAKE">
                                <ItemTemplate>
                                    <asp:Label ID="valueTake" runat="server"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[VALUE_WFM_TAKE]", "{0:###,###}") + " VND" %> '>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="EditValueTake" runat="server" CssClass="form-control form-control-sm"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[VALUE_WFM_TAKE]") %>' TextMode="Number"></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Loại" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="phone" runat="server"
                                        Text='<%# ShowType(DataBinder.Eval(Container, "DataItem.[TYPE_WFM_TAKE]")) %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="EditTypeTake"
                                        runat="server"
                                        CssClass="form-control" SelectedIndex='<%# int.Parse(DataBinder.Eval(Container, "DataItem.[TYPE_WFM_TAKE]").ToString()) - 1 %>'>
                                        <asp:ListItem Value="1"> Mừng cưới </asp:ListItem>
                                        <asp:ListItem Value="2"> Đám hiếu </asp:ListItem>
                                        <asp:ListItem Value="3"> Mừng nhà </asp:ListItem>
                                        <asp:ListItem Value="4"> Khác </asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="250px" />
                                <ItemStyle HorizontalAlign="Center" Width="250px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Người nhận" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="humanTake" runat="server" Style="word-wrap: normal; word-break: break-all;"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[HUMAN_WFM_TAKE]") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="EditHumanTake" runat="server" CssClass="form-control" Text='<%# DataBinder.Eval(Container, "DataItem.[HUMAN_WFM_TAKE]") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="500px" />
                                <ItemStyle HorizontalAlign="Center" Width="500px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nhóm (Quan hệ)" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="groupTake" runat="server" Style="word-wrap: normal; word-break: break-all;"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[GROUP_WFM_TAKE]") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="EditGroupTake" runat="server" CssClass="form-control" Text='<%# DataBinder.Eval(Container, "DataItem.[GROUP_WFM_TAKE]") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="500px" />
                                <ItemStyle HorizontalAlign="Center" Width="500px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ghi Chú" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="noteTake" runat="server" Style="word-wrap: normal; word-break: break-all;"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[NOTE_WFM_TAKE]") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="EditNoteTake" runat="server" CssClass="form-control" Text='<%# DataBinder.Eval(Container, "DataItem.[NOTE_WFM_TAKE]") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="500px" />
                                <ItemStyle HorizontalAlign="Center" Width="500px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Trạng thái" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="statusTake" runat="server" Style='<%# DataBinder.Eval(Container, "DataItem.[STATUS_WFM_TAKE]").ToString() == "1" ? "color: #00e600" : "color: Red" %>'
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[STATUS_WFM_TAKE]").ToString() == "1" ? "Đã đi lại ✓!" : "Chưa đi lại ✗!" %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="EditStatusTake" runat="server" CssClass="form-control" Text='<%# DataBinder.Eval(Container, "DataItem.[STATUS_WFM_TAKE]") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="500px" />
                                <ItemStyle HorizontalAlign="Center" Width="500px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ngày Đi Lại" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="dateTakeFinish" runat="server"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[DATE_WFM_TAKE_FINISH]") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="EditDateTakeFinish" TextMode="Date" runat="server" CssClass="form-control" Text='<%# (object)DateTime.ParseExact(DataBinder.Eval(Container, "DataItem.[DATE_WFM_TAKE_FINISH]").ToString(),"dd/MM/yyyy",null).ToString("yyyy-MM-dd") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterStyle Width="200px" />
                                <HeaderStyle HorizontalAlign="Center" Width="250px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="250px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ghi Chú(Đi Lại)" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="address" runat="server" Style="word-wrap: normal; word-break: break-all;"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.[NOTE_WFM_TAKE_FINISH]") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="EditNoteTake" runat="server" CssClass="form-control" Text='<%# DataBinder.Eval(Container, "DataItem.[NOTE_WFM_TAKE_FINISH]") %>'></asp:TextBox>
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
                        <FooterStyle BackColor="#888844" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#888844" Font-Size="Large" Height="50px" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        <PagerStyle BackColor="142, 218, 242" ForeColor="White" HorizontalAlign="Center" CssClass="PagingCss" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <!-- Modal -->
        <div class="modal fade" id="modalGive" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">THÊM MỚI DANH SÁCH ĐI TIỀN</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="exampleFormControlTextarea1">Ngày Tháng (tháng/ngày/năm)(*)</label>
                            <asp:TextBox ID="DateGive" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập ngày tháng.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlSelect1">Người(*)</label>
                            <asp:TextBox ID="HumanGive" runat="server" CssClass="form-control" placeholder="Nhập tên người nhận ..."></asp:TextBox>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập tên người nhận.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlSelect1">Hội Nhóm (Quan hệ)(*)</label>
                            <asp:TextBox ID="GroupGive" runat="server" CssClass="form-control" placeholder="Nhập hội nhóm (Quan hệ) ..."></asp:TextBox>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập hội nhóm.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlInput1">Số Tiền (VND)(*)</label>
                            <asp:TextBox ID="ValueGive" runat="server" CssClass="form-control" TextMode="Number" placeholder="Nhập số tiền ..." onchange="setFormatMonney();"></asp:TextBox>
                            <label style="color: darkseagreen; font-size: 15px" id="Foratmonney"></label>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập số tiền.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlSelect1">Phân Loại</label>
                            <asp:DropDownList ID="TypeGive"
                                runat="server"
                                CssClass="form-control">
                                <asp:ListItem Selected="True" Value="1"> Mừng cưới </asp:ListItem>
                                <asp:ListItem Value="2"> Đám hiếu </asp:ListItem>
                                <asp:ListItem Value="3"> Mừng nhà </asp:ListItem>
                                <asp:ListItem Value="4"> Khác </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlTextarea1">Ghi Chú</label>
                            <asp:TextBox ID="NoteGive" runat="server" CssClass="form-control" TextMode="multiline" placeholder="Note ..."></asp:TextBox>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <asp:Button ID="SubmitGive" runat="server" Text="Submit" OnClientClick="return submitGive()" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modalFormTake" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">THÊM MỚI DANH SÁCH NHẬN</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="exampleFormControlTextarea1">Ngày Tháng (tháng/ngày/năm)(*)</label>
                            <asp:TextBox ID="DateTake" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập ngày tháng.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlSelect1">Người(*)</label>
                            <asp:TextBox ID="HumanTake" runat="server" CssClass="form-control" placeholder="Nhập tên người gửi ..."></asp:TextBox>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập tên người gửi.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlSelect1">Hội Nhóm (Quan hệ)(*)</label>
                            <asp:TextBox ID="GroupTake" runat="server" CssClass="form-control" placeholder="Nhập hội nhóm (Quan hệ) ..."></asp:TextBox>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập hội nhóm.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlInput1">Số Tiền (VND)(*)</label>
                            <asp:TextBox ID="ValueTake" runat="server" CssClass="form-control" TextMode="Number" placeholder="Nhập số tiền ..." onchange="setFormatMonney();"></asp:TextBox>
                            <label style="color: darkseagreen; font-size: 15px" id="ForatmonneyTake"></label>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập số tiền.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlSelect1">Phân Loại</label>
                            <asp:DropDownList ID="TypeTake"
                                runat="server"
                                CssClass="form-control">
                                <asp:ListItem Selected="True" Value="1"> Mừng cưới </asp:ListItem>
                                <asp:ListItem Value="2"> Đám hiếu </asp:ListItem>
                                <asp:ListItem Value="3"> Mừng nhà </asp:ListItem>
                                <asp:ListItem Value="4"> Khác </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlTextarea1">Ghi Chú</label>
                            <asp:TextBox ID="NoteTake" runat="server" CssClass="form-control" TextMode="multiline" placeholder="Note ..."></asp:TextBox>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <asp:Button ID="SubmitTake" runat="server" Text="Submit" OnClientClick="return submitTake()" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <input id="TabIndex"  type="hidden" runat="server" />
    </form>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</body>
</html>
