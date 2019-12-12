using System.Data;
using ThinkingHome.Migrator.Framework;

namespace BackendAPI.Migrations
{
    [Migration(1)]
    public class CreateFirstTables : Migration
    {
        public override void Apply()
        {
            Database.AddTable("drilling_points",
                new Column("id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("well_id", DbType.Int32),
                new Column("measured_depth", DbType.Double),
                new Column("inclination", DbType.Double),
                new Column("azimuth", DbType.Double));

            Database.AddTable("wells",
                new Column("id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("location", DbType.String),
                new Column("date", DbType.DateTime));
        }

        public override void Revert()
        {
            Database.RemoveTable("drilling_points");
            Database.RemoveTable("wells");
        }
    }
}
