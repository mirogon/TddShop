package Shop;

import Item.Item;
import Item.ItemBatch;
import Customer.Wallet;

import org.junit.Assert;
import org.junit.Test;
import static org.junit.Assert.assertEquals;
import org.junit.Assert;

import javax.xml.crypto.dsig.CanonicalizationMethod;

public class ShopTest {
    @Test
    public void AddItem_AddsItem(){
        Shop shop = new Shop();
        assertEquals(0, shop.Items().size());

        Item i = new Item("Black Shirt", 15);
        ItemBatch batch = new ItemBatch(i, 100);
        shop.Add(batch);

        assertEquals(1, shop.Items().size());
        assertEquals(100, shop.Items().get(0).Stock);
    }
    @Test
    public void Add_TwoTimes_AddsStock(){
        Shop shop = new Shop();
        Item i = new Item("Black Shirt", 15);
        ItemBatch b = new ItemBatch(i, 100);
        shop.Add(b);

        assertEquals(1, shop.Items().size());
        assertEquals(100, shop.StockAvailable("Black Shirt"));

        shop.Add(b);

        assertEquals(1, shop.Items().size());
        assertEquals(200, shop.StockAvailable("Black Shirt"));
    }
    @Test
    public void StickAvailable_WithoutItems_IsZero(){
        Shop shop = new Shop();
        assertEquals(0, shop.StockAvailable("Pink Pants"));
    }
    @Test
    public void Revenue_AtBegin_Zero(){
        Shop shop = new Shop();
        assertEquals(0, shop.Revenue());
    }
    @Test
    public void Buy_ReducesFunds() throws NotEnoughFundsException, ItemNotAvailableException{
        Shop shop = new Shop();
        Item item = new Item("Black Shirt", 15);
        ItemBatch batch = new ItemBatch(item, 25);

        shop.Add(batch);

        assertEquals(25, shop.StockAvailable("Black Shirt"));

        Wallet wallet = new Wallet(100);
        shop.Buy("Black Shirt", wallet);

        assertEquals(85, wallet.Funds);
        assertEquals(24, shop.StockAvailable("Black Shirt"));
    }
    @Test(expected = NotEnoughFundsException.class)
    public void Buy_NotEnoughFunds_Throws() throws NotEnoughFundsException,ItemNotAvailableException {
        Shop shop = new Shop();
        Item item = new Item("Black Shirt", 15);
        ItemBatch batch = new ItemBatch(item, 11);

        shop.Add(batch);

        Wallet w = new Wallet(10);
        shop.Buy("Black Shirt", w);
    }
    @Test(expected = ItemNotAvailableException.class)
    public void Buy_NonExisting_Throws() throws NotEnoughFundsException, ItemNotAvailableException{
        Shop shop = new Shop();
        Wallet w = new Wallet(500);
        shop.Buy("Black Shirt", w);
    }
    @Test
    public void Item_AfterBought_IsGone() throws NotEnoughFundsException, ItemNotAvailableException{
        Shop shop = new Shop();
        Item i = new Item("Yellow Shoes", 55);
        ItemBatch batch = new ItemBatch(i, 1);
        shop.Add(batch);

        Assert.assertEquals(1, shop.Items().size());

        Wallet w = new Wallet(100);
        shop.Buy("Yellow Shoes", w);

        Assert.assertEquals(0, shop.Items().size());
    }
    @Test
    public void Revenue_AfterPurchase_Correct() throws NotEnoughFundsException, ItemNotAvailableException{
        Shop shop = new Shop();
        Item item = new Item("Black Shirt",15);
        Item item2 = new Item("Yellow Shoes", 55);

        ItemBatch shirtBatch = new ItemBatch(item, 100);
        ItemBatch shoeBatch = new ItemBatch(item2, 150);

        shop.Add(shirtBatch);
        shop.Add(shoeBatch);

        assertEquals(0, shop.Revenue());

        Wallet w = new Wallet(1000);
        shop.Buy("Black Shirt", w);

        assertEquals(item.Value(), shop.Revenue());

        shop.Buy("Yellow Shoes", w);
        assertEquals(item.Value() + item2.Value(), shop.Revenue());
    }
    @Test
    public void Return_ReturnsItemAndRevenue() throws NotEnoughFundsException, ItemNotAvailableException, CannotReturnException {
        Shop shop = new Shop();
        Item i = new Item("Black Shirt", 15);
        ItemBatch batch = new ItemBatch(i, 1);

        shop.Add(batch);

        assertEquals(1, shop.Items().size());

        Wallet wallet = new Wallet(1000);
        Item boughtItem = shop.Buy("Black Shirt", wallet);
        assertEquals(0, shop.Items().size());
        assertEquals(i.Value(), shop.Revenue());

        shop.Return(boughtItem);

        assertEquals(1, shop.Items().size());
        assertEquals(0, shop.Revenue());
    }
    @Test
    public void Return_WhenBoughtBefore_Works() throws NotEnoughFundsException, ItemNotAvailableException, CannotReturnException{
        Shop shop = new Shop();
        Item i = new Item("Black Shirt", 15);
        ItemBatch batch = new ItemBatch(i,1);

        shop.Add(batch);

        Wallet w = new Wallet(1000);
        Item boughtItem = shop.Buy("Black Shirt", w);
        shop.Return(boughtItem);
    }
    @Test(expected = CannotReturnException.class)
    public void Return_WhenNotBoughtBefore_Throws() throws CannotReturnException{
        Shop shop = new Shop();
        Item i = new Item("Black Shirt", 15);
        ItemBatch batch = new ItemBatch(i,1);

        shop.Add(batch);

        shop.Return(i);
    }
}
