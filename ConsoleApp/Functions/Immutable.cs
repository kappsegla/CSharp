using System.Collections.Immutable;
using Lucene.Net.Util;

namespace ConsoleApp.Functions
{
    public class Immutable
    {
        public void Run()
        {
            var immutableList = ImmutableList.Create(1, 2, 3, 4, 5);
            var newImmutableList = immutableList.Add(6); //Returns new immutableList with 6 added.
        }
    }

    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static Person Rename(Person person, string firstName)
        {
            return new Person(firstName, person.LastName);
        }

        public Person With(string firstName = null, string lastName = null)
        {
            return new Person(firstName ?? this.FirstName, lastName ?? this.LastName);
        }
    }
}