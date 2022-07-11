package App;

import Item.*;
import org.junit.Assert;
import org.junit.Test;

import static org.junit.Assert.*;
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
    @Test
    public void MainMenu_WithCustomerInput_CallsCustomerMenu(){
        Customer c = new Customer(new Wallet(1000));
        Shop shop = new Shop();
        Ui uiMock = mock(Ui.class);

        when(uiMock.MainMenu()).thenReturn("Customer");

        App app = new App(uiMock, c, shop);

        app.Update();
        app.Update();

        verify(uiMock).MainMenu();
        verify(uiMock).CustomerMenu(c);
    }
    @Test
    public void MainMenu_WithExitInput_Exits(){
        Customer c = new Customer(new Wallet(1000));
        Shop shop = new Shop();
        Ui uiMock = mock(Ui.class);

        when(uiMock.MainMenu()).thenReturn("Exit");

        App app = new App(uiMock, c, shop);

        assertTrue(app.Running());

        app.Update();

        assertFalse(app.Running());

        verify(uiMock).MainMenu();
    }
    @Test
    public void ShopMenu_Back_ReturnsToMainMenu(){
        Customer customer = new Customer(new Wallet(1000));
        Shop shop = new Shop();
        Ui uiMock = mock(Ui.class);

        when(uiMock.MainMenu()).thenReturn("Shop");
        when(uiMock.ShopMenu(any())).thenReturn("Back");

        App app = new App(uiMock, customer, shop);

        Item item = new Item("TestItem", 150);
        ItemBatch itemBatch = new ItemBatch(item, 1);
        shop.Add(itemBatch);

        app.Update();
        app.Update();

        verify(uiMock).MainMenu();
        verify(uiMock).ShopMenu(shop.Items());

        app.Update();
        verify(uiMock, times(2)).MainMenu();
    }
    @Test
    public void CustomerMenu_WithBackInput_ReturnsToMainMenu(){
        Customer customer = new Customer(new Wallet(1000));
        Shop shop = new Shop();
        Ui uiMock = mock(Ui.class);

        when(uiMock.MainMenu()).thenReturn("Customer");
        when(uiMock.CustomerMenu(any())).thenReturn("Back");

        App app = new App(uiMock, customer, shop);

        app.Update();
        app.Update();

        verify(uiMock).MainMenu();
        verify(uiMock).CustomerMenu(customer);

        app.Update();

        verify(uiMock, times(2)).MainMenu();
    }
    @Test
    public void CustomerMenu_WithBuyInput_GoesToCustomerBuyMenu(){
        Customer customer = new Customer(new Wallet(1000));
        Shop shop = new Shop();
        Ui uiMock = mock(Ui.class);

        when(uiMock.MainMenu()).thenReturn("Customer");
        when(uiMock.CustomerMenu(any())).thenReturn("Buy");

        App app = new App(uiMock, customer, shop);

        app.Update();
        verify(uiMock).MainMenu();
        app.Update();
        verify(uiMock).CustomerMenu(customer);
        app.Update();
        verify(uiMock).CustomerBuyMenu(any());
    }

}
