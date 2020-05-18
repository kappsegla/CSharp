using System.Collections.Generic;
using ConsoleApp.Files;
using Lucene.Net.Util.Packed;

namespace ConsoleApp.Repository
{
    public class FilePersonRepository : IPersonRepository
    {
        List<Person> persons = new List<Person>();
        
        public IEnumerable<Person> GetAll()
        {
            if (persons.Count == 0)
            {
                //Open file
                //Read all Persons into persons
            }

            //Return collection of persons as IEnumerable<Person>
            return persons;
        }

        public Person GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Person person)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}