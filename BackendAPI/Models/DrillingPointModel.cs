using BoreholeCalculation;

namespace BackendAPI.Models
{
    public class DrillingPointModel : DrillingPoint
    {
        public int Id { get; set; }
        public int WellId { get; set; }

        public DrillingPointModel() { }
        public DrillingPointModel(double measureDepth, double inclination, double azimuth)
        {
            MeasuredDepth = measureDepth;
            Inclination = inclination;
            Azimuth = azimuth;
        }
    }
}
