//CLASSES
- enable you to create your own custom, self-contained, reusable type
- a class is a blueprint for a custom type

//Declaring a Class
public class DrinksMachine
{
   private string _location;
   public string Location
   {
      get
      {
         return _location;
      }
      set
      {
         if (value != null) 
            _location = value;
      }
   }
   // The following statements define properties.
   public string Make {get; set;}
   public string Model {get; set;}
   // The following statements define methods.
   public void MakeCappuccino()
   {
      // Method logic goes here.
      Console.WriteLine("Cappuccino is made");
   }
   public void MakeEspresso()
   {
      // Method logic goes here.
   }
   // The following statement defines an event. The delegate definition is not shown.
   public event OutOfBeansHandler OutOfBeans;
}

//Partial Classes
- split the definition of the class across multiple source files
- must use keyword "partial"

//Instantiating Classes
- since a class is just a blueprint, must create an instance of a class or "object"
//This create a new object in memory based on the DrinksMachine type AND it creates an object referencenamed dm that refers to the new DrinksMachine object
DrinksMachine dm = new DrinksMachine();
OR
var dm = new DrinksMachine();  //type inference allows comiler to deduce type of object at compile time

// Using Object Members
var dm = new DrinksMachine();
dm.Make = "Fourth Coffee";
dm.Model = "Beancrusher 3000";
dm.Age = 2;
dm.MakeEspresso();

//Encapsulation
- used to describe the accessibility of the members belonging to a class or struct
- access modifiers and properties help implement encapsulation
- public - type available to code running in any assembly
- internal - type available to any code within the same assemebly, not to code in another assembly
- protected -ype only accessible within its class and by derived class instances
- private - type is only available within the class that contains it; must be used with nested classes; default if none specified

//Properties
- enable you to permit users a means of getting and setting values for the private member variable
 - validate a birthdate entry
- also present an "interface" to your class by exposing a way to get or set the members of the class
public class DrinksMachine
{
   // private member variables
   private int age;
   private string make;
   private string model;


   // public properties
   public int Age
   {
      get
      {
         return age;
      }
      set
      {
         age = value;
      }
   }
   public string Make
   {
      get
      {
         return make;
      }
      set
      { 
         make = value;
      }
   }
   
   // auto-implemented property
   public string Model { get; set; }

      // Constructors
   public DrinksMachine(int age)
   {
      this.Age = age;
   }
   public DrinksMachine(string make, string model)
   {
      this.Make = make;
      this.Model = model;
   }
   public DrinksMachine(int age, string make, string model)
   {
      this.Age = age;
      this.Make = make;
      this.Model = model;
   }
}


//Static Classes and Members
- a static class cannot be instantiated
- used to encapsulate a functionality, rather than representing an instance of anything (UTILITY)
    - ex: create a set of conversions
    // Static Classes
    public static class Conversions  //static keyword in class name
    {
       public static double PoundsToKilos(double pounds)  //static keyword must be used for any memebers also
       {
          // Convert argument from pounds to kilograms
          double kilos = pounds * 0.4536;
          return kilos;
       }
       public static double KilosToPounds(double kilos)
       {
          // Convert argument from kilograms to pounds
          double pounds = kilos * 2.205;
          return pounds;
       }
}

- to call a method of a static class, call the class name itself:
    //Calling Methods on a Static Class
    double weightInKilos = 80;
    double weightInPounds = Conversions.KilosToPounds(weightInKilos);

//Static members
- non-static classes can include static members
    - methods, fields, properties, and events can all be declared static
    - static properties used to return data that is common to all instances, or to keep try of how many instances of a class have been created
    - static methods used to provide utilities that relate to the type in some way, like comparison functions
    // Static Members in Non-static Classes
    public class DrinksMachine
    {
       ...
       public static int CountDrinksMachines()
       {
          // Add method logic here.
       }
    } 
- regardles of how many instances of a class exist, there is only ever one instance of a static member
- access static members through the class name rather than an instance name:
// Access Static Members
int drinksMachineCount = DrinksMachine.CountDrinksMachines();


//Inspect System.Math
- CTRL-ALT-j opens object browser
- select all components from drop down
- search for System.Math
- review inforamtion on System.Math on right-hand side.


