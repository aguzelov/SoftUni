import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.Collections;
import java.util.Locale;
import java.util.Scanner;

public class Largest_Three_Numbers {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        String[] input = scanner.nextLine().split(" ");
        int[] array = Arrays.asList(input).stream().mapToInt(Integer::parseInt).toArray();

        Arrays.sort(array);
        int count = array.length >= 3 ? 3 : array.length;
        for(int i = 0; i < count; i++){

            System.out.println(array[array.length - (i+1)]);
        }
    }
}



