using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using Domain;
using Domain.Entities;

namespace WMI
{
    public class WmInfo
    {
        protected EntitiesModel GetInfo()
        {
            var model = new EntitiesModel();

            model.Manufacturer = new Manufacturer();
            var manufacturer = GetInfo("Win32_ComputerSystem", "Manufacturer");
            if (manufacturer.Any())
            {
                model.Manufacturer.Name = manufacturer[0];
            }

            model.ComputerName = new ComputerName();
            var computerName = GetInfo("Win32_ComputerSystem", "Name");
            if (computerName.Any())
            {
                model.ComputerName.Name = computerName[0];
            }

            model.UserNames = new List<UserName>();
            var userNames = GetInfo("Win32_UserAccount", "Name");
            if (userNames.Any())
                foreach (var name in userNames)
                {
                    model.UserNames.Add(new UserName() {Name = name});
                }

            return model;
        }

        private List<string> GetInfo(string fromWin32Class, string classItemAdd)
        {
            List<string> result = new List<string>();
            ManagementObjectSearcher searcher =
            new ManagementObjectSearcher("SELECT * FROM " + fromWin32Class);
            try
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    result.Add(obj[classItemAdd].ToString().Trim());
                }
            }
            catch (Exception ex) { }

            return result;
        }
    }
}
