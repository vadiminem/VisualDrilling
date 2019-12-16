namespace BackendAPI.Models
{
    public class DrillingPointModel
    {
        public int Id { get; set; }
        public int WellId { get; set; }
        public double MeasuredDepth { get; set; }
        public double Inclination { get; set; }
        public double Azimuth { get; set; }

        public DrillingPointModel() { }
        public DrillingPointModel(double measureDepth, double inclination, double azimuth)
        {
            MeasuredDepth = measureDepth;
            Inclination = inclination;
            Azimuth = azimuth;
        }
    }
}
