/**
 * Created by Aleksandur on 17.7.2017 г..
 */

import java.text.DecimalFormat;
import java.util.Locale;
import java.util.Scanner;

public class Harvest {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int area = input.nextInt();
        double yield = input.nextDouble();
        int ltNeed = input.nextInt();
        int workers = input.nextInt();

        int totalGrapes = (int)(area * yield);


        double wine = (totalGrapes*0.4)/2.5;
        if(wine >= ltNeed){
            DecimalFormat df = new DecimalFormat("0");
            System.out.printf("Good harvest this year! Total wine: %s liters.", df.format(Math.floor(wine)));
            System.out.println();
            System.out.printf("%.0f liters left -> %.0f liters per person.", Math.ceil(wine-ltNeed),Math.ceil((wine-ltNeed)/workers));
        }else {
            System.out.printf("It will be a tough winter! More %.0f liters wine needed.", Math.floor(ltNeed-wine));
        }
     }
}
