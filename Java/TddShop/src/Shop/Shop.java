package Shop;

import Item.Item;
import Item.ItemBatch;

import java.util.ArrayList;
import java.util.List;

import Customer.Wallet;

public class Shop {
    private List<ItemBatch> items;
    private List<Item> soldItems;
    private int revenue = 0;
    public Shop(){
        items = new ArrayList<ItemBatch>();
        soldItems = new ArrayList<Item>();
    }
    public void Add(ItemBatch b){
        for(int i = 0; i < items.size(); ++i){
            if(items.get(i).Item().Name().equalsIgnoreCase(b.Item().Name())){
                items.get(i).Stock += b.Stock;
                return;
            }
        }
        items.add(b);
    }
    public List<ItemBatch> Items(){
        return items;
    }
    public int StockAvailable(String itemname){
        for(int i = 0; i < items.size(); ++i){
            if(itemname.equalsIgnoreCase(items.get(i).Item().Name())){
                return items.get(i).Stock;
            }
        }
        return 0;
    }
    public void DecrementStock(int itemIndex){
        --items.get(itemIndex).Stock;
        if(items.get(itemIndex).Stock <= 0){
            items.remove(itemIndex);
        }
    }
    public Item Buy(String itemName, Wallet wallet) throws NotEnoughFundsException, ItemNotAvailableException {
        boolean found = false;
        for(int i = 0; i < items.size(); ++i){
            if(items.get(i).Item().Name().equalsIgnoreCase(itemName)){
                found = true;
                if(wallet.Funds >= items.get(i).Item().Value()){
                    Item item = items.get(i).Item();
                    wallet.Funds -= items.get(i).Item().Value();
                    revenue += items.get(i).Item().Value();
                    soldItems.add(item);
                    DecrementStock(i);
                    return item;
                }
                else{
                    throw new NotEnoughFundsException();
                }
            }
        }
        throw new ItemNotAvailableException();
    }
    public void Return(Item item) throws CannotReturnException{
        boolean found = false;
        for(int i = 0; i < soldItems.size(); ++i){
            if(soldItems.get(i).Name().equalsIgnoreCase(item.Name())){
                found = true;
                soldItems.remove(i);
            }
        }
        if(!found){
            throw new CannotReturnException();
        }
        found = false;
        for(int i = 0; i < items.size(); ++i){
            if(items.get(i).Item().Name().equalsIgnoreCase(item.Name())){
                items.get(i).Stock++;
                found = true;
            }
        }
        if(!found){
            ItemBatch b = new ItemBatch(item, 1);
            items.add(b);
        }
        revenue -= item.Value();
    }
    public int Revenue(){
        return revenue;
    }
}
