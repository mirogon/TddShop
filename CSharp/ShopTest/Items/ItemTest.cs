using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopTest.Items {
    using Shop.Items;
    public class ItemTest {
        [Fact]
        public void NameAndValue_MatchGiven() {
            Item i = new Item("Red Pants", 60);

            Assert.Equal("Red Pants", i.Name);
            Assert.Equal(60, i.Value);
        }
    }
}
