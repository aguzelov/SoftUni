import java.util.Locale;
import java.util.Scanner;

public class RhombusOfStars {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);

        int n = input.nextInt();
        if(n == 1){
            System.out.println("*");
        }else{
            int stars = 0;
            for(int i = 1; i<=n-1 ; i++){
                System.out.print(repeatStr(" ", n-i));
                System.out.print(repeatStr("* ",stars));
                System.out.println("*");
                stars++;
            }
            for(int i = 0; i<n; i++){
                System.out.print(repeatStr(" ", i));
                System.out.print(repeatStr("* ", stars));
                System.out.println("*");
                stars--;
            }
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
