using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Customers {
    using Items;
    public class Customer {
        private int funds = 0;
        private List<ItemOld> items = new List<ItemOld>();
        public Customer(int funds) {
            this.funds = funds;
        }
        public int Funds {
            get { return funds; }
        }
        public List<ItemOld> Items {
            get { return items; }
        }

        public void Buy(Shop shop, string item) {
            ItemOld purchasedItem = shop.BuyOld(item, ref funds);
            items.Add(purchasedItem);
        }
        public void Return(Shop shop, ItemOld item) {
            shop.ReturnOld(item);
            items.Remove(item);
            funds += item.Value;
        }
    }
}
