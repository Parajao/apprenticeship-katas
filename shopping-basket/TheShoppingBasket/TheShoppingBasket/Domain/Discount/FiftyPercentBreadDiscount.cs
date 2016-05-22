using TheShoppingBasket.Domain.Basket;

namespace TheShoppingBasket.Domain.Discount
{
    public class FiftyPercentBreadDiscount : IDiscount
    {
        public Money ApplyTo(Products products)
        {
            var butterQuantity = products.QuantityOf(new Butter());
            var breadQuantity = products.QuantityOf(new Bread());
            if (breadQuantity > 0 && butterQuantity > 1)
            {
                return new Bread().Price.FiftyPercent();
            }

            return new Money();
        }
    }
}