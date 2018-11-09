.NET Academy Course
Day 1 - C# Tutorial in .NET Academy
    Taking notes on what seems new or different from C/C++
    .NET Academy Tutorials and practice:
        -Intro to C# Beginner Course
        -Hello World
        -Using the Console
Day 2 - C# Tutotorial in .NET Academy:
        -Repeated day one activities
        -Variables and Standard Types
Day 3 - C# Tutorial in .NET Academy and some outside C# research and practice using properties and get/set accessors:
        -Classes
        -Inheritance
        -Visibility and Accessibilty Modifiers
Day 4 - C# Review and outside tutorials
        - Running on VS for the first time
Day 5 - Review classes
        - inheritance, modifiers
        
//Learning C#
//directives:
using System; //namespace

//a class is a logical grouping of methods and properties 
public class Person {
    //default constructor
    public Person(string firstName, string lastName) {
        FirstName = firstName;
        LastName = lastName;
    }   
    public string FirstName{  //FirstName property
        get {return firstName;}  //get accessor must return a value of the property type
        set {firstName = value;} //set accessor has implicit parameter called value whose type is the type of the property; no return
    }
    public string LastName { get; set; } //auto property - see Age for meaning
    public int Age (   //same at auto property
        get {
            return this.age;
        }    
        set {
            this.age = value;
        }
}
    public DateTime DateOfBirth { get; set; }
    
    public string GetFullName() {
        return FirstName + " " + LastName;
    }
    public int GetYearOfBirth() {
        return DateTime.Now.AddYears(-Age).Year;
    }
    
}

public class Program //note Program is a class which encapsulates Main method
{
    public static void Main() { //main is the starting point of the porgram/application Entry Point
    //make sure Main is capitalized
        //write string without add line-terminator
        Console.Write("something");
        //add newline
        Console.Write(Environment.NewLine);
        //write string with line-terminator
        Console.WriteLine("Hello World"); //or System.Console.WriteLine() if namespace not declared
        
        string response = Console.ReadLine(); //ReadLine reads until it finds a new line, carraige return, or end of input
        Console.WriteLine("You said: " + response);
        string upperResponse = response.ToUpper();
        
        int value; //auto initialized to 0, or default(int)
        value = Console.Read(); //returns ASCII representation of the character entered
        Console.Write("You typed: " + (char)value); //cast to convert int into char
        Console.WriteLine("Largest int available: " + int.MaxValue);
        
        //explicitly state what a variable instead of using specific type name, compiler will infer each type
        var one = 1;
        var two = "two";
        //use for anonymous types
        var person = new { Name = "John Smith" };
        
        DateTime today = DateTime.Now;
        //declare an instance of the Person class
        Person person = new Person("John", "Smith");  //using type Person from Person class; new Person() uses default constructor
        person.Age = 30; //set accessor invoked here
        Method1(person);
        Console.WriteLine(person.GetFullName());
        
        //print formatted string
        int x = 10;
        double y = 20.0;
        Console.WriteLine("x = {0}; y = {1}", x, y);
        
        string yourName;
        Console.WriteLine("What is your name?");
        yourName = Console.ReadLine();
        Console.WriteLine("Hello {0}", yourName);
        
        //ReadLine returns a string; must cast if wanting a different type
        int age = Convert.ToInt32(Console.ReadLine()); //this will fail if a non-int is entered
        Console.WriteLine("You are {0} years old", age);
        //another conversion
        double n;
         string x = "77";
        n = Convert.ToDouble(x);
        
        //increment while loop from within condition
        int num = 0;
        while(++num < 6) //will execute 5 times... while(num++ < 6) will execute 6 times
            Console.WriteLine(num);
    }
    public static void Method1(Person person){
		person.Age = 40;
	}
}

//INHERITANCE
//a mechanism by which one class can inherit from another class, allowing it to re-use members, common code, and behaviors
//provided by the base class

