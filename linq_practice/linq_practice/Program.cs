using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // var record = DataLoader.Load(@"C:\Users\westy\~holly\Documents\Internship\linq_projects");
            // var femaleTop10 = record
            //     .Where(r => r.Gender == Gender.Female && r.Rank <= 10);
            // var maleTop10 = from r in record
            //                 where r.Gender == Gender.Male && r.Rank <= 10
            //                 select r;
            // foreach (var r in femaleTop10)
            //     System.Console.WriteLine(r);
            // foreach (var r in maleTop10)
            //     System.Console.WriteLine(r);

            var writer = new Writer
            {
                Name = "Timothy",
                Scope = ".NET Core",
                YearsOfExperience = 15
            };

            // writer.Introduce1();
            // writer.Introduce2();
            // writer.Introduce3();
            writer.Introduce1().Introduce2().Introduce3();
        }
    }

    public interface IWorker
    {
        string Name { get; set; }
        int YearsOfExperience { get; set; }
        string Scope { get; set; }
    }

    public class Writer : IWorker
    {
        public string Name { get; set; }
        public int YearsOfExperience { get; set; }
        public string Scope { get; set; }
        public void Write() { /*...*/ }
    }

    public class Teacher : IWorker
    {
        public string Name { get; set; }
        public int YearsOfExperience { get; set; }
        public string Scope { get; set; }
        public void Teach() { /*...*/ }
    }

    public static class IWorkerExtension
    {
        //public static void Introduce1(this IWorker worker)
        //{
        //    Console.WriteLine($"Hi, my name is {worker.Name}.");
        //}
        public static IWorker Introduce1(this IWorker worker)
        {
            Console.WriteLine($"Hi, my name is {worker.Name}.");
            return worker;
        }


        //public static void Introduce2(this IWorker worker)
        //{
        //    Console.WriteLine($"My major scope is {worker.Scope}.");
        //}
        public static IWorker Introduce2(this IWorker worker)
        {
            Console.WriteLine($"My major scope is {worker.Scope}.");
            return worker;
        }

        //public static void Introduce3(this IWorker worker)
        //{
        //    Console.WriteLine($"I have {worker.YearsOfExperience} years experience.");
        //}
        public static IWorker Introduce3(this IWorker worker)
        {
            Console.WriteLine($"I have {worker.YearsOfExperience} years experience.");
            return worker;
        }

    }
}
