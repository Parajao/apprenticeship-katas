using TheShoppingBasket.Domain;
using Xunit;

namespace TheShoppingBasketTests.Domain
{
    public class MoneyShould
    {
        private Money ONE_POUNDS = new Money(1.00m);
        private Money TWO_POUNDS = new Money(2.0m);
        private Money ZERO_POUNDS = new Money();
        private Money FOUR_POUNDS = new Money(4.0m);
        private Money THREE_POUNDS = new Money(3.0m);

        [Fact]
        public void equal_to_zero_when_no_amount_is_provided()
        {
            var money = new Money(0.0m);

            Assert.Equal(ZERO_POUNDS, money);
        }

        [Fact]
        public void equal_to_another_money_if_amount_is_same()
        {
            var anotherMoney = new Money(1.0m);

            var money = new Money(1.0m);

            Assert.Equal(anotherMoney, money);
        }

        [Fact]
        public void not_equal_to_another_money_if_amount_is_different()
        {
            var anotherMoney = new Money(2.0m);

            var money = new Money(1.0m);

            Assert.NotEqual(anotherMoney, money);
        }

        [Fact]
        public void sum_two_moneys()
        {
            var sum = ONE_POUNDS + TWO_POUNDS;

            Assert.Equal(THREE_POUNDS, sum);
        }

        [Fact]
        public void substract_two_moneys()
        {
            var difference = TWO_POUNDS - ONE_POUNDS;

            Assert.Equal(ONE_POUNDS, difference);
        }

        [Fact]
        public void be_multipliable_by_integer()
        {
            var twoTimes2 = TWO_POUNDS * 2;

            Assert.Equal(FOUR_POUNDS, twoTimes2);
        }

        [Fact]
        public void perform_fifty_percent()
        {
            var fiftyPercentOfTwo = TWO_POUNDS.FiftyPercent();

            Assert.Equal(ONE_POUNDS, fiftyPercentOfTwo);
        }

        [Fact]
        public void have_string_representation()
        {
            var moneyAsString = ONE_POUNDS.ToString();

            Assert.Equal("£1.00", moneyAsString);
        }
    }
}