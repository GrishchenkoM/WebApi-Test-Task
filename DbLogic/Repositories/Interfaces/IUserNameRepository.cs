using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace DbLogic.Repositories.Interfaces
{
    public interface IUserNameRepository
    {
        IEnumerable<UserName> GetUserNames();
        UserName GetUserName(int id);
    }
}
