import java.util.Locale;
import java.util.Scanner;

public class Vowel_or_Digit {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        Character c = scanner.nextLine().charAt(0);

        if( Character.isDigit(c)){
            System.out.println("digit");
        }else if("aeiou".indexOf(c) >= 0){
            System.out.println("vowel");
        }else{
            System.out.println("other");
        }
    }
}