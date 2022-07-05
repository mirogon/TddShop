package Customer;
import Shop.*;
import Item.*;

import java.util.ArrayList;
import java.util.List;

public class Customer {
    private List<Item> items;
    private Wallet wallet;
    public Customer(Wallet wallet){
        this.wallet = wallet;
        items = new ArrayList<Item>();
    }
    public Wallet Wallet(){
        return wallet;
    }
    public List<Item> Items(){
        return items;
    }
    public void Buy(Shop shop, String name) throws NotEnoughFundsException, ItemNotAvailableException, CannotReturnException{
        Item i = shop.Buy(name, wallet);
        items.add(i);
    }
    public void Return(Shop shop, Item i) throws CannotReturnException{
        shop.Return(i);
        items.remove(i);
        wallet.Funds += i.Value();
    }
}
