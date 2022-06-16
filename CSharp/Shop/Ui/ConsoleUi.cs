using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Ui {
    using Items;
    public class ConsoleUi : Ui{
        public ConsoleUi(ConsoleUiTextSource textSource) {

        }
        public void MainMenu() {
            Console.WriteLine("1 - Shop");
            Console.WriteLine("1 - Customer");
            string input = Console.ReadLine();
        }
        public void ShopMenu(List<ItemBatch> items) {
            
        }
    }
}
