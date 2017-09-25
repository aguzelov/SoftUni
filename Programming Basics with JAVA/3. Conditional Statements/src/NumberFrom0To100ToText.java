/**
 * Created by Aleksandur on 17.7.2017 г..
 */

import java.util.Locale;
import java.util.Scanner;

public class NumberFrom0To100ToText {
        public static final String[] units = {
                "", "one", "two", "three", "four", "five", "six", "seven",
                "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen",
                "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        };

        public static final String[] tens = {
                "",        // 0
                "",        // 1
                "twenty",  // 2
                "thirty",  // 3
                "forty",   // 4
                "fifty",   // 5
                "sixty",   // 6
                "seventy", // 7
                "eighty",  // 8
                "ninety"   // 9
        };

        public static String convert(final int n) {
            if (n < 0) {
                return "invalid number";
            }
            if(n == 0){
                return "zero";
            }
            if (n < 20) {
                return units[n];
            }

            if (n < 100) {
                return tens[n / 10] + ((n % 10 != 0) ? " " : "") + units[n % 10];
            }

            if(n == 100){
                return "one hundred";
            }

            if(n > 100){
               return "invalid number";
            }
            return "test";
        }

        public static void main(final String[] args) {
            Scanner input = new Scanner(System.in);

            System.out.printf("%s", convert(input.nextInt()));

        }
}
