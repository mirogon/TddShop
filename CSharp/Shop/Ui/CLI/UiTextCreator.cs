using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Ui.CLI {
    using Items;
    using Customers;
    public interface UiTextCreator {
        public string ConstructMainMenu();
        public string ConstructShopMenu(List<ItemBatch> items);
        public string ConstructCustomerMenu(Customer c);
        public string ConstructCustomerBuyMenu(List<ItemBatch> shopItems);
        public string ConstructCustomerRefundMenu(List<Item> items);
    }
}
