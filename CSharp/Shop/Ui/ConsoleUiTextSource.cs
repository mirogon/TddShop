using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Ui {
    using Items;
    public class ConsoleUiTextSource {
        public string ConstructShopMenu(List<ItemBatch> items) {
            if(items.Count == 0) {
                return "Shop Menu:";
            }
            string s = "Shop Menu:\n" + "Name, Price, Stock\n";

            for(int i = 0; i < items.Count; ++i) {
                s += items[i].Item.Name + " " + items[i].Item.Value + " " + items[i].Stock;
            }
            return s;
        }
    }
}
