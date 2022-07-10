package Ui;


import java.util.List;
import java.util.ArrayList;

import Customer.*;
import org.junit.Assert;
import org.junit.Test;
import static org.junit.Assert.assertEquals;
import org.junit.Assert;
import static org.mockito.Mockito.*;

import Item.*;

public class ConsoleUiTest {
    @Test
    public void MainMenu_CallsConstructMainMenu(){
        UiTextCreator textCreatorMock = mock(UiTextCreator.class);
        ConsoleInput consoleInputMock = mock(ConsoleInput.class);
        Ui ui = new ConsoleUi(textCreatorMock, consoleInputMock);

        when(textCreatorMock.ConstructMainMenu()).thenReturn("");
        when(consoleInputMock.ReadLine()).thenReturn("1");

        String actual = ui.MainMenu();

        verify(textCreatorMock).ConstructMainMenu();
        verify(consoleInputMock).ReadLine();
        assertEquals("1", actual);
    }
    @Test
    public void ShopMenu_CallsConstructShopMenu(){
        UiTextCreator textCreatorMock = mock(UiTextCreator.class);
        ConsoleInput consoleInputMock = mock(ConsoleInput.class);
        Ui ui = new ConsoleUi(textCreatorMock, consoleInputMock);

        List<ItemBatch> itemBatches = new ArrayList<ItemBatch>();
        Item i = new Item("Brown Jacket", 80);
        ItemBatch b = new ItemBatch(i, 1);
        itemBatches.add(b);

        ui.ShopMenu(itemBatches);

        verify(textCreatorMock).ConstructShopMenu(itemBatches);
        verify(consoleInputMock).ReadLine();
    }
    @Test
    public void CustomerMenu_CallsConstructMainMenu(){
        UiTextCreator textCreatorMock = mock(UiTextCreator.class);
        ConsoleInput consoleInputMock = mock(ConsoleInput.class);
        Ui ui = new ConsoleUi(textCreatorMock, consoleInputMock);

        Customer c = new Customer(new Wallet(1000));

        String input = ui.CustomerMenu(c);

        verify(textCreatorMock).ConstructCustomerMenu(c);
        verify(consoleInputMock).ReadLine();
    }
    @Test
    public void CustomerBuyMenu_CallsConstructCustomerBuyMenu(){
        UiTextCreator textCreatorMock = mock(UiTextCreator.class);
        ConsoleInput consoleInputMock = mock(ConsoleInput.class);
        Ui ui = new ConsoleUi(textCreatorMock, consoleInputMock);

        List<ItemBatch> items = new ArrayList<ItemBatch>();
        items.add(new ItemBatch(new Item("Black Shoe", 44), 1));

        String input = ui.CustomerBuyMenu(items);

        verify(textCreatorMock).ConstructCustomerBuyMenu(items);
        verify(consoleInputMock).ReadLine();
    }
}
