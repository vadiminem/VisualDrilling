using System.Collections.Generic;

namespace BoreholeCalculation
{
    interface IBorehole
    {
        public Coordinate MCM(DrillingPoint pointA, DrillingPoint pointB);
        public void MCM(List<DrillingPoint> points);
    }
}
