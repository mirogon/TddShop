using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace ShopTest.Ui {
    using Shop.Ui;
    using Shop.Items;
    using Shop.Customers;
    public class ConsoleUiTest {
        [Fact]
        public void MainMenu_CallsConstructMainMenu() {
            var consoleUiBuilderMock = new Mock<TextUiBuilder>();
            var consoleInput = new Mock<ConsoleInput>();

            Ui ui = new ConsoleUi(consoleUiBuilderMock.Object, consoleInput.Object);
            consoleUiBuilderMock.Setup(b => b.ConstructMainMenu());
            consoleInput.Setup(i => i.ReadLine());

            ui.MainMenu();

            consoleUiBuilderMock.Verify(b => b.ConstructMainMenu(), Times.Once());
            consoleInput.Verify(i => i.ReadLine(), Times.Once());
        }
        [Fact]
        public void ShopMenu_CallsConstructShopMenu() {
            var consoleUiBuilderMock = new Mock<TextUiBuilder>();
            var consoleInput = new Mock<ConsoleInput>();

            Ui ui = new ConsoleUi(consoleUiBuilderMock.Object, consoleInput.Object);
            consoleUiBuilderMock.Setup(b => b.ConstructShopMenu(It.IsAny<List<ItemBatch>>()));
            consoleInput.Setup(i => i.ReadLine());

            List<ItemBatch> itemBatches = new List<ItemBatch>();
            Item i = new Item("Brown Jacket", 80);
            ItemBatch b = new ItemBatch(i, 1);
            itemBatches.Add(b);

            ui.ShopMenu(itemBatches);

            consoleUiBuilderMock.Verify(b => b.ConstructShopMenu(itemBatches));
            consoleInput.Verify(i => i.ReadLine());
        }
        [Fact]
        public void CustomerMenu_CallsConstructCustomerMenu() {
            var consoleUiBuilderMock = new Mock<TextUiBuilder>();
            var consoleInput = new Mock<ConsoleInput>();

            Ui ui = new ConsoleUi(consoleUiBuilderMock.Object, consoleInput.Object);

            Customer c = new Customer(1000);

            consoleUiBuilderMock.Setup(b => b.ConstructCustomerMenu(It.IsAny<Customer>()));
            consoleInput.Setup(i => i.ReadLine());

            ui.CustomerMenu(c);

            consoleUiBuilderMock.Verify(uiBuilder => uiBuilder.ConstructCustomerMenu(c));
            consoleInput.Verify(input => input.ReadLine());
        }
    }
}
