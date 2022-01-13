using System;

namespace DynamicShapes
{
    abstract class ThreeDimensionalShape : Shape
    {
        
        // Constructor
         public ThreeDimensionalShape(double A) : base(A){

         }
        // public override double SetArea(){
        //     this.Area = Area;
        // }
        protected override abstract double Area{
    // So im overriding a class member that is abstract
            /*              ^^^^^^
             class members that are incomplete and must 
             be implemented in a derived class.
            */
            // this.Area = Area;
            get;
        }
        public abstract double Volume { get;}

        public override string ToString(){
            return string.Format(" Is A 3D Shape");
        }
        
    }
}
