function solution(row, col) {

    let currentNumber = 1;
    let matrix = [];

    for (let i = 0; i < row; i++) {
        matrix[i] = [];
        for (let j = 0; j < col; j++) {
            matrix[i][j] = 0;
        }
    }

    let toRight = true;
    let toDown = false;
    let toUp = false;
    let toLeft = false;

    let currentRow = 0;
    let currenCol = 0;


    let counter = 0;
    while (counter !== row * col) {
        if (toRight) {
            matrix[currentRow][currenCol++] = currentNumber++;
            if (currenCol === col || matrix[currentRow][currenCol] !== 0) {
                toRight = false;
                toDown = true;
                currenCol--;
                currentRow++;
            }
        } else if (toDown) {
            matrix[currentRow++][currenCol] = currentNumber++;
            if (currentRow === row || matrix[currentRow][currenCol] !== 0) {
                toDown = false;
                toLeft = true;
                currentRow--;
                currenCol--;
            }
        } else if (toLeft) {
            matrix[currentRow][currenCol--] = currentNumber++;
            if (currenCol < 0 || matrix[currentRow][currenCol] !== 0) {
                toLeft = false;
                toUp = true;
                currenCol++;
                currentRow--;
            }
        } else if (toUp) {
            matrix[currentRow--][currenCol] = currentNumber++;

            if (currentRow < 0 || matrix[currentRow][currenCol] !== 0) {
                toUp = false;
                toRight = true;
                currentRow++;
                currenCol++;
            }
        }
        counter++;

    }
    for (let index = 0; index < matrix.length; index++) {
        console.log(matrix[index].join(' '));

    }
}


solution(3, 3);