using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo_ds_labs
{
    class Program
    {
        enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat };
        static void Main(string[] args)
        {
            #region car_lab1
            //Car myCar = new Car();
            //myCar.Make = "Nissan";
            //myCar.Model = "Murano";
            //myCar.Color = "White";

            //Console.WriteLine($"My car is a {myCar.Make} {myCar.Model} that is {myCar.Color} in color");
            //myCar.Accelerate();
            #endregion

            #region days_enum_lab2
            //int x = (int)Days.Sun;
            //int y = (int)Days.Fri;
            //Console.WriteLine("Sun = {0}", x);  //prints Sun = 0
            //Console.WriteLine("Fri = {0}", y);
            //Console.WriteLine(Days.Thu); //prints Thu
            #endregion

            #region array_lab3
            //int[] numbers = new int[5];

            //numbers[0] = 2;
            //numbers[1] = 5;
            //numbers[2] = 9;
            //numbers[3] = 6;
            //numbers[4] = 7;

            //Console.WriteLine(numbers[0]);
            //Console.WriteLine(numbers[3]);
            //Console.WriteLine(numbers[2]);

            //int total = 0;
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    total = total + numbers[i];
            //}
            //Console.WriteLine(total.ToString());

            //int forEachTotal = 0;
            //foreach (int num in numbers)
            //{
            //    forEachTotal = forEachTotal + num;
            //}
            //Console.WriteLine(forEachTotal);
            #endregion

            #region mod2_self_assess
            //Student[] students = new Student[5];
            //students[0].Name = "Wimbly";

            //Console.Write($"{students[0].Name} is ");
            //students[0].Study();

            //Student[] studArray = new Student[5];

            //Student stud1 = new Student();

            //studArray.Add(stud1);

            #endregion

            #region data_structures_activities
            //int[] input = new int[] { 1, 3, 1, 1 };
            ////int[] ages = new int[] { 1, 2, 3, 4 };
            //Console.WriteLine(Average(input));

            //string input = "abcad";
            //Console.WriteLine(Reversal(input));

            //int[] input = new int[] { 2,1,4 };
            //Console.WriteLine(Ksmallest(input, 3));

            //int[] input = new int[] { 3, 2, 9, 5 };
            //Console.WriteLine(Difference(input));
            #endregion

            #region collections_labs
            //ArrayList myArrList = new ArrayList();  //no need to specify size or data type at declaration
            //myArrList.Add("First Item");
            //myArrList.Add("Third Item");
            //myArrList.Add("Second Item");
            //myArrList.Add(3);
            // myArrList.Add(4.5);
            //foreach (object obj in myArrList)
            //{
            //    Console.WriteLine(obj.ToString());
            //}
            //myArrList.Sort();
            //int itemIndex = myArrList.IndexOf("Third Item"); //will return index of item, if found
            //foreach (object obj in myArrList)
            //{
            //    Console.WriteLine(obj.ToString());
            //}
            //Console.WriteLine();
            //Console.WriteLine($"Third Item is at index {itemIndex}.");


            //// Create a new hash table.
            //Hashtable openWith = new Hashtable();      
            //// Add some elements to the hash table. There are no 
            //// duplicate keys, but some of the values are duplicates.
            //openWith.Add("txt", "notepad.exe");
            //openWith.Add("bmp", "paint.exe");
            //openWith.Add("dib", "paint.exe");
            //openWith.Add("rtf", "wordpad.exe");
            //// The Add method throws an exception if the new key is 
            //// already in the hash table.
            ////try
            ////{
            ////    openWith.Add("txt", "winword.exe");
            ////}
            ////catch
            ////{
            ////    Console.WriteLine("An element with Key = \"txt\" already exists.");
            ////}
            //// The Item property is the default property, so you can omit its name when accessing elements. 
            //Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);
            //// The default Item property can be used to change the value associated with a key.
            //openWith["rtf"] = "winword.exe";
            //Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);
            //// If a key does not exist, setting the default Item property for that key adds a new key/value pair.
            //openWith["doc"] = "winword.exe";
            //// ContainsKey can be used to test keys before inserting them.
            //if (!openWith.ContainsKey("ht"))
            //{
            //    openWith.Add("ht", "hypertrm.exe");
            //    Console.WriteLine("Value added for key = \"ht\": {0}", openWith["ht"]);
            //}
            //// When you use foreach to enumerate hash table elements, the elements are retrieved as KeyValuePair objects.
            //Console.WriteLine();
            //foreach (DictionaryEntry de in openWith)
            //{
            //    Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            //}


            #endregion

            #region collections_self_assess
            //ArrayList studentArr = new ArrayList();

            //Student_Class student1 = new Student_Class("Billy", 1);
            //Student_Class student2 = new Student_Class("Connor", 3);
            //Student_Class student3 = new Student_Class("Isobel", 2);

            //student1.Grades.Push(95.5);
            //student1.Grades.Push(85.5);
            //student1.Grades.Push(75.5);
            //student1.Grades.Push(65.5);
            //student1.Grades.Push(55.5);

            //student2.Grades.Push(95.0);
            //student2.Grades.Push(98.0);
            //student2.Grades.Push(85.0);
            //student2.Grades.Push(90.0);
            //student2.Grades.Push(88.0);

            //student3.Grades.Push(98.8);
            //student3.Grades.Push(88.8);
            //student3.Grades.Push(78.8);
            //student3.Grades.Push(98.2);
            //student3.Grades.Push(90.8);

            //studentArr.Add(student1);
            //studentArr.Add(student2);
            //studentArr.Add(student3);

            #endregion

            #region generic_lab
            //// Create a Generic List of type Student
            List<Student_generic> students = new List<Student_generic>();
            Student_generic stud1 = new Student_generic("Tom", "Thumb", 12, "Computer Science");
            Student_generic stud2 = new Student_generic("Fred", "Flintstone", 45, "Geology");
            Student_generic stud3 = new Student_generic("Mickey", "Mouse", 35, "Animation");
            stud1.Grades.Push(95.5);
            stud1.Grades.Push(85.5);
            stud1.Grades.Push(75.5);
            stud1.Grades.Push(65.5);
            stud1.Grades.Push(55.5);

            stud2.Grades.Push(95.0);
            stud2.Grades.Push(98.0);
            stud2.Grades.Push(85.0);
            stud2.Grades.Push(90.0);
            stud2.Grades.Push(88.0);

            stud3.Grades.Push(98.8);
            stud3.Grades.Push(88.8);
            stud3.Grades.Push(78.8);
            stud3.Grades.Push(98.2);
            stud3.Grades.Push(90.8);

            students.Add(stud1);
            students.Add(stud2);
            students.Add(stud3);

            stud1.Grades.Pop();
            stud1.Grades.Push(100);
            stud2.Grades.Pop();
            stud2.Grades.Push(100);
            stud3.Grades.Pop();
            stud3.Grades.Push(100);


            foreach (Student_generic stud in students)
            {
                Console.WriteLine($"First name: {stud.FirstName}  Last Name: {stud.LastName}");
            }

            //bool exists = students.Contains<Student_generic>(stud1);
            //Console.WriteLine(exists.ToString());

            //students.Remove(stud3);
            //Console.WriteLine(students.Count());
            #endregion


        }
        public static int Average(int[] a)
        {
            int length = a.Length;
            double total = 0;
            double average = 0.0;
            foreach (int num in a)
            {
                total = total + num;
            }
            average = Math.Round(total / length);
            return (int)average;
        }

        public static string Reversal(string s)
        {
            char[] charArray = new char[s.Length];
            charArray[0] = s[0];
            charArray[s.Length - 1] = s[s.Length - 1];
            int i = 1;
            int j = s.Length - 2;
            while (i < (s.Length - 1) / 2)
            {
                while (j < (s.Length - 1))
                {
                    if(i == j)
                    {
                        charArray[i] = s[i];
                        break;
                    }
                    charArray[i] = s[j];
                    charArray[j] = s[i];
                    i++;
                    j--;
                }
            }
            string newS = new string(charArray);
            //Console.WriteLine(newS);
            return newS;
        }

        public static int Ksmallest(int[] a, int k)
        {
            int smallest = 0;
            int counter = 0;

            Array.Sort(a);

            for(int i = 0; i < a.Length; i++)
            {
                if(a[i] > smallest)
                {
                    smallest = a[i];
                    counter++;
                }
                
                if(counter == k)
                {
                    break;
                }
                
            }
            return smallest;
        }

        public static int Difference(int[] a)
        {
            int diff = 0;
            Array.Sort(a);
            diff = a[a.Length - 1] - a[0];

            return diff;
        }
    }



    struct Student
    {
        public string Name;

        public void Study()
        {
            Console.WriteLine("studying");
        }
    }
    struct Teacher
    {
        public string Name;

        public void GradeAssignments()
        {
            Console.WriteLine("grading");
        }
    }
    struct Car
    {
        public string Make;
        public string Model;
        public string Color;

        public void Accelerate()
        {
            Console.WriteLine("Vroom");
        }
    }
}
