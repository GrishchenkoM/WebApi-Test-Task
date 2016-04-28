using System;

namespace DbLogic.Repositories.Interfaces
{
    public interface IRepository<T> : IDisposable where T: class
    {
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Save();
    }
}
