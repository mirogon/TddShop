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
        Assert.assertEquals(100, shop.Items().get(0).Stock());
    }
}
