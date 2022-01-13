using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
// using StoreAppLibrary.Logic;
// using Xml = StoreApp.App.Serialization;
using Xml = StoreApp.App.Serialization;
using System.Data.SqlClient;

/* ============== NOTES ==============
    if the stores name equals 'Food Store' write the history to "../FoodHistory.xml"
    if the stores name equals 'Shoe Store' write the history to "../ShoeHistory.xml"

    -  CONFLICTING CERTAIN TYPE OF CODE IN C# REACT DIFFERENTLY 

*/

namespace StoreAppLibrary.Logic {
    public class Stores {
        List<FoodStore>? FoodStoreHistory = new List<FoodStore>();
        List<FoodStoreInventory>? FoodStoreInventoryHistory = new List<FoodStoreInventory>();
        //^^ FOR XML FILE
        // List<FoodStoreInventory>? FoodStoreInventory = new List<FoodStoreInventory>();
        FoodStoreInventory FoodStoreInventory = new FoodStoreInventory();
        //^^ FOR INVENTORY OF PRODUCTS
        FoodStore FoodStore = new FoodStore();
        List<ShoeStore>? ShoeStoreHistory = new List<ShoeStore>();
        //^^ FOR XML FILE
        List<ShoeStoreInventory>? ShoeStoreInventory = new List<ShoeStoreInventory>();
        // private string ConnectionString = File.ReadAllText("/Users/kingbrooks/desktop/ProjectZero.rtf"); 
        //^^ FOR INVENTORY OF PRODUCTS

        // private readonly StoreInterface Employee;
        private XmlSerializer Serializer { get; } = new(typeof(List<Xml.StoreUpdate>)); 
        private string? _StoreName;
        public string StoreName {
            get {
                return _StoreName;
            }
            set {
                this._StoreName = value;
            }
        }
        internal string? CustomerName;
        internal int CustomerActionNumber = 0;
        internal int CustomerFoodSelectionNumber = 0;
        internal bool BackToStoreMenu = false;
        // internal string? Choose = null;
    /*the stores constructor will take in the type of store they want and 
    each individual method will take the customer name, The Stores History
    after a customer makes a order the reciept is for the customer
    so there will be two seperate serialization
    */
    // static int FoodList = FoodStoreInventory.FoodList.Count();
  
        public Stores(string StoreName){
            this.StoreName = StoreName;
            // this.CustomerName = CustomerName;
        }

        // private void IntroDuction(){
            
        //     string? MyName = null;
            
        //     if(BackToStoreMenu == false){
        //         Console.WriteLine($"AYE!! What was ya name again? I got short term memory");
        //         MyName = Console.ReadLine();
        //         this.CustomerName = MyName;
        //         Console.WriteLine($"OH!! Welcome {CustomerName}, Here Is Yo' CHoices");
        //         Console.WriteLine(" 0.\t Back To Main Menu,\n 1.\t Buy,\n 2.\t Sell\n 3.\t Look\n 4.\t Complain");
        //     } else {
        //         Console.WriteLine($"Hey {CustomerName}, Is There Anything Else You Need?");
        //         Console.WriteLine(" 0.\t Back To Main Menu,\n 1.\t Buy,\n 2.\t Sell\n 3.\t Look\n 4.\t Complain");
        //         // MyName = Console.ReadLine();
        //     }
        //     string? Choose = null;
        //     // string? Choose = Console.ReadLine();
        //     int Customer=0;
        //     while (Choose == null || Choose.Length <= 0 )
        //     {
                
        //         Console.Write("What's your choice? ");
        //         Choose = Console.ReadLine();
        //         bool validchoice = int.TryParse(Choose, out CustomerActionNumber);
        //         if (!validchoice || (CustomerActionNumber > 4 || CustomerActionNumber < 0) )
        //         {
        //             Console.WriteLine("We Dont know What That Is.., Tell Us Again!");
        //             Console.WriteLine();
        //             Choose=null;
        //             CustomerActionNumber = 0;
        //             continue;
        //         }
        //         if(CustomerActionNumber == 0){
        //             Console.WriteLine("Back To Main Menu");
        //             break;
        //         }
        //     }
        //     //^^ local

        //     // UserStringToInt(Choose, "What's your choice? ", "Invalid Choice, Try Again!", CustomerNumberChoice);
        //     // UserStringToInt(Choose, "What's your choice? ", "Invalid Choice, Try Again!");
        //     // UserStringToInt("What's your choice? ", "Invalid Choice, Try Again!");
        //     // Console.WriteLine(GlobalNumber);
        //     //^^ Global .. THE GLOBAL IDEA DOESNT WORK IN C# .NET
        //             // Moves CPUChoice = CPUMoves.DecideMove();
        //     Console.WriteLine();// skipping a line
        //     CustomerChoice CustomerChoice = (CustomerChoice)(CustomerActionNumber - 1);
        //     // CustomerChoice CustomerChoice = (CustomerChoice)(CustomerNumberChoice - 1);
        //     // CustomerChoice CustomerChoice = (CustomerChoice)(GlobalNumber - 1);
        //     // if(CustomerChoice.){

