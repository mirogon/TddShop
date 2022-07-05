package Ui;

import org.junit.Assert;
import org.junit.Test;
import static org.junit.Assert.assertEquals;
import org.junit.Assert;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;

class ConsoleUiTextCreatorTestHelper{
    public static String LoadFromFile(String fileName) throws FileNotFoundException, IOException {
        FileInputStream fileStream = new FileInputStream(fileName);
        byte[] buffer = new byte[2048];
        int read = fileStream.read(buffer);
        return buffer.toString();
    }
}
public class ConsoleUiTextCreatorTest {
    @Test
    public void ConstructMainMenu_Correct(){

    }
}
