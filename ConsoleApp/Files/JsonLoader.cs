using System.Collections.Generic;

namespace ConsoleApp.Files
{
    public class JsonLoader
    {
        public void Run()
        {
            var persons = new List<Person>()
            {
                new Person() {Name = "Martin", Age = 42, City = "Kalmar"},
                new Person() {Name = "Anna", Age = 30, City = "Göteborg"}
            };
            
        }


        public void LoadFromJson()
        {
            
        }
        
        public void SaveToJson()
        {
            
        }
    }
}