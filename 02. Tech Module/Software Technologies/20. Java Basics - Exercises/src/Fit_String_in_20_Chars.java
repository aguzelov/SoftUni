import java.util.Locale;
import java.util.Scanner;

public class Fit_String_in_20_Chars {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();

        if(input.length() < 20){
            StringBuilder text = new StringBuilder();
            text.append(input);
            while (text.length() != 20){
                text.append("*");
            }
            System.out.println(text);
        }else{
            System.out.println(input.substring(0, 20));
        }
    }
}