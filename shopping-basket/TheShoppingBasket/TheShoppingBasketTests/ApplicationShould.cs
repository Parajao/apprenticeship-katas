using NSubstitute;
using TheShoppingBasket;
using TheShoppingBasket.Domain;
using TheShoppingBasket.Domain.Basket;
using TheShoppingBasket.Infrastructure;
using Xunit;

namespace TheShoppingBasketTests
{
    public class ApplicationShould
    {
        private readonly IShoppingBasket _shoppingBasket;
        private readonly IDisplay _display;
        private readonly Application _application;

        public ApplicationShould()
        {
            _shoppingBasket = Substitute.For<IShoppingBasket>();
            _display = Substitute.For<IDisplay>();
            _application = new Application(_shoppingBasket,_display);
        }

        [Fact]
        public void add_items_to_shopping_basket_when_user_command_contains_add()
        {
            _application.Execute("Add 3 milk");

            _shoppingBasket.Received()
                .Add(Arg.Is<Product>(p => p.Equals(new Milk()) && p.Quantity == 3));
        }

        [Fact]
        public void get_total_from_shopping_basket()
        {
            _application.Execute("Total");

            _shoppingBasket.Received().Total();
        }

        [Fact]
        public void print_total()
        {
            _shoppingBasket.Total().Returns(new Money(10.00m));

            _application.Execute("Total");

            _display.Received().Show(Arg.Is<Money>(
                output => output.Equals(new Money(10.00m))));
        }
    }
}
