using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App {
    using Customers;
    using Ui;
    public class App {

        private Ui ui;
        public App(Ui ui, Customer customer, Shop shop) {
            this.ui = ui;
        }
        public void Start() {
            ui.MainMenu();
        }
    }
}
