import java.util.InputMismatchException;
import java.util.Locale;
import java.util.Scanner;

public class EnterEvenNumber {

    public static boolean isInteger(String s){
        try {
            Integer.parseInt(s);
        }catch (NumberFormatException exception){
            return true;
        }
        return false;
    }
    public static boolean isEven(String s){
        int num  = Integer.parseInt(s);
        if(num%2 ==0){
            return false;
        }
        return true;
    }
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        System.out.print("Enter even number: ");
        String n = input.nextLine();
        boolean check = true;

        while (isInteger(n) || isEven(n)){
            if(isInteger(n)){
                System.out.println("Invalid number!");
                System.out.print("Enter even number: ");
                n = input.nextLine();
            }else if(isEven(n)){
                System.out.println("The number is not even.");
                System.out.print("Enter even number: ");
                n = input.nextLine();
            }
        }

        System.out.println("Even number entered: " + n);

    }
}
