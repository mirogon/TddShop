using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Ui {
    using Items;
    using Customers;
    public interface TextUiBuilder {
        public string ConstructMainMenu();
        public string ConstructShopMenu(List<ItemBatch> items);
        public string ConstructCustomerMenu(Customer c);
    }
}
