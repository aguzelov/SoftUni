import java.util.Locale;
import java.util.Scanner;

public class Boolean_Variable {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();

        if(Boolean.valueOf(text)){
            System.out.println("Yes");
        }else{
            System.out.println("No");
        }
    }
}



