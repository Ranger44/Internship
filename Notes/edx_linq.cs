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
        
        
//ASP.NET
https://msdn.microsoft.com/en-us/magazine/mt767698.aspx
https://www.tutorialspoint.com/linq/linq_asp.net.htm