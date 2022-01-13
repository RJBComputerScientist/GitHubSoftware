// Console.WriteLine("IM HERE TEE HEE");
// int v = 78;
// int l = 29;
// int z = v / l;
// Console.WriteLine(z);
// Console.ReadKey();

using System;

namespace RyanCalculator{

    class Calculator{
        public static double MathItUp(double NumberOne, double NumberTwo, string? Configure){
            //                                                            ^^^^? is to declare it as nullable
            double Conculsion = double.NaN;
            //^^ Represents a value that is not a number (NaN). This field is constant.

            //THIS WILL BE THE SWITCH STATEMENT
            switch (Configure){
                case "Add":
                    Conculsion = NumberOne + NumberTwo;
                    break;
                case "Sub":
                    Conculsion = NumberOne - NumberTwo;
                    break;
                case "Multi":
                    Conculsion = NumberOne * NumberTwo;
                    break;
                case "Divide":
                // while(NumberTwo == 0){
                //     Console.WriteLine("We Aint Dividing 0 right neow: ");
                //      NumberTwo = Convert.ToDouble(Console.ReadLine());
                // }
                if(NumberTwo != 0){
                    Conculsion = NumberOne / NumberTwo;
                }
                if(NumberTwo == 0){
                    Console.WriteLine("You're probably thinking about limits\nThat'll come soon\n");
                }
                    // Console.WriteLine($"The Magic Is: {NumberOne} ÷ {NumberTwo} = "+(NumberOne/NumberTwo));
                    //                                          ^^ fancy divide sign
                    break;
                case "+":
                    Conculsion = NumberOne + NumberTwo;
                    break;
                case "-":
                    Conculsion = NumberOne - NumberTwo;
                    break;
                case "x":
                    Conculsion = NumberOne * NumberTwo;
                    break;
                case "÷":
                // while(NumberTwo == 0){
                //     Console.WriteLine("We Aint Dividing 0 right neow: ");
                //      NumberTwo = Convert.ToDouble(Console.ReadLine());
                // }
                if(NumberTwo != 0){
                    Conculsion = NumberOne / NumberTwo;
                }
                if(NumberTwo == 0){
                    Console.WriteLine("You're probably thinking about limits\nThat'll come soon\n");
                }
                    // Console.WriteLine($"The Magic Is: {NumberOne} ÷ {NumberTwo} = "+(NumberOne/NumberTwo));
                    //                                               ^^ fancy divide sign
                    break;
                default: 
                    return Conculsion;
            }
            // Console.Write("Press Any Key And Rate My Calculator From My Website");
            // Console.ReadKey();
            return Conculsion;
        }
    }

    class Program {

