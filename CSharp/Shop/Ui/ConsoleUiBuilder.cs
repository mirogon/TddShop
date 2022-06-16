using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Ui {
    using Items;
    public class ConsoleUiBuilder {
        public string ConstructShopMenu(List<ItemBatch> items) {
            if(items.Count == 0) {
                return "Items";
            }
            string s = "Items\n\n" + "Name                Price               Stock\n";

            for(int i = 0; i < items.Count; ++i) {
                s += items[i].Item.Name;// + " " + items[i].Item.Value + " " + items[i].Stock;
                int spaces = 20 - items[i].Item.Name.Length;
                for(int j = 0; j < spaces; ++j) {
                    s += " ";
                }
                s += items[i].Item.Value;
                spaces = 20 - items[i].Item.Value.ToString().Length;
                for(int j = 0; j < spaces; ++j) {
                    s += " ";
                }
                s += items[i].Stock;
            }
            return s;
        }
    }
}
