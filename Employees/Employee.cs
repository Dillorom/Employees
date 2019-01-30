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
            else
            {
                return false;
            }
        }

        public bool ValidSalary()
        {
            System.Type integer = typeof(int);
  
            if (this.Salary.GetType() == integer)
            {
                return true;
            }
            else if (this.Salary == 0)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}

