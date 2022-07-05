package Ui;

import Customer.Customer;
import org.junit.Assert;
import org.junit.Test;
import static org.junit.Assert.assertEquals;
import org.junit.Assert;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import Item.*;
import Shop.*;
import Customer.Wallet;

class ConsoleUiTextCreatorTestHelper{
    public static String LoadFromFile(String fileName) throws FileNotFoundException, IOException {
        FileInputStream fileStream = new FileInputStream(fileName);
        byte[] buffer = new byte[2048];
        int read = fileStream.read(buffer);
        fileStream.close();
        String s = new String(buffer);
        s = s.trim();
        return s;
    }
}
public class ConsoleUiTextCreatorTest {
    @Test
    public void TestTestHelper() throws IOException{
        FileOutputStream outputStream = new FileOutputStream("NewFile");
        outputStream.flush();
        outputStream.close();
        String actual = ConsoleUiTextCreatorTestHelper.LoadFromFile("TestHelperTest");
        assertEquals("Hello, There!", actual);
    }
    @Test
    public void ConstructMainMenu_Correct() throws IOException{
        ConsoleUiTextCreator textCreator = new ConsoleUiTextCreator();
        String actual = textCreator.ConstructMainMenu();
        String expected = ConsoleUiTextCreatorTestHelper.LoadFromFile("ConstructMainMenu");
        assertEquals(expected, actual);
    }
    @Test
    public void ConstructShopMenu_WithItems() throws IOException{
        ConsoleUiTextCreator textCreator = new ConsoleUiTextCreator();
        List<ItemBatch> items = new ArrayList<ItemBatch>();
        items.add(new ItemBatch(new Item("Black Shirt", 15), 110));
        String result = textCreator.ConstructShopMenu(items);
        String expected = ConsoleUiTextCreatorTestHelper.LoadFromFile("ConstructShopMenu1");
        assertEquals(expected,result);
    }
    @Test
    public void ConstructCustomerMenu_WithItem() throws NotEnoughFundsException, CannotReturnException, ItemNotAvailableException, IOException {
        ConsoleUiTextCreator textCreator = new ConsoleUiTextCreator();

        Shop shop = new Shop();
        ItemBatch itemBatch = new ItemBatch(new Item("Black Shirt", 15), 2);
        shop.Add(itemBatch);

        Customer customer = new Customer(new Wallet(1000));
        customer.Buy(shop, "Black Shirt");
        customer.Buy(shop, "Black Shirt");

        String expected = ConsoleUiTextCreatorTestHelper.LoadFromFile("ConstructCustomerMenu");
        String actual = textCreator.ConstructCustomerMenu(customer);
        assertEquals(expected, actual);
    }
    @Test
    public void ConstructCustomerBuyMenu() throws IOException {
        ConsoleUiTextCreator textCreator = new ConsoleUiTextCreator();

        Shop shop = new Shop();

        Item i = new Item("Red Shoes", 15);
        ItemBatch batch = new ItemBatch(i, 1);
        shop.Add(batch);

        String expected = ConsoleUiTextCreatorTestHelper.LoadFromFile("ConstructCustomerBuyMenu");
        String actual = textCreator.ConstructCustomerBuyMenu(shop.Items());
        assertEquals(expected, actual);
    }
}
