import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Locale;
import java.util.Scanner;

public class FruitOrVegetable {
    public static final String[] FRUIT = new String[]{"banana", "apple", "kiwi", "cherry", "lemon", "grapes"};
    public static final String[] VEGETABLE = new String[]{"tomato", "cucumber","pepper", "carrot"};

    public static boolean isInArray(String searchWord, String[] array){
        return Arrays.asList(array).contains(searchWord);
    }

    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        String word = input.nextLine();
        if(isInArray(word,FRUIT)){
            System.out.println("fruit");
        }else if(isInArray(word,VEGETABLE)){
            System.out.println("vegetable");
        }else{
            System.out.println("unknown");
        }

    }
}
