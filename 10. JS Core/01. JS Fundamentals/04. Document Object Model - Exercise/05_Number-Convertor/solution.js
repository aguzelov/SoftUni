function solve() {
    let exerciseElement = document.getElementById('exercise');

    let selectMenuToElement = document.getElementById("selectMenuTo");
    var binaryOption = document.createElement("option");
    binaryOption.text = "Binary";
    binaryOption.value = "binary";
    selectMenuToElement.add(binaryOption);
    var hexOption = document.createElement("option");
    hexOption.text = "Hexadeicmal";
    hexOption.value = "hexadeicmal";
    selectMenuToElement.add(hexOption);

    let buttonElement = exerciseElement.querySelector('#menus button');
    buttonElement.addEventListener('click', function () {
        let inputElement = exerciseElement.querySelector('#menus #input');
        let resultElement = exerciseElement.querySelector('div #result');
        let inputValue = +inputElement.value;

        // let selectMenuToElement = document.getElementById("selectMenuTo");

        let selectedOption = selectMenuToElement.options[selectMenuToElement.selectedIndex].text;
        // let selectedOption = selectMenuToElement.options[0].value;

        console.log(selectedOption);


        if (selectedOption === 'Binary') {
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