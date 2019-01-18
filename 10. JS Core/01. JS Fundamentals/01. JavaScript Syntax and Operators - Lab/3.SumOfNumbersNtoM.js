function sum(first, second){
    let start = +first;
    let end = +second;
    let sum = 0;

    for(let index = start; index <= end; index++){
        sum += index;
    }

    console.log(sum);
}


sum('-8', '20' );