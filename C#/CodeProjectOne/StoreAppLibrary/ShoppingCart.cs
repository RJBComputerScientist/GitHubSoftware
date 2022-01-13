using System.Text;
namespace StoreAppLibrary.Logic {
    /// <summary>
    ///This is for making a broad selection of products.
    /// Can be specified to any product.
    /// </summary>

    public class ShoppingCart {
        internal int FoodQuantity { get; set;}
        //^^ quantity in total
        internal string? FoodName {get; set;}
        internal string? FoodType {get; set;}
        internal decimal FoodPrice {get; set;}
        internal int ID {get; set;}

        public ShoppingCart() {
            ID = 0;
            FoodQuantity = 0;
            FoodName = "Nuclear Waste";
            FoodType = "Liquid";
            FoodPrice = 0.00M;
        } 

        public ShoppingCart(int id, int quantity, string name, string type, decimal price){
            this.ID = id;
            FoodQuantity = quantity;
            FoodName = name;
            FoodType = type;
            FoodPrice = price;
        }

        public override string ToString()
        {
            // return base.ToString();
            return "Quantity: "+FoodQuantity+" Name: "+FoodName+" Type: "+FoodType+" Price: "+FoodPrice;
        }
    }
}