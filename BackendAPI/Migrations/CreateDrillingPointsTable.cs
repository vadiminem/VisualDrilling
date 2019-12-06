using System.Data;
using ThinkingHome.Migrator.Framework;

namespace BackendAPI.Migrations
{
    [Migration(1)]
    public class CreateDrillingPointsTable : Migration
    {
        public override void Apply()
        {
            Database.AddTable("drilling_points",
                new Column("id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("measured_depth", DbType.Double),
                new Column("inclination", DbType.Double),
                new Column("azimuth", DbType.Double));
        }

        public override void Revert()
        {
            Database.RemoveTable("drilling_points");
        }
    }
}
