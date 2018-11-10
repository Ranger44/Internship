using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning_csharp
{
    class BusinessEmployee : Employee
    {
        public double bonusBudget = 1000;
        public BusinessEmployee(String name) : base(name, 50000)
        {
        }
        public override String employeeStatus()
        {
            return toString() + " with a budget of " + this.bonusBudget;
        }

    }
}
