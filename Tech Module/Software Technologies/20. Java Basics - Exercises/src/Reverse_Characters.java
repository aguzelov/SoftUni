import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.Scanner;

public class Reverse_Characters {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        List<Character> reversed = new ArrayList<>();
        for(int i =0 ; i< 3; i++){
            Character c = scanner.nextLine().charAt(0);
            reversed.add(0,c);
        }
        for(Character c : reversed){
            System.out.print(c);
        }
    }
}



