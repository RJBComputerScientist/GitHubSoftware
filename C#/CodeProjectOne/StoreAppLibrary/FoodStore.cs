namespace StoreAppLibrary.Logic{
    public class FoodStore {
        public CustomerChoice Customer { get; }
        private StoreInventory Inventory { get; }

        /*
            could make properties that make up a product here
        */
        // private List<Product>? FoodItems {get; set;}
        //^^ using the interface instead of putting it here
        // private List<Product>? ShoppingList {get; set;}
        //^^ using the interface instead of putting it here
        //^^ 
        public DateTime Date { get; }
        // public TransactionResult Result => ConfirmTransaction(Customer, Inventory);
        //^^ old one
        public TransactionResult Result => ConfirmTransaction(Customer);
        // public FoodStore(){
        //     FoodItems = new List<Product>();
        //     ShoppingList = new List<Product>();
        //     //^^ creates a new type of list
        // }
        //^^ using the interface instead of putting it here
        // public FoodStore(DateTime date, CustomerChoice customer, StoreInventory inventory){
        //     this.Date = date;
        //     this.Customer = customer;
        //     this.Inventory = inventory;
        // }
        //^^ old one
        public FoodStore(DateTime date, CustomerChoice customer){
            //^^ using food store to record customer transaction
            //^^ maybe not
            this.Date = date;
            this.Customer = customer;
            // this.Inventory = inventory;
        }
        public FoodStore(){
            //^^ using food store to record customer transaction
            //^^ maybe not
            this.Date = new DateTime();
            this.Customer = new CustomerChoice();
            // this.Inventory = inventory;
        }
        // internal int Quantity { get; set;}
        // //^^ quantity in total
        // internal string? Name {get; set;}
        // internal string? Type {get; set;}
        // internal decimal Price {get; set;}
        // internal int ID {get; set;}
        // public FoodStore(DateTime date, int ID, int Quantity, string Name, string Type, decimal Price, CustomerChoice customer = 0){
        //     this.Date = date;
        //     this.Customer = customer;
        //     this.Inventory = {ID; Quantity}
        // }

        // private static TransactionResult ConfirmTransaction(CustomerChoice Customer, StoreInventory Inventory){
        //     return (Customer, Inventory) switch {
        //         (CustomerChoice.Buy, StoreInventory.Money) => TransactionResult.Confirmed,
        //         (CustomerChoice.Complain, StoreInventory.Products) => TransactionResult.Deined,
        //         (CustomerChoice.Sell, StoreInventory.Money) => TransactionResult.Return,
        //         _ => throw new InvalidOperationException(),
        //     };
        // }
        private static TransactionResult ConfirmTransaction(CustomerChoice Customer){
            return (Customer) switch {
                (CustomerChoice.Buy) => TransactionResult.Confirmed,
                (CustomerChoice.Complain) => TransactionResult.Deined,
                (CustomerChoice.Sell) => TransactionResult.Return,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}