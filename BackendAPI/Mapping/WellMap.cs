using BackendAPI.Models;
using DapperExtensions.Mapper;

namespace BackendAPI.Mapping
{
    public class WellMap : ClassMapper<WellModel>
    {
        public WellMap()
        {
            Table("wells");
            Map(x => x.Id).Column("id").Key(KeyType.Identity);
            Map(x => x.Location).Column("location");
            Map(x => x.Date).Column("date");
        }
    }
}
