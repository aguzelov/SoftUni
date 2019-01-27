function solution(arr) {
    let currentBiggestElement = 0;

    arr.filter(function (num) {
        if (+num >= currentBiggestElement) {
            console.log(+num);
            currentBiggestElement = +num;
        }
    });
}

solution([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
);