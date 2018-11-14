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