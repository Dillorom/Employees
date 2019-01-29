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
                Console.WriteLine("What would you like to do? Enter one of the options: Add, List, Sort, Find, Remove.");

                string command = Console.ReadLine();

                if (command == "Add")
                {
                    Employee newEmployee = new Employee();
                    newEmployee.Id = Guid.NewGuid();

                    Console.WriteLine("What is the name of a new employee?");
                    newEmployee.Name = Console.ReadLine();

                    Console.WriteLine("What is the date of birth of the new employee? Format options: 'MM/DD/YY', 'MM/DD/YYYY',\n" +
                        " 'Jan 01, 2019', 'MM.DD.YY', 'MM.DD.YYYY', 'MM-DD-YY', 'MM-DD-YYYY'." );
                    try
                    {
                        string dateOfBirth = Console.ReadLine();
                        DateTime DateOfBirth = DateTime.Parse(dateOfBirth);
                        newEmployee.DateOfBirth = DateOfBirth;
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("Error! Please, enter date of birth in a correct format as suggested above.");
                    }

                    try
                    {
                        Console.WriteLine("What is the salary of the new employee?");
                        newEmployee.Salary = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("Error! Please, enter digits only.");
                    }
                    

                    employees.Add(newEmployee);
                    Console.WriteLine($"New employee {newEmployee.Name} with date of birth on\n" +
                        $" {newEmployee.DateOfBirth.ToString("dd/MM/yyyy")} and salary of {newEmployee.Salary} has been added.");
                }
                else if (command == "List")
                {
                    if (employees.Count != 0)
                    {
                        for (int i = 0; i < employees.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. Name: {employees[i].Name}, Date of Birth: {employees[i].DateOfBirth.ToString("dd/MM/yyyy")}," +
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

                            Console.WriteLine("Sorting employees in an ascending order by name: ");

                            foreach (Employee e in sortedEmployees)
                            {
                                Console.WriteLine($"Name: {e.Name}, Date of Birth: {e.DateOfBirth.ToString("dd/MM/yyyy")}," +
                                        $" Salary: {e.Salary}");
                            };
                        }
                        else if (choice == "Descending")
                        {
                            List<Employee> sortedEmployees = employees.OrderBy(e => e.Name).Reverse().ToList();

                            Console.WriteLine("Sorting employees in a descending order by name: ");

                            foreach (Employee e in sortedEmployees)
                            {
                                Console.WriteLine($"Name: {e.Name}, Date of Birth: {e.DateOfBirth.ToString("dd/MM/yyyy")}," +
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

                            Console.WriteLine("Sorting employees in an ascending order by date of birth: ");

                            foreach (Employee e in sortedEmployees)
                            {
                                Console.WriteLine($"Name: {e.Name}, Date of Birth: {e.DateOfBirth.ToString("dd/MM/yyyy")}," +
                                        $" Salary: {e.Salary}");
                            };
                        }
                        else if (choice == "Descending")
                        {
                            List<Employee> sortedEmployees = employees.OrderBy(e => e.DateOfBirth).Reverse().ToList();

                            Console.WriteLine("Sorting employees in a descending order by date of birth: ");

                            foreach (Employee e in sortedEmployees)
                            {
                                Console.WriteLine($"Name: {e.Name}, Date of Birth: {e.DateOfBirth.ToString("dd/MM/yyyy")}," +
                                        $" Salary: {e.Salary}");
                            };
                        }
                        else
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

                            Console.WriteLine("Sorting employees in an ascending order by salary: ");

                            foreach (Employee e in sortedEmployees)
                            {
                                Console.WriteLine($"Name: {e.Name}, Date of Birth: {e.DateOfBirth.ToString("dd/MM/yyyy")}," +
                                        $" Salary: {e.Salary}");
                            };
                        }
                        else if (choice == "Descending")
                        {
                            List<Employee> sortedEmployees = employees.OrderBy(e => e.Salary).Reverse().ToList();

                            Console.WriteLine("Sorting employees in a descending order by salary: ");

                            foreach (Employee e in sortedEmployees)
                            {
                                Console.WriteLine($"Name: {e.Name}, Date of Birth: {e.DateOfBirth.ToString("dd/MM/yyyy")}," +
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
                                Console.WriteLine($" Name: {e.Name}, Date of Birth: {e.DateOfBirth.ToString("dd/MM/yyyy")}," +
                                    $" Salary: {e.Salary}");
                            };
                        }
                        else
                        {
                            Console.WriteLine($"No employee with {enteredName} found in the list.");
                        };
                    }
                    else if (category == "DateOfBirth")
                    {
                        Console.WriteLine("Enter the employee DateOfBirth. Format options: 'MM/DD/YY', 'MM/DD/YYYY', 'Jan 01, 2019', 'MM.DD.YY', 'MM.DD.YYYY', 'MM-DD-YY', 'MM-DD-YYYY'.");

                        string enteredDateOfBirth = Console.ReadLine();

                        DateTime convertedDateOfBirth = DateTime.Parse(enteredDateOfBirth);

                        List<Employee> foundEmployees = employees.FindAll(e => e.DateOfBirth == convertedDateOfBirth);

                        if (foundEmployees.Count != 0)
                        {
                            foreach (Employee e in foundEmployees)
                            {
                                Console.WriteLine($" Name: {e.Name}, Date of Birth: {e.DateOfBirth.ToString("dd/MM/yyyy")}," +
                                    $" Salary: {e.Salary}");
                            };
                        }
                        else
                        {
                            Console.WriteLine($"No employee with date of birth of {enteredDateOfBirth} found in the list.");
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
                                Console.WriteLine($" Name: {e.Name}, Date of Birth: {e.DateOfBirth.ToString("dd/MM/yyyy")}," +
                                    $" Salary: {e.Salary}");
                            };
                        }
                        else
                        {
                            Console.WriteLine($"No employee with {enteredSalary} found in the list.");
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

                    List<Employee> toBeRemovedEmployees = employees.FindAll(e => e.Name == name);

                    if (toBeRemovedEmployees.Count > 1)
                    {
                        Console.WriteLine($"Which {name} would you like to remove? Please, select the employee number fromt he list.");

                        for (int i = 0; i < toBeRemovedEmployees.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {toBeRemovedEmployees[i].Name}, {toBeRemovedEmployees[i].DateOfBirth.ToString("dd/MM/yyyy")}, " +
                                $"{toBeRemovedEmployees[i].Salary}.");
                        }
                        int enteredNumber = int.Parse(Console.ReadLine());

                        employees.Remove(toBeRemovedEmployees[enteredNumber - 1]);
                        Console.WriteLine($"Employee Name: {toBeRemovedEmployees[enteredNumber - 1].Name}, Date of Birth:" +
                            $" {toBeRemovedEmployees[enteredNumber - 1].DateOfBirth.ToString("dd/MM/yyyy")}, " +
                            $"Salary: {toBeRemovedEmployees[enteredNumber - 1].Salary} has been removed from the list.");
                    }
                    else
                    {
                        employees.Remove(toBeRemovedEmployees[0]);
                        Console.WriteLine($"Employee Name: {toBeRemovedEmployees[0].Name}, Date of Birth: {toBeRemovedEmployees[0].DateOfBirth.ToString("dd/MM/yyyy")}, " +
                            $"Salary: {toBeRemovedEmployees[0].Salary} has been removed from the list.");
                    }
                }
                else if (command == "Exit")
                {
                    Console.WriteLine("Exiting the application. Goodbye! \nPress any key to confirm the exit.");

                    Console.ReadKey();

                    exit = true;
                }
                else
                {
                    Console.WriteLine("*** I do not understand this command. Please, try again." +
                        "Enter of of the options: Add, List, Sort, Find, Remove.***");
                };
            };
        }
    }
}





