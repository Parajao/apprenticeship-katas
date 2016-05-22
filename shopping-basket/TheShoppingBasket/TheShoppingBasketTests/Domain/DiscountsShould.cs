using TheShoppingBasket.Domain;
using TheShoppingBasket.Domain.Basket;
using TheShoppingBasket.Domain.Discount;
using Xunit;

namespace TheShoppingBasketTests.Domain
{
    public class DiscountsShould
    {
        private readonly Discounts _discounts = new Discounts();

        [Fact]
        public void apply_all_individual_discounts()
        {
            var severalDiscountsApplyed = new Money(1.65m);
            var products = new Products();
            AddProduct(products, new Butter(), 2);
            AddProduct(products, new Bread(), 1);
            AddProduct(products, new Milk(), 4);

            var totalDiscount = _discounts.ApplyTo(products);

            Assert.Equal(severalDiscountsApplyed, totalDiscount);
        }

        private void AddProduct(Products products, Product product, int quantity)
        {
            product.IncreaseQuantityBy(quantity);
            products.Add(product);
        }
    }
}