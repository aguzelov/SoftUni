import java.util.HashMap;
import java.util.Locale;
import java.util.Scanner;

public class SmallShop {
    public static HashMap<String,HashMap<String,Double>> shopPrice;
    static {
        shopPrice = new HashMap<String,HashMap<String,Double>>();
        shopPrice.put("Sofia", new HashMap<String, Double>());
        shopPrice.get("Sofia").put("coffee", 0.50);
        shopPrice.get("Sofia").put("water", 0.80);
        shopPrice.get("Sofia").put("beer", 1.20);
        shopPrice.get("Sofia").put("sweets", 1.45);
        shopPrice.get("Sofia").put("peanuts", 1.60);

        shopPrice.put("Plovdiv", new HashMap<String, Double>());
        shopPrice.get("Plovdiv").put("coffee", 0.40);
        shopPrice.get("Plovdiv").put("water", 0.70);
        shopPrice.get("Plovdiv").put("beer", 1.15);
        shopPrice.get("Plovdiv").put("sweets", 1.30);
        shopPrice.get("Plovdiv").put("peanuts", 1.50);

        shopPrice.put("Varna", new HashMap<String, Double>());
        shopPrice.get("Varna").put("coffee", 0.45);
        shopPrice.get("Varna").put("water", 0.70);
        shopPrice.get("Varna").put("beer", 1.10);
        shopPrice.get("Varna").put("sweets", 1.35);
        shopPrice.get("Varna").put("peanuts", 1.55);

    }

    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        String product = input.nextLine();
        String town = input.nextLine();
        Double count = input.nextDouble();

        System.out.println((double)(shopPrice.get(town).get(product))* count);

    }
}
