using System;
using TheShoppingBasket.Domain;
using TheShoppingBasket.Domain.Basket;
using TheShoppingBasket.Infrastructure;
using TheShoppingBasket.Services;

namespace TheShoppingBasket
{
    public class Application
    {
        private readonly IShoppingBasket _shoppingBasket;
        private readonly IDisplay _display;
        private readonly IProductWarehouse _productWarehouse = new ProductWarehouse();

        public Application(IShoppingBasket shoppingBasket, IDisplay display)
        {
            _shoppingBasket = shoppingBasket;
            _display = display;
        }

        public void Execute(string command)
        {
            if (command.Contains("Add"))
            {
                AddProduct(command);
                return;
            }

            ShowTotal();
        }

        private void AddProduct(string command)
        {
            var parameters = ParseAddProductCommand(command);

            int quantity = parameters.Item2;
            Product product = _productWarehouse.Find(parameters.Item1, quantity);

            _shoppingBasket.Add(product);
        }

        private void ShowTotal()
        {
            Money total = _shoppingBasket.Total();
            _display.Show(total);
        }

        private Tuple<string, int> ParseAddProductCommand(string command)
        {
            var parameters = command.Split(' ');
            var product = parameters[2];
            var quantity = int.Parse(parameters[1]);

            return new Tuple<string, int>(product, quantity);
        }
    }
}
