package App;

import Customer.*;
import Shop.*;
import Item.*;
import Ui.*;

public class Main {
    public static void main(String[] args) throws NotEnoughFundsException, CannotReturnException, ItemNotAvailableException {
        UiTextCreator textCreator = new ConsoleUiTextCreator();
        ConsoleInput input = new StandardConsoleInput();
        Ui ui = new ConsoleUi(textCreator, input);

        Customer c = new Customer(new Wallet(1000));
        Shop shop = new Shop();

        Item i = new Item("Red Shoes", 55);
        ItemBatch b = new ItemBatch(i, 1);
        shop.Add(b);

        App app = new App(ui, c,shop);

        while(app.Running()){
            app.Update();
        }
    }
}
