﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace InwersjaTomograficzna.Core.DataStructures
{
    public class SignalRoutes
    {
        private Signal[] _allRoutes;
        public Signal[] AllRoutes
        {
            get
            {
                return _allRoutes;
            }
        }

        /// <summary>
        /// Initializes Object of SignalRoutes
        /// </summary>
        /// <param name="RawData">Array of signals raw data in format: startPointF_x, startPointF_y, endPointF_x, endPointF_y, time </param>
        public SignalRoutes(Tuple<string, string, string, string, string>[] RawData)
        {
            List<Signal> routesList = new List<Signal>();

            foreach(var signal in RawData)
            {
                routesList.Add(new Signal(
                    new PointF(int.Parse(signal.Item1), int.Parse(signal.Item2)),
                    new PointF(int.Parse(signal.Item3), int.Parse(signal.Item4)),
                    decimal.Parse(signal.Item5)
                    ));
            }

            _allRoutes = routesList.ToArray();
        }

    }
}
