import java.util.Locale;
import java.util.Scanner;

/**
 * Created by Aleksandur on 9.7.2017 г..
 */
public class GreetingByName {
    public static void main(String[] args){
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        //System.out.print("Enter your name: ");
        String name = input.nextLine();
        System.out.printf("Hello, %s!",name);
}
}
