import java.util.Locale;
import java.util.Scanner;

public class Fibonacci {
    public static int fibonacci(int n){
        if(n == 0){
            return 1;
        }else if(n == 1){
            return 1;
        }else{
            int f0 = 1;
            int f1 = 1;
            int fib = 0;
            for(int i = 1 ; i < n; i++){
                fib = f0+f1;
                f0 = f1;
                f1 = fib;
            }
            return fib;
        }
    }

    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        System.out.println(fibonacci(input.nextInt()));
    }
}
