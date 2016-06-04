﻿using InwersjaTomograficzna.Core.RayDensity.DataReaders.Mocks;
using InwersjaTomograficzna.Core.RayDensity.DataStructures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace InwersjaTomograficzna.Core
{
    public class CoreWorker
    {
        public RoutedMatrix CalculateRayDensity()
        {
            SignalRoutes signals = new SignalRoutes(new MockDataReader());
            RoutedMatrix testMatrix = new RoutedMatrix(10, signals, 0, 20, 0, 10);
            var valueMatrix = testMatrix.MakeRayDensity();
            return testMatrix;
        }

        public Chart CreateSignalsChart(SignalRoutes signals)
        {
            var signalChart = new Chart();
            signalChart.Titles.Add("signals");
            var chartArea = new ChartArea("ChartArea");
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 20;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 10;
            signalChart.ChartAreas.Add(chartArea);
            signalChart.Series.Clear();

            foreach (var signal in signals.AllRoutes)
            {
                var series = new Series(String.Format("({0} ; {1}) - ({2} ; {3})", signal.StartPoint.X, signal.StartPoint.Y, signal.EndPoint.X, signal.EndPoint.Y));
                series.Points.AddXY(signal.StartPoint.X, signal.StartPoint.Y);
                series.Points.AddXY(signal.EndPoint.X, signal.EndPoint.Y);
                series.ChartType = SeriesChartType.FastLine;
                series.Color = Color.Blue;

                signalChart.Series.Add(series);

            }
            return signalChart;
        }
    }
}
