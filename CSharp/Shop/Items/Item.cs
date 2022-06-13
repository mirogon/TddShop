using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Items {
    public interface Item {
        public string Name { get; }
        public int Value { get; }
    }
}
