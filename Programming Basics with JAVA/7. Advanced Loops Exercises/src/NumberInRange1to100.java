import java.util.Locale;
import java.util.Scanner;

public class NumberInRange1to100 {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        System.out.print("Enter a number in the range [1...100]: ");
        int n = input.nextInt();
        while (n < 1 || n > 100){
            System.out.println("Invalid number!");
            System.out.print("Enter a number in the range [1...100]: ");
            n = input.nextInt();
        }
        System.out.println("The number is: " + n);
    }
}
