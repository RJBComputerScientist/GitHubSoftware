using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Serialization;
// using StoreAppLibrary.Logic;
using Xml = StoreAppLibrary.Logic.Serialization;
/*  ==== NOTES ====
You cannot, because IEnumerable<T> does not necessarily represent a collection to which items can be added. In fact, it does not necessarily represent a collection at all! For example:

IEnumerable<string> ReadLines()
{
     string s;
     do
     {
          s = Console.ReadLine();
          yield return s;
     } while (!string.IsNullOrEmpty(s));
}

IEnumerable<string> lines = ReadLines();
lines.Add("foo") // so what is this supposed to do??
What you can do, however, is create a new IEnumerable object (of unspecified type), which, when enumerated, will provide all items of the old one, plus some of your own. You use Enumerable.Concat for that:

 items = items.Concat(new[] { "foo" });
This will not change the array object (you cannot insert items into to arrays, anyway). But it will create a new object that will list all items in the array, and then "Foo". Furthermore, that new object will keep track of changes in the array (i.e. whenever you enumerate it, you'll see the current values of items).

*/

namespace StoreAppLibrary.Logic
{
    public class FoodStoreInventory : StoreInterface
    {
        private List<Product[]>? FoodItems { get; set; }
        private List<Product>? _ShoppingList;
        // public List<Product>? ShoppingList
        // {
        //     get
        //     {
        //         //^^ not the same type
        //         //^^ so when adding and removing from this list its not correct logic and syntax wise
        //         return _ShoppingList;
        //     }
        //     set
        //     {
        //         this._ShoppingList = value;
        //     }
        // }
        public List<Product>? ShoppingList = new List<Product>();
       private List<Product>? _CustomerOwnedItems;
        // public List<Product> CustomerOwnedItems
        // {
        //     get
        //     {
        //         //ITEMS THAT THE CUSTOMER BOUGHT
        //         return _CustomerOwnedItems;
        //     }
        //     set
        //     {
        //         this._CustomerOwnedItems = value;
        //     }
        // }
        // private List<FoodStoreInventory> _CustomerOwnedItems;
        // public List<FoodStoreInventory> CustomerOwnedItems
        // {
        //     get
        //     {
        //         //ITEMS THAT THE CUSTOMER BOUGHT
        //         return _CustomerOwnedItems;
        //     }
        //     set
        //     {
        //         this._CustomerOwnedItems = value;
        //     }
        // }
         List<Product> CustomerOwnedItems = new List<Product>();
     
        private String? _Name;
        private String? _Type;
        private int _Price;
        public string? Name
        {
            get
            {
                return _Name;
            }
            set
            {
                this._Name = value;
            }
        }
        public string Type
        {
            get
            {
                return _Type;
            }
            set
            {
                this._Type = value;
            }
        }
        public int Price
        {
            get
            {
                return _Price;
            }
            set
            {
                this._Price = value;
            }
        }
        /*
                Product A  = new Product("Yum Yum", "cat food", 10.00M);
                Product B = new Product("Pasta", "carbohydrates", 20.00M);
                Product C = new Product("Cake", "dessert", 7.99M);
                Product D = new Product("Dragon Fruit", "Fruit", 5.99M);
                Product E = new Product("Waffles", "Breakfast", 8.99M);
        */
        // private IEnumerable<Product> _FoodList;
        private List<Product>? _FoodList;
        private bool BackToStoreMenu = false;
        private string? CustomerName;
        internal int CustomerActionNumber = 0;
        private DateTime Date;
        private string? _Description;
        public string? Description {
            get {
                return _Description;
            }
            set {
                this._Description = value;
            }
        }
        // private decimal _Total;
        // public decimal? Total {
        //     get {
        //         return _Total;
        //     }
        // }
        // private string ConnectionString = File.ReadAllText("/Users/kingbrooks/desktop/ProjectZero.rtf"); 
        //                                                                                   ^^^^ cant be a rtf
            public FoodStoreInventory(DateTime date, string description, List<Product>? AllOrders = null, List<Product>? foodlist = null){
                this.Date = date;
                this.Description = description;
                if(AllOrders != null){
                    this.CustomerOwnedItems = AllOrders;
                }
                if(foodlist != null){
                    this.FoodList = foodlist;
                }
            }
            public XmlSerializer Serializer { get; } = new(typeof(List<Xml.Inventory>));
            List<Product>? FoodInventoryRecords = ReadOrdersFromFoodStore("../FoodInventoryHistory.xml");
        
