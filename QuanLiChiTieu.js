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

function getDetailBy(value) {
    if (value == "01") {
        document.getElementById('monthDetail').style.display = 'inline';
    } else if (value == "02") {
        document.getElementById('monthDetail').style.display = 'none';
    }
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