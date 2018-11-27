//EdX Data Quering Using LINQ and C#
LINQ = Language-Integreated Query
    - a set of technologies based on the integration of query capabilities directly into the .NET programming languages
    - simplifies the code of querying
        ex: get integers that appear in both arrays a1 and a2: var result = a1.Intersect(a2);
    - unifies the code of querying
        - can always use: WHERE, SELECT, MAX, MIN, SUM, COUNT, AVERAGE, INTERSECTION, EXCEPT, UNION, GROUPBY, ORDERBY, JOIN
    - can query the database with stringly-typed objects without writing SQL
        ex: writing SQL :
                var conn = new SqlConnection(connStr);
                conn.Open();
                var cmdText = "SELECT [Id],[Author],[Name],[Price] FROM [Bookstore].[dbo].[Book] WHERE Price < 60";
                var cmd = new SqlCommand(cmdText, conn);
                var reader = cmd.ExecuteReader();
                var names = new List<string>();
                while (reader.Read()) {
                    names.Add(reader["Name"].ToString());
                }
                conn.Close();
            using Entity Framework with LINQ:
                var names = _dbContext.Book.Where(b => b.Price < 60).Select(b => b.Name).ToList();
                
Writing LINQ queries
    2 syntaxes: (pick out values greater than 100 from int array)
        1. Standard
            var result = array.Where(n => n > 100);
        2. Query expression
            var result = from n in array select n;
            SQL = SELECT {result} FROM {source} WHERE {condition} 
            LINQ = from {variable} in {source} where {condition} select {result}
            
Fluent API
    public class Student {
        public void Greet(string name) {
            Console.WriteLine($"Hello, {name}!");
        }
    }
    var stu = new Student();
    stu.Greet("Timothy");
    stu.Greet("Tom");
    stu.Greet("Roman");
    
    //fluent
    public class Student {
        public Student Greet(string name) {
            Console.WriteLine($"Hello, {name}!");
            return this;
        }
    }
    new Student().Greet("Timothy").Greet("Tom").Greet("Roman");
    
Extension Methods
- attach methods to existing types
    ex: putting quotes around string even though .Quote is not a string method
    public static class StringExtension {
        public static string Quote(this string str) {
            return $"\"{str}\"";
        }
    }
    var original = "ABCDE";
    var quoted = original.Quote();
    Console.WriteLine(original);  //ABCDE
    Console.WriteLine(quoted);    //"ABCDE"
    - both the extension method and the host class must be static
- the first parameter of the extension method must be modified by this
    ex: rounding doubles even though .Double() is not a method of double
    using System;
    namespace Trimming {
        static class DoubleExtension {
            public static double Round(this double value, int digits) {
                return Math.Round(value, digits);
            }
        }

        class Program {
            static void Main(string[] args) {
                var d = 12.3456789;
                var r1 = d.Round(2);
                var r2 = d.Round(4);
                Console.WriteLine(d);
                Console.WriteLine(r1);
                Console.WriteLine(r2);
            }
        }
    }
    static class DoubleExtension {
        public static double Round(this double value, int digits) {
            return Math.Round(value, digits);
        }
    }
    var r1 = d.Round(2);  //2 parameters in declaration but only one argument used when calling
    var r2 = d.Round(4);
    
Extension Methods with Interfaces
- in order to attach Extension methods to multiple types
    ex:
       public interface IWorker {
            string Name { get; set; }
            int YearsOfExperience { get; set; }
            string Scope { get; set; }
        }

        public class Writer : IWorker {
            public string Name { get; set; }
            public int YearsOfExperience { get; set; }
            public string Scope { get; set; }
            public void Write() { /*...*/ }
        }

        public class Teacher : IWorker {
            public string Name { get; set; }
            public int YearsOfExperience { get; set; }
            public string Scope { get; set; }
            public void Teach() { /*...*/ }
        }
        //to attach a group of extension methods to the IWorker interface, create a static class to extend the IWorker interface
        public static class IWorkerExtension {
            public static void Introduce1(this IWorker worker) {
                Console.WriteLine($"Hi, my name is {worker.Name}.");
            }

            public static void Introduce2(this IWorker worker) {
                Console.WriteLine($"My major scope is {worker.Scope}.");
            }

            public static void Introduce3(this IWorker worker) {
                Console.WriteLine($"I have {worker.YearsOfExperience} years experience.");
            }
        }
        //after declaring the extension methods for IWorker
        static void Main(string[] args) {
            var writer = new Writer {
                Name = "Timothy",
                Scope = ".NET Core",
                YearsOfExperience = 15
            };

            writer.Introduce1();  //Hi, my name is Timothy.
            writer.Introduce2();  //My major scope is .NET Core.
            writer.Introduce3();  //I have 15 years experience.
        }
        
