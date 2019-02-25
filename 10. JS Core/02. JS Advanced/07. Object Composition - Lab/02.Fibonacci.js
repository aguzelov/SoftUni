function getFibonator() {
    let sum = 0;
    let first = 0;
    let second = 1;

    return function next() {
        sum = first + second;
        first = second;
        second = sum;

        return first;
    };
}
