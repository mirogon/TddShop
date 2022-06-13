using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopTest.Items {
    using Shop.Items;
    public class NullItemTest {
        Item item;
        public NullItemTest() {
            item = new NullItem();
        }
        [Fact]
        public void NullItem_HasNoName() {
            Assert.Equal("", item.Name);
        }
        [Fact]
        public void NullItem_HasNoValue() {
            Assert.Equal(0, item.Value);
        }
    }
}
