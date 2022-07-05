package Ui;
import Item.*;
import Customer.*;

import java.util.List;

public class ConsoleUiTextCreator {
    public String ConstructMainMenu(){
        String s ="USER COMMANDS\n\n";
        s += "SHOP     - Shop Menu\n";
        s += "CUSTOMER - Customer Menu\n";
        s += "EXIT     - Exit Application\n\n";
        s += "INPUT:";
        return s;
    }
    public String ConstructShopMenu(List<ItemBatch> items){
        String s ="SHOP ITEMS\n\n";
        s+="Name                Price               Stock\n";
        for(int i = 0; i < items.size(); ++i){
            int spacesAfterName = 20 - items.get(i).Item().Name().length();
            s += items.get(i).Item().Name();
            for(int j = 0; j < spacesAfterName; ++j){
                s +=" ";
            }
            String valueString = "" + items.get(i).Item().Value();
            int spacesAfterPrice = 20 - valueString.length();
            s += valueString;
            for(int j = 0; j < spacesAfterPrice; ++j){
                s += " ";
            }
            s += items.get(i).Stock;
            s += "\n";
        }
        s+="\nUSER COMMANDS\n\n";
        s+="BACK - Go back to the Main Menu\n\n";
        s+="INPUT:";
        return s;
    }
    public String ConstructCustomerMenu(Customer c){
        String s ="YOUR ITEMS\n\n";

        for(int i = 0; i < c.Items().size(); ++i){
            s += c.Items().get(i).Name();
            s+="\n";
        }
        s += "\n";
        s+="USER COMMANDS\n\n";
        s+="BUY    - Buy Item\n";
        s+="REFUND - Refund Item\n";
        s+="BACK   - Go back to the Main Menu\n\n";
        s+="INPUT:";
        return s;
    }
    public String ConstructCustomerBuyMenu(List<ItemBatch> shopItems){
        String s = "SHOP ITEMS\n\n";
        s += "Name                Price               Stock\n";

        for(int i = 0; i < shopItems.size(); ++i){
            int spaces = 20 - shopItems.get(i).Item().Name().length();
            s += shopItems.get(i).Item().Name();
            for(int j = 0; j < spaces; ++j){
                s += " ";
            }
            String itemValue = "" + shopItems.get(i).Item().Value();
            spaces = 20 - itemValue.length();
            s += itemValue;
            for(int j = 0; j < spaces; ++j){
                s += " ";
            }
            s += shopItems.get(i).Stock;
            s += "\n";
        }
        s += "\n";
        s += "USER COMMANDS\n\n";
        s+= "[ITEM]  - Buy item with the name [ITEM]\n";
        s+= "BACK    - Go back to the Customer Menu\n\n";
        s+="INPUT:";

        return s;
    }
    public String ConstructCustomerRefundMenu(List<Item> customerItems){
        String s = "YOUR ITEMS\n\n";
        s += "Name                Value\n";
        for(int i = 0; i < customerItems.size(); ++i){
            int spaces = 20 - customerItems.get(i).Name().length();
            s += customerItems.get(i).Name();
            for(int j = 0; j < spaces; ++j){
                s += " ";
            }
            s += customerItems.get(i).Value();
            s+="\n";
        }
        s+="\nUSER COMMANDS\n\n";
        s+="[ITEM] - Refund item with [ITEM] name\nBACK   - Go back to the Customer Menu\n\n";
        s+="INPUT:";
        return s;
    }
}
