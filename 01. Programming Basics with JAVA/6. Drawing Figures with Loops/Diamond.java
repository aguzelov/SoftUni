import java.util.Locale;
import java.util.Scanner;

public class Diamond {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);

        int n =input.nextInt();
        if(n == 1){
            System.out.println("*");
        }else{
            if(n%2==0){
                for(int i = 0; i<=(n-1)/2; i++){
                    System.out.print(repeatStr("-", ((n-1)/2)-i));

                    System.out.print("*");
                    System.out.print(repeatStr("-", i*2));
                    System.out.print("*");

                    System.out.println(repeatStr("-", ((n-1)/2)-i));
                }
                for(int i = ((n-1)/2)-1; i>=0; i--){
                    System.out.print(repeatStr("-", ((n-1)/2)-i));

                    System.out.print("*");
                    System.out.print(repeatStr("-", i*2));
                    System.out.print("*");

                    System.out.println(repeatStr("-", ((n-1)/2)-i));
                }
            }else{
                System.out.print(repeatStr("-", ((n-1)/2)));
                System.out.print("*");
                System.out.println(repeatStr("-", ((n-1)/2)));

                for(int i = 0; i<=(n-2)/2; i++){
                    System.out.print(repeatStr("-", ((n-1)/2)-(i+1)));

                    System.out.print("*");
                    System.out.print(repeatStr("-", (i*2)+1));
                    System.out.print("*");

                    System.out.println(repeatStr("-", ((n-1)/2)-(i+1)));
                }
                for(int i = ((n-2)/2)-1; i>=0; i--){
                    System.out.print(repeatStr("-", ((n-1)/2)-(i+1)));

                    System.out.print("*");
                    System.out.print(repeatStr("-", (i*2)+1));
                    System.out.print("*");

                    System.out.println(repeatStr("-", ((n-1)/2)-(i+1)));
                }
                System.out.print(repeatStr("-", ((n-1)/2)));
                System.out.print("*");
                System.out.println(repeatStr("-", ((n-1)/2)));
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