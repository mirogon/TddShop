using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace ShopTest.App {
    using Shop.Customers;
    using Shop;
    using Shop.App;
    using Shop.Ui;
    using Shop.Items;
    public class AppTest {
        [Fact]
        public void Start_ShowsMainMenu() {
            Customer customer = new Customer(1000);
            Shop shop = new Shop();
            var uiMock = new Mock<Ui>();
            uiMock.Setup(ui => ui.MainMenu());
            App app = new App(uiMock.Object, customer, shop);

            app.Start();

            uiMock.Verify(ui => ui.MainMenu());
        }
        [Fact]
        public void MainMenu_With1Input_AppCallsShopMenu() {
            Customer customer = new Customer(1000);
            Shop shop = new Shop();
            var uiMock = new Mock<Ui>();
            uiMock.Setup(ui => ui.MainMenu()).Returns("1");

            App app = new App(uiMock.Object, customer, shop);

            Item item = new Item("TestItem", 150);
            ItemBatch itemBatch = new ItemBatch(item , 1);
            shop.Add(itemBatch);

            app.Start();

            uiMock.Verify(ui => ui.MainMenu());
            uiMock.Verify(ui => ui.ShopMenu(shop.Items));
        }
        [Fact]
        public void MainMenu_With2Input_AppCallsCustomerMenu() {
            Customer customer = new Customer(1000);
            Shop shop = new Shop();
            var uiMock = new Mock<Ui>();
            uiMock.Setup(ui => ui.MainMenu()).Returns("2");

            App app = new App(uiMock.Object, customer, shop);

            app.Start();

            uiMock.Verify(ui => ui.MainMenu());
            uiMock.Verify(ui => ui.CustomerMenu(customer));
        }
    }
}
