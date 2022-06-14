using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Items {
    public class Item {
        private string name;
        private int value;
        public Item(string name, int value) {
            this.name = name;
            this.value = value;
        }
        public string Name {
            get { return name; }
        }
        public int Value {
            get { return value; }
        }
    }
}
