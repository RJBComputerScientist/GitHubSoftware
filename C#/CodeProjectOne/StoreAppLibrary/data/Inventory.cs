/* [XmlAttribute]
The addition of attribute in XML element gives more precise properties of the element
*/

using System.Xml.Serialization;
using StoreAppLibrary.Logic;

/* ============== NOTES ==============
The null-coalescing operator ?? returns the value 
of its left-hand operand if it isn't null; 
*/

// namespace StoreApp.App.Serialization{
namespace StoreAppLibrary.Logic.Serialization{
    public class Inventory {
        [XmlAttribute]
        // public DateTime OrderDate {get; set;}
        // public List<FoodStoreInventory> InventoryChange {get; set;}
        // public List<Product> CustomerChange {get; set;}
        // public string? Result {get; set;}
        // public string description {get; set;}
        public int ProductID {get; set;}
        public int ProductQuantity {get; set;}
        public string? ProductName {get; set;}
        public string? ProductType {get; set;}
        public decimal ProductPrice {get; set;}

        // public FoodStoreInventory CreateOrder(){
        public Product CreateOrder(){
        //    var customer = (CustomerChoice)Enum.Parse(typeof(CustomerChoice), CustomerChange ?? throw new InvalidOperationException("Player Move Cant Be Null"));
           /*An enumeration type (or enum type) is a value 
           type defined by a set of named constants of the 
           underlying integral numeric type.
           */
        //    var inventory = (TransactionResult)Enum.Parse(typeof(TransactionResult), InventoryChange ?? throw new InvalidOperationException("CPU Move Cant Be Null"));
           //^^^ keeping this out for now.. lill just relate to what the customer chooses
            // return new FoodStore(date: OrderDate, customer: customer, inventory: inventory);
            //^^ old one
            
            // return new FoodStoreInventory(date: OrderDate, description: description, AllOrders: InventoryChange, foodlist: CustomerChange);
            return new Product(id: ProductID, quantity: ProductQuantity, name: ProductName, type: ProductType, price: ProductPrice);
        }
    }
}