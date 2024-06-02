using MoneyFellows.Core.Entities;

namespace MonetFellows.UnitTest
{
    public class ProductTests
    {
        [Fact]
        public void Product_Constructor_Should_Initialize_Properties_Correctly()
        {
            // Arrange
            var creatorUserId = Guid.NewGuid();
            var name = "Test Product";
            var description = "Description of the product";
            var imageUrl = "https://example.com/image.jpg";
            var price = 10.99;
            var merchant = "Test Merchant";

            // Act
            var product = new Product(creatorUserId, name, description, imageUrl, price, merchant);

            // Assert
            Assert.Equal(creatorUserId, product.CreatorUserId);
            Assert.Equal(name, product.Name);
            Assert.Equal(description, product.Description);
            Assert.Equal(imageUrl, product.ImageUrl);
            Assert.Equal(price, product.Price);
            Assert.Equal(merchant, product.Merchant);
            Assert.NotNull(product.ProductsOrder);
            Assert.Empty(product.ProductsOrder); // Assuming ProductsOrder is initialized as empty list/array
        }
        [Fact]
        public void EditProduct_Should_Modify_Product_Details()
        {
            // Arrange
            var product = new Product(Guid.NewGuid(), "Original Name", "Original Description", "OriginalImageUrl", 10.99, "OriginalMerchant");
            var newName = "New Name";
            var newDescription = "New Description";
            var newPrice = 20.99;
            var newImageUrl = "https://example.com/new-image.jpg";

            // Act
            var result = product.EditProduct(newName, newDescription, newPrice, newImageUrl);

            // Assert
            Assert.True(result);
            Assert.Equal(newName, product.Name);
            Assert.Equal(newDescription, product.Description);
            Assert.Equal(newPrice, product.Price);
            Assert.Equal(newImageUrl, product.ImageUrl);
        }

        [Fact]
        public void EditProduct_Should_Not_Modify_If_No_Changes()
        {
            // Arrange
            var product = new Product(Guid.NewGuid(), "Original Name", "Original Description", "OriginalImageUrl", 10.99, "OriginalMerchant");

            // Act
            var result = product.EditProduct("Original Name", "Original Description", 10.99, "OriginalImageUrl");

            // Assert
            Assert.False(result);
            Assert.Equal("Original Name", product.Name);
            Assert.Equal("Original Description", product.Description);
            Assert.Equal(10.99, product.Price);
            Assert.Equal("OriginalImageUrl", product.ImageUrl);
        }
    }
}
