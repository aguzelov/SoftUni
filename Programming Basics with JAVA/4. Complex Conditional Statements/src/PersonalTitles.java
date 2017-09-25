import java.util.Locale;
import java.util.Scanner;

public class PersonalTitles {
    public static String title = null;

    public static void setTitle(double age, String gender){
        if(gender.equalsIgnoreCase("m")){
            if(age >= 16){
                title = "Mr.";
            }else if(age < 16){
                title = "Master";
            }
        }else if( gender.equalsIgnoreCase("f")){
            if(age >= 16){
                title = "Ms.";
            }else if(age < 16){
                title = "Miss";
            }
        }
    }
    public static void printTitle(){
        System.out.println(title);
    }

    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        double age = input.nextDouble();
        input.nextLine();
        String gender = input.nextLine();
        setTitle(age, gender);
        printTitle();

    }
}
