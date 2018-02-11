/**
 * Created by Aleksandur on 17.7.2017 г..
 */

import java.util.Locale;
import java.util.Scanner;

public class TransportPrice {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int km = input.nextInt();
        input.nextLine();
        String time = input.nextLine();

        double price = 0;
        if(km < 20){
            price+=0.70;
            if(time.equalsIgnoreCase("day")){
                price += km*0.79;
            }else{
                price += km*0.90;
            }
        }else if(km >= 20 && km < 100){
            price += km *0.09;
        }else {
            price += km*0.06;
        }
        System.out.printf("%.2f", price);
    }

}
