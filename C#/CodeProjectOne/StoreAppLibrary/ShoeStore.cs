namespace StoreAppLibrary.Logic{
    public class ShoeStore {
        private CustomerChoice Customer { get; }
        private StoreInventory Inventory { get; }
        /*
            could make properties that make up a product here
        */
        private DateTime Date { get; }
        public TransactionResult Result => ConfirmTransaction(Customer, Inventory);
        public ShoeStore(DateTime date, CustomerChoice customer, StoreInventory inventory){
            this.Date = date;
            this.Customer = customer;
            this.Inventory = inventory;
        }

        private static TransactionResult ConfirmTransaction(CustomerChoice Customer, StoreInventory Inventory){
            return (Customer, Inventory) switch {
                (CustomerChoice.Buy, StoreInventory.Money) => TransactionResult.Confirmed,
                (CustomerChoice.Complain, StoreInventory.Products) => TransactionResult.Deined,
                (CustomerChoice.Sell, StoreInventory.Money) => TransactionResult.Return,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}