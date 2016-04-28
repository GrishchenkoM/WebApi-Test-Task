using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DbLogic.Repositories.Interfaces;
using Domain;
using Domain.Entities;

namespace DbLogic.Repositories.Implementations
{
    public class UserNameRepository 
        : IUserNameRepository, IRepository<UserName>
    {
        public UserNameRepository(DbDataContext context)
        {
            _context = context;
        }
        public IEnumerable<UserName> GetUserNames()
        {
            return _context.UserNames;
        }

        public UserName GetUserName(int id)
        {
            return _context.UserNames.FirstOrDefault(x => x.Id == id);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Create(UserName item)
        {
            _context.UserNames.Add(item);
        }

        public void Update(UserName item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(UserName item)
        {
            var userName = _context.UserNames.Find(item);
            if (userName != null)
                _context.UserNames.Remove(item);
        }

        public void Save(UserName item)
        {
            _context.SaveChanges();
        }

        private readonly DbDataContext _context;
        private bool _disposed = false;
    }
}
