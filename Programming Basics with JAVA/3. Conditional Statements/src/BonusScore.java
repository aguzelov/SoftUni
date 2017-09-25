import java.util.Locale;
import java.util.Scanner;

/**
 * Created by Aleksandur on 17.7.2017 г..
 */
public class BonusScore {
    public static void main(String ... args){
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int number = input.nextInt();
        double bonus = lestThan100(number) + lestThan1000(number) + greatherThan1000(number) + evenOrOdd(number) + lastDigitFive(number);
        System.out.printf( "%.1f",bonus);
        System.out.println();
        System.out.println(number+bonus);
    }

    public static double lestThan100(final int number){
        if(number <= 100){
            return 5;
        }else {
            return 0;
        }
    }
    public static double lestThan1000(final int number){
        if(number > 100 && number <= 1000){
            return number*0.20;
        }else {
            return 0;
        }
    }
    public static double greatherThan1000(final int number){
        if( number > 1000){
            return number*0.10;
        }else {
            return 0;
        }
    }
    public static double evenOrOdd(final int number){
        if(number % 2 == 0 ){
            return 1;
        }else {
            return 0;
        }
    }
    public static double lastDigitFive(final int number){
       String strNum = Integer.toString(number);
       char charAtLastPosition = strNum.charAt(strNum.length() - 1);
        if(charAtLastPosition == '5'){
            return 2;
        }else {
            return 0;
        }
    }
}

