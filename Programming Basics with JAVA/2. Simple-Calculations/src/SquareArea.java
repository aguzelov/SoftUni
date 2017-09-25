import java.util.Scanner;

/**
 * Created by Aleksandur on 8.7.2017 г..
 */
public class SquareArea {
    public static void main(String[] args){
        Scanner input = new Scanner(System.in);

        System.out.print("a= ");
        int area = Integer.parseInt(input.nextLine());
        System.out.println("Square = " + (area*area));
    }
}
