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

        public bool ValidDateOfBirth()
        {
            System.Type dateTime = typeof(DateTime);

            if (this.DateOfBirth.GetType()  == dateTime)
            {
                return true;
            }
            return true;
        }

        public bool ValidSalary()
        {
            System.Type integer = typeof(int);
            if (this.Salary.GetType() == integer)
            {
                return true;
            }
            return true;
        }
    }
}

