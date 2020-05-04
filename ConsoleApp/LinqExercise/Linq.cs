﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.LinqExercise
{
    class Country
    {
        public Country(string name, string capital, double pop, int area)
        {
            Name = name;
            Capital = capital;
            Population = pop;
            Area = area;
        }

        public string Name { get; set; }
        public string Capital { get; set; }
        public double Population { get; set; }
        public int Area { get; set; }
    }


    public class Linq
    {
        private IEnumerable<Country> countries = new List<Country>()
        {
            new Country("Sverige", "Stockholm", 10.07, 450295),
            new Country("Norge", "Oslo", 5.27, 323802),
            new Country("Island", "Reykyavik", 0.33, 102775),
            new Country("Danmark", "Köpenhamn", 5.75, 42931),
            new Country("Finland", "Helsinki", 5.51, 338424),
            new Country("Belgien", "Bryssel", 11.30, 30528),
            new Country("Tyskland", "Berlin", 82.18, 357168),
            new Country("Frankrike", "Paris", 66.99, 640679),
            new Country("Storbritannien", "London", 60.80, 209331),
            new Country("Niue", "Alofi", 0.0016, 261),
            new Country("Mongoliet", "Kuala Lumpur", 3.08, 1566000),
            new Country("Polen", "Warsawa", 38.63, 312679),
            new Country("Spanien", "Madrid", 46.5, 505990),
            new Country("Portugal", "Lissabon", 10.31, 92212),
            new Country("Italien", "Rom", 60.59, 301338),
            new Country("Grekland", "Aten", 11.18, 131957),
            new Country("Luxemburg", "Luxemburg", 0.58, 2586),
            new Country("Liechtenstein", "Vaduz", 0.038, 160)
        };

        public void Run()
        {
            // Uppgift2();
            // Uppgift3();
            // Uppgift4();
            // Uppgift5();
            // Uppgift6();
            // Uppgift7();
            // Uppgift8();
            // Uppgift9();
            // Uppgift10();
            //Uppgift11();
            //Uppgift12();
            //Uppgift13();
            Uppgift14();
        }

        

        //Skriv ut namnet på det första och det sista landet i listan på konsolen.
        public void Uppgift2()
        {
            Console.WriteLine(countries.First().Name);
            Console.WriteLine(countries.Last().Name);
        }

        //Skriv ut namnen på alla länder i listan, sorterade i bokstavsordning.
        public void Uppgift3()
        {
            var query = countries.OrderBy(c => c.Name);

            Console.WriteLine("Sorted on Name.");
            foreach (var country in query)
            {
                Console.WriteLine(country.Name);
            }
        }

        //Skriv ut namnen på alla länder i listan, sorterade efter befolkning, med den högsta befolkningen först.
        public void Uppgift4()
        {
            var query = countries.OrderByDescending(c => c.Population);

            Console.WriteLine("Sorted for population, biggest first.");
            foreach (var country in query)
            {
                Console.WriteLine(country.Name + "  " + country.Population);
            }
        }

        //Skriv ut vilken den största befolkningsmängden är.
        public void Uppgift5()
        {
            var maxPop = countries.Max(c => c.Population);

            Console.WriteLine("Max population: " + maxPop);
        }
        
        //Skriv ut genomsnittsarean och hur många länder som har en mindre area än genomsnittet.
        public void Uppgift6()
        {
            var avgArea = countries.Average(c => c.Area);
            Console.WriteLine("Average area: " + avgArea);
            var query = countries.Where(c => c.Area < avgArea);
            Console.WriteLine("Countries smaller than average:");
            foreach (var country in query)
            {
                Console.WriteLine(country.Name);
            }
        }
        //Skriv ut namnen på alla länder som har en befolkning som är mindre än 5 miljoner.
        public void Uppgift7()
        {
            //var query = countries.Where(c => c.Population < 5.0);
            //Using Query syntax
            var query = from c in countries
                where c.Population < 5.0
                select c;
            Console.WriteLine("Population less than 5 miljon: ");
            foreach (var country in query)
            {
                Console.WriteLine(country.Name + "  " + country.Population);
            }
        }
        
        //Använd tre queries för att skriva ut hur många länder som har en
        //area över 10 000, över 100 000 och över 1 000 000 respektive.
        public void Uppgift8()
        {
            //We don't need Where here, Count has a overloaded version that takes a filter directly
            Console.WriteLine(countries.Where(c => c.Area > 10000).Count());
            Console.WriteLine(countries.Count(c => c.Area > 100000));
            Console.WriteLine(countries.Count(c => c.Area > 1000000));
        }
        
        //Skriv ut namn och huvudstad för alla länder vars huvudstad börjar på samma bokstav som landets namn.
        public void Uppgift9()
        {
            var query = countries.Where(c => c.Name[0] == c.Capital[0]);
            Console.WriteLine("Countries where name and capital starts with same letter:");
            foreach (var country in query)
            {
                Console.WriteLine(country.Name + " - " + country.Capital);
            }
        }
        //Skriv ut alla land vars namn är längre än namnet på deras huvudstad.
        public void Uppgift10()
        {
            var query = countries.Where(c => c.Name.Length > c.Capital.Length);
             foreach (var country in query)
            {
                Console.WriteLine(country.Name + " - " + country.Capital);
            }
        }

        //Skriv ut de fem första länderna som har minst folkmängd.
        public void Uppgift11()
        {
            var query = countries.OrderBy(c => c.Population).Take(5);
            foreach (var country in query)
            {
                Console.WriteLine(country.Name + " " + country.Population);
            }
        }

        //Skriv ut de tre första länderna som har minst folkmängd och över 7 miljoner.
        //Exempelvis kommer Norge inte med för det har bara 5 miljoner,
        //men Sverige har 10 miljoner så det kommer med.
        public void Uppgift12()
        {
            var query =
                countries.Where(c => c.Population > 7.0)
                    .OrderBy(c => c.Population)
                    .Take(3);
                
             foreach (var country in query)
            {
                Console.WriteLine(country.Name + " " + country.Population);
            }
        }

        //Skriv ut namnen på upp till tre länder som har en area på minst 500 000 km2,
        //sorterade fallande efter namn.
        public void Uppgift13()
        {
            var query = countries.Where(c => c.Area >= 500000)
                                         .OrderByDescending(c => c.Name)
                                         .Take(3);
            
            foreach (var country in query)
            {
                Console.WriteLine(country.Name + " " + country.Population);
            }
        }

        //Skriv ut hur många länder det finns som börjar på varje bokstav som finns i listan. Exempelvis så finns det två länder vars namn börjar på S,
        //ett som börjar på D och två som börjar på F. Tips: group..by..into.
        public void Uppgift14()
        {
            var query = countries.GroupBy(c => c.Name[0]);
            
            foreach (var groups in query)
            {
                Console.WriteLine(groups.Key);
                foreach (var c in groups)
                {
                    Console.WriteLine("\t" + c.Name);
                }
            }
            
        }
    }
}