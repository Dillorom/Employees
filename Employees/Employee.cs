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
    }
}

