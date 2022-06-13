using Xunit;

namespace ShopTest {
    using Shop;
    using Shop.Items;
    public class ShopTest {
        [Fact]
        public void AddItem_AddsNewItem() {
            Shop shop = new Shop();

            Assert.Empty(shop.Items);

            Item item = new NullItem();
            shop.AddItem(item);

            Assert.Single(shop.Items);
        }
        [Fact]
        public void Revenue_AtBegin_Zero() {
            Shop shop = new Shop();
            Assert.Equal(0, shop.Revenue);
        }
        [Fact]
        public void Buy_ReducesFunds() {
            Shop shop = new Shop();
            Item item = new BlackShirt();
            shop.AddItem(item);

            int funds = 100;
            shop.Buy("Black Shirt", ref funds);

            Assert.Equal(100 - item.Value, funds);
        }
        [Fact]
        public void Buy_NotEnoughFunds_Throws() {
            Shop shop = new Shop();
            Item item = new BlackShirt();
            shop.AddItem(item);

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
            Item i = new YellowShoes();
            shop.AddItem(i);

            Assert.Single(shop.Items);

            int funds = 100;
            shop.Buy("Yellow Shoes", ref funds);

            Assert.Empty(shop.Items);
        }
        [Fact]
        public void Revenue_AfterPurchase_Correct() {
            Shop shop = new Shop();
            Item item = new BlackShirt();
            Item item2 = new YellowShoes();

            shop.AddItem(item);
            shop.AddItem(item2);

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
            Item i = new BlackShirt();

            shop.AddItem(i);

            Assert.Single(shop.Items);

            int funds = 1000;
            Item boughtItem = shop.Buy("Black Shirt", ref funds);
            Assert.Empty(shop.Items);
            Assert.Equal(i.Value, shop.Revenue);

            shop.Return(boughtItem);

            Assert.Single(shop.Items);
            Assert.Equal(0, shop.Revenue);
        }
    }
}