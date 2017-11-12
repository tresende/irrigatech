var nodeData = {};
var circle = new Array();
function initMap() {
    setTimeout(function () {
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 18,
            center: { lat: -23.5893840, lng: -46.6622595 },
            zoomControl: false,
            mapTypeControl: false,
            scaleControl: false,
            streetViewControl: false,
            rotateControl: false,
            fullscreenControl: false,
            mapTypeId: 'satellite'
        });
        $.ajax({
            url: 'api/AvgMeasurementHour',
            async: false,
            success: function (points) {
                nodeData = points;
                for (var item in points) {
                    var node = points[item];
                    var color = '#00C7FF';
                    if (node.temperature > node.maxTemperature) {
                        color = 'red';
                    }
                    var cityCircle = new google.maps.Circle({
                        title: 'aa',
                        strokeColor: color,
                        icon: {
                            path: google.maps.SymbolPath.CIRCLE,
                            scale: 10
                        },
                        strokeOpacity: 0.8,
                        strokeWeight: 2,
                        fillColor: color,
                        fillOpacity: 0.35,
                        map: map,
                        center: { lat: node.lat, lng: node.long },
                        radius: node.area
                    });
                    circle.push(cityCircle);
                }
            }
        });

    }, 1000);
}

app.controller('home', [
    '$scope',
    '$rootScope',
    '$http',
    function ($scope, $rootScope, $http) {
        var charts = new Array();

        createCharts = function (nodes) {
            var gaugeOptions = {
                chart: {
                    type: 'solidgauge'
                },
                tooltip: {
                    enabled: false
                },
                pane: {
                    center: ['50%', '85%'],
                    size: '140%',
                    startAngle: -90,
                    endAngle: 90,
                    background: {
                        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || '#EEE',
                        innerRadius: '60%',
                        outerRadius: '100%',
                        shape: 'arc'
                    }
                },
                yAxis: {
                    stops: [
                        [0.1, '#55BF3B'],
                        [0.5, '#DDDF0D'],
                        [0.9, '#DF5353']
                    ],
                    lineWidth: 0,
                    minorTickInterval: null,
                    tickAmount: 2,
                    title: {
                        y: -70
                    },
                    labels: {
                        y: 16
                    }
                },

                plotOptions: {
                    solidgauge: {
                        dataLabels: {
                            y: 5,
                            borderWidth: 0,
                            useHTML: true
                        }
                    }
                }
            };

            for (var i = 0; i < nodes.length; i++) {
                var item = nodes[i];
                if (item.soilHumidity > 10) {
                    $('#node1-air').parent().parent().addClass('pulse')
                }
                else {
                    $('#node1-air').parent().parent().removeClass('pulse')
                }
                var charAir = Highcharts.chart(item.node + '-air', Highcharts.merge(gaugeOptions, {
                    title: {
                        text: 'Umidade do Ar'
                    },
                    credits: {
                        enabled: false
                    },
                    yAxis: {
                        min: 0,
                        max: 100,
                        title: {
                            text: item.node
                        }
                    },
                    series: [{
                        data: [item.airHumidity],
                        dataLabels: {
                            format: '<div style="text-align:center"><span style="font-size:25px;color:' +
                            ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y}</span><br/>' +
                            '<span style="font-size:12px;color:silver">Min:' + item.minAirHumidity + ' Max:' + item.maxAirHumidity + '</span></div>'
                        }
                    }]
                }));
                var charSoil = Highcharts.chart(item.node + '-soil', Highcharts.merge(gaugeOptions, {
                    title: {
                        text: 'Humidade do Solo'
                    },
                    credits: {
                        enabled: false
                    },
                    yAxis: {
                        min: 0,
                        max: 100,
                        title: {
                            text: item.node
                        }
                    },
                    series: [{
                        data: [item.soilHumidity],
                        dataLabels: {
                            format: '<div style="text-align:center"><span style="font-size:25px;color:' +
                            ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y}</span><br/>' +
                            '<span style="font-size:12px;color:silver">Min:' + item.minSoilHumidity + ' Max:' + item.maxSoilHumidity + '</span></div>'
                        }
                    }]
                }));
                var newChart = {
                    charSoil: charSoil,
                    charAir: charAir
                };
                charts.push(newChart);
            }
        }

        getFromSerer = function () {
            $http.get('api/AvgMeasurementHour').then(function (response) {
                createCharts(response.data);
            });
        }

        getFromSerer();

        setInterval(function () {
            updateCharts();
        }, 3000);

        updateCharts = function () {
            $http.get('api/AvgMeasurementHour').then(function (response) {
                var nodes = response.data;
                for (var i = 0; i < nodes.length; i++) {
                    var item = nodes[i];
                    if (item.soilHumidity > 10) {
                        $('#node1-air').parent().parent().addClass('pulse')
                    }
                    else {
                        $('#node1-air').parent().parent().removeClass('pulse')
                    }

                    charts[i].charSoil.update({
                        series: [{
                            data: [item.soilHumidity],
                        }]
                    });

                    charts[i].charAir.update({
                        series: [{
                            data: [item.soilAir],
                        }]
                    });

                    var color = '#00C7FF';
                    if (item.temperature > item.maxTemperature) {
                        color = 'red';
                    }
                    circle[i].setOptions({
                        fillColor: color,
                        strokeColor: color
                    });
                }
            });
        }
        $rootScope.title = 'Home';
        $rootScope.subtitle = 'Dashboard';
    }
]);