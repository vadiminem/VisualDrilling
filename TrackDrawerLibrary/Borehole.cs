using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BoreholeCalculation
{
    [Serializable]
    public class Borehole : IBorehole
    {
        [JsonProperty(PropertyName = "points")]
        public List<DrillingPoint> Points { get; set; } = new List<DrillingPoint>();
        public List<Coordinate> Coordinates { get; set; } = new List<Coordinate>();

        public Borehole() { }

        public Coordinate MCM(DrillingPoint pointA, DrillingPoint pointB)
        {
            var coordinate = new Coordinate();
            var i1 = pointA.Inclination;
            var i2 = pointB.Inclination;
            var a1 = pointA.Azimuth;
            var a2 = pointB.Azimuth;
            var md = pointB.MeasuredDepth - pointA.MeasuredDepth;
            var dl = ToDegrees(Math.Acos(Math.Cos(ToRadians(i2 - i1)) - Math.Sin(ToRadians(i1)) * ToRadians(Math.Sin(i2)) * ToRadians(1 - Math.Cos(ToRadians(a2 - a1)))));
            var rf = 1.0;

            if (dl >= 0.0001)
            {
                rf = 360 / (dl * Math.PI) * Math.Tan(ToRadians(dl / 2));
            }

            var x = (md / 2) * (Math.Sin(ToRadians(i1)) * Math.Sin(ToRadians(a1)) + Math.Sin(ToRadians(i2)) * Math.Sin(ToRadians(a2))) * rf;
            var y = (md / 2) * (Math.Cos(ToRadians(i1)) + Math.Cos(ToRadians(i2))) * rf;
            var z = (md / 2) * (Math.Sin(ToRadians(i1)) * Math.Cos(ToRadians(a1)) + Math.Sin(ToRadians(i2)) * Math.Cos(ToRadians(a2))) * rf;

            coordinate.X = x;
            coordinate.Y = y;
            coordinate.Z = z;

            return coordinate;
        }

        public void MCM(List<DrillingPoint> points)
        {
            for (var i = 1; i < points.Count; i++)
            {
                Coordinates.Add(MCM(points[i - 1], points[i]));
            }
        }

        private double ToDegrees(double radians)
        {
            return radians * (180 / Math.PI);
        }

        private double ToRadians(double degrees)
        {
            return degrees / (180 / Math.PI);
        }
    }
}
