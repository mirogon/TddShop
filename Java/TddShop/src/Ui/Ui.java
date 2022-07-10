package Ui;

import java.util.List;

import Customer.Customer;
import Item.*;
public interface Ui {
    public String MainMenu();
    public String ShopMenu(List<ItemBatch> itemBatches);
    public String CustomerMenu(Customer c);
    public String CustomerBuyMenu(List<ItemBatch> items);
    public String CustomerRefundMenu(List<Item> items);
}
