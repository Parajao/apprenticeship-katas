using TheShoppingBasket.Domain;
using TheShoppingBasket.Domain.Basket;
using Xunit;

namespace TheShoppingBasketTests.Domain
{
    public class ShoppingBasketShould
    {
        private readonly ShoppingBasket _shoppingBasket;

        public ShoppingBasketShould()
        {
            _shoppingBasket = new ShoppingBasket();
        }

        [Fact]
        public void total_cost_when_several_products_have_been_added()
        {
            AddMilk(1);
            AddButter(1);

            Money total = _shoppingBasket.Total();

            Assert.Equal(new Money(1.95m), total);
        }

        [Fact]
        public void total_cost_when_several_items_of_same_product_have_been_added()
        {
            AddBread(3);
            AddButter(1);

            Money total = _shoppingBasket.Total();

            Assert.Equal(new Money(3.80m), total);
        }

        [Fact]
        public void total_including_discount_of_4th_milk_free()
        {
            AddMilk(4);
            AddBread(2);

            Money total = _shoppingBasket.Total();

            var expectedDiscountedTotal = new Money(5.45m);
            Assert.Equal(expectedDiscountedTotal, total);
        }

        [Fact]
        public void total_including_discount_of_bread_half_price()
        {
            AddButter(2);
            AddBread(1);

            Money total = _shoppingBasket.Total();

            var expectedDiscountedTotal = new Money(2.10m);
            Assert.Equal(expectedDiscountedTotal, total);
        }

        private void AddBread(int quantity)
        {
            AddProduct(new Bread(), quantity);
        }

        private void AddButter(int quantity)
        {
            AddProduct(new Butter(), quantity);
        }
        private void AddMilk(int quantity)
        {
            AddProduct(new Milk(), quantity);
        }

        private void AddProduct(Product product, int quantity)
        {
            product.IncreaseQuantityBy(quantity);
            _shoppingBasket.Add(product);
        }
    }
}