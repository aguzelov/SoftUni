import java.util.Locale;
import java.util.Scanner;

public class EvenPowersOf2 {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        int num = 1;
        for(int i = 0; i<(n/2)+1; i++){
            System.out.println(num);
            num*=4;
        }
    }
}
