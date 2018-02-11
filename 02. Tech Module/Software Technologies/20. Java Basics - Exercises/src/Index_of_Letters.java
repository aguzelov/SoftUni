import java.util.ArrayList;
import java.util.Arrays;
import java.util.Locale;
import java.util.Scanner;

public class Index_of_Letters {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        ArrayList<Character> letterArray = new ArrayList<>();

        char letter = 'a';

        for (int i = 0; i < 26; i++) {
            letterArray.add(letter);
            letter++;
        }

        String word = scanner.nextLine();

        for(int i = 0; i < word.length(); i++){
            char c = word.charAt(i);
            int index = letterArray.indexOf(c);

            System.out.printf("%s -> %d%n", c, index);

        }

    }
}