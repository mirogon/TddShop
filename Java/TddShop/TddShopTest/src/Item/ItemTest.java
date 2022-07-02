package Item;

import org.junit.Assert;
import org.junit.Test;
import static org.junit.Assert.assertEquals;

public class ItemTest {
    @Test
    public void NameAndValue_EqualGiven(){
        Item i = new Item("Black Shirt", 50);
        Assert.assertEquals("Black Shirt", i.Name());
        Assert.assertEquals(50, i.Value());
    }
}
