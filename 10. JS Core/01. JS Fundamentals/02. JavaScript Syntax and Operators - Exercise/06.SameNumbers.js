function checkForSameNumberAndSumAllDigits(number){

    var numberAsString = number.toString();

    var sum = 0;
    var previosDigit;
    var isSame = true;
    for (let index = 0; index < numberAsString.length; index++) {
        sum += +numberAsString[index];

        if(index === 0){
            continue;
        }

        if(numberAsString[index] !== numberAsString[index -1]){
            isSame = false;
        }
        
    }

    console.log(isSame);
    console.log(sum);
}

checkForSameNumberAndSumAllDigits(14444);