import java.util.Locale;
import java.util.Scanner;

public class SumDigits {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int num = input.nextInt();
        String numToText = ""+num;
        int sum = 0;
        for (int i = 0; i < numToText.length(); i++){
            sum += Character.getNumericValue(numToText.charAt(i));
        }
        System.out.println(sum);


    }
}
