package Ui;

public class StandardConsoleInput implements ConsoleInput{
    public String ReadLine(){
        return System.console().readLine();
    }
}
