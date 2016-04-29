using System.Linq;
using DbLogic;
using Domain;
using Management;

namespace WebApiApp.Models
{
    public class ViewModel
    {
        public ViewModel(DataManager manager)
        {
            _manager = manager;
            FillModel();
        }

        public ViewModel(DataManager dataManager, Manager manager)
        {
            _manager = dataManager;
            manager.Manage();
            FillModel();
        }

        private void FillModel()
        {
            try
            {
                Model = new EntitiesModel()
                {
                    Manufacturer = _manager.ManufacturerRepositories.GetManufacturers().FirstOrDefault(),
                    Computer = _manager.ComputerRepositories.GetComputers().FirstOrDefault(),
                    Users = _manager.UserRepositories.GetUsers().ToList()
                };
            }
            catch
            {
                // ignored
            }
        }

        public EntitiesModel Model { get; private set; }
        private readonly DataManager _manager;
    }
}