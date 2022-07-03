package Item;

import org.junit.Assert;
import org.junit.Test;
import static org.junit.Assert.assertEquals;

public class ItemBatchTest {
    @Test
    public void ItemAndStock_EqualGiven(){
        Item i = new Item("Blue Shoes", 35);
        ItemBatch batch = new ItemBatch(i, 100);

        Assert.assertEquals(i, batch.Item());
        Assert.assertEquals(100, batch.Stock);
    }
}
