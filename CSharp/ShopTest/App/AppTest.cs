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
            uiMock.Setup(ui => ui.MainMenu()).Returns("0");
            App app = new App(uiMock.Object, customer, shop);

            app.Update();

            uiMock.Verify(ui => ui.MainMenu());
        }
        [Fact]
        public void MainMenu_WithSHOPInput_CallsShopMenu() {
            Customer customer = new Customer(1000);
            Shop shop = new Shop();
            var uiMock = new Mock<Ui>();
            uiMock.Setup(ui => ui.MainMenu()).Returns("SHOP");

            App app = new App(uiMock.Object, customer, shop);

            Item item = new Item("TestItem", 150);
            ItemBatch itemBatch = new ItemBatch(item , 1);
            shop.Add(itemBatch);

            app.Update();
            app.Update();

            uiMock.Verify(ui => ui.MainMenu());
            uiMock.Verify(ui => ui.ShopMenu(shop.Items));
        }
        [Fact]
        public void MainMenu_WithCUSTOMERInput_CallsCustomerMenu() {
            Customer customer = new Customer(1000);
            Shop shop = new Shop();
            var uiMock = new Mock<Ui>();
            uiMock.Setup(ui => ui.MainMenu()).Returns("CUSTOMER");

            App app = new App(uiMock.Object, customer, shop);

            app.Update();
            app.Update();

            uiMock.Verify(ui => ui.MainMenu());
            uiMock.Verify(ui => ui.CustomerMenu(customer));
        }
        [Fact]
        public void MainMenu_WithEXITInput_Exits() {
            Customer customer = new Customer(1000);
            Shop shop = new Shop();
            var uiMock = new Mock<Ui>();
            uiMock.Setup(ui => ui.MainMenu()).Returns("Exit");

            App app = new App(uiMock.Object, customer, shop);

            Assert.True(app.Running);

            app.Update();

            Assert.False(app.Running);

            uiMock.Verify(ui => ui.MainMenu());
        }

        [Fact]
        public void ShopMenu_Back_ReturnsToMainMenu() {
            Customer customer = new Customer(1000);
            Shop shop = new Shop();
            var uiMock = new Mock<Ui>();
            uiMock.Setup(ui => ui.MainMenu()).Returns("SHOP");
            uiMock.Setup(ui => ui.ShopMenu(It.IsAny<List<ItemBatch>>())).Returns("BACK");

            App app = new App(uiMock.Object, customer, shop);

            Item item = new Item("TestItem", 150);
            ItemBatch itemBatch = new ItemBatch(item , 1);
            shop.Add(itemBatch);

            app.Update();
            app.Update();
            uiMock.Verify(ui => ui.MainMenu(), Times.Once);
            uiMock.Verify(ui => ui.ShopMenu(shop.Items));

            app.Update();
            uiMock.Verify(ui => ui.MainMenu(), Times.Exactly(2));
        }

        [Fact]
        public void CustomerMenu_WIthBACKInput_ReturnsToMainMenu() {
            Customer customer = new Customer(100);
            Shop shop = new Shop();
            var uiMock = new Mock<Ui>();
            uiMock.Setup(ui => ui.MainMenu()).Returns("CUSTOMER");
            uiMock.Setup(ui => ui.CustomerMenu(It.IsAny<Customer>())).Returns("BACK");

            App app = new App(uiMock.Object, customer, shop);

            app.Update();
            app.Update();

            uiMock.Verify(ui => ui.MainMenu(), Times.Once());
            uiMock.Verify(ui => ui.CustomerMenu(customer));

            app.Update();

            uiMock.Verify(ui => ui.MainMenu(), Times.Exactly(2));
        }
        [Fact]
        public void CustomerMenu_WithBuyInput_GoesToCustomerBuyMenu() {
            Customer customer = new Customer(100);
            Shop shop = new Shop();
            var uiMock = new Mock<Ui>();
            uiMock.Setup(ui => ui.MainMenu()).Returns("CUSTOMER");
            uiMock.Setup(ui => ui.CustomerMenu(It.IsAny<Customer>())).Returns("BUY");
            uiMock.Setup(ui => ui.CustomerBuyMenu(It.IsAny<List<ItemBatch>>()));

            App app = new App(uiMock.Object, customer, shop);

            app.Update();

            uiMock.Verify(ui => ui.MainMenu(), Times.Once());
            app.Update();

            uiMock.Verify(ui => ui.CustomerMenu(customer), Times.Once());

            app.Update();
            uiMock.Verify(ui => ui.CustomerBuyMenu(It.IsAny<List<ItemBatch>>()), Times.Once());
        }
        [Fact]
        public void CustomerMenu_WithRefundInput_GoesToCustomerRefundMenu() {
            Customer customer = new Customer(100);
            Shop shop = new Shop();
            var uiMock = new Mock<Ui>();
            uiMock.Setup(ui => ui.MainMenu()).Returns("CUSTOMER");
            uiMock.Setup(ui => ui.CustomerMenu(It.IsAny<Customer>())).Returns("REFUND");
            uiMock.Setup(ui => ui.CustomerRefundMenu(It.IsAny<List<Item>>()));

            App app = new App(uiMock.Object, customer, shop);

            app.Update();

            uiMock.Verify(ui => ui.MainMenu(), Times.Once());
            app.Update();

            uiMock.Verify(ui => ui.CustomerMenu(customer), Times.Once());

            app.Update();
            uiMock.Verify(ui => ui.CustomerRefundMenu(It.IsAny<List<Item>>()), Times.Once());
        }
        [Fact]
        public void CustomerBuyMenu_WithBACKInput_ReturnsToCustomerMenu() {
            Customer customer = new Customer(100);
            Shop shop = new Shop();
            var uiMock = new Mock<Ui>();
            uiMock.Setup(ui => ui.MainMenu()).Returns("CUSTOMER");
            uiMock.Setup(ui => ui.CustomerMenu(It.IsAny<Customer>())).Returns("BUY");
            uiMock.Setup(ui => ui.CustomerBuyMenu(It.IsAny<List<ItemBatch>>())).Returns("BACK");

            App app = new App(uiMock.Object, customer, shop);

            app.Update();
            uiMock.Verify(ui => ui.MainMenu(), Times.Once());

            app.Update();
            uiMock.Verify(ui => ui.CustomerMenu(It.IsAny<Customer>()), Times.Once());

            app.Update();
            uiMock.Verify(ui => ui.CustomerBuyMenu(It.IsAny<List<ItemBatch>>()), Times.Once());

            app.Update();
            uiMock.Verify(ui => ui.CustomerMenu(It.IsAny<Customer>()), Times.Exactly(2));
        }
        [Fact]
        public void CustomerBuyMenu_WithBuyInput_Buys() {
            Customer customer = new Customer(100);
            Shop shop = new Shop();
            var uiMock = new Mock<Ui>();

            Item redShoes = new Item("Red Shoes", 100);
            ItemBatch batch = new ItemBatch(redShoes, 1);
            shop.Add(batch);

            uiMock.Setup(ui => ui.MainMenu()).Returns("CUSTOMER");
            uiMock.Setup(ui => ui.CustomerMenu(It.IsAny<Customer>())).Returns("BUY");
            uiMock.Setup(ui => ui.CustomerBuyMenu(It.IsAny<List<ItemBatch>>())).Returns("Red Shoes");

            App app = new App(uiMock.Object, customer, shop);

            Assert.Single(shop.Items);
            Assert.Empty(customer.Items);

            app.Update();
            app.Update();
            app.Update();

            Assert.Empty(shop.Items);
            Assert.Single(customer.Items);
        }
        [Fact] 
        public void CustomerRefundMenu_WithRefundInput_RefundsItem() {
            Customer customer = new Customer(100);
            Shop shop = new Shop();
            var uiMock = new Mock<Ui>();

            Item redShoes = new Item("Red Shoes", 100);
            ItemBatch batch = new ItemBatch(redShoes, 1);
            shop.Add(batch);

            customer.Buy(shop, "Red Shoes");

            uiMock.Setup(ui => ui.MainMenu()).Returns("Customer");
            uiMock.Setup(ui => ui.CustomerMenu(It.IsAny<Customer>())).Returns("Refund");
            uiMock.Setup(ui => ui.CustomerRefundMenu(It.IsAny<List<Item>>())).Returns("Red Shoes");

            App app = new App(uiMock.Object, customer, shop);

            Assert.Empty(shop.Items);
            Assert.Single(customer.Items);

            app.Update();
            app.Update();
            app.Update();

            Assert.Empty(customer.Items);
            Assert.Single(shop.Items);
        }

    }
}
