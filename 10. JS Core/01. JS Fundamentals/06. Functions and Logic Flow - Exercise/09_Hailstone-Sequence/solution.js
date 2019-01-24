function getNext() {
    let numElement = document.getElementById('num');

    let resultElement = document.getElementById('result');

    let num = +numElement.value;

    let result = hailStoneSeq(num);

    resultElement.textContent = result + ' ';

    function hailStoneSeq(n) {
        let seq = [n];

        while (n != 1) {
            if (n % 2 === 0) {
                n /= 2;
            }
            else {
                n = (n * 3) + 1;
            }

            seq.push(n);
        }

        return seq.join(' ');
    }

}