        //     // }
        //     if(CustomerActionNumber == 1){
        //     Console.WriteLine($"What Would You Like To [{CustomerChoice}]?");
        //     } else if(CustomerActionNumber == 2){
        //         Console.WriteLine($"What Are You Trying To [{CustomerChoice}]?");
        //     } else if(CustomerActionNumber == 3){
        //         Console.WriteLine($"What Are You [{CustomerChoice}]ing For?");
        //     } else if(CustomerActionNumber == 4){
        //         Console.WriteLine($"What Are You [{CustomerChoice}]ing About?");
        //     } 
        //     // Console.WriteLine($"The Computer Move Was [{CPUChoice}]");
        //     // OurInventory(CustomerChoice);
        //     // YourRecipet(CustomerChoice);
          
        // }
        
         List<FoodStore>? FoodRecords = ReadOrdersFromFoodStore("../FoodHistory.xml");
        //  List<FoodStoreInventory>? FoodInventoryRecords = ReadOrdersFromFoodStore("../FoodInventoryHistory.xml");
            // List<ShoeStoreInventory>? ShoeRecords = ReadOrderFromShoeStore("../ShoeHistory");
        public void FoodStoreMarket(List<FoodStore>? Records = null){
            //                                ^^^ this shold display the updated inventory when not null
            if(Records != null){
                this.FoodStoreHistory = Records;
            };
            this.StoreName = "Food Store";
            // IntroDuction();
            FoodStoreInventory.IntroDuction(false);
       var EnumLength = Enum.GetNames(typeof(CustomerChoice)).Length;
            A:{
                string? Choose = null;
            // string? Choose = Console.ReadLine();
            int CustomerNUmber=0;
            while (Choose == null || Choose.Length <= 0 )
            {
                
                Console.Write("What's your choice? ");
                Choose = Console.ReadLine();
                bool validchoice = int.TryParse(Choose, out CustomerNUmber);
                if (!validchoice || (CustomerNUmber > EnumLength || CustomerNUmber < 0) )
                {
                    Console.WriteLine("We Dont know What That Is.., Tell Us Again!");
                    Console.WriteLine();
                    Choose=null;
                    // CustomerActionNumber = 0;
                    continue;
                }
                if(CustomerNUmber == 0){
                    Console.WriteLine("Back To Main Menu");
                    break;
                }
                 CustomerChoice CustomerChoice = (CustomerChoice)(CustomerNUmber - 1);
            // Choose = null;
            
            // if(CustomerNUmber == 1){
            
            // } else if(CustomerNUmber == 2){
            //     Console.WriteLine($"What Are You Trying To {CustomerChoice}?");
            // } else if(CustomerNUmber == 3){
            //     Console.WriteLine($"What Are You {CustomerChoice}ing For?");
            // } else if(CustomerNUmber == 4){
            //     Console.WriteLine($"What Are You {CustomerChoice}ing About?");
            // } 
            // Console.WriteLine($"The Computer Move Was [{CPUChoice}]");
            // OurInventory(CustomerChoice);
            // YourRecipet(CustomerChoice);
            if(validchoice){
                
                //  Choose = null;
                //^^ DONT MAKE THE PREVIOUS STRING NULL
             if(CustomerNUmber == 1){
                 Console.WriteLine(Choose);
                 Console.WriteLine($"What Would You Like To {CustomerChoice}?");
                Console.WriteLine("We Only Got One Aisle so");
                 
                 if(Records == null){
                Console.WriteLine($"YOUR AT THE {StoreName}, Check Out Our Food");
                //USE THE FOOD STORE INVENTORY WHEN RECORDS IS NULL START
              B:{
                FoodStoreInventory.ShowList();
                // FoodStoreInventory.
                string? FoodChoice = null;
                int FoodNumberChoice = 0;
                 while (FoodChoice == null || FoodChoice.Length <= 0 )
            {
                Console.Write("What chu tryna eat? ");
                FoodChoice = Console.ReadLine();
                bool Confirmchoice = int.TryParse(FoodChoice, out FoodNumberChoice);
                // if (!validchoice || (CustomerFoodSelectionNumber > 5 || CustomerFoodSelectionNumber < 0) )
                if (!Confirmchoice || (FoodNumberChoice > FoodStoreInventory.NumberOfFood() || FoodNumberChoice < 0) )
                //                                                ^^ better to put amount of objects in foodlist
                {
                    Console.WriteLine("We Dont Have That.. TRY AGAIN!!\n");
                    FoodChoice=null;
                    continue;
                }
                // if(validchoice){
                // FoodStoreInventory.TakeFood(CustomerActionNumber, FoodStoreInventory.ShoppingList);
                // }
                // if(CustomerFoodSelectionNumber == 1){
                //     FoodStoreInventory.ShoppingList.Add(A);
                // } else if(CustomerFoodSelectionNumber == 2){
                //     FoodStoreInventory.ShoppingList.Add(B);
                // } else if(CustomerFoodSelectionNumber == 3){
                //     FoodStoreInventory.ShoppingList.Add(C);
                // }  else if(CustomerFoodSelectionNumber == 4){
                //     FoodStoreInventory.ShoppingList.Add(D);
                // } else if(CustomerFoodSelectionNumber == 5){
                //     FoodStoreInventory.ShoppingList.Add(E);
                // }
                /*
                    In C# code runs from top to bottom in order. so the if statement 
                    was stopping the logic up top
                */
                string? QuantityString = null;
                // Console.WriteLine("How many items do you want");
                int QuantityNumber = 0;
                      while (QuantityString == null || QuantityString.Length <= 0 )
            {
                Console.WriteLine("How many items do you want");
                QuantityString = Console.ReadLine();
                bool Quantitychoice = int.TryParse(QuantityString, out QuantityNumber);
                // if (!validchoice || (CustomerFoodSelectionNumber > 5 || CustomerFoodSelectionNumber < 0) )
                if (!Quantitychoice || (QuantityNumber > FoodStoreInventory.QuantityOfFood(QuantityNumber) || QuantityNumber < 0) )
                //                                                ^^ better to put amount of objects in foodlist
                {
                    Console.WriteLine("We Dont Have That.. TRY AGAIN!!\n");
                    QuantityString=null;
                    continue;
                }
            
                //   if(Confirmchoice){
                  if(Quantitychoice){
                    //   Choose = null;
                    //   FoodChoice = null;
                    //^^ DONT MAKE THE PREVIOUS STRING NULL
                    string? input = null;
                    // FoodStoreInventory.TakeFood(NewNumber, FoodStoreInventory.ShoppingList);
                    // FoodStoreInventory.TakeFood(QuantityNumber, FoodStoreInventory.ShoppingList);
                    // FoodStoreInventory.TakeFood(FoodNumberChoice, QuantityNumber, FoodStoreInventory.ShoppingList);
                    FoodStoreInventory.TakeFood(FoodNumberChoice, QuantityNumber);
                    // FoodStoreInventory.TakeFood(NewNumber);
                    // printFoodInventory(FoodStoreInventory);
                    //^^ NOT USING THIS RIGHT NOW 12/18/21
                    Console.WriteLine("Do you want more before you buy? (Y/N)\nPress Anything else To Go Back");
                    input = Console.ReadLine();
                    if(input?.ToUpper() == "N"){
                        Console.WriteLine("NO RAN");
                        // input = null;
                        // FoodNumberChoice = 0;
                        // QuantityNumber = 0;
                        FoodStoreInventory.CheckOut();
                        AddFoodCheckOutResult(CustomerChoice);
                        //^^ different
                        // FoodStoreInventory foodStoreInventory = new(DateTime.Now, )
                        FoodStoreInventory.FoodSummary();
                        // WriteOrdersToFile(FoodStoreInventory, "../FoodHistory.xml");
                        WriteOrdersToFile(FoodStore, "../FoodHistory.xml");
                        //                                          ^^^ FoodHistory
                        // break;
                    } else if(input?.ToUpper() == "Y"){
                        Console.WriteLine("YES RAN");
                        input = null;
                        // FoodChoice = null;
                        //^^ the string matter since im using those in my while statement 
                        //^^^ better to use labels and the goto keyword
                        //  FoodNumberChoice = 0;
                        //  QuantityNumber = 0;
                        // continue;
                        goto B;
                    } else {
                        Console.WriteLine("SOMETHING ELSE RAN");
                        // FoodNumberChoice = 0;
                        FoodChoice = null;
                        //^^ the string matter since im using those in my while statement 
                        // QuantityNumber = 0;
                        // BackToStoreMenu = true;
                        input = null;
                        
                        // IntroDuction();
                        FoodStoreInventory.IntroDuction(true);
                        //^^ SHOWING THE INTRO TEXT AGAIN
                        goto A;
                        //^^ PROPERLY GOING TO THE START OF MY FIRST WHILE LOOP
                    }
                }
            }
            }
              }
              
                //USE THE FOOD STORE INVENTORY WHEN RECORDS IS NULL END
                 } else {
                     Console.WriteLine("Here Is Our Updated Inventory");
                     Console.WriteLine(Records);
                     Console.WriteLine("Pick Your Food Again");
                 }
                
                
                //USE THE FOOD STORE HISTORY TO RECORD THEIR ORDER START

                //USE THE FOOD STORE HISTORY TO RECORD THEIR ORDER END
            } else if(CustomerNUmber == 2){
                Console.WriteLine("What Are You Trying To Sell?");
            } else if(CustomerNUmber == 3){
                Console.WriteLine("What Are You Looking at?");
            } else if(CustomerNUmber == 4){
                Console.WriteLine("What Are You Complaining about??");
            }

            // if(GlobalNumber == 0){
            //     Console.WriteLine("Choose From Our Selection Here");
            // } else if(GlobalNumber == 1){
            //     Console.WriteLine("What Are You Trying To Sell?");
            // } else if(GlobalNumber == 2){
            //     Console.WriteLine("What Are You Looking at?");
            // } else if(GlobalNumber == 3){
            //     Console.WriteLine("What Are You Complaining about??");
            // }

            }
            }
            }
           
        }
        public void ShoeStoreMarket(List<ShoeStore>? Records = null){
            if(Records != null){
                this.ShoeStoreHistory = Records;
            };
            this.StoreName = "Shoe Store";
        //    IntroDuction();
        FoodStoreInventory.IntroDuction(false);
            // if(GlobalNumber == 0){
            //     Console.WriteLine("Choose From Our Selection Here");
            // } else if(GlobalNumber == 1){
            //     Console.WriteLine("What Are You Trying To Sell?");
            // } else if(GlobalNumber == 2){
            //     Console.WriteLine("What Are You Looking at?");
            // } else if(GlobalNumber == 3){
            //     Console.WriteLine("What Are You Complaining about??");
            // }

        }

