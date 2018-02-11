import com.sun.org.apache.regexp.internal.RE;

import java.util.Locale;
import java.util.Scanner;

/**
 * Created by Aleksandur on 9.7.2017 г..
 */
public class RectangleArea {
    public static void main(String[] args){
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        Angle first = new Angle(input.nextDouble(), input.nextDouble());
        Angle second = new Angle(input.nextDouble(), input.nextDouble());
        System.out.println(first.area(second));
        System.out.println(first.perimeter(second));
    }
}
class Angle{
    private double x;
    private double y;

    public double getY() {
        return y;
    }

    public double getX() {
        return x;
    }

    public void setX(double x) {
        this.x = x;
    }

    public void setY(double y) {
        this.y = y;
    }

    public Angle(double x, double y) {
        this.x = x;
        this.y = y;
    }

    public double area(Angle other){

       return  Math.abs(this.x - other.getX()) *Math.abs(this.y - other.getY());
    }
    public double perimeter(Angle other){
        return  2*(Math.abs(this.x - other.getX()) +Math.abs(this.y - other.getY()));
    }
}