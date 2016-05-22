using TheShoppingBasket.Domain;
using TheShoppingBasket.Domain.Discount;
using TheShoppingBasket.Domain.Product;
using Xunit;

namespace TheShoppingBasketTests.Domain
{
    public class DiscountsShould
    {
        private readonly Discounts _discounts = new Discounts();

        [Fact]
        public void apply_all_individual_discounts()
        {
            Products products = new Products();

            AddProduct(products, new Butter(), 2);
            AddProduct(products, new Bread(), 1);
            AddProduct(products, new Milk(), 4);

            Money discount = _discounts.Apply(products);

            var severalDiscountsApplied = 1.65m;
            Assert.Equal(new Money(severalDiscountsApplied), discount);
        }

        private void AddProduct(Products products, Product product, int quantity)
        {
            product.IncreaseQuantityBy(quantity);
            products.Add(product);
        }
    }
}