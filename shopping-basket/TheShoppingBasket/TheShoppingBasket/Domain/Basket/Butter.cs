namespace TheShoppingBasket.Domain.Basket
{
    public class Butter : Product
    {
        public override Money Price => new Money(0.80m);

        public Butter() : base("butter")
        {
        }
    }
}