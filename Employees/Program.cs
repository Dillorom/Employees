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
                    Console.WriteLine("What category would you like to sort by? Enter one of the options: Name, DateOfBirth, Salary");

                    string category = Console.ReadLine();

                    if (category == "Name")
                    {
                        Console.WriteLine("Ascending or Descending?");

                        string choice = Console.ReadLine();
                        if (choice == "Ascending")
                        {
                            List<Employee> sortedEmployees = employees.OrderBy(e => e.Name).ToList();

                            foreach (Employee e in sortedEmployees)
                            {
                                Console.WriteLine($"Name: {e.Name}, Date of Birth: {e.DateOfBirth}," +
                                        $" Salary: {e.Salary}");
                            };
                        }
                        else if (choice == "Descending")
                        {
                            List<Employee> sortedEmployees = employees.OrderBy(e => e.Name).Reverse().ToList();

                            foreach (Employee e in sortedEmployees)
                            {
                                Console.WriteLine($"Name: {e.Name}, Date of Birth: {e.DateOfBirth}," +
                                        $" Salary: {e.Salary}");
                            };
                        }
                        else
                        {
                            Console.WriteLine("I do not understand this command. Please, enter 'Ascending' or 'Descending'.");
                        }

                    }
                    else if (category == "DateOfBirth")
                    {
                        Console.WriteLine("Ascending or Descending?");

                        string choice = Console.ReadLine();

                        if (choice == "Ascending")
                        {
                            List<Employee> sortedEmployees = employees.OrderBy(e => e.DateOfBirth).ToList();

                            foreach (Employee e in sortedEmployees)
                            {
                                Console.WriteLine($"Name: {e.Name}, Date of Birth: {e.DateOfBirth}," +
                                        $" Salary: {e.Salary}");
                            };
                        }
                        else if (choice == "Descending")
                        {
                            List<Employee> sortedEmployees = employees.OrderBy(e => e.DateOfBirth).Reverse().ToList();

                            foreach (Employee e in sortedEmployees)
                            {
                                Console.WriteLine($"Name: {e.Name}, Date of Birth: {e.DateOfBirth}," +
                                        $" Salary: {e.Salary}");
                            };
                        }
                        {
                            Console.WriteLine("I do not understand this command. Please, enter 'Ascending' or 'Descending'.");
                        };
                    }
                    else if (category == "Salary")
                    {
                        Console.WriteLine("Ascending or Descending?");

                        string choice = Console.ReadLine();

                        if (choice == "Ascending")
                        {
                            List<Employee> sortedEmployees = employees.OrderBy(e => e.Salary).ToList();

                            foreach (Employee e in sortedEmployees)
                            {
                                Console.WriteLine($"Name: {e.Name}, Date of Birth: {e.DateOfBirth}," +
                                        $" Salary: {e.Salary}");
                            };
                        }
                        else if (choice == "Descending")
                        {
                            List<Employee> sortedEmployees = employees.OrderBy(e => e.Salary).Reverse().ToList();

                            foreach (Employee e in sortedEmployees)
                            {
                                Console.WriteLine($"Name: {e.Name}, Date of Birth: {e.DateOfBirth}," +
                                        $" Salary: {e.Salary}");
                            };
                        }
                        else
                        {
                            Console.WriteLine("I do not understand this command. Please, enter 'Ascending' or 'Descending'.");
                        };
                    };
                }
                else if (command == "Find")
                {
                    Console.WriteLine("What category would you like to find by? Enter one of the options: Name, DateOfBirth, Salary");

                    string category = Console.ReadLine();

                    if (category == "Name")
                    {
                        Console.WriteLine("Enter the employee name.");

                        string enteredName = Console.ReadLine();

                        List<Employee> foundEmployees = employees.FindAll(e => e.Name == enteredName);

                        if (foundEmployees.Count != 0)
                        {
                            foreach (Employee e in foundEmployees)
                            {
                                Console.WriteLine($" Name: {e.Name}, Date of Birth: {e.DateOfBirth}," +
                                    $" Salary: {e.Salary}");
                            };
                        }
                        else
                        {
                            Console.WriteLine($"No employee by {enteredName} found in the list.");
                        };
                    }
                    else if (category == "DateOfBirth")
                    {
                        Console.WriteLine("Enter the employee DateOfBirth.");

                        string enteredDateOfBirth = Console.ReadLine();

                        List<Employee> foundEmployees = employees.FindAll(e => e.DateOfBirth == enteredDateOfBirth);

                        if (foundEmployees.Count != 0)
                        {
                            foreach (Employee e in foundEmployees)
                            {
                                Console.WriteLine($" Name: {e.Name}, Date of Birth: {e.DateOfBirth}," +
                                    $" Salary: {e.Salary}");
                            };
                        }
                        else
                        {
                            Console.WriteLine($"No employee by {enteredDateOfBirth} found in the list.");
                        };
                    }
                    else if (category == "Salary")
                    {
                        Console.WriteLine("Enter the employee Salary.");

                        int enteredSalary = int.Parse(Console.ReadLine());

                        List<Employee> foundEmployees = employees.FindAll(e => e.Salary == enteredSalary);

                        if (foundEmployees.Count != 0)
                        {
                            foreach (Employee e in foundEmployees)
                            {
                                Console.WriteLine($" Name: {e.Name}, Date of Birth: {e.DateOfBirth}," +
                                    $" Salary: {e.Salary}");
                            };
                        }
                        else
                        {
                            Console.WriteLine($"No employee by {enteredSalary} found in the list.");
                        };
                    }
                    else
                    {
                        Console.WriteLine("I do not understand this category. Next time enter one of the options: Name, DateOfBirth, Salary");
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





