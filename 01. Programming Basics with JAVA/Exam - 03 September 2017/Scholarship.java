import sun.nio.cs.ext.MacArabic;

        import java.util.Locale;
        import java.util.Scanner;

public class Scholarship {
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);

        double budget = input.nextDouble();
        double averageGrade = input.nextDouble();
        double minSalary = input.nextDouble();

        double social = minSalary * 0.35;
        double excellent = averageGrade * 25;

        if (budget >= minSalary && averageGrade < 5.5) {
            System.out.println("You cannot get a scholarship!");
            return;
        }

        if (budget < minSalary && averageGrade > 4.5 && averageGrade < 5.5) {
            System.out.printf("You get a Social scholarship %d BGN", (int) Math.floor(social));
        } else if (budget < minSalary && averageGrade >= 5.5) {
            if (social > excellent) {
                System.out.printf("You get a Social scholarship %d BGN", (int) Math.floor(social));
            } else if(excellent >= social) {
                System.out.printf("You get a scholarship for excellent results %d BGN", (int) Math.floor(excellent));
            }
        } else if (averageGrade >= 5.5) {
            System.out.printf("You get a scholarship for excellent results %d BGN", (int) Math.floor(excellent));
        }
    }
}
