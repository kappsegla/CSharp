using System.Collections.Generic;
using ConsoleApp.Files;

namespace ConsoleApp.Repository
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person GetById(long id);
        void Delete(Person person);
        void Insert(Person person);
        void Save();
        //Add more needed CRUD methods...
    }
}