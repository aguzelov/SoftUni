import java.util.Arrays;
import java.util.Locale;
import java.util.Scanner;

public class Equal_Sums {
    public static void main(String[] args) {

        int[] array = getIntArray();
        boolean isFindEqual = false;

        for (int i = 0; i < array.length; i++) {
            int leftSum = leftSum(array, i);

            int rightSum = rightSum(array, i);

            if (leftSum == rightSum) {
                System.out.println(i);
                isFindEqual = true;
            }
        }


        if (isFindEqual) {
            return;
        }
        System.out.println("no");

    }

    public static int leftSum(int[] array, int index) {
        int sum = 0;
        for (int i = 0; i < index; i++) {
            sum += array[i];
        }
        return sum;
    }

    public static int rightSum(int[] array, int index) {
        int sum = 0;
        for (int i = index + 1; i < array.length; i++) {
            sum += array[i];
        }
        return sum;
    }

    public static int[] getIntArray() {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        return Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
    }
}