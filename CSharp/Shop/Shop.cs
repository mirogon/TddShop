using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop {
    using Items;

    public class Shop {
        private List<Item> items = new List<Item>();
        private int revenue = 0;
        public List<Item> Items {
            get { return items; }
        }
        public int Revenue {
            get { return revenue; }
        }
        public void AddItem(Item i) {
            items.Add(i);
        }
        public Item Buy(string item, ref int funds) {
            for (int i = 0; i < items.Count; i++) {
                if (items[i].Name == item) {
                    if (items[i].Value > funds) {
                        throw new NotEnoughFundsException();
                    }
                    funds -= items[i].Value;
                    revenue += items[i].Value;
                    Item r = items[i];
                    items.RemoveAt(i);
                    return r;
                }
            }
            throw new ItemNotAvailableException();
        }
        public void Return(Item i) {
            AddItem(i);
            revenue -= i.Value;
        }
    }

    public class NotEnoughFundsException : Exception{
        public NotEnoughFundsException() : base("Not enough Funds!"){
        }
    }
    public class ItemNotAvailableException : Exception{
        public ItemNotAvailableException() : base("Item not available!"){
        }
    }
}
