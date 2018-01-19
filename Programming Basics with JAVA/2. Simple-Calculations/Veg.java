import java.util.Locale;
import java.util.Scanner;

/**
 * Created by Aleksandur on 9.7.2017 г..
 */
public class Veg {
    public static void main(String[] args){
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        double priceOfVegetables = Double.parseDouble(input.nextLine());
        double priceOfFruits = Double.parseDouble(input.nextLine());
        int numberOfVegetables = Integer.parseInt(input.nextLine());
        int numberofFruits = Integer.parseInt(input.nextLine());


        System.out.printf("%.2f",((numberOfVegetables*priceOfVegetables)+(numberofFruits*priceOfFruits))/1.94);

    }
}
