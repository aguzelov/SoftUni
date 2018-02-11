import java.util.Locale;
import java.util.Random;
import java.util.Scanner;

public class Advertisement_Message {
    private static String[] PHRASES = new String[] {"Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product."};
    private static String[] EVENTS = new String[] {"Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"};
    private static String[] AUTHORS = new String[]{"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
    private static String[] CITIES = new String[] {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        int numberOfMessages = scanner.nextInt();
        for (int i = 0; i < numberOfMessages; i++) {
            int phraseIndex = randInt(PHRASES.length);
            int eventIndex = randInt(EVENTS.length);
            int authorIndex =randInt(AUTHORS.length);
            int townIndex = randInt(CITIES.length);
            System.out.printf("%s %s %s - %s%n", PHRASES[phraseIndex], EVENTS[eventIndex],AUTHORS[authorIndex],CITIES[townIndex]);
        }
    }
    private static int randInt(int max) {
        Random rand = new Random();
        int randomNum = rand.nextInt((max)) ;

        return randomNum;
    }
}