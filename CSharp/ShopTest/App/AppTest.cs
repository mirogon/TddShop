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
    }
}
