using TheShoppingBasket.Domain;
using TheShoppingBasket.Domain.Basket;
using TheShoppingBasket.Domain.Discount;
using Xunit;

namespace TheShoppingBasketTests.Domain
{
    public class FiftyPercentBreadDiscountShould
    {
        private readonly IDiscount fiftyPercentBreadDiscount = new FiftyPercentBreadDiscount();

        [Theory]
        [InlineData(1, 1, 0.00)]
        [InlineData(2, 0, 0.00)]
        [InlineData(2, 1, 0.50)]
        [InlineData(3, 1, 0.50)]
        [InlineData(4, 1, 0.50)]
        [InlineData(4, 2, 0.50)]
        public void discount_a_bread_at_50_percent_off(int butterQuantity, int breadQuantity, decimal expectedDiscount)
        {
            Products products = new Products();
            AddButter(products, butterQuantity);
            AddBread(products, breadQuantity);

            Money discount = fiftyPercentBreadDiscount.ApplyTo(products);

            Assert.Equal(new Money(expectedDiscount), discount);
        }

        private void AddButter(Products products, int quantity)
        {
            Butter butter = new Butter();
            butter.IncreaseQuantityBy(quantity);
            products.Add(butter);
        }

        private void AddBread(Products products, int quantity)
        {
            Bread bread = new Bread();
            bread.IncreaseQuantityBy(quantity);
            products.Add(bread);
        }
    }
}