/**
 * Created by Aleksandur on 17.7.2017 г..
 */

import java.util.Locale;
import java.util.Scanner;

public class EqualNumbers {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);

        int currentValue = 0;
        int nextValue = 0;
        boolean equals = true;
        nextValue = input.nextInt();
        for (int i = 0; i < 2; i++) {
            currentValue = nextValue;
            nextValue = input.nextInt();
            if (nextValue != currentValue) {
                equals = false;
            }
        }
        System.out.println((equals == true ? "yes" : "no"));
    }
}
