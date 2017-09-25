import java.util.Locale;
import java.util.Scanner;

/**
 * Created by Aleksandur on 17.7.2017 г..
 */
public class SumSeconds {
    public static void main(String ... args){
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int first = input.nextInt();
        int second = input.nextInt();
        int third = input.nextInt();
        int sum = first + second + third;

        if(sum >= 60 && sum < 120){
            System.out.printf("%d:%02d", 1 ,sum-60);
        } else  if (sum >= 120 && sum < 180){
            System.out.printf("%d:%02d", 2 , sum-120);
        }else  if (sum < 60){
            System.out.printf("%d:%02d", 0 , sum);
        }
    }
}
