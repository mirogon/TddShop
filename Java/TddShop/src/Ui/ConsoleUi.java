package Ui;

public class ConsoleUi implements Ui{
    UiTextCreator textCreator;
    ConsoleInput consoleInput;
    public ConsoleUi(UiTextCreator textCreator, ConsoleInput consoleInput){
        this.textCreator = textCreator;
        this.consoleInput = consoleInput;
    }
    public String MainMenu(){
        String menuText = textCreator.ConstructMainMenu();
        System.out.print(menuText);
        String input = consoleInput.ReadLine();
        return input;
    }
}
