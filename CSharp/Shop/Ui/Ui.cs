using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Ui {
    using Items;
    using Customers;
    public interface Ui {
        public string MainMenu();
        public string ShopMenu(List<ItemBatch> items);
        public string CustomerMenu(Customer c);
        public void CustomerBuyMenu(List<ItemBatch> items);
    }
}
