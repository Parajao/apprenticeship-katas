using System.Collections.Generic;
using System.Linq;
using TheShoppingBasket.Domain.Basket;

namespace TheShoppingBasket.Domain.Discount
{
    internal class Discounts
    {
        private readonly IList<IDiscount> _discounts;
        public Discounts()
        {
            _discounts = new List<IDiscount>
            {
                new FourthMilkFreeDiscount(),
                new FiftyPercentBreadDiscount()
            };
        }

        public Money ApplyTo(Products products)
        {
            return _discounts
               .Select(discount => discount.ApplyTo(products))
               .Aggregate((discount, nextDiscount) => 
                    discount + nextDiscount);
        }
    }
}