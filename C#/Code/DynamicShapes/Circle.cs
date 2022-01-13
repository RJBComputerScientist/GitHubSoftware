using System;

namespace DynamicShapes
{
     class Circle : TwoDimensionalShape
    {
        public Circle(double A) : base(A){
            this.Name = "Circle";
        }

        protected override double Area
        {
            get{
            return Math.PI * Math.Pow(base.SizeOfSides,2);
            }
        }

        public override string ToString()
        {
            return string.Format(Name) + base.ToString();
        }
    }
}
