function stringCalculator(...arr){
    let sum = 0;

    for(let str of arr){
        sum += str.length;
    }

    console.log(sum);
    console.log(Math.floor( sum / arr.length));

}

stringCalculator('pasta', '5', '22.3');