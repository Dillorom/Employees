using System;
using System.Collections.Generic;
using System.Linq;

namespace Employees
{
    class Program
    {
        static List<Employee> employees = new List<Employee>();

        static string category;

        static string sortingDirection;

        static string enteredData;

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("What would you like to do? Enter one of the options: Add, List, Sort, Find, Remove, Exit.");

                string command = Console.ReadLine();

                switch (command)
                {
                    case "Add":

                        Employee newEmployee = new Employee();

                        newEmployee.Id = Guid.NewGuid();

                        bool nameCondition = true;

                        while (nameCondition)
                        {
                            Console.WriteLine("What is the name of the new employee?");

                            newEmployee.Name = Console.ReadLine();

                            if (!newEmployee.ValidName())
                            {
                                InvalidInputMessage();
                            }
                            else
                            {
                                nameCondition = false;
                            };
                        }

                        bool dateOfBirthCondition = true;

                        while (dateOfBirthCondition)
                        {
                            DateOfBirthPropt();

                            try
                            {
                                DateTime DateOfBirth = DateTime.Parse(enteredData);

                                newEmployee.DateOfBirth = DateOfBirth;

                                if (!newEmployee.ValidDateOfBirth())
                                {
                                    InvalidInputMessage();
                                }
                                else
                                {
                                    dateOfBirthCondition = false;
                                }
                            }
                            catch (Exception)
                            {
                                InvalidInputMessage();
                            }
                        };

                        bool salaryCondition = true;

                        while (salaryCondition)
                        {
                            Console.WriteLine("What is the salary of the new employee?");

                            try
                            {
                                newEmployee.Salary = int.Parse(Console.ReadLine());

                                if (!newEmployee.ValidSalary())
                                {
                                    InvalidInputMessage();
                                }
                                else
                                {
                                    if (newEmployee.ValidName() && (newEmployee.ValidDateOfBirth() && newEmployee.ValidSalary()))
                                    {
                                        employees.Add(newEmployee);

                                        Console.WriteLine($"New employee {newEmployee.Name} with date of birth on\n" +
                                            $" {newEmployee.DateOfBirth.ToString("MM/dd/yyyy")} and salary of {newEmployee.Salary} has been added.");
                                        break;
                                    }
                                };
                            }
                            catch (Exception)
                            {
                                InvalidInputMessage();
                            };
                        };
                        break;

                    case "List":

                        if (employees.Count != 0)
                        {
                            for (int i = 0; i < employees.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. Name: {employees[i].Name}, Date of Birth: {employees[i].DateOfBirth.ToString("MM/dd/yyyy")}," +
                                    $" Salary: {employees[i].Salary}");
                            };
                        }
                        else
                        {
                            Console.WriteLine("*** There are no employees in the list. ***");
                        };
                        break;

                    case "Sort":

                        CategoryPrompt(command);

                        if (category == "Name")
                        {
                            SortingDirectionPrompt();

                            if (sortingDirection == "Ascending")
                            {
                                List<Employee> sortedEmployees = employees.OrderBy(e => e.Name).ToList();

                                OrderCategoryMessageAndResult(sortingDirection, category, sortedEmployees);
                            }
                            else if (sortingDirection == "Descending")
                            {
                                List<Employee> sortedEmployees = employees.OrderBy(e => e.Name).Reverse().ToList();

                                OrderCategoryMessageAndResult(sortingDirection, category, sortedEmployees);
                            }
                            else
                            {
                                SortingDirectionError();
                            }
                        }
                        else if (category == "DateOfBirth")
                        {
                            SortingDirectionPrompt();

                            if (sortingDirection == "Ascending")
                            {
                                List<Employee> sortedEmployees = employees.OrderBy(e => e.DateOfBirth).ToList();

                                OrderCategoryMessageAndResult(sortingDirection, category, sortedEmployees);
                            }
                            else if (sortingDirection == "Descending")
                            {
                                List<Employee> sortedEmployees = employees.OrderBy(e => e.DateOfBirth).Reverse().ToList();

                                OrderCategoryMessageAndResult(sortingDirection, category, sortedEmployees);
                            }
                            else
                            {
                                SortingDirectionError();
                            };
                        }
                        else if (category == "Salary")
                        {
                            SortingDirectionPrompt();

                            if (sortingDirection == "Ascending")
                            {
                                List<Employee> sortedEmployees = employees.OrderBy(e => e.Salary).ToList();

                                OrderCategoryMessageAndResult(sortingDirection, category, sortedEmployees);
                            }
                            else if (sortingDirection == "Descending")
                            {
                                List<Employee> sortedEmployees = employees.OrderBy(e => e.Salary).Reverse().ToList();

                                OrderCategoryMessageAndResult(sortingDirection, category, sortedEmployees);
                            }
                            else
                            {
                                SortingDirectionError();
                            };
                        };
                        break;

                    case "Find":

                        CategoryPrompt(command);

