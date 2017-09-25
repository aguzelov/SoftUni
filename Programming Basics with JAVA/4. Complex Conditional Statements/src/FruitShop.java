
import java.lang.reflect.Array;
import java.util.*;

public class FruitShop {
    public static final String[] days = new String[]{"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
    public static final HashMap<String,Double> WORKDAYS;
    static {
        WORKDAYS = new HashMap<String,Double>();
        WORKDAYS.put("banana", 2.50);
        WORKDAYS.put("apple", 1.20);
        WORKDAYS.put("orange", 0.85);
        WORKDAYS.put("grapefruit", 1.45);
        WORKDAYS.put("kiwi", 2.70);
        WORKDAYS.put("pineapple", 5.50);
        WORKDAYS.put("grapes", 3.85);
    }
    public static final HashMap<String,Double> HOLIDAYS;
    static {
        HOLIDAYS = new HashMap<String,Double>();
        HOLIDAYS.put("banana", 2.70);
        HOLIDAYS.put("apple", 1.25);
        HOLIDAYS.put("orange", 0.90);
        HOLIDAYS.put("grapefruit", 1.60);
        HOLIDAYS.put("kiwi", 3.00);
        HOLIDAYS.put("pineapple", 5.60);
        HOLIDAYS.put("grapes", 4.20);
    }
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);

        String fruit = input.nextLine();
        String day = input.nextLine();
        Double quantity = input.nextDouble();


        if(!Arrays.asList(days).contains(day)){
            System.out.println("error");
        }else{
            if(!day.equalsIgnoreCase("Saturday")  && !day.equalsIgnoreCase("Sunday")){
                Double price = WORKDAYS.get(fruit);
                if(price != null){

                    System.out.println(price * quantity);
                }else {
                    System.out.println("error");
                }
            }else{
                Double price = HOLIDAYS.get(fruit);
                if(price != null){
                    System.out.println(price * quantity);
                }else {
                    System.out.println("error");
                }
            }
        }

    }
}
