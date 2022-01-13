int X;
int Y;
Console.WriteLine("What Line Of Mathemmatics Do Want?");
var Read = Console.ReadLine();
Console.WriteLine("Here Is "+Read);

if(Read == "Addition"){
    X = 5;
    Y = 5;
    int add = X+Y;
    Console.WriteLine(add);
}
if(Read == "Substraction"){
    X = 10;
    Y = 15;
    int sub = X-Y;
    Console.WriteLine(sub);
}
if(Read == "Multiplication"){
    X = 55;
    Y = 55;
    int product = X*Y;
    Console.WriteLine(product);
}
if(Read == "Division"){
    X = 120;
    Y = 120;
    int quotient = X/Y;
    Console.WriteLine(quotient);
}
