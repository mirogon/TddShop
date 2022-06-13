using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop {
    using Items;

    public class Shop {
        private List<Item> items = new List<Item>();
        private List<Item> soldItems = new List<Item>();
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
                    Item currentItem = items[i];
                    if (currentItem.Value > funds) {
                        throw new NotEnoughFundsException();
                    }

                    funds -= currentItem.Value;
                    revenue += currentItem.Value;

                    soldItems.Add(currentItem);
                    items.RemoveAt(i);
                    return currentItem;
                }
            }
            throw new ItemNotAvailableException();
        }
        public void Return(Item item) {
            for (int i = 0; i < soldItems.Count; i++) {
                if (soldItems[i] == item) {
                    AddItem(item);
                    revenue -= item.Value;
                    return;
                }
            }
            throw new Exception();
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
