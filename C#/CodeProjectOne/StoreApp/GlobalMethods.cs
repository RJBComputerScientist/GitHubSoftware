using System.Data.SqlClient;

namespace StoreAppLibrary.Logic {
    interface GlobalMethods {
        // internal static int GlobalNumber;
        // internal static string? GlobalChoose;
        // public static void UserStringToInt(string? Choose, string Question, string ResponseText, int IntoNumber) {
        // public static void UserStringToInt(string Question, string ResponseText, int AmountOfSelections) {
        //     // string? 
        //      while (GlobalChoose == null || GlobalChoose.Length <= 0 )
        //     {
        //         Thread.Sleep(3000);
        //         Console.Write(Question);
        //         GlobalChoose = Console.ReadLine();
        //         bool validchoice = int.TryParse(GlobalChoose, out GlobalNumber);
        //         if (!validchoice || (GlobalNumber > AmountOfSelections || GlobalNumber < 0) )
        //         {
        //             Console.WriteLine(ResponseText);
        //             Console.WriteLine();
        //             GlobalChoose=null;
        //             continue;
        //         }
        //     }
        // }
        public void SQLConnection();
       
    }
}