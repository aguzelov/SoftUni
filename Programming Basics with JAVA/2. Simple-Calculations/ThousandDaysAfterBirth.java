import java.nio.channels.CancelledKeyException;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import java.util.Scanner;

/**
 * Created by Aleksandur on 9.7.2017 г..
 */
public class ThousandDaysAfterBirth {
    public static void main(String[] args){
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        String userInput = input.nextLine();

        DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd-MM-yyyy");
        LocalDate date = LocalDate.parse(userInput,dateFormat).plusDays(999);
        date.format(dateFormat);
        String formattedDate = date.format(dateFormat);
        System.out.println(formattedDate);
    }
}
