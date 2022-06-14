using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Customers {
    using Items;
    public class Customer {
        private int funds = 0;
        private List<ItemOld> itemsOld = new List<ItemOld>();
        private List<Item> items = new List<Item>();
        public Customer(int funds) {
            this.funds = funds;
        }
        public int Funds {
            get { return funds; }
        }
        public List<ItemOld> ItemsOld {
            get { return itemsOld; }
        }
        public List<Item> Items {
            get { return items; }
        }

        public void BuyOld(Shop shop, string item) {
            ItemOld purchasedItem = shop.BuyOld(item, ref funds);
            itemsOld.Add(purchasedItem);
        }
        public void Buy(Shop shop, string item) {
            Item purchasedItem = shop.Buy(item, ref funds);
            items.Add(purchasedItem);
        }

        public void Return(Shop shop, Item item) {
            shop.Return(item);
            items.Remove(item);
            funds += item.Value;
        }
    }
}
