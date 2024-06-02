using MoneyFellows.Core.Entities;
using MoneyFellows.Core.VM;

namespace MonetFellows.UnitTest
{
    public class OrderTests
    {
        [Fact]
        public void Order_Constructor_Should_Initialize_Properties_Correctly()
        {
            // Arrange
            var creatorUserId = Guid.NewGuid();
            var deliveryAddress = "123 Main St";
            var deliveryTime = DateTime.Now;
            var userId = Guid.NewGuid();

            // Act
            var order = new Order(creatorUserId, deliveryAddress, deliveryTime, userId);

            // Assert
            Assert.Equal(creatorUserId, order.CreatorUserId);
            Assert.Equal(deliveryAddress, order.DeliveryAddress);
            Assert.Equal(deliveryTime, order.DeliveryTime);
            Assert.Equal(userId, order.UserId);
            Assert.NotNull(order.ProductsOrder);
            Assert.Empty(order.ProductsOrder); // Assuming ProductsOrder is initialized as empty list/array
        }
        [Fact]
        public void EditOrder_Should_Modify_Order_Details()
        {
            // Arrange
            var order = new Order(Guid.NewGuid(), "Address", DateTime.Now, Guid.NewGuid());
            var newAddress = "New Address";
            var newDeliveryTime = DateTime.Now.AddDays(1);
            var productOrder = new ProductOrderVM[] { new ProductOrderVM { ProductId = Guid.NewGuid(), Quantity = 2 } };

            // Act
            var result = order.EditOrder(newAddress, newDeliveryTime, productOrder);

            // Assert
            Assert.True(result);
            Assert.Equal(newAddress, order.DeliveryAddress);
            Assert.Equal(newDeliveryTime, order.DeliveryTime);
            Assert.NotNull(order.ProductsOrder);
            Assert.Single(order.ProductsOrder);
            Assert.Equal(productOrder[0].ProductId, order.ProductsOrder.First().ProductId);
            Assert.Equal(productOrder[0].Quantity, order.ProductsOrder.First().Quantity);
        }
    }
}