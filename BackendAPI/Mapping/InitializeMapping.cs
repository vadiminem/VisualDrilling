namespace BackendAPI.Mapping
{
    public class InitializeMapping
    {
        public void Initialize()
        {
            DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.PostgreSqlDialect();
            DapperExtensions.DapperExtensions
                .SetMappingAssemblies(new[]
            {
                typeof(WellMap).Assembly,
                typeof(DrillingPointMap).Assembly
            });
        }
    }
}
