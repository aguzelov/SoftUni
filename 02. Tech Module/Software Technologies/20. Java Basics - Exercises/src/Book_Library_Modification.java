import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;

public class Book_Library_Modification {
    public static void main(String[] args) throws ParseException {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        int n = scanner.nextInt();
        scanner.nextLine();

        TreeMap<String, Date> authors = new TreeMap<>();
        SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");
        for (int i = 0; i < n; i++) {
            String[] input = scanner.nextLine().split(" ");
            String title = input[0];
            Date date = dateFormat.parse(input[3]);

            if (authors.containsKey(title)){
                authors.put(title, date);
            }else{
                authors.put(title,date);
            }
        }

        Date date = dateFormat.parse(scanner.nextLine());
        for(Map.Entry<String,Date> entry : entriesSortedByValues(authors)){
            if(entry.getValue().after(date)){
                System.out.printf("%s -> %s%n", entry.getKey(),dateFormat.format(entry.getValue()));
            }
        }
    }
    static <K,V extends Comparable<? super V>> SortedSet<Map.Entry<K,V>> entriesSortedByValues(Map<K,V> map) {
        SortedSet<Map.Entry<K,V>> sortedEntries = new TreeSet<Map.Entry<K,V>>(
                new Comparator<Map.Entry<K,V>>() {
                    @Override public int compare(Map.Entry<K,V> e1, Map.Entry<K,V> e2) {
                        int res = e1.getValue().compareTo(e2.getValue());
                        return res != 0 ? res : 1; // Special fix to preserve items with equal values
                    }
                }
        );
        sortedEntries.addAll(map.entrySet());
        return sortedEntries;
    }
}