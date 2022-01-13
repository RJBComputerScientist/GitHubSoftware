int x;
for(x=0; x < 100; x++){
    if(x % 3 == 0){
        Console.WriteLine("Fizz");
    } else if(x % 5 == 0){
        Console.WriteLine("Buzz");
    } else if((x % 3 == 0) & (x % 5 == 0)){
        Console.WriteLine("Fizz-Buzz");
    } else {
        Console.WriteLine(x);
    }
}