//Built in LINQ Extension Methods
using System;
using System.Linq;

namespace HelloLINQ {
    class Program {
        static void Main(string[] args) {
            int[] values = {100, 200, 300};
            var max  = values.Max();  //use LINQ method instead of for or foreach
            System.Console.WriteLine(max);
        }
    }
}

//Lambda Experessions
- anonymous functions are not intended to be reused so instead of polluting the namespace with:
    static void Main(string[] args) {
        Action action = SayHello;
        action();
    }
    static void SayHello() {
        Console.WriteLine("Hello, World!");
    }
    //you can write:
    static void Main(string[] args) {
        Action action = () => { Console.WriteLine("Hello, World"); };
        action();
    }
    
//FUNC delegates
Func<in T, out TResult> is one of the most commonly used delegate types with LINQ
    - declaration: public delegate TResult Func<in T, out TResult>(T arg);
    class Program {
        static void Main(string[] args) {
            Func<string, int> func = (s) => { return s.Length; };
            int x = func("Hello");
            Console.WriteLine(x);  //output = 5
        }
    }
    
//Creating .NET Core App
1. Create Project
    Option 1: Create Project Directly
        - Execute the following command from the cmd or PowerShell:
            cd C:\Projects
            dotnet new console --name LinqApp
        - then:
            cd LinqApp
            code .
            (or right click the project folder and Open with Code
            
    Option 2: Create Project Folder First
        - create LinqApp folder first.
        - right click then Open with Code
        - then click View -> Integrated Terminal
        - in the terminal panel, execute:
            dotnet new console
2. Run/Debug the App
    - once you open the LinqApp project, wait about 5 seconds for popup message "Required assets to build and debug are missing from 'LinqApp'...
        - click yes
    - click Debug -> Start Debugging or press F5
        - You should see the output: Hello World!
        
        
//Outside resources
https://msdn.microsoft.com/en-us/magazine/mt767698.aspx

https://www.tutorialspoint.com/linq/linq_asp.net.htm

https://weblogs.asp.net/scottgu/using-linq-to-sql-part-1

https://www.c-sharpcorner.com/UploadFile/de41d6/learning-linq-made-easy-linq-to-sql-tutorial-2/

https://medium.com/edgefund/c-development-with-visual-studio-code-b860cc71a5ec

//Filtering Operators (Where, OfType)
Where 
    - accepts Func<TSource, bool> type parameter
        static void Main(string[] args) {
            var records = DataLoader.Load(@"C:\Projects");
            var femaleTop10 = records
                .Where(r => r.Gender == Gender.Female && r.Rank <= 10);
            foreach (var r in femaleTop10)
                System.Console.WriteLine(r);
        }
        //r => r.Gender == Gender.Female && r.Rank <= 10 is equivalent to:
        bool Filter(Record r) {
            if (r.Gender == Gender.Female && r.Rank <= 10) {
                return true;
            } else {
                return false;
            }
        }
        //so we can write the LINQ query as:
        static void Main(string[] args) {
            var records = DataLoader.Load(@"C:\Projects");
            bool Filter(Record r) {
                return r.Gender == Gender.Female && r.Rank <= 10;
            }
            var femaleTop10 = records.Where(Filter);
            foreach (var r in femaleTop10)
                System.Console.WriteLine(r);
        }
        //or, SQL-like syntax
        static void Main(string[] args) {
            var records = DataLoader.Load(@"C:\Projects");
            var maleTop10 = from r in records
                            where r.Gender == Gender.Male && r.Rank <= 10
                            select r;
            foreach (var r in maleTop10)
                System.Console.WriteLine(r);
        }
        //remeber SQL = SELECT {result} FROM {source} WHERE {condition}
        //SQL-like LINQ = from {variable} in {source} where {condition} select {result}
OfType
        static void Main(string[] args) {
            var objects = new Object[] { 1, 10L, 1.1, 1.1f, "Hello", 2, 3 };  //elements in this Object[] have different types
            var result = objects.OfType<int>();  //objects.OfType<int>() helps us pick out all int type instances
            foreach (var item in result) {
                System.Console.WriteLine(item);
            }
        }
        
//Quantifier Operations (All, Any, Contains)
- none have SQL-like syntax
All
        - determines whether all elements in a collection satisfy a condition
        - accepts Func<TSourse, bool> type parameter as the condition
        //find out if all names are longer than three characters
        static void Main(string[] args) {
            var records = DataLoader.Load(@"C:\Projects");
            var result = records.All(r => r.Name.Length > 3);
            System.Console.WriteLine(result);  //outputs false
        }
        
Any
        - determines whether there is at least one element in the source collection thet satisfies the condition. 
        - The condition is also a Func<TSource, bool> type parameters
        //find out if there is any name longer than 15 characters:
        static void Main(string[] args) {
            var records = DataLoader.Load(@"C:\Projects");
            var result = records.Any(r => r.Name.Length > 15);
            System.Console.WriteLine(result);
        }
Contains
        - determines whether a collections contains a specified element
        static void Main(string[] args) {
            int[] integers = { 100, 200, 300, 400, 500 };
            string[] strings = { "Tim", "Tom", "Rina", "Andrew" };
            var result1 = integers.Contains(200);
            var result2 = strings.Contains("Tim");
            System.Console.WriteLine($"{result1} {result2}");
        }
        
//Set Operations
    Distinct - Keeps unique elements of the collection and removes duplicate elements
    Intersect - Returns the set intersection, which means elements that appear in each of two collections
    Except - Returns the set difference, which means the elements of one collection that do not appear in a second collection
    Union - Returns the set union, which means unique elements that appear in either of two collections
    static void Main(string[] args) {
        var records = DataLoader.Load(@"C:\Projects");
        int[] left = { 1, 1, 2, 3, 3, 4, 4 };
        int[] right = { 3, 4, 5, 6 };

        var distinctResult = left.Distinct();
        var intersectResult = left.Intersect(right);
        var exceptResult = left.Except(right);
        var unionResult = left.Union(right);

        Console.WriteLine($"Distinct: {string.Join(",", distinctResult)}"); // 1, 2, 3, 4
        Console.WriteLine($"Intersect: {string.Join(",", intersectResult)}"); // 3, 4
        Console.WriteLine($"Except: {string.Join(",", exceptResult)}"); // 1, 2
        Console.WriteLine($"Union: {string.Join(",", unionResult)}"); // 1, 2, 3, 4, 5, 6
    }
    
//Concatenation Operations
Concat
    static void Main(string[] args) {
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 3, 4, 5, 6, 7 };

            var concatResult = array1.Concat(array2); // 1,2,3,4,5,3,4,5,6,7
            var unionResult = array1.Union(array2); // 1,2,3,4,5,6,7

            System.Console.WriteLine($"Concat: {string.Join(",", concatResult)}");
            System.Console.WriteLine($"Union: {string.Join(",", unionResult)}");
        }
        
