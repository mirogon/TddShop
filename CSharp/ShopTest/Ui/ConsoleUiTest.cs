using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopTest.UI {
    using Shop.Ui;
    using Shop.Items;
    public class ConsoleUiTest {
        [Fact]
        public void MainMenu() {
            ConsoleUiTextSource textSource = new ConsoleUiTextSource();
            Ui ui = new ConsoleUi(textSource);
        }
        [Fact]
        public void ShopMenu() {
            ConsoleUiTextSource textSource = new ConsoleUiTextSource();
            Ui ui = new ConsoleUi(textSource);
            List<ItemBatch> items = new List<ItemBatch>();
            items.Add(new ItemBatch(new Item("Black Shirt", 15), 100));
            //ui.ShopMenu(items);  
        }
        
    }
}
