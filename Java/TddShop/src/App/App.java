package App;

import Ui.*;
import Customer.*;
import Shop.*;

enum AppState{
    Exit,
    MainMenu,
    ShopMenu,
    CustomerMenu,
    CustomerBuyMenu,
    CustomerRefundMenu
}

public class App {
    Ui ui;
    Customer customer;
    Shop shop;

    AppState appState;

    boolean running;

    public App(Ui ui, Customer c, Shop s){
        this.ui = ui;
        this.customer = c;
        this.shop = s;
        running = true;

        appState = AppState.MainMenu;
    }

    public boolean Running(){
        return running;
    }
    public void Update() throws NotEnoughFundsException, CannotReturnException, ItemNotAvailableException {
        String input = "";
        if(appState == AppState.MainMenu){
            input = ui.MainMenu();
            if(input == "Shop"){
                appState = AppState.ShopMenu;
            }
            if(input == "Customer"){
               appState = AppState.CustomerMenu;
            }
            if(input == "Exit"){
                appState = AppState.Exit;
                running = false;
            }
        }
        else if(appState == AppState.ShopMenu){
            input = ui.ShopMenu(shop.Items());
            if(input == "Back"){
                appState = AppState.MainMenu;
            }
        }
        else if(appState == AppState.CustomerMenu){
            input = ui.CustomerMenu(customer);
            if(input == "Back"){
                appState = AppState.MainMenu;
            }
            else if(input =="Buy"){
                appState = AppState.CustomerBuyMenu;
            }
            else if(input == "Refund"){
                appState = AppState.CustomerRefundMenu;
            }
        }
        else if(appState == AppState.CustomerBuyMenu){
            input = ui.CustomerBuyMenu(shop.Items());
            if(input == ""){
                return;
            }
            if(input == "Back"){
                appState = AppState.CustomerMenu;
            }
            else{
                customer.Buy(shop, input);
            }
        }
        else if(appState == AppState.CustomerRefundMenu){
            input = ui.CustomerRefundMenu(customer.Items());
            if(input == "Back"){
                appState = AppState.CustomerMenu;
            }
            else{
                for(int i = 0; i < customer.Items().size(); ++i){
                    if(customer.Items().get(i).Name() == input){
                        customer.Return(shop, customer.Items().get(i));
                    }
                }
            }
        }
    }
}
