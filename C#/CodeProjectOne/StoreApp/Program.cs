using System.Diagnostics;
using System.Xml.Serialization;
using StoreAppLibrary.Logic;
using System.Data.SqlClient;
    /* ========== NOTES ==========
    the stores constructor will take in the type of store they want and 
    each individual method will take the customer name, The Stores History
    after a customer makes a order the reciept is for the customer
    so there will be two seperate serialization
    */

namespace StoreApp.App {
    public class Program {
        private static string? EntryName;
        private static int EntryNumber;
        private static bool BackToMainMenu;
        //  private string ConnectionString = File.ReadAllText("/Users/kingbrooks/desktop/ProjectZero.rtf"); 
        public static void Main(){
            // Console.WriteLine("Welcome To The Block\n\n What Store Do You Want?");
        // SqlConnection();
        
            // int action = ChooseAction();

            // while (action != 0)
            // {
            //      Console.WriteLine("You CHose "+action);
            //      action = ChooseAction();
            // }
            // // string b = "store";
            // // Stores Store = new(b);
            // // Store
            // Product A = new Product("Space Suit", "Appreal", 40.29M);
            // Product B = new Product("Eggs", "Food", 10.29M);

            // FoodStoreInventory F = new FoodStoreInventory();
            // F.ShoppingList.Add(A);
            // F.ShoppingList.Add(B);
            // decimal total = F.CheckOut();
            // Console.WriteLine("Yo Output IS "+total);

            List<FoodStore>? FoodRecords = ReadOrdersFromFoodStore("../FoodHistory.xml");
            // List<ShoeStore>? ShoeRecords = ReadOrdersFromShoeStore("../ShoeHistory");
        //     if(BackToMainMenu == false){
        // Console.WriteLine("\tWelcome To The Block\n\n\tWhat Store Do You Want?");
        // } else {
        //     Console.WriteLine("\tWelcome Back To Da Block\n\n\tA New Store?");
        //     // Console.WriteLine("\nLeave The Block?");
        // }
            // while (EntryName == null || EntryName.Length <= 0)
            // {
            // Thread.Sleep(3000);
            // EntryName = Console.ReadLine();
            // }
            FIRSTLOOP:{
                    if(BackToMainMenu == false){
        Console.WriteLine("\tWelcome To The Block\n\n\tWhat Store Do You Want?");
        } else {
            Console.WriteLine("\tWelcome Back To Da Block\n\n\tA New Store?");
            // Console.WriteLine("\nLeave The Block?");
        }
              while (EntryName == null || EntryName.Length <= 0 )
            {
                Thread.Sleep(1000);
                Console.Write(" 0.\t To Leave The Block\n 1.\t Food Store\n2.\t Shoe Store\n3.\t To Leave The Block");
                EntryName = Console.ReadLine();
                bool validchoice = int.TryParse(EntryName, out EntryNumber);
                if (!validchoice || (EntryNumber > 4 && EntryNumber < 0) )
                {
                    Console.WriteLine("Thats not the right store");
                    Console.WriteLine();
                    EntryName=null;
                    continue;
                }
                // if(validchoice){
                //     EntryName = null;
                //     EntryNumber = 0;
                //     string? input = null;
                //     //print all customer reciepts
                //     Console.WriteLine("\nLeave The Block? (Y/N)");
                //     input = Console.ReadLine();
                //     if(input?.ToLower() == "y"){
                //         break;
                //     } else {
                //         BackToMainMenu = false;
                //         continue;
                //     }
                // }
            
            if(EntryName == null){
            MainIntroDuction();
            }
            //^^ local
            // int f =0;
            // UserStringToInt(EntryName, "1.\t Food Store,\n2.\t Shoe Store\n", 
            // "Thats not the right store", EntryNumber);
            // GlobalMethods a =new GlobalMethods();
            // GlobalMethods.UserStringToInt();
            // GlobalMethods.UserStringToInt(EntryName, "1.\t Food Store,\n2.\t Shoe Store\n", 
            // "Thats not the right store", EntryNumber);
            // GlobalMethods.UserStringToInt(EntryName, "1.\t Food Store,\n2.\t Shoe Store\n", 
            // "Thats not the right store");
            // GlobalMethods.UserStringToInt("1.\t Food Store,\n2.\t Shoe Store\n", 
            // "Thats not the right store");
            //^^ Global .. THE GLOBAL IDEA DOESNT WORK IN C# .NET
            Stores store = new(EntryName);
            // Stores store = new(GlobalChoose);
            Console.WriteLine(store.CustomerName);
            Console.WriteLine(store.CustomerActionNumber);
            Console.WriteLine(store.StoreName);
            Console.WriteLine(store.CustomerFoodSelectionNumber);
            // Console.WriteLine(EntryNumber);
            // Console.WriteLine(GlobalNumber);
            //  while (true){
                Console.WriteLine("==================="); //skipping a line
                Console.WriteLine("===================");
                // Console.WriteLine("Play a round With RoBo? (y/n) ");
                if(EntryNumber == 1){
                // Console.WriteLine("Choose From Our Selection Here");
                store.FoodStoreMarket(FoodRecords);
            //      Console.WriteLine(store.CustomerName);
            // Console.WriteLine(store.CustomerActionNumber);
            // Console.WriteLine(store.StoreName);
            // Console.WriteLine(store.CustomerFoodSelectionNumber);

            BackToMainMenu = true;
            EntryName = null;
            // MainIntroDuction();
            goto FIRSTLOOP;
            //Need better logic because the method does loop back but it ends the program
            //^^ dont call this back but make a if statmetn back to the original "MainIntroDuction()"
            // Console.WriteLine("Anythinng Else You Need");
            // string? Choose = null;
            // int 
            //    while (Choose == null || Choose.Length <= 0 )
            // {
                 
            //     Thread.Sleep(1000);
            //     Console.Write("1.\t Food Store,\n2.\t Shoe Store\n");
            //     Choose = Console.ReadLine();
            //     bool validchoice = int.TryParse(Choose, out EntryNumber);
            //     if (!validchoice || (EntryNumber > 4 && EntryNumber < 0) )
            //     {
            //         Console.WriteLine("Thats not the right store");
            //         Console.WriteLine();
            //         Choose=null;
            //         continue;
            //     }
            // }
            // break;
            } else if(EntryNumber == 2){
                // Console.WriteLine("What Are You Trying To Sell?");
                store.ShoeStoreMarket();
                 Console.WriteLine(store.CustomerName);
            Console.WriteLine(store.CustomerActionNumber);
            Console.WriteLine(store.StoreName);
             BackToMainMenu = true;
             EntryName = null;
            // MainIntroDuction();
            //^^ dont call this back but make a if statmetn back to the original "MainIntroDuction()"
            // break;
            } else if(EntryNumber == 3){
                Console.WriteLine("YOu Left The Block");
                // break;
            }

                // string? Input = Console.ReadLine();

                // if (Input?.ToLower() != "y" || Input == null) { 
                //     Console.WriteLine("&&&& END OF GAME &&&&");
                //     break; 
                //     }

                // game.PlayRound();
            // }
            }
            }
        }

