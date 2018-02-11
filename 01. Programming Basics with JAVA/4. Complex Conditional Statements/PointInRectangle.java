import java.util.Locale;
import java.util.Scanner;

public class PointInRectangle {

    public boolean inRectangle = false;
    double x1 , y1, x2 , y2;
    double x, y;

    public PointInRectangle(double x1, double y1, double x2, double y2, double x, double y){
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x = x;
            this.y = y;
        }
    public void check(){
        if((this.x >= this.x1 && this.x <= x2) && (this.y >= this.y1 && this.y <= this.y2) ){
            this.inRectangle = true;
        }
    }

    public boolean isInRectangle(){
        this.check();
        return this.inRectangle;
    }


    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        PointInRectangle checkForPoint = new PointInRectangle(input.nextDouble(),input.nextDouble(),input.nextDouble(),input.nextDouble(),input.nextDouble(),input.nextDouble());

        if(checkForPoint.isInRectangle()){
            System.out.println("Inside");
        }else{
            System.out.println("Outside");
        }

    }
}
