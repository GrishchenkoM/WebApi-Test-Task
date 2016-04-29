using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DbLogic;
using Domain;
using Domain.Entities;
using WMI;

namespace Management
{
    public class Manager
    {
        public Manager(DataManager dataManager, IGetInfo info)
        {
            _dataManager = dataManager;
            _info = info;

            var thread = new Thread(new Timer(this, _updateTime).SwitchOn);
            thread.Start();
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
            try
            {
                var userNames = _dataManager.UserRepositories.GetUsers().ToList();

                if (!userNames.Any())
                    foreach (var name in model.Users)
                    {
                        _dataManager.UserRepositories.Create(name);
                    }
                else
                {
                    var userNamesOld = new List<User>(userNames);
                    var userNamesNew = new List<User>(model.Users);

                    if (userNamesNew.Count >= userNamesOld.Count)
                    {
                        foreach (var oldName in userNamesOld)
                        {
                            var item = userNamesNew.FirstOrDefault(x => x.Name.Equals(oldName.Name));

                            if (item != null)
                                userNamesNew.Remove(item);
                            else
                                userNames.Remove(item);

                            userNamesOld.Remove(item);
                        }
                        foreach (var userName in userNamesNew)
                        {
                            _dataManager.UserRepositories.Create(userName);
                        }
                    }
                    else
                    {
                        foreach (var userName in userNamesNew)
                        {
                            var item = userNamesOld.FirstOrDefault(x => x.Name.Equals(userName.Name));

                            if (item != null)
                            {
                                userNamesNew.Remove(item);
                                userNamesOld.Remove(item);
                            }
                            else
                                _dataManager.UserRepositories.Create(userName);
                        }
                        foreach (var userName in userNamesOld)
                        {
                            userNames.Remove(userName);
                        }
                    }
                }
                _dataManager.UserRepositories.Save();
            }
            catch { }
        }

        private void ManageManufacturer(EntitiesModel model)
        {
            try
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
            catch { }
        }

        private void ManageComputerName(EntitiesModel model)
        {
            try
            {
                var computerNames = _dataManager.ComputerRepositories.GetComputers().ToList();

                if (!computerNames.Any())
                    _dataManager.ComputerRepositories.Create(model.Computer);
                else
                {
                    if (!computerNames[0].Name.Equals(model.Computer.Name))
                    {
                        model.Computer.Id = computerNames[0].Id;
                        _dataManager.ComputerRepositories.Update(model.Computer);
                    }
                }
                _dataManager.ComputerRepositories.Save();
            }
            catch { }
        }

        private readonly DataManager _dataManager;
        private readonly IGetInfo _info;
        private readonly int _updateTime = 1800; // 30 minutes
    }
}
