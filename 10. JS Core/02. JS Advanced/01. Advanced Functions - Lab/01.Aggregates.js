function aggregates(arr) {
    //Sum
    console.log('Sum = ' + arr.reduce((a, b) => a + b, 0));
    //Min
    console.log('Min = ' + arr.reduce((a, b) => b < a ? b : a, Number.MAX_SAFE_INTEGER));
    //Max
    console.log('Max = ' + arr.reduce((a, b) => b > a ? b : a, Number.MIN_SAFE_INTEGER));
    //Product
    console.log('Product = ' + arr.reduce((a, b) => a * b, 1));
    //Join
    console.log('Product = ' + arr.reduce((a, b) => a + b, ''));
}

aggregates([2, 3, 10, 5]);