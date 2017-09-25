/**
 * Created by Aleksandur on 17.7.2017 г..
 */

import java.util.Locale;
import java.util.Scanner;

public class SpeedInfo {
    public static final String[] OUTPUT_TEXT = new String[]{"slow", "average", "fast" , "ultra fast", "extremely fast"};
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        double speed = input.nextDouble();
        if(speed <= 10){
            System.out.println(OUTPUT_TEXT[0]);
        }else if(speed > 10 && speed <= 50){
            System.out.printf(OUTPUT_TEXT[1]);
        }else if(speed > 50 && speed <= 150){
            System.out.println(OUTPUT_TEXT[2]);
        }else if (speed > 150 && speed <= 1000){
            System.out.println(OUTPUT_TEXT[3]);
        }else{
            System.out.printf(OUTPUT_TEXT[4]);
        }
    }
}
