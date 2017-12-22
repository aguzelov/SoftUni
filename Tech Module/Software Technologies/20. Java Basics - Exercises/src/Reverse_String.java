import java.util.Locale;
import java.util.Scanner;

public class Reverse_String {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();

        for (int i = text.length()-1; i >= 0 ; i--) {
            System.out.print(text.charAt(i));
        }
    }
}