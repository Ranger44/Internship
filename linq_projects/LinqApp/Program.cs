using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var record = DataLoader.Load(@"C:\Users\westy\~holly\Documents\Internship\linq_projects");
            var femaleTop10 = record
                .Where(r => r.Gender == Gender.Female && r.Rank <= 10);
            var maleTop10 = from r in record
                            where r.Gender == Gender.Male && r.Rank <= 10
                            select r;
            foreach (var r in femaleTop10)
                System.Console.WriteLine(r);
            foreach (var r in maleTop10)
                System.Console.WriteLine(r);
        }
    }
}
