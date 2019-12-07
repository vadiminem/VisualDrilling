using BackendAPI.Models;

namespace BackendAPI.Interfaces
{
    interface IData
    {
        void InsertWellData(WellModel well);
        void GetData();
    }
}
