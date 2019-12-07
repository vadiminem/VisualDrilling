using BackendAPI.Interfaces;
using BackendAPI.Models;
using BackendAPI.Settings;
using Npgsql;

namespace BackendAPI.Repositories
{
    public class DataRepository : IData
    {
        private PostgresSettings settings;

        public DataRepository(PostgresSettings settings)
        {
            this.settings = settings;
        }

        public void GetData()
        {
            throw new System.NotImplementedException();
        }

        public void InsertWellData(WellModel well)
        {
            using var connection = new NpgsqlConnection(settings.ConnectionString);

        }
    }
}
