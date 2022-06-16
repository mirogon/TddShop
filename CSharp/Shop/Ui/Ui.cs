using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Ui {
    using Items;
    public interface Ui {
        public void MainMenu();
        public void ShopMenu(List<ItemBatch> items);
    }
}
