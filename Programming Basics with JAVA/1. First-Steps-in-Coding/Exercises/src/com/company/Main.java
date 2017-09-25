package com.company;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        double money = 200;
        money+=500;
        money = icreaseFirst(money);
        for(int years = 2; years <= 18; years++){
            for(int mounts = 1; mounts <= 12; mounts++){
                money +=100;
            }
            if(years <= 3){
                money = icreaseFirst(money);
            }else if(years >3 && years <= 8){
                money = icreaseSecond(money);
            }else if(years >8 && years <= 13){
                money = icreaseThird(money);
            }else if(years> 13){
                money = icreaseFore(money);
            }else {
                System.out.println("error");
            }
        }
        System.out.println("Final money: " + money);
    }

    public static double icreaseFirst(double value){
        value += value*0.20;
        return value;
    }
    public static double icreaseSecond(double value){
        value += value*0.15;
        return value;
    }
    public static double icreaseThird(double value){
        value += value*0.10;
        return value;
    }
    public static double icreaseFore(double value){
        value += value*0.05;
        return value;
    }
}
