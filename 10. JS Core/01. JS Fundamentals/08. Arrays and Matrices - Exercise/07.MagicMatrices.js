function solution(arr) {

    console.log(isMagicMatrix(arr));

    function isMagicMatrix(matrix) {
        let sum = 0;

        // For sums of Rows 
        for (let i = 0; i < matrix.length; i++) {
            let rowSum = 0;
            for (let j = 0; j < matrix[i].length; j++) {
                rowSum += +matrix[i][j];
            }

            if (sum !== 0 && rowSum !== sum) {
                return false;
            }
            sum = rowSum;
        }

        // For sums of Columns 
        for (let i = 0; i < matrix.length; i++) {
            let colSum = 0;
            for (let j = 0; j < matrix.length; j++) {
                colSum += +matrix[j][i];
            }

            // check if every column sum is 
            // equal to prime diagonal sum 
            if (sum != colSum)
                return false;
        }

        return true;
    }
}


solution([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
);