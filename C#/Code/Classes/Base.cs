using System;
using System.IO;
using System.Collections.Generic;

namespace Classes{
   public class Base {
       public string baseString;
        public Base(){
            this.baseString = "Base";
public Base(string baseString)
{
this.baseString = baseString;       
}            

public void speak(){
    Console.WriteLine("Hey, I'm a Base Object");
}
public string speak(string type){
    Console.WriteLine($"Hello, I'm a {type} Object");
    return "done";
}

 // Use descriptive names for the methods, but the methods to be overloaded MUST have the same name.
 // Use descriptive names for the parameters. Use the same name for the same parameter for each instance
 //      of an overloaded method.
 // Send parameters in a consistent order.
 // Do NOT have overloads with parameters at the same position and similar types, yet with different semantics.


public virtual void newMethod(){
    Console.WriteLine("Running newMethod() from Base")
}
        }
    }
}