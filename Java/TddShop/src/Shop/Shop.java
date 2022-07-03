package Shop;

import Item.Item;
import Item.ItemBatch;

import java.util.ArrayList;
import java.util.List;

import Customer.Wallet;

class NotEnoughFundsException extends Exception{
}
public class Shop {
    private List<ItemBatch> items;
    public Shop(){
        items = new ArrayList<ItemBatch>();
    }
    public void Add(ItemBatch b){
        for(int i = 0; i < items.size(); ++i){
            if(items.get(i).Item().Name() == b.Item().Name()){
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
            if(itemname == items.get(i).Item().Name()){
                return items.get(i).Stock;
            }
        }
        return 0;
    }
    public void Buy(String itemName, Wallet wallet) throws NotEnoughFundsException {
        for(int i = 0; i < items.size(); ++i){
            if(items.get(i).Item().Name() == itemName){
                if(wallet.Funds >= items.get(i).Item().Value()){
                    items.get(i).Stock--;
                    wallet.Funds -= items.get(i).Item().Value();
                }
                else{
                    throw new NotEnoughFundsException();
                }
            }
        }
    }
    public int Revenue(){
        return 0;
    }
}
