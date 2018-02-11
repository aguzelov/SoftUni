import java.util.Arrays;
import java.util.Locale;
import java.util.Scanner;

public class Max_Sequence_of_Equal_Elements {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        String[] input = scanner.nextLine().replaceAll(" ", ",").split(",");
        int[] array = StringToIntArray(input);

        int maxnumbers = 0;
        int count = 1;
        int maxcount = 1;
        int pos = 0;
        while (pos < array.length - 1)
        {

            if (array[pos] == array[pos + 1])
            {
                count++;

                if (count > maxcount)
                {
                    maxcount = count;
                    maxnumbers = array[pos];
                }

            }
            else
            {
                count = 1;
            }
            pos++;
            if (maxcount == 1)
            {
                maxnumbers = array[0];
            }
        }
        for (int i = 0; i < maxcount; i++)
        {
            System.out.print(maxnumbers + " ");
        }
    }

    private static int[] StringToIntArray(String[] stringArray){
        int[] intArray = new int[stringArray.length];
        for(int i = 0; i < stringArray.length; i++){
            intArray[i] = Integer.parseInt("" + stringArray[i]);
        }

        return intArray;
    }
}