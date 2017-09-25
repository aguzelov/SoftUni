/**
 * Created by Aleksandur on 17.7.2017 г..
 */

import java.util.Locale;
import java.util.Scanner;

public class EqualWords {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        System.out.println( ((input.nextLine().equalsIgnoreCase(input.nextLine())) == true ? "yes" : "no")   );
    }
}
