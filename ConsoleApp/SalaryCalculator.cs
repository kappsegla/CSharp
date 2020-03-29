using System;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace ConsoleApp
{
    public class SalaryCalculator
    {
        //20 anställda
        private const int Employees = 20;

        //Lön per timma
        private const int SalaryPerHour = 100;
        //Grundlön per månad
        private const int SalaryPerMonth = 20000;
        
        private static string[] employeeNames = new string[20];
        private static int[] months = new int[20];
        private static int[] hours = new int[20];
        
        // Instantiate random number generator using system-supplied value as seed.
        //https://docs.microsoft.com/en-us/dotnet/api/system.random?view=netcore-3.1
        static Random random = new Random();

        // static Employee[] employees = new Employee[20];
        // struct Employee
        // {
        //     public Employee(string name, int months, int hours)
        //     {
        //         Name = name;
        //         Months = months;
        //         Hours = hours;
        //     }
        //
        //     private string Name { get; }
        //     private int Months { get; }
        //     private int Hours { get; }
        // }

        public static void Main(string[] args)
        {
            InitializeEmployees();
            PrintAllEmployeeInfo();
            PrintThreeMostExpensiveEmployees();
        }

        private static void PrintThreeMostExpensiveEmployees()
        {
            int[] list = FindThreeHighestSalaries();
            int sumSalary = 0;
            int sumHours = 0;

            Console.WriteLine("");
            Console.WriteLine("Top three salary costs:");
            for (int i = 0; i < list.Length; i++)
            {
                int id = list[i];
                sumSalary += CalculateCurrentSalaryForEmployee(i);
                sumHours += hours[id];
                Console.WriteLine($"{employeeNames[id]}\t\t{months[id]}\t{hours[id]}\t" +
                                  CalculateCurrentSalaryForEmployee(id));
            }

            Console.WriteLine($"Total cost: {sumSalary}\t Total hours: {sumHours}");
        }

        private static void InitializeEmployees()
        {
            for (int i = 0; i < 20; i++)
            {
                var chars = "abcdefghijklmnopqrstuvwxyz";
                var stringChars = new char[random.Next(2, 8)];

                for (int c = 0; c < stringChars.Length; c++)
                {
                    stringChars[c] = chars[random.Next(chars.Length)];
                }

                stringChars[0] = (char) (stringChars[0] - 32);

                var finalString = new String(stringChars);
                employeeNames[i] = finalString;

                //Returns a random value less than maxValue
                int num = random.Next(100);
                months[i] = num;
                if (i > 13)
                {
                    num = random.Next(20, 169);
                    hours[i] = num;
                }
                else
                {
                    hours[i] = 169;
                }
            }
        }

        static int CalculateCurrentSalaryForEmployee(int employeeId)
        {
            int h = hours[employeeId];
            int t = months[employeeId];

            int salary = 0;
            if (h == 169)
                salary = SalaryPerMonth;
            else
                salary = h * SalaryPerHour;

            salary = (int) (salary * Math.Pow(1.05, t / 5));

            if (salary > 3 * SalaryPerMonth)
                return 3 * SalaryPerMonth;

            return salary;
        }

        static int CalculateTotalSalarySum()
        {
            int sum = 0;
            for (int i = 0; i < 20; i++)
            {
                sum += CalculateCurrentSalaryForEmployee(i);
            }

            return sum;
        }

        static void PrintAllEmployeeInfo()
        {
            // Console.WriteLine("Name\t\tMonths\tHours\tSalary");
            // for (int i = 0; i < 20; i++)
            // {
            //     //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
            //     Console.WriteLine($"{employeeNames[i]}\t\t{months[i]}\t{hours[i]}\t" +
            //                       CalculateCurrentSalaryForEmployee(i));
            // }

            StringBuilder temp = new StringBuilder();
            temp.AppendLine("Name\t\tMonths\tHours\tSalary");
            for (int i = 0; i < 20; i++)
            {
                temp.AppendLine($"{employeeNames[i]}\t\t{months[i]}\t{hours[i]}\t" +
                                CalculateCurrentSalaryForEmployee(i));
            }

            Console.WriteLine(temp.ToString());

            Console.WriteLine("Total salaries:\t\t\t" + CalculateTotalSalarySum());
        }

        static int[] FindThreeHighestSalaries()
        {
            int first, second, third;

            third = first = second = 0;
            for (int i = 0; i < 20; i++)
            {
                // If current element is  
                // greater than first 
                if (CalculateCurrentSalaryForEmployee(i) > CalculateCurrentSalaryForEmployee(first))
                {
                    third = second;
                    second = first;
                    first = i;
                }

                // If arr[i] is in between first 
                // and second then update second 
                else if (CalculateCurrentSalaryForEmployee(i) > CalculateCurrentSalaryForEmployee(second))
                {
                    third = second;
                    second = i;
                }

                else if (CalculateCurrentSalaryForEmployee(i) > CalculateCurrentSalaryForEmployee(third))
                    third = i;
            }

            int[] toplist = new int[3] {first, second, third};
            return toplist;
        }
        
        
        
    }
}