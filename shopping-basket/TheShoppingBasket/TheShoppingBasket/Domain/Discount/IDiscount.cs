using TheShoppingBasket.Domain.Product;

namespace TheShoppingBasket.Domain.Discount
{
    public interface IDiscount
    {
        Money Apply(Products products);
    }
}