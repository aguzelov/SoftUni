import java.util.*;

public class Most_Frequent_Number {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        int[] numbers = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

        HashMap<Integer, Integer> numberFrequent = new HashMap<>();

        for (int i = 0; i < numbers.length; i++) {
            Integer count = numberFrequent.get(numbers[i]);

            numberFrequent.put(numbers[i], count !=  null ? count + 1: 0);
        }

        int count = 1, tempCount;
        int popular = numbers[0];
        int temp = 0;
        for (int i = 0; i < (numbers.length - 1); i++)
        {
            temp = numbers[i];
            tempCount = 0;
            for (int j = 0; j < numbers.length; j++)
            {
                if (temp == numbers[j])
                    tempCount++;
            }
            if (tempCount > count)
            {
                popular = temp;
                count = tempCount;
            }
        }

        System.out.println(popular);

    }
}

/*
4 1 1 4 2 3 4 4 1 2 4 9 3  - 4
2 2 2 2 1 2 2 2 - 2
7 7 7 0 2 2 2 0 10 10 10 - 7


 */