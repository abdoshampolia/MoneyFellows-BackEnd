using MoneyFellows.Core.Common;

namespace MoneyFellows.Core.Entities
{
    public class Product : ModifiableEntity
    {
        public Product(Guid creatorUserId ,string name, string description, string imageUrl, byte[] productImage, decimal price, string merchant) : base(creatorUserId)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            ProductImage = productImage;
            Price = price;
            Merchant = merchant;
            ProductsOrder = [];
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public byte[] ProductImage { get; private set; } // Blob type
        public decimal Price { get; private set; }
        public string Merchant { get; private set; }
        public ICollection<ProductOrder> ProductsOrder { get; set; }
    }

}
