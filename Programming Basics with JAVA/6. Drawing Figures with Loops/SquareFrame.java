import java.util.Locale;
import java.util.Scanner;

public class SquareFrame {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);

        int n = input.nextInt();

        System.out.print("+ ");
        System.out.print(repeatStr("- ", n-2));
        System.out.println("+");
        for(int i =0; i<n-2; i++){
            System.out.print("| ");
            System.out.print(repeatStr("- ", n-2));
            System.out.println("|");
        }
        System.out.print("+ ");
        System.out.print(repeatStr("- ", n-2));
        System.out.println("+");

    }
    public static String repeatStr(String str, int count){
        String text = "";
        for(int i = 0; i < count; i++){
            text = text + str;
        }
        return text;
    }
}