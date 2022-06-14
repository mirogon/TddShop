using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop {
    using Items;

    public class Shop {
        private int revenue = 0;

        private List<ItemBatch> items = new List<ItemBatch>();
        private List<ItemBatch> soldItems = new List<ItemBatch>();

        public List<ItemBatch> Items {
            get { return items; }
        }
        public int Revenue {
            get { return revenue; }
        }
        public void Add(ItemBatch batch) {
            items.Add(batch);
        }
        public Item Buy(string item, ref int funds) {
            for(int i = 0; i < items.Count; ++i) {
                if (items[i].Item.Name == item) {
                    Item currentItem = items[i].Item;
                    if(currentItem.Value > funds) {
                        throw new NotEnoughFundsException();
                    }
                    funds -= currentItem.Value;
                    revenue += currentItem.Value;

                    //Remove Stock from items
                    for(int j = 0; j < items.Count; ++j) {
                        if (items[j].Item.Name == item) {
                            items[j].Stock--;
                        }
                        if (items[j].Stock <= 0) {
                            items.RemoveAt(j);
                        }
                    }
                    //Add to sold
                    bool found = false;
                    for(int j = 0; j < soldItems.Count; ++j) {
                        if (soldItems[j].Item.Name == item) {
                            soldItems[j].Stock++;
                            found = true;
                        }
                    }
                    if (!found) {
                        soldItems.Add(new ItemBatch(currentItem, 1));
                    }
                    return currentItem;
                }
            }
            throw new ItemNotAvailableException();
        }
        public void Return(Item item) {
            for(int i = 0; i < soldItems.Count; ++i) {
                if (soldItems[i].Item == item) {
                    revenue -= item.Value;
                    //Add item back to stock
                    bool found = false;
                    for(int j = 0; j < items.Count; ++j) {
                        if (items[j].Item == item) {
                            items[j].Stock++;
                            found = true;
                        }
                    }
                    if (!found) {
                        items.Add(new ItemBatch(item, 1));
                    }
                    //Remove from soldItems
                    soldItems.RemoveAt(i);
                    return;
                }
            }
            throw new CannotReturnException();
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
    public class CannotReturnException : Exception{
        public CannotReturnException() : base("Item was never bought!"){
        }
    }

}
