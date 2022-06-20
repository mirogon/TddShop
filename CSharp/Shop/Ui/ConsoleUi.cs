using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Ui {
    using Items;
    using Customers;
    public class ConsoleUi : Ui{
        TextUiBuilder textUiBuilder;
        ConsoleInput consoleInput;
        public ConsoleUi(TextUiBuilder textUiBuilder, ConsoleInput consoleInput) {
            this.textUiBuilder = textUiBuilder;
            this.consoleInput = consoleInput;
        }
        public void MainMenu() {
            string mainMenuText = textUiBuilder.ConstructMainMenu();
            Console.WriteLine(mainMenuText);
            string input = consoleInput.ReadLine();
        }
        public void ShopMenu(List<ItemBatch> items) {
            string shopMenuText = textUiBuilder.ConstructShopMenu(items);
            Console.Write(shopMenuText);
            string i = consoleInput.ReadLine();
        }
        public void CustomerMenu(Customer c) {
            string menuText = textUiBuilder.ConstructCustomerMenu(c);
            Console.Write(menuText);
            var input = consoleInput.ReadLine();
        }
        public void CustomerBuyMenu(List<ItemBatch> items) {
            string menuText = textUiBuilder.ConstructCustomerBuyMenu(items);
            Console.Write(menuText);
            consoleInput.ReadLine();
        }
    }
}
