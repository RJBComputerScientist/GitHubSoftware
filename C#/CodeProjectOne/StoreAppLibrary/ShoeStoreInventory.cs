namespace StoreAppLibrary.Logic {
    public class ShoeStoreInventory : StoreInterface {
        private List<Product> ShoeItems {get; set;}
        public List<Product> ShoppingList {get; set;}
        public ShoeStoreInventory(){
            ShoeItems = new List<Product>();
            ShoppingList = new List<Product>();
            //^^ creates a new type of list
        }
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
        public void CheckOut(){
            decimal totalCost = 0;
            foreach (var item in ShoppingList)
            {
                totalCost += item.Price;    
            }
            ShoppingList.Clear();
            // return totalCost;
        }
    }
}