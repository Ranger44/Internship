using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning_csharp
{
    class Degree
    {
        List<Course> course_list = new List<Course>();
        public string DegreeName { get; set; }
        private static int numStudents = 0;
        public static int CountStudents()
        {
            return numStudents;
        }

        public Degree(string degree_name)
        {
            this.DegreeName = degree_name;
        }
        public void AddCourse(Course c)
        {
            course_list.Add(c);
        }
        public List<Course> GetCoursesList()
        {
            return course_list;
        }
    }
}
