import java.util.Locale;
import java.util.Scanner;

public class NumbersEndingIn7 {
    public static void main(String... args) {
        //Locale.setDefault(Locale.ROOT);
        //Scanner input = new Scanner(System.in);
        for(int i = 1 ; i<=1000 ; i++){
            if(i%10 == 7){
                System.out.println(i);
            }
        }
    }
}
