using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopTest.Items {
    using Shop.Items;
    public class BlackShirtTest {
        [Fact]
        public void Name_EqualsBlackShirt() {
            ItemOld blackShirt = new BlackShirt();
            Assert.Equal("Black Shirt", blackShirt.Name);
        }
        [Fact]
        public void Value_Equals15() {
            ItemOld blackShirt = new BlackShirt();
            Assert.Equal(15, blackShirt.Value);
        }
    }
}
