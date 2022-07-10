package App;

import Item.*;
import org.junit.Assert;
import org.junit.Test;
import static org.junit.Assert.assertEquals;
import static org.mockito.Mockito.*;

import Customer.*;
import Shop.*;
import Ui.*;

public class AppTest {
    @Test
    public void Start_ShowsMainMenu(){
        Customer c = new Customer(new Wallet(1000));
        Shop shop = new Shop();
        Ui uiMock = mock(Ui.class);

        App app = new App(uiMock, c, shop);

        app.Update();

        verify(uiMock).MainMenu();
    }
    @Test
    public void MainMenu_WithShopInput_CallsShopMenu(){
        Customer c = new Customer(new Wallet(1000));
        Shop shop = new Shop();
        Ui uiMock = mock(Ui.class);

        when(uiMock.MainMenu()).thenReturn("Shop");

        App app = new App(uiMock, c, shop);

        Item i = new Item("TestItem", 150);
        ItemBatch itemBatch = new ItemBatch(i, 1);
        shop.Add(itemBatch);

        app.Update();
        app.Update();

        verify(uiMock).MainMenu();
        verify(uiMock).ShopMenu(shop.Items());
    }

}
