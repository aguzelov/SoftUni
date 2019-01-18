function calorieCalculator(personData, workouts){
    let sex = personData[0];
    let weight = +personData[1];
    let height = +personData[2];
    let age = +personData[3];

    var metabolism = {
        'm' : function(weight, height, age) {
            return 66 +13.8 * weight + 5 * height - 6.8 * age;
        },
        'f' : function(weight, height, age) {
            return 655 + 9.7 * weight + 1.85 * height - 4.7 * age;
        },
    };

    let metabolismData = +metabolism[sex](weight, height, age);
    let activeFactor = 1.2;
    if(workouts >= 1 && workouts <= 2) {
        activeFactor = 1.375;
    }else if(workouts >= 3 && workouts <= 5){
        activeFactor = 1.55;
    }
    else if(workouts >= 6 && workouts <= 7){
        activeFactor = 1.725;
    }else if(workouts > 7){
        activeFactor = 1.90;
    }

    let dailyCalorieIntake = Math.round(metabolismData * activeFactor);

    console.log(dailyCalorieIntake);
}

calorieCalculator(['m', 86, 185, 25], 3);