package Customer;

import org.junit.Assert;
import org.junit.Test;
import static org.junit.Assert.assertEquals;
import Shop.*;
import Item.*;

public class CustomerTest {
    @Test
    public void Funds_EqualsGiven(){
        Wallet w = new Wallet(101);
        Customer customer = new Customer(w);
        assertEquals(101, customer.Wallet().Funds);

        Wallet w2 = new Wallet(11);
        Customer customer2 = new Customer(w2);
        assertEquals(11, customer2.Wallet().Funds);
    }
    @Test
    public void Buy_FromShop_LowersFunds() throws NotEnoughFundsException, ItemNotAvailableException, CannotReturnException{
        Shop shop = new Shop();
        Item i = new Item("Black Shirt", 15);
        ItemBatch b = new ItemBatch(i, 1);
        shop.Add(b);

        Wallet w = new Wallet(100);
        Customer c = new Customer(w);
        c.Buy(shop, "Black Shirt");

        Assert.assertEquals(85, c.Wallet().Funds);
    }
    @Test
    public void Buy_ReceivesItem() throws NotEnoughFundsException, ItemNotAvailableException, CannotReturnException{
        Shop shop = new Shop();
        Item i = new Item("Black Shirt", 15);
        ItemBatch batch = new ItemBatch(i,1);
        shop.Add(batch);

        Customer customer = new Customer(new Wallet(100));
        assertEquals(0, customer.Items().size());

        customer.Buy(shop, "Black Shirt");

        assertEquals(1, customer.Items().size());;
        assertEquals(i, customer.Items().get(0));
    }
    @Test
    public void Return_ReturnsItemAndMoney() throws ItemNotAvailableException, NotEnoughFundsException, CannotReturnException{
        Shop shop = new Shop();
        Item i = new Item("Black Shirt", 15);
        ItemBatch batch = new ItemBatch(i, 1);
        shop.Add(batch);

        Customer customer = new Customer(new Wallet(100));

        customer.Buy(shop, "Black Shirt");
        Assert.assertEquals(1, customer.Items().size());
        Assert.assertEquals(85, customer.Wallet().Funds);

        customer.Return(shop, customer.Items().get(0));

        assertEquals(0, customer.Items().size());
        assertEquals(100, customer.Wallet().Funds);
    }
}
