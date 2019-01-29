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

                    if (employees.Count != 0)
                    {
                        for (int i = 0; i < employees.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. Name: {employees[i].Name}, Date of Birth: {employees[i].DateOfBirth}," +
                                $" Salary: {employees[i].Salary}");
                        };
                    }
                    else
                    {
                        Console.WriteLine("*** There are no employees in the list. ***");
                    };

                }
                else if (command == "Sort")
                {
                    Console.WriteLine($"Sorted List:\n{employees.OrderBy(e => e.Name)}");
                }
                else if (command == "Find")
                {
                    Console.WriteLine("Enter the employee name.");

                    string name = Console.ReadLine();

                    List<Employee> foundEmployees = employees.FindAll(e => e.Name == name);

                    foreach (Employee e in foundEmployees)
                    {
                        Console.WriteLine($" Name: {e.Name}, Date of Birth: {e.DateOfBirth}," +
                            $" Salary: {e.Salary}");
                    };
                }
                else if (command == "Remove")
                {
                    Console.WriteLine("Enter the employee name.");

                    string name = Console.ReadLine();

                    Employee foundEmployee = employees.Find(e => e.Name == name);

                    employees.Remove(foundEmployee);

                    Console.WriteLine($"Employee {foundEmployee.Name} has been removed from the list.");
                }
                else if (command == "Exit")
                {
                    Console.WriteLine("Exiting the application. Goodbye! \nPress any key to confirm the exit.");

                    Console.ReadKey();

                    exit = true;
                }
                else
                {
                    Console.WriteLine("*** I don't recognize this command. Please, try again. All commands start in capital letters.***");
                };
            };
        }
    }
}





