function evenNumbers(input){
    let n = Number(input);

    for (let index = 1; index <= n; index++) {

        if(index % 2 === 0){
            console.log(index);
        }
        
    }
}

evenNumbers(7);