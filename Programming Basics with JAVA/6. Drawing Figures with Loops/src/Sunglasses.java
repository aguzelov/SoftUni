import java.util.Locale;
import java.util.Scanner;

public class Sunglasses {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);

        int n = input.nextInt();

        //first row
        System.out.print(repeatStr("*",n*2));
        System.out.print(repeatStr(" ",n));
        System.out.println(repeatStr("*",n*2));

        for(int i = 0; i<n-2; i++){
            //left
            System.out.print("*");
            System.out.print(repeatStr("/",2*n-2));
            System.out.print("*");

            //center
            if(i == (n-1)/2-1){
                System.out.print(repeatStr("|",n));
            }else{
                System.out.print(repeatStr(" ", n));
            }

            //right
            System.out.print("*");
            System.out.print(repeatStr("/",2*n-2));
            System.out.println("*");

        }

        //last row
        System.out.print(repeatStr("*",n*2));
        System.out.print(repeatStr(" ",n));
        System.out.println(repeatStr("*",n*2));

    }
    public static String repeatStr(String str, int count){
        String text = "";
        for(int i = 0; i < count; i++){
            text = text + str;
        }
        return text;
    }
}
