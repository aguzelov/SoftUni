import java.util.Locale;
import java.util.Scanner;

public class RectangleOfNStars {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        for(int i = 0; i < n; i++){
            System.out.println(repeatStr("*", n));
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
