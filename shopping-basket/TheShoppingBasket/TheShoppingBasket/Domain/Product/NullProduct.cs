namespace TheShoppingBasket.Domain.Product
{
    class NullProduct : Product
    {
        public override Money Price => new Money();

        public NullProduct() : base("") {}
    }
}
