function binarySearch() {
    let arrElement = document.getElementById('arr');
    let numElement = document.getElementById('num');

    let resultElement = document.getElementById('result');

    let arr = arrElement.value.split(', ');
    let num = +numElement.value;

    arr.sort(function (a, b) {
        return a - b;
    });

    let index = binarySearch(arr, num, compare);

    resultElement.textContent = index >= 0 ?
        `Found ${num} at index ${index}` :
        `${num} is not in the array`;

    function binarySearch(ar, el, compare_fn) {
        var m = 0;
        var n = ar.length - 1;
        while (m <= n) {
            var k = (n + m) >> 1;
            var cmp = compare_fn(el, +ar[k]);
            if (cmp > 0) {
                m = k + 1;
            } else if (cmp < 0) {
                n = k - 1;
            } else {
                return k;
            }
        }
        return -m - 1;
    }

    function compare(a, b) {
        if (a > b) {
            return 1;
        } else if (a < b) {
            return -1;
        } else {
            return 0;
        }
    }
}