//ANONYMOUS CLASSES
- no name
- encapsulates read-only properties into a single object without the need to explicitly define a type first
- type name generated by the compiler
- can only contain public fields
- fields must all be initialized
- fields cannot be static
- cannot define any methods
- use new keyword to use:
    var anAnonymousObject = new { Name = "Tom", Age = 65 };
    - will have 2 public fields, compiler infers data types of these fields
- access:
    Console.WriteLine("Name: {0} Age: {1}", anAnonymousObject.Name, anAnonymousObject.Age};
    var secondAnonymousObject = new { Name = "Hal", Age = 46 };
    secondAnonymousObject = anAnonymousObject;
    
    
    
//Inheritance
- a derived class can only have one base class
class Manager : Employee  //Manager = derived, Employee = base
{
    private char payRateIndicator;
    private Employee[] emps;
}

//Abstract classes
- Once you create an abstract class, you decide which methods "must" be 
    implemented in the sub classes and which methods "can" be implemented, or overridden, in the sub class.
        public virtual void Login()  //virtual = can be overridden
        {
        }

        public virtual void LogOff()
        {
        }

        public abstract void EatLunch();  //abstract = must be implemented in any sub class
            - An abstract method cannot exist in non-abstract class
            - An abstract method is not permitted to have any implementation, including curly braces
            - An abstract method signature must end in a semi-colon
            - An abstract method MUST be implemented in any sub class. 
            
            
//Sealed Classes
- keyword that prevents a class from being inherited
    - compiler error if inheritance is attempted
- STRUCTS are sealed - can't derived a class from a struct


//Interfaces
- Like a class without an implementation
- Specifies a set of characteristics and behaviors without specifying how they are implemented
- When a class implements an interface, the class rpovides an miplementation for each member of the interface
// Defining an Interface
public interface ILoyaltyCardHolder
{
   int TotalPoints { get; }
   int AddPoints(decimal transactionValue); //Methods do not include bodies
   void ResetPoints();
}
// Implementing an Interface Implicitly
public class Customer : ILoyaltyCardHolder
{
   private int totalPoints;
   public int TotalPoints
   {
      get { return totalPoints; }
   }
   public int AddPoints(decimal transactionValue)
   {
      int points = Decimal.ToInt32(transactionValue);
      totalPoints += points;
      return totalPoints;
   }
   public void ResetPoints()
   {
      totalPoints = 0;
   }
   // Other members of the Customer class.   
}
// Implementing an Interface Explicitly
public class Coffee : IBeverage
{
   private int servingTempWithoutMilk { get; set; }
   private int servingTempWithMilk { get; set; }
   public int IBeverage.GetServingTemperature(bool includesMilk)  //member belongs to a particular interface
   {
      if(includesMilk)
      {
          return servingTempWithMilk;
      }
      else
      {
         return servingTempWithoutMilk;
      }
   }
   public bool IBeverage.IsFairTrade { get; set; }
   // Other non-interface members.
}
// Representing an Object as an Interface Type
Coffee coffee1 = new Coffee();
IBeverage coffee2 = new Coffee();
// Casting to an Interface Type
IBeverage beverage = coffee1;
// Casting an Interface Type to a Derived Class Type
Coffee coffee3 = beverage as Coffee;
// OR
Coffee coffee4 = (Coffee)beverage;
Implementing Multiple Interfaces

//Implementing more than one interface
- add a comma-separated list of the interface
// Declaring a Class that Implements Multiple Interfaces
public class Coffee: IBeverage, IInventoryItem
{
}


//Object Lifecycle
- Common language runtime (CLR) executes code to create new oject
    - allocates a block of memory large enough to hold the object
    - initializes the block of memory to the new onject
- Garbage Collector (GC) runs automatically and periodically in a separate thread
        - releases resources
        - memory that is allocated to the object is reclaimed
        - Enables you to develop your application without having to worry about freeing memory.
        - Allocates objects on the managed heap efficiently.
        - Reclaims objects that are no longer being used, clears their memory, and keeps the memory available for future allocations. Managed objects automatically get clean content to start with, so their constructors do not have to initialize every data field.
        - Provides memory safety by making sure that an object cannot use the content of another object.
        - cannot handle unmanaged resources

