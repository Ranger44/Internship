using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiating a Class
            DrinksMachine dm = new DrinksMachine();

            // Instantiating a Class by Using Type Inference
            var dm2 = new DrinksMachine("Lounge", "Neat", "Cappo"); ;

            // Using Object Members
            dm.Make = "Fourth Coffee";
            dm.Model = "Beancrusher 3000";
            dm.Age = 2;
            //dm.MakeEspresso();
            
            dm.Location = "Kitchen"; //references the property not the private variable _location
            Console.WriteLine(dm.Location);
        }

        public class DrinksMachine
        {
            // private member variables
            private string _location;
            private int age;
            private string make;
            private string model;

            //default constructor
            public DrinksMachine()
            {
                Age = 0;
            }

            //non-default constructor
            public DrinksMachine(string loc, string make, string model)
            {
                this.Location = loc; //recommended to use properties even in constructor
                this.Model = model;
                this.Make = make;
            }

            public int Age { get; set; }
                                 
            // public properties
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
            //using refactor tool:
            public string Location { get => _location; set => _location = value; }

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
    }
}
