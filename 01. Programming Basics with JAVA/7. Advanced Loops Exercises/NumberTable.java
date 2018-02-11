import java.util.Locale;
import java.util.Scanner;

public class NumberTable {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        if(n>1){
            //first row
            for(int i = 1 ; i<=n;i++){
                if(i == n){
                    System.out.print(i);
                }else {
                    System.out.print(i + " ");
                }
            }
            System.out.println();

            int secondNum = 2;
            int thirdNum = n-1;

            for(int i = 0 ; i< n-2 ; i++){
                for(int j = secondNum; j <= n; j++){
                    System.out.print(j+" ");
                }
                secondNum++;
                for(int l = n-1 ; l >= thirdNum; l--){
                    if(l == thirdNum){
                        System.out.print(l);
                    }else {
                        System.out.print(l + " ");
                    }
                }
                thirdNum--;
                System.out.println();
            }

            // last row
            for(int i = n ; i>=1;i--){
                if(i == 1){
                    System.out.print(i);
                }else{
                    System.out.print(i+" ");
                }
            }
        }else{
            System.out.println(1);
        }

    }
}
