import java.util.Locale;
import java.util.Scanner;

public class Tailoring {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);

        double table = input.nextDouble();
        double lTable = input.nextDouble();
        double wTable = input.nextDouble();

        double totalAreaP = table * (lTable + 2 * 0.30) * (wTable + 2 * 0.30);
        double totalAreaK = table * (lTable / 2) * (lTable / 2);

        double priceUSD = totalAreaP * 7 + totalAreaK * 9;
        System.out.printf("%.2f USD%n", priceUSD);
        double priceBGN = priceUSD * 1.85;
        System.out.printf("%.2f BGN", priceBGN);
    }
}
