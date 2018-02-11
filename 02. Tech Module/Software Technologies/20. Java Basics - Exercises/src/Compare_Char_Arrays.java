import java.util.Locale;
import java.util.Scanner;

public class Compare_Char_Arrays {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        char[] first = scanner.nextLine().replaceAll(" ","").toCharArray();
        char[] second = scanner.nextLine().replaceAll(" ","").toCharArray();

        String firstString = String.valueOf(first);
        String secondString = String.valueOf(second);


        if(first.length == second.length){
            int firstSum = 0;
            int secondSum = 0;

            for(int i = 0; i < first.length; i++){
                firstSum += first[i];
                secondSum += second[i];
            }

            if(firstSum == secondSum){
                System.out.println(firstString);
                System.out.println(secondString);
            }else if(firstSum < secondSum){
                System.out.println(firstString);
                System.out.println(secondString);
            }else{
                System.out.println(secondString);
                System.out.println(firstString);
            }
        }else{
            if(first.length < second.length){
                System.out.println(firstString);
                System.out.println(secondString);
            }else{
                System.out.println(secondString);
                System.out.println(firstString);
            }
        }
    }

    private static char[] TakeCharArray(){
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();
        input = input.replaceAll(" ","");
        char[] arr = input.toCharArray();

        return arr;
    }
}