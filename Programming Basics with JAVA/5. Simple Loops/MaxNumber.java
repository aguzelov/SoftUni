import java.util.Locale;
import java.util.Scanner;

public class MaxNumber {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        int biggestNum = Integer.MIN_VALUE;
        int temp;
        for(int i = 0 ; i < n ; i++){
            temp = input.nextInt();
            if(temp > biggestNum){
                biggestNum=temp;
            }
        }
        System.out.println(biggestNum);
    }
}
