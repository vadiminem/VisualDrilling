using System.Collections.Generic;

namespace BackendAPI.Models
{
    public class WellModel
    {
        public int Id { get; set; }
        public List<DrillingPointModel> Points { get; set; } = new List<DrillingPointModel>();
    }
}
