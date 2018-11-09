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