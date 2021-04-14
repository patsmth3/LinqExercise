using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            //Print the Sum and Average of numbers

            var sum = numbers.Sum();
            var avg = numbers.Average();

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Average: {avg}");

            Console.WriteLine("---------------------------------------------");

            //Order numbers in ascending order and decsending order. Print each to console.
            var asc = numbers.OrderBy(num => num);

            Console.WriteLine("Ascending order");

            foreach (var num in asc)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("---------------------------------------------");

            var desc = numbers.OrderBy(num => num);

            Console.WriteLine("Descensing Order");

            foreach (var num in desc)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("---------------------------------------------");

            //Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6);

            Console.WriteLine("Greater than six");

            foreach (var item in greaterThanSix)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------------------------------------");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var firstFour = asc.Take(4);

            Console.WriteLine("First 4 asc");

            foreach (var num in firstFour)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("---------------------------------------------");

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 32;

            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------------------------------------");

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var filtered = employees.Where(person => person.FirstName.StartsWith('C') ||
                                                     person.FirstName.StartsWith('S'))
                .OrderBy(person => person.FirstName);

            Console.WriteLine("Employees with the first name starting with either a C or S");

            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FirstName);
            }

            Console.WriteLine("---------------------------------------------");

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees.Where(emp => emp.Age > 26)
                .OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName)
                .ThenBy(emp => emp.YearsOfExperience);
            
            Console.WriteLine("Employees who are over the age of 26");

            foreach (var person in overTwentySix)
            {
                Console.WriteLine($"Age: {person.Age} Fullname: {person.FullName} YOE: {person.YearsOfExperience}");
            }

            Console.WriteLine("---------------------------------------------");
            
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var yoeEmployees = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age >= 35);
            var sumOfYears = yoeEmployees.Sum(emp => emp.YearsOfExperience);
            var avgOfYears = yoeEmployees.Average(emp => emp.YearsOfExperience);

            Console.WriteLine($"Sum: {sumOfYears} Avg: {avgOfYears}");
           
            Console.WriteLine("---------------------------------------------");
            
            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("first", "LastName", 98, 1)).ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.Age}");
            }

            
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
    
}
