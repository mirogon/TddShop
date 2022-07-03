package Shop;

import Item.Item;
import Item.ItemBatch;
import org.junit.Assert;
import org.junit.Test;
import static org.junit.Assert.assertEquals;

public class ShopTest {
    @Test
    public void AddItem_AddsItem(){
        Shop shop = new Shop();
        Assert.assertEquals(0, shop.Items().size());

        Item i = new Item("Black Shirt", 15);
        ItemBatch batch = new ItemBatch(i, 100);
        shop.Add(batch);

        Assert.assertEquals(1, shop.Items().size());
        Assert.assertEquals(100, shop.Items().get(0).Stock);
    }
    @Test
    public void Add_TwoTimes_AddsStock(){
        Shop shop = new Shop();
        Item i = new Item("Black Shirt", 15);
        ItemBatch b = new ItemBatch(i, 100);
        shop.Add(b);

        Assert.assertEquals(1, shop.Items().size());
        Assert.assertEquals(100, shop.StockAvailable("Black Shirt"));

        shop.Add(b);

        Assert.assertEquals(1, shop.Items().size());
        Assert.assertEquals(200, shop.StockAvailable("Black Shirt"));
    }
    @Test
    public void StickAvailable_WithoutItems_IsZero(){
        Shop shop = new Shop();
        Assert.assertEquals(0, shop.StockAvailable("Pink Pants"));
    }
    @Test
    public void Revenue_AtBegin_Zero(){
        Shop shop = new Shop();
        assertEquals(0, shop.Revenue());
    }
}
