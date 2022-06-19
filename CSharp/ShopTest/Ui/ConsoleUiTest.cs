using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace ShopTest.Ui {
    using Shop.Ui;
    using Shop.Items;
    public class ConsoleUiTest {
        [Fact]
        public void MainMenu_CallsConstructMainMenu() {
            var consoleUiBuilderMock = new Mock<TextUiBuilder>();
            var consoleInput = new Mock<ConsoleInput>();

            Ui ui = new ConsoleUi(consoleUiBuilderMock.Object, consoleInput.Object);
            consoleUiBuilderMock.Setup(b => b.ConstructMainMenu());
            consoleInput.Setup(i => i.ReadLine());

            ui.MainMenu();

            consoleUiBuilderMock.Verify(b => b.ConstructMainMenu(), Times.Once());
            consoleInput.Verify(i => i.ReadLine(), Times.Once());
        }
        [Fact]
        public void ShopMenu_CallsConstructShopMenu() {
        }
    }
}
