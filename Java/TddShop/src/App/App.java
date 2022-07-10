package App;

import Ui.*;
import Customer.*;
import Shop.*;

enum AppState{
    Exit,
    MainMenu,
    ShopMenu
}

public class App {
    Ui ui;
    Customer customer;
    Shop shop;

    AppState appState;

    public App(Ui ui, Customer c, Shop s){
        this.ui = ui;
        this.customer = c;
        this.shop = s;

        appState = AppState.MainMenu;
    }
    public void Update(){

        String input = "";
        if(appState == AppState.MainMenu){
            input = ui.MainMenu();
            if(input == "Shop"){
                appState = AppState.ShopMenu;
            }
        }
        else if(appState == AppState.ShopMenu){
            input = ui.ShopMenu(shop.Items());
        }
    }
}
