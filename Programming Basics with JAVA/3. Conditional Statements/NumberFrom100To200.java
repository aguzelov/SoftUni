/**
 * Created by Aleksandur on 17.7.2017 г..
 */

import java.util.Locale;
import java.util.Scanner;

public class NumberFrom100To200 {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int number = input.nextInt();
        if(number < 100){
            System.out.println("Less than 100");
        }else if(number >= 100 && number <=200){
            System.out.println("Between 100 and 200");
        }else if(number>200){
            System.out.println("Greater than 200");
        }
    }
}
