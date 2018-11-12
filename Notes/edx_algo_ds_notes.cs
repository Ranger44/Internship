////DATA STRUCTURES
//Arrays
int[] arrayName = new int[10];
//multi-dimensional arrays
int[ , ] arrayName = new int[10,10];
    //access first row second column
    int value = arrayName[0,1]
//Jagged Arrays
    - an array of arrays
    - the size of each array can vary
    - good for sparse datastructures
    - must specify the size of first array, but not the size of the arrays it contains
    - allocate memory to each array within a jagged array separately
    int[][] jaggedArray = new int[10][];
     jaggedArray[0] = new Type[5]; // Can specify different sizes.
     jaggedArray[1] = new Type[7];
     ...
     jaggedArray[9] = new Type[21];
     
 //ENUM
    enum Day { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };  //Sunday = 0
    enum Day { Sunday = 1, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };  //change the default by specifying the start value
    enum Day : short { Sunday = 1, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday }; //change the default data type of the enum
    //cast from enum type to int
    int x = (int)Days.Sun;
    //using enum
    Day favoriteDay = Day.Friday;
    // Set an enum variable by value.
    Day favoriteDay = (Day)4;
    
    
//STRUCT
    - lightweight data structure
    //creating a struct
    //Declaring a Struct
    public struct Coffee
    {
        // This is the custom constructor.
        public Coffee(int strength, string bean, string countryOfOrigin)
        
        public int Strength;
        public string Bean;
        public string CountryOfOrigin;
        // Other methods, fields, properties, and events.
    }
    //using a struct
    //Instantiating a Struct with default constructor
        Coffee coffee1 = new Coffee();
        coffee1.Strength = 3;
        coffee1.Bean = "Arabica";
        coffee1.CountryOfOrigin = "Kenya";
    //Instantiating with custom constructor
        // Call the custom constructor by providing arguments for the three required parameters.
        Coffee coffee1 = new Coffee(4, "Arabica", "Columbia");
    //Implementing a Property 
    public struct Coffee 
    { 
        private int strength; 
        public int Strength 
        { 
            get { return strength; } 
            set { strength = value; } 
        } 
    }
    
    //Creating a Struct that Includes an Array 
        public struct Menu 
        { 
            public string[] beverages; 
            public Menu(string bev1, string bev2) 
            { 
                beverages = new string[] { "Americano", "Café au Lait", "Café Macchiato", "Cappuccino", "Espresso" }; 
            }
        }
        //Accessing Array Items Directly 
        Menu myMenu = new Menu(); 
        string firstDrink = myMenu.beverages[0];
        
    //Creating an Indexer 
    public struct Menu 
    { 
        private string[] beverages; 
        // This is the indexer. 
        public string this[int index] 
        { 
            get { return this.beverages[index]; } 
            set { this.beverages[index] = value; } 
        } 
        // Enable client code to determine the size of the collection. 
        public int Length 
        { 
            get { return beverages.Length; } 
        } 
    }
    //Accessing Array Items by Using an Indexer 
    Menu myMenu = new Menu(); 
    string firstDrink = myMenu[0]; 
    int numberOfChoices = myMenu.Length;
    
    
