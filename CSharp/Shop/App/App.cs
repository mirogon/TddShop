using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Items;
using Shop.Customers;

namespace Shop.App {
    using Ui;
    public class App {
        private Ui ui;
        private Customer customer;
        private Shop shop;
        public App(Ui ui, Customer customer, Shop shop) {
            this.ui = ui;
            this.customer = customer;
            this.shop = shop;
        }
        public void Start() {
            string mainMenuInput = ui.MainMenu();
            if (mainMenuInput == "1") {
                ui.ShopMenu(shop.Items);
            }
            else if (mainMenuInput == "2") {
                ui.CustomerMenu(customer);
            }
        }
    }
}