        // private static int ChooseAction(){
        //     int choice = 0;
        //     Console.WriteLine("choose 0 to quit,\n 1 to add a item,\n 2 to add to cart,\n 3 for checkout");
        //     choice = int.Parse(Console.ReadLine());
        //     return choice;
        // }

// public void SQLConnection(){
//     using SqlConnection TheBlockDatabase = new(ConnectionString);
//     // TheBlockDatabase.
//     string commandText = "SELECT * FoodStore";
//     SqlCommand command = new(commandText, TheBlockDatabase);
//     using SqlDataReader reader = command.ExecuteReader();
//     while (reader.Read()){
//         int ID = reader.GetInt32(0);
//         string name = reader.GetString(1);
//         Console.WriteLine($"\"{ID}\" with {name}");
//     }
// // }
//  private static void WriteRecordsToFile(FoodStoreInventory store, string FilePath){
//         /*      ^^^^^^
//         Use the static modifier to declare a static 
//         member, which belongs to the type itself 
//         rather than to a specific object. 
//         */
//         string AlmostXML = store.SerializeAsXml();
//         File.WriteAllText(FilePath, AlmostXML);
//         }
    private static List<FoodStore>? ReadOrdersFromFoodStore(string FilePath){
        XmlSerializer Serializer = new(typeof(List<Serialization.StoreUpdate>));
    try{
       using StreamReader Reader = new(FilePath);
        //  List<Record> Records = (List<Record>?)Serializer.Deserializer(Reader);
         var Orders = (List<Serialization.StoreUpdate>?)Serializer.Deserialize(Reader);
          if (Orders is null) throw new InvalidDataException();
                return Orders.Select(x => x.CreateOrder()).ToList();
    }
    catch (System.Exception)
    {
        
        return null;
    } 
        }
    // private static List<ShoeStore>? ReadOrdersFromShoeStore(string FilePath){
    //     XmlSerializer Serializer = new(typeof(List<Serialization.StoreUpdate>));
    // try {
    //         using StreamReader Reader = new(FilePath);
    //             //  List<Record> Records = (List<Record>?)Serializer.Deserializer(Reader);
    //             var Orders = (List<Serialization.StoreUpdate>?)Serializer.Deserialize(Reader);
    //             if (Orders is null) throw new InvalidDataException();
    //             return Orders.Select(x => x.CreateOrder()).ToList();
    //     }
    // catch (System.Exception)    {
    //     return null;
    //     } 
    // }

    private static void MainIntroDuction(){
        if(BackToMainMenu == false){
        Console.WriteLine("\tWelcome To The Block\n\n\tWhat Store Do You Want?");
        } else {
            Console.WriteLine("\tWelcome Back To Da Block\n\n\tA New Store?");
            // Console.WriteLine("\nLeave The Block?");
        }
            // while (EntryName == null || EntryName.Length <= 0)
            // {
            // Thread.Sleep(3000);
            // EntryName = Console.ReadLine();
            // }
              while (EntryName == null || EntryName.Length <= 0 )
            {
                Thread.Sleep(1000);
                Console.Write(" 0.\t To Leave The Block\n 1.\t Food Store\n2.\t Shoe Store\n3.\t To Leave The Block");
                EntryName = Console.ReadLine();
                bool validchoice = int.TryParse(EntryName, out EntryNumber);
                if (!validchoice || (EntryNumber > 4 && EntryNumber < 0) )
                {
                    Console.WriteLine("Thats not the right store");
                    Console.WriteLine();
                    EntryName=null;
                    continue;
                }
                // if(validchoice){
                //     EntryName = null;
                //     EntryNumber = 0;
                //     string? input = null;
                //     //print all customer reciepts
                //     Console.WriteLine("\nLeave The Block? (Y/N)");
                //     input = Console.ReadLine();
                //     if(input?.ToLower() == "y"){
                //         break;
                //     } else {
                //         BackToMainMenu = false;
                //         continue;
                //     }
                // }
            }
    }

    }
}