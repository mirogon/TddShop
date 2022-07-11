package App;

import Ui.*;
import Customer.*;
import Shop.*;

enum AppState{
    Exit,
    MainMenu,
    ShopMenu,
    CustomerMenu,
    CustomerBuyMenu
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
    public void Update(){

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
        }
        else if(appState == AppState.CustomerBuyMenu){
            input = ui.CustomerBuyMenu(shop.Items());
        }
    }
}
