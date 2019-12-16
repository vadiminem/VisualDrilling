using BackendAPI.Models;

namespace BackendAPI.Interfaces
{
    public interface IDataRepository
    {
        void InsertWellData(WellModel well);
        WellModel GetWellData(int id);
    }
}
