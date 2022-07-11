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
    public void Start_ShowsMainMenu() throws NotEnoughFundsException, CannotReturnException, ItemNotAvailableException {
        Customer c = new Customer(new Wallet(1000));
        Shop shop = new Shop();
        Ui uiMock = mock(Ui.class);

        when(uiMock.MainMenu()).thenReturn("");

        App app = new App(uiMock, c, shop);

        app.Update();

        verify(uiMock).MainMenu();
    }
    @Test
    public void MainMenu_WithShopInput_CallsShopMenu() throws NotEnoughFundsException, CannotReturnException, ItemNotAvailableException {
        Customer c = new Customer(new Wallet(1000));
        Shop shop = new Shop();
        Ui uiMock = mock(Ui.class);

        when(uiMock.MainMenu()).thenReturn("Shop");
        when(uiMock.ShopMenu(any())).thenReturn("");

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
    public void MainMenu_WithCustomerInput_CallsCustomerMenu() throws NotEnoughFundsException, CannotReturnException, ItemNotAvailableException {
        Customer c = new Customer(new Wallet(1000));
        Shop shop = new Shop();
        Ui uiMock = mock(Ui.class);

        when(uiMock.MainMenu()).thenReturn("Customer");
        when(uiMock.CustomerMenu(any())).thenReturn("");

        App app = new App(uiMock, c, shop);

        app.Update();
        app.Update();

        verify(uiMock).MainMenu();
        verify(uiMock).CustomerMenu(c);
    }
    @Test
    public void MainMenu_WithExitInput_Exits() throws NotEnoughFundsException, CannotReturnException, ItemNotAvailableException {
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
    public void ShopMenu_Back_ReturnsToMainMenu() throws NotEnoughFundsException, CannotReturnException, ItemNotAvailableException {
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
    public void CustomerMenu_WithBackInput_ReturnsToMainMenu() throws NotEnoughFundsException, CannotReturnException, ItemNotAvailableException {
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
    public void CustomerMenu_WithBuyInput_GoesToCustomerBuyMenu() throws NotEnoughFundsException, CannotReturnException, ItemNotAvailableException {
        Customer customer = new Customer(new Wallet(1000));
        Shop shop = new Shop();
        Ui uiMock = mock(Ui.class);

        when(uiMock.MainMenu()).thenReturn("Customer");
        when(uiMock.CustomerMenu(any())).thenReturn("Buy");
        when(uiMock.CustomerBuyMenu(any())).thenReturn("");

        App app = new App(uiMock, customer, shop);

        app.Update();
        verify(uiMock).MainMenu();
        app.Update();
        verify(uiMock).CustomerMenu(customer);
        app.Update();
        verify(uiMock).CustomerBuyMenu(any());
    }
    @Test
    public void CustomerMenu_WithRefundInput_GoesToCustomerRefundMenu() throws NotEnoughFundsException, CannotReturnException, ItemNotAvailableException {
        Customer customer = new Customer(new Wallet(1000));
        Shop shop = new Shop();
        Ui uiMock = mock(Ui.class);

        when(uiMock.MainMenu()).thenReturn("Customer");
        when(uiMock.CustomerMenu(any())).thenReturn("Refund");
        when(uiMock.CustomerRefundMenu(any())).thenReturn("");

        App app = new App(uiMock, customer, shop);

        app.Update();

        verify(uiMock).MainMenu();
        app.Update();

        verify(uiMock).CustomerMenu(customer);
        app.Update();

        verify(uiMock).CustomerRefundMenu(any());
    }
    @Test
    public void CustomerBuyMenu_WithBackInput_ReturnsToCustomerMenu() throws NotEnoughFundsException, CannotReturnException, ItemNotAvailableException {
        Customer customer = new Customer(new Wallet(1000));
        Shop shop = new Shop();
        Ui uiMock = mock(Ui.class);

        when(uiMock.MainMenu()).thenReturn("Customer");
        when(uiMock.CustomerMenu(any())).thenReturn("Buy");
        when(uiMock.CustomerBuyMenu(any())).thenReturn("Back");

        App app = new App(uiMock, customer, shop);

        app.Update();
        verify(uiMock).MainMenu();

        app.Update();
        verify(uiMock).CustomerMenu(customer);

        app.Update();
        verify(uiMock).CustomerBuyMenu(any());

        app.Update();
        verify(uiMock, times(2)).CustomerMenu(customer);
    }
    @Test
    public void CustomerBuyMenu_WithBuyInput_Buys() throws NotEnoughFundsException, CannotReturnException, ItemNotAvailableException {
        Customer customer = new Customer(new Wallet(1000));
        Shop shop = new Shop();
        Ui uiMock = mock(Ui.class);

        Item redShoes = new Item("Red Shoes", 100);
        ItemBatch batch = new ItemBatch(redShoes, 1);
        shop.Add(batch);

        when(uiMock.MainMenu()).thenReturn("Customer");
        when(uiMock.CustomerMenu(any())).thenReturn("Buy");
        when(uiMock.CustomerBuyMenu(any())).thenReturn("Red Shoes");

        App app = new App(uiMock, customer, shop);

        assertEquals(1, shop.Items().size());
        assertEquals(0, customer.Items().size());

        app.Update();
        app.Update();
        app.Update();

        assertEquals(0, shop.Items().size());
        assertEquals(1, customer.Items().size());
    }
    @Test
    public void CustomerRefundMenu_WithBackInput_ReturnsToCustomerMenu() throws NotEnoughFundsException, CannotReturnException, ItemNotAvailableException {
        Customer customer = new Customer(new Wallet(1000));
        Shop shop = new Shop();
        Ui uiMock = mock(Ui.class);

        when(uiMock.MainMenu()).thenReturn("Customer");
        when(uiMock.CustomerMenu(any())).thenReturn("Refund");
        when(uiMock.CustomerRefundMenu(any())).thenReturn("Back");

        App app = new App(uiMock, customer, shop);

        app.Update();
        verify(uiMock).MainMenu();

        app.Update();
        verify(uiMock).CustomerMenu(customer);

        app.Update();
        verify(uiMock).CustomerRefundMenu(any());

        app.Update();
        verify(uiMock, times(2)).CustomerMenu(any());
    }
    @Test
    public void CustomerRefundMenu_WithRefundInput_RefundsItem() throws NotEnoughFundsException, CannotReturnException, ItemNotAvailableException {
        Customer customer = new Customer(new Wallet(1000));
        Shop shop = new Shop();
        Ui uiMock = mock(Ui.class);

        Item redShoes = new Item("Red Shoes", 100);
        ItemBatch batch = new ItemBatch(redShoes, 1);
        shop.Add(batch);

        customer.Buy(shop, "Red Shoes");

        when(uiMock.MainMenu()).thenReturn("Customer");
        when(uiMock.CustomerMenu(any())).thenReturn("Refund");
        when(uiMock.CustomerRefundMenu(any())).thenReturn("Red Shoes");

        App app = new App(uiMock, customer ,shop);

        assertEquals(0, shop.Items().size());
        assertEquals(1, customer.Items().size());

        app.Update();
        app.Update();
        app.Update();

        assertEquals(1, shop.Items().size());
        assertEquals(0, customer.Items().size());

    }

}
