using System;
using TheShoppingBasket.Domain.Basket;
using TheShoppingBasket.Services;
using Xunit;

namespace TheShoppingBasketTests
{
    public class ProductWarehouseShould
    {
        [Theory]
        [InlineData("butter", typeof(Butter))]
        [InlineData("milk", typeof(Milk))]
        [InlineData("bread", typeof(Bread))]
        [InlineData("not-in-catalogue", typeof(NullProduct))]
        public void find_product_based_on_its_name(string name, Type typeOfProduct)
        {
            var productCatalogue = new ProductWarehouse();

            Product productFromCatalogue = productCatalogue.Find(name, 2);

            Assert.Equal(typeOfProduct, productFromCatalogue.GetType());
        }
    }
}