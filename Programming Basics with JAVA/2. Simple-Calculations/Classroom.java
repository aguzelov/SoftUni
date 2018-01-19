import java.util.Locale;
import java.util.Scanner;

/**
 * Created by Aleksandur on 9.7.2017 г..
 */
public class Classroom {
    public static void main(String[] args){
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        double h = input.nextDouble() * 100;
        double w = input.nextDouble() * 100;
        w -= 100;

        int row = (int)(h/120);
        int b = (int)(w/70);

        int count = row * b - 3;
        System.out.println(count);
    }
}
