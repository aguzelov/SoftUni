import java.util.Locale;
import java.util.Scanner;

public class Sequence2k {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();

        int num = 1;
        for(int i = 0 ; i<n; i++){
            if(num>n){
                break;
            }
            System.out.println(num);
            num = (num*2)+1;

        }
    }

}