//Sorting Operations
        OrderBy - Sorts values in ascending order.
        ThenBy - Performs a secondary sort in ascending order.
        OrderByDescending - Sorts values in descending order.
        ThenByDescending - Performs a secondary sort in descending order.
        Reverse - Reverses the order of the elements in a collection. (no SQL-like syntax)
    - OrderBy
        static void Main(string[] args) {
            var records = DataLoader.Load(@"C:\Projects");
            var sortedByRank = records.OrderBy(r => r.Rank);
            foreach (var r in sortedByRank) {
                System.Console.WriteLine(r.ToString());
            }
        }
        //SQL-like
        static void Main(string[] args) {
            var records = DataLoader.Load(@"C:\Projects");
            var sortedByRank = from r in records orderby r.Rank select r;
            foreach (var r in sortedByRank) {
                System.Console.WriteLine(r.ToString());
            }
        }
    - OrderByDescending
        static void Main(string[] args) {
            var records = DataLoader.Load(@"C:\Projects");
            var sortedByRank = records.OrderByDescending(r => r.Rank);
            foreach (var r in sortedByRank) {
                System.Console.WriteLine(r.ToString());
            }
        }
        //SQL-like
        static void Main(string[] args) {
            var records = DataLoader.Load(@"C:\Projects");
            var sortedByRank = from r in records orderby r.Rank descending select r;
            foreach (var r in sortedByRank) {
                System.Console.WriteLine(r.ToString());
            }
        }
    - ThenBy
        static void Main(string[] args) {
            var records = DataLoader.Load(@"C:\Projects");
            var sortedByRank = records.OrderBy(r => r.Rank).ThenBy(r => r.Name);
            foreach (var r in sortedByRank) {
                System.Console.WriteLine(r.ToString());
            }
        }
        //SQL-like:
        static void Main(string[] args) {
            var records = DataLoader.Load(@"C:\Projects");
            var sortedByRank = from r in records orderby r.Rank, r.Name select r;
            foreach (var r in sortedByRank) {
                System.Console.WriteLine(r.ToString());
            }
        }
    - ThenByDescending
        var sortedByRank = records.OrderBy(r=>r.Rank).ThenByDescending(r=>r.Name);
        var sortedByRank = from r in records orderby r.Rank, r.Name descending select r;
    - Reverse
        - doesn't sort just generates new collection with elements reversed compared to original
        static void Main(string[] args) {
            var records = DataLoader.Load(@"C:\Projects");
            int[] original = { 1979, 10, 31, 8, 15 };
            var reversed = original.Reverse();
            System.Console.WriteLine($"Original: {string.Join(",", original)}");  //1979, 10, 31, 8, 15
            System.Console.WriteLine($"Reversed: {string.Join(",", reversed)}");  //15,8,31,10,1979
        }
