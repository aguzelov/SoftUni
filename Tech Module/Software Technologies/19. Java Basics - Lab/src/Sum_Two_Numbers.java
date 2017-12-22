import java.util.Locale;
import java.util.Scanner;

public class Sum_Two_Numbers {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        double firstNum = input.nextDouble();
        double secondNum = input.nextDouble();

        double sum = firstNum + secondNum;

        System.out.println(sum);

    }
}
