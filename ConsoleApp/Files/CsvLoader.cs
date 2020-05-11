using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace ConsoleApp.Files
{
    public class CsvLoader
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
            var csvPath = Path.Combine(programPath, "Test.csv");
            
            LoadFromCsvFile(csvPath);
            
            
            

        }


        public void LoadFromCsvFile(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            
            //This will only load one line at a time into memory
            var records = csv.GetRecords<Person>();

            //This will load all of file into memory
            //var list = records.ToList();

            foreach (var person in records)
            {
                Console.WriteLine(person);
            }
        }
        
        
        
        public void SaveToCsvFile()
        {
            
        }
        
    }
}