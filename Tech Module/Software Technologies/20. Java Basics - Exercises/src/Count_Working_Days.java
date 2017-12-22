import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Scanner;

public class Count_Working_Days {
    private static String[] holidays = new String[] {"1 Jan", "3 March", "1 May", "6 May", "24 May", "6 Sept", "22 Sept", "1 Nov", "24 Dec", "25 Dec", "26 Dec"};

    public static void main(String[] args) throws ParseException {
        Scanner scanner = new Scanner(System.in);
        DateFormat df = new SimpleDateFormat("dd-MM-yyyy");

        String input = scanner.nextLine();
        Date startDate = df.parse(input);

        input = scanner.nextLine();
        Date endDate = df.parse(input);

        Calendar start = Calendar.getInstance();
        start.setTime(startDate);

        Calendar end = Calendar.getInstance();
        end.setTime(endDate);

        int workDays = 0;

        do {
            //excluding start date
            if (start.get(Calendar.DAY_OF_WEEK) != Calendar.SATURDAY && start.get(Calendar.DAY_OF_WEEK) != Calendar.SUNDAY && !isHolidays(start)) {
                ++workDays;
            }
            start.add(Calendar.DAY_OF_MONTH, 1);
        } while (start.getTimeInMillis() <= end.getTimeInMillis()); //excluding end date

        System.out.println(workDays);
    }

    private static boolean isHolidays(Calendar start) {
        String date = start.get(Calendar.DAY_OF_MONTH) + " ";
        switch (start.get(Calendar.MONTH)){
            case 0: date += "Jan"; break;
            case 1: date += "Feb"; break;
            case 2: date += "March"; break;
            case 3: date += "April"; break;
            case 4: date += "May"; break;
            case 5: date += "June"; break;
            case 6: date += "July"; break;
            case 7: date += "Aug"; break;
            case 8: date += "Sept"; break;
            case 9: date += "Oct"; break;
            case 10: date += "Nov"; break;
            case 11: date += "Dec"; break;
        }

        for(String h : holidays){
            if(h.equals(date)){
                return true;
            }
        }
        return false;
    }
}