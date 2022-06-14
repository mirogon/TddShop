using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Items {
    public class NullItem : ItemOld{
        public string Name {
            get { return ""; }
        }
        public int Value {
            get { return 0; }
        }
    }
}