        // public IEnumerable<Product> FoodList {
        //     get {
        //         yield return new Product {ID = 1, Quantity = 1000, Name = "Cookies",  Type="Desserts", Price=10.00M};
        //         yield return new Product {ID = 2, Quantity = 1000, Name = "Pasta",  Type="carbohydrates", Price=30.00M};
        //         yield return new Product {ID = 3, Quantity = 1000, Name = "Cake",  Type="Desserts", Price=7.99M};
        //         yield return new Product {ID = 4, Quantity = 1000, Name = "Dragon Fruit",  Type="Fruit", Price=5.99M};
        //         yield return new Product {ID = 5, Quantity = 1000, Name = "Waffles",  Type="Breakfast", Price=9.99M};
        //     }
        //     set {
        //         this._FoodList = value;
        //     }
        // }
        //    public List<Product> FoodList {
        //         get {
        //             return _FoodList;
        //         }
        //         set {
        //             this._FoodList = value;
        //         }
        //     }
        public List<Product> FoodList = new List<Product>{
            new Product(1, 1000, "Cookies", "Desserts", 10.00M),
            new Product(2, 1000, "Pasta", "carbohydrates", 30.00M),
            new Product(3, 1000, "Cake", "Desserts", 7.99M),
            new Product(4, 1000, "Dragon Fruit", "Fruit", 5.99M),
            new Product(5, 1000, "Waffles", "Breakfast", 9.99M),
        };
        // void InsertList() {
        //     using SqlConnection connection = new(ConnectionString);
        //     connection.Open();
        //     using SqlCommand command = new($"INSERT ")
        //     foreach(var item in FoodList){

        //     }
        // }
        // public int NumberOfItems {get{
        //     return FoodList.Count
        // }}
        //    public void ShowList(){
        // var ItemsList = new FoodStoreInventory();
        // foreach(Product Item in ItemsList.FoodList){
        //     Console.WriteLine("We Got' " + Item);
        // }
        public void ShowList()
        {
            //^^ might envolve the records as a parameter
            //    FoodList.Add(new Product(1, 1000, "Cookies", "Desserts", 10.00M));
            //    FoodList.Add(new Product(2, 1000, "Pasta", "carbohydrates", 30.00M));
            //    FoodList.Add(new Product(3, 1000, "Cake", "Desserts", 7.99M));
            //    FoodList.Add(new Product(4, 1000, "Dragon Fruit", "Fruit", 5.99M));
            //    FoodList.Add(new Product(4, 1000, "Waffles", "Breakfast", 9.99M));
            // var ItemsList = new FoodStoreInventory();
            // foreach(Product Item in ItemsList.FoodList){
            //     Console.WriteLine("We Got' " + Item);
            // }
            foreach (Product Item in FoodList)
            {
                Console.WriteLine("We Got' " + Item);
            }

            // for(int number = 1; number < ItemsList.FoodList; number++){
            //     Console.WriteLine("What We Got' " + Item);
            // }
            //             foreach(var item in .Select((value, i) => new { i, value }))
            // {
            //     var value = item.value;
            //     var index = item.i;
            // }
        }
        public int NumberOfFood()
        {
            return FoodList.Count();
        }
        public int QuantityOfFood(int number)
        {
            var a = 0;
            foreach (var item in FoodList)
            {
                // FoodList.ForEach(r => {
                // if(item.Quantity > r.Quantity){
                //     // return false;
                //     Console.WriteLine("We Dont Have That");
                //     a = 0;
                // } else {
                // }
                // });
                //  a = item.Quantity;
                if (number > item.Quantity)
                {
                    Console.WriteLine("We Dont Have That");
                    a = 0;
                }
                else if (number < item.Quantity)
                {
                    Console.WriteLine("We Got That");
                    a = item.Quantity;
                }
                else if (number == item.Quantity)
                {
                    Console.WriteLine("This Is Our Last Supply");
                    a = item.Quantity;
                }
                //    return a;
            }
            return a;
        }
        //substract from yield Quantity and add entire object to customer list
        //ListName.Count for total Items
        //var result = firms.Except(trackedFirms); // returns all the firms except those in trackedFirms

