using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Ui.CLI {
    using Items;
    using Customers;

    public class ConsoleUiTextCreator : UiTextCreator {
        public string ConstructMainMenu() {
            return "USER COMMANDS\n\nSHOP     - Shop Menu\nCUSTOMER - Customer Menu\nEXIT     - Exit Application\n\nINPUT: ";
        }
        public string ConstructShopMenu(List<ItemBatch> items) {
            string s = "SHOP ITEMS\n\n" + "Name                Price               Stock";

            if (items.Count > 0) {
                s += "\n";
            }

            for (int i = 0; i < items.Count; ++i) {
                s += items[i].Item.Name;
                int spaces = 20 - items[i].Item.Name.Length;
                for (int j = 0; j < spaces; ++j) {
                    s += " ";
                }
                s += items[i].Item.Value;
                spaces = 20 - items[i].Item.Value.ToString().Length;
                for (int j = 0; j < spaces; ++j) {
                    s += " ";
                }
                s += items[i].Stock;
            }

            s += "\n\nUSER COMMANDS\n\nBACK - Go back to the Main Menu\n\nINPUT: ";

            return s;
        }
        public string ConstructCustomerMenu(Customer customer) {
            string s = "YOUR ITEMS";
            s += "\n\n";
            for (int i = 0; i < customer.Items.Count; ++i) {
                s += customer.Items[i].Name;
            }
            s += "\n\n";
            s += "USER COMMANDS\n\nBUY    - Buy Item\nREFUND - Refund Item\nBACK   - Go back to the Main Menu\n\nINPUT: ";
            return s;
        }
        public string ConstructCustomerBuyMenu(List<ItemBatch> shopItems) {
            string s = "SHOP ITEMS\n\n";
            s += "Name                Price               Stock\n";
            for (int i = 0; i < shopItems.Count; ++i) {
                s += shopItems[i].Item.Name;
                int spaces = 20 - shopItems[i].Item.Name.Length;
                for (int j = 0; j < spaces; ++j) {
                    s += " ";
                }
                s += shopItems[i].Item.Value;
                spaces = 20 - shopItems[i].Item.Value.ToString().Length;
                for (int j = 0; j < spaces; ++j) {
                    s += " ";
                }
                s += shopItems[i].Stock;
                s += "\n";
            }
            s += "\nUSER COMMANDS\n\n";
            s+= "[ITEM]  - Buy item with the name [ITEM]\n";
            s += "BACK    - Go back to the Customer Menu\n\n";
            s += "INPUT: ";

            return s;
        }
        public string ConstructCustomerRefundMenu(List<Item> customerItems) {
            string s = "YOUR ITEMS\n\n";
            s += "Name                Value\n";
            for (int i = 0; i < customerItems.Count; ++i) {
                s += customerItems[i].Name;
                int spaces = 20 - customerItems[i].Name.Length;
                for (int j = 0; j < spaces; ++j) {
                    s += " ";
                }
                s += customerItems[i].Value;
                s += "\n";
            }
            s += "\nUSER COMMANDS\n\n[ITEM] - Refund item with [ITEM] name\nBACK   - Go back to the Customer Menu\n\nINPUT: ";
            return s;

        }
    }
}
