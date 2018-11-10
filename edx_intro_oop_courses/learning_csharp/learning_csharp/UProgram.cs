using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning_csharp
{
    class UProgram
    {
        List<Degree> degree_list = new List<Degree>();
        public string UProgramName { get; set; }
        private static int numStudents = 0;
        public static int CountStudents()
        {
            return numStudents;
        }

        public UProgram(string uprogram_name)
        {
            this.UProgramName = uprogram_name;
        }

        public void AddDegree(Degree d)
        {
            degree_list.Add(d);
            numStudents++;
        }
        public List<Degree> GetDegreeList()
        {
            return degree_list;
        }
    }
}
