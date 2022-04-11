<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="QuanLiChiTieuWebForm.Home" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Quản Lí Chi Tiêu</title>
    <link rel="stylesheet" type="" href="../Style/QuanLiChiTieu.css">
    <script src="../Scripts/QuanLiChiTieu.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.6.0/Chart.min.js"></script>
    <!-- <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"> -->
</head>

<body onload="setMonthYear(), clickDetail(false)">
    <header>
        <div class="home">
            <a href="https://phanhiep97nd.github.io/hiepphan/Hieplayout/Hiep-Profile.html" target="_blank">POWER BY Phan Văn Hiệp</a>
        </div>
        <div class="banner">
            <h1>QUẢN LÍ CHI TIÊU</h1>
            <h5>Giúp bạn tính toán các khoản thu nhập và chi tiêu để hoạch định số tiền cần đầu tư!</h5>
        </div>
    </header>
    <main>
        <div id="navbar" class="navbar">
            <ul class="clearfix menu-vertical">
                <li><a href="/CreateIncome/CreateIncome">KHAI THU NHẬP</a></li>
                <li><a href="/CreateSpending/CreateSpending">KHAI CHI TIÊU</a></li>
            </ul>
        </div>
        <div class="menu-content">
            <ul class="clearfix nav-detail">
                <li id="overView" onclick="clickDetail(false)">
                    <a href="#OverView">BẢNG TỔNG QUÁT</a>
                </li>
                <li id="detail" onclick="clickDetail(true)">
                    <a href="#Detail">BẢNG CHI TIẾT</a>
                </li>
            </ul>
        </div>
        <div class="content-overView clearfix">
            <div class="left-content-overView">
                <h2>Hi @ViewBag.loginName ! <button id="logout" onclick="checkLogout(@ViewBag.userId)" style="font-style:italic; font-size:15px; background:#4ba9dd; color:white">[Logout]</button></h2>
                <h1>Quản lý chi tiêu hàng tháng</h1>
                <p>Thống kê thu nhập và các khoản chi tiêu hàng tháng, bạn sẽ có cái nhìn rõ hơn về tình trạng tài chính để hoạch định cho tương lai!</p>
                <hr style="color: white;">
                <h2>
                    Tháng
                    <select name="" id="monthOverView" class="month"></select> Năm
                    <select name="" id="yearOverView" class="year"></select>
                </h2>
                @{
                    if (Model != null)
                    {
                        int totalIncome = 0;
                        int totalSpending = 0;
                        foreach (var Data in Model)
                        {
                            totalIncome += Data.ValueIncome;
                            //totalSpending += Data.ValueSpending;
                        }
                        <h3>Tổng thu nhập</h3>
                        <h2>@{@FormattedAmount(totalIncome);} VND</h2>
                        <hr style="border: 1px solid rgb(66, 157, 196);">
                        <h3>Tổng chi tiêu</h3>
                        <h2>VND</h2>
                        <hr style="border: 1px solid rgb(66, 157, 196);">
                        <h3>Tích lũy tài chính</h3>
                        <h2>VND</h2>
                    }
                }
            </div>
            <div class="right-content-overView">
                <table style="width: 90%;" cellspacing="30">
                    <tr>
                        <td style="width: 70%;">
                            <h2 style="color: #1348ab;">Thu nhập tháng</h2>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="color: #3ebeda;">Tiền lương</td>
                        <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b>VND</b></td>
                    </tr>
                    <tr>
                        <td style="color: #3ebeda;">Thu nhập khác</td>
                        <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b>VND</b></td>
                    </tr>
                </table>
                <hr style="color: rgb(54, 109, 138);">
                <table style="width: 90%;" cellspacing="30">
                    <tr>
                        <td style="width: 70%;">
                            <h2 style="color: #1348ab;">Chi tiêu tháng</h2>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="color: #3ebeda;">Nhà/Sinh hoạt phí</td>
                        <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b>VND</b></td>
                    </tr>
                    <tr>
                        <td style="color: #3ebeda;">Ăn uống</td>
                        <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b>VND</b></td>
                    </tr>
                    <tr>
                        <td style="color: #3ebeda;">Mua sắm</td>
                        <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b>VND</b></td>
                    </tr>
                    <tr>
                        <td style="color: #3ebeda;">Quỹ tài chính/Bảo hiểm</td>
                        <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b>VND</b></td>
                    </tr>
                    <tr>
                        <td style="color: #3ebeda;">Trả nợ vay</td>
                        <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b>VND</b></td>
                    </tr>
                    <tr>
                        <td style="color: #3ebeda;">Di chuyển</td>
                        <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b>VND</b></td>
                    </tr>
                    <tr>
                        <td style="color: #3ebeda;">Giải trí</td>
                        <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b>VND</b></td>
                    </tr>
                    <tr>
                        <td style="color: #3ebeda;">Giáo dục/Sức khỏe</td>
                        <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b>VND</b></td>
                    </tr>
                    <tr>
                        <td style="color: #3ebeda;">Khác</td>
                        <td style="color: rgba(0, 0, 0, 0.8);text-align: right;"><b>VND</b></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="content-detail clearfix">
            <div class="left-content-detail">
                <h1>Chi tiết các khoản thu chi</h1>
                <h2>
                    Lọc các khoản chi tiêu
                    <select name="" id="showDetailBy1" onchange="getDetailBy(this.value)">
                        <option value="01">Theo tháng</option>
                        <option value="02">Theo Năm</option>
                    </select>
                    <select name="" id="monthDetail" class="month" onchange="">
                        <option selected>-Chọn tháng-</option>
                    </select>
                    <select name="" id="yearDetail" class="year" onchange=""></select>
                </h2>
                <hr style="color: white;">
                <h2>Thu Nhập</h2>
                <table border="1" cellpadding="0" cellspacing="0" style="width: 100%;text-align: center;">
                    <tr>
                        <td style="width: 20%;">
                            <h3>Ngày</h3>
                        </td>
                        <td style="width: 20%;">
                            <h3>Loại thu nhập</h3>
                        </td>
                        <td style="width: 20%;">
                            <h3>Số tiền</h3>
                        </td>
                        <td>
                            <h3>Ghi chú</h3>
                        </td>
                    </tr>
                </table>
                <h3>Tổng: VND</h3>
                <hr style="color: white;">
                <h2>Chi Tiêu</h2>
                <table border="1" cellpadding="0" cellspacing="0" style="width: 100%;text-align: center;">
                    <tr>
                        <td style="width: 20%;">
                            <h3>Ngày<a>△▼▲▽</a></h3>
                        </td>
                        <td style="width: 20%;">
                            <h3>Loại chi tiêu</h3>
                        </td>
                        <td style="width: 20%;">
                            <h3>Số tiền</h3>
                        </td>
                        <td>
                            <h3>Ghi chú</h3>
                        </td>
                    </tr>
                </table>
                <h3>Tổng: VND</h3>
            </div>
            <div class="right-content-detail">
                <canvas id="myChart"></canvas>
                <canvas id="myLineChart"></canvas>
            </div>
        </div>
    </main>
</body>
<script type="text/javascript">
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
                data: [13, 20, 30, 40, 50, 70, 45, 65, 30, 40, 55, 65],
                backgroundColor: "rgba(151,249,190,0.5)",
                borderWidth: 1,
                borderColor: '#777',
                hoverBorderWidth: 3,
                hoverBorderColor: '#000'
            }, {
                label: 'Chi',
                data: [28, 68, 40, 19, 96, 13, 20, 30, 40, 50, 70, 55],
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
                data: [13, 20, 30, 40, 50, 70, 45, 65, 30, 40, 55, 65],
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
</script>

</html>