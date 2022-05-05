﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoanDebt.aspx.cs" Inherits="QuanLiChiTieuWebForm.LoanDebt" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Home</title>
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
    </script>
</head>

<body onload="setMonthYear()">
    <header>
        <div class="home">
            <a href="https://phanhiep97nd.github.io/hiepphan/Hieplayout/Hiep-Profile.html" target="_blank">POWER BY Phan Văn Hiệp</a>
        </div>
    </header>
    <nav class="navbar navbar-expand-lg navbar-light bg-light" style="background-color: #398ddc;">
        <div class="container-fluid">
            <a class="navbar-brand" href="#">
                <h3>Hi <b>Admin</b>!</h3>
            </a>
            <button type="button" style="color: red; background-color: rgb(247, 179, 179);" class="btn btn-danger btn-right">Log
                Out</button>
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
                <button type="button" class="list-group-item list-group-item-info list-group-item-action"> > Home</button>
                <button type="button" class="list-group-item list-group-item-info list-group-item-action"> > Quản Lý Vay Nợ</button>
                <button type="button" class="list-group-item list-group-item-info list-group-item-action"> > Quản Lý Danh Sách Hiếu Hỷ</button>
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
                        <a href="#" class="btn btn-primary mx-auto d-block btn-right" data-bs-toggle="modal" data-bs-target="#modalFormSpending"><i class="material-icons">&#xE147;</i> <span>Thêm mới danh sách nợ</span></a>
                    </li>
                    <li class="nav-item">
                        <a href="#" class="btn btn-primary btn-right"><i class="material-icons">&#xE24D;</i> <span>Export to
                                CSV</span></a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <div style="height: 20px"></div>
    <nav class="navbar navbar-light bg-light">
        <div class="container-fluid">
            <!-- <a class="navbar-brand">Navbar</a> -->
            <div class="form-check navbar-brand">
                <input class="form-check-input" type="checkbox" value="" id="flexCheckIndeterminate">
                <label class="form-check-label" for="flexCheckIndeterminate">
              Hiển Thị Toàn Bộ Năm
            </label>
            </div>
            <form class="d-flex">
                <h6 class="navbar-brand">Tháng:</h6>
                <select class="form-select form-select-sm month" aria-label=".form-select-sm example" style="width: 20%; margin-right: 10px;">
                <option value="1">01</option>
                <option value="2">02</option>
                <option value="3">03</option>
                <option value="4">04</option>
                <option value="5">05</option>
                <option value="6">06</option>
                <option value="7">07</option>
                <option value="8">08</option>
                <option value="9">09</option>
                <option value="10">10</option>
                <option value="11">11</option>
                <option value="12">12</option>
              </select>
                <h6 class="navbar-brand">Năm:</h6>
                <select class="form-select form-select-sm year" aria-label=".form-select-sm example" style="width: 30%; margin-right: 10px;">
              </select>
                <h6 class="navbar-brand">| Trạng thái:</h6>
                <select class="form-select form-select-sm" aria-label=".form-select-sm example" style="width: 50%;margin-right: 10px;">
                <option value="1">Tất cả</option>
                <option value="2">Chưa trả</option>
                <option value="3">Đã trả</option>
              </select>
                <input class="form-control me-2" type="search" placeholder="Người vay/ Cho vay" aria-label="Search">
                <button class="btn btn-outline-success" type="submit">Search</button>
            </form>
        </div>
    </nav>
    <hr style="color: rgb(54, 109, 138);">
    <div class="row">
        <div class="col-md">
            <h4 style="text-align: center; color: rgb(174, 199, 118);">Danh sách cho vay</h4>
            <div id="accordion Loan">
                <div class="card bg-light">
                    <div class="card-header" id="heading">
                        <h5 class="mb-0">
                            <div class="container">
                                <div class="row">
                                    <div class="col">
                                        <button class="btn btn-link">Ngày tháng</button> |
                                    </div>
                                    <div class="col">
                                        <button class="btn btn-link">Người vay</button> |
                                    </div>
                                    <div class="col">
                                        <button class="btn btn-link">Số tiền</button> |
                                    </div>
                                    <div class="col">
                                        <button class="btn btn-link">Trạng thái</button> |
                                    </div>
                                    <div class="col">
                                    </div>
                                </div>
                            </div>
                        </h5>
                    </div>
                </div>
                <div class="card card-loan">
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
                                        Chưa trả <i class="fa fa-times-circle-o" style="font-size:20px;color:red"></i>
                                    </div>
                                    <div class="col">
                                        <button class="btn btn-link" data-toggle="collapse" data-target="#collapseOneLoan" aria-expanded="true" aria-controls="collapseOne">
                                        #Xem Chi tiết
                                      </button>
                                    </div>
                                </div>
                            </div>
                        </h5>
                    </div>
                    <div id="collapseOneLoan" class="collapse" aria-labelledby="headingOne" data-parent="#accordion">
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
                        <hr style="color: rgb(54, 109, 138);">
                        <div>
                            <img src="test.jpg" class="img-thumbnail" alt="...">
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
                                        Đã trả <i class="fa fa-check-circle" style="font-size:20px;color:yellow"></i>
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
                                        Chưa trả <i class="fa fa-times-circle-o" style="font-size:20px;color:red"></i>
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
                </div>
            </div>
        </div>
        <div class="col-md">
            <h4 style="text-align: center; color: rgb(174, 199, 118);">Danh sách Nợ</h4>
            <div id="accordion Debt">
                <div class="card bg-light">
                    <div class="card-header" id="heading">
                        <h5 class="mb-0">
                            <div class="container">
                                <div class="row">
                                    <div class="col">
                                        <button class="btn btn-link">Ngày tháng</button> |
                                    </div>
                                    <div class="col">
                                        <button class="btn btn-link">Người cho vay</button> |
                                    </div>
                                    <div class="col">
                                        <button class="btn btn-link">Số tiền</button> |
                                    </div>
                                    <div class="col">
                                        <button class="btn btn-link">Trạng thái</button> |
                                    </div>
                                    <div class="col">
                                    </div>
                                </div>
                            </div>
                        </h5>
                    </div>
                </div>
                <div class="card card-debt">
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
                                        Chưa trả <i class="fa fa-times-circle-o" style="font-size:20px;color:red"></i>
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
                                        Chưa trả <i class="fa fa-times-circle-o" style="font-size:20px;color:red"></i>
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
                                        Đã trả <i class="fa fa-check-circle" style="font-size:20px;color:yellow"></i>
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
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalForm" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">THÊM MỚI DANH SÁCH CHO VAY</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form style="padding:15px" action="" method="post" id="form">
                        <div class="form-group">
                            <label for="exampleFormControlTextarea1">Ngày Cho Vay (tháng/ngày/năm)</label>
                            <input class="form-control" type="date" id="dateIncome" name="dateIncome">
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập ngày tháng.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlSelect1">Người Vay</label>
                            <input class="form-control" type="text" id="" name="dateIncome">
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlInput1">Số Tiền Cho Vay (VND)</label>
                            <input type="number" class="form-control" id="valueIncome" placeholder="Đơn vị VND" onchange="setFormatMonney()" name="valueIncome">
                            <label style="color:darkseagreen; font-size:15px" id="Foratmonney"></label>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập số tiền.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlTextarea1">Ghi Chú</label>
                            <textarea class="form-control" id="noteIncome" rows="3" name="noteIncome"></textarea>
                        </div>
                        <div class="mb-3">
                            <label for="formFileSm" class="form-label">Đính kèm ảnh</label>
                            <input class="form-control form-control-sm" id="formFileSm" type="file">
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary" onclick="submitIncome()">Submit</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalFormSpending" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">THÊM MỚI DANH SÁCH NỢ</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form style="padding:15px" action="/CreateSpending/ClickCreateSpending" method="post" id="form">
                        <div class="form-group">
                            <label for="exampleFormControlTextarea1">Ngày Vay (tháng/ngày/năm)</label>
                            <input class="form-control" type="date" id="dateSpending" name="dateSpending">
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlSelect1">Người Cho Vay</label>
                            <input class="form-control" type="text" id="" name="dateIncome">
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlInput1">Số Tiền Vay (VND)</label>
                            <input type="number" class="form-control" id="valueSpending" placeholder="Đơn vị VND" onchange="setFormatMonney()" name="valueSpending">
                            <label style="color:darkseagreen; font-size:15px" id="Foratmonney"></label>
                            <div id="validationServerUsernameFeedback" class="invalid-feedback">
                                Hãy nhập số tiền.
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleFormControlTextarea1">Ghi Chú</label>
                            <textarea class="form-control" id="noteSpending" rows="3" name="noteSpending"></textarea>
                        </div>
                        <div class="mb-3">
                            <label for="formFileSm" class="form-label">Đính kèm ảnh</label>
                            <input class="form-control form-control-sm" id="formFileSm" type="file">
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary" onclick="submitIncome()">Submit</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</body>

</html>