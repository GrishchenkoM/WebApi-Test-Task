using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DbLogic.Repositories.Interfaces;
using Domain;
using Domain.Entities;

namespace DbLogic.Repositories.Implementations
{
    public class ManufacturerRepository 
        : IManufacturerRepository, IRepository<Manufacturer>
    {
        public ManufacturerRepository(DbDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Manufacturer> GetManufacturers()
        {
            return _context.Manufacturers;
        }

        public Manufacturer GetManufacturer(int id)
        {
            return _context.Manufacturers.FirstOrDefault(x => x.Id == id);
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

        public void Create(Manufacturer item)
        {
            _context.Manufacturers.Add(item);
        }

        public void Update(Manufacturer item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Manufacturer item)
        {
            var manufacturer = _context.Manufacturers.Find(item);
            if (manufacturer != null)
                _context.Manufacturers.Remove(item);
        }

        public void Save(Manufacturer item)
        {
            _context.SaveChanges();
        }

        private readonly DbDataContext _context;
        private bool _disposed = false;
    }
}
