function solution(stringArray) {
    let matrix = [];
    for (let i = 0; i < stringArray.length; i++) {
        matrix[i] = [];
        let row = stringArray[i].split(' ');
        for (let j = 0; j < row.length; j++) {
            matrix[i][j] = row[j];
        }
    }

    let diagonalRow = 0;
    let leftDiagonalCol = 0;
    let rightDiagonalCol = matrix[0].length - 1;

    let leftDiagonalSum = 0;
    let rightDiagonalSum = 0;

    for (let i = 0; i < matrix.length; i++) {
        leftDiagonalSum += +matrix[diagonalRow][leftDiagonalCol];
        rightDiagonalSum += +matrix[diagonalRow][rightDiagonalCol];
        diagonalRow++;
        leftDiagonalCol++;
        rightDiagonalCol--;
    }

    diagonalRow = 0;
    leftDiagonalCol = 0;
    rightDiagonalCol = matrix[0].length - 1;

    if (leftDiagonalSum === rightDiagonalSum) {
        for (let i = 0; i < matrix.length; i++) {
            for (let j = 0; j < matrix[i].length; j++) {
                if ((i === diagonalRow && j === leftDiagonalCol) ||
                    (i === diagonalRow && j === rightDiagonalCol)) {
                    continue;
                }
                matrix[i][j] = leftDiagonalSum;
            }
            diagonalRow++;
            leftDiagonalCol++;
            rightDiagonalCol--;
        }
    }

    for (let i = 0; i < matrix.length; i++) {
        console.log(matrix[i].join(' '));

    }
}


solution(['1 1 1',
    '1 1 1',
    '1 1 0']
);