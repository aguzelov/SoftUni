/**
 * Created by Aleksandur on 17.7.2017 г..
 */

import java.util.Locale;
import java.util.Scanner;

public class PippeInPool {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int poolV = input.nextInt();
        int flowRateFirstPippe = input.nextInt();
        int flowRateSecondPippe = input.nextInt();
        input.nextLine();
        String H = input.nextLine();
        double hours = Double.parseDouble(H);

        double flowRateFirstTubeTotalV = (flowRateFirstPippe * hours);
        double flowRateSecondTubeTotalV = (flowRateSecondPippe * hours);
        double totalV = flowRateFirstTubeTotalV + flowRateSecondTubeTotalV;


        if(poolV >= totalV){
            System.out.printf("The pool is %.0f%% full. Pipe 1: %.0f%%. Pipe 2: %.0f%%.",
                    Math.floor((totalV/poolV)*100),
                    Math.floor((flowRateFirstTubeTotalV/totalV) *100),
                    Math.floor((flowRateSecondTubeTotalV/totalV) *100));
        }else {
            System.out.printf("For %s hours the pool overflows with %.1f liters.",
                    H, totalV-poolV);
        }
    }
}