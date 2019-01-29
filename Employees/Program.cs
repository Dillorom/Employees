using System;
using System.Collections.Generic;
using System.Linq;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("What would you like to do?");

                string command = Console.ReadLine();

                if (command == "Add")
                {
                    Employee newEmployee = new Employee();
                    newEmployee.Id = Guid.NewGuid();

                    Console.WriteLine("What is the name of a new employee?");
                    newEmployee.Name = Console.ReadLine();

                    Console.WriteLine("What is the date of birth of the new employee?");
                    newEmployee.DateOfBirth = Console.ReadLine();

                    Console.WriteLine("What is the salary of the new employee?");
                    newEmployee.Salary = int.Parse(Console.ReadLine());

                    employees.Add(newEmployee);
                    Console.WriteLine($"New employee {newEmployee.Name} with date of birth on\n" +
                        $" {newEmployee.DateOfBirth} and salary of {newEmployee.Salary} has been added.");
                }
                else if (command == "List")
                {
                    for (int i = 0; i < employees.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Name: {employees[i].Name}, Date of Birth: {employees[i].DateOfBirth}, Salary: {employees[i].Salary}");
                    };
                }
                else if (command == "Sort")
                {
                    employees.OrderBy(e => e.Name);
                }
            };
        }
    }
}