//Projection Operations (Select, SelectMany)
    - Select
        - Project values that are based on a transform function
        - called "mapping" in other languages
        static void Main(string[] args) {
            var records = DataLoader.Load(@"C:\Projects");
            var names = records.Select(r => r.Name);  //picks only the name property from each record then puts in new collection
            foreach (var n in names) {
                System.Console.WriteLine(n);
            }
        }
        //SQL-like
        static void Main(string[] args) {
            var records = DataLoader.Load(@"C:\Projects");
            var names = from r in records select r.Name;
            foreach (var n in names) {
                System.Console.WriteLine(n);
            }
        }
        - select multiple element property values
            class RankAndName {
                public int Rank { get; set; }
                public string Name { get; set; }
            }
            ...
            var records = DataLoader.Load(@"C:\Projects");
            var items = records.Select(r => new RankAndName { Rank = r.Rank, Name = r.Name });
            foreach (var item in items) {
                System.Console.WriteLine($"Rank:{item.Rank} Name:{item.Name}");
            }
            
    - SelectMany
        - Projects sequences of values that are based on a transform function and then flattens them into one sequence
        
//Single element operations
        ElementAt	Returns the element at a specified index in a collection.
        ElementAtOrDefault	Returns the element at a specified index in a collection or a default value if the index is out of range.
        First	Returns the first element of a collection, or the first element that satisfies a condition.
        FirstOrDefault	Returns the first element of a collection, or the first element that satisfies a condition. Returns a default value if no such element exists.
        Last	Returns the last element of a collection, or the last element that satisfies a condition.
        LastOrDefault	Returns the last element of a collection, or the last element that satisfies a condition. Returns a default value if no such element exists.
        Single	Returns the only element of a collection, or the only element that satisfies a condition.
        SingleOrDefault	Returns the only element of a collection, or the only element that satisfies a condition. Returns a default value if no such element exists or the collection does not contain exactly one element.
        
//Partitioning Operations
        Skip - Skips elements up to a specified position in the source collection.
        Take - Takes elements up to a specified position in the source collection.
        TakeLast - Takes the specified number of elements at the tail of the source collection.
        SkipWhile - Skips elements until an element does not satisfy the condition.
        TakeWhile - Takes elements until an element does not satisfy the condition.
    static void Main(string[] args) {
        string[] source = { "A1", "A2", "B1", "B2", "C1", "C2" };
        var r1 = source.Take(3);  //A1,A2,B1
        var r2 = source.Take(100);  //A1,A2,B1,B2,C1,C2
        var r3 = source.Skip(2);  //B1,B2,C1,C2
        var r4 = source.Skip(100);
        var r5 = source.Skip(2).Take(2);  //B1,B2
        var r6 = source.TakeLast(2);  //C1,C2
        var r7 = source.TakeLast(100);  //A1,A2,B1,B2,C1,C2

        Console.WriteLine(String.Join(",", r1));
        Console.WriteLine(String.Join(",", r2));
        Console.WriteLine(String.Join(",", r3));
        Console.WriteLine(String.Join(",", r4));
        Console.WriteLine(String.Join(",", r5));
        Console.WriteLine(String.Join(",", r6));
        Console.WriteLine(String.Join(",", r7));
    }
    static void Main(string[] args) {
        string[] source = { "A1", "B1", "C1", "A2", "B2", "C2" };
        var r1 = source.TakeWhile(e => e.StartsWith("A")); //A1
        var r2 = source.TakeWhile(e => !e.StartsWith("C"));  //A1, B1
        var r3 = source.TakeWhile(e => e.StartsWith("C"));
        var r4 = source.SkipWhile(e => e.StartsWith("A"));  //B1,C1,A2,B2,C2
        var r5 = source.SkipWhile(e => !e.StartsWith("C"));  //C1,A2,B2,C2
        var r6 = source.SkipWhile(e => e.StartsWith("C"));  //A1,B1,C1,A2,B2,C2

        Console.WriteLine(String.Join(",", r1));
        Console.WriteLine(String.Join(",", r2));
        Console.WriteLine(String.Join(",", r3));
        Console.WriteLine(String.Join(",", r4));
        Console.WriteLine(String.Join(",", r5));
        Console.WriteLine(String.Join(",", r6));
    }
    
