import java.util.Locale;
import java.util.Scanner;

public class CheckPrime {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        if(n <2){
            System.out.println("Not Prime");
        }else{
            if(isPrime(n)){
                System.out.println("Prime");
            }else{
                System.out.println("Not Prime");
            }
        }

    }
    public static boolean isPrime (int n){
        for(int i = 2; i < n; i++){
            if(n%i == 0){
                return false;
            }
        }
        return true;
    }
}
