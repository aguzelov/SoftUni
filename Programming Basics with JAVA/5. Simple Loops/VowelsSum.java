import org.omg.PortableInterceptor.INACTIVE;

import java.util.HashMap;
import java.util.Locale;
import java.util.Scanner;

public class VowelsSum {
    public static final HashMap<Character, Integer> VOWELS;
    static {
        VOWELS = new HashMap<Character, Integer>();
        VOWELS.put('a', 1);
        VOWELS.put('e', 2);
        VOWELS.put('i', 3);
        VOWELS.put('o', 4);
        VOWELS.put('u', 5);
    }
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        String inputText = input.nextLine();

        int sum = 0;

        for (int i = 0; i < inputText.length(); i++){
            Integer value = VOWELS.get(inputText.charAt(i));
            if(value != null){
                sum += value;
            }
        }
        System.out.println(sum);
    }
}
