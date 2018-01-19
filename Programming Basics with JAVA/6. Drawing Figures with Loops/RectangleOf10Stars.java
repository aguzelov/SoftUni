import java.util.Locale;
import java.util.Scanner;

public class RectangleOf10Stars {
    public static void main(String... args) {
        //Locale.setDefault(Locale.ROOT);
        //Scanner input = new Scanner(System.in);

        for(int i = 0; i < 10; i++){
            System.out.println(repeatStr("*", 10));
        }

    }
    public static String repeatStr(String str, int count){
        String text = "";
        for(int i = 0; i < count; i++){
            text = text + str;
        }
        return text;
    }
}