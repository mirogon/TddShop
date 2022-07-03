package Customer;

import org.junit.Test;
import static org.junit.Assert.assertEquals;

public class WalletTest {
    @Test
    public void Funds_EquaGiven(){
        Wallet w = new Wallet(150);
        assertEquals(150, w.Funds);
    }
}
