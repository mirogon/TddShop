using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopTest.UI {
    using Shop.Ui;
    public class UiTest {
        [Fact]
        public void Test() {
            Ui ui = new ConsoleUi();
        }
        
    }
}
