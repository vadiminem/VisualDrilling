using BackendAPI.Interfaces;
using BackendAPI.Models;
using BackendAPI.Settings;
using DapperExtensions;
using Npgsql;
using System;
using System.Linq;

namespace BackendAPI.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly PostgresSettings settings;

        public DataRepository(PostgresSettings settings)
        {
            this.settings = settings;
        }

        public void GetWellData(int id)
        {
            using var connection = new NpgsqlConnection(settings.ConnectionString);
            var well = connection.Get<WellModel>(id);
            well.Points = connection.GetList<DrillingPointModel>().Where(s => s.Id == id).ToList();
        }

        public void InsertWellData(WellModel well)
        {
            try
            {
                using var connection = new NpgsqlConnection(settings.ConnectionString);
                well.Date = DateTime.Now;
                var wellId = connection.Insert(well);
                foreach (var point in well.Points)
                {
                    point.WellId = wellId;
                    connection.Insert(point);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка при попытке добавления в базу данных. Ошибка:\n{0}", ex.Message);
            }
        }
    }
}
