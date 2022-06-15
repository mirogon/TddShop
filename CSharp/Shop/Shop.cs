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
            bool found = false;
            for(int i = 0; i < items.Count; ++i) {
                if (items[i].Item == batch.Item) {
                    items[i].Stock += batch.Stock;
                    found = true;
                }
            }
            if (!found) {
                items.Add(batch);
            }
        }
        public int StockAvailable(string itemName) {
            for(int i = 0; i < items.Count; ++i) {
                if (items[i].Item.Name == itemName) {
                    return items[i].Stock;
                }
            }
            return 0;
        }
        public Item Buy(string item, ref int funds) {
            for(int i = 0; i < items.Count; ++i) {
                if (items[i].Item.Name == item) {
                    Item currentItem = items[i].Item;
                    if(currentItem.Value > funds) {
                        throw new NotEnoughFundsException();
                    }
                    SoldItem(currentItem, ref funds);
                    return currentItem;
                }
            }
            throw new ItemNotAvailableException();
        }
        public void SoldItem(Item item, ref int funds) {
            funds -= item.Value;
            revenue += item.Value;

            RemoveItem(item);
            AddSoldItem(item);
        }
        private void RemoveItem(Item item) {
            for(int j = 0; j < items.Count; ++j) {
                if (items[j].Item == item) {
                    items[j].Stock--;
                }
                if (items[j].Stock <= 0) {
                    items.RemoveAt(j);
                }
            }
        }
        private void AddSoldItem(Item item) {
            bool found = false;
            for(int j = 0; j < soldItems.Count; ++j) {
                if (soldItems[j].Item == item) {
                    soldItems[j].Stock++;
                    found = true;
                }
            }
            if (!found) {
                soldItems.Add(new ItemBatch(item, 1));
            }
        }
        public void Return(Item item) {
            for(int i = 0; i < soldItems.Count; ++i) {
                if (soldItems[i].Item == item) {
                    revenue -= item.Value;
                    AddSingleItemToStock(item);
                    soldItems.RemoveAt(i);
                    return;
                }
            }
            throw new CannotReturnException();
        }
        private void AddSingleItemToStock(Item item) {
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
