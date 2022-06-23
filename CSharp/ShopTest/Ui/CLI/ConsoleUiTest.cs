using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace ShopTest.Ui.CLI {
    using Shop.Ui;
    using Shop.Items;
    using Shop.Customers;
    using Shop.Ui.CLI;

    public class ConsoleUiTest {
        [Fact]
        public void MainMenu_CallsConstructMainMenu() {
            var consoleUiBuilderMock = new Mock<UiTextCreator>();
            var consoleInput = new Mock<ConsoleInput>();

            Ui ui = new ConsoleUi(consoleUiBuilderMock.Object, consoleInput.Object);
            consoleUiBuilderMock.Setup(b => b.ConstructMainMenu());
            consoleInput.Setup(i => i.ReadLine()).Returns("1");

            string actual = ui.MainMenu();

            consoleUiBuilderMock.Verify(b => b.ConstructMainMenu(), Times.Once());
            consoleInput.Verify(i => i.ReadLine(), Times.Once());
            Assert.Equal("1", actual);
        }
        [Fact]
        public void ShopMenu_CallsConstructShopMenu() {
            var consoleUiBuilderMock = new Mock<UiTextCreator>();
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
            var consoleUiBuilderMock = new Mock<UiTextCreator>();
            var consoleInput = new Mock<ConsoleInput>();

            Ui ui = new ConsoleUi(consoleUiBuilderMock.Object, consoleInput.Object);

            Customer c = new Customer(1000);

            consoleUiBuilderMock.Setup(b => b.ConstructCustomerMenu(It.IsAny<Customer>()));
            consoleInput.Setup(i => i.ReadLine()).Returns("5");

            string input = ui.CustomerMenu(c);

            consoleUiBuilderMock.Verify(uiBuilder => uiBuilder.ConstructCustomerMenu(c));
            consoleInput.Verify(input => input.ReadLine());
            Assert.Equal("5", input);
        }
        [Fact]
        public void CustomerBuyMenu_CallsConstructCustomerBuyMenu() {
            var consoleUiBuilderMock = new Mock<UiTextCreator>();
            var consoleInput = new Mock<ConsoleInput>();

            Ui ui = new ConsoleUi(consoleUiBuilderMock.Object, consoleInput.Object);

            List<ItemBatch> items = new List<ItemBatch>();
            items.Add(new ItemBatch(new Item("Black Shoe", 44), 1));

            consoleUiBuilderMock.Setup(b => b.ConstructCustomerBuyMenu(It.IsAny<List<ItemBatch>>()));
            consoleInput.Setup(i => i.ReadLine()).Returns("TEST");

            string actual = ui.CustomerBuyMenu(items);

            consoleUiBuilderMock.Verify(uiBuilder => uiBuilder.ConstructCustomerBuyMenu(items));
            consoleInput.Verify(input => input.ReadLine());
            Assert.Equal("TEST", actual);

        }
        [Fact]
        public void CustomerRefundMenu_CallsConstructCustomerRefundMenu() {
            var consoleUiBuilderMock = new Mock<UiTextCreator>();
            var consoleInput = new Mock<ConsoleInput>();

            Ui ui = new ConsoleUi(consoleUiBuilderMock.Object, consoleInput.Object);

            consoleUiBuilderMock.Setup(b => b.ConstructCustomerRefundMenu(It.IsAny<List<Item>>()));
            consoleInput.Setup(i => i.ReadLine()).Returns("TEST");

            string actual = ui.CustomerRefundMenu(new List<Item>());

            consoleUiBuilderMock.Verify(uiBuilder => uiBuilder.ConstructCustomerRefundMenu(new List<Item>()));
            consoleInput.Verify(input => input.ReadLine());
            Assert.Equal("TEST", actual);
        }
    }
}
