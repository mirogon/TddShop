using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Items;
using Shop.Customers;

namespace Shop.App {
    using Ui;

    public enum AppState {
        Exit = -1,
        MainMenu = 0,
        ShopMenu = 1,
        CustomerMenu = 2
    }
    public class App {
        public bool Running = true;

        private Ui ui;
        private Customer customer;
        private Shop shop;

        AppState currentState = AppState.MainMenu;

        public App(Ui ui, Customer customer, Shop shop) {
            this.ui = ui;
            this.customer = customer;
            this.shop = shop;
        }
        public void Update() {
            if(currentState == 0) {
                string mainMenuInput = ui.MainMenu();
                if (mainMenuInput == "1") {
                    currentState = AppState.ShopMenu;
                }
                else if (mainMenuInput == "2") {
                    currentState = AppState.CustomerMenu;
                }
                else if (mainMenuInput == "3") {
                    currentState = AppState.Exit;
                    Running = false;
                    return;
                }
            }
            else if(currentState == AppState.ShopMenu) {
                string input = ui.ShopMenu(shop.Items);
                if(input == "3") {
                    currentState = AppState.MainMenu;
                }
            }
            else if(currentState == AppState.CustomerMenu) {
                string input = ui.CustomerMenu(customer);
                if(input == "3") {
                    currentState = AppState.MainMenu;
                }
            }
        }
    }
}
