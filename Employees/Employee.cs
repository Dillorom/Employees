using System;
using System.Collections.Generic;
using System.Text;

namespace Employees
{
    class Employee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Salary { get; set; }

        public bool ValidName()
        {
            return this.Name == "" ? false : true;
        }

        public bool ValidDateOfBirth()
        {
            System.Type dateTime = typeof(DateTime);

            return this.DateOfBirth.GetType() == dateTime ? true : false;
        }

        public bool ValidSalary()
        {
            System.Type integer = typeof(int);

            if (this.Salary == 0)
            {
                return false;
            }
            else if (this.Salary.GetType() == integer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

