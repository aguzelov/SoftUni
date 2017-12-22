import java.util.Locale;
import java.util.Scanner;

public class Integer_to_Hex_and_Binary {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        Integer num = Integer.parseInt(scanner.nextLine());

        System.out.println(Integer.toHexString(num).toUpperCase());
        System.out.println(Integer.toBinaryString(num));
    }
}