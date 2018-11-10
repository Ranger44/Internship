using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning_csharp
{
    class Course
    {
        List<Student> students_list = new List<Student>();
        List<Teacher> teacher_list = new List<Teacher>();
        public string CourseName { get; set; }
        private static int numStudents = 0;
        public static int CountStudents()
        {
            return numStudents;
        }

        public Course(string course_name)
        {
            this.CourseName = course_name;
        }

        public void AddStudent(Student s)
        {
            students_list.Add(s);
            numStudents++;
        }
        public void AddTeacher(Teacher t)
        {
            teacher_list.Add(t);
        }

    }
}
