import java.util.Locale;
import java.util.Scanner;

public class House {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);

        int n = input.nextInt();


        //roof
        if(n%2==0){
            int roofStars = 2;
            for(int i = 0; i<(n+1)/2; i++) {
                System.out.print(repeatStr("-", (n - roofStars) / 2));
                System.out.print(repeatStr("*", roofStars));
                System.out.println(repeatStr("-", (n - roofStars) / 2));
                roofStars += 2;
            }
        }else{
            int roofStars = 1;
            for(int i = 0; i<(n+1)/2; i++) {
                System.out.print(repeatStr("-", (n - roofStars) / 2));
                System.out.print(repeatStr("*", roofStars));
                System.out.println(repeatStr("-", (n - roofStars) / 2));
                roofStars += 2;
            }
        }

        //base
        for(int i = 0; i<(n/2); i++){
            System.out.print("|");
            System.out.print(repeatStr("*",n-2));
            System.out.println("|");
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