using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TheShoppingBasket.Domain.Product
{
    public class Products : IEnumerable<Product>
    {
        private readonly IList<Product> _products;

        public Products()
        {
            _products = new List<Product>();
        }

        public void Add(Product product)
        {
            var existingProduct = _products.SingleOrDefault(p => p.Equals(product));
            if (existingProduct != null)
            {
                existingProduct.AddQuantity(product.Quantity);
                return;
            }
            
            _products.Add(product);
        }

        public Money Cost()
        {
            var cost = new Money();

            if (_products.Any())
            {
                cost = _products
                .Select(product => product.Cost())
                .Aggregate((amount, nextAmount) => amount + nextAmount);
            }

            return cost;
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return _products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Product Find(Product product)
        {
            return _products
                .Where(p => p.Equals(product))
                .DefaultIfEmpty(new NullProduct())
                .Single();
        }

        public int QuantityOf(Product product)
        {
            return Find(product).Quantity;
        }
    }
}