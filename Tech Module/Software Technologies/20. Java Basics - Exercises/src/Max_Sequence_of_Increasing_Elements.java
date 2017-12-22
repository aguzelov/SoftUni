import java.util.Locale;
import java.util.Scanner;

public class Max_Sequence_of_Increasing_Elements {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        String[] input = scanner.nextLine().replaceAll(" ", ",").split(",");
        int[] array = StringToIntArray(input);

        int start = 0;
        int len = 1;
        int bestStart = 0;
        int bestLen = 0;
        int pos = 0;
        while (pos < array.length - 1)
        {
            if (array[pos] < array[pos + 1])
            {
                len++;
            }
            else
            {
                if(len > bestLen){
                    bestLen = len;
                    bestStart = start;
                }
                len = 1;
                start = pos+1;
            }
            pos++;

            if (bestLen == 1)
            {
                bestStart = array[0];
            }
        }

        if(len > bestLen){
            bestLen = len;
            bestStart = start;
        }

        for (int i = bestStart; i < bestStart + bestLen; i++)
        {
            System.out.print(array[i] + " ");
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