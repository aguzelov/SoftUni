import java.util.Locale;
import java.util.Scanner;

public class OddEvenPosition {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);

        double oddSum = 0;
        double oddMin = 100000000;
        double oddMax = -100000000;

        double evenSum = 0;
        double evenMin = 100000000;
        double evenMax = -100000000;


        int n = input.nextInt();
        double temp;
        for(int i = 0; i<n;i++){
            temp = input.nextDouble();
            if(i%2==0){
                oddSum += temp;
                if(temp > oddMax){
                    oddMax = temp;
                }
                if(temp < oddMin){
                    oddMin = temp;
                }

            }else{
                evenSum += temp;
                if(temp > evenMax){
                    evenMax = temp;
                }
                if(temp < evenMin){
                    evenMin = temp;
                }
            }
        }
        System.out.println( Double.toString(oddSum));
        System.out.printf("OddSum="+oddSum+", ");
        if(oddMin != 100000000){
            System.out.print("OddMin="+oddMin+", ");
        }else{
            System.out.print("OddMin=No, ");
        }
        if(oddMax != -100000000){
            System.out.print("OddMax="+oddMax+", ");
        }else{
            System.out.print("OddMax=No, ");
        }

        System.out.print("EvenSum="+evenSum+", ");
        if(evenMin != 100000000){
            System.out.print("EvenMin="+evenMin+", ");
        }else{
            System.out.print("EvenMin=No, ");
        }
        if(evenMax != -100000000){
            System.out.print("EvenMax="+evenMax);
        }else{
            System.out.print("EvenMax=No");
        }
    }
}
