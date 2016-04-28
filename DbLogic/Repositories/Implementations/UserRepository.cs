using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DbLogic.Repositories.Interfaces;
using Domain;
using Domain.Entities;

namespace DbLogic.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(DbDataContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
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

        public void Create(User item)
        {
            _context.Users.Add(item);
        }

        public void Update(User item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(User item)
        {
            var userName = _context.Users.Find(item);
            if (userName != null)
                _context.Users.Remove(item);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private readonly DbDataContext _context;
        private bool _disposed = false;
    }
}
