import java.util.Locale;
import java.util.Scanner;

public class LeftAndRightSum {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        //left
        int leftSum = 0;
        for(int i = 0; i < n; i++){
            leftSum += input.nextInt();
        }
        //right
        int rightSum = 0;
        for(int i = 0; i < n; i++){
            rightSum += input.nextInt();
        }

        if(leftSum == rightSum){
            System.out.println("Yes, sum = " + leftSum);
        }else{
            System.out.println("No, diff = "+ Math.abs(leftSum-rightSum));
        }
    }
}
