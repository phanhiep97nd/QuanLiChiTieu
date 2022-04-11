
function clickDetail2(isDetail2) {
    return clickDetail(isDetail2);
}

function clickDetail(isDetail) {
    if (isDetail) {
        document.getElementById("overView").style.backgroundColor = "#78bfe6";
        document.getElementById("detail").style.backgroundColor = "#10329a";
        document.getElementsByClassName("content-overView")[0].style.display = "none";
        document.getElementsByClassName("content-detail")[0].style.display = "block";
    } else {
        document.getElementById("overView").style.backgroundColor = "#10329a";
        document.getElementById("detail").style.backgroundColor = "#78bfe6";
        document.getElementsByClassName("content-detail")[0].style.display = "none";
        document.getElementsByClassName("content-overView")[0].style.display = "block";
    }
}

function setMonthYear(monthOverview, yearOverview, searchDetailBy, monthDetal, yearDetail) {
    var today = new Date();
    var strMonth = "";
    var strYear = "";
    for (var i = 1; i <= 12; i++) {
        //if (i == (today.getMonth() + 1)) {
            //strMonth += ("<option value=" + i + " selected >" + i + "</option>\n");
        //} else {
            strMonth += ("<option value=" + i + ">" + i + "</option>\n");
       // }
    }
    for (var i = today.getFullYear() - 11; i <= today.getFullYear(); i++) {
        //if (i == today.getFullYear()) {
            //strYear += ("<option value=" + i + " selected >" + i + "</option>\n");
        //} else {
            strYear += ("<option value=" + i + ">" + i + "</option>\n");
        //}
    }
    var month = document.querySelectorAll('.month');
    var year = document.querySelectorAll('.year');
    month.forEach(element => {
        element.innerHTML = strMonth;
    });
    year.forEach(element => {
        element.innerHTML = strYear;
    });
    document.getElementById("monthOverView").value = monthOverview;
    document.getElementById("yearOverView").value = yearOverview;
    document.getElementById("showDetailBy1").value = searchDetailBy;
    document.getElementById("monthDetail").value = monthDetal;
    document.getElementById("yearDetail").value = yearDetail;
    var showDetailBy1 = document.getElementById("showDetailBy1").value;
    if (showDetailBy1 == "1") {
        document.getElementById('monthDetail').style.display = 'inline';
    } else if (showDetailBy1 == "2") {
        document.getElementById('monthDetail').style.display = 'none';
    }
}

function getDetailBy(value) {
    if (value == "1") {
        document.getElementById('monthDetail').style.display = 'inline';
    } else if (value == "2") {
        document.getElementById('monthDetail').style.display = 'none';
    }
}

function checkLogout(loginNmae) {
    if(confirm("Bạn có muốn đăng xuất không!")) {
    location.href = "/Logout/Logout/" + loginNmae;
    }
}

function checkDelete(idDetail, type) {
    var url = (window.location.href).replaceAll("&", "*");
    url = url.replaceAll("#", "!");
    console.log(url);
    if (confirm("Bạn có xóa dòng chi tiết này không ?")) {
        location.href = "/DeleteDetail/DeleteDetail/" + idDetail + "?type=" + type + "&url=" + url  ;
    }
}

function convertMonneyFormat(number) {
    return number.toLocaleString();
}

function changeSearchCondition(id, sortBy, sortType, tab) {
    var monthOverview = document.getElementById("monthOverView").value;
    var yearOverview = document.getElementById("yearOverView").value;
    var searchDetailBy = document.getElementById("showDetailBy1").value;
    var monthDetal = "0";
    var yearDetail = "";
    if (searchDetailBy == "1") {
        var monthDetal = document.getElementById("monthDetail").value == "" ? "1" : document.getElementById("monthDetail").value;
        var yearDetail = document.getElementById("yearDetail").value;
    }
    else if (searchDetailBy == "2") {
        var yearDetail = document.getElementById("yearDetail").value;
    }
    location.href = "/Home/Index/" + id + "?monthOverview=" + monthOverview + "&yearOverview=" + yearOverview + "&searchDetailBy=" + searchDetailBy + "&monthDetal=" + monthDetal + "&yearDetail=" + yearDetail + "&sortBy=" + sortBy + "&sortType=" + sortType +"&tab="+tab;
}
// var LineChart = {
//     labels: ["Ruby", "jQuery", "Java", "ASP.Net", "PHP"],
//     datasets: [{
//         fillColor: "rgba(151,249,190,0.5)",
//         strokeColor: "rgba(255,255,255,1)",
//         pointColor: "rgba(220,220,220,1)",
//         pointStrokeColor: "#fff",
//         data: [10, 20, 30, 40, 50]
//     }, {
//         fillColor: "rgba(252,147,65,0.5)",
//         strokeColor: "rgba(255,255,255,1)",
//         pointColor: "rgba(173,173,173,1)",
//         pointStrokeColor: "#fff",
//         data: [28, 68, 40, 19, 96]
//     }]
// }
// var myLineChart = new Chart(document.getElementById("canvas").getContext("2d")).Line(LineChart, { scaleFontSize: 14, scaleFontColor: "#ff8540" });
// google.charts.load('current', { 'packages': ['corechart'] });
// google.charts.setOnLoadCallback(drawChart);

// function drawChart() {
//     var data = google.visualization.arrayToDataTable([
//         ['Task', 'Hours per Day'],
//         ['Work', 8],
//         ['Friends', 2],
//         ['Eat', 2],
//         ['TV', 3],
//         ['Gym', 2],
//         ['Sleep', 7]
//     ]);
//     var options = { 'title': 'My Average Day', 'width': 400, 'height': 300 };
//     var chart = new google.visualization.PieChart(document.getElementById('piechart'));
//     chart.draw(data, options);
// }