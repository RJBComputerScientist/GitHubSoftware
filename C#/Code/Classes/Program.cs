using System;
using System.IO;
using System.Collections.Generic;

namespace Classes{
    class DerivedClass : BaseClass {
        public override void AbstractMethod(){
            _x++;
            _y++;
        }
        public override int x {
            get{
                return _x + 20;
            }

        }
        public override int y{
            get{
                return _y + 20;
            }

        }
        
    } 
    class Program {
        static void Main(string[] args){
            Console.WriteLine("Welcome To Classes Program");

            Employee Robot = new Employee();
            Robot.Introduce();
            Employee AnotherRobot = new Employee(200, 25, "Robot", "Mang");
            AnotherRobot.DoWork();
            AnotherRobot.Introduce();
            Employee AnotherRobotAgain = new Employee(200, 25, "Robot", "Mang");
            AnotherRobotAgain.Introduce();
            AnotherRobotAgain.ChangeName("Spine", "Broke");
            AbstractMethod()
            
        }
    }
}