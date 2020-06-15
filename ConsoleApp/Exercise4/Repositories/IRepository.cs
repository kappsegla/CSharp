using System.Collections.Generic;

namespace ConsoleApp.Exercise4.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        void Delete(T product);
        void Insert(T product);
        void Save();
    }
}