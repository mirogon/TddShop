package Ui;

import java.util.List;
import Item.*;
import Customer.*;

public interface UiTextCreator {
    public String ConstructMainMenu();
    public String ConstructShopMenu(List<ItemBatch> items);

    public String ConstructCustomerMenu(Customer c);
    public String ConstructCustomerBuyMenu(List<ItemBatch> shopItems);
    public String ConstructCustomerRefundMenu(List<Item> customerItems);
}
