using System.Text;
namespace StoreAppLibrary.Logic {
    /// <summary>
    ///This is for making a broad selection of products.
    /// Can be specified to any product.
    /// </summary>

    public class Product {
        internal int Quantity { get; set;}
        //^^ quantity in total
        internal string? Name {get; set;}
        internal string? Type {get; set;}
        internal decimal Price {get; set;}
        internal int ID {get; set;}

        public DateTime Date;

        public Product() {
            ID = 0;
            Quantity = 0;
            Name = "Nuclear Waste";
            Type = "Liquid";
            Price = 0.00M;
        } 
        public Product(int id, int quantity, string name, string type, decimal price){
            this.ID = id;
            Quantity = quantity;
            Name = name;
            Type = type;
            Price = price;

        }

        public override string ToString()
        {
            // return base.ToString();
            return "Quantity: "+Quantity+" Name: "+Name+" Type: "+Type+" Price: "+Price;
        }
    }
}