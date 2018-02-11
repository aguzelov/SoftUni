import java.util.Locale;
import java.util.Scanner;

public class URL_Parser {
    public static void main(String[] args) {
        Locale.setDefault(Locale.ROOT);
        Scanner scanner = new Scanner(System.in);

        String url = scanner.nextLine();
        String protocol = "";
        String server = "";
        String resource = "";

        int index = url.indexOf("://");
        if(index >= 0){
            protocol = url.substring(0, index);
            url = url.replace(protocol+"://", "");
        }

        index = url.indexOf("/");
        if(index < 0){
            server = url;
        }else{
            server = url.substring(0, index);
            resource = url.substring(index+1, url.length());
        }


        System.out.println("[protocol] = \"" + protocol + "\"");
        System.out.println("[server] = \"" +server + "\"");
        System.out.println("[resource] = \"" +resource + "\"");
    }
}