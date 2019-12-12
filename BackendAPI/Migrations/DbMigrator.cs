using BackendAPI.Settings;
using ThinkingHome.Migrator;

namespace BackendAPI.Migrations
{
    public class DbMigrator
    {
        private readonly PostgresSettings settings;

        public DbMigrator(PostgresSettings settings)
        {
            this.settings = settings;
        }

        public void StartMigration()
        {
            var provider = "Postgres";
            var assembly = typeof(DbMigration).Assembly;
            using var migrator = new Migrator(provider, settings.ConnectionString, assembly);
            migrator.Migrate();
        }
    }
}
