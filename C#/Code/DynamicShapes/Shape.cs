using System;

namespace DynamicShapes
{
    abstract public class Shape
    {
        public string Name { get; set; } = "";
        public double SizeOfSides { get; set; } = 0;
        protected double area;
        
        protected virtual double Area 
        /*        ^^^^^^^
        used to modify a method, property, indexer, or 
        event declaration and allow for it to be overridden 
        in a derived class.
        */
        { 
            get
            {
                return this.area;
            } 
            set
            {
                if(value > 0)
                    this.area = value;
            }
            // get;
            
            // set;
            
        }

          public Shape(double SizeOfSides)
        {
            this.SizeOfSides = SizeOfSides;
            //putting in this.Name = ... for individual shapes
        }
        // ^^This method returns the general information about the shape.

        public void GetInfo()
        {
            System.Console.WriteLine($"This {Name} has a area of {Area}");
        }

        // ^^ This method returns the area of the shape
        public double GetArea()
        {
            return this.Area;
        }
        
        public override abstract string ToString();

    }
}
