using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xunit;

namespace ShopTest.Ui.CLI {
    using Shop.Items;
    using Shop.Customers;
    using Shop;
    using Shop.Ui.CLI;
    public class ConsoleUiBuilderTestHelper {
        public static string LoadFromFile(string fileName) {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            byte[] buffer = new byte[2048];
            int nonNulls = fs.Read(buffer, 0, buffer.Length);
            return Encoding.ASCII.GetString(buffer, 0, nonNulls);
        }
    }
    public class ConsoleUiBuilderTest {
        [Fact]
        public void ConstructMainMenu_Correct() {
            UiTextCreator uiBuilder = new ConsoleUiTextCreator();
            string actual = uiBuilder.ConstructMainMenu();
            string expected = ConsoleUiBuilderTestHelper.LoadFromFile("TestData/ConstructMainMenu");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConstructShopMenu_WithItems() {
            UiTextCreator builder = new ConsoleUiTextCreator();
            List<ItemBatch> items = new List<ItemBatch>();
            items.Add(new ItemBatch(new Item("Black Shirt", 15), 110));
            string result = builder.ConstructShopMenu(items);
            string expected = ConsoleUiBuilderTestHelper.LoadFromFile("TestData/ConstructShopMenu1");
            Assert.Equal(expected, result);
        }
        [Fact]
        public void ConstructCustomerMenu_WithItem() {
            UiTextCreator builder = new ConsoleUiTextCreator();

            Shop shop = new Shop();

            ItemBatch itemBatch = new ItemBatch(new Item("Black Shirt", 15), 2);
            shop.Add(itemBatch);

            Customer c = new Customer(1000);
            c.Buy(shop, "Black Shirt");
            c.Buy(shop, "Black Shirt");

            string expected = ConsoleUiBuilderTestHelper.LoadFromFile("TestData/ConstructCustomerMenu");
            string actual = builder.ConstructCustomerMenu(c);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ConstructCustomerBuyMenu() {
            UiTextCreator builder = new ConsoleUiTextCreator();

            Shop shop = new Shop();

            Item item = new Item("Red Shoes", 15);
            ItemBatch itemBatch = new ItemBatch(item, 1);
            shop.Add(itemBatch);

            string expected = ConsoleUiBuilderTestHelper.LoadFromFile("TestData/ConstructCustomerBuyMenu");
            string actual = builder.ConstructCustomerBuyMenu(shop.Items);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ConstructCustomerRefundMenu() {
            UiTextCreator builder = new ConsoleUiTextCreator();

            Customer c = new Customer(1000);

            Shop shop = new Shop();
            Item item = new Item("Blue Pants", 60);
            shop.Add(new ItemBatch(item, 1));

            c.Buy(shop, "Blue Pants");

            string expected = ConsoleUiBuilderTestHelper.LoadFromFile("TestData/ConstructCustomerRefundMenu");
            string actual = builder.ConstructCustomerRefundMenu(c.Items);

            Assert.Equal(expected, actual);
        }

    }
}
