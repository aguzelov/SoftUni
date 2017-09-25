/**
 * Created by Aleksandur on 17.7.2017 г..
 */

import java.util.Locale;
import java.util.Scanner;

public class AreaOfFigures {

    public static String figure = null;

    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        figure = input.nextLine();
        if(figure.equalsIgnoreCase("square")){
            double squareH = input.nextDouble();
            System.out.printf("%.3f", squareH*squareH);
        }else if(figure.equalsIgnoreCase("rectangle")){
            double squareH = input.nextDouble();
            double squareW = input.nextDouble();
            System.out.printf("%.3f", squareH*squareW);
        }else if(figure.equalsIgnoreCase("circle")){
            double radius = input.nextDouble();
            System.out.printf("%.3f", Math.PI*(radius*radius));
        }else if(figure.equalsIgnoreCase("triangle")){
            double squareH = input.nextDouble();
            double squareW = input.nextDouble();
            System.out.printf("%.3f", (squareH*squareW)/2);
        }
    }
}
