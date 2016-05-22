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
                return new Bread().Price.FiftyPercent();
            }

            return new Money();
        }

        private bool CanApplyOffer(Products products)
        {
            var butterQuantity = products.QuantityOf(new Butter());
            var breadQuantity = products.QuantityOf(new Bread());

            return breadQuantity > 0 && butterQuantity > 1;
        }
    }
}