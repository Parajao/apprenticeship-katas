using System.Linq;
using TheShoppingBasket.Domain.Product;

namespace TheShoppingBasket.Domain.Discount
{
    public class FiftyPercentBreadDiscount : IDiscount
    {
        public Money Apply(Products products)
        {
            if (CanApplyOffer(products))
            {
                return Offer();
            }

            return new Money();
        }

        private Money Offer()
        {
            return new Bread().Price.FiftyPercent();
        }

        private bool CanApplyOffer(Products products)
        {
            var butterQuantity = products.QuantityOf(new Butter());
            var breadQuantity = products.QuantityOf(new Bread());

            return breadQuantity > 0 && butterQuantity > 1;
        }
    }
}