                        if (category == "Name")
                        {
                            FindByPrompt(category);

                            List<Employee> foundEmployees = employees.FindAll(e => e.Name == enteredData);

                            EmployeeCountCheck(foundEmployees);
                        }
                        else if (category == "DateOfBirth")
                        {
                            DateOfBirthPropt();

                            try
                            {
                                DateTime convertedDateOfBirth = DateTime.Parse(enteredData);

                                List<Employee> foundEmployees = employees.FindAll(e => e.DateOfBirth == convertedDateOfBirth);

                                EmployeeCountCheck(foundEmployees);
                            }
                            catch (Exception)
                            {
                                InvalidInputMessage();
                            };
                        }
                        else if (category == "Salary")
                        {
                            FindByPrompt(category);

                            int convertedData = int.Parse(enteredData);

                            List<Employee> foundEmployees = employees.FindAll(e => e.Salary == convertedData);

                            EmployeeCountCheck(foundEmployees);
                        }
                        else
                        {
                            InvalidInputMessage();
                        };
                        break;

                    case "Remove":

                        Console.WriteLine("Enter the employee name.");

                        string name = Console.ReadLine();

                        List<Employee> toBeRemovedEmployees = employees.FindAll(e => e.Name == name);

                        if (toBeRemovedEmployees.Count > 1)
                        {
                            Console.WriteLine($"Which {name} would you like to remove? Please, select the employee number from the list.");

                            for (int i = 0; i < toBeRemovedEmployees.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {toBeRemovedEmployees[i].Name}, {toBeRemovedEmployees[i].DateOfBirth.ToString("MM/dd/yyyy")}, " +
                                    $"{toBeRemovedEmployees[i].Salary}.");
                            }

                            int enteredNumber = int.Parse(Console.ReadLine());

                            employees.Remove(toBeRemovedEmployees[enteredNumber - 1]);

                            Console.WriteLine($"Employee Name: {toBeRemovedEmployees[enteredNumber - 1].Name}, Date of Birth:" +
                                $" {toBeRemovedEmployees[enteredNumber - 1].DateOfBirth.ToString("MM/dd/yyyy")}, " +
                                $"Salary: {toBeRemovedEmployees[enteredNumber - 1].Salary} has been removed from the list.");
                        }
                        else
                        {
                            employees.Remove(toBeRemovedEmployees[0]);

                            Console.WriteLine($"Employee Name: {toBeRemovedEmployees[0].Name}, Date of Birth: {toBeRemovedEmployees[0].DateOfBirth.ToString("MM/dd/yyyy")}, " +
                                $"Salary: {toBeRemovedEmployees[0].Salary} has been removed from the list.");
                        }
                        break;

                    case "Exit":

                        Console.WriteLine("Exiting the application. Goodbye! \nPress any key to confirm the exit.");

                        Console.ReadKey();

                        exit = true;

                        break;

                    default:

                        InvalidInputMessage();
                        break;
                };
            }

            void Result(List<Employee> sortedEmployees)
            {
                foreach (Employee e in sortedEmployees)
                {
                    Console.WriteLine($"Name: {e.Name}, Date of Birth: {e.DateOfBirth.ToString("MM/dd/yyyy")}," +
                            $" Salary: {e.Salary}");
                };
            }

            void DateOfBirthPropt()
            {
                Console.WriteLine("What is the date of birth of the new employee? Format options: 'MM/DD/YY', 'MM/DD/YYYY',\n" +
                            " 'Jan 01, 2019', 'MM.DD.YY', 'MM.DD.YYYY', 'MM-DD-YY', 'MM-DD-YYYY'.");
                enteredData = Console.ReadLine();
            }

            void OrderCategoryMessageAndResult(string sortingDirection, string category, List<Employee> sortedEmployees)
            {
                Console.WriteLine($"Sorting employees in a {sortingDirection} order by {category}: ");
                Result(sortedEmployees);
            }

            void SortingDirectionPrompt()
            {
                Console.WriteLine("Ascending or Descending?");

                sortingDirection = Console.ReadLine();
            }

            void CategoryPrompt(string command)
            {
                Console.WriteLine($"What category would you like to {command} by? Enter one of the options: Name, DateOfBirth, Salary");

                category = Console.ReadLine();
            }

            void NotFoundMessage(string category, string enteredData)
            {
                Console.WriteLine($"No employee with {category} of {enteredData} found in the list.");
            }

            void SortingDirectionError()
            {
                Console.WriteLine("I do not understand this command. Please, enter 'Ascending' or 'Descending'.");
            }

            void InvalidInputMessage()
            {
                Console.WriteLine("Error! Please, enter a valid input in a correct format.");
            }

            void FindByPrompt(string category)
            {
                Console.WriteLine($"Enter the employee {category}.");

                enteredData = Console.ReadLine();
            }

            void EmployeeCountCheck(List<Employee> foundEmployees)
            {
                if (foundEmployees.Count != 0)
                {
                    Result(foundEmployees);
                }
                else
                {
                    NotFoundMessage(category, enteredData);
                };
            }
        }
    }
}





