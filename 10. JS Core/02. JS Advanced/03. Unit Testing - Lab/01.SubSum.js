function subsum(range, start, end) {

    if (!Array.isArray(range)) {
        return NaN;
    }

    if (start < 0) {
        start = 0;
    }

    if (end < 0 || end > range.length) {
        end = range.length - 1;
    }

    return range.slice(start, end + 1)
        .map(Number)
        .reduce((a, b) => a + b, 0);
}


let result = subsum(['10', '20', '30', '40', '50', '60'], 3, 300);

console.log(result);
