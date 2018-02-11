import java.util.Arrays;
import java.util.Locale;
import java.util.Scanner;

public class Intersection_of_Circles {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        int[] firstInput = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        Circle first = new Circle(firstInput[0], firstInput[1], firstInput[2]);

        int[] secondInput = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        Circle second = new Circle(secondInput[0], secondInput[1], secondInput[2]);

        if(Circle.Intersect(first,second)){
            System.out.println("Yes");
        }else{
            System.out.println("No");
        }
    }
}

class Circle{
    public static boolean Intersect(Circle c1, Circle c2){
        double d = Math.sqrt(((c1.center.getX() - c2.center.getX())*(c1.center.getX() - c2.center.getX()))+
                ((c1.center.getY() - c2.center.getY()) * (c1.center.getY() - c2.center.getY())));

        if(d <= c1.radius + c2.radius){
            return true;
        }else{
            return false;
        }
    }

    public Circle(double x, double y, double radius) {
        this.center = new Point(x, y);
        this.radius = radius;
    }

    public Circle(Point center, double radius) {
        this.center = center;
        this.radius = radius;
    }

    public Circle() {
    }

    public Point getCenter() {
        return center;
    }

    public void setCenter(Point center) {
        this.center = center;
    }

    public double getRadius() {
        return radius;
    }

    public void setRadius(double radius) {
        this.radius = radius;
    }

    private Point center;
    private double radius;

}

class Point{
    private double x;
    private double y;

    public Point() {
        this.x = 0;
        this.y = 0;
    }

    public Point(double x, double y) {
        this.x = x;
        this.y = y;
    }

    public double getX() {
        return x;
    }

    public void setX(double x) {
        this.x = x;
    }

    public double getY() {
        return y;
    }

    public void setY(double y) {
        this.y = y;
    }
}