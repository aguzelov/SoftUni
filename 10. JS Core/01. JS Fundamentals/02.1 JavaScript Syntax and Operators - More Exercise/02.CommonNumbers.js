function solve(...input) {

    let array = [];
    let sum = 0;

    for (let num of input[0]) {
        let isContains = isIncludes(num, input[1]) && isIncludes(num, input[2]);

        if (isContains) {
            array.push(num);
            sum += num;
        }
    }

    function isIncludes(num, arr) {
        return arr.includes(num);
    }

    function median(array) {
        array.sort(function (a, b) {
            return a - b;
        });

        if (array.length === 0) return 0

        var half = Math.floor(array.length / 2);

        if (array.length % 2)
            return array[half];
        else
            return (array[half - 1] + array[half]) / 2.0;
    }

    console.log(`The common elements are ${array.sort().join(', ')}.`);
    console.log(`Average: ${sum / array.length}.`);
    console.log(`Median: ${median(array)}.`);
}

solve(
    [1, 2, 3, 4, 5],
    [3, 2, 1, 5, 8],
    [2, 5, 3, 1, 16]

);