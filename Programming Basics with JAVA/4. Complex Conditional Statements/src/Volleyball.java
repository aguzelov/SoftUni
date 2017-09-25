import java.util.Locale;
import java.util.Scanner;

public class Volleyball {
    public static final int WEEKEND = 48;
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        String yearType = input.nextLine();
        int p = input.nextInt();
        int h = input.nextInt();

        double gameInSofia = (WEEKEND - h)*0.75;
        double gameOutSofia = h;

        double gameInHolidays = p* 0.6667;

        double totalGames = gameInHolidays + gameInSofia + gameOutSofia;

        if(yearType.equalsIgnoreCase("leap")){
            //System.out.println("test : " + (totalGames+(totalGames*0.15)));
            System.out.printf("%.0f", Math.floor(totalGames+(totalGames*0.15)));
        }else{
            //System.out.println("test : " + (totalGames));
            System.out.printf("%.0f", Math.floor(totalGames));
        }

    }
}
