import java.util.Locale;
import java.util.Scanner;

public class ChristmasTree {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);

        int n = input.nextInt();

        System.out.print(repeatStr(" ", n));
        System.out.print(" | ");
        System.out.println(repeatStr(" ", n));

        for(int i = 1; i<=n;i++){
            System.out.print(repeatStr(" ",n-i));
            System.out.print(repeatStr("*", i));
            System.out.print(" | ");
            System.out.print(repeatStr("*", i));
            System.out.println(repeatStr(" ",n-i));
        }

    }
    public static String repeatStr(String str, int count){
        String text = "";
        for(int i = 0; i < count; i++){
            text = text + str;
        }
        return text;
    }
}