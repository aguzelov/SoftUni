import java.util.Locale;
import java.util.Scanner;

public class Cinema {
    public static final double PREMIERE = 12.00;
    public static final double NORMAL = 7.50;
    public static final double DISCOUNT = 5.00;
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        String projectionType = input.nextLine();
        int row = input.nextInt();
        int col = input.nextInt();

        if(projectionType.equalsIgnoreCase("Premiere")){
            System.out.printf("%.2f leva", (row*col)*PREMIERE);
        }else if(projectionType.equalsIgnoreCase("Normal")){
            System.out.printf("%.2f leva",(row*col)*NORMAL);
        }else if(projectionType.equalsIgnoreCase("Discount")){
            System.out.printf("%.2f leva",(row*col)*DISCOUNT);
        }
    }
}
