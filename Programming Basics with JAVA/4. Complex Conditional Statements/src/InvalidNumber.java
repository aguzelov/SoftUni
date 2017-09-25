import java.util.Locale;
import java.util.Scanner;

public class InvalidNumber {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int number = input.nextInt();
        if((number < 100 || number > 200) && number != 0){
            System.out.println("invalid");
        }
    }
}
