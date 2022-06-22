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
        public bool Running = true;

        private Ui ui;
        private Customer customer;
        private Shop shop;

        int currentState = 0; //0 MainMenu, 1 ShopMenu

        public App(Ui ui, Customer customer, Shop shop) {
            this.ui = ui;
            this.customer = customer;
            this.shop = shop;
        }
        public void Update() {
            if(currentState == 0) {
                string mainMenuInput = ui.MainMenu();
                if (mainMenuInput == "1") {
                    currentState = 1;
                }
                else if (mainMenuInput == "2") {
                    ui.CustomerMenu(customer);
                }
                else if (mainMenuInput == "3") {
                    currentState = -1;
                    return;
                }
            }
            else if(currentState == 1) {
                string input = ui.ShopMenu(shop.Items);
                if(input == "3") {
                    Running = false;
                }
            }
        }
    }
}
