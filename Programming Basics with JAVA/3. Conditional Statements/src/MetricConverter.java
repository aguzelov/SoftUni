import java.util.*;

/**
 * Created by Aleksandur on 17.7.2017 г..
 */
public class MetricConverter {

    private static final Map<String, Double> map;
    static
    {
        map = new HashMap<String, Double>();
        map.put("m", Double.parseDouble("1"));
        map.put("mm", Double.parseDouble("1000"));
        map.put("cm", Double.parseDouble("100"));
        map.put("mi", Double.parseDouble("0.000621371192"));
        map.put("in", Double.parseDouble("39.3700787"));
        map.put("km", Double.parseDouble("0.001"));
        map.put("ft", Double.parseDouble("3.2808399"));
        map.put("yd", Double.parseDouble("1.0936133"));
    }

    public static void main(String... args){
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);

        Double number = Double.parseDouble(input.nextLine());
        String inputValue = input.nextLine().trim();
        String outputValue = input.nextLine().trim();

        double total = (number /  map.get(inputValue))*map.get(outputValue);

        System.out.printf("%.8f %s", total, outputValue);
    }
}
