using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopTest.Ui {
    using Shop.Ui;
    using Shop.Items;
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
            Assert.Equal("Shop Menu:\nName, Price, Stock\nBlack Shirt 15 110", result);
        }
    }
}
