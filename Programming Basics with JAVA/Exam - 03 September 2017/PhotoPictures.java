import java.util.HashMap;
import java.util.Locale;
import java.util.Scanner;

public class PhotoPictures {
    public static final HashMap<String, Double> PRICE_TABLE;
    static {
        PRICE_TABLE = new HashMap<String, Double>();
        PRICE_TABLE.put("9X13",0.16);
        PRICE_TABLE.put("10X15",0.16);
        PRICE_TABLE.put("13X18",0.38);
        PRICE_TABLE.put("20X30",2.90);
    }

    public static void main(String... args) {
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);

        double pictures = input.nextInt();

        input.nextLine();
        String picturesType = input.nextLine();
        String type = input.nextLine();

        double price = pictures * PRICE_TABLE.get(picturesType);
        if(picturesType.equalsIgnoreCase("9X13")&& pictures>50){
            price -=price*0.05;
        }else if(picturesType.equalsIgnoreCase("10X15") && pictures > 80){
            price -=price*0.03;
        }else if(picturesType.equalsIgnoreCase("13X18")){
            if(pictures>= 50 && pictures <= 100){
                price -=price*0.03;
            }else if(pictures > 100){
                price -=price*0.05;
            }
        }else if(picturesType.equalsIgnoreCase("20X30")){
            if(pictures>= 10 && pictures <= 50){
                price -=price*0.07;
            }else if(pictures > 50){
                price -=price*0.09;
            }
        }

        if(type.equalsIgnoreCase("online")){
            price-=price*0.02;
        }
        System.out.printf("%.2fBGN", price);
    }
}
