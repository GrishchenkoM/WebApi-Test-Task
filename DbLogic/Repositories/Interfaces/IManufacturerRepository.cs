using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace DbLogic.Repositories.Interfaces
{
    public interface IManufacturerRepository
    {
        IEnumerable<Manufacturer> GetManufacturers();
        Manufacturer GetManufacturer(int id);
    }
}
