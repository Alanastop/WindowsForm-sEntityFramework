function dashboardWidgetCreated(s, e) {
    if (e.ItemName == 'pieDashboardItem1') {
        var chart = e.GetWidget()[0];
        var chartSerie = chart.getSeriesByPos(0);
        var chartPoints = chartSerie.getAllPoints();
        for (var i = 0; i < chartPoints.length; i++) {
            var point = chartPoints[i];
            if (point.argument === " ") {
                point.argument = "<orphans>";
                point._label._textContent = "<orphans>" + point._label._textContent;
            }
        }
    }
}
