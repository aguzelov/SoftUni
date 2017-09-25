import java.util.Locale;
import java.util.Scanner;

public class HalfSumElement {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();

        int maxValue = 0;
        int otherSum = 0;
        for(int i = 0 ; i< n; i++){
            int temp = input.nextInt();
            if(temp > maxValue){
                otherSum += maxValue;
                maxValue = temp;
            }else{
                otherSum += temp;
            }
        }
        if(maxValue == otherSum){
            System.out.println("Yes");
            System.out.println("Sum = " + maxValue);
        }else {
            System.out.println("No");
            System.out.println("Diff = " + Math.abs(maxValue - otherSum));
        }

    }
}
