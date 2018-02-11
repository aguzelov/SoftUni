import java.util.Locale;
import java.util.Scanner;

public class PointInFigure {
    public static void print(String outputText){
        System.out.println(outputText);
    }
    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        int h = input.nextInt();
        int x = input.nextInt();
        int y = input.nextInt();

        int firstH = h;
        int firstW = h*3;
        int secondH = h * 3;
        int secondW = h;
        // low part

        if((x > 0 && x < firstW) && (y > 0 && y < h) ){ //inside
            print("inside");
        }else if ((x < 0 || x > firstW) || (y < 0 || y > h) && !((x > h && (x < (h + secondW))) && (y > h && (y < (h + secondH))))){ // outside
            print("outside");
        }else if((x==0) && (y>= 0 && y <= h)){ //border left
            print("border");
        }else if((y == h) && (x>= 0 && x <= firstW) ){// border up
            print("border");
        }else if((x == firstW) && (y>= 0 && y <= h)){ // border right
            print("border");
        }else if((y==0) && (x>= 0 && x <= firstW)){//border down
            print("border");
        }else {

            //Up part

            if ((x > h && (x < (h + secondW))) && (y > h && (y < (h + secondH)))) { //inside
                print("inside");
            } else if ((x < h || x > (h + secondW)) || (y < h || y > (h + secondH))) { // outside
                print("outside");
            } else if ((x == h) && (y >= h && y <= (h + secondW))) { //border left
                print("border");
            } else if ((y == (h + secondW)) && (x >= h && x <= (h + secondH))) {// border up
                print("border");
            } else if ((x == (h + secondW)) && (y >= h && y <= (h + secondH))) { // border right
                print("border");
            } else if ((y == h) && (x >= h && x <= (h + secondW))) {//border down
                print("border");
            }
        }
    }
}
