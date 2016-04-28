using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DbLogic.Repositories.Interfaces;
using Domain;
using Domain.Entities;

namespace DbLogic.Repositories.Implementations
{
    public class ComputerRepository : IComputerRepository
    {
        public ComputerRepository(DbDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Computer> GetComputers()
        {
            return _context.Computers;
        }

        public Computer GetComputer(int id)
        {
            return _context.Computers.FirstOrDefault(x => x.Id == id);
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

        public void Create(Computer item)
        {
            _context.Computers.Add(item);
        }

        public void Update(Computer item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Computer item)
        {
            var computerName = _context.Computers.Find(item);
            if (computerName != null)
                _context.Computers.Remove(item);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private readonly DbDataContext _context;
        private bool _disposed = false;
    }
}
