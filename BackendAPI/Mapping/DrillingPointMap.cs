using BackendAPI.Models;
using DapperExtensions.Mapper;

namespace BackendAPI.Mapping
{
    public class DrillingPointMap : ClassMapper<DrillingPointModel>
    {
        public DrillingPointMap()
        {
            Table("drilling_points");
            Map(x => x.Id).Column("id").Key(KeyType.Identity);
            Map(x => x.WellId).Column("well_id");
            Map(x => x.MeasuredDepth).Column("measured_depth");
            Map(x => x.Inclination).Column("inclination");
            Map(x => x.Azimuth).Column("azimuth");
        }
    }
}
