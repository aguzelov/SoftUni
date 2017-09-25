import java.util.Locale;
import java.util.Scanner;

public class Cake {
    public static final int ONE_PIECE = 1 * 1;

    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int cakeW = input.nextInt();
        int cakeL = input.nextInt();
        int cakeArea = cakeW * cakeL;

        int pieces;

        while (input.hasNextInt()) {
            pieces = input.nextInt();
            if (cakeArea < pieces) {
                System.out.printf("No more cake left! You need %d pieces more.", pieces - cakeArea);
                return;
            }
            cakeArea -= pieces;
        }
        System.out.printf("%d pieces are left.", cakeArea);
    }
}
