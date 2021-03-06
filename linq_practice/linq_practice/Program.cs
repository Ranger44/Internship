﻿using System;
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
            //writer.Introduce1().Introduce2().Introduce3();

            //double CylinderVolume(double h, double r) { return Math.PI * r * r * h; }
            //Console.WriteLine(CylinderVolume(2.2, 1.1));

            //Func<double, double, double> func1 = (double h, double r) => { return Math.PI * r * r * h; };
            //Console.WriteLine(func1(2.2, 1.1));

            //Func<double, double, double> func2 = (h, r) => { return Math.PI * r * r * h; };
            //Console.WriteLine(func2(2.2, 1.1));

            //Func<double, double, double> func3 = (h, r) => { Math.PI* r *r * h };

            //var nums = Enumerable.Range(0, 100).Reverse();
            //var nums2 = Enumerable.Range(0, 100).OrderByDescending(n => n);
            //Console.WriteLine(String.Join(",",nums));
            //Console.WriteLine(String.Join(",", nums2));
            //var nums3 = Enumerable.Range(0, 99).Reverse();
            //var nums4 = Enumerable.Range(0, 99).OrderByDescending(n => n);
            //Console.WriteLine(String.Join(",", nums3));
            //Console.WriteLine(String.Join(",", nums4));

            int[] source = { 1, 2, 3, 4, 5 };
            var a = source.Average();
            var b = source.Sum() / source.Count();
            var c = source.Sum() / source.LongCount();
            var d = source.Sum() / source.Length;
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
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
