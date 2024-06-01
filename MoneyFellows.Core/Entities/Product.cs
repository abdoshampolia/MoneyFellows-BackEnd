using MoneyFellows.Core.Common;

namespace MoneyFellows.Core.Entities
{
    public class Product : ModifiableEntity
    {
        public Product(Guid creatorUserId, string name, string description, byte[] image, double price, string merchant) : base(creatorUserId)
        {
            Name = name;
            Description = description;
            Image = image;
            Price = price;
            Merchant = merchant;
            ProductsOrder = [];
        }
        protected Product():base(Guid.Empty){} 

        public string Name { get; private set; }
        public string Description { get; private set; }
        //public string ImageUrl { get; private set; }
        public byte[] Image { get; private set; } // Blob type
        public double Price { get; private set; }
        public string Merchant { get; private set; }
        public ICollection<ProductOrder> ProductsOrder { get; set; }

        public bool ChangeName(string name)
        {
            bool result = false;

            if ((Name != name))
            {
                Name = name;
                ModifiedOn = DateTime.Now;
                result = true;
            }
            return result;
        }
        public bool ChangeDescription(string? description)
        {
            bool result = false;

            if (Description != description)
            {
                Description = description;
                ModifiedOn = DateTime.Now;
                result = true;
            }
            return result;
        }
        public bool ChangeImage(byte[]? image)
        {
            bool result = false;

            if (Image != image && image != null)
            {
                Image = image;
                ModifiedOn = DateTime.Now;
                result = true;
            }
            return result;
        }
        public bool ChangeMerchant(string merchant)
        {
            bool result = false;

            if ((Merchant != merchant))
            {
                Merchant = merchant;
                ModifiedOn = DateTime.Now;
                result = true;
            }
            return result;
        }
        public bool ChangePrice(double? price)
        {
            bool result = false;

            if (Price != price)
            {
                Price = (double)price;
                ModifiedOn = DateTime.Now;
                result = true;
            }
            return result;
        }

        public bool EditProduct(string name, string description, double? price, byte[]? image)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(name))
            {
                if (ChangeName(name))
                {
                    result = true;
                }
            }

            if (!string.IsNullOrEmpty(description))
            {
                if (ChangeDescription(description))
                {
                    result = true;
                }
            }

            if (price != null)
            {
                if (ChangePrice(price))
                {
                    result = true;
                }
            }

            if (image != null)
            {
                if (ChangeImage(image))
                {
                    result = true;
                }
            }

            return result;
        }

    }
}
