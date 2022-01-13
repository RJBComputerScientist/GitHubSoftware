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
namespace StoreApp.App.Serialization{
    public class StoreUpdate {
        [XmlAttribute]
        public DateTime OrderDate {get; set;}
        public string? InventoryChange {get; set;}
        public string? CustomerChange {get; set;}
        public string? Result {get; set;}

        public FoodStore CreateOrder(){
           var customer = (CustomerChoice)Enum.Parse(typeof(CustomerChoice), CustomerChange ?? throw new InvalidOperationException("Customer Cant Be Null"));
           /*An enumeration type (or enum type) is a value 
           type defined by a set of named constants of the 
           underlying integral numeric type.
           */
        //    var inventory = (TransactionResult)Enum.Parse(typeof(TransactionResult), InventoryChange ?? throw new InvalidOperationException("CPU Move Cant Be Null"));
           //^^^ keeping this out for now.. lill just relate to what the customer chooses
            // return new FoodStore(date: OrderDate, customer: customer, inventory: inventory);
            //^^ old one
            return new FoodStore(date: OrderDate, customer: customer);
        }
    }
}