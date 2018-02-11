import java.util.Locale;
import java.util.Scanner;

public class SumNumbers {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        int sum = 0;
        for(int i = 0; i < n ; i++){
            sum += input.nextInt();
        }
        System.out.println(sum);
    }
}
