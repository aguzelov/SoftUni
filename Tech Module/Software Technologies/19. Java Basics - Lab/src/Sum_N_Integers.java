import java.util.Locale;
import java.util.Scanner;

public class Sum_N_Integers {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        int n = scanner.nextInt();
        int sum = 0;
        for(int i = 0; i< n; i++){
            sum += scanner.nextInt();
        }
        System.out.println("Sum = " + sum);
    }
}



