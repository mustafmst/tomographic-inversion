﻿using InwersjaTomograficzna.Core.ChartCreators;
using InwersjaTomograficzna.Core.RayDensity.DataReaders.Mocks;
using InwersjaTomograficzna.Core.RayDensity.DataStructures;
using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace InwersjaTomograficzna.Core
{
    public class CoreWorker
    {
        private RoutedMatrix matrix;

        public void CalculateRayDensity()
        {
            SignalRoutes signals = new SignalRoutes(new MockDataReader());
            matrix = new RoutedMatrix(2, signals, 0, 30, 0, 20);
            matrix.MakeRayDensity();
        }

        public Chart CreateSignalsChart()
        {
            return new SignalChartCreator(matrix).CreateSignalChart();
        }

        public Image CreateRayDensityChart()
        {
            return new RayDensityChartCreator(matrix).CreateChart();
        }
    }
}
