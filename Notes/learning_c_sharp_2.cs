EDX Intro to C# Course

History
    - Object-oriented - encapsulation, inheritance, and polymorphism
    - Strongly-typed - the languages enforces type checking on objects in the code meaning it is type-safe
    - handles memory and resource management for the developer
    - uses garbage collection to release memory and prevent memory leaks
    - Component-oriented - C# permits the creation of software components for self-contained, self-describing packages of functionality
    - Unified type system - all C# types, from primitive to reference types, inherit from a single root known as Object
    
.NET Framework
    - Common Language Runtime (CLR) is the foundation of the .NET framework
    - C# is a Just-in-Time (JIT) compiled language
        - enforces strict type safety 
    - Runtime responsible for managing code at execution time
        - memory management
        - thread management
        - remoting
        
Data Types
    - Value types contain the actual value of the data they store (int, double, char, string, DateTime, etc.)
    - Reference types AKA objects are created from class files
        - No pointers necessary
    
Identifiers
    - C# will not allow you to use an unassigned variable to help prevent unwanted data from being used in your application   
    - identifiers are case-sensitive
    
Operators
    + will add sum numbers or combine strings //operator overloading
        "Tom" + "Sawyer" = "TomSawyer"
        Recommended: Console.WriteLine("{0} {1}", firstName, lastName); //use placeholders
        // use string interpolation
            // NOTE: This line of code only works with Visual Studio 2015 or C# 6.0 and later.
            // If you are using an earlier version, then comment out this line of code.
            Console.WriteLine($"Born on {birthDate}");
    ++ will increment numbers
    
Data Conversion
    - implicit casting:
        int myInt = 2147483647; //32-bits
        long myLong = myInt; //64-bits so can easily accomodate any int value
    - explicit  
        //going from long to int may result in data loss so should use explicit casting
        double myDouble = 1234.6;
        int myInt;
        myInt = (int)myDouble;
        OR
        myInt = Convert.ToInt32(myDouble);  //can cast string to numbers
        
        double value = (double)myVar / (double)secondVar; //both were declared at ints
        
        // TryParse() example
        bool result = Int32.TryParse(value, out number);

        // Parse() example
        int number = Int32.Parse(value);
        
        sum.ToString()
        
Switch statements
    - Can use strings!
    
For each loops
    string[] names = new string[10];
    // Process each name in the array.
    foreach (string name in names)
    {
        // Code to execute.
    }
    
    
METHODS
    - can return an array or collection
    - using out keyword:
        //out keyword indicats that values will be returned for those parameters
        //don't need to call with assignment statement
        ReturnMultiOut(out first, out sValue);
        Console.WriteLine($"{first.ToString}, {sValue}");

        static void ReturnMultiOut(out int i, out string s)
        {
            i = 25;
            s = "using out";
            
            //note: no return statement, so cannot assign to a value
        }
    - using ref keyword:
        // Using ref requires that the variables be initialized first
        string sValue = "";
        int first = 0;
        ReturnMultiRef(ref first, ref sValue);
        Console.WriteLine($"{first.ToString()}, {sValue}");

         void ReturnMultiRef(ref int i, ref string s)
         {
                i = 50;
                s = "using ref";
         }
         
 METHOD OVERLOADING
    - parameters must differ
    
OPTIONAL PARAMETERS
    - list all non-optional paraemeters first, then list optional parameters
    - define a method with optional parameters by including default value with parameter
    void StopService(bool forceStop, string serviceName = null, int serviceId = 1)
    {
       // code here that will stop the service
    }
    
NAMED PARAMETERS
    - no difference when defining method
    - allows the parameters to be in any order
    StopService(true, serviceID: 1); //must specify positional arguments before named args
    //also good to clarify meaning:
    Area(length: 30, width: 9);
    
EXCEPTION HANDLING
    try
    {
        result = SafeDivision(a, b);
        Console.WriteLine("{0} divided by {1} = {2}", a, b, result);
    }
    catch (DivideByZeroException ex)
    {
        // Catch all DivideByZero exceptions.
        Console.WriteLine("Attempted to divide by zero."); //send user friendly text to user
        //developer message:
        Console.WriteLine(ex);
    }
    catch (Exception ex)  //catch other general exceptions
    {
        // Catch all other exceptions.
    }
    finally
    {
       // Code that always runs to close files or release resources.
    }
    
    static double SafeDivision(double x, double y) {
        if (y == 0 )
            throw new System.DivideByZeroException();
        return x / y;
    }