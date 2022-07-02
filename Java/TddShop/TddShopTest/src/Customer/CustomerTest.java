package Customer;

import org.junit.Assert;
import org.junit.Test;
import static org.junit.Assert.assertEquals;

public class CustomerTest {
    @Test
    public void Funds_EqualsGiven(){
        Customer customer = new Customer(101);
        assertEquals(101, customer.Funds());

        Customer customer2 = new Customer(11);
        assertEquals(11, customer2.Funds());
    }
}
