using System;

namespace DynamicShapes
{
     class Cube : ThreeDimensionalShape
    {
       
        public Cube(double A) : base(A){
            this.Name = "Cube";
        }
        protected override double Area
        {
            get{
            return 6 * Math.Pow(base.SizeOfSides,2);
            }
        }

            public override double Volume{
            get{
                return Math.Pow(base.SizeOfSides, 3);
            }
        }

        public override string ToString()
        {
            return string.Format(Name) + base.ToString();
        }
    }
}
