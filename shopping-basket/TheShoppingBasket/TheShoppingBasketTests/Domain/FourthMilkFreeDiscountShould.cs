using TheShoppingBasket.Domain;
using TheShoppingBasket.Domain.Basket;
using TheShoppingBasket.Domain.Discount;
using Xunit;

namespace TheShoppingBasketTests.Domain
{
    public class FourthMilkFreeDiscountShould
    {
        private readonly IDiscount _fourthMilkFreeDiscount = new FourthMilkFreeDiscount();

        [Theory]
        [InlineData(3, 0)]
        [InlineData(4, 1.15)]
        [InlineData(5, 1.15)]
        [InlineData(8, 2.30)]
        [InlineData(12, 3.45)]
        [InlineData(14, 3.45)]
        public void discount_4th_milk(int quantity, decimal expectedDiscount)
        {
            Products products = new Products();
            AddMilks(products, quantity);

            Money discount = _fourthMilkFreeDiscount.ApplyTo(products);

            Assert.Equal(new Money(expectedDiscount), discount);
        }

        private void AddMilks(Products products, int quantity)
        {
            var milk = new Milk();
            milk.IncreaseQuantityBy(quantity);
            products.Add(milk);
        }
    }
}