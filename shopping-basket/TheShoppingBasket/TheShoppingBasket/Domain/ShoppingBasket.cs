using TheShoppingBasket.Domain.Discount;
using TheShoppingBasket.Domain.Product;

namespace TheShoppingBasket.Domain
{
    public interface IShoppingBasket
    {
        void Add(Product.Product product);
        Money Total();
    }

    internal class ShoppingBasket : IShoppingBasket
    {
        private readonly Products _products = new Products();
        private readonly Discounts _discounts = new Discounts();

        public void Add(Product.Product product)
        {
            _products.Add(product);
        }

        public Money Total()
        {
            return _products.TotalCost() - _discounts.Apply(_products);
        }
    }
}