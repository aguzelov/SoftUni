/**
 * Created by Aleksandur on 17.7.2017 г..
 */

import java.util.Locale;
import java.util.Scanner;

public class Me {
    public static final int PLAY_TIME_WORK = 63;
    public static final int PLAY_TIME_HOLIDAY = 127;
    public static final int TOM_NORM = 30000;
    public static final int DAY_IN_YEAR = 365;
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int holidays = input.nextInt();

        int playTime = holidays * PLAY_TIME_HOLIDAY + ((DAY_IN_YEAR - holidays)*PLAY_TIME_WORK);

        if(playTime <= TOM_NORM){
            System.out.println("Tom sleeps well");
            int timeRemain = TOM_NORM - playTime;
            System.out.printf("%d hours and %d minutes less for play", (timeRemain - (timeRemain%60))/60 ,timeRemain%60 );
        }else{
            System.out.println("Tom will run away");
            int overTime = playTime -TOM_NORM;
            System.out.printf("%d hours and %d minutes more for play", (overTime - (overTime%60))/60 , overTime%60);
        }
    }
}
