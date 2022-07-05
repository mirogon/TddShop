package Ui;
import Item.*;

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
        }
        return s;
    }
}