using System;
//Animal is base class or "super"
public class Animal
{
    public void Eat()
    {
        Console.WriteLine("Eating");    
    }
}
//Dog inherits from Animal class; it is the derived class, "subclass", or child class
public class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Woof woof!");    
    }
}

public class Program  //equivalent to public class Program : Object since 
{
    public static void Main()
    {
        //System.Object is the root of the inheritance hierarchy tree
        Object root = new Object();
        Console.WriteLine(root.ToString()); //will print: System.Object
        
        var dog = new Dog();

        dog.Eat(); // Declared by Animal
        dog.Bark();  // Declared by Dog

        // ToString declared by Object
        Console.WriteLine(dog.ToString());
    }   
}

//Inheritance Constructors
using System;

public class Message
{
    public Message(string header) //Message type has a constructor
    {
        Header = header;
    }

    public string Header { get; set; }

    public string Content { get; set; }

    public void Send()
    {
        Console.WriteLine(Header);
        Console.WriteLine(Content); 
    }
}

public class Email : Message
{
    public Email() : base("Email") { }  //base notation calls constructor with string argument
}

public class Program
{
    public static void Main()
    {
        var email = new Email();
        email.Send();
    }
}

//ABSTRACT keyword
using System;

// Implement your classes here
public abstract class SpaceStation {  //1. can apply to class declaration itself; This means that the class MUST BE INHERITED/cannot be instantiated by itself
{
	public abstract void FireLaser();	//2. or can apply to type members; means that the derived type MUST IMPLEMENT THAT MEMBER!
}

public class DeathStar : SpaceStation {
	public override void FireLaser() {
		Console.WriteLine("Pew pew");
	}
}

public class Program
{
	public static void Main()
	{
		var ship = new DeathStar();
		ship.FireLaser();
	}
}

//VIRUAL keyword
//allow you to provide a default implementation of your property on your base class that can optionally be overriden on your derived class. 
//It is similar to the abstract keywords, but carries optional semantics instead of required semantics
using System;

public abstract class Astrodroid {
	public virtual string GetSound() {
		return "Beep beep";
	}
	public void MakeSound() {
		Console.WriteLine(GetSound());
	}
}

public class R2 : Astrodroid {
	public override string GetSound() {
		return "Beep bop";	
	}
}

public class Program
{
	public static void Main()
	{

	}
}

//VISIBILTY AND ACCESSIBILITY MODIFIERS

//public - can be called form external callers

//private used to restrict access to type members, or can be applied to nested classes (cannot be applied
    //to classes unless they are nested
    //default modifier whne acess modifier is omitted
    //in context of type - no external callers outside of the parent public class that declares the type has access
    //in context of type member - no external callers (including those in the same program assembly will be able to access the type member
        //only accessible from the type in which the member is declared
        public class Person
        {
            private Person()
            {
                // Private constructor; external callers cannot create instances of the Person class
            }
        }
        
//protected - used in inheritance scenarios. The protexted modifier marks a types member as availbable only in the type which it is declared
    //or in any type that inherits from it.
    using System;
					
    public class Animal
    {
        // This protected constructor means that only inherited callers
        // create instances of Animal
        protected Animal()
        {

        }        
        protected string GetSound() //GetSound() can only be called from the Animal or Dog class
        {
            return "Woof!";
        }
    }

    public class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine(GetSound());    
        }   
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var dog = new Dog();
            dog.Bark();
        }
    }
    
//internal code can only be accessed from your own code
using System;
					
public class Candidate
{
	internal int Order { get; set; }
}

public class Program
{
	public static void Main()
	{
		var candidate = new Candidate();
		candidate.Order = 1;
	}
}

//static - static class cannot be instantiated
// The Application class is marked as static...
public static class Application
{
    // .. So all members have to also be static.
    public static string Name { get; set; }
}

// A non static class
public class Student
{
    // Can still have static members.
    public static string GetSchool()
    {
        return "MIT";   
    }
}

public class Program
{
    public static void Main()
    {
        // Use the type name to access static members of the class.
        Application.Name = "Program";
		
		Console.WriteLine(Application.Name);
    }   
}

