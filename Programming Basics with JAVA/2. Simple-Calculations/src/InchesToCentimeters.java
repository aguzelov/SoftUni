import java.util.Scanner;

/**
 * Created by Aleksandur on 9.7.2017 г..
 */
public class InchesToCentimeters {
    public static void main(String[] args){
        Scanner input = new Scanner(System.in);

        System.out.print("inches: ");
        double inches = Double.parseDouble(input.nextLine());
        System.out.println("centimeters = " + inches*2.54);
    }
}
