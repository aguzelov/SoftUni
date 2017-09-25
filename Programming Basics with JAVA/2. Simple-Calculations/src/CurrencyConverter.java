import java.util.Locale;
import java.util.Scanner;

/**
 * Created by Aleksandur on 9.7.2017 г..
 */
public class CurrencyConverter {
    public static void main(String[] args){
        Locale.setDefault(Locale.ROOT);
        Scanner input = new Scanner(System.in);
        Currency money = new Currency();
        money.setValue(input.nextDouble());
        money.setInputCurrency(input.next());
        money.setOutputCurrency(input.next());

        System.out.printf("%.2f %s", money.convert(), money.getOutputCurrency());
    }
}

class Currency{
    public double getValue() {
        return value;
    }

    public void setValue(double value) {
        this.value = value;
    }

    public String getInputCurrency() {
        return inputCurrency;
    }

    public void setInputCurrency(String inputCurrency) {
        this.inputCurrency = inputCurrency;
    }

    public String getOutputCurrency() {
        return outputCurrency;
    }

    public void setOutputCurrency(String outputCurrency) {
        this.outputCurrency = outputCurrency;
    }

    public double convert(){
        if(this.inputCurrency.equals("BGN")) {
            if (this.outputCurrency.equals("USD")) {
                return value / 1.79549;
            } else if (this.outputCurrency.equals("EUR")) {
                return value / 1.95583;
            } else if (this.outputCurrency.equals("GBP")) {
                return value / 2.53405;
            }
        }else if(this.inputCurrency.equals("USD")) {
            if (this.outputCurrency.equals("BGN")) {
                return value * 1.79549;
            } else if (this.outputCurrency.equals("EUR")) {
                return (value * 1.79549) / 1.95583;
            } else if (this.outputCurrency.equals("GBP")) {
                return (value * 1.79549) / 2.53405;
            }
        }else if(this.inputCurrency.equals("EUR")){
            if (this.outputCurrency.equals("USD")) {
                return (value * 1.95583) / 1.79549;
            } else if (this.outputCurrency.equals("BGN")) {
                return value * 1.95583;
            } else if (this.outputCurrency.equals("GBP")) {
                return (value * 1.95583) / 2.53405;
            }
        }else if(this.inputCurrency.equals("GBP")) {
            if (this.outputCurrency.equals("USD")) {
                return (value * 2.53405) / 1.79549;
            } else if (this.outputCurrency.equals("EUR")) {
                return (value * 2.53405) / 1.95583;
            } else if (this.outputCurrency.equals("BGN")) {
                return value * 2.53405;
            }
        }
        return 1;
    }

    double value;
    String inputCurrency;
    String outputCurrency;


}
