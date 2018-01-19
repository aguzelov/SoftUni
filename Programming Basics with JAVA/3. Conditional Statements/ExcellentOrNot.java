import java.util.Scanner;

/**
 * Created by Aleksandur on 17.7.2017 г..
 */
public class ExcellentOrNot {
    public static void main(String ... args){
        Scanner input = new Scanner(System.in);
        double grade = input.nextDouble();
        if(grade >= 5.50){
            System.out.println("Excellent!");
        }else {
            System.out.println("Not excellent.");
        }
    }
}
