$(document).ready(function () {
    //Peticion API
    $.ajax({

        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: "http://localhost:53082/Home/DataPastel",
        error: function () {
            alert("Ocurrio un error con la solicitud");
        },
        success: function (data) {
            console.log(data);
            GraficaPastel(data);
        }

    })


});

function GraficaPastel(data) {


    Highcharts.chart('container', {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        title: {
            text: ''
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        accessibility: {
            point: {
                valueSuffix: '%'
            }
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: false
                },
                showInLegend: true
            }
        },
        series: [{
            name: 'Marcas',
            colorByPoint: true,
            data: data
        }]
    });
}