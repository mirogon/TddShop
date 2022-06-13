using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Customers {
    public class Customer {
        int funds = 0;
        public Customer(int funds) {
            this.funds = funds;
        }
        public int Funds {
            get { return funds; }
        }
        public void Buy(Shop shop, string item) {
            shop.Buy(item, ref funds);
        }
    }
}
