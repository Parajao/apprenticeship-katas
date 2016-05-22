using TheShoppingBasket.Domain.Product;

namespace TheShoppingBasket.Domain.Discount
{
    public class FourthMilkFreeDiscount : IDiscount
    {
        public Money Apply(Products products)
        {
            var milkPrice = new Milk().Price;
            var numberOfTimesToApplyOffer = products.QuantityOf(new Milk())/4;

            return milkPrice * numberOfTimesToApplyOffer;
        }
    }
}