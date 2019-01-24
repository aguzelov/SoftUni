(function () {
    let exerciseElement = document.getElementById('exercise');
    let inputElement = exerciseElement.querySelector('fieldset div input');
    let buttonElement = exerciseElement.querySelector('fieldset div button');

    buttonElement.addEventListener('click', function () {
        let input = inputElement.value;
        let lastDigit = +input[input.length - 1];

        let sumNum = 0;
        for (let index = 0; index < input.length - 1; index++) {
            sumNum += getWeight(+input[index], index);
        }

        sumNum = +(sumNum % 11).toString().split('').pop();

        let responseElement = document.getElementById('response');

        responseElement.textContent = lastDigit === sumNum ? 'This number is Valid!' : 'This number is NOT Valid!';
    });

    function getWeight(num, index) {
        let weightPosition = [2, 4, 8, 5, 10, 9, 7, 3, 6];

        let result = num * weightPosition[index];

        return result;
    }
})();