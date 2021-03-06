﻿using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region mod3_labs
            //// Creates StreamReader object called "streamReaderObject" 
            //// Assigns its value to null
            //StreamReader streamReaderObject = null;

            //try
            //{
            //    // Assigns "streamReaderObject" to read from a text file named "file1"
            //    streamReaderObject = new StreamReader("file1.txt");

            //    // Reads all characters from the current position to the end of the stream
            //    // Stores in String variable "contents"
            //    String contents = streamReaderObject.ReadToEnd();

            //    // Closes StreamReader
            //    streamReaderObject.Close();

            //    // Writes the amount of text elements in the text file to the Console
            //    Console.WriteLine("The file has {0} text elements.", new StringInfo(contents).LengthInTextElements);
            //}

            //// Code to handle any errors
            //catch (FileNotFoundException)
            //{
            //    // Informs user there is no file created
            //    Console.WriteLine("The file cannot be found.");
            //}
            //// Invoking the Dispose method in a finally block
            //// Note that code in finally block will always execute
            //finally
            //{
            //    // Checks if object is not null
            //    if (streamReaderObject != null)
            //        // Calls upon the Dispose method
            //        // Releases all resources used by the TextReader object
            //        streamReaderObject.Dispose();
            //}
            #endregion

            #region mod2_self_assess
            //see oop_mod1_assess
            #endregion

            #region mod2_labs
            //// Instantiates Employee Object with name Libby and salary 2000 called employee1
            ////var employee1 = new Employee("Libby", 2000);
            //var employee1 = new TechnicalEmployee("Libby");
            //// Instantiates TechnicalEmployee Object with name Zaynah called employee2
            //var employee2 = new TechnicalEmployee("Zaynah");
            //// Instantiates BusinessEmployee Object with name Winter called employee3
            //var employee3 = new BusinessEmployee("Winter");

            //// Output to the console window
            //Console.WriteLine(employee1.employeeStatus() + "..." + employee2.employeeStatus() + "..." + employee3.employeeStatus());
            #endregion

            #region inheritance demo
            ////see Employee & Manager classes below
            //Manager leadManager = new Manager();
            //leadManager.Department = "Warehouse";
            #endregion

            #region Anon class
            //var anon = new { Name = "Gerry", Age = 29 };
            //Console.WriteLine(anon.Name + anon.Age);
            #endregion

            #region oop_mod1_assess
            //var program1 = new UProgram("Information Technology");
            //var student1 = new Student();
            //var student2 = new Student();
            //var student3 = new Student();
            //var course1 = new Course("Programming with C#");
            //course1.AddStudent(student1);
            //course1.AddStudent(student2);
            //course1.AddStudent(student3);

            //var teacher1 = new Teacher();
            //course1.AddTeacher(teacher1);
            //var degree1 = new Degree("Bachelors");
            //degree1.AddCourse(course1);
            //program1.AddDegree(degree1);

            //Console.WriteLine("Program: {0}", program1.UProgramName);
            //Console.Write("Degree: ");
            //var deg_list = program1.GetDegreeList();
            //foreach (Degree deg in deg_list)
            //{
            //    Console.WriteLine(deg.DegreeName);
            //}
            //Console.Write("Course: ");
            //var courses_list = degree1.GetCoursesList();
            //foreach (Course course in courses_list)
            //{
            //    Console.WriteLine(course.CourseName);
            //}
            //Console.WriteLine("Student Count: {0}", Course.CountStudents());

            //Student myStudent = new Student();
            //Person myPerson = myStudent;
            #endregion

            #region OOP_mod1_labs 
            //// Instantiating an object of Car() Class by using Type Inference called Car1
            //var Car1 = new Car();

            //// Using dot notation to call members on Car1
            ////notice how get and set are using properties, not members
            ////Car1.Color = "White";
            ////Car1.Year = 2010;
            ////Car1.Mileage = 11000;

            //// Output to the console window
            ////Console.WriteLine($"This car is painted {Car1.Color}, was built in {Car1.Year}, and has {Car1.Mileage} miles on it.");

            //var Car2 = new Car("Red", 2008);

            //// Access static members
            //int carCount = Car.CountCars();

            //// Output to the console window
            //Console.WriteLine($"There are {carCount} cars on inventory right now.");
            #endregion

            #region instantiating a class
            //// Instantiating a Class
            //DrinksMachine dm = new DrinksMachine();

            //// Instantiating a Class by Using Type Inference
            //var dm2 = new DrinksMachine("Lounge", "Neat", "Cappo"); ;
            #endregion

            #region using_object_memebers
            //// Using Object Members
            //dm.Make = "Fourth Coffee";
            //dm.Model = "Beancrusher 3000";
            //dm.Age = 2;
            ////dm.MakeEspresso();
            #endregion

            #region using_properties
            //dm.Location = "Kitchen"; //references the property not the private variable _location
            //Console.WriteLine(dm.Location);
            #endregion

            #region using_static_classes
            ////using a static class
            //Console.WriteLine(Math.Pow(2, 8)); //don't instantiate, just call the method
            #endregion
        }

        public class DrinksMachine
        {
            // private member variables
            private string _location;
            private int age;
            private string make;
            private string model;

            //default constructor
            public DrinksMachine()
            {
                Age = 0;
            }

            //non-default constructor
            public DrinksMachine(string loc, string make, string model)
            {
                this.Location = loc; //recommended to use properties even in constructor
                this.Model = model;
                this.Make = make;
            }

            public int Age { get; set; }
                                 
            // public properties
            public string Make
            {
                get
                {
                    return make;
                }
                set
                {
                    make = value;
                }
            }

            // auto-implemented property
            public string Model { get; set; }
            //using refactor tool:
            public string Location { get => _location; set => _location = value; }

            // Constructors
            public DrinksMachine(int age)
            {
                this.Age = age;
            }
            public DrinksMachine(string make, string model)
            {
                this.Make = make;
                this.Model = model;
            }
            public DrinksMachine(int age, string make, string model)
            {
                this.Age = age;
                this.Make = make;
                this.Model = model;
            }
        }

        //abstract class Employee  //employee is abstract so cannot be instantiated
        //{
        //    private string empNumber;
        //    private string firstName;
        //    private string lastName;
        //    private string address;

        //    public string EmpNumber
        //    {
        //        get
        //        {
        //            return empNumber;
        //        }

        //        set
        //        {
        //            empNumber = value;
        //        }
        //    }

        //    public string FirstName
        //    {
        //        get
        //        {
        //            return firstName;
        //        }

        //        set
        //        {
        //            firstName = value;
        //        }
        //    }

        //    public string LastName
        //    {
        //        get
        //        {
        //            return lastName;
        //        }

        //        set
        //        {
        //            lastName = value;
        //        }
        //    }

        //    public string Address
        //    {
        //        get
        //        {
        //            return address;
        //        }

        //        set
        //        {
        //            address = value;
        //        }
        //    }
        //}
        //class Manager : Employee
        //{
        //    private char payRateIndicator;
        //    private Employee[] emps;
        //    private string department;

        //    public string Department
        //    {
        //        get { return department; }
        //        set { department = value; }
        //    }
        //}
    }
}
