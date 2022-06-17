using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Ui {
    using Items;
    using Customers;
    public class ConsoleUiBuilder {
        public string ConstructMainMenu() {
            return "1 - Shop Menu\n2 - Customer Menu\n3 - Exit";
        }
        public string ConstructShopMenu(List<ItemBatch> items) {
            string s = "Items\n\n" + "Name                Price               Stock";

            if (items.Count > 0) {
                s += "\n";
            }

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
        public string ConstructCustomerMenu(Customer customer) {
            string s = "Items";
            s += "\n\n";
            for (int i = 0; i < customer.Items.Count; ++i) {
                s += customer.Items[i].Name;
            }
            s += "\n\n";
            s += "1 - Buy Item\n";
            s += "2 - Refund Item";
            return s;
        }
        public string ConstructCustomerBuyMenu(List<ItemBatch> shopItems) {
            string s = "Shop Items\n\n";
            s += "Name                Price               Stock\n";
            for(int i = 0; i < shopItems.Count; ++i) {
                s += shopItems[i].Item.Name;
                int spaces = 20 - shopItems[i].Item.Name.Length;
                for(int j = 0; j < spaces; ++j) {
                    s += " ";
                }
                s += shopItems[i].Item.Value;
                spaces = 20 - shopItems[i].Item.Value.ToString().Length;
                for(int j = 0; j < spaces; ++j) {
                    s += " ";
                }
                s += shopItems[i].Stock;
                s += "\n";
            }
            s += "\nBuy Item: ";
            return s;
        }
        public string ConstructCustomerRefundMenu(List<Item> customerItems) {
            string s = "Items\n\n";
            s += "Name                Value\n";
            for(int i = 0; i < customerItems.Count; ++i) {
                s += customerItems[i].Name;
                int spaces = 20 - customerItems[i].Name.Length;
                for(int j = 0; j < spaces; ++j) {
                    s += " ";
                }
                s += customerItems[i].Value;
                s += "\n";
            }
            s += "\nRefund Item: ";
            return s;

        }
    }
}
