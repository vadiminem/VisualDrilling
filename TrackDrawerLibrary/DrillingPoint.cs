using Newtonsoft.Json;
using System;

namespace BoreholeCalculation
{
    [Serializable]
    public class DrillingPoint
    {
        [JsonProperty(PropertyName = "measuredDepth")]
        public double MeasuredDepth { get; set; }
        [JsonProperty(PropertyName = "inclination")]
        public double Inclination { get; set; }
        [JsonProperty(PropertyName = "azimuth")]
        public double Azimuth { get; set; }
    }
}
