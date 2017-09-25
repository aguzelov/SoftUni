import java.util.Locale;
import java.util.Scanner;

/**
 * Created by Aleksandur on 9.7.2017 г..
 */
public class CircleAreaAndPerimeter {
    public static void main(String[] args){
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        double r = input.nextDouble();
        System.out.println("Area = " + area(r));
        System.out.println("Perimeter = " + perimeter(r));
    }
    public static double area(double r){
        return Math.PI*r*r;
    }
    public static double perimeter(double r){
        return 2*Math.PI*r;
    }
}
