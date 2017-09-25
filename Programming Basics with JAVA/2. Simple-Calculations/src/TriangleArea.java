import java.util.Locale;
import java.util.Scanner;

/**
 * Created by Aleksandur on 9.7.2017 г..
 */
public class TriangleArea {
    public static void main(String[] args){
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        System.out.printf("Triangle area %.2f ",triangleArea(input.nextDouble(), input.nextDouble()));
    }
    public static double triangleArea(double a, double h){
        return (a*h)/2;
    }
}
