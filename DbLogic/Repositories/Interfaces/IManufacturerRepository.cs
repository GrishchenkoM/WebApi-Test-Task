using System.Collections.Generic;
using Domain.Entities;

namespace DbLogic.Repositories.Interfaces
{
    public interface IManufacturerRepository : IRepository<Manufacturer>
    {
        IEnumerable<Manufacturer> GetManufacturers();
        Manufacturer GetManufacturer(int id);
    }
}
