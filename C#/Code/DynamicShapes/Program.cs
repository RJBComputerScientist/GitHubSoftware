using System;

namespace DynamicShapes
{
    class Program
    {
        static void Main(string[] args)
        {

            Shape[] Shapes = new Shape[6];
        //  ^^^ an array of shapes
            Shapes[0] = new Rectangle(102);
            Shapes[1] = new Triangle(67);
            Shapes[2] = new Circle(89);
            Shapes[3] = new Cube(36);
            Shapes[4] = new Square(3);
            Shapes[5] = new Sphere(45);

            foreach (Shape Element in Shapes)
            // ^^ looping through the shapes collection
            {
                if(Element is TwoDimensionalShape){
                    Console.WriteLine(Element);
                    Element.GetInfo();
                    Element.GetArea();
                } else if(Element is ThreeDimensionalShape){
                    ThreeDimensionalShape ThreeDShape = (ThreeDimensionalShape)Element;
                    /*^^ casting the volume property here because i want to keep the 
                    array of Shapes broad.
                    */
                    Console.WriteLine(Element);
                    
                    Element.GetInfo();
                    Element.GetArea();
                    Console.WriteLine("The Volume is {0:N}\n", ThreeDShape.Volume);
                    /*^^ casting the volume property here because i want to keep the 
                    array of Shapes broad.
                    */
                }
            }
    // Console.ReadKey();
        }
    }
}
