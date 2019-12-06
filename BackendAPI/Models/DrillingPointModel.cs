namespace BackendAPI.Models
{
    public class DrillingPointModel
    {
        public int Id { get; set; }
        public double MeasuredDepth { get; set; }
        public double Inclination { get; set; }
        public double Azimuth { get; set; }
    }
}
