using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLogic;
using Domain;
using WMI;

namespace Management
{
    public class Manager
    {
        public Manager(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public Manager(DataManager dataManager, IGetInfo info)
        {
            _dataManager = dataManager;
            _info = info;

        }

        public void Manage()
        {
            var model = _info.GetInfo();

            ManageComputerName(model);
            ManageManufacturer(model);
            ManageUserName(model);
        }

        private void ManageUserName(EntitiesModel model)
        {
            var manufacturer = _dataManager.ManufacturerRepositories.GetManufacturers().ToList();

            if (!manufacturer.Any())
                _dataManager.ManufacturerRepositories.Create(model.Manufacturer);
            else
            {
                if (!manufacturer[0].Name.Equals(model.Manufacturer.Name))
                {
                    model.Manufacturer.Id = manufacturer[0].Id;
                    _dataManager.ManufacturerRepositories.Update(model.Manufacturer);
                }
            }
            _dataManager.ManufacturerRepositories.Save();
        }

        private void ManageManufacturer(EntitiesModel model)
        {
            var manufacturer = _dataManager.ManufacturerRepositories.GetManufacturers().ToList();

            if (!manufacturer.Any())
                _dataManager.ManufacturerRepositories.Create(model.Manufacturer);
            else
            {
                if (!manufacturer[0].Name.Equals(model.Manufacturer.Name))
                {
                    model.Manufacturer.Id = manufacturer[0].Id;
                    _dataManager.ManufacturerRepositories.Update(model.Manufacturer);
                }
            }
            _dataManager.ManufacturerRepositories.Save();
        }

        private void ManageComputerName(EntitiesModel model)
        {
            var computerNames = _dataManager.ComputerNameRepositories.GetComputerNames().ToList();

            if (!computerNames.Any())
                _dataManager.ComputerNameRepositories.Create(model.ComputerName);
            else
            {
                if (!computerNames[0].Name.Equals(model.ComputerName.Name))
                {
                    model.ComputerName.Id = computerNames[0].Id;
                    _dataManager.ComputerNameRepositories.Update(model.ComputerName);
                }
            }
            _dataManager.ComputerNameRepositories.Save();
        }

        private readonly DataManager _dataManager;
        private readonly IGetInfo _info;
    }
}
