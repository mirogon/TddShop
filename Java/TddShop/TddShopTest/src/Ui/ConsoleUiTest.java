package Ui;


import org.junit.Assert;
import org.junit.Test;
import static org.junit.Assert.assertEquals;
import org.junit.Assert;
import static org.mockito.Mockito.*;

public class ConsoleUiTest {
    @Test
    public void MainMenu_CallsConstructMainMenu(){
        UiTextCreator textCreatorMock = mock(UiTextCreator.class);
        ConsoleInput consoleInputMock = mock(ConsoleInput.class);
        Ui ui = new ConsoleUi(textCreatorMock, consoleInputMock);

        when(textCreatorMock.ConstructMainMenu()).thenReturn("");
        when(consoleInputMock.ReadLine()).thenReturn("1");

        String actual = ui.MainMenu();

        verify(textCreatorMock.ConstructMainMenu());
        verify(consoleInputMock.ReadLine());
        assertEquals("1", actual);
    }
}
