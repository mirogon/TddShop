using Shop.App;
using Shop.Ui;
using Shop.Ui.CLI;
using Shop.Customers;
using Shop;
using Shop.Items;

//UI
UiTextCreator uiTextCreator = new ConsoleUiTextCreator();
ConsoleInput consoleInput = new StandardConsoleInput();
Ui ui = new ConsoleUi(uiTextCreator, consoleInput);

//Customer
Customer customer = new Customer(1000);

//Shop
Shop.Shop shop = new Shop.Shop();
Item redShoes = new Item("Red Shoes", 55);
ItemBatch batch = new ItemBatch(redShoes, 10);

App app = new App(ui, customer, shop);
app.Start();
