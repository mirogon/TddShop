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
        CustomerMenu = 2,
        CustomerBuyMenu = 3,
        CustomerRefundMenu = 4
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
                if (mainMenuInput.Contains("SHOP", StringComparison.OrdinalIgnoreCase)) {
                    currentState = AppState.ShopMenu;
                }
                else if (mainMenuInput.Contains("CUSTOMER", StringComparison.OrdinalIgnoreCase)) {
                    currentState = AppState.CustomerMenu;
                }
                else if (mainMenuInput.Contains("EXIT", StringComparison.OrdinalIgnoreCase)) {
                    currentState = AppState.Exit;
                    Running = false;
                    return;
                }
            }
            else if(currentState == AppState.ShopMenu) {
                string input = ui.ShopMenu(shop.Items);
                if(input == "BACK") {
                    currentState = AppState.MainMenu;
                }
            }
            else if(currentState == AppState.CustomerMenu) {
                string input = ui.CustomerMenu(customer);
                if(input == "BUY") {
                    currentState = AppState.CustomerBuyMenu;
                }
                else if(input == "REFUND") {
                    currentState = AppState.CustomerRefundMenu;
                }
                else if(input == "BACK") {
                    currentState = AppState.MainMenu;
                }
            }
            else if(currentState == AppState.CustomerBuyMenu) {
                string input = ui.CustomerBuyMenu(shop.Items);
                if(input == "BACK") {
                    currentState = AppState.CustomerMenu;
                }
                else {
                    try {
                        customer.Buy(shop, input);
                    }
                    catch(Exception e) {

                    }
                }
            }
            else if(currentState == AppState.CustomerRefundMenu) {
                ui.CustomerRefundMenu(customer.Items);
            }
        }
    }
}
