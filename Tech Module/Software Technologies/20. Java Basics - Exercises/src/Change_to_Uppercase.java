import java.util.Locale;
import java.util.Scanner;

public class Change_to_Uppercase {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();
        int openIndex = 0;
        int closeIndex = 0;
        while (true){
            openIndex = text.indexOf("<upcase>",openIndex);
            closeIndex = text.indexOf("</upcase>",closeIndex);
            if(openIndex != -1){
                String sub = text.substring(openIndex+8, closeIndex);
                sub = sub.toUpperCase();

                text = text.substring(0, openIndex) +
                        sub +
                        text.substring(closeIndex+9, text.length());
            }else{
                System.out.println(text);
                return;
            }

        }
    }
}