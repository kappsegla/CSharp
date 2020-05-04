using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ConsoleApp.Linq
{
    //LINQ is query language. It can only filter and transform data.
    //That what LINQ is intended for.
    

    public class LinqDemo
    {
        public void Run()
        {
            Demo1();
        }
        
        
        //Query syntax:
        public void Demo1()
        {
            // The Three Parts of a LINQ Query:
            // 1. Obtain the data source.
            int[] numbers = new int[7] {0, 1, 2, 3, 4, 5, 6};

            // 2. Create the query.
            // numQuery is an IEnumerable<int>
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            // 3. Execute the query.
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }
        }

        
        //Method syntax:
        public void Demo2()
        {
            //int[] numbers = new int[7] {0, 1, 2, 3, 4, 5, 6};
            //var v = new []{1,2,3,4,5}.ToList();
            var numbers = Enumerable.Range(0, 7); 

            var enumerable = numbers.Where(i => i % 2 == 0);
            
            foreach (var i in enumerable)
            {
                Console.Write("{0,1} ", i);
            }
        }

        //Avoid returning a List if not needed.
        public List<string> GetCities()
        {
            return new List<string>(){"Kalmar","Stockholm","Göteborg","Malmö","Jönköping","Borås","Östersund","Lund"};
        } 
        //Prefer returning Enumerable interface instead.
        //https://medium.com/developers-arena/ienumerable-vs-icollection-vs-ilist-vs-iqueryable-in-c-2101351453db
        public IEnumerable<string> GetCitiesInterfaceStyle()
        {
            //Prefer returning an immutable collection, preventing the receiver or any other thread to change it.
            return ImmutableList.Create<string>("Kalmar", "Stockholm", "Göteborg", "Malmö", "Jönköping", "Borås",
                "Östersund", "Lund");
        }
    }
    
    //Relationships
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //One to Many Relationship
        public Course Course { get; set; }
        //One to One
        public Address Address { get; set; }
        
        //Many to Many
        public ICollection<Course> Courses { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
 
    //In swedish it's spelled Adress
    public class Address  
    {
        public int AddressId { get; set; }
        public string Road { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}