        private void AddFoodCheckOutResult(CustomerChoice Customer){
            var CheckOutResult = new FoodStore(DateTime.Now, Customer);
            FoodStoreHistory.Add(CheckOutResult);
            Console.WriteLine($"This is your order history{CheckOutResult.Result}");
        }

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
// }
  public string SerializeAsXml()
        {
            var XmlOrder = new List<Xml.StoreUpdate>();

            // foreach (FoodStoreInventory order in CustomerOwnedItems)
            foreach (FoodStore store in FoodStoreHistory)
            {
                XmlOrder.Add(new Xml.StoreUpdate
                {
                    OrderDate = store.Date,
                    CustomerChange = store.Customer.ToString()
                });
            }

            var StringWriter = new StringWriter();
            Serializer.Serialize(StringWriter, XmlOrder);
            StringWriter.Close();
            // return DateTime.Now+StringWriter.ToString();
            return StringWriter.ToString();
        }
 private void WriteOrdersToFile(FoodStore store, string FilePath){
        /*      ^^^^^^ this write is to FoodHistory
        Use the static modifier to declare a static 
        member, which belongs to the type itself 
        rather than to a specific object. 
        */
        // string AlmostXML = store.SerializeAsXml();
        
        File.WriteAllText(FilePath, SerializeAsXml());
        }
  private static List<FoodStore>? ReadOrdersFromFoodStore(string FilePath){
        XmlSerializer Serializer = new(typeof(List<Xml.StoreUpdate>));
    try{
       using StreamReader Reader = new(FilePath);
        //  List<Record> Records = (List<Record>?)Serializer.Deserializer(Reader);
         var Orders = (List<Xml.StoreUpdate>?)Serializer.Deserialize(Reader);
          if (Orders is null) throw new InvalidDataException();
                return Orders.Select(X => X.CreateOrder()).ToList();
    }
    catch (System.Exception)
    {
        
        return null;
    } 
        }
    // private static List<ShoeStoreInventory>? ReadOrderFromShoeStore(string FilePath){
    //     XmlSerializer Serializer = new(typeof(List<Serialization.Inventory>));
    // try {
    //         using StreamReader Reader = new(FilePath);
    //             //  List<Record> Records = (List<Record>?)Serializer.Deserializer(Reader);
    //             var Records = (List<Serialization.Inventory>?)Serializer.Deserialize(Reader);
    //             if (Records is null) throw new InvalidDataException();
    //             return Records.Select(x => x.CreateOrder()).ToList();
    //     }
    // catch (System.Exception)    {
    //     return null;
    //     } 
    // }
    }
}

