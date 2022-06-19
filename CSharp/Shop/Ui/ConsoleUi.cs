using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Ui {
    using Items;
    public class ConsoleUi : Ui{
        TextUiBuilder textUiBuilder;
        ConsoleInput consoleInput;
        public ConsoleUi(TextUiBuilder textUiBuilder, ConsoleInput consoleInput) {
            this.textUiBuilder = textUiBuilder;
            this.consoleInput = consoleInput;
        }
        public void MainMenu() {
            string m = textUiBuilder.ConstructMainMenu();
            string input = consoleInput.ReadLine();
        }
        public void ShopMenu(List<ItemBatch> items) {
        }
    }
}
