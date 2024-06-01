using MoneyFellows.Core.Common;
using MoneyFellows.Core.VM;
using System.Xml.Linq;

namespace MoneyFellows.Core.Entities
{
    public class Order : ModifiableEntity
    {
        public Order(Guid creatorUserId, string deliveryAddress,  DateTime deliveryTime, Guid userId) : base(creatorUserId)
        {
            DeliveryAddress = deliveryAddress;
            DeliveryTime = deliveryTime;
            UserId = userId;
            ProductsOrder = [];
        }

        protected Order() : base(Guid.Empty)
        {
            ProductsOrder = [];
        }

        public string DeliveryAddress { get; private set; }
        public double TotalCost { get; private set; }
        public DateTime DeliveryTime { get; private set; }

        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public ICollection<ProductOrder> ProductsOrder { get; private set; }


        public bool ChangeDeliveryAddress(string deliveryAddress)
        {
            bool result = false;

            if (DeliveryAddress != deliveryAddress)
            {
                DeliveryAddress = deliveryAddress;
                ModifiedOn = DateTime.Now;
                result = true;
            }
            return result;
        }
        public bool ChangeDeliveryTime(DateTime? deliveryTime)
        {
            bool result = false;

            if (DeliveryTime != deliveryTime)
            {
                DeliveryTime = (DateTime)deliveryTime;
                ModifiedOn = DateTime.Now;
                result = true;
            }
            return result;
        }
        public bool EditOrder(string deliveryAddress, DateTime deliveryTime , ProductOrderVM[] ids)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(deliveryAddress))
            {
                if (ChangeDeliveryAddress(deliveryAddress))
                {
                    result = true;
                }
            }

            if (deliveryTime != null)
            {
                if (ChangeDeliveryTime(deliveryTime))
                {
                    result = true;
                }
            }

            if (ids != null)
            {
                if (AddProductsOrder(ids))
                {
                    result = true;
                }
            }

            return result;
        }

        public bool AddProductsOrder(ProductOrderVM[] ids)
        {
            bool result = false;
            var productsOrder = new List<ProductOrder>();

            foreach (var item in ids)
            {
                var productOrder = new ProductOrder(Id, item.ProductId, item.Quantity);
                productsOrder?.Add(productOrder);
                result = true;
            }

            if (productsOrder?.Count > 0)
            {
                ProductsOrder = productsOrder;
                TotalCost = productsOrder.Sum(po => po.Quantity * po.Product.Price);
                result = true;
            }

            return result;
        }

    }
}
