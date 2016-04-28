using System.Collections.Generic;
using Domain.Entities;

namespace DbLogic.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
    }
}
