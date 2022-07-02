package Shop;

import Item.Item;
import Item.ItemBatch;

import java.util.ArrayList;
import java.util.List;

public class Shop {
    private List<ItemBatch> items;
    public Shop(){
        items = new ArrayList<ItemBatch>();
    }
    public void Add(ItemBatch b){
        items.add(b);
    }
    public List<ItemBatch> Items(){
        return items;
    }
}