        // public void TakeFood(IEnumerable<Product> product, List<Product> CustomerList){
        // public void TakeFood(int Selection, List<Product> CustomerList){
        // public void TakeFood(int Selection, int PickedQuantity, List<Product> CustomerList){
        public void TakeFood(int Selection, int PickedQuantity)
        {
            //if the name is the same as the customer item than you plus one that items quantity (DONE)
            //substract from quantity if customer has the item or not (DONE)
            //if customer doenst have the item add the entire item as is (DONE)
            // var l = product.GetEnumerator().Current.Quantity;
            // var l = product.GetEnumerator().Current.Quantity;

            //      IDEAS
            // create ids for each product and have user put in a number and check if number matches that id
            //^^ than thats their product than look at the quantity subsstract from it
            //^^^ than check to see if user have that whole item, if customer doesnt add whole item
            //^^^^ if they dont add quantity
            Product? SelectedItem = null;
            //   foreach (var item in ShoppingList)
            // //adding to the list
            // {
            //     Product? UpdatedItem = null;
            //     // Console.WriteLine(ShoppingList);
            //     //^^ not showing when nothing is added
            //     if(Selection == item.ID && item.Quantity >= 1){
            //         Console.WriteLine("I Have SOmething in here");
            //         item.Quantity += 1;
            //         UpdatedItem = item;
            //     } else {
            //         Console.WriteLine("I Have Nothing In here");
            //     }
            //         Console.WriteLine(item);
            //     //THE ITEM .... NOT THE LIST

            // }
            // List<Product> FoodListTOLIST = FoodList.ToList();
            //^ not sure if its working

            //   var newlist = FoodList.Select(point => {
            //         point.Quantity = 1;
            //         return point;
            //     }).ToList();
            //^^ works but might be a better way

            // foreach (var item in FoodList)
            // //for the list here
            // {
            //     // FoodList.ForEach(a => a.Quantity -= 1);
            //     //^^ not here
            //     if (Selection == item.ID)
            //     {
            //         // FoodList.ForEach(a => a.Quantity -= 1);
            //         //^^ not here
            //         if (CustomerList.Contains(item))
            //         {
            //             // item.Quantity -= 1;
            //             item.Quantity -= Selection;
            //             // FoodList.ForEach(a => {
            //             // if(a.ID == item.ID){
            //             // }
            //             // });
            //             // item.Quantity += 1;
            //             // SelectedItem = item;
            //             CustomerList.ForEach(d =>
            //             {
            //                 if (d.ID == item.ID)
            //                 {
            //                     // item.Quantity += 1;
            //                     // d.Quantity += 1;
            //                     d.Quantity += Selection;
            //                 }
            //             });
            //         }
            //         else
            //         {
            //             // FoodList.ForEach(a =>
            //             // {
            //             //     if (a.ID == item.ID)
            //             //     {
            //             //     }
            //             // });
            //                     // item.Quantity -= 1;
            //                     item.Quantity -= Selection;

            //             // item.Quantity += 1;
            //             // item.Quantity = 1;
            //             CustomerList.ForEach(d => {
            //                 if(d.ID == item.ID){

            //                     // d.Quantity += 1;
            //                     // SelectedItem = item;
            //                 }
            //             });
            //             // item.Quantity = 1;
            //             // SelectedItem = item;
            //             // CustomerList.Add(SelectedItem);
            //             CustomerList.Add(new Product(item.ID, Selection, item.Name, item.Type, item.Price));
            //             Console.WriteLine("NEW ITEM");

            //         }
            //         // FoodList.ForEach(a => a.Quantity -= 1);
            //         //^^ not here

            //     }

            //     Console.WriteLine(item);
            // }
            //  FoodList.ForEach(a => {
            //             // Console.WriteLine(a);
            //         if(a.ID == Selection){
            //             // a.Quantity -= 1;
            //             a.Quantity -= Selection;
            //             // SelectedItem = 
            //         }
            //         });
            //             // item.Quantity += 1;
            //     // item.Quantity = 1;
            //     CustomerList.ForEach(d => {
            //             Console.WriteLine(d);
            //         if(d.ID == Selection){
            //             // d.Quantity += 1;
            //             // SelectedItem = d;
            //         }
            //     });
            // FoodList.Where(w => w.ID == Selection).ToList().ForEach( x => {
            //     if(CustomerList.Contains(x)){
            //         x.Quantity += 1;
            //         FoodList.ForEach(c => {
            //             if(c.ID == Selection){
            //                 c.Quantity -= 1;
            //             }
            //         });
            //     } else {
            //         SelectedItem = x;
            //     }
            // });
            var CustomerItem = new Product(0, 0, "", "", 0);
            foreach (var item in FoodList)
            //for the list here
            {
                
                Console.WriteLine("Inside for each loop");
                // FoodList.ForEach(a => a.Quantity -= 1);
                //^^ not here
                if (Selection == item.ID)
                {
                    Console.WriteLine("item IS THE SAME as selection");
                    // FoodList.ForEach(a => a.Quantity -= 1);
                    //^^ not here
                    // foreach(var g in CustomerList){
                    //cant do nested foreach in C#
                    // Console.WriteLine("SECOND FOR EACH");
                    var CompareCustomerList = ShoppingList.Exists(x => x.ID == Selection);
                    // var FIrstItem = ShoppingList.First(c => c.ID == Selection);
                    if (CompareCustomerList)
                    {
                        // CustomerList.Where(x => {
                        //     if(x.ID == item.ID){
                        //          Console.WriteLine("I Have this");
                        // // item.Quantity -= 1;
                        // item.Quantity -= PickedQuantity;
                        // x.Quantity += PickedQuantity;
                        // return true;
                        //     } else {
                        //                   item.Quantity -= PickedQuantity;
                        // CustomerItem.ID = item.ID;
                        // CustomerItem.Quantity += PickedQuantity;
                        // CustomerItem.Name = item.Name;
                        // CustomerItem.Type = item.Type;
                        // CustomerItem.Price = item.Price;   
                        // // CustomerList.Add(new Product(item.ID, Selection, item.Name, item.Type, item.Price));
                        // CustomerList.Add(CustomerItem);
                        // Console.WriteLine("NEW ITEM");
                        // return false;
                        //     }

                        // });
                        //^^^ not this way .. it doenst work
                        Console.WriteLine("Seems Like You Got This Product\n");
                        // item.Quantity -= 1;
                        item.Quantity -= PickedQuantity;
                        // FoodList.ForEach(a => {
                        // if(a.ID == item.ID){
                        // }
                        // });
                        // item.Quantity += 1;
                        // SelectedItem = item;
                        // CustomerItem.ID = item.ID;
                        // CustomerItem.Quantity += Selection;
                        // CustomerItem.Name = item.Name;
                        // CustomerItem.Type = item.Type;
                        // CustomerItem.Price = item.Price;
                        ShoppingList.ForEach(d =>
                        {
                            Console.WriteLine("I'll Add It To Your");
                                    // if (d.ID == item.ID)
                                    // {
                                    //     // item.Quantity += 1;
                                    //     // d.Quantity += 1;
                                    //     d.Quantity += PickedQuantity;
                                    // }
                                    if (d.ID == Selection)
                            {
                                Console.WriteLine("Here You Go");
                                        //^^^ this text isnt showing either
                                        // item.Quantity += 1;
                                        // d.Quantity += 1;
                                        d.Quantity += PickedQuantity;
                            }
                        });
                    }
                    else
                    {
                        // FoodList.ForEach(a =>
                        // {
                        //     if (a.ID == item.ID)
                        //     {
                        //     }
                        // });
                        // item.Quantity -= 1;
                        item.Quantity -= PickedQuantity;
                        CustomerItem.ID = item.ID;
                        CustomerItem.Quantity += PickedQuantity;
                        CustomerItem.Name = item.Name;
                        CustomerItem.Type = item.Type;
                        CustomerItem.Price = item.Price;
                        // CustomerList.Add(new Product(item.ID, Selection, item.Name, item.Type, item.Price));
                        ShoppingList.Add(CustomerItem);
                        Console.WriteLine("NEW ITEM");
                    }
                    // FoodList.ForEach(a => a.Quantity -= 1);
                    //^^ not here
                    // }
                }

                Console.WriteLine(item);
            }

            // Console.WriteLine(CustomerItem);
            // item.Quantity = 1;
            // SelectedItem = item;
            // CustomerList.Add(SelectedItem);
            // Console.WriteLine(SelectedItem);
            // List<Product> NewItem = FoodList.ToList();
            Console.WriteLine("==============");
            // ShoppingList.Add(NewItem);
            // ShoppingList.Add(SelectedItem);
            // Console.WriteLine(ShoppingList);
            Console.WriteLine(ShoppingList);
            foreach (var item in ShoppingList)
            {
                Console.WriteLine(item);
            }


        }
        public void RemoveFood(int Selection, int PickedQuantity)
        {
            //if the name is the same as the customer item than you decrement that items quantity
            //substract from quantity of customer list and add quantity to foodlist
            //The customer not haveing the item is handled already (DONE)
            // var l = product.GetEnumerator().Current.Quantity;
            // var l = product.GetEnumerator().Current.Quantity;

            var CustomerItem = new Product(0, 0, "", "", 0);
            foreach (var item in FoodList)
            {
                //BASE THE BUSINESS LOGIC ON REALISM, The item
                Console.WriteLine("Inside for each loop");

                if (Selection == item.ID)
                {
                    Console.WriteLine("item IS THE SAME as selection");
                    var CompareCustomerList = ShoppingList.Exists(x => x.ID == Selection);
                    if (CompareCustomerList)
                    {
                    var FIrstItem = ShoppingList.First(c => c.ID == Selection);
                        Console.WriteLine("Seems Like You Got This Product\n");
                        item.Quantity += PickedQuantity;

                        // ShoppingList.ForEach(d =>
                        // {
                        //     Console.WriteLine("I'll Delete It To Your");
                        //     if (d.ID == Selection)
                        //     {
                        //         d.Quantity -= PickedQuantity;
                        //     if(d.Quantity == 0){
                        //         Console.WriteLine("Your Producted was deleted");
                        //     }
                        //     }
                        //         ShoppingList.Remove(d);
                        // });
                        // Product? TheItem = null;
                        // foreach (var CartItem in ShoppingList)
                        // {
                            Console.WriteLine("I'll Delete It To Your");
                            // if (FIrstItem.ID == Selection)
                            // {
                            //     TheItem = CartItem;
                                
                                // if(CartItem.Quantity == 0){
                                //     ShoppingList.Remove(CartItem);
                                //     Console.WriteLine("Your Producted was deleted");
                                // }
                            // }
                        // }
                           FIrstItem.Quantity -= PickedQuantity;
                        if (FIrstItem.Quantity == 0)
                        {
                            ShoppingList.Remove(FIrstItem);
                            Console.WriteLine("Your Product was deleted");
                        }
                    }
                }

                Console.WriteLine(item);
            }
            Console.WriteLine("==============");
            Console.WriteLine("==============");
            foreach (var item in ShoppingList)
            {
                Console.WriteLine(item);
            }
        }
        public FoodStoreInventory()
        {
            FoodItems = new List<Product[]>();
            ShoppingList = new List<Product>();
            //^^ creates a new type of list
        }
        // public FoodStoreInventory(List<Product> UserList)
        // {
        //     FoodItems = new List<Product[]>();
        //     this.ShoppingList = UserList;
        //     //^^ creates a new type of list
        // }
        // public FoodStoreInventory(DateTime date, CustomerChoice customer, StoreInventory inventory){
        //     this.Date = date;
        //     this.Customer = customer;
        //     this.Inventory = inventory;
        // }

