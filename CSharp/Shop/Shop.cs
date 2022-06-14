using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop {
    using Items;

    public class Shop {
        private List<ItemOld> itemsOld = new List<ItemOld>();
        private List<ItemOld> soldItemsOld = new List<ItemOld>();
        private int revenue = 0;
        
        //New
        private List<Item> items = new List<Item>();
        private List<Item> soldItems = new List<Item>();

        public List<ItemOld> ItemsOld {
            get { return itemsOld; }
        }
        public List<Item> Items {
            get { return items; }
        }
        public int Revenue {
            get { return revenue; }
        }
        public void AddItem(ItemOld i) {
            itemsOld.Add(i);
        }
        public void AddItem(Item i) {
            items.Add(i);
        }
        public ItemOld BuyOld(string item, ref int funds) {
            for (int i = 0; i < itemsOld.Count; i++) {
                if (itemsOld[i].Name == item) {
                    ItemOld currentItem = itemsOld[i];
                    if (currentItem.Value > funds) {
                        throw new NotEnoughFundsException();
                    }
                    SoldItemOld(currentItem, ref funds);
                    return currentItem;
                }
            }
            throw new ItemNotAvailableException();
        }
        public Item Buy(string item, ref int funds) {
            for(int i = 0; i < items.Count; ++i) {
                if (items[i].Name == item) {
                    Item currentItem = items[i];
                    if(currentItem.Value > funds) {
                        throw new NotEnoughFundsException();
                    }
                    SoldItem(currentItem, ref funds);
                    return currentItem;
                }
            }
            throw new ItemNotAvailableException();
        }
        private void SoldItemOld(ItemOld i, ref int funds) {
            funds -= i.Value;
            revenue += i.Value;
            soldItemsOld.Add(i);
            itemsOld.Remove(i);
        }
        private void SoldItem(Item i, ref int funds) {
            funds -= i.Value;
            revenue += i.Value;
            soldItems.Add(i);
            items.Remove(i);
        }
        public void ReturnOld(ItemOld item) {
            for (int i = 0; i < soldItemsOld.Count; i++) {
                if (soldItemsOld[i] == item) {
                    AddItem(item);
                    revenue -= item.Value;
                    return;
                }
            }
            throw new CannotReturnException();
        }
        public void Return(Item item) {
            for (int i = 0; i < soldItems.Count; i++) {
                if (soldItems[i] == item) {
                    AddItem(item);
                    revenue -= item.Value;
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
