function solve() {
    let exerciseElement = document.getElementById('exercise');

    let buttonElement = exerciseElement.querySelector('#menus button');
    buttonElement.addEventListener('click', function () {
        let inputElement = exerciseElement.querySelector('#menus #input');
        let resultElement = exerciseElement.querySelector('div #result');
        let inputValue = +inputElement.value;

        let selectMenuToElement = document.getElementById("selectMenuTo");

        // let selectedOption = selectMenuToElement.options[selectMenuToElement.selectedIndex].text;
        let selectedOption = selectMenuToElement.options[0].value;

        if (selectedOption === '') {
            var binary = parseInt(inputValue, 10);
            resultElement.value = binary.toString(2);

        } else {
            if (inputValue < 0) {
                inputValue = 0xFFFFFFFF + inputValue + 1;
            }
            resultElement.value = inputValue.toString(16).toUpperCase();
        }
    });
}