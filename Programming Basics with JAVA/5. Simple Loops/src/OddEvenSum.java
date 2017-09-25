import java.util.Locale;
import java.util.Scanner;

public class OddEvenSum {
    public static final void test(){
        System.out.println("test");
    }
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        int oddSum = 0;
        int evenSum = 0;
        int temp;
        for(int i = 0; i<n;i++ ){
            temp = input.nextInt();
            if(i%2 == 0){
                oddSum+=temp;
            }else{
                evenSum+=temp;
            }
        }

        if(oddSum == evenSum){
            System.out.println("Yes");
            System.out.println("Sum = " + oddSum);
        }else{
            System.out.println("No");
            System.out.println("Diff = "+ Math.abs(oddSum-evenSum));
        }
    }
}
