using System;

namespace StringManipulationChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userInputString; //this will hold your users message
            int elementNum;         //this will hold the element number within the messsage that your user indicates
            char char1;             //this will hold the char value that your user wants to search for in the message.
            string fName;           //this will hold the users first name
            string lName;           //this will hold the users last name
            string userFullName;    //this will hold the users full name;
            
            //
            //
            //implement the required code here and within the methods below.
            //
            //


        }

        // This method has one string parameter. 
        // It will:
        // 1) change the string to all upper case, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringToUpper(string x){
            // x.ToUpper();
            Console.WriteLine(x.ToUpper());
            char ThisChar = x[1];
            Console.WriteLine(ThisChar);
            Console.WriteLine("Here is your new String "+Console.ReadLine());
            throw new NotImplementedException("StringToUpper method not implemented.");
        }

        // This method has one string parameter. 
        // It will:
        // 1) change the string to all lower case, 
        // 2) print the result to the console and 
        // 3) return the new string.        
        public static string StringToLower(string x){
            // x.ToLower();
            Console.WriteLine(x.ToLower());
            Console.WriteLine(x.Length);
            Console.WriteLine("Here is your new String "+Console.ReadLine());
            throw new NotImplementedException("StringToLower method not implemented.");

        }
        
        // This method has one string parameter. 
        // It will:
        // 1) trim the whitespace from before and after the string, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringTrim(string x){
        //    string b = LTrim(RTrim(x));
        //    string b = Trim(x);
            Console.WriteLine(x.Trim());
            Console.WriteLine("Your New String"+Console.ReadLine());
            throw new NotImplementedException("StringTrim method not implemented.");

        }
        
        // This method has two parameters, one string and one integer. 
        // It will:
        // 1) get the substring based on the integer received, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringSubstring(string x, int elementNum){
           string v = x.Substring(elementNum);
            Console.WriteLine(v);
            Console.WriteLine("New Substring "+Console.ReadLine());
            throw new NotImplementedException("StringSubstring method not implemented.");

        }

        // This method has two parameters, one string and one char.
        // It will:
        // 1) search the string parameter for the char parameter
        // 2) return the index of the char.
        public static int SearchChar(string userInputString, char x){
            string search = String.Intern(userInputString);
            Console.WriteLine(search);
            Console.WriteLine("You have searched this word "+Console.ReadLine());
            throw new NotImplementedException("SearchChar method not implemented.");
        }

        // This method has two string parameters.
        // It will:
        // 1) concatenate the two strings with a space between them.
        // 2) return the new string.
        public static string ConcatNames(string fName, string lName){
            string YoName = fName + " " + lName;
            Console.WriteLine(YoName);
            Console.WriteLine("Your name is "+Console.ReadLine());
            throw new NotImplementedException("ConcatNames method not implemented.");
        }



    }//end of program
}
