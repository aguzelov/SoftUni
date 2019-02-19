function solve() {
    let name = arguments[0];
    let age = +arguments[1];
    let weight = +arguments[2];
    let height = +arguments[3];
    let heightInMeters = height / 100;

    let bmi = weight / (heightInMeters * heightInMeters);
    bmi = Math.round(bmi);
    let status = '';
    if (bmi < 18.5) status = 'underweight';
    else if (bmi <= 25) status = 'normal';
    else if (bmi <= 30) status = 'overweight';
    else status = 'obese';

    let parient = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height,
        },
        BMI: bmi,
        status: status
    };

    if (status === 'obese') {
        parient.recommendation = 'admission required';
    }
    return parient;
}

console.log(solve('Honey Boo Boo', 33, 66, 162));