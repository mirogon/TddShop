using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xunit;

namespace ShopTest.Ui {
    using Shop.Ui;
    using Shop.Items;
    public class ConsoleUiTextSourceTestHelper {
        public static string LoadFromFile(string fileName) {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            byte[] buffer = new byte[2048];
            int nonNulls = fs.Read(buffer, 0, buffer.Length);
            return Encoding.ASCII.GetString(buffer, 0, nonNulls);
        }
    }
    public class ConsoleUiTextSourceTest {
        [Fact]
        public void ConstructShopMenu_WithoutItems() {
            ConsoleUiTextSource textSource = new ConsoleUiTextSource();
            List<ItemBatch> items = new List<ItemBatch>();
            string result = textSource.ConstructShopMenu(items);
            Assert.Equal("Shop Menu:", result);
        }
        [Fact]
        public void ConstructShopMenu_WithItems() {
            ConsoleUiTextSource textSource = new ConsoleUiTextSource();
            List<ItemBatch> items = new List<ItemBatch>();
            items.Add(new ItemBatch(new Item("Black Shirt", 15), 110));
            string result = textSource.ConstructShopMenu(items);
            string expected = ConsoleUiTextSourceTestHelper.LoadFromFile("ConstructShopMenu1");
            Assert.Equal(expected, result);
        }
    }
}
