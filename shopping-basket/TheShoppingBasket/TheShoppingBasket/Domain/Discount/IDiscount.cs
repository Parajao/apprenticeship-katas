using TheShoppingBasket.Domain.Basket;

namespace TheShoppingBasket.Domain.Discount
{
    public interface IDiscount
    {
        Money ApplyTo(Products products);
    }
}