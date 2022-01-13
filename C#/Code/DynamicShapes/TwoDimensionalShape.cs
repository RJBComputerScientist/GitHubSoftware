using System;

namespace DynamicShapes
{
    abstract class TwoDimensionalShape : Shape
    {
        
        // Constructor
         public TwoDimensionalShape(double A) : base(A){

         }
        // public override abstract double SetArea(){
        //     // this.Area = Area;
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

        public override string ToString(){
            return string.Format(" Is A 2D Shape");
        }
        
    }
}
