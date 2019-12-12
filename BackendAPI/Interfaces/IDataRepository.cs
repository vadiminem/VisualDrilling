using BackendAPI.Models;

namespace BackendAPI.Interfaces
{
    public interface IDataRepository
    {
        public void InsertWellData(WellModel well);
        public void GetWellData(int id);
    }
}
