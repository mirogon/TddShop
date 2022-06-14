using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopTest.Customer {
    using Shop.Customers;
    using Shop.Items;
    using Shop;
    public class CustomerTest {
        [Fact]
        public void Funds_EqualsGivenMoney() {
            Customer customer = new Customer(100);
            Assert.Equal(100, customer.Funds);

            Customer customer2 = new Customer(150);
            Assert.Equal(150, customer2.Funds);
        }

        [Fact]
        public void Buy_FromShop_LowersFunds() {
            Shop shop = new Shop();
            Item i = new Item("Black Shirt", 15);
            shop.AddItem(i);

            Customer customer = new Customer(100);
            customer.Buy(shop, "Black Shirt");

            Assert.Equal(85, customer.Funds);
        }
        [Fact]
        public void Buy_ReceivesItem() {
            Shop shop = new Shop();
            Item i = new Item("Black Shirt", 15);
            shop.AddItem(i);

            Customer customer = new Customer(100);

            Assert.Empty(customer.Items);

            customer.Buy(shop, "Black Shirt");

            Assert.Single(customer.Items);
            Assert.Equal(i, customer.Items[0]);
        }
        [Fact]
        public void Return_ReturnsItem() {
            Shop shop = new Shop();
            Item i = new Item("Black Shirt", 15);
            shop.AddItem(i);

            Customer customer = new Customer(100);

            customer.Buy(shop, "Black Shirt");
            Assert.Single(customer.Items);
            Assert.Equal(85, customer.Funds);

            customer.Return(shop, customer.Items[0]);
    
            Assert.Empty(customer.Items);
            Assert.Equal(100, customer.Funds);
        }
    }
}
