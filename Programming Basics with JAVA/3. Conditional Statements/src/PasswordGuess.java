/**
 * Created by Aleksandur on 17.7.2017 г..
 */

import java.util.Locale;
import java.util.Scanner;

public class PasswordGuess {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        String password = input.nextLine();
        if(password.equalsIgnoreCase("s3cr3t!P@ssw0rd")){
            System.out.println("Welcome");
        }else{
            System.out.println("Wrong password!");
        }


    }
}
