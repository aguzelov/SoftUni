import java.util.Locale;
import java.util.Scanner;

public class NumberPyramid {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);

        int n = input.nextInt();
        int number = 1;
        int row = 1;
        for(int i = 0 ; i< n; i++){
            for(int j = 0; j < row; j++){
                if(number > n){
                    break;
                }
                System.out.print(number + " ");
                number++;
            }
            System.out.println();
            row++;
        }
    }
}
