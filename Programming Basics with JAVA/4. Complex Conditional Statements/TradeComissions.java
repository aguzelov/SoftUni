import java.util.Locale;
import java.util.Scanner;

public class TradeComissions {

    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);

        String town = input.nextLine();
        double sales = input.nextDouble();


        if(town.equalsIgnoreCase("Sofia")){
            if(sales >= 0 && sales <=500){
                System.out.printf("%.2f",sales*0.05);
            }else if(sales > 500 && sales <=1000){
                System.out.printf("%.2f",sales*0.07);
            }else if(sales > 1000 && sales <=10000){
                System.out.printf("%.2f",sales*0.08);
            }else if(sales > 10000){
                System.out.printf("%.2f",sales*0.12);
            }else{
                System.out.println("error");
            }
        }else if(town.equalsIgnoreCase("Varna")){
            if(sales >= 0 && sales <=500){
                System.out.printf("%.2f",sales*0.045);
            }else if(sales > 500 && sales <=1000){
                System.out.printf("%.2f",sales*0.075);
            }else if(sales > 1000 && sales <=10000){
                System.out.printf("%.2f",sales*0.10);
            }else if(sales > 10000){
                System.out.printf("%.2f",sales*0.13);
            }else{
                System.out.println("error");
            }
        }else if(town.equalsIgnoreCase("Plovdiv")){
            if(sales >= 0 && sales <=500){
                System.out.printf("%.2f",sales*0.055);
            }else if(sales > 500 && sales <=1000){
                System.out.printf("%.2f",sales*0.08);
            }else if(sales > 1000 && sales <=10000){
                System.out.printf("%.2f",sales*0.12);
            }else if(sales > 10000){
                System.out.printf("%.2f",sales*0.145);
            }else{
                System.out.println("error");
            }
        }else{
            System.out.println("error");
        }

    }
}
