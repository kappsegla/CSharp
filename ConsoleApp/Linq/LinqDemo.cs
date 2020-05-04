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
            Demo3();

            // var list = GetCities();
            //
            // var i = list.Where(s => s.Contains("r")).Count();
            //
            // Console.WriteLine("Number of cities containing r: " + i);
        }

        //Avoid returning a List if not needed.
        public IEnumerable<string> GetCities()
        {
            return new List<string>()
            {
                "Kalmar", "Stockholm", "Göteborg",
                "Malmö", "Jönköping", "Borås", "Östersund", "Lund"
            };
        }


        //Query syntax:
        public void Demo1()
        {
            // The Three Parts of a LINQ Query:
            // 1. Obtain the data source.
            int[] numbers = new int[] {0, 1, 2, 3, 4, 5, 6};

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
            //var numbers = new List<int>{0,1,2,3,4,5,6};
            var numbers = Enumerable.Range(0, 7);


            double average = numbers.Average();
            Console.WriteLine("Average of numbers: " + average);

            var enumerable = numbers.Where(i => i % 2 == 0);
            //var enumerable = numbers.Where(IsEven);
            
            foreach (var i in enumerable)
            {
                Console.WriteLine("{0,1} ", i);
            }
        }

        private bool IsEven(int i)
        {
            return i % 2 == 0;
        }



        //Prefer returning Enumerable interface instead.
        //https://medium.com/developers-arena/ienumerable-vs-icollection-vs-ilist-vs-iqueryable-in-c-2101351453db
        public IEnumerable<string> GetCitiesInterfaceStyle()
        {
            //Prefer returning an immutable collection, preventing the receiver or any other thread to change it.
            return ImmutableList.Create<string>("Kalmar", "Stockholm", "Göteborg", "Malmö", "Jönköping", "Borås",
                "Östersund", "Lund");
        }

        private void Demo3()
        {
            //Create some students and courses.
            var course1 = new Course() {CourseId = 0, CourseName = "C#"};
            var course2 = new Course() {CourseId = 1, CourseName = "Database"};

            var students = new List<Student>()
            {
                new Student() {Id = 0, Name = "Martin", Course = course1},
                new Student() {Id = 1, Name = "Maria", Course = course1},
                new Student() {Id = 2, Name = "Malin", Course = course2},
                new Student() {Id = 3, Name = "Kalle", Course = course1},
                new Student() {Id = 4, Name = "Indira", Course = course1},
                new Student() {Id = 5, Name = "Parul", Course = course2}
            };
            //Ask questions like which students attends a specific course
            var list = students.Where(s => s.Course.CourseId == 0);

            foreach (var student in list)
            {
                Console.WriteLine(student.Name);
            }

            //How many students do we have on each course?
            var groups =
                students.GroupBy(s => s.Course)
                    .Select(group => new
                    {
                        CourseName = group.Key.CourseName,
                        StudentCount = group.Count()
                    }).OrderBy(x => x.CourseName);

            foreach (var group in groups)
            {
                Console.WriteLine(group.CourseName + "\t" + group.StudentCount);
            }


            // foreach (var group in groups)
            // {
            //     Console.WriteLine("Course: {0}", group.Key.CourseName); //Each group has a key 
            //  
            //     foreach(var s in group) // Each group has inner collection
            //         Console.WriteLine("Student Name: {0}", s.Name);
            // }


            //C#  4
            //Database 2
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Course Course { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}