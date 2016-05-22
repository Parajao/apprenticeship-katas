using NSubstitute;
using TheShoppingBasket.Domain;
using TheShoppingBasket.Domain.Basket;
using Xunit;

namespace TheShoppingBasketTests.Domain
{
    public class ProductShould
    {
        [Fact]
        public void initialize_with_quantity_zero()
        {
            var product = Substitute.For<Product>("dummy");

            Assert.Equal(0, product.Quantity);
        }

        [Fact]
        public void update_quantity_when_adding_more()
        {
            var product = Substitute.For<Product>("dummy");
            const int quantity = 2;

            product.IncreaseQuantityBy(quantity);

            Assert.Equal(quantity, product.Quantity);
        }

        [Fact]
        public void cost_price_times_quantity()
        {
            var product = Substitute.For<Product>("dummy");
            var productPrice = new Money(1.0m);
            product.Price.Returns(productPrice);
            const int quantity = 2;

            product.IncreaseQuantityBy(quantity);

            Assert.Equal(productPrice * quantity, product.Cost());
        }

        [Fact]
        public void equal_to_another_product_when_name_is_same()
        {
            var product = Substitute.For<Product>("dummy");
            var anotherProduct = Substitute.For<Product>("dummy");

            var areEqual = product.Equals(anotherProduct);

            Assert.True(areEqual);
        }
    }
}