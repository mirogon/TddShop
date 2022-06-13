using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Customers {
    using Items;
    public class Customer {
        private int funds = 0;
        private List<Item> items = new List<Item>();
        public Customer(int funds) {
            this.funds = funds;
        }
        public int Funds {
            get { return funds; }
        }
        public List<Item> Items {
            get { return items; }
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
