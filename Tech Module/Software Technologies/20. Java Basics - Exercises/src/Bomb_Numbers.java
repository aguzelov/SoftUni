import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Locale;
import java.util.Scanner;

public class Bomb_Numbers {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        int[] inputArray = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        ArrayList<Integer> numbers = new ArrayList<>();

        for (int i = 0; i < inputArray.length; i++) {
            numbers.add(inputArray[i]);
        }

        int specialNumber = scanner.nextInt();
        int power = scanner.nextInt();

        int index = 0;
        while (index < numbers.size()){
            if(numbers.get(index) == specialNumber){
                numbers.subList(index-power < 0 ? 0 : index- power,
                        index+ power + 1 >= numbers.size() ? numbers.size() : index + power +1).clear();
                index = 0;
            }else {
                index++;
            }
        }

        int sum = 0;
        for(Integer i : numbers){
            sum += i;
        }
        System.out.println(sum);
    }

    private static boolean indexOutOfBounds(int index, ArrayList<Integer> numbers ){
        if(index < 0 || index >= numbers.size()){
            return  true;
        }
        return false;
    }
}