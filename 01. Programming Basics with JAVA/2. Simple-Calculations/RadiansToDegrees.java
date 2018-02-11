import java.util.Locale;
import java.util.Scanner;

/**
 * Created by Aleksandur on 9.7.2017 г..
 */
public class RadiansToDegrees {
    public static void main(String[] args){
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        System.out.printf("%.0f" ,Math.toDegrees(input.nextDouble()));
    }
}
