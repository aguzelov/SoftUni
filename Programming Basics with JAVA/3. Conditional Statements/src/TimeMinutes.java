/**
 * Created by Aleksandur on 17.7.2017 г..
 */

import java.util.Locale;
import java.util.Scanner;

public class TimeMinutes {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int hour = input.nextInt();
        int minutes = input.nextInt();

        if(minutes + 15 >= 60){
            ++hour;
            if(hour >=24){
                hour = 0;
            }
            minutes = (minutes+15)-60;
        }else{
            minutes += 15;
        }
        System.out.printf("%d:%02d",hour, minutes);
    }
}
