using System;

namespace Operators{

    public class Operators {
        
        public static void Main(string[] args){

Console.WriteLine("Hello, World!");

int g = 10;
int n = 10;
bool EitherOr = false;

Console.WriteLine("Your result is removed on to your variable: "+Decrement(n));
Console.WriteLine("Your result is added on to your variable: "+Increment(g));
Console.WriteLine("Substracting g from n "+Diff(g,n));
Console.WriteLine("DIviding n from g "+Quotient(n, g));
Console.WriteLine($"Negative {g} is "+Negate(g));
Console.WriteLine($"Not {EitherOr} is "+Not(EitherOr));
Console.WriteLine("Adding n from g "+Sum(n, g));
Console.WriteLine("Dividing g from n With Remainder "+Remainder(g,n));
Console.WriteLine("Multiplying g from n "+Product(g, n));
Console.WriteLine("n is not equal to 0, and g greater than 0"+And(n,g));
Console.WriteLine("g is less than 0 or n is not equal to 0 "+Or(g, n));
        }
        public static int Increment(int num) { 
            return ++num;
            throw new NotImplementedException(); 
            }
        public static int Decrement(int num) { 
            return --num;
            throw new NotImplementedException(); 
            }
        public static bool Not(bool input) { 
            return !input;
            throw new NotImplementedException(); 
            }
        public static int Negate(int num){ 
            return -num;
            throw new NotImplementedException(); 
            }
        public static int Sum(int num1, int num2){ 
            return num1 + num2;
            throw new NotImplementedException(); 
            } 
        public static int Diff(int num1, int num2){ 
            return num1 - num2;
            throw new NotImplementedException(); 
            }
        public static int Product(int num1, int num2){ 
            return num1 * num2;
            throw new NotImplementedException();}
        public static int Quotient(int num1, int num2) { 
            return num1 / num2;
            throw new NotImplementedException(); 
            }
        public static int Remainder(int num1, int num2) { 
            return num1 % num2;
            throw new NotImplementedException(); 
            }
        public static bool And(int num1, int num2){ 
            return (num1 != 0) & (num2 > 0);
            throw new NotImplementedException(); 
            }
        public static bool Or(int num1, int num2){ 
            return (num1 < 0) | (num2 != 0);
            throw new NotImplementedException(); 
            }
        }
    }