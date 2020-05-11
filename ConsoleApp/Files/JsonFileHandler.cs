using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp.Files
{
    public class JsonFileHandler
    {
        public void Run()
        {
            var persons = new List<Person>()
            {
                new Person() {Name = "Martin", Age = 42, City = "Kalmar"},
                new Person() {Name = "Anna", Age = 30, City = "Göteborg"}
            };
            var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var programPath = Path.Combine(path, ".DemoApp2020");
            var csvPath = Path.Combine(programPath, "Persons.json");
           
            SaveToJson(csvPath, persons);

            var records = LoadFromJson<Person>(csvPath);
            
            foreach (var person in records)
            {
                Console.WriteLine(person);
            }
            
            
        }

        public IEnumerable<T> LoadFromJson<T>(string filePath)
        {
            return null;
        }
        
        public void SaveToJson<T>(string filePath, IEnumerable<T> records)
        {
            
        }
    }
}