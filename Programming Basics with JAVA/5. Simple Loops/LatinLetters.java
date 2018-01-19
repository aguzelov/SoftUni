import java.util.Locale;
import java.util.Scanner;

public class LatinLetters {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        for(char i = 'a'; i <= 'z'; i++){
            System.out.println(i);
        }
    }
}
