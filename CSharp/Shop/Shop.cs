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
        public void Buy(string item, ref int funds) {
            for (int i = 0; i < items.Count; i++) {
                if (items[i].Name == item) {
                    if (items[i].Value > funds) {
                        throw new NotEnoughFundsException();
                    }
                    funds -= items[i].Value;
                    revenue += items[i].Value;
                    items.RemoveAt(i);
                    return;
                }
            }
            throw new ItemNotAvailableException();
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
