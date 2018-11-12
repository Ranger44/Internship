using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo_ds_labs
{
    class Student_Class
    {
        public Student_Class(string n, int y)
        {
            Name = n;
            Year = y;
        }
        private string name;
        private int year;

       public Stack<double> Grades = new Stack<double>();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Year {
            get { return year; }
            set { year = value; }
        }
    }
}
