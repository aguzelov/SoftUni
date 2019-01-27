function solution(input) {
    let rows = +input[0];
    let cols = +input[1];
    let x = +input[2];
    let y = +input[3];

    let matrix = [];
    let offset = 1;
    for (let i = 0; i < rows; i++) {
        matrix[i] = [];
        for (let j = 0; j < cols; j++) {
            if (i === x && j === y) {
                matrix[i][j] = offset;
            } else {
                matrix[i][j] = 0;
            }
        }
    }

    let currentNum = 1;
    while (offset < rows) {
        currentNum++;
        for (let xOffset = x - offset; xOffset <= x + offset; xOffset++) {
            for (let yOffset = y - offset; yOffset <= y + offset; yOffset++) {

                if (isInRange(xOffset, yOffset) && matrix[xOffset][yOffset] === 0) {
                    setCell(matrix, xOffset, yOffset, currentNum);
                }
            }
        }
        offset++;

    }

    for (let i = 0; i < matrix.length; i++) {
        console.log(matrix[i].join(' '));

    }

    function setCell(matrix, row, col, value) {
        if (isInRange(row, col)) {
            matrix[row][col] = value;
        }
    }

    function isInRange(row, col) {
        if ((row < 0 || row >= matrix.length) ||
            (col < 0 || col >= matrix[row].length)) {
            return false;
        }
        return true;
    }

}


solution([3, 3, 2, 2]);