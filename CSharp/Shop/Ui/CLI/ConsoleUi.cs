using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Ui.CLI {
    using Items;
    using Customers;

    public class ConsoleUi : Ui {
        UiTextCreator textUiBuilder;
        ConsoleInput consoleInput;
        public ConsoleUi(UiTextCreator textUiBuilder, ConsoleInput consoleInput) {
            this.textUiBuilder = textUiBuilder;
            this.consoleInput = consoleInput;
        }
        public string MainMenu() {
            string mainMenuText = textUiBuilder.ConstructMainMenu();
            Console.WriteLine(mainMenuText);
            string input = consoleInput.ReadLine();
            return input;
        }
        public string ShopMenu(List<ItemBatch> items) {
            string shopMenuText = textUiBuilder.ConstructShopMenu(items);
            Console.Write(shopMenuText);
            string i = consoleInput.ReadLine();
            return i;
        }
        public string CustomerMenu(Customer c) {
            string menuText = textUiBuilder.ConstructCustomerMenu(c);
            Console.Write(menuText);
            var input = consoleInput.ReadLine();
            return input;
        }
        public void CustomerBuyMenu(List<ItemBatch> items) {
            string menuText = textUiBuilder.ConstructCustomerBuyMenu(items);
            Console.Write(menuText);
            consoleInput.ReadLine();
        }
    }
}
