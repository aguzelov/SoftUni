import java.util.Locale;
import java.util.Scanner;

public class PointOnRectangleBorder {
    public static double x1, y1, x2, y2;
    public static double x, y;
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        x1 = input.nextDouble();
        y1 = input.nextDouble();
        x2 = input.nextDouble();
        y2 = input.nextDouble();
        x = input.nextDouble();
        y = input.nextDouble();

        if(((y == y1 && (x >= x1 && x <= x2)) || (x == x1 && (y >= y1 && y <= y2))) || ((y == y2 && (x >= x1 && x <= x2)) || (x == x2 && (y >= y1 && y <= y2))) ){
            System.out.println("Border");
        }else {
            System.out.println("Inside / Outside");
        }

    }
}
