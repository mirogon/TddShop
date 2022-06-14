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
        public ItemOld Buy(string item, ref int funds) {
            for (int i = 0; i < itemsOld.Count; i++) {
                if (itemsOld[i].Name == item) {
                    ItemOld currentItem = itemsOld[i];
                    if (currentItem.Value > funds) {
                        throw new NotEnoughFundsException();
                    }
                    SoldItem(currentItem, ref funds);
                    return currentItem;
                }
            }
            throw new ItemNotAvailableException();
        }
        private void SoldItem(ItemOld i, ref int funds) {
            funds -= i.Value;
            revenue += i.Value;
            soldItemsOld.Add(i);
            itemsOld.Remove(i);
        }
        public void Return(ItemOld item) {
            for (int i = 0; i < soldItemsOld.Count; i++) {
                if (soldItemsOld[i] == item) {
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
