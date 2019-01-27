function solution(arr) {
    let step = +arr.pop();

    for (let index = 0; index < arr.length; index += step) {
        console.log(arr[index]);
    }
}


solution(['5',
    '20',
    '31',
    '4',
    '20',
    '2']
);