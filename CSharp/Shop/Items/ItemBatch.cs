using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Items {
    public class ItemBatch {
        private Item item;
        private int stock;
        public ItemBatch(Item item, int stock) {
            this.item = item;
            this.stock = stock;
        }
        public Item Item {
            get { return item; }
        }
        public int Stock {
            get { return stock; }
        }
    }
}
