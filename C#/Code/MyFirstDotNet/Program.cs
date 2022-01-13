// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Ryan!");
Console.WriteLine("GoodBye, Ryan!");

/*Primitive data types
int - whole numbers from -2,147,483,648 to 2,147,483,647 (signed 32-bit integer)
char - Any Unicode Character (UTF-16)
short - whole numbers from -32,768 to 32,767 (signed 16-bit integer)
float - real numbers from +-1.5x10^-45 to +-3.4x10^38 (4-bytes) (More accurate precision to a number) 
^^meaning where the numbers will be measured.. use the float and short careful in loop and certain types of conditions
bool - logical true or false, yes or no, on or off (1 - bit to use, allocates slightly more)
byte - positive whole numbers from 0 to 255 (unsigned 8-bit integer)
double - all real numbers from +-5.0 x 10^-324 to +-1.7 x 10^308 Low Precision
long - Whole numbers from teeny-tiny to gigundo-massive (64-bit signed integer)
*/

Console.WriteLine("Hello");

for(int s = 0; s < 100; s += 3){
    Console.WriteLine(s);
}

for(int s = 1; s < 100; s += 3){
    Console.WriteLine(s);
}

Console.WriteLine("Type Your Name");
Console.WriteLine("Welcome "+Console.ReadLine());

for(int v = 1; v <= 50; v++){
    Console.WriteLine(v);
}