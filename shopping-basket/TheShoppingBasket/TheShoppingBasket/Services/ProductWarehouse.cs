using System.Collections.Generic;
using TheShoppingBasket.Domain.Product;

namespace TheShoppingBasket.Services
{
    public interface IProductWarehouse
    {
        Product Find(string product, int quantity);
    }

    internal class ProductWarehouse : IProductWarehouse
    {
        private readonly Dictionary<string, Product> _productCatalogue;

        public ProductWarehouse()
        {
            _productCatalogue = new Dictionary<string, Product>()
            {
                ["butter"] = new Butter(),
                ["milk"] = new Milk(),
                ["bread"] = new Bread()
            };
        }

        public Product Find(string product, int quantity)
        {
            if (_productCatalogue.ContainsKey(product))
            {
                return PrepareProduct(product, quantity);
            }

            return new NullProduct();
            
        }

        private Product PrepareProduct(string product, int quantity)
        {
            var productInCatalogue = _productCatalogue[product];
            productInCatalogue.IncreaseQuantityBy(quantity);

            return productInCatalogue;
        }
    }
}