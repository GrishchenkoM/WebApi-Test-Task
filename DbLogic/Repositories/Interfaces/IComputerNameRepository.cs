using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace DbLogic.Repositories.Interfaces
{
    public interface IComputerNameRepository :  IRepository<ComputerName>
    {
        IEnumerable<ComputerName> GetComputerNames();
        ComputerName GetComputerName(int id);
    }
}
