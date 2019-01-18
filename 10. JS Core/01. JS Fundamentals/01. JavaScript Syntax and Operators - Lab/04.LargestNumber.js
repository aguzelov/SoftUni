function findLargest(...arr){
    let largestNum = Number.MIN_SAFE_INTEGER;
    for(let num of arr){
        if(largestNum < num) largestNum = num;
    }

    console.log(`The largest number is ${largestNum}.`);
}

findLargest(-3, -5, -22.5);