import java.util.Locale;
import java.util.Scanner;

/**
 * Created by Aleksandur on 17.7.2017 г..
 */
public class GreaterNumber {
    public static void  main(String ... args){
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int first = input.nextInt();
        int second = input.nextInt();
        System.out.println((first > second ? first : second));
    }
}

