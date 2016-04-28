using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DbLogic.Repositories.Interfaces;
using Domain;
using Domain.Entities;

namespace DbLogic.Repositories.Implementations
{
    public class ComputerNameRepository : IComputerNameRepository
    {
        public ComputerNameRepository(DbDataContext context)
        {
            _context = context;
        }

        public IEnumerable<ComputerName> GetComputerNames()
        {
            return _context.ComputerNames;
        }

        public ComputerName GetComputerName(int id)
        {
            return _context.ComputerNames.FirstOrDefault(x => x.Id == id);
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

        public void Create(ComputerName item)
        {
            _context.ComputerNames.Add(item);
        }

        public void Update(ComputerName item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(ComputerName item)
        {
            var computerName = _context.ComputerNames.Find(item);
            if (computerName != null)
                _context.ComputerNames.Remove(item);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private readonly DbDataContext _context;
        private bool _disposed = false;
    }
}