//Generation Operations
        Repeat - Generates a collection that contains one repeated value.
        Range - Generates a collection that contains a sequence of numbers.
        Empty - Returns an empty collection.
        DefaultIfEmpty - Replaces an empty collection with a default valued singleton collection
    - Repeat and Range
        static void Main(string[] args) {
            var r1 = Enumerable.Repeat("Hello", 5);  //Hello,Hello,Hello,Hello,Hello
            var r2 = Enumerable.Range(0, 10);  //0,1,2,3,4,5,6,7,8,9
            var r3 = Enumerable.Range(0, 10).Select(e => Math.Pow(2, e));  //1,2,4,8,16,32,64,128,256,512
            var r4 = Enumerable.Range('A', 26).Select(e => (char)e);  //A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z

            Console.WriteLine(String.Join(",", r1));
            Console.WriteLine(String.Join(",", r2));
            Console.WriteLine(String.Join(",", r3));
            Console.WriteLine(String.Join(",", r4));
        }
    - Empty
        - can be used to generate an empty collection instead of using new operator to create a List instance
    - DefaultIfEmpty
        - will put a specified default value to a collection, if the collectio nis empty
                static void Main(string[] args) {
                    var defaultGift = "Programming Books";
                    string[] wishlist = { "Toy Car", "Video Games", "Skateboard" };
                    string[] storeInventory = { "Computer", "Candy", "Flowers" };
                    var iGot = wishlist.Intersect(storeInventory).DefaultIfEmpty(defaultGift);

                    foreach (var gift in iGot) {
                        System.Console.WriteLine(gift);
                    }
                }
                
//Data Types Conversion Operators
    - Cast
        var arrayList = new ArrayList() { 100, 200, 300, 400 };
        var nums = arrayList.Cast<int>();
        System.Console.WriteLine(nums is IEnumerable<int>);  //true
        System.Console.WriteLine(String.Join(",", nums));  //100,200,300,400
    - ToList, ToArray, ToHashSet, ToDictionary and ToLookup
        var records = DataLoader.Load(@"C:\Projects");
        var maleTop100 = records
            .Where(r => r.Rank <= 100 && r.Gender == Gender.Male);
        var list = maleTop100.ToList();
        var array = maleTop100.ToArray();
        var set = maleTop100.ToHashSet();
        var dict = maleTop100.ToDictionary(r => r.Name, r => r.Rank);
        var lookup = maleTop100.ToLookup(r => (r.Rank - 1) / 10, r => r.Name);

        // Check collection type
        System.Console.WriteLine(maleTop100.GetType());
        System.Console.WriteLine(list.GetType());
        System.Console.WriteLine(array.GetType());
        System.Console.WriteLine(set.GetType());
        System.Console.WriteLine(dict.GetType());
        System.Console.WriteLine(lookup.GetType());
        System.Console.WriteLine(lookup.First().GetType());

        System.Console.WriteLine("=======================");

        // Check values
        System.Console.WriteLine(dict["Timothy"]);
        System.Console.WriteLine(String.Join(",", lookup[0]));
        
//Equality Operations
    - SequenceEqual
        var array = new int[] { 0, 1, 2, 3, 4, 5 };
        var list = new List<int> { 0, 1, 2, 3, 4, 5 };
        var set = new HashSet<int> { 0, 1, 2, 3, 3, 2, 1, 4, 5 };
        var r1 = array.SequenceEqual(list);
        var r2 = array.SequenceEqual(set);
        System.Console.WriteLine(r1);  //True
        System.Console.WriteLine(r2);  //True
        
//Aggregation Operations