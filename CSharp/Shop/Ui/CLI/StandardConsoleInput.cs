using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Ui.CLI {
    public class StandardConsoleInput : ConsoleInput{
        public string ReadLine() {
            return Console.ReadLine();
        }
    }
}
