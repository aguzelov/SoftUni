import java.util.*;
class StudentsNameComparator implements Comparator{

    public int compare(Object o1, Object o2) {

        Student e1=(Student) o1;
        Student e2=(Student) o2;
        if(e1.getName().equals(e2.getName())){
            return e2.getAverage().compareTo(e1.getAverage());
        }
        return e1.getName().compareTo(e2.getName());
    }
}

public class Average_Grades {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        TreeSet<Student> students = new TreeSet<Student>(new StudentsNameComparator());

        int n = scanner.nextInt();
        scanner.nextLine();

        for (int i = 0; i < n; i++) {
            String[] input = scanner.nextLine().split(" ");
            String name = input[0];
            ArrayList<Double> grades = new ArrayList<>();
            for (int j = 1; j < input.length; j++) {
                grades.add(Double.parseDouble(input[j]));
            }
            students.add(new Student(name, grades));
        }

        for (Student s : students){
            if(s.getAverage()>= 5.00){
                System.out.printf("%s -> %.2f%n",s.getName(),s.getAverage());
            }
        }
    }
}

class Student {
    public Student(String name, ArrayList<Double> grades) {
        this.name = name;
        this.grades = grades;

        Double total =0.0;
        for(Double grade : grades){
            total += grade;
        }
        this.average = total / grades.size();
    }

    public Student() {
    }

    public String getName() {
        return name;
    }

    public ArrayList<Double> getGrades() {
        return grades;
    }

    public Double getAverage() {
        return average;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setGrades(ArrayList<Double> grades) {
        this.grades = grades;
    }

    private String name;
    private ArrayList<Double> grades = new ArrayList<>();
    private Double average;
}