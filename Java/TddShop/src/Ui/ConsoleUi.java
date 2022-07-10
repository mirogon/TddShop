package Ui;

import Customer.Customer;
import Item.Item;
import Item.ItemBatch;

import java.util.List;

public class ConsoleUi implements Ui{
    UiTextCreator textCreator;
    ConsoleInput consoleInput;
    public ConsoleUi(UiTextCreator textCreator, ConsoleInput consoleInput){
        this.textCreator = textCreator;
        this.consoleInput = consoleInput;
    }
    public String MainMenu(){
        String menuText = textCreator.ConstructMainMenu();
        System.out.print(menuText);
        String input = consoleInput.ReadLine();
        return input;
    }
    public String ShopMenu(List<ItemBatch> itemBatches){
        String menuText = textCreator.ConstructShopMenu(itemBatches);
        System.out.print(menuText);
        String input = consoleInput.ReadLine();
        return input;
    }
    public String CustomerMenu(Customer c){
        String menuText = textCreator.ConstructCustomerMenu(c);
        System.out.print(menuText);
        String input = consoleInput.ReadLine();
        return input;
    }
    public String CustomerBuyMenu(List<ItemBatch> items){
        String menuText = textCreator.ConstructCustomerBuyMenu(items);
        System.out.print(menuText);
        String input = consoleInput.ReadLine();
        return input;
    }
    public String CustomerRefundMenu(List<Item> items){
        String menuText = textCreator.ConstructCustomerRefundMenu(items);
        System.out.print(menuText);
        String input = consoleInput.ReadLine();
        return input;
    }
}