//abstract - forces a class to be inherited; an abstract class cannot be instantiated
    //- when applied to a type member - enforces anything that inherits from the class to implement the abstract member
    
//COLLECTIONS
//Arrays
        string[] names = new string[5];
        names[0] = "Luke";
        names[1] = "Leia";
        names[2] = "Han";
        names[3] = "Yoda";
        names[4] = "Chewbacca";

        for (int i = 0; i < names.Length; i++)  //get array Length
        {
            Console.WriteLine(names[i]);  
        }
        
        int[] ages = new int[] { 1, 2, 3, 4 };
        
//Lists  **most popular collection**
//essential an array with additional methods to support adding, removing and resizing
//untyped System.Collections.List and the generic System.Collections.Generic.List<T>
        List<string> names = new List<string>();
        names.Add("Luke");
        names.Add("Leia");
        names.Add("Han");
        names.Add("Yoda");
        names.Add("Chewbacca");

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
        
        List<int> ages = new List<int> { 1, 2, 3, 4 };
        var droids = new List<Droid>();
        List<DateTime> datesOfBirth = new List<DateTime>();
    //add new value
    list.Add("new value");
    
    //insert items into specific index
    names.Insert(0, "Darth");
    
    //reading and replacing existing values
    string name = names[0];
    names[0] = "Han";   
    
    //removing values
    names.Remove("Han");
    names.RemoveAt(0);
    
    //Find index
    int index = names.FindIndex("Han");
    if (index >= 0)
    {
        names.RemoveAt(0);
    }
    
    //Iterating through a list'
    foreach (<type> <identifier> in <expression>)
    <body>
    
    for (int i = 0; i < names.Count; i++) //Count of number of items stored in list (which is less than the length)
    {
        Console.WriteLine(names[i]);   
    }
    
    using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<string> characters = new List<string>();
        
        characters.Add("Chewbacca");
		string name = characters[0];
		Console.WriteLine(name);
    }
}
        
        
//DICTIONARIES
//able to specify key and value types
//able to refer to item through key
//can declare with 2 generic types (below) or 1 like : var droids = new Dictionary<string, Droid>();
    Dictionary<string, bool> people = new Dictionary<string, bool>();
    people.Add("Luke", true);
    people.Add("Leia", false);
    people.Add("Han", false);
    people.Add("Yoday", true);
    people.Add("Chewbacca", false);

    foreach (KeyValuePair<string, bool> pair in people)
    {
        // A KeyValuePair provides the string as the Key property
        // and the bool as the Value property.

        if (pair.Value)
        {
            Console.WriteLine(pair.Key + " is a Jedi");
        }
        else
        {
            Console.WriteLine(pair.Key + " is not a Jedi");
        }
    }
//can initialize during declaration
    Dictionary<string, int> ages = new Dictionary<string, int> { { "Luke", 53 }, { "Leia", 53 } };
