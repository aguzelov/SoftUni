import java.util.Locale;
import java.util.Scanner;

public class Three_Integers_Sum {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();
        String[] stringArray = input.split(" ");
        int[] arr = new int[stringArray.length];
        for(int i = 0; i < stringArray.length; i++){
            arr[i] = Integer.parseInt(stringArray[i]);
        }
        CheckIfExist(arr[0], arr[1], arr[2]);
    }

    public static void CheckIfExist(int firstNum, int secondNum, int thirdNum){

        if(firstNum == secondNum + thirdNum){
            int min = secondNum < thirdNum ? secondNum : thirdNum;
            int max = secondNum > thirdNum ? secondNum : thirdNum;
            System.out.println("" + min + " + " + max + " = " + firstNum);
        }else if(secondNum == firstNum + thirdNum){
            int min = firstNum < thirdNum ? firstNum : thirdNum;
            int max = firstNum > thirdNum ? firstNum : thirdNum;
            System.out.println("" + min + " + " + max + " = " + secondNum);
        }else if(thirdNum == secondNum + firstNum){
            int min = firstNum < secondNum ? firstNum : secondNum;
            int max = firstNum > secondNum ? firstNum : secondNum;
            System.out.println("" + min + " + " + max + " = " + thirdNum);
        }else {
            System.out.println("No");
        }
    }

}



