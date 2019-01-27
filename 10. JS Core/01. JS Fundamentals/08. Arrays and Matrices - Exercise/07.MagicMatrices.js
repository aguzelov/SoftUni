function solution(arr) {
    let rowSum = 0;
    let colSum = 0;

    let isMagic = true;

    for (let i = 0; i < arr.length; i++) {
        let currentRowSum = arr[i].reduce((a, b) => a + b, 0);

        if (i === 0) {
            rowSum = currentRowSum;
        } else if (rowSum !== currentRowSum) {
            isMagic = false;
            break;
        }

        let currentColSum = 0;
        for (let j = 0; j < arr[i].length; j++) {

            if (i === 0) {
                colSum += arr[i][j];
                currentColSum += arr[i][j];
            } else {
                currentColSum += arr[i][j];
            }

        }

        if (colSum !== currentColSum) {
            isMagic = false;
            break;
        }
    }

    console.log(isMagic);
}


solution([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]
);