import java.util.Locale;
import java.util.Scanner;

public class NumbersNto1 {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        for(int i = n; i>0; i--){
            System.out.println(i);
        }
    }
}