//COLLECTIONS
//Standard Collection Classes - System.Collections
    - ArrayList - stores linear collection of objects
        - dynamic array
            // Create a new ArrayList collection.
            ArrayList beverages = new ArrayList();


            // Create some items to add to the collection.
            Coffee coffee1 = new Coffee(4, "Arabica", "Columbia");
            Coffee coffee2 = new Coffee(3, "Arabica", "Vietnam");
            Coffee coffee3 = new Coffee(4, "Robusta", "Indonesia");


            // Add the items to the collection.
            // **Items are implicitly cast to the Object type when you add them.**
            beverages.Add(coffee1);
            beverages.Add(coffee2);
            beverages.Add(coffee3);


            // Retrieve items from the collection.
            // ***Items must be explicitly cast back to their original type.***
            Coffee firstCoffee = (Coffee)beverages[0];
            Coffee secondCoffee = (Coffee)beverages[1];
            
            // Iterating Over a List Collection
            foreach(Coffee coffee in beverages)
            {
               Console.WriteLine("Bean type: {0}", coffee.Bean);
               Console.WriteLine("Country of origin: {0}", coffee.CountryOfOrigin);
               Console.WriteLine("Strength (1-5): {0}", coffee.Strength);
            }
    - BitArray - list class that represetns a collection of bits as Boolean values. Used for bitwise operations and Boolean arithmetic.
        - inlcudes methods to perform common Boolean operations (AND< NOT XOR)
    - Hashtable - general purpose dictionary the stores key.value paris
            // Create a new Hashtable collection.
            Hashtable ingredients = new Hashtable();

            // Add some key/value pairs to the collection.
            ingredients.Add("Café au Lait", "Coffee, Milk");
            ingredients.Add("Café Mocha", "Coffee, Milk, Chocolate");
            ingredients.Add("Cappuccino", "Coffee, Milk, Foam");
            ingredients.Add("Irish Coffee", "Coffee, Whiskey, Cream, Sugar");
            ingredients.Add("Macchiato", "Coffee, Milk, Foam");

            // Check whether a key exists.
            if(ingredients.ContainsKey("Café Mocha"))
            {
               // Retrieve the value associated with a key.
               Console.WriteLine("The ingredients of a Café Mocha are: {0}", ingredients["Café Mocha"]);
            }
            
            //can iterate over keys OR values
            // Iterating Over a Dictionary Collection
            foreach(string key in ingredients.Keys)
            {
               // For each key in turn, retrieve the value associated with the key.  
               Console.WriteLine("The ingredients of a {0} are {1}", key, ingredients[key]);
            }
    - Queue - first in, first out collection of objects
    - SortedList - stores a collections of key/value pairs that are sorted by key.  Functionality of hashtable plus ablility to retrieve 
        items by key or by index
    - Stack - first in, last out
    
//Specialized Collection Classes - System.Collections.Specialized
    - ListDictionary
        - dictionary class that is optimized for small collections
        - general rule: use for collections of 10 items or less, otherwise, use hashtable
    - HybridDictionary
        - use when you cannot estimate the size of the collection
            - uses ListDictionary when collection is small then switches to Hashtable as the collection grows larger
    - OrderedDictionary
        - indexed dictionary class that enables you to retrieve items by key or by index
        - unlike SortedDictionary, items NOT sorted by key
    - NameValueCollection
        - both key and value are strings
        - can retrieve items by key or index
    - StringCollection
        - list class where every item is a string
        - use for simple, linear collection of strings
    - StringDictionary
        - both key and value are strings
        - can NOT retrieve by index
    - BitVector32
        - struct that represents 32-bit value as both a bit array and an integer value
        - fixed 32-bit size so more efficient for small values
        
//Lambda expressions
    List<Employee> employees= new List<Employee>()
    {
    new Employee() { empID = 001, Name = "Tom", Department= "Sales"},
    new Employee() { empID = 024, Name = "Joan", Department= "HR"},
    new Employee() { empID = 023, Name = "Fred", Department= "Accounting" },
    new Employee() { empID = 040, Name = "Mike", Department= "Sales" },
    };


    // Find the member of the list that has an employee id of 023
    Employee match = employees.Find((Employee p) => { return p.empID == 023; });
    Console.WriteLine("empID: {0}\nName: {1}\nDepartment: {2}", match.empID, match.Name, match.Department);
    
    
//Generics
 - ArrayList can store different data types but everything is acutally stored as an Object data type
    - must do casting or conversion when retrieving items
- Generic classes offer:
    - type safety
    - no casting
    - no boxing and unboxing
// Creating a Generic Class
public class CustomList<T>
{
   public T this[int index] { get; set; }
   public void Add(T item)
   {
      // Method logic goes here.
   }
   public void Remove(T item)
   {
      // Method logic goes here.
   } 
}
//Instantiating a Generic Class
CustomList<Coffee> clc = new CustomList<Coffee>;
Coffee coffee1 = new Coffee();
Coffee coffee2 = new Coffee();
clc.Add(coffee1);
clc.Add(coffee2);
Coffee firstCoffee = clc[0];

//Constraining generics
    // Constraining Type Parameters by Interface
    public class CustomList<T> where T : IBeverage
    {
    }
//Constraint Types
    where T : <name of interface>
        - the type argument must be, or implement, the specified interface
    where T : <name of base class>
        - the type argument must be, or derived from, the specified base class
    where T : U
        - the type argument must be, or derive form, the supplied type argument U
    where T : new()
        - the type argument must have a public default constructor
    where T : struct
        - the type argument must be a reference type
// Apply Multiple Type Constraints
public class CustomList<T> where T : IBeverage, IComparable<T>, new()
{
}


    where T : class
    