using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning_csharp
{
    abstract class Employee
    {
        private string employeeName;
        private double employeeBaseSalary;
        private int employeeId;
        private static int employeeCount = 1;
        // Public properties
        public string Name
        {
            get { return employeeName; }
            set { employeeName = value; }
        }
        public double BaseSalary
        {
            get { return employeeBaseSalary; }
            set { employeeBaseSalary = value; }
        }
        public int ID
        {
            get { return employeeId; }
            set {employeeId = value; }
        }
        public Employee(String name, double baseSalary)
        {
            this.Name = name;
            this.BaseSalary = baseSalary;
            this.ID = employeeCount++;
        }
        public double getBaseSalary()
        {
            return this.BaseSalary;
        }
        public String getName()
        {
            return this.Name;
        }
        public int getEmployeeID()
        {
            return this.ID;
        }
        public String toString()
        {
            return this.ID + " " + this.Name;
        }
        //public virtual String employeeStatus()  //virtual since it is allowed to be overriden
        //{
        //    return toString() + " is in the company's system";
        //}
        public abstract String employeeStatus();

    }
}
