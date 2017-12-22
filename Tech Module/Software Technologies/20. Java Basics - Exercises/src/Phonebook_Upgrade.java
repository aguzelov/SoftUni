import java.util.*;

public class Phonebook_Upgrade {
    private static TreeMap<String, String> phonebook = new TreeMap<>();
    private static Scanner scanner = new Scanner(System.in);
    public static void main(String[] args) {

        while (TakeCommands()) {
        }
    }

    private static boolean TakeCommands() {
        String[] command = scanner.nextLine().split(" ");

        switch (command[0]) {
            case "A":
                String name = command[1];
                String number = command[2];
                add(name, number);
                break;
            case "S":
                name = command[1];
                search(name);
                break;
            case "ListAll":
                listAll();
                break;
            case "END":
                return false;
        }
        return true;
    }

    private static void listAll() {
        for(Map.Entry<String,String> contact: phonebook.entrySet()){
            System.out.println(contact.getKey() + " -> " + contact.getValue());
        }
    }

    private static void add(String name, String number) {
        phonebook.put(name, number);
    }

    private static void search(String name) {
        if (phonebook.containsKey(name)) {
            System.out.printf("%s -> %s%n", name, phonebook.get(name));
        } else {
            System.out.printf("Contact %s does not exist.%n", name);
        }
    }
}