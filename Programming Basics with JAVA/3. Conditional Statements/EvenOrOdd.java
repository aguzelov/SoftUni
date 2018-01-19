import java.util.Locale;
import java.util.Scanner;

/**
 * Created by Aleksandur on 17.7.2017 г..
 */
public class EvenOrOdd {
    public static void main(String ... args){
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int number = input.nextInt();
        if(number % 2 == 0){
            System.out.println("even");
        }else {
            System.out.println("odd");
        }
    }
}
