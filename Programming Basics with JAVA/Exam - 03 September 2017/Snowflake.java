import java.util.Locale;
import java.util.Scanner;

public class Snowflake {
    public static int n = 0;
    public static int h = 0;
    public static int w = 0;

    Snowflake(int n) {
        Snowflake.n = n;
        Snowflake.h = 2 * n + 1;
        Snowflake.w = 2 * n + 3;
    }

    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        new Snowflake(input.nextInt());
        // N = 3 h = 7 w = 9
        // N = 5 h = 11 w = 13


        for (int i = 0; i < n; i++) {
            print(replaceStr(".", i));
            if (i == n - 1) {
                print(replaceStr("*", w - (i * 2)));
            } else {
                print("*");
                print(replaceStr(".", n - i));
                print("*");
                print(replaceStr(".", n - i));
                print("*");
            }
            printNewLine(replaceStr(".", i));
        }

        printNewLine(replaceStr("*", w));

        for (int i = n - 1; i >= 0; i--) {
            print(replaceStr(".", i));
            if (i == n - 1) {
                print(replaceStr("*", w - (i * 2)));
            } else {
                print("*");
                print(replaceStr(".", n - i));
                print("*");
                print(replaceStr(".", n - i));
                print("*");
            }
            printNewLine(replaceStr(".", i));
        }
    }

    public static String replaceStr(String symbol, int count) {
        String text = "";

        for (int i = 0; i < count; i++) {
            text += symbol;
        }
        return text;
    }

    public static void print(String text) {
        System.out.print(text);
    }

    public static void printNewLine(String text) {
        System.out.println(text);
    }
}