//under the hood - uses a hash table
//READ value:
people["Holly"];
//ADD dictionary values
 droids.Add("R2 D2", new Droid());  //will throw an argument exception if key already exists
 OR
 droids["R2 D2"] = new Droid();  //allows you to replace an existing item
 //REMOVE values
 droids.Remove("R2 D2");  //will return a boolean value indicating if value was removed
 //Iterating through a dictionary
 foreach (var pair in droids) {
    Console.WriteLine("Found: " + pair.Value + ", with key: " + pair.Key);
 }
 
 
 //QUEUES
 //first in, first out
 //under hood = array
        Queue<string> names = new Queue<string>();  //OR var names = new Queue<string>();
        names.Enqueue("Luke");
        names.Enqueue("Leia");
        names.Enqueue("Han");
        names.Enqueue("Yoda");
        names.Enqueue("Chewbaca");

        while (names.Count > 0)
        {
            string name = names.Dequeue();
            Console.WriteLine(name);    
//ADD items to queue
names.Enqueue("C3PO");
//REMOVE items from queue
//best to check Count property otherwise exception is thrown is queue is empty
string name = names.Dequeue();
//PEEK at next item without removing it
string name = names.Peek();
//LOOPING through queue
while (names.Count > 0)
{
    string name = names.Dequeue();
    Console.WriteLine(name);    
}


//STACK
//first in last out
//under hood = array
        Stack<string> months = new Stack<string>(); //OR var names = new Stack<string>();
        months.Push("January");
        months.Push("February");
        months.Push("March");
        months.Push("April");
        months.Push("May");
        months.Push("June");

        while (months.Count > 0)
        {
            string month = months.Pop();
            Console.WriteLine(month);    
        }
//ADD items to stack
names.Push("C3PO");
//REMOVING items from stack
string name = names.Pop();
//Use PEEK to see next item without removing
//LOOPING
foreach (string name in names)
{
    // The item has not been removed from the stack.
    Console.WriteLine(name);
}

while (names.Count > 0)
{
    // The item has been removed from the stack.
    Console.WriteLine(names.Pop());
}


//LINKED LISTS
//values stored in LinkedListNode<T> wrapper
    LinkedList<string> months = new LinkedList<string>();  //OR var names = new LinkedList<string>();
    months.AddLast("March");
    months.AddFirst("January");

    var march = months.Find("March");

    months.AddBefore(march, "February");
    months.AddAfter(march, "April");

    foreach (string month in months)
    {
        Console.WriteLine(month);    
    }
    
//ADD to list
names.AddFirst("Anakin");
names.AddLast("Luke");

var node = names.Find("Luke");
names.AddBefore("Padme");
names.AddAfter("Rey?");

var node = new LinkedListNode<T>("Luke");
// Add the node
names.AddLast(node);
// Add another value, using this node
names.AddAfter(node, "Rey?");

//REMOVE
names.Remove("Luke");   // Find the item and remove it.
names.Remove(node);     // Remove the specific node.
names.RemoveFirst();    // Removes the first item in the list.
names.RemoveLast();     // Removes the last item in the list.

//LOOPING
foreach (string name in names)
{
    Console.WriteLine(name);    
}
    
    
//READIN AND WRITING FILES
//using namespace System.IO includes all functions needed to read and write files
//simplest approach is to used File class
        File.WriteAllText(@".\hello.txt", "Hello World");

        string content = File.ReadAllText(@".\hello.txt");  //@ suggest a verbatim string so additional escape characters needed in file path
        Console.WriteLine(content);
        File.Delete(@".\hello.txt");
        
//DIRECTORIES
//Directory type exists to provide methods for working with directories
Directory.CreateDirectory(@".\folder");
Directory.Delete(@".\folder");  //folder must be empty
Directory.Delete(@".\folder", true);  //recursively deletes folder and all of its contents

//create string array to store files
string[] files = Directory.GetFiles(@".\folder", "*", SearchOption.TopDirectoryOnly);  //"*" finds all files
string[] files = Directory.GetFiles(@".\folder", "*.jpg", SearchOption.AllDirectories);  //only finds .jpg files
for (int i = 0; i < files.Length; i++)
{
    Console.WriteLine(files[i]);   
}

//FILE STREAMS
//a more generic approach to reading/writing data
//allows for greater control over how you read and write data

        using (var writer = new StreamWriter(
            new FileStream(@".\StarWars.txt", FileMode.Create)))
        {
            writer.Write("Beep bop!");
        }

        using (var reader = new StreamReader(
            new FileStream(@".\StarWars.txt", FileMode.Open)))
        {
            Console.WriteLine(reader.ReadToEnd());
        }
    //1. Obtain a stream from a file
    //2. Create a reader to read from the stream
        var file = new FileStream(@".\StarWars.txt", FileMode.Open);
        var reader = new StreamReader(file);
        //read a line
        string line = reader.ReadLine();
        //read entire files, line-by-line
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            Console.WriteLine(line);
        }
        //read entire file
        string content = reader.ReadToEnd();
        //close the reader and file
        file.Close();
        reader.Close(); // Closes the FileStream
    //writing to FileStream
        var file = new FileStream(@".\StarWars.txt", FileMode.Create);
        var writer = new StreamWriter(file);
        //write a line
        write.WriteLine("Hello World");
        //close file
        file.Close()
        
        
