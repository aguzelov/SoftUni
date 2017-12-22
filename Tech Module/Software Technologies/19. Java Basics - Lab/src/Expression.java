import java.util.Locale;
import java.util.Scanner;

public class Expression {

    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        double val = (30 + 21) * 0.5 * (35 - 12 - 0.5);
        double sqrVal = Math.pow(val, 2);

        System.out.println(sqrVal);
    }
}
