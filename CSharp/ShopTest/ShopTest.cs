using Xunit;

namespace ShopTest {
    using Shop;
    using Shop.Items;
    public class ShopTest {
        [Fact]
        public void AddItem_AddsNewItem() {
            Shop shop = new Shop();

            Assert.Empty(shop.Items);

            Item i = new Item("Black Shirt", 15);
            ItemBatch b = new ItemBatch(i, 100);
            shop.Add(b);

            Assert.Single(shop.Items);
            Assert.Equal(100, shop.Items[0].Stock);
        }
        [Fact]
        public void Revenue_AtBegin_Zero() {
            Shop shop = new Shop();
            Assert.Equal(0, shop.Revenue);
        }
        [Fact]
        public void Buy_ReducesFunds() {
            Shop shop = new Shop();
            Item item = new Item("Black Shirt", 15);
            ItemBatch batch = new ItemBatch(item, 25);

            shop.Add(batch);

            Assert.Equal(25, shop.Items[0].Stock);

            int funds = 100;
            shop.Buy("Black Shirt", ref funds);

            Assert.Equal(100 - item.Value, funds);
            Assert.Equal(24, shop.Items[0].Stock);
        }
        [Fact]
        public void Buy_NotEnoughFunds_Throws() {
            Shop shop = new Shop();
            Item item = new Item("Black Shirt", 15);
            ItemBatch batch = new ItemBatch(item, 11);
            shop.Add(batch);

            int funds = 10;
            Assert.Throws<NotEnoughFundsException>(() => {
                shop.Buy("Black Shirt", ref funds);
            });
        }
        [Fact]
        public void Buy_NonExisting_Throws() {
            Shop shop = new Shop();

            int funds = 100;
            Assert.Throws<ItemNotAvailableException>(() => {
                shop.Buy("Black Shirt", ref funds);
            });
        }
        [Fact]
        public void Item_AfterBuying_IsGoneFromTheShop() {
            Shop shop = new Shop();
            Item i = new Item("Yellow Shoes", 55);
            ItemBatch batch = new ItemBatch(i, 1);
            shop.Add(batch);

            Assert.Single(shop.Items);

            int funds = 100;
            shop.Buy("Yellow Shoes", ref funds);

            Assert.Empty(shop.Items);
        }
        [Fact]
        public void Revenue_AfterPurchase_Correct() {
            Shop shop = new Shop();
            Item item = new Item("Black Shirt", 15);
            Item item2 = new Item("Yellow Shoes", 55);

            ItemBatch shirtBatch = new ItemBatch(item, 100);
            ItemBatch shoeBatch = new ItemBatch(item2, 150);

            shop.Add(shirtBatch);
            shop.Add(shoeBatch);

            Assert.Equal(0, shop.Revenue);

            int funds = 1000;
            shop.Buy("Black Shirt", ref funds);

            Assert.Equal(item.Value, shop.Revenue);

            shop.Buy("Yellow Shoes", ref funds);

            Assert.Equal(item.Value + item2.Value, shop.Revenue);
        }
        [Fact]
        public void Return_ReturnsItemAndRevenue() {
            Shop shop = new Shop();
            Item i = new Item("Black Shirt", 15);
            ItemBatch batch = new ItemBatch(i, 1);

            shop.Add(batch);

            Assert.Single(shop.Items);

            int funds = 1000;
            Item boughtItem = shop.Buy("Black Shirt", ref funds);
            Assert.Empty(shop.Items);
            Assert.Equal(i.Value, shop.Revenue);

            shop.Return(boughtItem);

            Assert.Single(shop.Items);
            Assert.Equal(0, shop.Revenue);
        }
        [Fact]
        public void Return_WhenBoughtBefore_Works() {
            Shop shop = new Shop();
            Item i = new Item("Black Shirt", 15);
            ItemBatch batch = new ItemBatch(i, 1);

            shop.Add(batch);

            int funds = 1000;
            Item boughtItem = shop.Buy("Black Shirt", ref funds);
            shop.Return(boughtItem);
        }
        [Fact]
        public void Return_WhenNotBoughtBefore_Throws() {
            Shop shop = new Shop();
            Item i = new Item("Black Shirt", 15);
            ItemBatch b = new ItemBatch(i, 1);

            shop.Add(b);

            Assert.Throws<CannotReturnException>(() => {
                shop.Return(i);
            });
        }
    }
}