//IDisposable Interface and using statement
        using (var writer = new StreamWriter(new FileStream(@".\movies.txt", FileMode.Create)))
        {
            writer.WriteLine("A New Hope");
            writer.WriteLine("The Empire Strikes Back");
            writer.WriteLine("Return of the Jedi");
        }
        //file and writer are closed at this point
        using (var reader = new StreamReader(new FileStream(@".\movies.txt", FileMode.Open)))
        {
            Console.WriteLine(reader.ReadToEnd());
        }
    //nested using statements
        using (var file = new FileStream(@".\movies.txt", FileMode.Open))
        using (var stream = new StreamReader(file))
        {

        }
    equivalent to:
        using (var file = new FileStream(".\movies.txt", FileMode.Open))
        {
            using (var stream = new StreamReader(file))
            {

            }
        }

        
//Utility Types
        const string DirectoryPath = @".\";
        const string FilePath = @".\HelloWorld.txt";
		
		// Create a sub-directory 
		Directory.CreateDirectory(Path.Combine(DirectoryPath, "sub-dir"));
		Directory.CreateDirectory(Path.Combine(DirectoryPath, "sub-dir2"));
		
		// Create a file
		File.WriteAllText(FilePath, "Hello World");

        FileInfo file = new FileInfo(FilePath);
        Console.WriteLine(file.Exists);
        Console.WriteLine(file.Name);
        Console.WriteLine(file.LastWriteTime);

        string directoryPath = Path.GetDirectoryName(FilePath);
        DirectoryInfo directory = new DirectoryInfo(directoryPath);
        Console.WriteLine(directory.Exists);
        Console.WriteLine(directory.LastWriteTime);

        foreach (string childDirectory in Directory.GetDirectories(directoryPath))
        {
            Console.WriteLine(childDirectory);
        }
    
    
    FileInfo file = new FileInfo(@"C:\Windows\Notepad.exe");
    if (file.Exists)
    {
        Console.WriteLine("The file {0} exists on disk, and was last accessed on {1}", file.Name, file.LastAccessTime);
    }
    
    file.CopyTo(newPath);
    file.MoveTo(newPath);
    
    string file = @"C:\Windows\Notepad.exe";
    if (File.Exists(file))
    {
        Console.WriteLine("The file {0} exists on disk", file);
    }
    
    string text = File.ReadAllText(path);
    string[] lines = File.ReadAllLines(path);

    File.WriteAllText(path, text);
    File.WriteAllLines(path, lines);
    
    File.Copy(fromPath, toPath);
    File.Move(fromPath, toPath);
    
    
    DirectoryInfo directory = new DirectoryInfo(@"C:\Windows");
    if (directory.Exists)
    {
        Console.WriteLine("The directory {0} exists", directory.Name);
    }
    
    string directory = @"C:\Windows";
    if (Directory.Exists(directory))
    {
        Console.WriteLine("The directory {0} exists", directory);
    }
    
    foreach (string childDirectory in Directory.GetDirectories(@"C:\Windows"))
    {
        Console.WriteLine(childDirectory);
    }
    
    string filePath = @"C:\Windows\Notepad.exe";
    string fileDirectory = Path.GetDirectoryName(filePath);
    string fileName = Path.GetFileName(filePath);
    
    string fileName = Path.GetFileName(@"C:\Windows\Notepad.exe");
    Console.WriteLine(fileName); // Notepad.exe
    
    string directory = Path.GetDirectoryName(@"C:\Windows\Notepad.exe");
    Console.WriteLine(directory); // C:\Windows
    
    string path = Path.Combine("C:", "Windows", "Notepad.exe");
    Console.WriteLine(path); // C:\Windows\Notepad.exe