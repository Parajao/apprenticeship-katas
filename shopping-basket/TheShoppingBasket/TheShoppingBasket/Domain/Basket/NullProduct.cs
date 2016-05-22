namespace TheShoppingBasket.Domain.Basket
{
    class NullProduct : Product
    {
        public override Money Price => new Money();

        public NullProduct() : base("") {}
    }
}
