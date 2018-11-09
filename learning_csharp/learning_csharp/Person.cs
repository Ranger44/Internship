using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning_csharp
{
    abstract class Person
    {
        private String name;

        public String Name
        {
            get { return name;  }
            set { name = value; }
        }
    }
}
