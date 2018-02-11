import java.util.Locale;
import java.util.Scanner;

public class NumbersToN {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        for(int i = 1; i<= n; i+=3){
            System.out.println(i);
        }
    }
}
