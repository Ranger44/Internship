using System;
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

            //int[] input = new int[] { 1, 3, 1, 1 };
            ////int[] ages = new int[] { 1, 2, 3, 4 };
            //Console.WriteLine(Average(input));

            //string input = "abcad";
            //Console.WriteLine(Reversal(input));

            //int[] input = new int[] { 2,1,4 };
            //Console.WriteLine(Ksmallest(input, 3));

            int[] input = new int[] { 3, 2, 9, 5 };
            Console.WriteLine(Difference(input));


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
