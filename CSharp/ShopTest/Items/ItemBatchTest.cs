using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopTest.Items {
    using Shop.Items;
    public class ItemBatchTest {
        [Fact]
        public void ItemAndStock_EqualsGiven() {
            Item i = new Item("Blue Shoes", 50);
            ItemBatch batch = new ItemBatch(i, 100);

            Assert.Equal(i, batch.Item);
            Assert.Equal(100, batch.Stock);
        }
    }
}
