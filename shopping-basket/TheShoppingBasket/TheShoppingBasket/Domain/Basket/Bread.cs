namespace TheShoppingBasket.Domain.Basket
{
    public class Bread : Product
    {
        public override Money Price => new Money(1.00m);

        public Bread() : base("bread")
        {
        }
    }
}