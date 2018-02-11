import java.util.Locale;
import java.util.Scanner;

/**
 * Created by Aleksandur on 9.7.2017 г..
 */
public class ConcatenateData {
    public static void main(String[] args){
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        String firstName = input.nextLine();
        String secondName = input.nextLine();
        int age = Integer.parseInt(input.nextLine());
        String town = input.nextLine();
        System.out.printf("You are %s %s, a %d-years old person from %s.",firstName, secondName, age, town);
    }
}
