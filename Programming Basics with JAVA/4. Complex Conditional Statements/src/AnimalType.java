import java.util.Locale;
import java.util.Scanner;

public class AnimalType {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        String type = input.nextLine();
        if(type.equalsIgnoreCase("dog")){
            System.out.println("mammal");
        }else if(type.equalsIgnoreCase("crocodile") || type.equalsIgnoreCase("tortoise") || type.equalsIgnoreCase("snake")){
            System.out.println("reptile");
        }else{
            System.out.println("unknown");
        }
    }
}
