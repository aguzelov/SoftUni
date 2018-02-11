import java.util.*;

public class Sums_by_Town {
    private static Map<String, Double> towns = new TreeMap<String, Double>() {
    };

    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        int n = scanner.nextInt();
        scanner.nextLine();
        for(int i = 0; i < n; i++){
            String input = scanner.nextLine();
            AddTowns(input);
        }

        for (Map.Entry<String,Double> entry : towns.entrySet()) {
            System.out.println(entry.getKey() + " -> " + entry.getValue());
        }

    }

    private static void AddTowns(String line){
        String[] arr = line.split("\\s+\\|\\s+");
        String townName = arr[0];
        Double income = Double.parseDouble(arr[1]);

        if(towns.containsKey(townName)){
            towns.put(townName, towns.get(townName) + income);
        }else{
            towns.put(townName, income);
        }

    }
}



