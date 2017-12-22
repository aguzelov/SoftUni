import java.util.Locale;
import java.util.Scanner;

public class Censor_Email_Address {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        String originEmail = scanner.nextLine();
        String[] emailParts = originEmail.split("@");
        emailParts[0] = emailParts[0].replaceAll(".", "*");
        String censorEmail = emailParts[0] + "@" + emailParts[1];

        String text = scanner.nextLine();
        int index = 0;
        while (index < text.length()){
            index = text.indexOf(originEmail,index);
            if(index < 0){
                System.out.println(text);
                return;
            }

            text = text.subSequence(0, index) +
                    censorEmail +
                    text.subSequence(index+censorEmail.length(), text.length());

        }

    }
}