        static void Main(string[] args){

            //Some variables
            // float NumberOne = 0, NumberTwo = 0;
            // double NumberOne = 0, NumberTwo = 0;
            //Changed it to double for 64 bit precision because float has 32 bit precision
            bool ActiveCalculator = true;

            Console.WriteLine("Ryans Calculator In C# .NET\r");
            /*^^^^
            \r is a carriage return which often means that the cursor should move to the leftmost 
            column, while \n is a line feed which moves the cursor to the next line.
            */
            Console.WriteLine("===================\n");
            
            //^^Makes a new line
            while(ActiveCalculator){
            //^^^while, if, & else if statements are always true
                string? NumberOneInput = "", NumberTwoInput = "";
                // ? is to declare it as nullable
                double result = 0;
                string AdvancedInput = "";
            // Console.WriteLine("Whats Your First NUmber??");
            //^^ for converting logic from before

            //Maybe the user wants to enter everything at once
            //first ill give them a choice
            Console.WriteLine("Are You An Advanced User Or Beginner User? \n 'Advanced' Or 'Beginner'");
            var UserChoice = Console.ReadLine();
            if(UserChoice == "Advanced"){
                Console.WriteLine("==========");
                Console.WriteLine("Enter Your Math Equation In One Line :D\nONLY 3 TERMS FO' NEOW");
                Console.WriteLine("==========");
                Console.WriteLine("Choose Either +, -, x, ÷ (π, √, ≈, ∫, ´, ∑)\n and many other symbols coming soon");
                 AdvancedInput = Console.ReadLine();
                string[] ArrayOfString = AdvancedInput.Split(' ');
                try{
                var FirstNumber = ArrayOfString[0];
                var Operation = ArrayOfString[1];
                var SecondNumber = ArrayOfString[2];
                //^^ could use a for loop to increase amount of entries the user can do
                //^^^ didnt test that out yet 11/30/21
                double AdvancedOutPutOne = 0;
                while(!double.TryParse(FirstNumber, out AdvancedOutPutOne)){
                    Console.Write("AYY!! Your First Number Ain't Good. Retry!");
                    FirstNumber = Console.ReadLine();
                }
                double AdvancedOutPutTwo = 0;
                while(!double.TryParse(SecondNumber, out AdvancedOutPutTwo)){
                    Console.Write("AYY!! Your Second Number Ain't Good. Retry!");
                    SecondNumber = Console.ReadLine();
                }
                try{
                    result = Calculator.MathItUp(AdvancedOutPutOne, AdvancedOutPutTwo, Operation);
                     if(double.IsNaN(result)){
                    Console.WriteLine("You Got A Mathematical Error\n");
                } else {
                    Console.WriteLine("The Magic Is: {0:0.##}\n", result); 
                }
                } catch(Exception E){
                    Console.WriteLine("The Math Messed Up..\n --Details Are Here: "+E.Message);
                }
                Console.Write("Type 'Rate' To Go To The Website Or Type 'End' To End This Amazing Program: \n Or Any Other Input To Continue!!\t");
            var Read = Console.ReadLine();
            if(Read == "Rate"){
                Console.WriteLine("PUT A LINK TO A URL OF THE PROGRAM DOWNLOAD HERE\n\tMore Logic Can Go Here Too");
            } else if(Read == "End"){ 
                ActiveCalculator = false;
                Console.Write("BYE BYE NOW!!");
            }
            Console.WriteLine("\n");
                 } catch(IndexOutOfRangeException){
                    Console.WriteLine("Put Some Spaces DANG");
                    Console.WriteLine("TRY AGAIN FOO!!\n");
                }

            } else if(UserChoice == "Beginner"){
            Console.Write("Whats Your First NUmber??\t");
            // NumberOne = Convert.ToDouble(Console.ReadLine());
            NumberOneInput = Console.ReadLine();
            /*
                The Console.ReadLine() method in C# is used to read the next line of characters 
                from the standard input stream.
            */
            double OutputNumberOne = 0;
            while(!double.TryParse(NumberOneInput, out OutputNumberOne)){
                //^^ for the number to be an invalid input
                // Console.WriteLine("AYY!! This Number Ain't Good. Retry!");
                //^^ for converting logic from before
                Console.Write("AYY!! This Number Ain't Good. Retry!");
                NumberOneInput = Console.ReadLine();
            }
            //^^ getting first number .. getting error when its a fraction number
            Console.WriteLine("Whats Your Second NUmber??\t");
            // NumberTwo = Convert.ToDouble(Console.ReadLine());
            //^^ getting second number .. getting error when its a fraction number
             NumberTwoInput = Console.ReadLine();

            double OutputNumberTwo = 0;
            while(!double.TryParse(NumberTwoInput, out OutputNumberTwo)){
                //^^ for the number to be an invalid input
                Console.Write("AYY!! This Number Ain't Good. Retry!");
                NumberTwoInput = Console.ReadLine();
            }

            Console.WriteLine("What Kind Of Operation Do You Want??");
            Console.WriteLine("\tAdd - Addition");
            Console.WriteLine("\tSub - Substraction");
            Console.WriteLine("\tMulti - Multiplication");
            Console.WriteLine("\tDivide - Division");
            Console.Write("PICK SOMETHING!!!!!\n\t");

            string? Operation = Console.ReadLine();

            //THIS WILL BE THE SWITCH STATEMENT
            // switch (Console.ReadLine()){
            //     case "Add":
            //         Console.WriteLine($"The Magic Is: {NumberOne} + {NumberTwo} = "+(NumberOne+NumberTwo));
            //         break;
            //     case "Sub":
            //         Console.WriteLine($"The Magic Is: {NumberOne} - {NumberTwo} = "+(NumberOne-NumberTwo));
            //         break;
            //     case "Multi":
            //         Console.WriteLine($"The Magic Is: {NumberOne} x {NumberTwo} = "+(NumberOne*NumberTwo));
            //         break;
            //     case "Divide":
            //     while(NumberTwo == 0){
            //         Console.WriteLine("We Aint Dividing 0 right neow: ");
            //          NumberTwo = Convert.ToDouble(Console.ReadLine());
            //     }
            //         Console.WriteLine($"The Magic Is: {NumberOne} ÷ {NumberTwo} = "+(NumberOne/NumberTwo));
            //         //                                          ^^ fancy divide sign
            //         break;
            // }
            try {
                result = Calculator.MathItUp(OutputNumberOne, OutputNumberTwo, Operation);
                if(double.IsNaN(result)){
                    //^^ Returns a value that indicates whether the specified value is not a number (NaN).
                    Console.WriteLine("You Got A Mathematical Error\n");
                } else {
                    Console.WriteLine("The Magic Is: {0:0.##}\n", result); 
                    //...arguements after comma for Console.WriteLine()
                    /*                              ^^^ the . is the wildcard term
                        ^^^^ number 0 is for digits, : is for grouping,
                        ^^^^^ is for number
                    */
                }
            } catch(Exception E){
                Console.WriteLine("The Math Messed Up..\n --Details Are Here: "+E.Message);
            }
            Console.WriteLine("===================\n");

            Console.Write("Type 'Rate' To Go To The Website Or Type 'End' To End This Amazing Program: \n Or Any Other Input To Continue!!\t");
            var Read = Console.ReadLine();
            if(Read == "Rate"){
                Console.WriteLine("PUT A LINK TO A URL OF THE PROGRAM DOWNLOAD HERE\n\tMore Logic Can Go Here Too");
            } else if(Read == "End"){ 
                ActiveCalculator = false;
                Console.Write("BYE BYE NOW!!");
            }
            Console.WriteLine("\n");
            // Console.ReadKey();
            /*
                ReadKey() Method makes the program wait for a key press and it prevents the screen until 
                a key is pressed.
            */
        }
            }
        return;
        }
    }

}