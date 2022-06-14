using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop {
    using Items;

    public class Shop {
        private int revenue = 0;
        
        //New
        private List<Item> items = new List<Item>();
        private List<Item> soldItems = new List<Item>();

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
        private void SoldItem(Item i, ref int funds) {
            funds -= i.Value;
            revenue += i.Value;
            soldItems.Add(i);
            items.Remove(i);
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
