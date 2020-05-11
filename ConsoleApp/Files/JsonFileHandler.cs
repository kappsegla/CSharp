using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
            var jsonPath = Path.Combine(programPath, "Persons.json");
           
            SaveToJson(jsonPath, persons);

           var records = LoadFromJson<Person>(jsonPath);
            
            foreach (var person in records)
            {
                Console.WriteLine(person);
            }
        }

        public static IEnumerable<T> LoadFromJson<T>(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            
            var records = JsonSerializer.Deserialize<List<T>>(jsonString);
            return records;
        }
        
        public static void SaveToJson<T>(string filePath, IEnumerable<T> records)
        {
            var jsonString = JsonSerializer.SerializeToUtf8Bytes(records);
            File.WriteAllBytes(filePath, jsonString);
        }
    }
}