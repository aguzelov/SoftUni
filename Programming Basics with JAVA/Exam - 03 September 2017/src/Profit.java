import java.util.Locale;
import java.util.Scanner;

public class Profit {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);

        int moneti1 = input.nextInt();
        int moneti2 = input.nextInt();
        int bank5 = input.nextInt();
        int sum = input.nextInt();

        for (int i = 0; i <= moneti1; i++) {
            for (int m = 0; m <= moneti2; m++) {
                for (int g = 0; g <= bank5; g++) {
                    if (((i * 1) + (m * 2) + (g * 5)) == sum) {
                        System.out.printf("%d * 1 lv. + %d * 2 lv. + %d * 5 lv. = %d lv.%n", i, m, g, sum);
                    }
                }
            }
        }
    }

}