        // public CustomerChoice CustomerOrder(){
        //     Random random = new();
        //     return (CustomerChoice)random.Next(3);
        //     //^^ possible for employee to randomly react or make new logic for employee
        // }

        // public decimal CheckOut(){
        public void CheckOut()
        {
            /*
                               NOTES 
           THE FOREACH is good to multiple each quantity to its price,
           than push all of those prices in an array and up the array
           (DONE)

           Before adding up the total, ask the user if they want to remove any items

           Its Good to use the records logic here
           will probably eventually use the database
           */
           
            // Product? CartItem = null;
            // foreach (var item in ShoppingList)
            // {

            //     CartItem = item;
            // }
            //^use the "First" instance method like from the remove function.
            //^^ so not the foreach loop. use more C# .NET funcitons
            // using SqlConnection connection = new(ConnectionString);
            TRYAGAIN:
                {
                    string? AnswerString = null;
                    while (AnswerString == null || AnswerString.Length <= 0)
                    {
                        Console.WriteLine("≈≈ Would You Like To Remove Any Item??\n≈≈ Before Purchase??\nENTER (y/n)");
                        AnswerString = Console.ReadLine();
                        if (AnswerString?.ToLower() != "y" && AnswerString?.ToLower() != "n")
                        {
                            Console.WriteLine("JUST TYPE Y OR N..!!!!!");
                            Console.WriteLine("ITS JUST A CONSOLE APP JEEZZZ");
                            AnswerString = null;
                            // goto TRYAGAIN;
                        }
                        else if (AnswerString?.ToLower() == "n")
                        {
                            break;
                        }
                        else
                        {
                        // Console.WriteLine($"{AnswerString}???\nHA LETS TRY AGAIN");
                        // AnswerString = null;
                        // goto TRYAGAIN;
                        ONE_MORE_TIME:
                            {
                                string? RemovalString = null;
                                int RemovalNumber = 0;
                                string? NameOfProduct = null;
                                while (RemovalString == null || RemovalString.Length <= 0)
                                {
                                    Console.WriteLine("µµµ WHICH ITEM DO YOU WANT TO REMOVE? µµµ");
                                    RemovalString = Console.ReadLine();
                                    bool RemovalCHeck = int.TryParse(RemovalString, out RemovalNumber);
                                    var CartItemExists = ShoppingList.Exists(x => x.ID == RemovalNumber);
                                    // var CartItem = ShoppingList.First(x => x.ID == RemovalNumber);
                                    //^^ Made "First" method 
                                    // if (RemovalNumber == CartItem.ID)
                                    // {
                                    //     NameOfProduct = CartItem.Name;
                                    // }
                                    // else
                                    // {
                                        // Console.WriteLine("Thats Not A Product You Got On Ya!");
                                        // RemovalString = null;
                                        // continue;
                                    // }
                                    if(CartItemExists){
                                        var CartItem = ShoppingList.First(x => x.ID == RemovalNumber);
                                        NameOfProduct = CartItem.Name;
                                    } else {
                                        Console.WriteLine("Thats Not A Product You Got On Ya!");
                                        RemovalString = null;
                                        continue;
                                    }
                                QUANTITYRELOOP:
                                    {
                                        string? RemovalQuantityString = null;
                                        int RemovalQuantityNumber = 0;
                                        while (RemovalQuantityString == null || RemovalQuantityString.Length <= 0)
                                        {
                                            Console.WriteLine($"### HOW MANY DO YOU WANT REMOVED FROM {NameOfProduct}");
                                            RemovalQuantityString = Console.ReadLine();
                                            bool QuantityCheck = int.TryParse(RemovalQuantityString, out RemovalQuantityNumber);
                                            // if (RemovalNumber == CartItem.ID)
                                            var CartItem = ShoppingList.First(x => x.ID == RemovalNumber);
                                            //^^ THIS HELPS GET A NEW REFERENCE OF THE CARTITEM
                                            if (CartItemExists)
                                            {
                                                if (!QuantityCheck || (CartItem.Quantity < RemovalQuantityNumber || 0 > RemovalQuantityNumber))
                                                {
                                                    Console.WriteLine("Aye We DOnt wanna be scammed here..\t..DO YOU????\nYOU HAVE"+CartItem.Quantity+"FOR THIS ITEM");
                                                    RemovalQuantityString = null;
                                                }
                                                else
                                                {
                                                    RemoveFood(RemovalNumber, RemovalQuantityNumber);
                                                    string? input = null;
                                                    Console.WriteLine("∑∑∑ Would You Like To Remove AnyOther Items ∑∑∑");
                                                    Console.WriteLine("††† Y for YES & N for NO †††");
                                                    input = Console.ReadLine();
                                                    if (input?.ToUpper() == "N")
                                                    {
                                                        break;
                                                    }
                                                    else if (input?.ToUpper() == "Y")
                                                    {
                                                        if(ShoppingList.Count() == 0){
                                                        Console.WriteLine("YOU AINT GOT NOTHING TO RETURN");
                                                            goto TRYAGAIN;
                                                    }

                                                        goto ONE_MORE_TIME;
                                                    }
                                                    else
                                                    {
                                                        goto TRYAGAIN;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            // connection.Open();
            string description = "";
            decimal QuantityTimesPrice = 0;
            decimal totalCost = 0;
            string both = "";
            Product? Items = null;
            foreach (var item in ShoppingList)
            {
                Console.WriteLine("FOREACH WENT THROUGH");
                if (item.Price >= 25.00M)
                {
                    Console.WriteLine("OH MY!! Do You Want A Coupon");
                    var CompareCustomerList = ShoppingList.Exists(x => x.ID == 0);
                    if (CompareCustomerList)
                    {
                        Console.WriteLine("See you got dem COokies\n");
                        Console.WriteLine("....Aye Let get a Cookie");
                        // item.Quantity -= 1;
                    }
                    else
                    {
                        Console.WriteLine("NIce Food Selection");
                    }
                    // FoodList.ForEach(a => a.Quantity -= 1);
                    //^^ not here
                    // }
                }
                
                /*
                                        NOTES 
                    THE FOREACH is good to multiple each quantity to its price,
                    than push all of those prices in an array and up the array
                    (DONE)
                */
                description = item.ToString();
                //              ^^^^ Product String
                // totalCost = (item.Quantity*item.Price);
                QuantityTimesPrice = (item.Quantity * item.Price);
                //^^ solved the adding up total cost
                // totalCost += (QuantityTimesPrice*0.7M);
                //^^ i should round this
                totalCost += Math.Round((QuantityTimesPrice / 0.7M), 2);
                //^^ solved the adding up total cost
                // Console.WriteLine(description);
                both = description+"\n"+totalCost;
                Console.WriteLine("∞∞∞ YOUR TOTAL IS.... ∞∞∞");
                Console.WriteLine(totalCost);
                Console.WriteLine(both);
            // AddCheckOutResult(item);
            Items = item;
            }
            // AddCheckOutResult(description);
            AddCheckOutResult(Items);
            FoodStoreInventory FoodStoreAdjustmet = new(DateTime.Now, both, FoodInventoryRecords, FoodList);
            // FoodSummary();
            WriteOrdersToFile(FoodStoreAdjustmet, "../FoodInventoryHistory.xml");
            //^^ adding is finr but reading needs to be adjusted
            Console.WriteLine("==============");
            Console.WriteLine("\nYOUR ORDER DESCRIPTION\n");
            foreach (var item in ShoppingList)
            {
                Console.WriteLine(item);
            }
            // ShoppingList.Clear();
        }
         public string SerializeAsXml()
        {
            var XmlOrder = new List<Xml.Inventory>();

            // foreach (FoodStoreInventory order in CustomerOwnedItems)
            foreach (Product order in CustomerOwnedItems)
            {
                XmlOrder.Add(new Xml.Inventory
                {
                    // OrderDate = order.Date,
                    // description = order.Description,
                    // CustomerChange = order.CustomerOwnedItems.ToString(),
                    ProductID = order.ID,
                    ProductQuantity = order.Quantity,
                    ProductName = order.Name,
                    ProductType = order.Type,
                    ProductPrice = order.Price,
                    // FoodQuantity = order.ShoppingList.ToList(),
                    // FoodName = order.ShoppingList.ToList(),
                    // InventoryChange = order.CustomerOwnedItems,
                    // InventoryChange = order.FoodList.ToString(),
                    // InventoryChange = order.FoodList.ToList(),
                    // InventoryChange = order,
                    // Result = order.Result.ToString()
                });
            }

            var StringWriter = new StringWriter();
            Serializer.Serialize(StringWriter, XmlOrder);
            StringWriter.Close();
            // return DateTime.Now+StringWriter.ToString();
            return StringWriter.ToString();
        }
         private void WriteOrdersToFile(FoodStoreInventory store, string FilePath){
        /*      ^^^^^^ this write is to FoodHistory
        Use the static modifier to declare a static 
        member, which belongs to the type itself 
        rather than to a specific object. 
        */
        // string AlmostXML = store.SerializeAsXml();
        // File.WriteAllText(FilePath, AlmostXML);
        // FoodStoreInventory.
        // File.WriteAllText(FilePath, SerializeAsXml());
        //^^ cant do it this way in C#
        File.WriteAllText(FilePath, SerializeAsXml());
        }
        private CustomerChoice Customer;
        public TransactionResult Result => ConfirmTransaction(Customer);
 private static TransactionResult ConfirmTransaction(CustomerChoice Customer){
            return (Customer) switch {
                (CustomerChoice.Buy) => TransactionResult.Confirmed,
                (CustomerChoice.Complain) => TransactionResult.Deined,
                (CustomerChoice.Sell) => TransactionResult.Return,
                _ => throw new InvalidOperationException(),
            };
        }

        //   private void AddCheckOutResult(string Description){
          private void AddCheckOutResult(Product Products){
              //                ^^^ the add chekcout result should add the resulting 
            // var CheckOutResult = new FoodStore(DateTime.Now, Customer);
            // var CheckOutResult = new FoodStoreInventory(DateTime.Now, Description);
            var CheckOutResult = new Product(Products.ID, Products.Quantity, Products.Name,
            Products.Type, Products.Price);
            // FoodStoreHistory.Add(CheckOutResult);
            CustomerOwnedItems.Add(CheckOutResult);
            // Console.WriteLine($"This is your order history {CheckOutResult.Date}\n{CheckOutResult}");
            Console.WriteLine($"This is your order history \n{CheckOutResult}");
        }
        private static List<Product>? ReadOrdersFromFoodStore(string FilePath){
        XmlSerializer Serializer = new(typeof(List<Serialization.Inventory>));
    try{
       using StreamReader Reader = new(FilePath);
        //  List<Record> Records = (List<Record>?)Serializer.Deserializer(Reader);
         var Orders = (List<Serialization.Inventory>?)Serializer.Deserialize(Reader);
          if (Orders is null) throw new InvalidDataException();
                return Orders.Select(X => X.CreateOrder()).ToList();
    }
    catch (System.Exception)
    {
        
        return null;
    } 
        }

        public void FoodSummary()
        //^^ summary is for the customer
        {
            var Summary = new StringBuilder();
            // Summary.AppendLine($"Date\t{CustomerName}\t\tFood\t\tTransaction");
            Summary.AppendLine($"{CustomerName}\t\tFood\t\tTransaction");
            Summary.AppendLine("-----------------------------------------------------------------------------------------");
            foreach (var order in CustomerOwnedItems)
            {
                // Summary.AppendLine($"{order.Date}\t{order.Name}\t{order}\t");
                Summary.AppendLine($"\t{order}\t");
            }
            Summary.AppendLine("-----------------------------------------------------------------------------------------");
            
            Console.WriteLine(Summary.ToString());
        }

       

        /// <summary>
        ///Overrided ToString() method
        /// CUSTOM FOR FOOD STORE
        /// </summary>

        public override string ToString()
        {
            string Description = "";
            foreach (var item in ShoppingList)
            {
                // Description += "Name: " + item.Name + " " + "Type: " + item.Type + "\n";
                 Description = "Name: " + item.Name + " " + "Type: " + item.Type + "\n";
                //  Description +="Quantity: "+item.Quantity + "Name: "+item.Name + " " + "Type: " + item.Type+"\n";
                //  ^^ this would be wrong because it will return the total quantity
            }
            // ShoppingList.Clear();
            return Description;
        }
        public void IntroDuction(bool BackToStoreMenu)
        {

            string? MyName = null;

            if (BackToStoreMenu == false)
            {
                Console.WriteLine($"AYE!! What was ya name again? I got short term memory");
                MyName = Console.ReadLine();
                this.CustomerName = MyName;
                Console.WriteLine($"OH!! Welcome {CustomerName}, Here Is Yo' CHoices");
                Console.WriteLine($" 0.\t Back To Main Menu,\n 1.\t {(CustomerChoice)(0)},\n 2.\t {(CustomerChoice)(1)}\n 3.\t {(CustomerChoice)(2)}\n 4.\t {(CustomerChoice)(3)}\n");
            }
            else
            {
                Console.WriteLine($"Hey {CustomerName}, Is There Anything Else You Need?");
                Console.WriteLine($" 0.\t Back To Main Menu,\n 1.\t {(CustomerChoice)(0)},\n 2.\t {(CustomerChoice)(1)}\n 3.\t {(CustomerChoice)(2)}\n 4.\t {(CustomerChoice)(3)}\n");
                // MyName = Console.ReadLine();
            }

        }
//         public void SQLConnection(){
//     using SqlConnection TheBlockDatabase = new(ConnectionString);
//     // TheBlockDatabase.
//     string commandText = "SELECT * FoodStore";
//     SqlCommand command = new(commandText, TheBlockDatabase);
// }
    }
}