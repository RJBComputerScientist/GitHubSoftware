using System;

namespace DynamicShapes 
{
     class Square : TwoDimensionalShape
    {
        // Implement your Square Class here.
        public Square(double A) : base(A){
            this.Name = "Square";
        }

         protected override double Area
        {
            get{
            return Math.Pow(base.SizeOfSides,2);
            }
        }

        public override string ToString()
        {
            return string.Format(Name) + base.ToString();
        }
    }
}

/*
COde coverage is where each test reports back what blocks of code 
are excuting at how many lines it runs at.
*/
