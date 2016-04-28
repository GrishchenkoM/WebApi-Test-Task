using System.Collections.Generic;
using Domain.Entities;

namespace DbLogic.Repositories.Interfaces
{
    public interface IComputerRepository :  IRepository<Computer>
    {
        IEnumerable<Computer> GetComputers();
        Computer GetComputer(int id);
    }
}
