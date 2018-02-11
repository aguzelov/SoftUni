import java.util.*;

public class Book_Library {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        int n = scanner.nextInt();
        scanner.nextLine();

        TreeMap<String, Double> authors = new TreeMap<>();

        for (int i = 0; i < n; i++) {
            String[] input = scanner.nextLine().split(" ");
            String author = input[1];
            Double price = Double.parseDouble(input[5]);

            if (authors.containsKey(author)){
                authors.put(author, authors.get(author) + price);
            }else{
                authors.put(author,price);
            }
        }

        for(Map.Entry<String,Double> entry : entriesSortedByValues(authors)){
            System.out.printf("%s -> %.2f%n", entry.getKey(),entry.getValue());
        }
    }

    static <K,V extends Comparable<? super V>> SortedSet<Map.Entry<K,V>> entriesSortedByValues(Map<K,V> map) {
        SortedSet<Map.Entry<K,V>> sortedEntries = new TreeSet<Map.Entry<K,V>>(
                new Comparator<Map.Entry<K,V>>() {
                    @Override public int compare(Map.Entry<K,V> e1, Map.Entry<K,V> e2) {
                        int res = e2.getValue().compareTo(e1.getValue());
                        return res != 0 ? res : 1; // Special fix to preserve items with equal values
                    }
                }
        );
        sortedEntries.addAll(map.entrySet());
        return sortedEntries;
    }
}