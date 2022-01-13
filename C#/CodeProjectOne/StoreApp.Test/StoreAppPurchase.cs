using System;
using Xunit;
using Xunit.Sdk;

namespace StoreAppLibrary.Test{
    class StoreAppPurchase{
        [Fact]
        public void OrderHistoryTest_WriteOrder(){
            //^^ focus on each piece of code
            var xml = new Logic.Serialization.Receipt{
                CustomerName = "walldo",
                CustomerProduct = "Cake",
                ProductPrice = 40.00,
            };
            try{
               var Order = xml.CreateOrder();
            }
            catch (ArgumentException)
            {
                
                return null;
            }
            throw new XunitException("expected an ArgumentException");
        }
        
    }
}