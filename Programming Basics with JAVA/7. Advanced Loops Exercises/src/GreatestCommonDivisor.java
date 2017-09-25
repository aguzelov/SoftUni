import java.math.BigInteger;
import java.util.Locale;
import java.util.Scanner;

public class GreatestCommonDivisor {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int a = input.nextInt();
        int b = input.nextInt();
        System.out.println(gcd(a,b));
    }
    public static int gcd(int a, int b){
        BigInteger b1 = new BigInteger(""+a);
        BigInteger b2 = new BigInteger(""+b);
        return b1.gcd(b2).intValue();
    }
}
