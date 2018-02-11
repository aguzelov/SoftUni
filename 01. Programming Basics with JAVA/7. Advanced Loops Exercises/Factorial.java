import java.util.Locale;
import java.util.Scanner;

public class Factorial {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        int range = n;
        for(int i = 1; i<range; i++){
            n*=i;
        }
        System.out.println(n);
    }
}
