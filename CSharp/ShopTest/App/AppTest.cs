using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopTest.App {
    using Shop.Customers;
    using Shop;
    using Shop.App;
    public class AppTest {
        [Fact]
        public void Create() {
            Customer customer = new Customer(1000);
            Shop shop = new Shop();
            App app = new App(customer, shop);
        }
    }
}
