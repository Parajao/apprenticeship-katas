namespace TheShoppingBasket.Domain.Basket
{
    public abstract class Product
    {
        public int Quantity;
        private readonly string _name;

        protected Product(string name)
        {
            _name = name;
        }

        public abstract Money Price { get; }

        public void IncreaseQuantityBy(int quantity)
        {
            Quantity += quantity;
        }

        public Money Cost()
        {
            return Price * Quantity;
        }

        public override bool Equals(object product)
        {
            return ((Product)product)._name == _name;
        }
    }
}