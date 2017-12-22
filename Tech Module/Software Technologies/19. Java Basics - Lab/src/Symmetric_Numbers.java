import java.util.Locale;
import java.util.Scanner;

public class Symmetric_Numbers {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        int n = scanner.nextInt();

        for(int i = 1; i <= n; i++){
            if(isSymmetrical(i)){
                System.out.println(i);
            }
        }
    }

    private static boolean isSymmetrical(int num){
        String stringNum = "" + num;
        stringNum = new StringBuilder(stringNum).reverse().toString();
        int reversedNum = Integer.parseInt(stringNum);

        return reversedNum == num;
    }
}



